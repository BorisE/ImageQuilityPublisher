namespace ImageQualityPublisher
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSearchSubdirs = new System.Windows.Forms.CheckBox();
            this.cmbMonitorPath = new System.Windows.Forms.ComboBox();
            this.btnDelFolder = new System.Windows.Forms.Button();
            this.btnShowFilters = new System.Windows.Forms.Button();
            this.lblDirsMonitoringCount = new System.Windows.Forms.Label();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnRecheck = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.cmbLang = new System.Windows.Forms.ComboBox();
            this.linkDSS = new System.Windows.Forms.LinkLabel();
            this.btnLoadDSSPath = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSettings_DSS = new System.Windows.Forms.TextBox();
            this.chkSettings_Autostart = new System.Windows.Forms.CheckBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabList = new System.Windows.Forms.TabPage();
            this.dataGridFileData = new System.Windows.Forms.DataGridView();
            this.dataGridData_filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_Alt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_Stars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_FWHM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_MeanRadius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_Bg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_Exp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.btnSettings_Save = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServerKey_Private = new System.Windows.Forms.TextBox();
            this.txtServerKey_Group = new System.Windows.Forms.TextBox();
            this.txtSettings_urlprivate = new System.Windows.Forms.TextBox();
            this.txtSettings_urlgorup = new System.Windows.Forms.TextBox();
            this.chkSettings_publishprivate = new System.Windows.Forms.CheckBox();
            this.chkSettings_publishgroup = new System.Windows.Forms.CheckBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.linkAstrohostel = new System.Windows.Forms.LinkLabel();
            this.linkMilantiev = new System.Windows.Forms.LinkLabel();
            this.linkAstromania = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus_FilesFound = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_FilesProcessed = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_FilesWaiting = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownLogLevel = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripLogSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.monitorTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFileData)).BeginInit();
            this.tabLog.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusBar.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.chkSearchSubdirs);
            this.groupBox1.Controls.Add(this.cmbMonitorPath);
            this.groupBox1.Controls.Add(this.btnDelFolder);
            this.groupBox1.Controls.Add(this.btnShowFilters);
            this.groupBox1.Controls.Add(this.lblDirsMonitoringCount);
            this.groupBox1.Controls.Add(this.btnAddFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // chkSearchSubdirs
            // 
            resources.ApplyResources(this.chkSearchSubdirs, "chkSearchSubdirs");
            this.chkSearchSubdirs.Name = "chkSearchSubdirs";
            this.toolTip1.SetToolTip(this.chkSearchSubdirs, resources.GetString("chkSearchSubdirs.ToolTip"));
            this.chkSearchSubdirs.UseVisualStyleBackColor = true;
            this.chkSearchSubdirs.CheckedChanged += new System.EventHandler(this.chkSearchSubdirs_CheckedChanged);
            // 
            // cmbMonitorPath
            // 
            resources.ApplyResources(this.cmbMonitorPath, "cmbMonitorPath");
            this.cmbMonitorPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonitorPath.FormattingEnabled = true;
            this.cmbMonitorPath.Name = "cmbMonitorPath";
            this.toolTip1.SetToolTip(this.cmbMonitorPath, resources.GetString("cmbMonitorPath.ToolTip"));
            // 
            // btnDelFolder
            // 
            resources.ApplyResources(this.btnDelFolder, "btnDelFolder");
            this.btnDelFolder.Name = "btnDelFolder";
            this.toolTip1.SetToolTip(this.btnDelFolder, resources.GetString("btnDelFolder.ToolTip"));
            this.btnDelFolder.UseVisualStyleBackColor = true;
            this.btnDelFolder.Click += new System.EventHandler(this.btnDelFolder_Click);
            // 
            // btnShowFilters
            // 
            resources.ApplyResources(this.btnShowFilters, "btnShowFilters");
            this.btnShowFilters.Name = "btnShowFilters";
            this.toolTip1.SetToolTip(this.btnShowFilters, resources.GetString("btnShowFilters.ToolTip"));
            this.btnShowFilters.UseVisualStyleBackColor = true;
            this.btnShowFilters.Click += new System.EventHandler(this.btnShowFilters_Click);
            // 
            // lblDirsMonitoringCount
            // 
            resources.ApplyResources(this.lblDirsMonitoringCount, "lblDirsMonitoringCount");
            this.lblDirsMonitoringCount.Name = "lblDirsMonitoringCount";
            this.toolTip1.SetToolTip(this.lblDirsMonitoringCount, resources.GetString("lblDirsMonitoringCount.ToolTip"));
            // 
            // btnAddFolder
            // 
            resources.ApplyResources(this.btnAddFolder, "btnAddFolder");
            this.btnAddFolder.Name = "btnAddFolder";
            this.toolTip1.SetToolTip(this.btnAddFolder, resources.GetString("btnAddFolder.ToolTip"));
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // btnTest
            // 
            resources.ApplyResources(this.btnTest, "btnTest");
            this.btnTest.Name = "btnTest";
            this.toolTip1.SetToolTip(this.btnTest, resources.GetString("btnTest.ToolTip"));
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnRecheck
            // 
            resources.ApplyResources(this.btnRecheck, "btnRecheck");
            this.btnRecheck.Name = "btnRecheck";
            this.toolTip1.SetToolTip(this.btnRecheck, resources.GetString("btnRecheck.ToolTip"));
            this.btnRecheck.UseVisualStyleBackColor = true;
            this.btnRecheck.Click += new System.EventHandler(this.btnRecheck_Click);
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.toolTip1.SetToolTip(this.btnStart, resources.GetString("btnStart.ToolTip"));
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.label38);
            this.groupBox2.Controls.Add(this.cmbLang);
            this.groupBox2.Controls.Add(this.linkDSS);
            this.groupBox2.Controls.Add(this.btnLoadDSSPath);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtSettings_DSS);
            this.groupBox2.Controls.Add(this.chkSettings_Autostart);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // label38
            // 
            resources.ApplyResources(this.label38, "label38");
            this.label38.Name = "label38";
            this.toolTip1.SetToolTip(this.label38, resources.GetString("label38.ToolTip"));
            // 
            // cmbLang
            // 
            resources.ApplyResources(this.cmbLang, "cmbLang");
            this.cmbLang.FormattingEnabled = true;
            this.cmbLang.Name = "cmbLang";
            this.toolTip1.SetToolTip(this.cmbLang, resources.GetString("cmbLang.ToolTip"));
            this.cmbLang.SelectionChangeCommitted += new System.EventHandler(this.cmbLang_SelectionChangeCommitted);
            this.cmbLang.Leave += new System.EventHandler(this.SettingsControl_Leave);
            // 
            // linkDSS
            // 
            resources.ApplyResources(this.linkDSS, "linkDSS");
            this.linkDSS.Name = "linkDSS";
            this.linkDSS.TabStop = true;
            this.toolTip1.SetToolTip(this.linkDSS, resources.GetString("linkDSS.ToolTip"));
            this.linkDSS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAny_LinkClicked);
            // 
            // btnLoadDSSPath
            // 
            resources.ApplyResources(this.btnLoadDSSPath, "btnLoadDSSPath");
            this.btnLoadDSSPath.Name = "btnLoadDSSPath";
            this.toolTip1.SetToolTip(this.btnLoadDSSPath, resources.GetString("btnLoadDSSPath.ToolTip"));
            this.btnLoadDSSPath.UseVisualStyleBackColor = true;
            this.btnLoadDSSPath.Click += new System.EventHandler(this.btnLoadDSSPath_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.toolTip1.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // txtSettings_DSS
            // 
            resources.ApplyResources(this.txtSettings_DSS, "txtSettings_DSS");
            this.txtSettings_DSS.Name = "txtSettings_DSS";
            this.toolTip1.SetToolTip(this.txtSettings_DSS, resources.GetString("txtSettings_DSS.ToolTip"));
            this.txtSettings_DSS.TextChanged += new System.EventHandler(this.SettingsControl_Valuechanged);
            // 
            // chkSettings_Autostart
            // 
            resources.ApplyResources(this.chkSettings_Autostart, "chkSettings_Autostart");
            this.chkSettings_Autostart.Name = "chkSettings_Autostart";
            this.toolTip1.SetToolTip(this.chkSettings_Autostart, resources.GetString("chkSettings_Autostart.ToolTip"));
            this.chkSettings_Autostart.UseVisualStyleBackColor = true;
            this.chkSettings_Autostart.CheckedChanged += new System.EventHandler(this.SettingsControl_Valuechanged);
            this.chkSettings_Autostart.Leave += new System.EventHandler(this.SettingsControl_Leave);
            // 
            // txtLog
            // 
            resources.ApplyResources(this.txtLog, "txtLog");
            this.txtLog.Name = "txtLog";
            this.toolTip1.SetToolTip(this.txtLog, resources.GetString("txtLog.ToolTip"));
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabList);
            this.tabControl1.Controls.Add(this.tabLog);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabAbout);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.toolTip1.SetToolTip(this.tabControl1, resources.GetString("tabControl1.ToolTip"));
            // 
            // tabList
            // 
            resources.ApplyResources(this.tabList, "tabList");
            this.tabList.Controls.Add(this.dataGridFileData);
            this.tabList.Name = "tabList";
            this.toolTip1.SetToolTip(this.tabList, resources.GetString("tabList.ToolTip"));
            this.tabList.UseVisualStyleBackColor = true;
            // 
            // dataGridFileData
            // 
            resources.ApplyResources(this.dataGridFileData, "dataGridFileData");
            this.dataGridFileData.AllowUserToAddRows = false;
            this.dataGridFileData.AllowUserToDeleteRows = false;
            this.dataGridFileData.AllowUserToResizeRows = false;
            this.dataGridFileData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridData_filename,
            this.dataGridData_DateTime,
            this.dataGridData_Alt,
            this.dataGridData_Stars,
            this.dataGridData_FWHM,
            this.dataGridData_MeanRadius,
            this.dataGridData_Bg,
            this.dataGridData_Exp});
            this.dataGridFileData.Name = "dataGridFileData";
            this.dataGridFileData.RowHeadersVisible = false;
            this.toolTip1.SetToolTip(this.dataGridFileData, resources.GetString("dataGridFileData.ToolTip"));
            // 
            // dataGridData_filename
            // 
            this.dataGridData_filename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridData_filename.FillWeight = 50F;
            resources.ApplyResources(this.dataGridData_filename, "dataGridData_filename");
            this.dataGridData_filename.Name = "dataGridData_filename";
            this.dataGridData_filename.ReadOnly = true;
            // 
            // dataGridData_DateTime
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridData_DateTime.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dataGridData_DateTime, "dataGridData_DateTime");
            this.dataGridData_DateTime.Name = "dataGridData_DateTime";
            this.dataGridData_DateTime.ReadOnly = true;
            // 
            // dataGridData_Alt
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridData_Alt.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dataGridData_Alt, "dataGridData_Alt");
            this.dataGridData_Alt.Name = "dataGridData_Alt";
            this.dataGridData_Alt.ReadOnly = true;
            // 
            // dataGridData_Stars
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridData_Stars.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.dataGridData_Stars, "dataGridData_Stars");
            this.dataGridData_Stars.Name = "dataGridData_Stars";
            this.dataGridData_Stars.ReadOnly = true;
            // 
            // dataGridData_FWHM
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridData_FWHM.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.dataGridData_FWHM, "dataGridData_FWHM");
            this.dataGridData_FWHM.Name = "dataGridData_FWHM";
            this.dataGridData_FWHM.ReadOnly = true;
            // 
            // dataGridData_MeanRadius
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridData_MeanRadius.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.dataGridData_MeanRadius, "dataGridData_MeanRadius");
            this.dataGridData_MeanRadius.Name = "dataGridData_MeanRadius";
            this.dataGridData_MeanRadius.ReadOnly = true;
            // 
            // dataGridData_Bg
            // 
            resources.ApplyResources(this.dataGridData_Bg, "dataGridData_Bg");
            this.dataGridData_Bg.Name = "dataGridData_Bg";
            this.dataGridData_Bg.ReadOnly = true;
            // 
            // dataGridData_Exp
            // 
            resources.ApplyResources(this.dataGridData_Exp, "dataGridData_Exp");
            this.dataGridData_Exp.Name = "dataGridData_Exp";
            this.dataGridData_Exp.ReadOnly = true;
            // 
            // tabLog
            // 
            resources.ApplyResources(this.tabLog, "tabLog");
            this.tabLog.Controls.Add(this.txtLog);
            this.tabLog.Name = "tabLog";
            this.toolTip1.SetToolTip(this.tabLog, resources.GetString("tabLog.ToolTip"));
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            resources.ApplyResources(this.tabSettings, "tabSettings");
            this.tabSettings.Controls.Add(this.btnSettings_Save);
            this.tabSettings.Controls.Add(this.groupBox4);
            this.tabSettings.Controls.Add(this.groupBox2);
            this.tabSettings.Name = "tabSettings";
            this.toolTip1.SetToolTip(this.tabSettings, resources.GetString("tabSettings.ToolTip"));
            this.tabSettings.UseVisualStyleBackColor = true;
            this.tabSettings.Leave += new System.EventHandler(this.SettingsControl_Leave);
            // 
            // btnSettings_Save
            // 
            resources.ApplyResources(this.btnSettings_Save, "btnSettings_Save");
            this.btnSettings_Save.Name = "btnSettings_Save";
            this.toolTip1.SetToolTip(this.btnSettings_Save, resources.GetString("btnSettings_Save.ToolTip"));
            this.btnSettings_Save.UseVisualStyleBackColor = true;
            this.btnSettings_Save.Click += new System.EventHandler(this.btnSettings_Save_Click);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtServerKey_Private);
            this.groupBox4.Controls.Add(this.txtServerKey_Group);
            this.groupBox4.Controls.Add(this.txtSettings_urlprivate);
            this.groupBox4.Controls.Add(this.txtSettings_urlgorup);
            this.groupBox4.Controls.Add(this.chkSettings_publishprivate);
            this.groupBox4.Controls.Add(this.chkSettings_publishgroup);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox4, resources.GetString("groupBox4.ToolTip"));
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.toolTip1.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // txtServerKey_Private
            // 
            resources.ApplyResources(this.txtServerKey_Private, "txtServerKey_Private");
            this.txtServerKey_Private.Name = "txtServerKey_Private";
            this.toolTip1.SetToolTip(this.txtServerKey_Private, resources.GetString("txtServerKey_Private.ToolTip"));
            this.txtServerKey_Private.TextChanged += new System.EventHandler(this.SettingsControl_Valuechanged);
            this.txtServerKey_Private.Leave += new System.EventHandler(this.SettingsControl_Leave);
            // 
            // txtServerKey_Group
            // 
            resources.ApplyResources(this.txtServerKey_Group, "txtServerKey_Group");
            this.txtServerKey_Group.Name = "txtServerKey_Group";
            this.toolTip1.SetToolTip(this.txtServerKey_Group, resources.GetString("txtServerKey_Group.ToolTip"));
            this.txtServerKey_Group.TextChanged += new System.EventHandler(this.SettingsControl_Valuechanged);
            this.txtServerKey_Group.Leave += new System.EventHandler(this.SettingsControl_Leave);
            // 
            // txtSettings_urlprivate
            // 
            resources.ApplyResources(this.txtSettings_urlprivate, "txtSettings_urlprivate");
            this.txtSettings_urlprivate.Name = "txtSettings_urlprivate";
            this.toolTip1.SetToolTip(this.txtSettings_urlprivate, resources.GetString("txtSettings_urlprivate.ToolTip"));
            this.txtSettings_urlprivate.TextChanged += new System.EventHandler(this.SettingsControl_Valuechanged);
            this.txtSettings_urlprivate.Leave += new System.EventHandler(this.SettingsControl_Leave);
            // 
            // txtSettings_urlgorup
            // 
            resources.ApplyResources(this.txtSettings_urlgorup, "txtSettings_urlgorup");
            this.txtSettings_urlgorup.Name = "txtSettings_urlgorup";
            this.toolTip1.SetToolTip(this.txtSettings_urlgorup, resources.GetString("txtSettings_urlgorup.ToolTip"));
            this.txtSettings_urlgorup.TextChanged += new System.EventHandler(this.SettingsControl_Valuechanged);
            this.txtSettings_urlgorup.Leave += new System.EventHandler(this.SettingsControl_Leave);
            // 
            // chkSettings_publishprivate
            // 
            resources.ApplyResources(this.chkSettings_publishprivate, "chkSettings_publishprivate");
            this.chkSettings_publishprivate.Name = "chkSettings_publishprivate";
            this.toolTip1.SetToolTip(this.chkSettings_publishprivate, resources.GetString("chkSettings_publishprivate.ToolTip"));
            this.chkSettings_publishprivate.UseVisualStyleBackColor = true;
            this.chkSettings_publishprivate.CheckedChanged += new System.EventHandler(this.SettingsControl_Valuechanged);
            this.chkSettings_publishprivate.Leave += new System.EventHandler(this.SettingsControl_Leave);
            // 
            // chkSettings_publishgroup
            // 
            resources.ApplyResources(this.chkSettings_publishgroup, "chkSettings_publishgroup");
            this.chkSettings_publishgroup.Checked = true;
            this.chkSettings_publishgroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettings_publishgroup.Name = "chkSettings_publishgroup";
            this.toolTip1.SetToolTip(this.chkSettings_publishgroup, resources.GetString("chkSettings_publishgroup.ToolTip"));
            this.chkSettings_publishgroup.UseVisualStyleBackColor = true;
            this.chkSettings_publishgroup.CheckedChanged += new System.EventHandler(this.SettingsControl_Valuechanged);
            this.chkSettings_publishgroup.Leave += new System.EventHandler(this.SettingsControl_Leave);
            // 
            // tabAbout
            // 
            resources.ApplyResources(this.tabAbout, "tabAbout");
            this.tabAbout.Controls.Add(this.label7);
            this.tabAbout.Controls.Add(this.lblVersion);
            this.tabAbout.Controls.Add(this.label14);
            this.tabAbout.Controls.Add(this.label6);
            this.tabAbout.Controls.Add(this.label17);
            this.tabAbout.Controls.Add(this.linkAstrohostel);
            this.tabAbout.Controls.Add(this.linkMilantiev);
            this.tabAbout.Controls.Add(this.linkAstromania);
            this.tabAbout.Controls.Add(this.pictureBox1);
            this.tabAbout.Name = "tabAbout";
            this.toolTip1.SetToolTip(this.tabAbout, resources.GetString("tabAbout.ToolTip"));
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            this.toolTip1.SetToolTip(this.label7, resources.GetString("label7.ToolTip"));
            // 
            // lblVersion
            // 
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.Name = "lblVersion";
            this.toolTip1.SetToolTip(this.lblVersion, resources.GetString("lblVersion.ToolTip"));
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            this.toolTip1.SetToolTip(this.label14, resources.GetString("label14.ToolTip"));
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            this.toolTip1.SetToolTip(this.label6, resources.GetString("label6.ToolTip"));
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            this.toolTip1.SetToolTip(this.label17, resources.GetString("label17.ToolTip"));
            // 
            // linkAstrohostel
            // 
            resources.ApplyResources(this.linkAstrohostel, "linkAstrohostel");
            this.linkAstrohostel.Name = "linkAstrohostel";
            this.linkAstrohostel.TabStop = true;
            this.toolTip1.SetToolTip(this.linkAstrohostel, resources.GetString("linkAstrohostel.ToolTip"));
            this.linkAstrohostel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAny_LinkClicked);
            // 
            // linkMilantiev
            // 
            resources.ApplyResources(this.linkMilantiev, "linkMilantiev");
            this.linkMilantiev.Name = "linkMilantiev";
            this.linkMilantiev.TabStop = true;
            this.toolTip1.SetToolTip(this.linkMilantiev, resources.GetString("linkMilantiev.ToolTip"));
            this.linkMilantiev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAny_LinkClicked);
            // 
            // linkAstromania
            // 
            resources.ApplyResources(this.linkAstromania, "linkAstromania");
            this.linkAstromania.Name = "linkAstromania";
            this.linkAstromania.TabStop = true;
            this.toolTip1.SetToolTip(this.linkAstromania, resources.GetString("linkAstromania.ToolTip"));
            this.linkAstromania.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAny_LinkClicked);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, resources.GetString("pictureBox1.ToolTip"));
            // 
            // logRefreshTimer
            // 
            this.logRefreshTimer.Interval = 500;
            this.logRefreshTimer.Tick += new System.EventHandler(this.logRefreshTimer_Tick);
            // 
            // statusBar
            // 
            resources.ApplyResources(this.statusBar, "statusBar");
            this.statusBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus_FilesFound,
            this.toolStripStatus_FilesProcessed,
            this.toolStripStatus_FilesWaiting,
            this.toolStripDropDownLogLevel,
            this.toolStripLogSize});
            this.statusBar.Name = "statusBar";
            this.statusBar.ShowItemToolTips = true;
            this.toolTip1.SetToolTip(this.statusBar, resources.GetString("statusBar.ToolTip"));
            // 
            // toolStripStatus_FilesFound
            // 
            resources.ApplyResources(this.toolStripStatus_FilesFound, "toolStripStatus_FilesFound");
            this.toolStripStatus_FilesFound.Name = "toolStripStatus_FilesFound";
            // 
            // toolStripStatus_FilesProcessed
            // 
            resources.ApplyResources(this.toolStripStatus_FilesProcessed, "toolStripStatus_FilesProcessed");
            this.toolStripStatus_FilesProcessed.Name = "toolStripStatus_FilesProcessed";
            // 
            // toolStripStatus_FilesWaiting
            // 
            resources.ApplyResources(this.toolStripStatus_FilesWaiting, "toolStripStatus_FilesWaiting");
            this.toolStripStatus_FilesWaiting.Name = "toolStripStatus_FilesWaiting";
            // 
            // toolStripDropDownLogLevel
            // 
            resources.ApplyResources(this.toolStripDropDownLogLevel, "toolStripDropDownLogLevel");
            this.toolStripDropDownLogLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownLogLevel.Name = "toolStripDropDownLogLevel";
            this.toolStripDropDownLogLevel.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownLogLevel_DropDownItemClicked);
            // 
            // toolStripLogSize
            // 
            resources.ApplyResources(this.toolStripLogSize, "toolStripLogSize");
            this.toolStripLogSize.Name = "toolStripLogSize";
            // 
            // monitorTimer
            // 
            this.monitorTimer.Interval = 1000;
            this.monitorTimer.Tick += new System.EventHandler(this.monitorTimer_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // groupBox5
            // 
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Controls.Add(this.btnRecheck);
            this.groupBox5.Controls.Add(this.btnStart);
            this.groupBox5.Controls.Add(this.btnTest);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox5, resources.GetString("groupBox5.ToolTip"));
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnStart;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFileData)).EndInit();
            this.tabLog.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkSettings_Autostart;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.DataGridView dataGridFileData;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Timer logRefreshTimer;
        private System.Windows.Forms.StatusStrip statusBar;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatus_FilesFound;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownLogLevel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLogSize;
        private System.Windows.Forms.Timer monitorTimer;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtSettings_urlprivate;
        private System.Windows.Forms.TextBox txtSettings_urlgorup;
        private System.Windows.Forms.CheckBox chkSettings_publishprivate;
        private System.Windows.Forms.CheckBox chkSettings_publishgroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSettings_DSS;
        private System.Windows.Forms.LinkLabel linkDSS;
        private System.Windows.Forms.Button btnLoadDSSPath;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.LinkLabel linkAstrohostel;
        private System.Windows.Forms.LinkLabel linkAstromania;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkMilantiev;
        private System.Windows.Forms.Button btnSettings_Save;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRecheck;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ComboBox cmbLang;
        private System.Windows.Forms.ComboBox cmbMonitorPath;
        private System.Windows.Forms.Button btnDelFolder;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblDirsMonitoringCount;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatus_FilesProcessed;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatus_FilesWaiting;
        private System.Windows.Forms.CheckBox chkSearchSubdirs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Alt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Stars;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_FWHM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_MeanRadius;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Bg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Exp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServerKey_Group;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServerKey_Private;
        private System.Windows.Forms.Button btnShowFilters;
    }
}

