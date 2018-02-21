using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ImageQualityPublisher
{
    public class FITSHeaderData
    {
        public DateTime DateObsUTC; //DATE-OBS

        public double ImageExposure; //EXPOSURE
        public string ImageFilter; //FILTER
        public string ImageType; //IMAGETYP

        public double ImageBinningX; //XBINNING
        public double ImageBinningY; //YBINNING

        public double ImageSetTemp; //SET-TEMP
        public double ImageTemp; //CCD-TEMP

        public double CameraPixelSizeX; //XPIXSZ
        public double CameraPixelSizeY; //YPIXSZ

        public string ObjName;  //OBJECT
        public string ObjRA;    //OBJCTRA
        public string ObjDec;   //OBJCTDEC
        public double ObjAlt;   //OBJCTALT
        public double ObjAz;    //OBJCTAZ

        public string CameraName; //INSTRUME    
        public string Observer;  //OBSERVER
        public string TelescopeName;    //TELESCOP
        public double TelescopeFocusLen;    //FOCALLEN
        public double TelescopeDiameter;    //APTDIA

        public UInt16 HistoryCount = 0; //HISTORY tag count
    }


    /************************************************************************************************************************************************/
    /// <summary>
    /// Class for getting FITS file HEADER 
    /// 1. Run - ReadFITSHeader
    /// 2. Get result - in FITSData field 
    /// </summary>
    public class FITSHeaderReader
    {
        //current File
        public string FITSFileName = @"NGC247_20171212_L_600s_1x1_-30degC_0.0degN_000005308.FIT";
        public string FITSFilePath = @"d:\2\"; //without slash - except root dir ;)
        public string FITSFullFileName;

        public FITSHeaderData FITSData = new FITSHeaderData();

        internal UInt16 BlockLen = 2880;
        internal UInt16 MAX_FITS_DATA_BLOCKS = 2; //max header units to read (in case of bad fits file)


        //Each header or data unit is a multiple of 2880 bytes long. If necessary, the header or data unit is padded out to the required length with ASCII blanks or NULLs depending on the type of unit.
        //Each header unit contains a sequence of fixed-length 80 - character keyword records which have the general form:
        //KEYNAME = value / comment string
        //The keyword names may be up to 8 characters long and can only contain uppercase letters A to Z, the digits 0 to 9, the hyphen, and the underscore character.
        //The keyword name is (usually) followed by an equals sign and a space character in columns 9 and 10 of the record, followed by the value of the keyword which may be either an integer, a floating point number, a complex value(i.e., a pair of numbers), a character string(enclosed in single quotes), or a Boolean value(the letter T or F).
        //Some keywords, (e.g., COMMENT and HISTORY) are not followed by an equals sign and in that case columns 9 - 80 of the record may contain any string of ASCII text.

        FileStream FS;


        /// <summary>
        /// Entry point for parsing FITSFile
        /// </summary>
        /// <param name="FullFITSFileNameExt"></param>
        /// <param name="asyncrun"></param>
        public void ReadFITSHeader(string FullFITSFileNameExt = "")
        {
            //0. Compose image FileName
            if (FullFITSFileNameExt != "")
            {
                FITSFileName = Path.GetFileName(FullFITSFileNameExt);
                FITSFilePath = Path.GetDirectoryName(FullFITSFileNameExt);
            }
            string FullFITSFileName = Path.Combine(FITSFilePath, FITSFileName);

            try
            {
                string stBlock = "";

                //1. Прочитаем заголовок FITS
                
                //1.1. Откроем поток
                using (FS = new FileStream(FullFITSFileName, FileMode.Open))
                {
                    //1.2. Прочитаем нужное количество блоков, относящихся к заголовку
                    bool bHeaderRead = false;
                    int i = 0;
                    do
                    {
                        stBlock += ReadFITSBlock(i);

                        if (stBlock.Contains(" END ") || i > MAX_FITS_DATA_BLOCKS)
                        {
                            bHeaderRead = true;
                        }
                        else
                        {
                            i++;
                        }
                        
                    }
                    while (stBlock != "" && !bHeaderRead);
                }

                //2. Обработаем заголовок
                ParseFITSHeaderData(stBlock);

                //3. Thats all! Result is in FITSData

            }
            catch (Exception ex)
            {
                Logging.AddLog("Cant read fits header for file [" + FullFITSFileName + "]", LogLevel.Important, Highlight.Error);
                Logging.AddLog(MethodBase.GetCurrentMethod().Name + "error! [" + ex.ToString() + "]", LogLevel.Debug, Highlight.Error);
            }
        }




        /// <summary>
        /// Read FITS HEADER block
        /// </summary>
        /// <param name="BlockNum">Block num, from 0</param>
        /// <returns>Block contents</returns>
        private string ReadFITSBlock(int BlockNum=0)
        {
            string stReadBlock = "";

            try
            {
                byte[] readbuffer = new byte[BlockLen];

                //Перейдем на начала нужного блока
                FS.Seek(BlockNum * BlockLen, SeekOrigin.Begin);

                //Прочитаем
                int readchars = FS.Read(readbuffer, 0, BlockLen);

                //сконвертируем в строку
                stReadBlock = Encoding.ASCII.GetString(readbuffer);
            }
            catch (Exception ex)
            {
                Logging.AddLog("Cant read fits block [BlockNum] from [" + FITSFullFileName + "]", LogLevel.Important, Highlight.Error);
                Logging.AddLog(MethodBase.GetCurrentMethod().Name + "error! [" + ex.ToString() + "]", LogLevel.Debug, Highlight.Error);
            }

            return stReadBlock;
        }

        /// <summary>
        /// Parse header into keywords and values
        /// </summary>
        /// <param name="stHeader"></param>
        private void ParseFITSHeaderData(string stHeader)
        {
            int nStartPos = 0;
            while (nStartPos < stHeader.Length)
            {
                string stLine = stHeader.Substring(nStartPos, 80);
                nStartPos = nStartPos + 80;

                string KEYWORD = "";
                string VAL = "";
                string COMMENT = "";

                //get keyword
                KEYWORD = stLine.Substring(0, 8).Trim();

                if (KEYWORD !="" )
                // this is not extended line
                { 
                    string REST = stLine.Substring(8);

                    //get value
                    if (REST.Substring(0,2) == "= ")
                    //this normal keyword
                    {
                        string VAL_COMMENT = REST.Substring(2).Trim();

                        int nComStart = VAL_COMMENT.IndexOf("/");
                        if (nComStart >= 0)
                        // there is '/' sign, so we should cut values/comment on it + trim
                        {
                            VAL = VAL_COMMENT.Substring(0,nComStart).Trim();
                            COMMENT = VAL_COMMENT.Substring(nComStart + 1).Trim();
                        }
                        else
                        // there is no '/' sign, no comments
                        {
                            VAL = VAL_COMMENT.Trim();
                        }
                    }
                    else
                    //this is not normal keyword, no '=' sign (such as HISTORY etc)
                    {
                        VAL = REST.Trim();
                    }

                    //strip quotes (for string type)
                    VAL = VAL.Trim('\'');

                    //PARSE PAIR KEYWORD / VAL
                    ParseKeywordValPair(KEYWORD, VAL, COMMENT);


                } //ignore keyless line
            } //end of while
        }


        /// <summary>
        /// Parse pair Keyword / Val into FITSData
        /// </summary>
        /// <param name="FITSKeyword"></param>
        /// <param name="FITSVal"></param>
        /// <param name="FITSComment"></param>
        private void ParseKeywordValPair(string FITSKeyword, string FITSVal, string FITSComment)
        {

            //public DateTime DateObsUTC; //DATE-OBS
            //DATE - OBS = '2017-12-12T15:51:25' / YYYY-MM-DDThh:mm:ss observation start, UT
            if (FITSKeyword== "DATE-OBS")
            {
                FITSData.DateObsUTC = DateTime.ParseExact(FITSVal, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            }
            //public double ImageExposure; //EXPOSURE
            //EXPOSURE=   600.00000000000000 /Exposure time in seconds                        
            else if(FITSKeyword == "EXPOSURE")
            {
                FITSData.ImageExposure = Utils.ConvertToDouble(FITSVal);
            }
            //public string ImageFilter; //FILTER
            //FILTER = 'L       ' / Filter used when taking image
            else if (FITSKeyword == "FILTER")
            {
                FITSData.ImageFilter = FITSVal.Trim();
            }
            //public string ImageType; //IMAGETYP
            //IMAGETYP = 'Light Frame' / Type of image                                   
            else if (FITSKeyword == "IMAGETYP")
            {
                FITSData.ImageType = FITSVal.Trim();
            }
            //public double ImageBinningX; //XBINNING
            else if (FITSKeyword == "XBINNING")
            {
                FITSData.ImageBinningX = Utils.ConvertToDouble(FITSVal);
            }
            //public double ImageBinningY; //YBINNING
            else if (FITSKeyword == "YBINNING")
            {
                FITSData.ImageBinningY = Utils.ConvertToDouble(FITSVal);
            }
            //public double ImageSetTemp; //SET-TEMP
            else if (FITSKeyword == "SET-TEMP")
            {
                FITSData.ImageSetTemp = Utils.ConvertToDouble(FITSVal);
            }
            //public double ImageTemp; //CCD-TEMP
            else if (FITSKeyword == "CCD-TEMP")
            {
                FITSData.ImageTemp = Utils.ConvertToDouble(FITSVal);
            }
            //public double CameraPixelSizeX; //XPIXSZ
            else if (FITSKeyword == "XPIXSZ")
            {
                FITSData.CameraPixelSizeX = Utils.ConvertToDouble(FITSVal);
            }
            //public double CameraPixelSizeY; //YPIXSZ
            else if (FITSKeyword == "YPIXSZ")
            {
                FITSData.CameraPixelSizeY = Utils.ConvertToDouble(FITSVal);
            }
            //public string ObjName;  //OBJECT
            //OBJECT = 'NGC247  '
            else if (FITSKeyword == "OBJECT")
            {
                FITSData.ObjName = FITSVal.Trim();
            }
            //public string ObjRA;    //OBJCTRA
            //OBJCTRA = '00 47 17.0'
            else if (FITSKeyword == "OBJCTRA")
            {
                FITSData.ObjRA = FITSVal.Trim();
            }
            //public string ObjDec;   //OBJCTDEC
            //OBJCTDEC = '-20 41 58.0'
            else if (FITSKeyword == "OBJCTDEC")
            {
                FITSData.ObjDec = FITSVal.Trim();
            }
            //public double ObjAlt;   //OBJCTALT
            //OBJCTALT = ' 23.7854' / Nominal altitude of center of image
            else if (FITSKeyword == "OBJCTALT")
            {
                FITSData.ObjAlt = Utils.ConvertToDouble(FITSVal);
            }
            //public double ObjAz;    //OBJCTAZ
            //OBJCTAZ = '168.2074' / Nominal azimuth of center of image
            else if (FITSKeyword == "OBJCTAZ")
            {
                FITSData.ObjAz = Utils.ConvertToDouble(FITSVal);
            }

            //public string CameraName; //INSTRUME   
            else if (FITSKeyword == "INSTRUME")
            {
                FITSData.CameraName = FITSVal.Trim();
            }
            //public string Observer;  //OBSERVER
            else if (FITSKeyword == "OBSERVER")
            {
                FITSData.Observer = FITSVal.Trim();
            }
            //public string TelescopeName;    //TELESCOP
            else if (FITSKeyword == "TELESCOP")
            {
                FITSData.TelescopeName = FITSVal.Trim();
            }
            //public double TelescopeFocusLen;    //FOCALLEN
            else if (FITSKeyword == "FOCALLEN")
            {
                FITSData.TelescopeFocusLen = Utils.ConvertToDouble(FITSVal);
            }
            //public double TelescopeDiameter;    //APTDIA
            else if (FITSKeyword == "APTDIA")
            {
                FITSData.TelescopeDiameter = Utils.ConvertToDouble(FITSVal);
            }
            //public UInt16 HistoryCount = 0; //HISTORY tag count
            else if (FITSKeyword == "HISTORY")
            {
                FITSData.HistoryCount++;
            }
        }

    }
}
