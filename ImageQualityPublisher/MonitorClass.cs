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
        //path to monitor files
        public string FileMonitorPath="";

        public bool settingsPublishToGroup = true;

        //file list where to keep already parsed file
        private Dictionary<string, bool> FileList = new Dictionary<string, bool>();

        //link to mainform
        private MainForm ParentMF;

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
                        RunQualityEstimation(filename, settingsPublishToGroup);
                    });
                    childThread.Start();
                }
            }
        }


        public FileParseResult RunQualityEstimation(string FileName, bool PublishToWeb = true)
        {
            string FullFileName = Path.Combine(FileMonitorPath, FileName); //in case filename contains full path - it will be used. If no - monitor path would be added

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
