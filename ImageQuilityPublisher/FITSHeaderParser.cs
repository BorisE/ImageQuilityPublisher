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

    public class FITSHeaderParser
    {
        //current File
        public string FITSFileName = @"NGC247_20171212_L_600s_1x1_-30degC_0.0degN_000005308.FIT";
        public string FITSFilePath = @"d:\2\"; //without slash - except root dir ;)

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


        internal UInt16 InitialHeaderLen = 2880;


        //Each header or data unit is a multiple of 2880 bytes long. If necessary, the header or data unit is padded out to the required length with ASCII blanks or NULLs depending on the type of unit.
        //Each header unit contains a sequence of fixed-length 80 - character keyword records which have the general form:
        //KEYNAME = value / comment string
        //The keyword names may be up to 8 characters long and can only contain uppercase letters A to Z, the digits 0 to 9, the hyphen, and the underscore character.
        //The keyword name is (usually) followed by an equals sign and a space character in columns 9 and 10 of the record, followed by the value of the keyword which may be either an integer, a floating point number, a complex value(i.e., a pair of numbers), a character string(enclosed in single quotes), or a Boolean value(the letter T or F).
        //Some keywords, (e.g., COMMENT and HISTORY) are not followed by an equals sign and in that case columns 9 - 80 of the record may contain any string of ASCII text.

        public void ReadFITSHeader(string FullFITSFileNameExt = "", bool asyncrun = false)
        {
            //0. Compose image FileName
            if (FullFITSFileNameExt != "")
            {
                FITSFileName = Path.GetFileName(FullFITSFileNameExt);
                FITSFilePath = Path.GetDirectoryName(FullFITSFileNameExt);
            }
            string FullFITSFileName = Path.Combine(FITSFilePath, FITSFileName);

            //1. Прочитаем заголовок FITS
            try
            {
                //Прочитаем содержимое файла 
                using (StreamReader sr = new StreamReader(FullFITSFileName))
                { 
                    Char[] readbuffer = new Char[InitialHeaderLen];
                    int readchars = sr.Read(readbuffer, 0, InitialHeaderLen);
                }
            }
            catch (Exception ex)
            {
                Logging.AddLog("Cant read logfile contents [" + FullFITSFileName + "]", LogLevel.Important, Highlight.Error);
                Logging.AddLog(MethodBase.GetCurrentMethod().Name + "error! [" + ex.ToString() + "]", LogLevel.Debug, Highlight.Error);
            }

  
        }

        void GetFITSData()
        {

        }

    }
}
