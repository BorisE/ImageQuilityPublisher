using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using LoggingLib;

namespace LoggingLib
{

    /// <summary>
    /// Config based on custom XML file
    /// 
    /// 1.3 [2018-03-04]
    /// - getting config file storage was rewritten
    /// 1.2 [2018-03-02]
    /// - create directory (CreateDocumentsDirStructure) now creates only Config dir (earlier also Log)
    /// 1.1 [2018-02-01]
    /// - can now create sections
    ///
    /// Рекомендуемый способ устроения сохраения в Программе: 
    ///  1. [LoadParamsFromConfigFile] загружает из XML в переменные
    ///  2. [UpdateSettingsDialogFields] из переменных обновляет элементы формы
    /// Как устроить сохранение:
    ///  1. [SaveSettingsToConfigFile] сохраняет из элементов форм в XML
    ///  2. [LoadParamsFromConfigFile] загружает из XML в переменные
    ///
    /// Есть одна особенность хранения файла (во вермя разработки, по крайней мере)
    /// 1. Дефольный конфиг под именем ObservatoryControl.defaultconfig.txt" при разработке храниться в паке с исходным кодом (чтобы он синхронизировался через GITHUB он должен лежать там, где хранится весь SourceCode) ("c:\Users\Emchenko Boris\Source\Repos\ObsControl\ObservatoryControl\ObservatoryControl.defaultconfig.txt")
    /// 2. При компиляции он копируется в \Source\Repos\ObsControl\ObservatoryControl\bin\Debug\ 
    /// 3. A рабочий лежит в \Documents\ObservatoryControl\Config\ObservatoryControl.config 
    /// Обновлять лучше так: редактируем дефолтный (txt) в папке с SourceCode (ПОМНИ НЕ .../DEBUG!!!), при компиляции он скопируется сам, а рабочий просто удаляем (при запуске перепишется). Ну или рабочий копировать в текстовый, но опять же - в папку с SourceCode.
    /// </summary>
    public static class ConfigManagement
    {

        /// <summary>
        /// Main Object to store config base XML markup
        /// </summary>
        public static XmlDocument configXML = new XmlDocument();

        
        //******************************************************
        //  BEFORE 1ST RUN NEED TO SETUP:
        //******************************************************
        //  1. Установить глобальную папку, где будет храниться папка с логами (GlobalConfigFolderContext)
        //  2. В ней будет автоматически создана папка LOG_FOLDER_NAME
        //  3. Указать префикс имени лог файла LOG_FILE_NAME_MAIN
        //  4. Указать, нужен ли вообще полный файл (settingsLOG_NOTICES)
        //  Можно делать напрямую, а можно, чтобы не забыть, вызывать InitLogging
        //******************************************************
        #region LOG FILES STORAGE
            /// <summary>
            /// Log Parent Dir, where LOG_FOLDER_NAME folder with log files will be
            /// </summary>
            public static string GlobalConfigFolderContext = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);  //"c:\Users\Emchenko Boris\Documents\AstrohostelTools" 
                                                                                                                                //should be set on creation (as below). Otherwise - use Document folder

            /// <summary>
            /// Folder with log files
            /// </summary>
            public static string CONFIG_FOLDER_NAME = "Config";  //last part, full path would be smt like "c:\Users\Emchenko Boris\Documents\AstrohostelTools\Config

            public static string CONFIG_FILENAME = "ImageQualityPublisher.config";                      // Config name
            public static string DEFAULT_CONFIG_FILENAME = "ImageQualityPublisher.defaultconfig.txt";   //Default config file
        #endregion

        private static string calculatedConfigFilePath = "";
        private static string calculatedConfigFullFileName = "";
        

