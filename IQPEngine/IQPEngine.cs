using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IQPEngineLib
{
    public class IQPEngine
    {
        public FileMonitoring MonitorObj;
        public FileProcessing ProcessingObj;

        public WebPublish WebPublishObj;    //for public
        public WebPublish WebPublishObj2;   //for private

        public delegate void CallBackFunction(FileParseResult FileResObj); //declare delegate type

        public CallBackFunction CallBackFunction_Outputreslut; //store delegate

        public IQPEngine(CallBackFunction RunAtEnd)
        {
            ProcessingObj = new FileProcessing(this);
            MonitorObj = new FileMonitoring(this);
            WebPublishObj = new WebPublish();
            WebPublishObj2 = new WebPublish();

            CallBackFunction_Outputreslut = RunAtEnd; //save call back function
        }

    }
}
