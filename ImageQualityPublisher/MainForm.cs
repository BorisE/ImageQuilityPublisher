using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageQualityPublisher
{
    public partial class MainForm : Form
    {
        public MonitorClass MonitorObj;
        public WebPublish WebPublishObj;

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
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DefBackColor = btnExit.BackColor;

            //Load config file
            ConfigManagement.Load();
            //Change parameters according to configuration
            LoadParamsFromConfigFiles();
            //Update interface Settings
            UpdateSettingsDialogFields();


            //Dump log, because interface may hang wating for connection
            Logging.DumpToFile();


            //Init Log DropDown box
            foreach (LogLevel C in Enum.GetValues(typeof(LogLevel)))
            {
                toolStripDropDownLogLevel.DropDownItems.Add(Enum.GetName(typeof(LogLevel), C));
            }
            toolStripDropDownLogLevel.Text = Enum.GetName(typeof(LogLevel), LogLevel.Activity);

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


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (monitorTimer.Enabled)
            // if runnig - stop
            {
                monitorTimer.Enabled = false;
                btnStart.Text = "Start";
                btnStart.BackColor = DefBackColor;
            }
            else
            {
                monitorTimer.Enabled = true;
                btnStart.Text = "Stop";
                btnStart.BackColor = OnColor;
            }

            //Monitor.CheckForNewFiles();

            /*
            string FileName = @"d:\2\NGC247_20171021_R_600s_1x1_-25degC_0.0degN_000004463_c_cc_r_a.fit";
            txtLastFileName.Text = FileName;

            DSSObj.EvaluateFile(FileName);

            DSSObj.GetEvaluationResults();

            txtBgLevel.Text = DSSObj.QualityEstimate.SkyBackground.ToString();
            txtMeanRadius.Text = DSSObj.QualityEstimate.MeanRadius.ToString();
            txtStarsNum.Text= DSSObj.QualityEstimate.StarsNumber.ToString();
            txtSumMeas.Text = DSSObj.QualityEstimate.MeanRadiusSum.ToString();
            txtNumMeasur.Text = DSSObj.QualityEstimate.MeanRadiusNum.ToString();
            */
        }


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

            toolStripStatus_Images.Text = "Images: " + ImagesCount;


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
            }

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
            if (! AlreadyRunning)
            {
                AlreadyRunning = true;

                MonitorObj.CheckForNewFiles();
                
                AlreadyRunning = false;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            FileParseResult FileResObj = new FileParseResult();
            FileResObj = MonitorObj.RunQualityEstimation(@"d:\2\NGC247_20171212_L_600s_1x1_-30degC_0.0degN_000005308.FIT");

            WebPublishObj.PublishData(FileResObj);

        }

        #region //// Settings //////////////////////////////////////
        private void LoadParamsFromConfigFiles()
        {
            MonitorObj.FileMonitorPath = ConfigManagement.getString("monitorPath","Dir1") ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            settingsAutoStartMonitoring = ConfigManagement.getBool("options", "AUTOSTARTMONITORING") ?? false;
            settingsDSSCLPath = ConfigManagement.getString("options", "DSS_PATH") ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),@"\DeepSkyStacker\DeepSkyStackerCL.exe");

            MonitorObj.settingsPublishToGroup = ConfigManagement.getBool("options", "PUBLISHTOGROUP") ?? true;
            WebPublishObj.SetURL(ConfigManagement.getString("publishURL", "url1") ?? "http://localhost");

            Logging.AddLog("Program parameters were set according to configuration file", LogLevel.Activity);
        }

        private void UpdateSettingsDialogFields()
        {
            //Технически - добавить ссылку для LinkLabel
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "http://deepskystacker.free.fr/english/download.htm";
            linkDSS.Links.Add(link);

            txtMonitorPath.Text = MonitorObj.FileMonitorPath;

            chkSettings_Autostart.Checked = settingsAutoStartMonitoring;
            txtSettings_DSS.Text = settingsDSSCLPath;

            chkSettings_publishgroup.Checked = MonitorObj.settingsPublishToGroup;
            txtSettings_urlgorup.Text = WebPublishObj.PublishURL;
        }

        private void btnSettings_Save_Click(object sender, EventArgs e)
        {
            //Update ConfigXML
            ConfigManagement.UpdateConfigValue("monitorPath", "Dir1", txtMonitorPath.Text);
            ConfigManagement.UpdateConfigValue("options", "AUTOSTARTMONITORING", chkSettings_Autostart.Checked.ToString());
            ConfigManagement.UpdateConfigValue("options", "DSS_PATH", txtSettings_DSS.Text);
            ConfigManagement.UpdateConfigValue("options", "PUBLISHTOGROUP", chkSettings_publishgroup.Checked.ToString());
            ConfigManagement.UpdateConfigValue("publishURL", "url1", txtSettings_urlgorup.Text);
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


        #endregion Settings



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