        /// <summary>
        /// Init Configuration File Storage
        /// -----------
        /// Recommend to run it always on Program Startup
        /// </summary>
        /// <param name="GlobalConfigFolderContextExt">e.g. c:\Users\Admin\Documents\AstrohostelTools</param>
        /// <param name="ConfigFileName">e.g. ImageQualityPublisher.config</param>
        /// <param name="DefaultConfigFileName">e.g. ImageQualityPublisher.defaultconfig.txt</param>
        public static void InitConfig(string GlobalConfigFolderContextExt, string ConfigFileName, string DefaultConfigFileName = "")
        {
            GlobalConfigFolderContext = GlobalConfigFolderContextExt;
            CONFIG_FILENAME = ConfigFileName;
            DEFAULT_CONFIG_FILENAME = DefaultConfigFileName;
        }


        //***************************************************************************************************************************
        #region Config File Management

        /// <summary>
        /// Get current config file name with path (full config file)
        /// </summary>
        private static string getConfigFileFullName
        {
            get
            {
                if (calculatedConfigFullFileName == "")
                {
                    calculatedConfigFilePath = GetConfigDir();
                    calculatedConfigFullFileName = Path.Combine(calculatedConfigFilePath, CONFIG_FILENAME);
                }
                return calculatedConfigFullFileName;
            }
        }

        /// <summary>
        /// Check if config folder exits, and if not - create it
        /// Also cache this value in [calculatedConfigFilePath]
        /// </summary>
        /// <returns>Current config file path</returns>
        private static string GetConfigDir(bool ForceCheckDir = false)
        {
            if (calculatedConfigFilePath == "" || ForceCheckDir)
            {
                string st = "";
                //Check if root folder exists. If not - create it
                if (!Directory.Exists(GlobalConfigFolderContext) || !Directory.Exists(Path.Combine(GlobalConfigFolderContext, CONFIG_FOLDER_NAME)))
                {
                    CreateDocumentsDirStructure();
                }

                //Config folder exists (Creation succeeds)?
                if (Directory.Exists(Path.Combine(GlobalConfigFolderContext, CONFIG_FOLDER_NAME) + "\\"))
                {
                    //use default folder
                    calculatedConfigFilePath = Path.Combine(GlobalConfigFolderContext, CONFIG_FOLDER_NAME);
                }
                else
                {
                    //if not - use app folder
                    calculatedConfigFilePath = Application.StartupPath;
                }
            }
            return calculatedConfigFilePath;
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
                if (!Directory.Exists(GlobalConfigFolderContext))
                {
                    Directory.CreateDirectory(GlobalConfigFolderContext);
                    Logging.AddLog("Root directory [" + GlobalConfigFolderContext + "] created", LogLevel.Important, Highlight.Emphasize);
                    wasCreated = true;
                }

                //Is - Documents/ObservatoryControl/Config
                if (!Directory.Exists(Path.Combine(GlobalConfigFolderContext, CONFIG_FOLDER_NAME)))
                {
                    Directory.CreateDirectory(Path.Combine(GlobalConfigFolderContext, CONFIG_FOLDER_NAME));
                    Logging.AddLog("Config directory [" + Path.Combine(GlobalConfigFolderContext, CONFIG_FOLDER_NAME) + "] created", LogLevel.Important, Highlight.Emphasize);
                    wasCreated = true;

                    //Config Default Config
                    CopyDefaultConfig();
                }
            }
            catch (Exception ex)
            {
                Logging.AddLog("Create directory structure error: " + ex.Message, LogLevel.Important, Highlight.Error);
                Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
            }

