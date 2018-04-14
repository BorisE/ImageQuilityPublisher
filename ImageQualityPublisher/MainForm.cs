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
using IQPEngineLib;
using LoggingLib;

namespace ImageQualityPublisher
{
    public partial class MainForm : Form
    {
        public IQPEngineLib.IQPEngine EngineObj;

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

        //Color constants
        Color OnColor = Color.DarkSeaGreen;
        Color DefBackColor;

        private bool AlreadyRunning = false; //flag to block concurent timer run

        //Filters
        private FiltersForm FiltersFormObj;
        bool bFiltersEnabled = false;


        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            //Name settings
            string ProgDocumentFullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AstrohostelTools");
            ConfigManagement.InitConfig(ProgDocumentFullPath, "ImageQualityPublisher.config", "ImageQualityPublisher.defaultconfig.txt"); 
            Logging.InitLogging(ProgDocumentFullPath, "imagepublisher_", false); //set log folder and log file name
            Logging.AddLog("Program has been started");
           

            EngineObj = new IQPEngineLib.IQPEngine(new IQPEngineLib.IQPEngine.CallBackFunction(PublishFITSData));
            //this.Invoke(new Action(() => this.PublishFITSData(FileResObj)));
            
            FiltersFormObj = new FiltersForm(this);

            //Load config file
            ConfigManagement.Load();
            //Change parameters according to configuration
            LoadParamsFromConfigFile();

            //Load language on form creation //need to be before formload-fix
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(currentLang);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(currentLang);
            LocRM = new ResourceManager("ImageQualityPublisher.WinStrings", Assembly.GetExecutingAssembly()); //create resource manager
            LocWinFormRM = new ResourceManager("ImageQualityPublisher.MainForm", Assembly.GetExecutingAssembly()); //create resource manager

            InitializeComponent();
        }

        /// <summary>
        /// Load event. Ininitalize some actions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            toolStripLogSize.Text = "LogRec: " + Logging.GetCount();

