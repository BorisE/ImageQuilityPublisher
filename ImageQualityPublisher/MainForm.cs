﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ImageQualityPublisher
{
    public partial class MainForm : Form
    {
        public FileMonitoring MonitorObj;
        public FileProcessing ProcessingObj;

        public WebPublish WebPublishObj;    //for public
        public WebPublish WebPublishObj2;   //for private


        /// <summary>
        /// Link to NON LOCALISED resource manager
        /// </summary>
        ResourceManager LocRM;
        ResourceManager LocWinFormRM;
        public string currentLang = "";
        internal string currentLangDefault = "ru-RU";

        //Settings
        public bool settingsAutoStartMonitoring = false;
        public List<string> FileMonitorPath = new List<string>();

        //Statistics
        private uint statImagesProcessed = 0;
        private uint statImagesFound = 0;
        private uint statImagesWaiting = 0;

        Color OnColor = Color.DarkSeaGreen;
        Color DefBackColor;

        public MainForm()
        {
            ProcessingObj = new FileProcessing(this);
            MonitorObj = new FileMonitoring(this);
            WebPublishObj = new WebPublish();
            WebPublishObj2 = new WebPublish();

            //Load config file
            ConfigManagement.Load();
            //Change parameters according to configuration
            LoadParamsFromConfigFiles();

            //Load language on form creation //need to be before formload-fix
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(currentLang);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(currentLang);
            LocRM = new ResourceManager("ImageQualityPublisher.WinStrings", Assembly.GetExecutingAssembly()); //create resource manager
            LocWinFormRM = new ResourceManager("ImageQualityPublisher.MainForm", Assembly.GetExecutingAssembly()); //create resource manager

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DefBackColor = btnStart.BackColor;

            //Update interface for current Settings values (after they was loaded in constructor)
            UpdateSettingsDialogFields();

            //Dump log, because interface may hang wating for connection
            Logging.DumpToFile();

            //Init versiondata static class
            //Display about information
            VersionData.initVersionData();
            LoadAboutData();

            //Run all timers at the end
            logRefreshTimer.Enabled = true;

            //Autostart
            if (settingsAutoStartMonitoring)
            {
                btnStart_Click(btnStart, new EventArgs());
            }
        }



        /// <summary>
        /// Method which ivoked by from other class to add to grid
        /// </summary>
        /// <param name="FileResObj"></param>
        public void PublishFITSData(FileParseResult FileResObj)
        {
            //Grid block
            int curRowIndex = dataGridFileData.Rows.Add();
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_filename"].Value = Path.GetFileName(FileResObj.FITSFileName);
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_Bg"].Value = FileResObj.QualityData.SkyBackground.ToString("P", CultureInfo.InvariantCulture); 
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_MeanRadius"].Value = FileResObj.QualityData.MeanRadius.ToString("N2", CultureInfo.InvariantCulture);
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_Stars"].Value = FileResObj.QualityData.StarsNumber.ToString("N0", CultureInfo.InvariantCulture);

            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_Alt"].Value = FileResObj.HeaderData.ObjAlt.ToString("N0", CultureInfo.InvariantCulture);
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_Exp"].Value = FileResObj.HeaderData.ImageExposure.ToString("N0", CultureInfo.InvariantCulture);
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_DateTime"].Value = FileResObj.HeaderData.DateObsUTC.ToString();
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_FWHM"].Value = FileResObj.FWHM.ToString("N2", CultureInfo.InvariantCulture);

            statImagesProcessed++;

            UpdateStatistics(); // on every invoke
        }

        public void ClearFITSData()
        {
            //Clear queque
            ProcessingObj.Clear();
            
            //clear Grid block
            dataGridFileData.Rows.Clear();

            //update statistics
            statImagesFound = 0;
            statImagesProcessed = 0;
            statImagesWaiting = 0;
            UpdateStatistics();
        }

        /// <summary>
        /// Log refresh cycle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logRefreshTimer_Tick(object sender, EventArgs e)
        {
            //Get current loglevel value
            LogLevel CurLogLevel = LogLevel.Activity;
            if (!Enum.TryParse(toolStripDropDownLogLevel.Text, out CurLogLevel))
            {
                CurLogLevel = LogLevel.Activity;
            }

            //add line to richtextbox
            Logging.DisplayLogInTextBox(txtLog, CurLogLevel);

            toolStripLogSize.Text = "LogRec: " + Logging.LOGLIST.Count();

            //write to file
            Logging.DumpToFile();

        }

        private bool AlreadyRunning = false;

        private void monitorTmer_Tick(object sender, EventArgs e)
        {
            //Update statistics
            UpdateStatistics();

            //Give time quants to objects
            if (!AlreadyRunning)
            {
                AlreadyRunning = true;

                //1. Give some time to MonitorObj
                List<string> dirList = cmbMonitorPath.Items.Cast<String>().ToList();
                MonitorObj.CheckForNewFiles_async(dirList);

                //2. Give some time to FileQueQue processing
                ProcessingObj.ProcessAll();

                AlreadyRunning = false;
            }
        }


        private void UpdateStatistics()
        {
            //calc
            statImagesWaiting = ProcessingObj.QuequeLen(); 
            statImagesFound = statImagesProcessed + statImagesWaiting; //пока так

            //status 
            toolStripStatus_FilesFound.Text = LocRM.GetString("statusbar_images") + ": " + statImagesFound;
            toolStripStatus_FilesProcessed.Text = LocRM.GetString("statusbar_imagesprocessed") + ": " + statImagesProcessed;
            toolStripStatus_FilesWaiting.Text = LocRM.GetString("statusbar_imageswaiting") + ": " + statImagesWaiting;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (monitorTimer.Enabled)
            // if runnig - stop
            {
                //stop timer
                monitorTimer.Enabled = false;
                //end monitor thread
                MonitorObj.AbortThread();
                
                btnStart.Text = LocWinFormRM.GetString("btnStart.Text");
                btnStart.BackColor = DefBackColor;
            }
            else
            {
                monitorTimer.Enabled = true;
                btnStart.Text = LocRM.GetString("btnStart_StopText");
                btnStart.BackColor = OnColor;
            }
        }
        

        /// <summary>
        /// Add new dir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = false;
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;

            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                //add to combobox
                cmbMonitorPath.Items.Add(folderBrowserDialog1.SelectedPath);
                cmbMonitorPath.SelectedItem = folderBrowserDialog1.SelectedPath;

                //update lists
                UpdateDirList();

                //MonitorObj.ClearFileList(); //очисить список
                Logging.AddLog(LocRM.GetString("Log_startmonitoring") +" ["+ folderBrowserDialog1.SelectedPath + "]", LogLevel.Activity, Highlight.Emphasize);
            }

        }

        /// <summary>
        /// Delete current dir from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelFolder_Click(object sender, EventArgs e)
        {
            //remove from combobox
            cmbMonitorPath.Items.RemoveAt(cmbMonitorPath.SelectedIndex);
            if (cmbMonitorPath.Items.Count > 0)
                cmbMonitorPath.SelectedIndex = 0;

            //update lists
            UpdateDirList();
        }


        /// <summary>
        /// Updates all dir lists from combobox list
        /// Из элемента формы обновляются данные в XML и в переменных
        /// </summary>
        private void UpdateDirList()
        {
            //1. Empty current lists
            //Monitoring list
            FileMonitorPath.Clear();
            //Config
            ConfigManagement.ClearSection("monitorPath"); //clear entire section

            //2. Make new lists
            for (int i = 0; i < cmbMonitorPath.Items.Count; i++)
            {
                string curDir = cmbMonitorPath.GetItemText(cmbMonitorPath.Items[i]);

                //Add to monitor list
                FileMonitorPath.Add(curDir);
                //Add to config list
                ConfigManagement.UpdateConfigValue("monitorPath", "Dir" + (i + 1), curDir);
            }
            
            //3. Save config
            ConfigManagement.Save();

            //4. Обновить инфо о количестве подакаталог
            lblDirsMonitoring.Text = cmbMonitorPath.Items.Count.ToString();
        }

        private void chkSearchSubdirs_CheckedChanged(object sender, EventArgs e)
        {
            MonitorObj.settingsScanSubdirs = chkSearchSubdirs.Checked;
        }

        private void btnRecheck_Click(object sender, EventArgs e)
        {
            Logging.AddLog("Resetting data and rereading it from scratch", LogLevel.Activity, Highlight.Emphasize);
            MonitorObj.ClearFileList();
            ClearFITSData();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            List<string> DirList = new List<string>();

            DirList.Add(@"D:\2");
            DirList.Add(@"D:\2\2");

            MonitorObj.CheckForNewFiles(DirList);

        }

        /**************************************************************************************************/
        #region //// Settings //////////////////////////////////////
        // Как устроена загрузка:
        //  1. [LoadParamsFromConfigFiles] загружает из XML в переменные
        //  2. [UpdateSettingsDialogFields] из переменных обновляет элементы формы
        // Как устроено сохранение:
        //  1. [btnSettings_Save_Click] сохраняет из элементов форм в XML
        //  2. [LoadParamsFromConfigFiles] загружает из XML в переменные

        private void LoadParamsFromConfigFiles()
        {
            List<string> dirNodesList = ConfigManagement.getAllSectionNamesList("monitorPath");
            foreach (string curDirNode in dirNodesList)
            {
                FileMonitorPath.Add(ConfigManagement.getString("monitorPath", curDirNode));
            }

            settingsAutoStartMonitoring = ConfigManagement.getBool("options", "AUTOSTARTMONITORING") ?? false;
            ProcessingObj.settingsDSSCLPath = ConfigManagement.getString("options", "DSS_PATH") ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),@"\DeepSkyStacker\DeepSkyStackerCL.exe");

            ProcessingObj.settingsPublishToGroup = ConfigManagement.getBool("options", "PUBLISHTOGROUP") ?? true;
            WebPublishObj.SetURL(ConfigManagement.getString("publishURL", "url1") ?? "http://localhost");

            ProcessingObj.settingsPublishToPrivate = ConfigManagement.getBool("options", "PUBLISHTOPRIVATE") ?? true;
            WebPublishObj2.SetURL(ConfigManagement.getString("publishURL", "url2") ?? "http://localhost");

            currentLang = ConfigManagement.getString("options", "Language") ?? currentLangDefault;

            Logging.AddLog("Program parameters were set according to configuration file", LogLevel.Activity);
        }
  
        /// <summary>
        /// Update form fields from actual settings
        /// </summary>
        private void UpdateSettingsDialogFields()
        {
            //Init Log DropDown box (в statusbar)
            foreach (LogLevel C in Enum.GetValues(typeof(LogLevel)))
            {
                toolStripDropDownLogLevel.DropDownItems.Add(Enum.GetName(typeof(LogLevel), C));
            }
            toolStripDropDownLogLevel.Text = Enum.GetName(typeof(LogLevel), LogLevel.Activity);

            //Технически - добавить ссылку для LinkLabel
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "http://deepskystacker.free.fr/english/download.htm";
            linkDSS.Links.Add(link);

            //Init Language ComboBox list
            cmbLang.DataSource = new CultureInfo[]{
                CultureInfo.GetCultureInfo("en-US"),
                CultureInfo.GetCultureInfo("ru-RU")
            };
            cmbLang.DisplayMember = "NativeName";
            cmbLang.ValueMember = "Name";
            cmbLang.SelectedValue = currentLang;


            //Установить значения из ранее загруженных данных в диалоге настройка
            cmbMonitorPath.Items.Clear();
            foreach (string curDir in FileMonitorPath)
            {
                cmbMonitorPath.Items.Add(curDir);
            }
            cmbMonitorPath.SelectedIndex = 0;
            lblDirsMonitoring.Text = cmbMonitorPath.Items.Count.ToString();

            chkSettings_Autostart.Checked = settingsAutoStartMonitoring;
            txtSettings_DSS.Text = ProcessingObj.settingsDSSCLPath;

            chkSettings_publishgroup.Checked = ProcessingObj.settingsPublishToGroup;
            txtSettings_urlgorup.Text = WebPublishObj.PublishURL;

            chkSettings_publishprivate.Checked = ProcessingObj.settingsPublishToPrivate;
            txtSettings_urlprivate.Text = WebPublishObj2.PublishURL;

        }

        /// <summary>
        /// Save current settings. And reload them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettings_Save_Click(object sender, EventArgs e)
        {
            //1. Update ConfigXML

            //Save dirlist
            ConfigManagement.ClearSection("monitorPath"); //clear entire section
            for (int i = 0; i < cmbMonitorPath.Items.Count; i++)
            {
                string curDir = cmbMonitorPath.GetItemText(cmbMonitorPath.Items[i]);
                ConfigManagement.UpdateConfigValue("monitorPath", "Dir"+(i+1), curDir);
            }

            ConfigManagement.UpdateConfigValue("options", "Language", cmbLang.SelectedValue.ToString());

            ConfigManagement.UpdateConfigValue("options", "AUTOSTARTMONITORING", chkSettings_Autostart.Checked.ToString());
            ConfigManagement.UpdateConfigValue("options", "DSS_PATH", txtSettings_DSS.Text);

            ConfigManagement.UpdateConfigValue("options", "PUBLISHTOGROUP", chkSettings_publishgroup.Checked.ToString());
            ConfigManagement.UpdateConfigValue("publishURL", "url1", txtSettings_urlgorup.Text);

            ConfigManagement.UpdateConfigValue("options", "PUBLISHTOPRIVATE", chkSettings_publishprivate.Checked.ToString());
            ConfigManagement.UpdateConfigValue("publishURL", "url2", txtSettings_urlprivate.Text);


            //2. Save ConfigXML to disk
            ConfigManagement.Save();

            //3. Load config from disk
            ConfigManagement.Load();
            LoadParamsFromConfigFiles();
        }


        private void btnLoadDSSPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "DeepSkyStacker");
            openFileDialog1.FileName = "DeepSkyStackerCL";
            openFileDialog1.Filter = "DeepSkyStackerCL.exe|DeepSkyStackerCL.exe|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSettings_DSS.Text = openFileDialog1.FileName;
            }

        }

        #endregion end of =Settings=
        /**************************************************************************************************/


        #region //// About information //////////////////////////////////////
        private void LoadAboutData()
        {
            lblVersion.Text += "Publish version: " + VersionData.PublishVersionSt;
            lblVersion.Text += Environment.NewLine + "Assembly version: " + VersionData.AssemblyVersionSt;
            lblVersion.Text += Environment.NewLine + "File version: " + VersionData.FileVersionSt;
            //lblVersion.Text += Environment.NewLine + "Product version " + ProductVersionSt;

            //MessageBox.Show("Application " + assemName.Name + ", Version " + ver.ToString());
            lblVersion.Text += Environment.NewLine + "Compile time: " + VersionData.CompileTime.ToString("yyyy-MM-dd HH:mm:ss");

            // Add link
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "http://www.astromania.info/";
            linkAstromania.Links.Add(link);

            LinkLabel.Link link2 = new LinkLabel.Link();
            link2.LinkData = "http://astrohostel.ru/";
            linkAstrohostel.Links.Add(link2);

            LinkLabel.Link link3 = new LinkLabel.Link();
            link3.LinkData = "http://astro.milantiev.com/";
            linkMilantiev.Links.Add(link3);
        }

        private void linkAny_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }


        #endregion About information

    }
}