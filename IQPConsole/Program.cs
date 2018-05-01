using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IQPEngineLib;
using LoggingLib;


namespace IQPConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            IQPEngine IQPObj = new IQPEngine(PublishData);
            IQPObj.MonitorObj.CheckForNewFiles(@"d:\CCD COmmander");
            IQPObj.ProcessingObj.ProcessAll();

            Console.WriteLine("The End");
            Logging.DumpToFile();

            Console.ReadLine();
        }


        static void PublishData(FileParseResult Res)
        {
            Console.WriteLine(Res.FITSFileName + "was proccessed");
        }
    }
}
