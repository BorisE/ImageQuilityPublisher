using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ImageQuilityPublisher
{
    class FITSData
    {
        Int32 StarsNumber = 0;
        Double FWHM = 0.0;
        Double AspecRatio = 0.0;
        Double SkyBackground = 0.0;
    }

    class FITSHeaderParser
    {

        public string FileName = "";
        public string FilePath = "";

        public string ObservatoryName;

        public string TelescopeName;
        public string TelescopeFocusLen;
        public string TelescopeDiameter;

        public string CameraName;
        public string CameraPixelSize;

        public string ImageBinning;
        public string ImageFilter;
        public string ImageExposureLength;

        public string ObjName;
        public string ObjRA;
        public string ObjDec;
        public string ObjAlt;
        public string ObjAz;


        internal UInt16 InitialHeaderLen = 4500;

        void ReadFITSHeader()
        {
            string FullFileName = FilePath + FileName;

            //1. Прочитаем заголов FITS
            try
            {
                //Прочитаем содержимое файла 
                using (StreamReader sr = new StreamReader(FullFileName))
                { 
                    Char[] readbuffer = new Char[InitialHeaderLen];
                    int readchars = sr.Read(readbuffer, 0, InitialHeaderLen);
                }
            }
            catch (Exception ex)
            {
                Logging.AddLog("Cant read logfile contents [" + FullFileName + "]", LogLevel.Important, Highlight.Error);
                Logging.AddLog(MethodBase.GetCurrentMethod().Name + "error! [" + ex.ToString() + "]", LogLevel.Debug, Highlight.Error);
            }

  
        }

        void GetFITSData()
        {

        }

    }
}
