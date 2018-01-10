using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ImageQualityPublisher
{
    /// <summary>
    /// Monitor folder for new files and run estimation procedures
    /// 1. Run CheckForNewFiles to check new files
    /// 2. for each new file RunQualityEstimation_async in separate thread
    /// 3. RunQualityEstimation_async in separate thread runs:
    ///     - quality estimation through DSSQualityReader class
    ///     - fits header data reading through FITSHeaderReader class
    ///     - publish result with the help of FileParseResult class to form
    ///     - publish result with the help of FileParseResult class to web
    /// </summary>
    public class FileMonitoring
    {
        public string settingsExtensionToSearch = "*.fit*"; //which extension to loop
        public bool settingsScanSubdirs = false;             //scan subdirs also

        //file list where to keep already parsed file
        private Dictionary<string, bool> FileList = new Dictionary<string, bool>();

        //link to mainform for callback functions
        private MainForm ParentMF;

        //status flag not to overlap threads
        bool bMonitoringThreadRun = false;

        private Thread monitorThread;

        public FileMonitoring(MainForm extMF)
        {
            ParentMF = extMF;
        }


        public void CheckForNewFiles_async(List<string> FileMonitorPathList)
        {
            if (!bMonitoringThreadRun)
            {
                bMonitoringThreadRun = true; //set to false on thread exit inside method
                monitorThread = new Thread(delegate ()
                {
                    CheckForNewFiles(FileMonitorPathList);
                });
                monitorThread.Start();
            }
        }

        public void AbortThread()
        {
            monitorThread.Abort();
            bMonitoringThreadRun = false;
        }

        /// <summary>
        /// Check for new files in DIRECTORIES
        /// Overload where directories as LIST<string>
        /// </summary>
        /// <param name="FileMonitorPathList">List of directories to check</param>
        public void CheckForNewFiles(List<string> FileMonitorPathList)
        {
            bMonitoringThreadRun = true;
            //LOOP throug all directory path and run overload method for every dir
            foreach (string curDir in FileMonitorPathList)
            {
                CheckForNewFiles(curDir);
            }
            bMonitoringThreadRun = false;
        }

        /// <summary>
        /// Check for new files in one DIRECTORIE
        /// Overload where directory is only one<string>
        /// </summary>
        /// <param name="FileMonitorPathSt"></param>
        public void CheckForNewFiles(string FileMonitorPathSt)
        {
            //1. SCAN CURRENT DIR
            //get all files
            string[] fileArray = Directory.GetFiles(FileMonitorPathSt, settingsExtensionToSearch);

            //check them all
            foreach(string filename in fileArray)
            {
                //string FileNameOnly = Path.GetFileName(filename);
                
                //is the file new?
                if (FileList.ContainsKey(filename))
                {
                    //do nothing
                }
                else
                {
                    //add to filelist
                    FileList.Add(filename, true);
                    ParentMF.ProcessingObj.QuequeAdd(filename);

                    Logging.AddLog("New file [" + filename + "] was detected and added to queque...", LogLevel.Activity, Highlight.Emphasize);
                }
            }

            //2. If set option to scan subdirs, run recursion
            if (settingsScanSubdirs)
            {
                //get directories
                string[] dirsArray = Directory.GetDirectories(FileMonitorPathSt);

                foreach (string dirname in dirsArray)
                {
                    CheckForNewFiles(dirname);
                }
            }
        }

        
        /// <summary>
        /// Reset current monitoring
        /// </summary>
        public void ClearFileList()
        {
            FileList.Clear();
        }

    }
}
