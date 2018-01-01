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
        Int32 StarsNumber = 0;
        Double FWHM = 0.0;
        Double AspecRatio = 0.0;
        Double SkyBackground = 0.0;
    }

    class DSSWrapper
    {

        public string DSSCLPath = @"c:\Program Files (x86)\DeepSkyStacker\DeepSkyStackerCL.exe";
        public string DSSimagelist = Path.GetTempPath() + "dss_list.txt";


        public string FITSFileName = "";
        public string FITSFilePath = "";

        private Process objProcess = new Process();


        public void EvaluateFile(string FullFITSFileName)
        {
            //string FullFITSFileName = FITSFilePath + FITSFileName;

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

        }

        private void GetDSSInfoFileHeader()
        {
            //1 Read file

            //2 Get overal key parameters from header
            //Int32 StarsNumber = 0;
            //Double SkyBackground = 0.0;

            //3 Count all fwhm values
        }

    }
}
