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

        public bool settingsFilterDate_UseFlag = false;
        public DateTime settingsFilterDateAfter = new DateTime(1970, 1, 1);
        public DateTime settingsFilterDateBefore = new DateTime(2017, 12, 12);
        public bool settingsFilterDirName_UseFlag = false;
        public List<string> settingsFilterDirName_ExcludeSt = new List<string> { "bad", "ифв" };
        public bool settingsFilterFileName_UseFlag = false;
        public List<string> settingsFilterFileName_ExcludeSt = new List<string> { "++-", "+++"} ;

        /**************************************************************************************************
        * Private vars
        **************************************************************************************************/
        //dir list which was scanned (including all subdirs)
        private Dictionary<string, DateTime> DirListToMonitor = new Dictionary<string, DateTime>();
        //dir list which was scanned (including all subdirs)
        //private Dictionary<string, DateTime> DirListProcessed = new Dictionary<string, DateTime>();
        //file list where to keep already parsed file
        private Dictionary<string, DateTime> FileListProcessed = new Dictionary<string, DateTime>();

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
            if (monitorThread != null && monitorThread.ThreadState == ThreadState.Running)
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
            //1. CHECK FOR DIRNAME FILTER (if needed)
            bool skipDir = false;
            if (settingsFilterDirName_UseFlag)
            {
                foreach (string DirNameExcludeSt in settingsFilterDirName_ExcludeSt)
                {
                    if (FileMonitorPathSt.Contains(DirNameExcludeSt))
                        skipDir = true;
                }
            }
            
            //1.2. ADD CURRENT DIR TO DirNameProcessing
            if (!DirListToMonitor.ContainsKey(FileMonitorPathSt))
            {
                //1.2.2. Add to skipdirlist
                DirListToMonitor.Add(FileMonitorPathSt, VERY_OLD_TIME );
                if (skipDir)
                {
                    Logging.AddLog("Skiping dirname [" + FileMonitorPathSt + "] because of filter...", LogLevel.Activity, Highlight.Error);
                }
            }

            //1.3. SKIP PROCESSING IF NEEDED
            if (skipDir)
            {
                return;
            }

            //2. SCAN CURRENT DIR
            //get all files
            //string[] fileArray = Directory.GetFiles(FileMonitorPathSt, settingsExtensionToSearch);
            FileInfo[] fileArray;
            try { 
                DirectoryInfo dir = new DirectoryInfo(FileMonitorPathSt);
                fileArray = dir.GetFiles(settingsExtensionToSearch).OrderBy(p => p.LastWriteTime).ToArray();
            }
            catch (Exception ex)
            {
                //dir doesn't exists - EXIT
                Logging.AddLog("Monitor dir ["+ FileMonitorPathSt + "] exception ["+ ex.Message + "]", LogLevel.Important, Highlight.Error);
                return;
            }

            //3. ENUMERATE ALL FILES
            bool skipFile = false;
            foreach (FileInfo fileEl in fileArray)
            {
                string filename = fileEl.FullName;

                //3.1. FILTER CHECK
                skipFile = false;
                //3.1.1. CHECK FOR DATE FILTER (if needed)
                if (settingsFilterDate_UseFlag && (fileEl.LastWriteTime.Date < settingsFilterDateAfter || fileEl.LastWriteTime.Date > settingsFilterDateBefore))
                {
                    Logging.AddLog("Skiping filename [" + fileEl.Name + "] because of filedate [" + fileEl.LastWriteTime.Date + "]...", LogLevel.Activity, Highlight.Error);
                    skipFile = true;
                }
                //3.1.2. CHECK FOR FILENAME FILTER (if needed)
                if (settingsFilterFileName_UseFlag)
                {
                    foreach(string FileNameExcludeSt in settingsFilterFileName_ExcludeSt)
                    {
                        if (fileEl.Name.Contains(FileNameExcludeSt))
                        { 
                            Logging.AddLog("Skiping filename [" + fileEl.Name + "] because of filename [" + FileNameExcludeSt + "]...", LogLevel.Activity, Highlight.Error);
                            skipFile = true;
                        }
                    }
                }


                //3.2. Skip file?
                if (skipFile)
                {
                    //3.2. Add record for skipped file 
                    //3.2.1 Is the file new to us?
                    if (!FileListProcessed.ContainsKey(filename))
                    {
                        //3.2.2. Add to filelist with time
                        FileListProcessed.Add(filename, fileEl.LastWriteTime);
                    }
                }
                else
                {
                //3.3. PROCESSING
                    //3.3. Is the file new to us?
                    if (!FileListProcessed.ContainsKey(filename))
                    {
                        //3.4.1. Add to filelist with time
                        FileListProcessed.Add(filename, fileEl.LastWriteTime);

                        //3.4.2. ADD TO PROCESSING QUEQUE
                        ParentMF.ProcessingObj.QuequeAdd(filename);

                        Logging.AddLog("New file [" + filename + "] was detected and added to queque...", LogLevel.Activity, Highlight.Emphasize);
                    }
                }
            }

            //4. If set option to scan subdirs, run recursion
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
            FileListProcessed.Clear();
            DirListToMonitor.Clear();
        }

        /// <summary>
        /// Clear IMS Data
        /// </summary>
        public void ClearDirIMSData()
        {
            //1. Reset DirListToMonitor
            List<string> keys = new List<string>(DirListToMonitor.Keys); //Copying keys first (changing dic will reset iterator)
            foreach (string curDir in keys)
            {
                DirListToMonitor[curDir] = VERY_OLD_TIME;
            }
        }


        /// <summary>
        /// Check if FileDate is newer then Directory IMS
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool CheckFileForIMS(string FileName)
        {
            //Current file DateTime
            DateTime FileDate = FileListProcessed[FileName];

            //Get Dir of current file
            string DirName = Path.GetDirectoryName(FileName);

            //Get IMS date for current file
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
            DateTime FileDate = FileListProcessed[FileName];

            string DirName = Path.GetDirectoryName(FileName);
            DateTime DirIMSDate = DirListToMonitor[DirName];

            if (DirIMSDate < FileDate) DirListToMonitor[DirName] = FileDate;
        }

    }
}
