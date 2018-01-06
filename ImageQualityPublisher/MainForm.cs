using System;
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
        public MonitorClass MonitorObj;
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
        public string settingsDSSCLPath = @"c:\Program Files (x86)\DeepSkyStacker\DeepSkyStackerCL.exe";

        private uint ImagesCount = 0;

        Color OnColor = Color.DarkSeaGreen;
        Color DefBackColor;

        public MainForm()
        {
            MonitorObj = new MonitorClass(this);
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
            DefBackColor = btnExit.BackColor;

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
            //Last image block
            txtLastFileName.Text = FileResObj.FITSFileName;

            txtBgLevel.Text = FileResObj.QualityData.SkyBackground.ToString("P", CultureInfo.InvariantCulture);
            txtMeanRadius.Text = FileResObj.QualityData.MeanRadius.ToString("N2", CultureInfo.InvariantCulture);
            txtStarsNum.Text = FileResObj.QualityData.StarsNumber.ToString("N0", CultureInfo.InvariantCulture);

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

            ImagesCount++;

            toolStripStatus_Images.Text = LocRM.GetString("statusbar_images") + ": " + ImagesCount;
        }

        public void ClearFITSData()
        {
            //Last image block
            txtLastFileName.Text = "";

            txtBgLevel.Text = "";
            txtMeanRadius.Text = "";
            txtStarsNum.Text = "";

            //clear Grid block
            dataGridFileData.Rows.Clear();

            //update status bar
            ImagesCount = 0;
            toolStripStatus_Images.Text = LocRM.GetString("statusbar_images") + ": " + ImagesCount;
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
            if (!AlreadyRunning)
            {
                AlreadyRunning = true;

                MonitorObj.CheckForNewFiles();

                AlreadyRunning = false;
            }
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (monitorTimer.Enabled)
            // if runnig - stop
            {
                monitorTimer.Enabled = false;
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


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = false;
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;

            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtMonitorPath.Text = folderBrowserDialog1.SelectedPath;
                MonitorObj.FileMonitorPath = txtMonitorPath.Text;
                MonitorObj.ClearFileList(); //очисить список
                Logging.AddLog(LocRM.GetString("Log_startmonitoring") +" ["+ txtMonitorPath.Text + "]", LogLevel.Activity, Highlight.Emphasize);
            }

        }

        private void btnRecheck_Click(object sender, EventArgs e)
        {
            Logging.AddLog("Resetting data and rereading it from scratch", LogLevel.Activity, Highlight.Emphasize);
            MonitorObj.ClearFileList();
            ClearFITSData();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            FileParseResult FileResObj = new FileParseResult();
            FileResObj = MonitorObj.RunQualityEstimation(@"d:\2\NGC247_20171212_L_600s_1x1_-30degC_0.0degN_000005308.FIT");

            WebPublishObj.PublishData(FileResObj);

        }

        /**************************************************************************************************/
        #region //// Settings //////////////////////////////////////

        private void LoadParamsFromConfigFiles()
        {
            MonitorObj.FileMonitorPath = ConfigManagement.getString("monitorPath","Dir1") ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            settingsAutoStartMonitoring = ConfigManagement.getBool("options", "AUTOSTARTMONITORING") ?? false;
            settingsDSSCLPath = ConfigManagement.getString("options", "DSS_PATH") ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),@"\DeepSkyStacker\DeepSkyStackerCL.exe");

            MonitorObj.settingsPublishToGroup = ConfigManagement.getBool("options", "PUBLISHTOGROUP") ?? true;
            WebPublishObj.SetURL(ConfigManagement.getString("publishURL", "url1") ?? "http://localhost");

            MonitorObj.settingsPublishToPrivate = ConfigManagement.getBool("options", "PUBLISHTOPRIVATE") ?? true;
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
            txtMonitorPath.Text = MonitorObj.FileMonitorPath;

            chkSettings_Autostart.Checked = settingsAutoStartMonitoring;
            txtSettings_DSS.Text = settingsDSSCLPath;

            chkSettings_publishgroup.Checked = MonitorObj.settingsPublishToGroup;
            txtSettings_urlgorup.Text = WebPublishObj.PublishURL;

            chkSettings_publishprivate.Checked = MonitorObj.settingsPublishToPrivate;
            txtSettings_urlprivate.Text = WebPublishObj2.PublishURL;

        }

        /// <summary>
        /// Save current settings. And reload them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettings_Save_Click(object sender, EventArgs e)
        {
            //Update ConfigXML
            ConfigManagement.UpdateConfigValue("monitorPath", "Dir1", txtMonitorPath.Text);

            ConfigManagement.UpdateConfigValue("options", "Language", cmbLang.SelectedValue.ToString());

            ConfigManagement.UpdateConfigValue("options", "AUTOSTARTMONITORING", chkSettings_Autostart.Checked.ToString());
            ConfigManagement.UpdateConfigValue("options", "DSS_PATH", txtSettings_DSS.Text);

            ConfigManagement.UpdateConfigValue("options", "PUBLISHTOGROUP", chkSettings_publishgroup.Checked.ToString());
            ConfigManagement.UpdateConfigValue("publishURL", "url1", txtSettings_urlgorup.Text);

            ConfigManagement.UpdateConfigValue("options", "PUBLISHTOPRIVATE", chkSettings_publishprivate.Checked.ToString());
            ConfigManagement.UpdateConfigValue("publishURL", "url2", txtSettings_urlprivate.Text);


            //Save ConfigXML to disk
            ConfigManagement.Save();

            //Load config from disk
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
