using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageQualityPublisher
{
    public class IQPEngine
    {
        public FileMonitoring MonitorObj;
        public FileProcessing ProcessingObj;

        public WebPublish WebPublishObj;    //for public
        public WebPublish WebPublishObj2;   //for private

        public IQPEngine()
        {
            ProcessingObj = new FileProcessing(this);
            MonitorObj = new FileMonitoring(this);
            WebPublishObj = new WebPublish();
            WebPublishObj2 = new WebPublish();
        }

    }
}