            //write to file
            Logging.DumpToFile();

        }
        
        
        /******************************************************************************************************************/
        /// <summary>
        /// MAIN TIMER CYCLE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monitorTimer_Tick(object sender, EventArgs e)
        {
            //Update statistics
            UpdateStatistics();

            //Give time quants to objects
            if (!AlreadyRunning)
            {
                AlreadyRunning = true;

                //1. Give some time to MonitorObj
                List<string> dirList = cmbMonitorPath.Items.Cast<String>().ToList();
                EngineObj.MonitorObj.CheckForNewFiles_async(dirList);

                //2. Give some time to FileQueQue processing
                EngineObj.ProcessingObj.ProcessAll_async();

                AlreadyRunning = false;
            }
        }
        /******************************************************************************************************************/

        /// <summary>
        /// Method which ivoked from other class to add to grid
        /// </summary>
        /// <param name="FileResObj"></param>
        public void PublishFITSData(FileParseResult FileResObj)
        {
            this.Invoke(new Action(() => this.PublishFITSDataInvoke(FileResObj)));
        }

        private void PublishFITSDataInvoke(FileParseResult FileResObj)
        {
            //Grid block
            int curRowIndex = dataGridFileData.Rows.Add();
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_filename"].Value = Path.GetFileName(FileResObj.FITSFileName);
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_Bg"].Value = FileResObj.QualityData.SkyBackground.ToString("P", CultureInfo.InvariantCulture);
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_AspectRatio"].Value = FileResObj.QualityData.AspectRatio.ToString("N3", CultureInfo.InvariantCulture);
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_Stars"].Value = FileResObj.QualityData.StarsNumber.ToString("N0", CultureInfo.InvariantCulture);

            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_Alt"].Value = FileResObj.HeaderData.ObjAlt.ToString("N0", CultureInfo.InvariantCulture);
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_Exp"].Value = FileResObj.HeaderData.ImageExposure.ToString("N0", CultureInfo.InvariantCulture);

            DateTime DateObsUTC = DateTime.SpecifyKind(FileResObj.HeaderData.DateObsUTC, DateTimeKind.Utc); //set it to UTC
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_DateTime"].Value = DateObsUTC.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");

            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_FWHM"].Value = FileResObj.FWHM.ToString("N2", CultureInfo.InvariantCulture);

            statImagesProcessed++;

            UpdateStatistics(); // on every invoke
        }

        /// <summary>
        /// Reset all data (on pressing button)
        /// </summary>
        public void ResetData()
        {
            //Stop current processing activity
            EngineObj.MonitorObj.AbortThread();
            //reset already monitored filelist
            EngineObj.MonitorObj.ClearFileList();
            //Clear queque
            EngineObj.ProcessingObj.Clear();

            //Clear IMS data
            EngineObj.MonitorObj.ClearDirIMSData();

            //clear Grid block
            dataGridFileData.Rows.Clear();

            //update statistics
            statImagesFound = 0;
            statImagesProcessed = 0;
            statImagesWaiting = 0;
            UpdateStatistics();
        }
        private void UpdateStatistics()
        {
            //calc
            statImagesWaiting = EngineObj.ProcessingObj.QuequeLen(); 
            statImagesFound = statImagesProcessed + statImagesWaiting; //пока так

            //status 
            toolStripStatus_FilesFound.Text = LocRM.GetString("statusbar_images") + ": " + statImagesFound;
            toolStripStatus_FilesProcessed.Text = LocRM.GetString("statusbar_imagesprocessed") + ": " + statImagesProcessed;
            toolStripStatus_FilesWaiting.Text = LocRM.GetString("statusbar_imageswaiting") + ": " + statImagesWaiting;
        }


        /**************************************************************************************************/
        #region Events Handlers
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (monitorTimer.Enabled)
            // if runnig - stop
            {
                //stop timer
                monitorTimer.Enabled = false;
                //end monitor thread
                EngineObj.MonitorObj.AbortThread();
                
                btnStart.Text = LocWinFormRM.GetString("btnStart.Text");
                btnStart.BackColor = DefBackColor;
                Logging.AddLog("Montoring has been stoped", LogLevel.Activity);
            }
            else
            {
                monitorTimer.Enabled = true;
                btnStart.Text = LocRM.GetString("btnStart_StopText");
                btnStart.BackColor = OnColor;
                Logging.AddLog("Starting monitoring...",LogLevel.Activity);
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
                SaveDirList();

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
            SaveDirList();
        }


        private void chkSearchSubdirs_CheckedChanged(object sender, EventArgs e)
        {
            EngineObj.MonitorObj.settingsScanSubdirs = chkSearchSubdirs.Checked;
        }

        private void btnRecheck_Click(object sender, EventArgs e)
        {
            Logging.AddLog("Resetting data and rereading it from scratch", LogLevel.Activity, Highlight.Emphasize);
            ResetData();
        }

        /// <summary>
        /// Save settings on exit
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Stop current processing activity
            EngineObj.MonitorObj.AbortThread();
            //Save settings
            SaveSettingsToConfigFile();
            Logging.AddLog("Program exit");
            Logging.DumpToFile();
        }

        private void toolStripDropDownLogLevel_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Clear")
            {
                txtLog.Clear();
            }
            else
            {
                toolStripDropDownLogLevel.Text = e.ClickedItem.Text;
                for (int i = 0; i < toolStripDropDownLogLevel.DropDownItems.Count; i++)
                { 
                    if (toolStripDropDownLogLevel.DropDownItems[i].Text == e.ClickedItem.Text)
                        toolStripDropDownLogLevel.DropDownItems[i].BackColor = OnColor; //not working
                }
            }
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            List<string> DirList = new List<string>();

            DirList.Add(@"D:\2");
            DirList.Add(@"D:\2\2");

            EngineObj.MonitorObj.CheckForNewFiles(DirList);

        }

        private void cmbLang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MessageBox.Show(LocRM.GetString("ChangeLanguage_text"), LocRM.GetString("ChangeLanguage_caption"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion Events hadler
        /**************************************************************************************************/

        /**************************************************************************************************/
        #region //// Settings //////////////////////////////////////
        // Как устроена загрузка:
        //  1. [LoadParamsFromConfigFile] загружает из XML в переменные
        //  2. [UpdateSettingsDialogFields] из переменных обновляет элементы формы
        // Как устроено сохранение:
        //  1. [SaveSettingsToConfigFile] сохраняет из элементов форм в XML
        //  2. [LoadParamsFromConfigFile] загружает из XML в переменные

        private void LoadParamsFromConfigFile()
        {
            try
            {
                List<string> dirNodesList = ConfigManagement.getAllSectionNamesList("monitorPath");
                foreach (string curDirNode in dirNodesList)
                {
                    FileMonitorPath.Add(ConfigManagement.getString("monitorPath", curDirNode));
                }

                EngineObj.MonitorObj.settingsScanSubdirs = ConfigManagement.getBool("options", "ScanSubDirs") ?? false;
                settingsAutoStartMonitoring = ConfigManagement.getBool("options", "AUTOSTARTMONITORING") ?? false;
                EngineObj.ProcessingObj.settingsDSSCLPath = ConfigManagement.getString("options", "DSS_PATH") ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"\DeepSkyStacker\DeepSkyStackerCL.exe");
                currentLang = ConfigManagement.getString("options", "Language") ?? currentLangDefault;

                EngineObj.ProcessingObj.settingsPublishToGroup = ConfigManagement.getBool("options", "PUBLISHTOGROUP") ?? true;
                EngineObj.WebPublishObj.SetURL(ConfigManagement.getString("publishURL", "url1") ?? "http://localhost");
                EngineObj.WebPublishObj.ServerKey = ConfigManagement.getString("publishURL", "key1") ?? "";

                EngineObj.ProcessingObj.settingsPublishToPrivate = ConfigManagement.getBool("options", "PUBLISHTOPRIVATE") ?? true;
                EngineObj.WebPublishObj2.SetURL(ConfigManagement.getString("publishURL", "url2") ?? "http://localhost");
                EngineObj.WebPublishObj2.ServerKey = ConfigManagement.getString("publishURL", "key2") ?? "";

                //hidden settings
                EngineObj.MonitorObj.settingsExtensionToSearch = ConfigManagement.getString("options", "extensionsToSearch") ?? "*.fit*";
                EngineObj.ProcessingObj.settingsMaxThreads = (uint)(ConfigManagement.getInt("options", "checkThreads_max") ?? 1);
                EngineObj.ProcessingObj.settingsSkipIMSfiles = ConfigManagement.getBool("options", "checkDirIMS") ?? true;
                EngineObj.ProcessingObj.settingsDSSForceRecheck = ConfigManagement.getBool("options", "alwaysRebuildDSSInfoFile") ?? false;
                EngineObj.ProcessingObj.settingsDSSForceRunHidden = ConfigManagement.getBool("options", "RunDSSHidden") ?? false;
                EngineObj.ProcessingObj.settingsPublishLightFramesOnly = ConfigManagement.getBool("options", "publishLightFramesOnly") ?? true;
                EngineObj.ProcessingObj.settingsDSSInfoFileAutoDelete = ConfigManagement.getBool("options", "autoDeleteDSSInfoFile") ?? false;

                //Filter settings
                string st = ConfigManagement.getString("filters", "excludedirs") ?? "";
                EngineObj.MonitorObj.settingsFilterDirName_ExcludeSt = new List<string>(st.Split(';'));
                st = ConfigManagement.getString("filters", "excludefiles") ?? "";
                EngineObj.MonitorObj.settingsFilterFileName_ExcludeSt = new List<string>(st.Split(';'));
                EngineObj.ProcessingObj.settingsFilterObserverTag_Contains = ConfigManagement.getString("filters", "observer") ?? "";
                EngineObj.ProcessingObj.settingsFilterTelescopTag_Contains = ConfigManagement.getString("filters", "telescop") ?? "";
                EngineObj.ProcessingObj.settingsFilterInstrumeTag_Contains = ConfigManagement.getString("filters", "instrume") ?? "";
                //Filter settings: quality
                EngineObj.ProcessingObj.settingsFilterHistoryTag_MaxCount = (UInt16) (ConfigManagement.getInt("filters", "historycount") ?? 1);
                EngineObj.ProcessingObj.settingsFilterStarsNum_MinCount = (UInt16)(ConfigManagement.getInt("filters", "minstars") ?? 1);
                EngineObj.ProcessingObj.settingsFilterFWHM_MaxVal = ConfigManagement.getDouble("filters", "maxfwhm") ?? 10.0;
                EngineObj.ProcessingObj.settingsFilterMinAltitude_MinVal = ConfigManagement.getDouble("filters", "minaltitude") ?? 19.0;
                EngineObj.ProcessingObj.settingsFilterBackground_MaxVal = ConfigManagement.getDouble("filters", "maxbackground") ?? 0.30;

                Logging.AddLog("Program parameters were set according to configuration file", LogLevel.Activity);
            }
            catch (Exception ex)
            {
                Logging.AddLog("Couldn't load options" + ex.Message, LogLevel.Important, Highlight.Error);
                Logging.AddLog("Exception details: " + ex.ToString(), LogLevel.Debug, Highlight.Error);
            }
        }
  
        /// <summary>
        /// Update form fields from actual settings
        /// </summary>
        private void UpdateSettingsDialogFields()
        {
            //cancel autosasve settings events
            bTrapEvents = false;

            //Init Log DropDown box (в statusbar)
            foreach (LogLevel C in Enum.GetValues(typeof(LogLevel)))
            {
                toolStripDropDownLogLevel.DropDownItems.Add(Enum.GetName(typeof(LogLevel), C));
            }
            ToolStripSeparator s = new ToolStripSeparator();
            toolStripDropDownLogLevel.DropDownItems.Add(s);
            toolStripDropDownLogLevel.DropDownItems.Add("Clear");

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
            //перечень подкаталогов
            cmbMonitorPath.Items.Clear();
            foreach (string curDir in FileMonitorPath)
            {
                cmbMonitorPath.Items.Add(curDir);
            }
            if (cmbMonitorPath.Items.Count >= 1) cmbMonitorPath.SelectedIndex = 0;

            lblDirsMonitoringCount.Text = cmbMonitorPath.Items.Count.ToString();

            chkSearchSubdirs.Checked = EngineObj.MonitorObj.settingsScanSubdirs;

            chkSettings_Autostart.Checked = settingsAutoStartMonitoring;
            txtSettings_DSS.Text = EngineObj.ProcessingObj.settingsDSSCLPath;

            chkSettings_publishgroup.Checked = EngineObj.ProcessingObj.settingsPublishToGroup;
            txtSettings_urlgorup.Text = EngineObj.WebPublishObj.PublishURL;
            txtServerKey_Group.Text = EngineObj.WebPublishObj.ServerKey;

            chkSettings_publishprivate.Checked = EngineObj.ProcessingObj.settingsPublishToPrivate;
            txtSettings_urlprivate.Text = EngineObj.WebPublishObj2.PublishURL;
            txtServerKey_Private.Text = EngineObj.WebPublishObj2.ServerKey;

            //Filter settings
            FiltersFormObj.txtFilterDirNameExclude.Text = String.Join(";", EngineObj.MonitorObj.settingsFilterDirName_ExcludeSt.ToArray());
            FiltersFormObj.txtFilterFileNameExclude.Text = String.Join(";", EngineObj.MonitorObj.settingsFilterFileName_ExcludeSt.ToArray());
            FiltersFormObj.txtFilterObserverContains.Text = EngineObj.ProcessingObj.settingsFilterObserverTag_Contains;
            FiltersFormObj.txtFilterTelescopContains.Text = EngineObj.ProcessingObj.settingsFilterTelescopTag_Contains;
            FiltersFormObj.txtFilterInstrumeContains.Text = EngineObj.ProcessingObj.settingsFilterInstrumeTag_Contains;

            //Filter settings: quality
            FiltersFormObj.txtHistoryMaxCount.Text = EngineObj.ProcessingObj.settingsFilterHistoryTag_MaxCount.ToString();
            FiltersFormObj.txtFilterMinStarsCount.Text = EngineObj.ProcessingObj.settingsFilterStarsNum_MinCount.ToString();
            FiltersFormObj.txtFilterMaxFWHM.Text = EngineObj.ProcessingObj.settingsFilterFWHM_MaxVal.ToString();
            FiltersFormObj.txtFilterMinAltitude.Text = EngineObj.ProcessingObj.settingsFilterMinAltitude_MinVal.ToString();
            FiltersFormObj.txtFilterMaxBackground.Text = (EngineObj.ProcessingObj.settingsFilterBackground_MaxVal*100.0).ToString();

            //restore autosasve settings events
            bTrapEvents = true;

        }

        private void SaveSettingsToConfigFile()
        {
            //1. Update ConfigXML

            //Save dirlist
            ConfigManagement.ClearSection("monitorPath"); //clear entire section
            for (int i = 0; i < cmbMonitorPath.Items.Count; i++)
            {
                string curDir = cmbMonitorPath.GetItemText(cmbMonitorPath.Items[i]);
                ConfigManagement.UpdateConfigValue("monitorPath", "Dir" + (i + 1), curDir);
            }

            ConfigManagement.UpdateConfigValue("options", "ScanSubDirs", chkSearchSubdirs.Checked.ToString());
            ConfigManagement.UpdateConfigValue("options", "AUTOSTARTMONITORING", chkSettings_Autostart.Checked.ToString());
            ConfigManagement.UpdateConfigValue("options", "DSS_PATH", txtSettings_DSS.Text);
            ConfigManagement.UpdateConfigValue("options", "Language", cmbLang.SelectedValue.ToString());

            ConfigManagement.UpdateConfigValue("options", "PUBLISHTOGROUP", chkSettings_publishgroup.Checked.ToString());
            ConfigManagement.UpdateConfigValue("publishURL", "url1", txtSettings_urlgorup.Text);
            ConfigManagement.UpdateConfigValue("publishURL", "key1", txtServerKey_Group.Text);

            ConfigManagement.UpdateConfigValue("options", "PUBLISHTOPRIVATE", chkSettings_publishprivate.Checked.ToString());
            ConfigManagement.UpdateConfigValue("publishURL", "url2", txtSettings_urlprivate.Text);
            ConfigManagement.UpdateConfigValue("publishURL", "key2", txtServerKey_Private.Text);

            //hidden settings
            ConfigManagement.UpdateConfigValue("options", "extensionsToSearch", EngineObj.MonitorObj.settingsExtensionToSearch);
            ConfigManagement.UpdateConfigValue("options", "checkThreads_max", EngineObj.ProcessingObj.settingsMaxThreads.ToString());
            ConfigManagement.UpdateConfigValue("options", "checkDirIMS", EngineObj.ProcessingObj.settingsSkipIMSfiles.ToString());
            ConfigManagement.UpdateConfigValue("options", "alwaysRebuildDSSInfoFile", EngineObj.ProcessingObj.settingsDSSForceRecheck.ToString());
            ConfigManagement.UpdateConfigValue("options", "RunDSSHidden", EngineObj.ProcessingObj.settingsDSSForceRunHidden.ToString());
            ConfigManagement.UpdateConfigValue("options", "autoDeleteDSSInfoFile", EngineObj.ProcessingObj.settingsDSSInfoFileAutoDelete.ToString());
            ConfigManagement.UpdateConfigValue("options", "publishLightFramesOnly", EngineObj.ProcessingObj.settingsPublishLightFramesOnly.ToString());

            //Filter settings
            ConfigManagement.UpdateConfigValue("filters", "excludedirs", String.Join(";", EngineObj.MonitorObj.settingsFilterDirName_ExcludeSt.ToArray()));
            ConfigManagement.UpdateConfigValue("filters", "excludefiles", string.Join(";", EngineObj.MonitorObj.settingsFilterFileName_ExcludeSt.ToArray()));
            ConfigManagement.UpdateConfigValue("filters", "observer", EngineObj.ProcessingObj.settingsFilterObserverTag_Contains);
            ConfigManagement.UpdateConfigValue("filters", "telescop", EngineObj.ProcessingObj.settingsFilterTelescopTag_Contains);
            ConfigManagement.UpdateConfigValue("filters", "instrume", EngineObj.ProcessingObj.settingsFilterInstrumeTag_Contains);
            ConfigManagement.UpdateConfigValue("filters", "historycount", EngineObj.ProcessingObj.settingsFilterHistoryTag_MaxCount.ToString());
            ConfigManagement.UpdateConfigValue("filters", "minstars", EngineObj.ProcessingObj.settingsFilterStarsNum_MinCount.ToString());
            ConfigManagement.UpdateConfigValue("filters", "maxfwhm", EngineObj.ProcessingObj.settingsFilterFWHM_MaxVal.ToString());
            ConfigManagement.UpdateConfigValue("filters", "minaltitude", EngineObj.ProcessingObj.settingsFilterMinAltitude_MinVal.ToString());
            ConfigManagement.UpdateConfigValue("filters", "maxbackground", EngineObj.ProcessingObj.settingsFilterBackground_MaxVal.ToString());

            //2. Save ConfigXML to disk
            ConfigManagement.Save();

            //3. Load config from disk
            ConfigManagement.Load();
            LoadParamsFromConfigFile();

        }

        /// <summary>
        /// Updates all dir lists from combobox list
        /// Из элемента формы обновляются данные в XML и в переменных
        /// </summary>
        private void SaveDirList()
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

            //4. Обновить инфо о количестве подакаталогов
            lblDirsMonitoringCount.Text = cmbMonitorPath.Items.Count.ToString();
        }


        /// <summary>
        /// Save current settings. And reload them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettings_Save_Click(object sender, EventArgs e)
        {
            SaveSettingsToConfigFile();
        }

        bool bTrapEvents = true;
        bool bOptionsChanged = false;

        private void SettingsControl_Valuechanged(object sender, EventArgs e)
        {
            if (bTrapEvents)
                bOptionsChanged = true;
        }

        private void SettingsControl_Leave(object sender, EventArgs e)
        {
            if (bTrapEvents)
            {
                if (bOptionsChanged)
                {
                    bOptionsChanged = false;
                    SaveSettingsToConfigFile();
                }
            }
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
        /**************************************************************************************************/


        /**************************************************************************************************/
        #region = Filters =
        private void btnShowFilters_Click(object sender, EventArgs e)
        {
            FiltersFormObj.Show();
        }

        public void FiltersEnable()
        {
            bFiltersEnabled = true;
            btnFilters.BackColor = OnColor;
        }
        public void FiltersDisabe()
        {
            bFiltersEnabled = false;
            btnFilters.BackColor = DefBackColor;
        }
        #endregion End of = Filters =
        /**************************************************************************************************/



    }
}
