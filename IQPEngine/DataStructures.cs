using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IQPEngineLib
{
    public class DSSQualityData
    {
        public Int32 StarsNumber = 0;
        public Double SkyBackground = 0.0;

        internal Double MeanRadiusSum = 0.0;
        internal Int32 MeanRadiusNum = 0;

        internal Double AspectRatioSum = 0.0;
        internal Int32 AspectRatioNum = 0;

        internal const double Multiplier = 1.566;

        public double MeanRadius
        {
            get
            {
                return MeanRadiusSum / MeanRadiusNum * Multiplier;
            }
        }

        public double AspectRatio
        {
            get
            {
                return AspectRatioSum / AspectRatioNum;
            }
        }
    }

    public class FITSHeaderData
    {
        public DateTime DateObsUTC_dt; //DATE-OBS
        public string DateObsUTC; //DATE-OBS

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


    /// <summary>
    /// Contains all results to use
    /// </summary>
    public class FileParseResult
    {
        public string FITSFileName = "";
        public DSSQualityData QualityData;
        public FITSHeaderData HeaderData;
        public double PixelResolution
        {
            get
            {
                return HeaderData.CameraPixelSizeX / HeaderData.TelescopeFocusLen * 206.265;    //  Formula:   (   Pixel Size   /   Telescope Focal Length   )   X 206.265
            }
        }
        public double FWHM
        {
            get
            {
                return QualityData.MeanRadius * PixelResolution;
            }
        }

        public WebExtensionsClass WebExtensions;
    }


    public class IQPDataJSON
    {
        public Int32 StarsNumber { get; set; }
        public Double SkyBackground { get; set; }
        public double MeanRadius { get; set; }
        public double AspectRatio { get; set; }

        public DateTime DateObsUTC { get; set; }   //DATE-OBS
        public double ImageExposure { get; set; }   //EXPOSURE
        public string ImageFilter { get; set; }   //FILTER
        public string ImageType { get; set; }   //IMAGETYP

        public double ImageBinningX { get; set; }   //XBINNING
        public double ImageBinningY { get; set; }   //YBINNING

        public double ImageSetTemp { get; set; }   //SET-TEMP
        public double ImageTemp { get; set; }   //CCD-TEMP

        public double CameraPixelSizeX { get; set; }   //XPIXSZ
        public double CameraPixelSizeY { get; set; }   //YPIXSZ

        public string ObjName { get; set; }    //OBJECT
        public string ObjRA { get; set; }      //OBJCTRA
        public string ObjDec { get; set; }     //OBJCTDEC
        public double ObjAlt { get; set; }     //OBJCTALT
        public double ObjAz { get; set; }      //OBJCTAZ

        public string CameraName { get; set; }   //INSTRUME    
        public string Observer { get; set; }    //OBSERVER
        public string TelescopeName { get; set; }      //TELESCOP
        public double TelescopeFocusLen { get; set; }      //FOCALLEN
        public double TelescopeDiameter { get; set; }      //APTDIA

        public string FITSFileName { get; set; }
        public double PixelResolution { get; set; }

        public double FWHM { get; set; }
    }

}
