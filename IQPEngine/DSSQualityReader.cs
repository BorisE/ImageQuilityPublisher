using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using LoggingLib;

namespace IQPEngineLib
{
    public class DSSQualityData
    {
        public Int32 StarsNumber = 0;
        public Double SkyBackground = 0.0;

        internal Double MeanRadiusSum = 0.0;
        internal Int32 MeanRadiusNum = 0;

        internal Double AspectRatioSum = 0.0;
        internal Int32 AspectRatioNum = 0;

        internal const double Multiplier = 1.566;

        public double MeanRadius
        {
            get
            {
                return MeanRadiusSum/ MeanRadiusNum * Multiplier;
            }
        }

        public double AspectRatio
        {
            get
            {
                return AspectRatioSum / AspectRatioNum;
            }
        }
    }

    /************************************************************************************************************************************************/
    /// <summary>
    /// Main class for getting QulityEstimation data
    /// 1. Run EvaluateFile()
    /// 2. After this run GetEvaluationResults()
    /// 3. Get result in QualityEstimate field
    /// </summary>
    public class DSSQualityReader
    {
        //settings
        public string settingsDSSCLPath;
        public bool settingsDSSForceRecheck = false;
        public bool settingsDSSForceRunHidden = false;

        //current File
        public string FITSFileName = "";
        public string FITSFilePath = ""; //without slash - except root dir ;)

        //result data
        public DSSQualityData QualityEstimate = new DSSQualityData();

        //process obj
        private Process objProcess = new Process();

        public DSSQualityReader(string DSSCLPath)
        {
            settingsDSSCLPath = DSSCLPath;
        }

        public DSSQualityReader()
                :this(  @"c:\Program Files (x86)\DeepSkyStacker\DeepSkyStackerCL.exe")
        {}

