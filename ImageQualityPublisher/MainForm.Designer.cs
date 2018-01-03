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
            this.txtMonitorPath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChooseFolder = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkDSS = new System.Windows.Forms.LinkLabel();
            this.btnLoadDSSPath = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSettings_DSS = new System.Windows.Forms.TextBox();
            this.chkSettings_Autostart = new System.Windows.Forms.CheckBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.txtLastFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtStarsNum = new System.Windows.Forms.TextBox();
            this.txtMeanRadius = new System.Windows.Forms.TextBox();
            this.txtBgLevel = new System.Windows.Forms.TextBox();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.tabList = new System.Windows.Forms.TabPage();
            this.dataGridFileData = new System.Windows.Forms.DataGridView();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.btnSettings_Save = new System.Windows.Forms.Button();
            this.btnSettings_Cancel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSettings_urlprivate = new System.Windows.Forms.TextBox();
            this.txtSettings_urlgorup = new System.Windows.Forms.TextBox();
            this.chkSettings_publishprivate = new System.Windows.Forms.CheckBox();
            this.chkSettings_publishgroup = new System.Windows.Forms.CheckBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
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
            this.toolStripStatus_Images = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownLogLevel = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripLogSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.monitorTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridData_filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_Alt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_Stars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_FWHM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_MeanRadius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_Bg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_Exp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.tabList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFileData)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMonitorPath
            // 
            this.txtMonitorPath.Location = new System.Drawing.Point(17, 30);
            this.txtMonitorPath.Name = "txtMonitorPath";
            this.txtMonitorPath.Size = new System.Drawing.Size(845, 31);
            this.txtMonitorPath.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChooseFolder);
            this.groupBox1.Controls.Add(this.txtMonitorPath);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Location = new System.Drawing.Point(0, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1495, 89);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Monitor";
            // 
            // btnChooseFolder
            // 
            this.btnChooseFolder.Location = new System.Drawing.Point(891, 30);
            this.btnChooseFolder.Name = "btnChooseFolder";
            this.btnChooseFolder.Size = new System.Drawing.Size(90, 38);
            this.btnChooseFolder.TabIndex = 1;
            this.btnChooseFolder.Text = "...";
            this.btnChooseFolder.UseVisualStyleBackColor = true;
            this.btnChooseFolder.Click += new System.EventHandler(this.btnChooseFolder_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(1299, 20);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(152, 50);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(1008, 20);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(77, 50);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1106, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(176, 50);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkDSS);
            this.groupBox2.Controls.Add(this.btnLoadDSSPath);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtSettings_DSS);
            this.groupBox2.Controls.Add(this.chkSettings_Autostart);
            this.groupBox2.Location = new System.Drawing.Point(14, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(997, 163);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // linkDSS
            // 
            this.linkDSS.AutoSize = true;
            this.linkDSS.Location = new System.Drawing.Point(812, 82);
            this.linkDSS.Name = "linkDSS";
            this.linkDSS.Size = new System.Drawing.Size(156, 25);
            this.linkDSS.TabIndex = 6;
            this.linkDSS.TabStop = true;
            this.linkDSS.Text = "Download DSS";
            this.linkDSS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAny_LinkClicked);
            // 
            // btnLoadDSSPath
            // 
            this.btnLoadDSSPath.Location = new System.Drawing.Point(720, 74);
            this.btnLoadDSSPath.Name = "btnLoadDSSPath";
            this.btnLoadDSSPath.Size = new System.Drawing.Size(75, 40);
            this.btnLoadDSSPath.TabIndex = 5;
            this.btnLoadDSSPath.Text = "...";
            this.btnLoadDSSPath.UseVisualStyleBackColor = true;
            this.btnLoadDSSPath.Click += new System.EventHandler(this.btnLoadDSSPath_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "DeepSkyStacker path";
            // 
            // txtSettings_DSS
            // 
            this.txtSettings_DSS.Location = new System.Drawing.Point(258, 79);
            this.txtSettings_DSS.Name = "txtSettings_DSS";
            this.txtSettings_DSS.Size = new System.Drawing.Size(443, 31);
            this.txtSettings_DSS.TabIndex = 3;
            // 
            // chkSettings_Autostart
            // 
            this.chkSettings_Autostart.AutoSize = true;
            this.chkSettings_Autostart.Location = new System.Drawing.Point(25, 37);
            this.chkSettings_Autostart.Name = "chkSettings_Autostart";
            this.chkSettings_Autostart.Size = new System.Drawing.Size(236, 29);
            this.chkSettings_Autostart.TabIndex = 0;
            this.chkSettings_Autostart.Text = "Autostart monitoring";
            this.chkSettings_Autostart.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1479, 590);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // txtLastFileName
            // 
            this.txtLastFileName.Location = new System.Drawing.Point(74, 24);
            this.txtLastFileName.Name = "txtLastFileName";
            this.txtLastFileName.ReadOnly = true;
            this.txtLastFileName.Size = new System.Drawing.Size(670, 31);
            this.txtLastFileName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "File";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtStarsNum);
            this.groupBox3.Controls.Add(this.txtMeanRadius);
            this.groupBox3.Controls.Add(this.txtBgLevel);
            this.groupBox3.Controls.Add(this.txtTest);
            this.groupBox3.Controls.Add(this.txtLastFileName);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(1457, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1496, 126);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "last image";
            this.groupBox3.Visible = false;
            // 
            // txtStarsNum
            // 
            this.txtStarsNum.Location = new System.Drawing.Point(1348, 24);
            this.txtStarsNum.Name = "txtStarsNum";
            this.txtStarsNum.ReadOnly = true;
            this.txtStarsNum.Size = new System.Drawing.Size(104, 31);
            this.txtStarsNum.TabIndex = 0;
            // 
            // txtMeanRadius
            // 
            this.txtMeanRadius.Location = new System.Drawing.Point(1083, 24);
            this.txtMeanRadius.Name = "txtMeanRadius";
            this.txtMeanRadius.ReadOnly = true;
            this.txtMeanRadius.Size = new System.Drawing.Size(104, 31);
            this.txtMeanRadius.TabIndex = 0;
            // 
            // txtBgLevel
            // 
            this.txtBgLevel.Location = new System.Drawing.Point(815, 24);
            this.txtBgLevel.Name = "txtBgLevel";
            this.txtBgLevel.ReadOnly = true;
            this.txtBgLevel.Size = new System.Drawing.Size(104, 31);
            this.txtBgLevel.TabIndex = 0;
            // 
            // txtTest
            // 
            this.txtTest.Location = new System.Drawing.Point(18, 68);
            this.txtTest.Name = "txtTest";
            this.txtTest.ReadOnly = true;
            this.txtTest.Size = new System.Drawing.Size(1434, 31);
            this.txtTest.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1229, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Stars #";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(944, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "MeanRadius";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(771, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bg";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabLog);
            this.tabControl1.Controls.Add(this.tabList);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabAbout);
            this.tabControl1.Location = new System.Drawing.Point(0, 107);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1495, 643);
            this.tabControl1.TabIndex = 6;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.txtLog);
            this.tabLog.Location = new System.Drawing.Point(8, 39);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(1479, 596);
            this.tabLog.TabIndex = 0;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // tabList
            // 
            this.tabList.Controls.Add(this.dataGridFileData);
            this.tabList.Location = new System.Drawing.Point(8, 39);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(1479, 596);
            this.tabList.TabIndex = 1;
            this.tabList.Text = "Images";
            this.tabList.UseVisualStyleBackColor = true;
            // 
            // dataGridFileData
            // 
            this.dataGridFileData.AllowUserToAddRows = false;
            this.dataGridFileData.AllowUserToDeleteRows = false;
            this.dataGridFileData.AllowUserToResizeRows = false;
            this.dataGridFileData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGridFileData.Location = new System.Drawing.Point(0, 0);
            this.dataGridFileData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridFileData.Name = "dataGridFileData";
            this.dataGridFileData.RowHeadersVisible = false;
            this.dataGridFileData.RowHeadersWidth = 10;
            this.dataGridFileData.Size = new System.Drawing.Size(1479, 582);
            this.dataGridFileData.TabIndex = 4;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.btnSettings_Save);
            this.tabSettings.Controls.Add(this.btnSettings_Cancel);
            this.tabSettings.Controls.Add(this.groupBox4);
            this.tabSettings.Controls.Add(this.groupBox2);
            this.tabSettings.Location = new System.Drawing.Point(8, 39);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(1479, 596);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // btnSettings_Save
            // 
            this.btnSettings_Save.Location = new System.Drawing.Point(1141, 400);
            this.btnSettings_Save.Name = "btnSettings_Save";
            this.btnSettings_Save.Size = new System.Drawing.Size(153, 43);
            this.btnSettings_Save.TabIndex = 3;
            this.btnSettings_Save.Text = "Save";
            this.btnSettings_Save.UseVisualStyleBackColor = true;
            this.btnSettings_Save.Click += new System.EventHandler(this.btnSettings_Save_Click);
            // 
            // btnSettings_Cancel
            // 
            this.btnSettings_Cancel.Location = new System.Drawing.Point(1300, 400);
            this.btnSettings_Cancel.Name = "btnSettings_Cancel";
            this.btnSettings_Cancel.Size = new System.Drawing.Size(153, 43);
            this.btnSettings_Cancel.TabIndex = 3;
            this.btnSettings_Cancel.Text = "Cancel";
            this.btnSettings_Cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSettings_urlprivate);
            this.groupBox4.Controls.Add(this.txtSettings_urlgorup);
            this.groupBox4.Controls.Add(this.chkSettings_publishprivate);
            this.groupBox4.Controls.Add(this.chkSettings_publishgroup);
            this.groupBox4.Location = new System.Drawing.Point(14, 195);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(997, 242);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Web";
            // 
            // txtSettings_urlprivate
            // 
            this.txtSettings_urlprivate.Location = new System.Drawing.Point(231, 72);
            this.txtSettings_urlprivate.Name = "txtSettings_urlprivate";
            this.txtSettings_urlprivate.Size = new System.Drawing.Size(632, 31);
            this.txtSettings_urlprivate.TabIndex = 1;
            // 
            // txtSettings_urlgorup
            // 
            this.txtSettings_urlgorup.Location = new System.Drawing.Point(231, 35);
            this.txtSettings_urlgorup.Name = "txtSettings_urlgorup";
            this.txtSettings_urlgorup.Size = new System.Drawing.Size(632, 31);
            this.txtSettings_urlgorup.TabIndex = 1;
            // 
            // chkSettings_publishprivate
            // 
            this.chkSettings_publishprivate.AutoSize = true;
            this.chkSettings_publishprivate.Location = new System.Drawing.Point(25, 74);
            this.chkSettings_publishprivate.Name = "chkSettings_publishprivate";
            this.chkSettings_publishprivate.Size = new System.Drawing.Size(186, 29);
            this.chkSettings_publishprivate.TabIndex = 0;
            this.chkSettings_publishprivate.Text = "Publish private";
            this.chkSettings_publishprivate.UseVisualStyleBackColor = true;
            // 
            // chkSettings_publishgroup
            // 
            this.chkSettings_publishgroup.AutoSize = true;
            this.chkSettings_publishgroup.Checked = true;
            this.chkSettings_publishgroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettings_publishgroup.Location = new System.Drawing.Point(25, 37);
            this.chkSettings_publishgroup.Name = "chkSettings_publishgroup";
            this.chkSettings_publishgroup.Size = new System.Drawing.Size(200, 29);
            this.chkSettings_publishgroup.TabIndex = 0;
            this.chkSettings_publishgroup.Text = "Publish to group";
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
            this.tabAbout.Location = new System.Drawing.Point(8, 39);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(1479, 596);
            this.tabAbout.TabIndex = 3;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // lblVersion
            // 
            this.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVersion.Location = new System.Drawing.Point(488, 162);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(699, 161);
            this.lblVersion.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(483, 9);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(704, 60);
            this.label14.TabIndex = 11;
            this.label14.Text = "Image Quality Publisher";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(483, 122);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(285, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Part of Astrohostel.ru project";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(483, 69);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(286, 25);
            this.label17.TabIndex = 10;
            this.label17.Text = "(C) 2018 by Emchenko Boris";
            // 
            // linkAstrohostel
            // 
            this.linkAstrohostel.AutoSize = true;
            this.linkAstrohostel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkAstrohostel.Location = new System.Drawing.Point(776, 122);
            this.linkAstrohostel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkAstrohostel.Name = "linkAstrohostel";
            this.linkAstrohostel.Size = new System.Drawing.Size(143, 25);
            this.linkAstrohostel.TabIndex = 9;
            this.linkAstrohostel.TabStop = true;
            this.linkAstrohostel.Text = "astrohostel.ru";
            this.linkAstrohostel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAny_LinkClicked);
            // 
            // linkMilantiev
            // 
            this.linkMilantiev.AutoSize = true;
            this.linkMilantiev.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkMilantiev.Location = new System.Drawing.Point(1180, 69);
            this.linkMilantiev.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkMilantiev.Name = "linkMilantiev";
            this.linkMilantiev.Size = new System.Drawing.Size(211, 25);
            this.linkMilantiev.TabIndex = 9;
            this.linkMilantiev.TabStop = true;
            this.linkMilantiev.Text = "(astro.milantiev.com)";
            this.linkMilantiev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAny_LinkClicked);
            // 
            // linkAstromania
            // 
            this.linkAstromania.AutoSize = true;
            this.linkAstromania.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkAstromania.Location = new System.Drawing.Point(763, 69);
            this.linkAstromania.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkAstromania.Name = "linkAstromania";
            this.linkAstromania.Size = new System.Drawing.Size(224, 25);
            this.linkAstromania.TabIndex = 9;
            this.linkAstromania.TabStop = true;
            this.linkAstromania.Text = "(www.astromania.info)";
            this.linkAstromania.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAny_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(4, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(452, 221);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 8;
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
            this.toolStripStatus_Images,
            this.toolStripDropDownLogLevel,
            this.toolStripLogSize});
            this.statusBar.Location = new System.Drawing.Point(0, 753);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(4, 0, 28, 0);
            this.statusBar.ShowItemToolTips = true;
            this.statusBar.Size = new System.Drawing.Size(1496, 38);
            this.statusBar.TabIndex = 7;
            this.statusBar.Text = "statusBar";
            // 
            // toolStripStatus_Images
            // 
            this.toolStripStatus_Images.AutoSize = false;
            this.toolStripStatus_Images.Name = "toolStripStatus_Images";
            this.toolStripStatus_Images.Size = new System.Drawing.Size(200, 33);
            this.toolStripStatus_Images.Text = "Images: 0";
            this.toolStripStatus_Images.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripDropDownLogLevel
            // 
            this.toolStripDropDownLogLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownLogLevel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownLogLevel.Image")));
            this.toolStripDropDownLogLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownLogLevel.Name = "toolStripDropDownLogLevel";
            this.toolStripDropDownLogLevel.Size = new System.Drawing.Size(336, 36);
            this.toolStripDropDownLogLevel.Text = "toolStripDropDownLogLevel";
            // 
            // toolStripLogSize
            // 
            this.toolStripLogSize.Name = "toolStripLogSize";
            this.toolStripLogSize.Size = new System.Drawing.Size(96, 33);
            this.toolStripLogSize.Text = "LogRec:";
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
            // dataGridData_filename
            // 
            this.dataGridData_filename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridData_filename.FillWeight = 50F;
            this.dataGridData_filename.HeaderText = "Name";
            this.dataGridData_filename.MinimumWidth = 100;
            this.dataGridData_filename.Name = "dataGridData_filename";
            this.dataGridData_filename.ReadOnly = true;
            // 
            // dataGridData_DateTime
            // 
            this.dataGridData_DateTime.HeaderText = "DateTime";
            this.dataGridData_DateTime.MinimumWidth = 50;
            this.dataGridData_DateTime.Name = "dataGridData_DateTime";
            this.dataGridData_DateTime.ReadOnly = true;
            this.dataGridData_DateTime.Width = 120;
            // 
            // dataGridData_Alt
            // 
            this.dataGridData_Alt.HeaderText = "Alt";
            this.dataGridData_Alt.Name = "dataGridData_Alt";
            this.dataGridData_Alt.ReadOnly = true;
            this.dataGridData_Alt.Width = 30;
            // 
            // dataGridData_Stars
            // 
            this.dataGridData_Stars.HeaderText = "Stars";
            this.dataGridData_Stars.Name = "dataGridData_Stars";
            this.dataGridData_Stars.ReadOnly = true;
            this.dataGridData_Stars.Width = 35;
            // 
            // dataGridData_FWHM
            // 
            this.dataGridData_FWHM.HeaderText = "FWHM\"";
            this.dataGridData_FWHM.Name = "dataGridData_FWHM";
            this.dataGridData_FWHM.ReadOnly = true;
            this.dataGridData_FWHM.Width = 40;
            // 
            // dataGridData_MeanRadius
            // 
            this.dataGridData_MeanRadius.HeaderText = "MeanRadius";
            this.dataGridData_MeanRadius.Name = "dataGridData_MeanRadius";
            this.dataGridData_MeanRadius.ReadOnly = true;
            this.dataGridData_MeanRadius.Width = 40;
            // 
            // dataGridData_Bg
            // 
            this.dataGridData_Bg.HeaderText = "Bg";
            this.dataGridData_Bg.Name = "dataGridData_Bg";
            this.dataGridData_Bg.ReadOnly = true;
            this.dataGridData_Bg.Width = 40;
            // 
            // dataGridData_Exp
            // 
            this.dataGridData_Exp.HeaderText = "Exposure";
            this.dataGridData_Exp.Name = "dataGridData_Exp";
            this.dataGridData_Exp.ReadOnly = true;
            this.dataGridData_Exp.Width = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(991, 69);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "and Oleg Milantiev";
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1496, 791);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ImageQualityPublisher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabLog.ResumeLayout(false);
            this.tabList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFileData)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMonitorPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChooseFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkSettings_Autostart;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.TextBox txtLastFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtStarsNum;
        private System.Windows.Forms.TextBox txtMeanRadius;
        private System.Windows.Forms.TextBox txtBgLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.DataGridView dataGridFileData;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer logRefreshTimer;
        private System.Windows.Forms.StatusStrip statusBar;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Images;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownLogLevel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLogSize;
        private System.Windows.Forms.Timer monitorTimer;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtTest;
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
        private System.Windows.Forms.Button btnSettings_Cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Alt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Stars;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_FWHM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_MeanRadius;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Bg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Exp;
        private System.Windows.Forms.Label label7;
    }
}

