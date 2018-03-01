using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LoggingLib;


namespace IQPEngineLib
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
        public bool settingsDSSInfoFileAutoDelete = false;    //delete .info files after reading

        //settings for filter
        public bool settingsFilterHistoryTag_UseFlag = false;    //use HISTORY tag filter
        public UInt16 settingsFilterHistoryTag_MaxCount = 1;     //max count for HISTORY tag
        public bool settingsFilterObserverTag_UseFlag = false;   //use OBSERVER tag filter
        public string settingsFilterObserverTag_Contains = "";  //string OBSERVER tag filter max contains
        public bool settingsFilterTelescopTag_UseFlag = false;   //use TELESCOP tag filter
        public string settingsFilterTelescopTag_Contains = "";  //string TELESCOP tag filter max contains
        public bool settingsFilterInstrumeTag_UseFlag = false;   //use INSTRUME tag filter
        public string settingsFilterInstrumeTag_Contains = "";  //string INSTRUME tag filter max contains
        public bool settingsFilterStarsNum_UseFlag = false;     //Quality Filter: stars count
        public UInt16 settingsFilterStarsNum_MinCount = 0;      //Quality Filter: stars count min count
        public bool settingsFilterFWHM_UseFlag = false;         //Quality Filter: FWHM
        public double settingsFilterFWHM_MaxVal = 10.0;         //Quality Filter: max FWHM
        public bool settingsFilterMinAltitude_UseFlag = false;  //Quality Filter: Minimum altitude
        public double settingsFilterMinAltitude_MinVal = 19.0;  //Quality Filter: Minimum altitude value
        public bool settingsFilterBackground_UseFlag = false;   //Quality Filter: Max Background level
        public double settingsFilterBackground_MaxVal = 0.30;   //Quality Filter: Max Background level value


        internal uint curActiveThreads = 0;              //currently active threads

        //link to mainform for callback functions
        private IQPEngine ParentEngine;

        public FileProcessing(IQPEngine extIQP)
        {
            ParentEngine = extIQP;
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
                DSSObj.EvaluateFile(FullFileName, false);
                Logging.AddLog("Quality evaluation procedure for file [" + FullFileName + "] finished", LogLevel.Activity);

                //3. Parse evaluation results
                DSSObj.GetEvaluationResults(settingsDSSInfoFileAutoDelete);
                Logging.AddLog("Quality results for file [" + FullFileName + "] were read", LogLevel.Activity);

                //4. Get FITS Header fields
                FITSobj.ReadFITSHeader(FullFileName);

                //5. Make Res obj
                FileResObj.FITSFileName = FullFileName;
                FileResObj.QualityData = DSSObj.QualityEstimate;
                FileResObj.HeaderData = FITSobj.FITSData;

                //6. Filter file if needed
                bool skipPublishFlag = false;
                //6.1. HISTORY tag
                if (settingsFilterHistoryTag_UseFlag)
                {
                    if (FileResObj.HeaderData.HistoryCount > settingsFilterHistoryTag_MaxCount)
                    {
                        skipPublishFlag = true; //don't publish data
                        Logging.AddLog("Skipping publishing frame [" + FullFileName + "]. HISTORY count = [" + FileResObj.HeaderData.HistoryCount + "]", LogLevel.Activity, Highlight.Error);
                    }
                }
                //6.2. OBSERVER tag
                if (settingsFilterObserverTag_UseFlag)
                {
                    if (!FileResObj.HeaderData.Observer.Contains(settingsFilterObserverTag_Contains))
                    {
                        skipPublishFlag = true; //don't publish data
                        Logging.AddLog("Skipping publishing frame [" + FullFileName + "]. OBSERVER = [" + FileResObj.HeaderData.Observer + "]", LogLevel.Activity, Highlight.Error);
                    }
                }
                //6.3. TELECOP tag
                if (settingsFilterTelescopTag_UseFlag)
                {
                    if (!FileResObj.HeaderData.TelescopeName.Contains(settingsFilterTelescopTag_Contains))
                    { 
                        skipPublishFlag = true; //don't publish data
                        Logging.AddLog("Skipping publishing frame [" + FullFileName + "]. TELECOP = [" + FileResObj.HeaderData.TelescopeName + "]", LogLevel.Activity, Highlight.Error);
                    }
                }
                //6.4. INSTRUME tag
                if (settingsFilterInstrumeTag_UseFlag)
                {
                    if (!FileResObj.HeaderData.CameraName.Contains(settingsFilterInstrumeTag_Contains))
                    {
                        skipPublishFlag = true; //don't publish data
                        Logging.AddLog("Skipping publishing frame [" + FullFileName + "]. INSTRUME = [" + FileResObj.HeaderData.CameraName + "]", LogLevel.Activity, Highlight.Error);
                    }
                }
                //6.5. Quality Filter: stars num
                if (settingsFilterStarsNum_UseFlag)
                {
                    if (FileResObj.QualityData.StarsNumber <= settingsFilterStarsNum_MinCount)
                    {
                        skipPublishFlag = true; //don't publish data
                        Logging.AddLog("Skipping publishing frame [" + FullFileName + "]. StarsNum = [" + FileResObj.QualityData.StarsNumber + "]", LogLevel.Activity, Highlight.Error);
                    }
                }
                //6.6. Quality Filter: FWHM
                if (settingsFilterFWHM_UseFlag)
                {
                    if (FileResObj.FWHM > settingsFilterFWHM_MaxVal)
                    {
                        skipPublishFlag = true; //don't publish data
                        Logging.AddLog("Skipping publishing frame [" + FullFileName + "]. FWHM = [" + FileResObj.FWHM + "]", LogLevel.Activity, Highlight.Error);
                    }
                }
                //6.7. Quality Filter: Min Altitude
                if (settingsFilterMinAltitude_UseFlag)
                {
                    if (FileResObj.HeaderData.ObjAlt <= settingsFilterMinAltitude_MinVal)
                    {
                        skipPublishFlag = true; //don't publish data
                        Logging.AddLog("Skipping publishing frame [" + FullFileName + "]. Altitude = [" + FileResObj.HeaderData.ObjAlt + "]", LogLevel.Activity, Highlight.Error);
                    }
                }
                //6.8. Quality Filter: Max Background
                if (settingsFilterBackground_UseFlag)
                {
                    if (FileResObj.QualityData.SkyBackground >= settingsFilterBackground_MaxVal)
                    {
                        skipPublishFlag = true; //don't publish data
                        Logging.AddLog("Skipping publishing frame [" + FullFileName + "]. BgLevel = [" + FileResObj.QualityData.SkyBackground + "]", LogLevel.Activity, Highlight.Error);
                    }
                }




                //7.1. Check - if this light frame or not
                if (settingsPublishLightFramesOnly)
                {
                    if ( !(FileResObj.HeaderData.ImageType == "Light Frame" || FileResObj.HeaderData.ImageType == ""))
                    {
                        skipPublishFlag = true;
                        Logging.AddLog("Skipping publishing frame [" + FullFileName + "]. ImageType = [" + FileResObj.HeaderData.ImageType + "]", LogLevel.Activity, Highlight.Error);
                    }
                }

                //8. Check - file should be published?
                if (!skipPublishFlag)
                {
                    //8.1. Pulbish to form
                    //ParentEngine.Invoke(new Action(() => ParentEngine.PublishFITSData(FileResObj)));
                    ParentEngine.CallBackFunction_Outputreslut(FileResObj);

                    //8.2. Publsh to web (GROUP)
                    if (PublishToWeb)
                    {
                        if (!settingsSkipIMSfiles || (settingsSkipIMSfiles && ParentEngine.MonitorObj.CheckFileForIMS(FullFileName)))
                        {
                            ParentEngine.WebPublishObj.PublishData(FileResObj);
                        }
                    }

                    //8. Publsh to web (PRIVATE)
                    if (PublishToWeb2)
                        ParentEngine.WebPublishObj2.PublishData(FileResObj);
                }

                //9. Update IMS Directory date
                ParentEngine.MonitorObj.UpdateDirIMS(FullFileName);
            }
            catch (Exception ex)
            {
                Logging.AddLog("RunFileFullProcessing error: " + ex.Message, LogLevel.Important, Highlight.Error);
                Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Error);
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
