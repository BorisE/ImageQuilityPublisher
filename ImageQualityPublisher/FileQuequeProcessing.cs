using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ImageQualityPublisher
{
    /// <summary>
    /// Class FileParseResult
    /// Contains all results to use
    /// </summary>
    public class FileParseResult
    {
        public string FITSFileName = "";
        public DSSQualityData QualityData;
        public FITSHeaderData HeaderData;
        public double PixelResolution
        {
            get
            {
                return HeaderData.CameraPixelSizeX / HeaderData.TelescopeFocusLen * 206.265;    //  Formula:   (   Pixel Size   /   Telescope Focal Length   )   X 206.265
            }
        }
        public double FWHM
        {
            get
            {
                return QualityData.MeanRadius * PixelResolution;
            }
        }

        public WebExtensionsClass WebExtensions;
    }


    /// <summary>
    /// Process FileQueque
    /// </summary>
    public class FileProcessing
    {
        //file list where to keep already parsed file
        private Queue<string> FileQuequeList = new Queue<string>();

        //Last process time (for IMS checking)
        public DateTime LastProcessedTime = new DateTime();

        //Settings for file processing
        public string settingsDSSCLPath = @"c:\Program Files (x86)\DeepSkyStacker\DeepSkyStackerCL.exe";
        public bool settingsPublishToGroup = true;      //publish to web - group resource
        public bool settingsPublishToPrivate = false;   //publish to web - private resource
        public uint settingsMaxThreads = 1;             //how many threads run simultaneously
        public bool settingsSkipIMSfiles = true;        //use IMS setting (check last modified file in directory)
        public bool settingsDSSForceRecheck = false;    //rebuild .info files always
        public bool settingsPublishLightFramesOnly = true;    //publish only lightframes

        internal uint curActiveThreads = 0;              //currently active threads

        //link to mainform for callback functions
        private MainForm ParentMF;

        public FileProcessing(MainForm extMF)
        {
            ParentMF = extMF;
        }

        /// <summary>
        /// Add file to queque
        /// </summary>
        /// <param name="filename"></param>
        public void QuequeAdd(string filename)
        {
            FileQuequeList.Enqueue(filename);
            LastProcessedTime = DateTime.Now;
        }

        /// <summary>
        /// Process All Queque
        /// </summary>
        public void ProcessAll()
        {
            while (FileQuequeList.Count > 0 && curActiveThreads < settingsMaxThreads)
            {
                ProcessOne();
            }
        }

        /// <summary>
        /// Process first file in queque
        /// </summary>
        public void ProcessOne()
        {
            //if there is free threads
            if (curActiveThreads < settingsMaxThreads)
            {
                //if there is non empty queque
                if (FileQuequeList.Count > 0)
                {
                    //1. Get the first file
                    string filename = FileQuequeList.Dequeue();

                    //2. run file processing async
                    Thread childThread = new Thread(delegate ()
                    {
                        RunFileFullProcessing(filename, settingsPublishToGroup, settingsPublishToPrivate);
                        curActiveThreads--;
                    });
                    childThread.Start();
                    curActiveThreads++;
                }
            }
            else
            {
                //??
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
            FileParseResult FileResObj = new FileParseResult();
            try
            {
                //1. Init vars and objects
                //string FullFileName = Path.Combine(sFileMonitorPath, FileName); //in case filename contains full path - it will be used. If no - monitor path would be added
                string FullFileName = FileName; //there is no default path now :(

                DSSQualityReader DSSObj = new DSSQualityReader(settingsDSSCLPath);
                DSSObj.settingsDSSForceRecheck = settingsDSSForceRecheck; //copy setting
                FITSHeaderReader FITSobj = new FITSHeaderReader();

                //2. Run evaluation in sync mode
                DSSObj.EvaluateFile(FullFileName,false);
                Logging.AddLog("Quality evaluation procedure for file [" + FullFileName + "] finished", LogLevel.Activity);

                //3. Parse evaluation results
                DSSObj.GetEvaluationResults();
                Logging.AddLog("Quality results for file [" + FullFileName + "] were read", LogLevel.Activity);

                //4. Get FITS Header fields
                FITSobj.ReadFITSHeader(FullFileName);

                //5. Make Res obj
                FileResObj.FITSFileName = FullFileName;
                FileResObj.QualityData = DSSObj.QualityEstimate;
                FileResObj.HeaderData = FITSobj.FITSData;

                //6.1. Check - if this light frame or not
                bool skipPublishFlag = false;
                if (settingsPublishLightFramesOnly)
                {
                    skipPublishFlag = true;
                    if (FileResObj.HeaderData.ImageType == "Light Frame" || FileResObj.HeaderData.ImageType == "")
                    {
                        skipPublishFlag = false;
                    }
                }
                if (!skipPublishFlag)
                {
                    //6. Pulbish to form
                    ParentMF.Invoke(new Action(() => ParentMF.PublishFITSData(FileResObj)));

                    //7. Publsh to web (GROUP)
                    if (PublishToWeb)
                    {
                        if (!settingsSkipIMSfiles || (settingsSkipIMSfiles && ParentMF.MonitorObj.CheckFileForIMS(FullFileName)))
                        {
                            ParentMF.WebPublishObj.PublishData(FileResObj);
                        }
                    }

                    //8. Publsh to web (PRIVATE)
                    if (PublishToWeb2)
                        ParentMF.WebPublishObj2.PublishData(FileResObj);
                }
                else
                {
                    Logging.AddLog("Skipping publishing frame ["+ FullFileName + "]. ImageType = [" + FileResObj.HeaderData.ImageType + "]" , LogLevel.Activity, Highlight.Error);
                }

                //9. Update IMS Directory date
                ParentMF.MonitorObj.UpdateDirIMS(FullFileName);
            }
            catch (Exception ex)
            {
                Logging.AddLog("RunFileFullProcessing error: " + ex.Message, LogLevel.Important, Highlight.Error);
                Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
            }
            return FileResObj;
        }

        /// <summary>
        /// Clear QueQue
        /// </summary>
        public void Clear()
        {
            FileQuequeList.Clear();
            LastProcessedTime = new DateTime(2015, 01, 01);
        }

        /// <summary>
        /// Get QueQue len
        /// </summary>
        /// <returns></returns>
        public uint QuequeLen()
        {
            return (uint)FileQuequeList.Count();
        }
    }
}
