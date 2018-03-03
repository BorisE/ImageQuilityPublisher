using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IQPEngineLib
{
    public class IQPEngine
    {

        /// <summary>
        /// Monitoring Class
        /// ----------------
        /// Class to monitor folders.
        /// 1. Should be run CheckForNewFiles (or CheckForNewFiles_async for async running) periodicaly
        /// 2. For every valid file it will add it to PROCESSING QUEQUE
        /// </summary>
        public FileMonitoring MonitorObj;

        /// <summary>
        /// File processing class
        /// ---------------------
        /// Class to process file from PROCESSING QUEQUE
        /// 1. Run ProcessAll() or ProcessOne() to process all queque or just 1 element periodicaly
        /// 2. For each file in queque will be ran RunFileFullProcessing() in separate thread
        ///     - quality estimation through DSSQualityReader class
        ///     - fits header data reading through FITSHeaderReader class
        ///     - publish result with the help of FileParseResult class to form
        ///     - publish result with the help of FileParseResult class to web
        /// </summary>
        public FileQueQueProcessing ProcessingObj;


        /// <summary>
        /// Class for WebPublish quality FileParseResult data
        /// </summary>
        public WebPublish WebPublishObj;    //for public
        public WebPublish WebPublishObj2;   //for private

        /// <summary>
        /// Callback function at end of processing
        /// ---------------------------------------------------
        /// set CallBackFunction CallBackFunction_Outputreslut to be run at the end of processing of each file (to publish data in caller)
        /// </summary>
        /// <param name="FileResObj"></param>
        public CallBackFunction CallBackFunction_Outputreslut; //store delegate
        public delegate void CallBackFunction(FileParseResult FileResObj); //declare delegate type

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="RunAtEnd"></param>
        public IQPEngine(CallBackFunction RunAtEnd)
        {
            ProcessingObj = new FileQueQueProcessing(this);
            MonitorObj = new FileMonitoring(this);
            WebPublishObj = new WebPublish();
            WebPublishObj2 = new WebPublish();

            CallBackFunction_Outputreslut = RunAtEnd; //save call back function
        }

    }
}
