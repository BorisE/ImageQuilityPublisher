using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using LoggingLib;

namespace IQPEngineLib
{
    /// <summary>
    /// Class to be included in FileParseResult (since version 1.3.9)
    /// </summary>
    public class WebExtensionsClass
    {
        public string ServerKey = "";
    }

    public class WebPublish
    {
        public string PublishURL = "http://localhost/astropublisher/fitspublish.php";
        public string ServerKey ="";

        public WebPublish(string URLPath)
        {
            PublishURL = URLPath;
        }

        public WebPublish():this("http://localhost/astropublisher/fitspublish.php")
        { }


        /// <summary>
        /// Set URL to upload
        /// </summary>
        /// <param name="URLPath"></param>
        public void SetURL(string URLPath)
        {
            PublishURL = URLPath;
        }

        /// <summary>
        /// Publish data
        /// </summary>
        /// <param name="DataToPublish"></param>
        public void PublishData(FileParseResult DataToPublish)
        {
            // Extend DataToPublish data
            DataToPublish.WebExtensions = new WebExtensionsClass();
            // Add special web data to class, which would be sent to server 
            DataToPublish.WebExtensions.ServerKey = ServerKey;


            Logging.AddLog("Publishing data on ["+ DataToPublish.FITSFileName + "] to "+ PublishURL, LogLevel.Debug);
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(PublishURL);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                // POST parameters
                // Data would be sent on GetRequestStream() method
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(DataToPublish);
                    //var final = JsonConvert.SerializeObject(DataToPublish); Newtonsoft.JSON converter
                    streamWriter.Write(json);
                }

                // Send the 'WebRequest' and wait for response.
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Logging.AddLog("Data on file [" + DataToPublish.FITSFileName + "] was published to [" + PublishURL + "]", LogLevel.Activity);
                    Logging.AddLog("Published result:" + result, LogLevel.Debug);
                }
            }
            catch (Exception ex)
            {
                Logging.AddLog("Data wasn't published [" + DataToPublish.FITSFileName + "] to [" + PublishURL + "]", LogLevel.Important, Highlight.Error);
                Logging.AddLog(MethodBase.GetCurrentMethod().Name + "error! [" + ex.ToString() + "]", LogLevel.Debug, Highlight.Error);
            }
        }
    }
}
