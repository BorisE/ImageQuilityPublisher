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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSearchSubdirs = new System.Windows.Forms.CheckBox();
            this.cmbMonitorPath = new System.Windows.Forms.ComboBox();
            this.btnDelFolder = new System.Windows.Forms.Button();
            this.lblDirsMonitoring = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.chkSearchSubdirs);
            this.groupBox1.Controls.Add(this.cmbMonitorPath);
            this.groupBox1.Controls.Add(this.btnDelFolder);
            this.groupBox1.Controls.Add(this.lblDirsMonitoring);
            this.groupBox1.Controls.Add(this.btnAddFolder);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chkSearchSubdirs
            // 
            resources.ApplyResources(this.chkSearchSubdirs, "chkSearchSubdirs");
            this.chkSearchSubdirs.Name = "chkSearchSubdirs";
            this.chkSearchSubdirs.UseVisualStyleBackColor = true;
            this.chkSearchSubdirs.CheckedChanged += new System.EventHandler(this.chkSearchSubdirs_CheckedChanged);
            // 
            // cmbMonitorPath
            // 
            this.cmbMonitorPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonitorPath.FormattingEnabled = true;
            resources.ApplyResources(this.cmbMonitorPath, "cmbMonitorPath");
            this.cmbMonitorPath.Name = "cmbMonitorPath";
            // 
            // btnDelFolder
            // 
            resources.ApplyResources(this.btnDelFolder, "btnDelFolder");
            this.btnDelFolder.Name = "btnDelFolder";
            this.toolTip1.SetToolTip(this.btnDelFolder, resources.GetString("btnDelFolder.ToolTip"));
            this.btnDelFolder.UseVisualStyleBackColor = true;
            this.btnDelFolder.Click += new System.EventHandler(this.btnDelFolder_Click);
            // 
            // lblDirsMonitoring
            // 
            resources.ApplyResources(this.lblDirsMonitoring, "lblDirsMonitoring");
            this.lblDirsMonitoring.Name = "lblDirsMonitoring";
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
            // 
            // btnTest
            // 
            resources.ApplyResources(this.btnTest, "btnTest");
            this.btnTest.Name = "btnTest";
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
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
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
            // 
            // label38
            // 
            resources.ApplyResources(this.label38, "label38");
            this.label38.Name = "label38";
            // 
            // cmbLang
            // 
            this.cmbLang.FormattingEnabled = true;
            resources.ApplyResources(this.cmbLang, "cmbLang");
            this.cmbLang.Name = "cmbLang";
            this.toolTip1.SetToolTip(this.cmbLang, resources.GetString("cmbLang.ToolTip"));
            // 
            // linkDSS
            // 
            resources.ApplyResources(this.linkDSS, "linkDSS");
            this.linkDSS.Name = "linkDSS";
            this.linkDSS.TabStop = true;
            this.linkDSS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAny_LinkClicked);
            // 
            // btnLoadDSSPath
            // 
            resources.ApplyResources(this.btnLoadDSSPath, "btnLoadDSSPath");
            this.btnLoadDSSPath.Name = "btnLoadDSSPath";
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
            // 
            // chkSettings_Autostart
            // 
            resources.ApplyResources(this.chkSettings_Autostart, "chkSettings_Autostart");
            this.chkSettings_Autostart.Name = "chkSettings_Autostart";
            this.toolTip1.SetToolTip(this.chkSettings_Autostart, resources.GetString("chkSettings_Autostart.ToolTip"));
            this.chkSettings_Autostart.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            resources.ApplyResources(this.txtLog, "txtLog");
            this.txtLog.Name = "txtLog";
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
            // 
            // tabList
            // 
            this.tabList.Controls.Add(this.dataGridFileData);
            resources.ApplyResources(this.tabList, "tabList");
            this.tabList.Name = "tabList";
            this.tabList.UseVisualStyleBackColor = true;
            // 
            // dataGridFileData
            // 
            this.dataGridFileData.AllowUserToAddRows = false;
            this.dataGridFileData.AllowUserToDeleteRows = false;
            this.dataGridFileData.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dataGridFileData, "dataGridFileData");
            this.dataGridFileData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            resources.ApplyResources(this.dataGridData_DateTime, "dataGridData_DateTime");
            this.dataGridData_DateTime.Name = "dataGridData_DateTime";
            this.dataGridData_DateTime.ReadOnly = true;
            // 
            // dataGridData_Alt
            // 
            resources.ApplyResources(this.dataGridData_Alt, "dataGridData_Alt");
            this.dataGridData_Alt.Name = "dataGridData_Alt";
            this.dataGridData_Alt.ReadOnly = true;
            // 
            // dataGridData_Stars
            // 
            resources.ApplyResources(this.dataGridData_Stars, "dataGridData_Stars");
            this.dataGridData_Stars.Name = "dataGridData_Stars";
            this.dataGridData_Stars.ReadOnly = true;
            // 
            // dataGridData_FWHM
            // 
            resources.ApplyResources(this.dataGridData_FWHM, "dataGridData_FWHM");
            this.dataGridData_FWHM.Name = "dataGridData_FWHM";
            this.dataGridData_FWHM.ReadOnly = true;
            // 
            // dataGridData_MeanRadius
            // 
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
            this.tabLog.Controls.Add(this.txtLog);
            resources.ApplyResources(this.tabLog, "tabLog");
            this.tabLog.Name = "tabLog";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.btnSettings_Save);
            this.tabSettings.Controls.Add(this.groupBox4);
            this.tabSettings.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.tabSettings, "tabSettings");
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // btnSettings_Save
            // 
            resources.ApplyResources(this.btnSettings_Save, "btnSettings_Save");
            this.btnSettings_Save.Name = "btnSettings_Save";
            this.btnSettings_Save.UseVisualStyleBackColor = true;
            this.btnSettings_Save.Click += new System.EventHandler(this.btnSettings_Save_Click);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.txtSettings_urlprivate);
            this.groupBox4.Controls.Add(this.txtSettings_urlgorup);
            this.groupBox4.Controls.Add(this.chkSettings_publishprivate);
            this.groupBox4.Controls.Add(this.chkSettings_publishgroup);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // txtSettings_urlprivate
            // 
            resources.ApplyResources(this.txtSettings_urlprivate, "txtSettings_urlprivate");
            this.txtSettings_urlprivate.Name = "txtSettings_urlprivate";
            // 
            // txtSettings_urlgorup
            // 
            resources.ApplyResources(this.txtSettings_urlgorup, "txtSettings_urlgorup");
            this.txtSettings_urlgorup.Name = "txtSettings_urlgorup";
            // 
            // chkSettings_publishprivate
            // 
            resources.ApplyResources(this.chkSettings_publishprivate, "chkSettings_publishprivate");
            this.chkSettings_publishprivate.Name = "chkSettings_publishprivate";
            this.toolTip1.SetToolTip(this.chkSettings_publishprivate, resources.GetString("chkSettings_publishprivate.ToolTip"));
            this.chkSettings_publishprivate.UseVisualStyleBackColor = true;
            // 
            // chkSettings_publishgroup
            // 
            resources.ApplyResources(this.chkSettings_publishgroup, "chkSettings_publishgroup");
            this.chkSettings_publishgroup.Checked = true;
            this.chkSettings_publishgroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettings_publishgroup.Name = "chkSettings_publishgroup";
            this.chkSettings_publishgroup.UseVisualStyleBackColor = true;
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.label7);
            this.tabAbout.Controls.Add(this.lblVersion);
            this.tabAbout.Controls.Add(this.label14);
            this.tabAbout.Controls.Add(this.label6);
            this.tabAbout.Controls.Add(this.label17);
            this.tabAbout.Controls.Add(this.linkAstrohostel);
            this.tabAbout.Controls.Add(this.linkMilantiev);
            this.tabAbout.Controls.Add(this.linkAstromania);
            this.tabAbout.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.tabAbout, "tabAbout");
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // lblVersion
            // 
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.Name = "lblVersion";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // linkAstrohostel
            // 
            resources.ApplyResources(this.linkAstrohostel, "linkAstrohostel");
            this.linkAstrohostel.Name = "linkAstrohostel";
            this.linkAstrohostel.TabStop = true;
            this.linkAstrohostel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAny_LinkClicked);
            // 
            // linkMilantiev
            // 
            resources.ApplyResources(this.linkMilantiev, "linkMilantiev");
            this.linkMilantiev.Name = "linkMilantiev";
            this.linkMilantiev.TabStop = true;
            this.linkMilantiev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAny_LinkClicked);
            // 
            // linkAstromania
            // 
            resources.ApplyResources(this.linkAstromania, "linkAstromania");
            this.linkAstromania.Name = "linkAstromania";
            this.linkAstromania.TabStop = true;
            this.linkAstromania.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAny_LinkClicked);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // logRefreshTimer
            // 
            this.logRefreshTimer.Interval = 500;
            this.logRefreshTimer.Tick += new System.EventHandler(this.logRefreshTimer_Tick);
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus_FilesFound,
            this.toolStripStatus_FilesProcessed,
            this.toolStripStatus_FilesWaiting,
            this.toolStripDropDownLogLevel,
            this.toolStripLogSize});
            resources.ApplyResources(this.statusBar, "statusBar");
            this.statusBar.Name = "statusBar";
            this.statusBar.ShowItemToolTips = true;
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
            this.toolStripDropDownLogLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripDropDownLogLevel, "toolStripDropDownLogLevel");
            this.toolStripDropDownLogLevel.Name = "toolStripDropDownLogLevel";
            // 
            // toolStripLogSize
            // 
            this.toolStripLogSize.Name = "toolStripLogSize";
            resources.ApplyResources(this.toolStripLogSize, "toolStripLogSize");
            // 
            // monitorTimer
            // 
            this.monitorTimer.Interval = 1000;
            this.monitorTimer.Tick += new System.EventHandler(this.monitorTmer_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnRecheck);
            this.groupBox5.Controls.Add(this.btnStart);
            this.groupBox5.Controls.Add(this.btnTest);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Alt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Stars;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_FWHM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_MeanRadius;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Bg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Exp;
        private System.Windows.Forms.ComboBox cmbMonitorPath;
        private System.Windows.Forms.Button btnDelFolder;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblDirsMonitoring;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatus_FilesProcessed;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatus_FilesWaiting;
        private System.Windows.Forms.CheckBox chkSearchSubdirs;
    }
}