            return wasCreated;
        }

        /// <summary>
        /// Copy default config to CONFIG dir
        /// </summary>
        private static void CopyDefaultConfig()
        {
            //Path.Combine(calculatedConfigFilePath, CONFIG_FILENAME);
            if (!File.Exists(Path.Combine(GlobalConfigFolderContext, CONFIG_FOLDER_NAME, CONFIG_FILENAME)))
            {
                if (!Directory.Exists(Path.Combine(GlobalConfigFolderContext, CONFIG_FOLDER_NAME)))
                {
                    Logging.AddLog("Config folder [" + Path.Combine(GlobalConfigFolderContext, CONFIG_FOLDER_NAME) + "] not found. Recreating structure", LogLevel.Important, Highlight.Emphasize);
                    //Create dir structure if needed
                    CreateDocumentsDirStructure();
                }

                //Copy default config
                try
                {
                    File.Copy(Path.Combine(Environment.CurrentDirectory, DEFAULT_CONFIG_FILENAME), Path.Combine(GlobalConfigFolderContext, CONFIG_FOLDER_NAME, CONFIG_FILENAME));
                    Logging.AddLog("Default config was copied", LogLevel.Important, Highlight.Emphasize);
                }
                catch (Exception ex)
                {
                    Logging.AddLog("Default config copying error: " + ex.Message, LogLevel.Important, Highlight.Error);
                    Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
                }
            }
        }

        #endregion Config File Management
        //***************************************************************************************************************************
        

        /// <summary>
        /// Load configuration XML file
        /// </summary>
        /// <returns>true if loaded, false if error</returns>
        public static bool Load()
        {
            bool res = false;
            try
            {
                configXML.Load(getConfigFileFullName);
                Logging.AddLog("Configuration file [" + getConfigFileFullName + "] loaded", LogLevel.Activity);
                return true;
            }
            catch (Exception ex)
            {
                if (ex is System.IO.FileNotFoundException || ex is System.IO.DirectoryNotFoundException)
                {
                    Logging.AddLog("No configuration file found", LogLevel.Important, Highlight.Error);

                    CopyDefaultConfig();

                    try
                    {
                        configXML.Load(getConfigFileFullName);
                        return true;
                    }
                    catch (Exception ex2)
                    {
                        Logging.AddLog("Load configuration error: " + ex2.Message, LogLevel.Important, Highlight.Error);
                        Logging.AddLog("Exception details: " + ex2.ToString(), LogLevel.Debug, Highlight.Debug);
                    }
                }
                else
                {
                    Logging.AddLog("Load configuration error: " + ex.Message, LogLevel.Important, Highlight.Error);
                    Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
                }
                res = false;
            }
            return res;
        }

        /// <summary>
        /// Save current configXML to disk
        /// </summary>
        /// <returns></returns>
        public static bool Save()
        {
            bool res = false;
            try
            {
                configXML.Save(getConfigFileFullName);
                Logging.AddLog("Configuration was successfuly saved to file", LogLevel.Activity);
                return true;
            }
            catch (Exception ex)
            {
                if (ex is System.IO.FileNotFoundException || ex is System.IO.DirectoryNotFoundException)
                {
                    Logging.AddLog("No configuration file found", LogLevel.Important, Highlight.Error);
                    Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
                    res = false;
                }
                else
                {
                    Logging.AddLog("Save configuration error: " + ex.Message, LogLevel.Important, Highlight.Error);
                    Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
                }
                res = false;
            }
            return res;
        }

        //***************************************************************************************************************
        // GET VALUES ///////////////////////////////////////////////////
        #region Get Values by Type

        public static string getString(string section, string key)
        {
            string res = null;
            try
            {
                XmlNode nodeAppSet = configXML.SelectSingleNode("//" + section);
                res = nodeAppSet[key].Attributes["value"].Value;
            }
            catch (Exception ex)
            {
                Logging.AddLog("Config parameter [" + section + "][" + key + "] not found: " + ex.Message, LogLevel.Activity, Highlight.Error);
                Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
                res = null;
            }
            return res;
        }

        public static bool? getBool(string section, string key)
        {
            bool? res = null;
            try
            {
                XmlNode nodeAppSet = configXML.SelectSingleNode("//" + section);
                string st = nodeAppSet[key].Attributes["value"].Value;
                res = Convert.ToBoolean(st);
            }
            catch (Exception ex)
            {
                Logging.AddLog("getBool [" + key + "] error: " + ex.Message, LogLevel.Important, Highlight.Error);
                Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
                res = null;
            }
            return res;
        }

        public static int? getInt(string section, string key)
        {
            int? res = null;
            try
            {
                XmlNode nodeAppSet = configXML.SelectSingleNode("//" + section);
                string st = nodeAppSet[key].Attributes["value"].Value;
                res = Convert.ToInt32(st);
            }
            catch (Exception ex)
            {
                Logging.AddLog("getInt [" + key + "] error: " + ex.Message, LogLevel.Important, Highlight.Error);
                Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
                res = null;
            }
            return res;
        }

        public static double? getDouble(string section, string key)
        {
            double? res = null;
            try
            {
                XmlNode nodeAppSet = configXML.SelectSingleNode("//" + section);
                string st = nodeAppSet[key].Attributes["value"].Value;
                res = Convert.ToDouble(st);
            }
            catch (Exception ex)
            {
                Logging.AddLog("getDouble [" + key + "] error: " + ex.Message, LogLevel.Important, Highlight.Error);
                Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
                res = null;
            }
            return res;
        }
        //***************************************************************************************************************
        #endregion Get Values
        //***************************************************************************************************************



        // SECTION CONTENTS ///////////////////////////////////////////////////
        #region Section management
        public static List<string> getAllSectionNamesList(string sectionName)
        {
            List<string> res = new List<string>();

            try
            {
                XmlNode xnlNodes = ConfigManagement.configXML.SelectSingleNode("//" + sectionName);
                // Перебрать все вложеннные узлы и добавить их в List
                foreach (XmlNode xndNode in xnlNodes.ChildNodes)
                {
                    res.Add(xndNode.Name);
                }
            }
            catch (Exception ex)
            {
                Logging.AddLog("Config section [" + sectionName + "] not found: " + ex.Message, LogLevel.Activity, Highlight.Error);
                Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
                res = null;
            }
            return res;
        }

        public static XmlNode getXMLNode(string sectionName)
        {
            XmlNode res = null;
            try
            {
                XmlNode nodeAppSet = configXML.SelectSingleNode("//" + sectionName);
                res = nodeAppSet;
            }
            catch (Exception ex)
            {
                Logging.AddLog("getXMLNode [" + sectionName + "] error: " + ex.Message, LogLevel.Important, Highlight.Error);
                Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
                res = null;
            }
            return res;
        }

        public static void ClearSection(string sectionName)
        {
            try
            {
                XmlNode xnlNodes = ConfigManagement.configXML.SelectSingleNode("//" + sectionName);
                for (int i = xnlNodes.ChildNodes.Count - 1; i >= 0; i--)
                {
                    xnlNodes.RemoveChild(xnlNodes.ChildNodes[i]);
                }
            }
            catch (Exception ex)
            {
                Logging.AddLog("ClearSection [" + sectionName + "] error: " + ex.Message, LogLevel.Important, Highlight.Error);
                Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
            }
        }
        #endregion Section management
        //***************************************************************************************************************


        /// <summary>
        /// Used to change config value before saving
        /// </summary>
        /// <param name="sectionName">Section</param>
        /// <param name="curName">Node name</param>
        /// <param name="curValue">New value to set</param>
        public static void UpdateConfigValue____(string sectionName, string curName = "", string curValue = "")
        {
            
            try
            {
                // Получить перечень Узлов из текущей секции
                XmlNode xnlNodes = ConfigManagement.configXML.SelectSingleNode("//" + sectionName);
                // Перебрать их всех и поправить аттрибуты для текущего
                foreach (XmlNode xndNode in xnlNodes.ChildNodes)
                {
                    //Update data
                    if (xndNode.Name == curName)
                    {
                        if (curValue != "")
                        {
                            XmlAttribute att = ConfigManagement.configXML.CreateAttribute("value");
                            att.Value = curValue;
                            xndNode.Attributes.SetNamedItem(att);
                        }
                    }
                } //foreach
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame[] frames = st.GetFrames();
                string messstr = "";

                // Iterate over the frames extracting the information you need
                foreach (StackFrame frame in frames)
                {
                    messstr += String.Format("{0}:{1}({2},{3})", frame.GetFileName(), frame.GetMethod().Name, frame.GetFileLineNumber(), frame.GetFileColumnNumber());
                }

                string FullMessage = "Exception when loading CONFIG XML sections" + Environment.NewLine;
                FullMessage += Environment.NewLine + Environment.NewLine + "Debug information:" + Environment.NewLine + "IOException source: " + ex.Data + " " + ex.Message
                        + Environment.NewLine + Environment.NewLine + messstr;
                FullMessage += Environment.NewLine + "Section name: " + sectionName + ", xmlNode: " + curName ;


                MessageBox.Show(FullMessage, "Invalid value", MessageBoxButtons.OK);

                Logging.AddLog(FullMessage, LogLevel.Important, Highlight.Error);
            }
        }

        /// <summary>
        /// Used to change config value before saving
        /// if not found - create it
        /// </summary>
        /// <param name="sectionName">Section</param>
        /// <param name="curName">Node name</param>
        /// <param name="curValue">New value to set</param>
        public static void UpdateConfigValue(string sectionName, string curName = "", string curValue = "")
        {
            try
            {
                // Получить перечень Узлов из текущей секции
                XmlNode xmlSectionNode = ConfigManagement.configXML.SelectSingleNode("//" + sectionName);
                // Если не существует, то создать секцию!
                if (xmlSectionNode == null)
                {
                    XmlNode root = ConfigManagement.configXML.SelectSingleNode("configuration");
                    xmlSectionNode = ConfigManagement.configXML.CreateElement(sectionName);
                    XmlNode newNode = ConfigManagement.configXML.CreateElement(curName);
                    xmlSectionNode.AppendChild(newNode);
                    root.AppendChild(xmlSectionNode);
                    //root.AppendChild(newNodeEnd);
                    //XElement
                }

                bool bFound = false;
                // Перебрать их всех и поправить аттрибуты для текущего
                foreach (XmlNode xndNode in xmlSectionNode.ChildNodes)
                {
                    //Update data
                    if (xndNode.Name == curName)
                    {
                        bFound = true;
                        if (curValue != "" || curValue == "") //<-- @todo
                        {
                            XmlAttribute att = ConfigManagement.configXML.CreateAttribute("value");
                            att.Value = curValue;
                            xndNode.Attributes.SetNamedItem(att);
                        }
                    }
                } //foreach

                if (!bFound)
                //Если не найдено, то сначала создать его
                {
                    XmlNode newNode = ConfigManagement.configXML.CreateNode(XmlNodeType.Element, curName, null);
                    if (curValue != "")
                    {
                        XmlAttribute att = ConfigManagement.configXML.CreateAttribute("value");
                        att.Value = curValue;
                        newNode.Attributes.SetNamedItem(att);
                    }
                    xmlSectionNode.AppendChild(newNode);
                }
 
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame[] frames = st.GetFrames();
                string messstr = "";

                // Iterate over the frames extracting the information you need
                foreach (StackFrame frame in frames)
                {
                    messstr += String.Format("{0}:{1}({2},{3})", frame.GetFileName(), frame.GetMethod().Name, frame.GetFileLineNumber(), frame.GetFileColumnNumber());
                }

                string FullMessage = "Exception when loading CONFIG XML sections" + Environment.NewLine;
                FullMessage += Environment.NewLine + Environment.NewLine + "Debug information:" + Environment.NewLine + "IOException source: " + ex.Data + " " + ex.Message
                        + Environment.NewLine + Environment.NewLine + messstr;
                FullMessage += Environment.NewLine + "Section name: " + sectionName + ", xmlNode: " + curName;


                MessageBox.Show(FullMessage, "Invalid value", MessageBoxButtons.OK);

                Logging.AddLog(FullMessage, LogLevel.Important, Highlight.Error);
            }
        }

    }

}
