﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using LoggingLib;

namespace ImageQualityPublisher
{

    /// <summary>
    /// Config based on custom XML file
    /// 
    /// 1.2 [2018-03-02]
    /// - create directory (CreateDocumentsDirStructure) now creates only Config dir (earlier also Log)
    /// 1.1 [2018-02-01]
    /// - can now create sections
    /// </summary>
    public static class ConfigManagement
    {

        public static string ProgDocumentsFolderName = "AstrohostelTools"; //set this property to change 
        public static string ProgDocumentsFullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ProgDocumentsFolderName) + "\\";


        public static XmlDocument configXML = new XmlDocument();

        // Есть одна особенность хранения файла (во вермя разработки, по крайней мере)
        // 1. Чтобы он синхронизировался через GITHUB он должен лежать там, где хранится весь SourceCode ("c:\Users\Emchenko Boris\Source\Repos\ObsControl\ObservatoryControl\ObservatoryControl.config")
        // 2. Но для того, чтоыб он подгружался во время запуска,  он должен лежать в "c:\Users\Emchenko Boris\Source\Repos\ObsControl\ObservatoryControl\bin\Debug\config" (ну или Release\config)
        // 3. И еще есть дефолтный конфиг, который имеет расширение txt так как только такие файлы ClickOnce может добавлять в инсталяцию
        // Поэтому нужно помнить, что их ТРИ и синхронизировать правки (просто копируя их)
        //
        // UPDATE. Начиная с версии 0.7.2 поменялось:
        // 1. Дефольный конфиг под именем ObservatoryControl.defaultconfig.txt" при разработке храниться в паке с исходным кодом (чтобы он синхронизировался через GITHUB он должен лежать там, где хранится весь SourceCode) ("c:\Users\Emchenko Boris\Source\Repos\ObsControl\ObservatoryControl\ObservatoryControl.defaultconfig.txt")
        // 2. При компиляции он копируется в \Source\Repos\ObsControl\ObservatoryControl\bin\Debug\ 
        // 3. A рабочий лежит в \Documents\ObservatoryControl\Config\ObservatoryControl.config 
        // Обновлять лучше так: редактируем дефолтный (txt) в папке с SourceCode (ПОМНИ НЕ .../DEBUG!!!), при компиляции он скопируется сам, а рабочий просто удаляем (при запуске перепишется). Ну или рабочий копировать в текстовый, но опять же - в папку с SourceCode.

        public static string CONFIG_FILENAME = "ImageQualityPublisher.config";
        public static string CONFIG_PATH = Path.Combine(ProgDocumentsFullPath, "Config") + "\\";
        public static string DEFAULT_CONFIG_FILENAME = "ImageQualityPublisher.defaultconfig.txt"; //Default config file

        /// <summary>
        /// Load configuration XML file
        /// </summary>
        /// <returns>true if loaded, false if error</returns>
        public static bool Load()
        {
            bool res = false;
            try
            {
                configXML.Load(Path.Combine(CONFIG_PATH, CONFIG_FILENAME));
                Logging.AddLog("Configuration file [" + CONFIG_PATH + CONFIG_FILENAME + "] loaded", LogLevel.Activity);
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
                        configXML.Load(Path.Combine(CONFIG_PATH, CONFIG_FILENAME));
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
                configXML.Save(CONFIG_PATH + CONFIG_FILENAME);
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

        // GET VALUES ///////////////////////////////////////////////////

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

        // SECTION CONTENTS ///////////////////////////////////////////////////

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
                        if (curValue != "")
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


        /// <summary>
        /// Copy default config to CONFIG dir
        /// </summary>
        private static void CopyDefaultConfig()
        {
            if (!File.Exists(Path.Combine(CONFIG_PATH, CONFIG_FILENAME)))
            {
                if (!Directory.Exists(CONFIG_PATH))
                {
                    Logging.AddLog("Config folder [" + CONFIG_PATH + "] not found. Recreating structure", LogLevel.Important, Highlight.Emphasize);
                    //Create dir structure if needed
                    CreateDocumentsDirStructure();
                }

                //Copy default config
                try
                {
                    File.Copy(Path.Combine(Environment.CurrentDirectory, DEFAULT_CONFIG_FILENAME), Path.Combine(CONFIG_PATH, CONFIG_FILENAME));
                    Logging.AddLog("Default config was copied", LogLevel.Important, Highlight.Emphasize);
                }
                catch (Exception ex)
                {
                    Logging.AddLog("Default config copying error: " + ex.Message, LogLevel.Important, Highlight.Error);
                    Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Debug);
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
                if (!Directory.Exists(ProgDocumentsFullPath))
                {
                    Directory.CreateDirectory(ProgDocumentsFullPath);
                    Logging.AddLog("Root directory [" + ProgDocumentsFullPath + "] created", LogLevel.Important, Highlight.Emphasize);
                    wasCreated = true;
                }

                //Is - Documents/ObservatoryControl/Config
                if (!Directory.Exists(CONFIG_PATH))
                {
                    Directory.CreateDirectory(CONFIG_PATH);
                    Logging.AddLog("Config directory [" + CONFIG_PATH + "] created", LogLevel.Important, Highlight.Emphasize);
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



        private static XmlDocument __loadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(CONFIG_PATH + CONFIG_FILENAME);
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
            catch (Exception ex)
            {

                return null;
            }
        }


    }





}