        /// <summary>
        /// 1. Run image evaluation process
        /// Run this first
        /// </summary>
        /// <param name="FullFITSFileNameExt">file to evaluate</param>
        /// <param name="asyncrun">false - to run in sync mode</param>
        public void EvaluateFile(string FullFITSFileNameExt = "", bool asyncrun = false)
        {
            //0. Compose image FileName
            if (FullFITSFileNameExt != "")
            {
                FITSFileName = Path.GetFileName(FullFITSFileNameExt);
                FITSFilePath = Path.GetDirectoryName(FullFITSFileNameExt);
            }
            string FullFITSFileName = Path.Combine(FITSFilePath, FITSFileName);

            //1. Create image list for DSS
            string dsslistFileName = Path.GetRandomFileName();
            dsslistFileName = Path.ChangeExtension(dsslistFileName, "txt");
            dsslistFileName = Path.Combine(Path.GetTempPath(), dsslistFileName);
            try
            {
                using (StreamWriter DssListStream = new StreamWriter(dsslistFileName))
                {
                    DssListStream.WriteLine("DSS file list"); //Header 1st line
                    DssListStream.WriteLine("CHECKED\tTYPE\tFILE"); //Header 2nd line
                    DssListStream.WriteLine("1\tlight\t" + FullFITSFileName); //for our file
                }
                Logging.AddLog("DSS filelist for file [" + FullFITSFileName + "] created", LogLevel.Debug);
            }
            catch (Exception ex)
            {
                Logging.AddLog("Cant write DSS filelist [" + dsslistFileName + "]", LogLevel.Important, Highlight.Error);
                Logging.AddLog(MethodBase.GetCurrentMethod().Name + "error! [" + ex.ToString() + "]", LogLevel.Debug, Highlight.Error);
            }


            //2. Запуск DSS для измерения
            string DSSOption = "/r";
            if (settingsDSSForceRecheck) DSSOption = "/R";
            try
            {
                objProcess.StartInfo.FileName = settingsDSSCLPath;
                objProcess.StartInfo.WindowStyle = (settingsDSSForceRunHidden ? ProcessWindowStyle.Hidden : ProcessWindowStyle.Minimized);
                objProcess.StartInfo.UseShellExecute = true;
                objProcess.StartInfo.Arguments = " " + DSSOption + " " + dsslistFileName; // /R for rechecking
                objProcess.Start();

                Logging.AddLog("DSSLiveCL thread for evaluating file [" + FullFITSFileName + "] started", LogLevel.Activity);

                if (asyncrun == false)
                {
                    objProcess.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Logging.AddLog("Cant run DSSLiveCL", LogLevel.Important, Highlight.Error);
                Logging.AddLog(MethodBase.GetCurrentMethod().Name + "error! [" + ex.ToString() + "]", LogLevel.Debug, Highlight.Error);
            }
        }
    


        /// <summary>
        /// 2. Get result
        /// After running his function get FITSQualityData
        /// And file could be deleted after
        /// </summary>
        public DSSQualityData GetEvaluationResults(bool DeleteFileAfterRead = false)
        {
            //0. Compose file name
            string InfoFileName = Path.Combine(FITSFilePath, Path.GetFileNameWithoutExtension(FITSFileName) + ".Info.txt");

            //1. Read info file
            try
            {
                using (StreamReader InfoFileStream = new StreamReader(InfoFileName))
                {
                    string line = "";
                    while ((line = InfoFileStream.ReadLine()) != null)
                    {
                        ParseInfoFileLine(line);
                    }
                }
                Logging.AddLog("Info file [" + InfoFileName + "] readed", LogLevel.Debug);

                //2. If needed - delete file
                File.Delete(InfoFileName);
                Logging.AddLog("Info file [" + InfoFileName + "] deleted", LogLevel.Debug);


            }
            catch (Exception ex)
            {
                Logging.AddLog("Cant read info file [" + InfoFileName + "]", LogLevel.Important, Highlight.Error);
                Logging.AddLog(MethodBase.GetCurrentMethod().Name + "error! [" + ex.ToString() + "]", LogLevel.Debug, Highlight.Error);
            }
            return QualityEstimate;
        }

        private void ParseInfoFileLine(string LineSt)
        {
            
            // 1. HEADER DATA
            //SkyBackground = 0.0269
            if (LineSt.Contains("SkyBackground"))
            {
                int beg1 = LineSt.LastIndexOf("=")+1;
                string Val = LineSt.Substring(beg1).Trim();
                if (!UtilsFunctions.TryParseToDouble(Val, out QualityEstimate.SkyBackground))
                    QualityEstimate.SkyBackground = 0.0;
            }
            //NrStars = 77
            else if (LineSt.Contains("NrStars"))
            {
                int beg1 = LineSt.LastIndexOf("=") + 1;
                string Val = LineSt.Substring(beg1).Trim();
                if (!int.TryParse(Val, out QualityEstimate.StarsNumber))
                    QualityEstimate.StarsNumber = 0;
            }

            // 2. PER STAR DATA
            //MeanRadius = 2.12
            else if (LineSt.Contains("MeanRadius"))
            {
                int beg1 = LineSt.LastIndexOf("=") + 1;
                string Val = LineSt.Substring(beg1).Trim();
                double dblVal = 0.0;
                if (UtilsFunctions.TryParseToDouble(Val, out dblVal))
                {
                    QualityEstimate.MeanRadiusSum += dblVal;
                    QualityEstimate.MeanRadiusNum++;
                }
            }

            //Axises = 10.00, 2.64, 2.65, 2.54, 2.53
            //fMajorAxisAngle, fLargeMajorAxis, fSmallMajorAxis, fLargeMinorAxis, fSmallMinorAxis
            else if (LineSt.Contains("Axises"))
            {
                int beg1 = LineSt.LastIndexOf("=") + 1;
                string AxisValuesSt = LineSt.Substring(beg1).Trim();
                string[] AxisValues = AxisValuesSt.Split(',');
                double fMajorAxisAngle = 0.0, fLargeMajorAxis = 0.0, fSmallMajorAxis = 0.0, fLargeMinorAxis = 0.0, fSmallMinorAxis = 0.0;
                //fMajorAxisAngle
                if (UtilsFunctions.TryParseToDouble(AxisValues[0], out fMajorAxisAngle))
                {
                }
                //fLargeMajorAxis
                if (UtilsFunctions.TryParseToDouble(AxisValues[1], out fLargeMajorAxis))
                {
                    //fSmallMajorAxis
                    if (UtilsFunctions.TryParseToDouble(AxisValues[2], out fSmallMajorAxis))
                    {
                        //fLargeMinorAxis
                        if (UtilsFunctions.TryParseToDouble(AxisValues[3], out fLargeMinorAxis))
                        {
                            //fSmallMinorAxis
                            if (UtilsFunctions.TryParseToDouble(AxisValues[4], out fSmallMinorAxis))
                            {
                                //(star.m_fLargeMinorAxis+star.m_fSmallMinorAxis)/(star.m_fLargeMajorAxis+star.m_fSmallMajorAxis)
                                double AspRation = (fLargeMinorAxis + fSmallMinorAxis) / (fLargeMajorAxis + fSmallMajorAxis);

                                QualityEstimate.AspectRatioSum += AspRation;
                                QualityEstimate.AspectRatioNum++;

                            }
                        }
                    }
                }
            }

        }

    }
}
