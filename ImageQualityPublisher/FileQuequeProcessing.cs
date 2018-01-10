using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ImageQualityPublisher
{
    public class FileParseResult
    {
        public string FITSFileName = "";
        public FITSQualityData QualityData;
        public FITSHeaderData HeaderData;
        public double PixelResolution
        {
            get
            {
                //  Formula:   (   Pixel Size   /   Telescope Focal Length   )   X 206.265
                return HeaderData.CameraPixelSizeX / HeaderData.TelescopeFocusLen * 206.265;
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

        public uint curActiveThreads = 0;              //currently active threads

        //link to mainform for callback functions
        private MainForm ParentMF;

        public FileProcessing(MainForm extMF)
        {
            ParentMF = extMF;
        }

        public void QuequeAdd(string filename)
        {
            FileQuequeList.Enqueue(filename);
            LastProcessedTime = DateTime.Now;
        }

        public void ProcessAll()
        {
            while (FileQuequeList.Count > 0 && curActiveThreads < settingsMaxThreads)
            {
                ProcessOne();
            }
        }

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
                //string FullFileName = Path.Combine(sFileMonitorPath, FileName); //in case filename contains full path - it will be used. If no - monitor path would be added
                string FullFileName = FileName; //there is no default path now :(

                DSSQualityReader DSSObj = new DSSQualityReader(settingsDSSCLPath);
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
            }
            catch (Exception ex)
            {
                Logging.AddLog("RunFileFullProcessing error: " + ex.Message, LogLevel.Important, Highlight.Error);
                Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
            }
            return FileResObj;
        }


        public void Clear()
        {
            FileQuequeList.Clear();
            LastProcessedTime = new DateTime(2015, 01, 01);
        }

        public uint QuequeLen()
        {
            return (uint)FileQuequeList.Count();
        }
    }
}
