using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ImageQuilityPublisher
{

    class FITSQualityEstimate
    {
        public Int32 StarsNumber = 0;
        public Double FWHM = 0.0;
        public Double AspecRatio = 0.0;
        public Double SkyBackground = 0.0;
    }

    class DSSWrapper
    {

        public string DSSCLPath = @"c:\Program Files (x86)\DeepSkyStacker\DeepSkyStackerCL.exe";
        public string DSSimagelist = Path.GetTempPath() + "dss_list.txt";

        public string FITSFileName = "";
        public string FITSFilePath = ""; //with slash!

        public FITSQualityEstimate QualityEstimate = new FITSQualityEstimate();

        private Process objProcess = new Process();


        public void EvaluateFile(string FullFITSFileNameExt = "")
        {
            //0. Compose image FileName
            if (FullFITSFileNameExt != "")
            {
                FITSFileName = Path.GetFileName(FullFITSFileNameExt);
                FITSFilePath = Path.GetDirectoryName(FullFITSFileNameExt);
            }
            string FullFITSFileName = FITSFilePath + FITSFileName;

            //1. Create image list for DSS
            try
            {
                using (StreamWriter DssListStream = new StreamWriter(DSSimagelist))
                {
                    DssListStream.WriteLine("DSS file list"); //Header 1st line
                    DssListStream.WriteLine("CHECKED\tTYPE\tFILE"); //Header 2nd line
                    DssListStream.WriteLine("1\tlight\t" + FullFITSFileName); //for our file
                }
                Logging.AddLog("DSS filelist for file [" + FullFITSFileName + "] created", LogLevel.Debug);
            }
            catch (Exception ex)
            {
                Logging.AddLog("Cant write DSS filelist [" + DSSimagelist + "]", LogLevel.Important, Highlight.Error);
                Logging.AddLog(MethodBase.GetCurrentMethod().Name + "error! [" + ex.ToString() + "]", LogLevel.Debug, Highlight.Error);
            }


            //2. Запуск DSS для измерения
            objProcess.StartInfo.FileName = DSSCLPath;
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            objProcess.StartInfo.UseShellExecute = true;
            objProcess.StartInfo.Arguments = " /R "+ DSSimagelist;
            objProcess.Start();


            Logging.AddLog("DSSLiveCL for evaluating file [" + FullFITSFileName + "] started", LogLevel.Activity);
        }

        public void GetEvaluationResults()
        {
            //0. Compose file name
            string InfoFileName = FITSFilePath + Path.GetFileNameWithoutExtension(FITSFileName) + ".Info.txt";

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
            }
            catch (Exception ex)
            {
                Logging.AddLog("Cant read info file [" + InfoFileName + "]", LogLevel.Important, Highlight.Error);
                Logging.AddLog(MethodBase.GetCurrentMethod().Name + "error! [" + ex.ToString() + "]", LogLevel.Debug, Highlight.Error);
            }
        }

        private void ParseInfoFileLine(string LineSt)
        {
            //SkyBackground = 0.0269
            if (LineSt.Contains("SkyBackground"))
            {
                int beg1 = LineSt.LastIndexOf("=")+1;
                string BgVal = LineSt.Substring(beg1).Trim();

                if (!Utils.TryParseToDouble(BgVal, out QualityEstimate.SkyBackground))
                    QualityEstimate.SkyBackground = 0.0;
            }
            
            //1 Read file

            //2 Get overal key parameters from header
            //Int32 StarsNumber = 0;
            //Double SkyBackground = 0.0;

            //3 Count all fwhm values
        }

    }
}
