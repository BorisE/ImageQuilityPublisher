using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ImageQualityPublisher
{
    public class FITSData
    {
        public string DateObs; //DATE-OBS

        public string ImageExposure; //EXPOSURE
        public string ImageFilter; //FILTER
        public string ImageType; //IMAGETYP

        public string ImageBinningX; //XBINNING
        public string ImageBinningY; //YBINNING

        public string ImageSetTemp; //SET-TEMP
        public string ImageTemp; //CCD-TEMP

        public string CameraPixelSizeX; //XPIXSZ
        public string CameraPixelSizeY; //YPIXSZ

        public string ObjName;  //OBJECT
        public string ObjRA;    //OBJCTRA
        public string ObjDec;   //OBJCTDEC
        public string ObjAlt;   //OBJCTALT
        public string ObjAz;    //OBJCTAZ

        public string CameraName; //INSTRUME    
        public string Observer;  //OBSERVER
        public string TelescopeName;    //TELESCOP
        public string TelescopeFocusLen;    //FOCALLEN
        public string TelescopeDiameter;    //APTDIA

    }

    public class FITSHeaderParser
    {
        //current File
        public string FITSFileName = @"NGC247_20171212_L_600s_1x1_-30degC_0.0degN_000005308.FIT";
        public string FITSFilePath = @"d:\2\"; //without slash - except root dir ;)
        public string FullFITSFileName;



        internal UInt16 BlockLen = 2880;




        //Each header or data unit is a multiple of 2880 bytes long. If necessary, the header or data unit is padded out to the required length with ASCII blanks or NULLs depending on the type of unit.
        //Each header unit contains a sequence of fixed-length 80 - character keyword records which have the general form:
        //KEYNAME = value / comment string
        //The keyword names may be up to 8 characters long and can only contain uppercase letters A to Z, the digits 0 to 9, the hyphen, and the underscore character.
        //The keyword name is (usually) followed by an equals sign and a space character in columns 9 and 10 of the record, followed by the value of the keyword which may be either an integer, a floating point number, a complex value(i.e., a pair of numbers), a character string(enclosed in single quotes), or a Boolean value(the letter T or F).
        //Some keywords, (e.g., COMMENT and HISTORY) are not followed by an equals sign and in that case columns 9 - 80 of the record may contain any string of ASCII text.

        FileStream FS;

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
                string stBlock = "";

                //Откроем поток
                using (FS = new FileStream(FullFITSFileName, FileMode.Open))
                {
                    //Прочитаем все блоки заголовка
                    bool bHeaderRead = false;
                    int i = 0;
                    do
                    {
                        stBlock += FITSReadBlock(i);

                        if (stBlock.Contains("END"))
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

                //Обработаем заголовок
                FITSParseHeaderData(stBlock);

            }
            catch (Exception ex)
            {
                Logging.AddLog("Cant read logfile contents [" + FullFITSFileName + "]", LogLevel.Important, Highlight.Error);
                Logging.AddLog(MethodBase.GetCurrentMethod().Name + "error! [" + ex.ToString() + "]", LogLevel.Debug, Highlight.Error);
            }
        }




        /// <summary>
        /// Read FITS HEADER block
        /// </summary>
        /// <param name="BlockNum">Block num, from 0</param>
        /// <returns>Block contents</returns>
        private string FITSReadBlock(int BlockNum=0)
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
                Logging.AddLog("Cant read fits block [BlockNum] from [" + FullFITSFileName + "]", LogLevel.Important, Highlight.Error);
                Logging.AddLog(MethodBase.GetCurrentMethod().Name + "error! [" + ex.ToString() + "]", LogLevel.Debug, Highlight.Error);
            }

            return stReadBlock;
        }

        /// <summary>
        /// Parse header into keywords and values
        /// </summary>
        /// <param name="stHeader"></param>
        void FITSParseHeaderData(string stHeader)
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

                    //get comment
                    ParseLine(KEYWORD, VAL, COMMENT);
                } //ignore keyless line
            } //end of while
        }

        void ParseLine(string Keyword, string Val, string Comment)
        {
            //tets
        }

    }
}
