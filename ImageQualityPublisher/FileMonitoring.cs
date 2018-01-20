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
    /// 2. For each new file RunQualityEstimation_async in separate thread
    /// RunQualityEstimation_async in separate thread runs:
    ///     - quality estimation through DSSQualityReader class
    ///     - fits header data reading through FITSHeaderReader class
    ///     - publish result with the help of FileParseResult class to form
    ///     - publish result with the help of FileParseResult class to web
    /// </summary>
    public class FileMonitoring
    {
        public string settingsExtensionToSearch = "*.fit*"; //which extension to loop
        public bool settingsScanSubdirs = false;             //scan subdirs also

        /**************************************************************************************************
        * Private vars
        **************************************************************************************************/
        //file list where to keep already parsed file
        private Dictionary<string, DateTime> FileListParsed = new Dictionary<string, DateTime>();
        //Dir list as point of entry
        private Dictionary<string, DateTime> DirListToMonitor = new Dictionary<string, DateTime>();

        //link to mainform for callback functions
        private MainForm ParentMF;

        //status flag not to overlap threads
        private bool bMonitoringThreadRun = false;

        private Thread monitorThread;

        private DateTime VERY_OLD_TIME = new DateTime(1970, 1, 1);

        /**************************************************************************************************
        * Methods
        **************************************************************************************************/
        public FileMonitoring(MainForm extMF)
        {
            ParentMF = extMF;
        }

        /// <summary>
        /// Main methods - run checking for new files
        /// </summary>
        /// <param name="FileMonitorPathList"></param>
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


        /// <summary>
        /// Abort checking
        /// </summary>
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
                //1. Add current dir to dirlist with LAST TIME
                if (!DirListToMonitor.ContainsKey(curDir))
                {
                    DirListToMonitor.Add(curDir, VERY_OLD_TIME);
                }

                //2. Run check directory
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
            //string[] fileArray = Directory.GetFiles(FileMonitorPathSt, settingsExtensionToSearch);

            DirectoryInfo dir = new DirectoryInfo(FileMonitorPathSt);
            FileInfo[] fileArray = dir.GetFiles(settingsExtensionToSearch).OrderBy(p => p.LastWriteTime).ToArray();

            //check them all
            foreach (FileInfo fileEl in fileArray)
            {
                //string FileNameOnly = Path.GetFileName(filename);
                string filename = fileEl.FullName;

                //is the file new?
                if (!FileListParsed.ContainsKey(filename))
                { 
                    //1. Add to filelist with time
                    FileListParsed.Add(filename, fileEl.LastWriteTime);

                    //3. PROCESS
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
            FileListParsed.Clear();
        }

        /// <summary>
        /// Clear IMS Data
        /// </summary>
        public void ClearDirIMSData()
        {
            foreach(string curDirName in DirListToMonitor.Keys)
            {
                DirListToMonitor[curDirName] = VERY_OLD_TIME;
            }
        }


        /// <summary>
        /// Check if FileDate is newer then Directory IMS
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool CheckFileForIMS(string FileName)
        {
            DateTime FileDate = FileListParsed[FileName];

            string DirName = Path.GetDirectoryName(FileName);
            DateTime DirIMSDate = DirListToMonitor[DirName];

            bool res = (FileDate > DirIMSDate);

            return res;

        }

        /// <summary>
        /// Update Directory IMS if FileDate is newer
        /// </summary>
        /// <param name="FileName"></param>
        public void UpdateDirIMS(string FileName)
        {
            DateTime FileDate = FileListParsed[FileName];

            string DirName = Path.GetDirectoryName(FileName);
            DateTime DirIMSDate = DirListToMonitor[DirName];

            if (DirIMSDate < FileDate) DirListToMonitor[DirName] = FileDate;
        }

    }
}
