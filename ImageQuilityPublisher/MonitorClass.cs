using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ImageQuilityPublisher
{
    public class MonitorClass
    {
        public string FileMonitorPath="";

        private Dictionary<string, bool> FileList = new Dictionary<string, bool>();


        MainForm ParentMF;

        public MonitorClass(MainForm extMF)
        {
            ParentMF = extMF;
        }

        /// <summary>
        /// Main method to call
        /// </summary>
        public void CheckForNewFiles()
        {
            //get all files
            string[] fileArray = Directory.GetFiles(FileMonitorPath, "*.fit*");

            foreach(string filename in fileArray)
            {
                string FileNameOnly = Path.GetFileName(filename);
                
                //is the file new?
                if (FileList.ContainsKey(FileNameOnly))
                {
                    //do nothing
                }
                else
                {
                    //add to filelist
                    FileList.Add(FileNameOnly, true);

                    //run async
                    Thread childThread = new Thread(delegate () {
                        RunQualityEstimation(filename);
                    });
                    childThread.Start();
                }
            }
        }
        
        private void RunQualityEstimation(string filename)
        {
            string FullFileName = Path.Combine(FileMonitorPath, filename);

            DSSQualityEstimator DSSObj = new DSSQualityEstimator();

            //Run evaluation in sync mode
            DSSObj.EvaluateFile(FullFileName);
            Logging.AddLog("Quality evaluatoion procedrure for file [" + FullFileName + "] finished", LogLevel.Activity);

            //Parse evaluation results
            DSSObj.GetEvaluationResults();
            Logging.AddLog("Quality results for file [" + FullFileName + "] were read", LogLevel.Activity);

            //Pulbish to form
            ParentMF.Invoke(new Action( () => ParentMF.PublishQualityData(FullFileName, DSSObj.QualityEstimate)  ));
            
            //Publsh to web

        }

        /// <summary>
        /// Need to be run when changing folder
        /// </summary>
        public void ClearFileList()
        {
            FileList.Clear();
        }

    }
}
