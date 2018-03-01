using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace LoggingLib
{
    public class LogRecord
    {
        public DateTime Time;
        public LogLevel LogLevel = LogLevel.Activity;
        public string Procedure = "";
        public string Message = "";
        public Highlight Highlight = 0;
        public string Caller = "";
        public bool dumpedToFile = false;
        public bool displayed = false;
    }

    public enum Highlight
    {
        Normal = 0,
        Error = 1,
        Emphasize = 2,
        Debug = 3
    }

    public enum LogLevel
    {
        Important = 0,
        Activity = 1,
        Debug = 2,
        Chat = 3,
        Trace = 4,
        All = 999
    }

    public class Logging
    {
        /// <summary>
        /// Log main structure
        /// </summary>
        public static List<LogRecord> LOGLIST;

        //******************************************************
        // Пишет логи в два файла:
        //      "c:\Users\Emchenko Boris\Documents\AstrohostelTools\Logs\imagepublisher_2018-03-02 00-00-39.log" 
        //      "c:\Users\Emchenko Boris\Documents\AstrohostelTools\Logs\imagepublisher_trace_2018-03-02 00-00-39.log" 
        //******************************************************
        //  BEFORE 1ST RUN NEED TO SETUP:
        //******************************************************
        //  1. Установить глобальную папку, где будет храниться папка с логами (GlobalLogFolderContext)
        //  2. В ней будет автоматически создана папка LOG_FOLDER_NAME
        //  3. Указать префикс имени лог файла LOG_FILE_NAME_MAIN
        //  4. Указать, нужен ли вообще полный файл (settingsLOG_NOTICES)
        //  Можно делать напрямую, а можно, чтобы не забыть, вызывать InitLogging
        //******************************************************
        #region LOG FILES DATA
            /// <summary>
            /// Log Parent Dir, where LOG_FOLDER_NAME folder with log files will be
            /// </summary>
            public static string GlobalLogFolderContext = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
                        //should be set on creation (as below). Otherwise - use Document folder
                    //public static string ProgDocumentsFolderName = "AstrohostelTools"; //set this property to change 
                    //public static string ProgDocumentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ProgDocumentsFolderName) + "\\";
        
                /// <summary>
                /// Folder with log files
                /// </summary>
                public static string LOG_FOLDER_NAME = "Logs";

                /// <summary>
                /// Log file with Main Events (debug, activity, important)
                /// </summary>
                public static string LOG_FILE_NAME_MAIN = "logs_";      //file name prefis (suffix will be data)

                /// <summary>
                /// Log file with Notices (all events)
                /// </summary>
                public static string LOG_FILE_NAME_ALL = "logs_trace_"; //file name prefis (suffix will be data)

                /// <summary>
                /// Log file extensions
                /// </summary>
                public static string LOG_FILE_EXT = "log"; //file log extensions

                public static bool settingsLOG_NOTICES = false; //should notices also be logged???
        #endregion LOG FILES DATA






        
        //DEBUG LEVEL
        public static LogLevel DEBUG_LEVEL = LogLevel.All;

        public static Int32 _MAX_DIPSLAYED_PROG_LOG_LINES = 100;
        public static Int32 _MAX_LOGLIST_SIZE = 65000;

        //**************************************************
        // PRIVATE PROPERTIES
        //**************************************************
        #region Private Properies
            private static string LogFilePath="";   //полный путь к папке с логами. Устанавливается GetLogDirectory()

            private static string currentLogAllFileFullName = ""; //путь и имя файла лога текущей сессии
            private static string currentLogMainFileFullName = ""; //путь и имя файла лога текущей сессии

            //Block log operations flag (for asynchrouneous operations)
            private static bool LOCKLOGFILE = false;
        #endregion

        static Logging()
        {
            LOGLIST = new List<LogRecord>();
        }

        /// <summary>
        /// Recomend to run this during program initialization
        /// </summary>
        /// <param name="GlobalLogFolderContextExt"></param>
        /// <param name="MainEventsLogFileNamePrefix"></param>
        /// <param name="LogNoticesFlag"></param>
        /// <param name="NoticesLogFileNamePrefix"></param>
        public static void InitLogging(string GlobalLogFolderContextExt, string MainEventsLogFileNamePrefix, bool LogNoticesFlag = false, string NoticesLogFileNamePrefix = "")
        {
            GlobalLogFolderContext = GlobalLogFolderContextExt;
            LOG_FILE_NAME_MAIN = MainEventsLogFileNamePrefix;
            settingsLOG_NOTICES = LogNoticesFlag;
            LOG_FILE_NAME_ALL = (NoticesLogFileNamePrefix == "" ? MainEventsLogFileNamePrefix + "trace_" : NoticesLogFileNamePrefix);
        }

        /// <summary>
        /// Get current log files names with path (full log file)
        /// </summary>
        private static string LogAllFileFullName
        {
            get
            {
                if (currentLogAllFileFullName == "")
                {
                    LogFilePath = GetLogDirectory();
                    currentLogAllFileFullName = Path.Combine(LogFilePath, LOG_FILE_NAME_ALL + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + "." + LOG_FILE_EXT);
                }
                return currentLogAllFileFullName;
            }
        }
        /// <summary>
        /// Get current log files names with path (main log file)
        /// </summary>
        private static string LogMainFileFullName
        {
            get
            {
                if (currentLogMainFileFullName == "")
                {
                    LogFilePath = GetLogDirectory();
                    currentLogMainFileFullName = Path.Combine(LogFilePath, LOG_FILE_NAME_MAIN + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + "." + LOG_FILE_EXT);
                }
                return currentLogMainFileFullName;
            }
        }

        /// <summary>
        /// Check if log folder exits, and if not - create it
        /// </summary>
        /// <returns>Current log file path</returns>
        private static string GetLogDirectory(bool ForceCheckDir = false)
        {
            if (LogFilePath == "" || ForceCheckDir)
            {
                string st = "";
                //Check if root folder exists. If not - create it
                if (!Directory.Exists(GlobalLogFolderContext) || !Directory.Exists(Path.Combine(GlobalLogFolderContext, LOG_FOLDER_NAME)))
                {
                    CreateDocumentsDirStructure(); //on earlier version - use ConfigManagement
                }

                //Log folder exists (Creation succeeds)?
                if (Directory.Exists(Path.Combine(GlobalLogFolderContext, LOG_FOLDER_NAME) + "\\"))
                {
                    //use default folder
                    LogFilePath = Path.Combine(GlobalLogFolderContext, LOG_FOLDER_NAME);
                }
                else
                {
                    //if not - use app folder
                    LogFilePath = Application.StartupPath;
                }
                return LogFilePath;
            }
            else
            {
                return LogFilePath;
            }
        }


        /// <summary>
        /// Add log record to DataBase (LogList LIST)
        /// </summary>
        /// <param name="logMessage"></param>
        /// <param name="LogLevel"></param>
        /// <param name="ColorHoghlight"></param>
        public static void AddLog(string logMessage, LogLevel LogLevel = LogLevel.Important, Highlight ColorHighlight = Highlight.Normal, string logProcedure = "")
        {
            //Add to list
            LogRecord LogRec = new LogRecord();
            LogRec.Time = DateTime.Now;
            LogRec.Procedure = logProcedure;
            LogRec.Message = logMessage;
            LogRec.LogLevel = LogLevel;
            LogRec.Highlight = ColorHighlight;
            LOCKLOGFILE = true; // <<<
            LOGLIST.Add(LogRec);
            LOCKLOGFILE = false;// >>>
        }

        /// <summary>
        /// Dump to file Log Contents (LogList LIST)
        /// </summary>
        public static void DumpToFile(LogLevel LogLevel = LogLevel.All)
        {
            List<LogRecord> LogListNewAll = new List<LogRecord>();
            List<LogRecord> LogListNewMainOnly = new List<LogRecord>();

            LOCKLOGFILE = true; // <<<

            //sort new (not saved) records
            for (var i = 0; i < LOGLIST.Count; i++)
            {
                // if current line wasn't written to file
                if (LOGLIST[i] != null && !LOGLIST[i].dumpedToFile) //Always check for null due to multithreading!!!
                {
                    LogListNewAll.Add(LOGLIST[i]); //add to newrecords array
                    if (LOGLIST[i].LogLevel <= LogLevel.Debug)
                        LogListNewMainOnly.Add(LOGLIST[i]); //add Important, Activity, Debug level only to array

                    LOGLIST[i].dumpedToFile = true; //mark as written
                }
            }

            LOCKLOGFILE = false;// >>>

            //Save new (not saved) records
            if (LogListNewAll.Count > 0)
            {
                try
                {
                    //if setting to log notices - then write them
                    if (settingsLOG_NOTICES)  
                    {
                        // Write all (trace) log file 
                        using (StreamWriter LogFile = new StreamWriter(LogAllFileFullName, true))
                        {
                            for (var i = 0; i < LogListNewAll.Count; i++)
                            {
                                // if current log level is less then DebugLevel
                                if (LogListNewAll[i].LogLevel <= LogLevel)
                                {
                                    //time
                                    LogFile.Write("{0,-12}{1,-14}", LogListNewAll[i].Time.ToString("yyyy-MM-dd"), LogListNewAll[i].Time.ToString("HH:mm:ss.fff"));
                                    //LogLevel
                                    LogFile.Write("{0,-10}", LogListNewAll[i].LogLevel.ToString());
                                    //message
                                    LogFile.Write("{0}\t", LogListNewAll[i].Message);
                                    LogFile.WriteLine();
                                }
                            }
                        }
                    }

                    // Write main (debug, activity, important) log file 
                    using (StreamWriter LogFile2 = new StreamWriter(LogMainFileFullName, true))
                    {
                        for (var i = 0; i < LogListNewMainOnly.Count; i++)
                        {
                            // if current log level is less then DebugLevel
                            if (LogListNewMainOnly[i].LogLevel <= LogLevel)
                            {
                                //time
                                LogFile2.Write("{0,-12}{1,-14}", LogListNewMainOnly[i].Time.ToString("yyyy-MM-dd"), LogListNewMainOnly[i].Time.ToString("HH:mm:ss.fff"));
                                //LogLevel
                                LogFile2.Write("{0,-10}", LogListNewMainOnly[i].LogLevel.ToString());
                                //message
                                LogFile2.Write("{0}\t", LogListNewMainOnly[i].Message);
                                LogFile2.WriteLine();
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Log write error [" + Ex.Message + "]");
                }
            }

            //Cleanup old records
            CleanupLogList();

        }

        /// <summary>
        /// Dump to screen Log Contents
        /// </summary>
        public static string DumpToString(LogLevel LogLevel = LogLevel.Activity)
        {
            string RetStr = "";
            for (var i = 0; i < LOGLIST.Count; i++)
            {
                // if current line wasn't written to file
                if (!LOGLIST[i].displayed)
                {
                    // if current log level is less then DebugLevel
                    if (LOGLIST[i].LogLevel <= LogLevel)
                    {
                        RetStr += String.Format("{0} {1}", LOGLIST[i].Time.ToString("yyyy-MM-dd"), LOGLIST[i].Time.ToString("HH:mm:ss"));
                        RetStr += String.Format(": {0}", LOGLIST[i].Message) + Environment.NewLine;
                    }
                    LOGLIST[i].displayed = true;
                }
            }
            return RetStr;
        }

        /// <summary>
        /// Dump to screen Log Contents
        /// </summary>
        public static void DisplayLogInTextBox(RichTextBox LogTextBox, LogLevel LogLevel = LogLevel.Activity)
        {
            List<LogRecord> LogListNew = new List<LogRecord>();

            //sort new (not saved) records
            for (var i = 0; i < LOGLIST.Count; i++)
            {
                // if current line wasn't displayed
                if (LOGLIST[i] !=null && !LOGLIST[i].displayed) //Always check for null due to multithreading!!!
                {
                    LogListNew.Add(LOGLIST[i]); //add to newrecords array
                    LOGLIST[i].displayed = true; //mark as written
                }
            }

            //check - if logtextbox is too large
            if (LogTextBox.Lines.Length > _MAX_DIPSLAYED_PROG_LOG_LINES)
            {
                string[] lines = LogTextBox.Lines;
                var newLines = lines.Skip(LogTextBox.Lines.Length - _MAX_DIPSLAYED_PROG_LOG_LINES);
                LogTextBox.Lines = newLines.ToArray();
            }

            string RetStr = "";
            //Save new (not saved) records
            if (LogListNew.Count > 0)
            {
                for (var i = 0; i < LogListNew.Count; i++)
                {
                    // if current log level is less then DebugLevel
                    if (LogListNew[i].LogLevel <= LogLevel)
                    {
                        LogTextBox.SelectionStart = LogTextBox.TextLength;
                        LogTextBox.SelectionLength = 0;

                        if (LogListNew[i].Highlight == Highlight.Error)
                        {
                            LogTextBox.SelectionColor = Color.Red;
                        }
                        else if (LogListNew[i].Highlight == Highlight.Emphasize)
                        {
                            LogTextBox.SelectionFont = new Font(LogTextBox.Font, FontStyle.Bold);
                        }

                        RetStr = String.Format("{0} {1}", LogListNew[i].Time.ToString("yyyy-MM-dd"), LogListNew[i].Time.ToString("HH:mm:ss"));
                        RetStr += String.Format(": {0}", LogListNew[i].Message) + Environment.NewLine;

                        LogTextBox.AppendText(RetStr);

                        LogTextBox.SelectionColor = LogTextBox.ForeColor;

                        //set cursor to the end
                        LogTextBox.SelectionStart = LogTextBox.TextLength;
                        LogTextBox.SelectionLength = 0;
                        LogTextBox.ScrollToCaret();
                    }
                }
            }
        }

        public static string LogExceptionMessage(Exception Ex, string MESSAGEST, bool ImportantLogFlag = true)
        {
            StackTrace st = new StackTrace(Ex, true);
            StackFrame[] frames = st.GetFrames();
            string messstr = "";

            // Iterate over the frames extracting the information you need
            foreach (StackFrame frame in frames)
            {
                messstr += String.Format("{0}:{1}({2},{3})", frame.GetFileName(), frame.GetMethod().Name, frame.GetFileLineNumber(), frame.GetFileColumnNumber());
            }

            string FullMessage = MESSAGEST + Environment.NewLine;
            FullMessage += Environment.NewLine + Environment.NewLine + "Debug information:" + Environment.NewLine + "Exception source: " + Ex.Data + " " + Ex.Message
                    + Environment.NewLine + Environment.NewLine + messstr;
            //MessageBox.Show(this, FullMessage, "Invalid value", MessageBoxButtons.OK);

            Logging.AddLog(MESSAGEST + ", exception: " + Ex.Message, (ImportantLogFlag ? LogLevel.Important : LogLevel.Debug), Highlight.Error);
            Logging.AddLog(FullMessage, LogLevel.Debug, Highlight.Error);

            return FullMessage;
        }

        /// <summary>
        /// Maintain reasonable LOGLIST size
        /// </summary>
        private static void CleanupLogList()
        {
            if (LOGLIST.Count() > _MAX_LOGLIST_SIZE)
            {
                try
                {
                    //Clean LOGFILE from records already dumped
                    for (var i = _MAX_LOGLIST_SIZE; i < LOGLIST.Count; i++)
                    {
                        if (LOGLIST[i - _MAX_LOGLIST_SIZE].dumpedToFile)
                        {
                            if (LOCKLOGFILE) return;
                            // if current line was written to file remove it
                            LOGLIST.RemoveAt(i - _MAX_LOGLIST_SIZE);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    // Disabled MessageBox because of errors out of asynchroneous nature
                    // MessageBox.Show("Log error during cleanup [" + Ex.Message + "]");
                }
            }
        }


        /// <summary>
        /// Создает папку, в которую будут писаться логи, храниться конфиги и т.д.
        /// </summary>
        /// <returns></returns>
        public static bool CreateDocumentsDirStructure()
        {
            bool wasCreated = false;

            try
            {
                //Is - Documents/ObservatoryControl
                if (!Directory.Exists(GlobalLogFolderContext))
                {
                    Directory.CreateDirectory(GlobalLogFolderContext);
                    Logging.AddLog("Root directory [" + GlobalLogFolderContext + "] created", LogLevel.Important, Highlight.Emphasize);
                    wasCreated = true;
                }

                //Is - Documents/ObservatoryControl/Logs
                if (!Directory.Exists(GetLogDirectory()))
                {
                    Directory.CreateDirectory(Logging.LogFilePath);
                    Logging.AddLog("Log directory [" + Logging.LogFilePath + "] created", LogLevel.Important, Highlight.Emphasize);
                    wasCreated = true;
                }
            }
            catch (Exception ex)
            {
                Logging.AddLog("Create directory structure error: " + ex.Message, LogLevel.Important, Highlight.Error);
                Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
            }

            return wasCreated;
        }


    }
}
