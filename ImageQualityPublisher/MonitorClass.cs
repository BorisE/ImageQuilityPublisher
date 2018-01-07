using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ImageQualityPublisher
{
    public class FileParseResult
    {
        public string FITSFileName="";
        public FITSQualityData QualityData;
        public FITSHeaderData HeaderData;
        public double PixelResolution
        {
            get
            {
                //  Formula:   (   Pixel Size   /   Telescope Focal Length   )   X 206.265
                return HeaderData.CameraPixelSizeX /  HeaderData.TelescopeFocusLen * 206.265;
            }
        }

        public double FWHM
        { 
            get
            {
                return QualityData.MeanRadius * PixelResolution;
            }
        }
    }

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
    public class MonitorClass
    {
        public List<string> FileMonitorPath = new List<string>();

        public bool settingsPublishToGroup = true;      //publish to web - group resource
        public bool settingsPublishToPrivate = false;   //publish to web - private resource
        public string settingsExtensionToSearch = "*.fit*"; //which extension to loop
        public uint settingsMaxThreads = 1;             //how many threads run simultaneously

        private uint curActiveThreads = 0;              //currently active threads

        //file list where to keep already parsed file
        private Dictionary<string, bool> FileList = new Dictionary<string, bool>();

        //link to mainform for callback functions
        private MainForm ParentMF;

        public MonitorClass(MainForm extMF)
        {
            ParentMF = extMF;
        }


        /// <summary>
        /// Check for new files in DIRECTORIES
        /// Overload where directories as LIST<string>
        /// </summary>
        /// <param name="FileMonitorPathList">List of directories to check</param>
        public void CheckForNewFiles(List<string> FileMonitorPathList)
        {
            //LOOP throug all directory path and run overload method for every dir
            foreach(string curDir in FileMonitorPathList)
            {
                CheckForNewFiles(curDir);
            }
        }

        /// <summary>
        /// Check for new files in one DIRECTORIE
        /// Overload where directory is only one<string>
        /// </summary>
        /// <param name="FileMonitorPathSt"></param>
        public void CheckForNewFiles(string FileMonitorPathSt)
        {
            //get all files
            string[] fileArray = Directory.GetFiles(FileMonitorPathSt, settingsExtensionToSearch);

            //check them all
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
                    if (curActiveThreads < settingsMaxThreads)
                    {
                        Logging.AddLog("New file [" + filename + "] was detected...", LogLevel.Activity, Highlight.Emphasize);

                        //add to filelist
                        FileList.Add(FileNameOnly, true);

                        //run async
                        Thread childThread = new Thread(delegate ()
                        {
                            RunFileFullProcessing(filename, settingsPublishToGroup, settingsPublishToPrivate);
                            curActiveThreads--;
                        });
                        childThread.Start();
                        curActiveThreads++;
                    }
                    else
                    {
                        Logging.AddLog("New file [" + filename + "] waiting in queque", LogLevel.Activity);
                    }
                }
            }
        }

        /// <summary>
        /// Quality estimator method 
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="PublishToWeb"></param>
        /// <param name="PublishToWeb2"></param>
        /// <returns></returns>
        public FileParseResult RunFileFullProcessing(string FileName, bool PublishToWeb = true, bool PublishToWeb2 = false)
        {
            //string FullFileName = Path.Combine(sFileMonitorPath, FileName); //in case filename contains full path - it will be used. If no - monitor path would be added
            string FullFileName = FileName; //there is no default path now :(

            DSSQualityReader DSSObj = new DSSQualityReader(ParentMF.settingsDSSCLPath);
            FITSHeaderReader FITSobj = new FITSHeaderReader();

            //Run evaluation in sync mode
            DSSObj.EvaluateFile(FullFileName);
            Logging.AddLog("Quality evaluatoion procedrure for file [" + FullFileName + "] finished", LogLevel.Activity);

            //Parse evaluation results
            DSSObj.GetEvaluationResults();
            Logging.AddLog("Quality results for file [" + FullFileName + "] were read", LogLevel.Activity);

            //Get FITS Header fields
            FITSobj.ReadFITSHeader(FullFileName);

            //Make Res obj
            FileParseResult FileResObj = new FileParseResult();
            FileResObj.FITSFileName = FullFileName;
            FileResObj.QualityData = DSSObj.QualityEstimate;
            FileResObj.HeaderData = FITSobj.FITSData;

            //Pulbish to form
            ParentMF.Invoke(new Action(() => ParentMF.PublishFITSData(FileResObj)));

            //Publsh to web (GROUP)
            if (PublishToWeb)
                ParentMF.WebPublishObj.PublishData(FileResObj);

            //Publsh to web (PRIVATE)
            if (PublishToWeb2)
                ParentMF.WebPublishObj2.PublishData(FileResObj);

            return FileResObj;
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
