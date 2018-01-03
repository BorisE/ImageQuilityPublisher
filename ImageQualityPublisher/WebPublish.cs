using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;

namespace ImageQualityPublisher
{
    public class WebPublish
    {
        public string PublishURL = "http://localhost/astropublisher/fitspublish.php";

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


        public void PublishData(FileParseResult DataToPublish)
        {
            Logging.AddLog("Publishing data on ["+ DataToPublish.FITSFileName + "] to "+ PublishURL, LogLevel.Activity);
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(PublishURL);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(DataToPublish);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Logging.AddLog("Data on file [" + DataToPublish.FITSFileName + "] was published:  " + result, LogLevel.Activity);
                }
            }
            catch (Exception ex)
            {
                Logging.AddLog("Data wasn't published [" + DataToPublish.FITSFileName + "]", LogLevel.Important, Highlight.Error);
                Logging.AddLog(MethodBase.GetCurrentMethod().Name + "error! [" + ex.ToString() + "]", LogLevel.Debug, Highlight.Error);
            }
        }
    }
}
