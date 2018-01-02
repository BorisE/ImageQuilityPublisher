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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
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
            this.dataGridData_filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_Alt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_Stars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_FWHM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_MeanRadius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_Bg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridData_Exp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.logRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus_Connection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownLogLevel = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripLogSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.monitorTmer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.tabList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFileData)).BeginInit();
            this.tabSettings.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1472, 89);
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
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 109);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(25, 37);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 29);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Autorun";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1476, 418);
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
            this.groupBox3.Location = new System.Drawing.Point(11, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1473, 126);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "last image";
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
            this.tabControl1.Location = new System.Drawing.Point(3, 230);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1492, 520);
            this.tabControl1.TabIndex = 6;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.txtLog);
            this.tabLog.Location = new System.Drawing.Point(8, 39);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(1476, 473);
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
            this.tabList.Size = new System.Drawing.Size(1476, 473);
            this.tabList.TabIndex = 1;
            this.tabList.Text = "List";
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
            this.dataGridFileData.Size = new System.Drawing.Size(1476, 465);
            this.dataGridFileData.TabIndex = 4;
            // 
            // dataGridData_filename
            // 
            this.dataGridData_filename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridData_filename.FillWeight = 300F;
            this.dataGridData_filename.HeaderText = "Name";
            this.dataGridData_filename.MinimumWidth = 300;
            this.dataGridData_filename.Name = "dataGridData_filename";
            this.dataGridData_filename.ReadOnly = true;
            // 
            // dataGridData_DateTime
            // 
            this.dataGridData_DateTime.HeaderText = "DateTime";
            this.dataGridData_DateTime.MinimumWidth = 100;
            this.dataGridData_DateTime.Name = "dataGridData_DateTime";
            this.dataGridData_DateTime.ReadOnly = true;
            this.dataGridData_DateTime.Width = 150;
            // 
            // dataGridData_Alt
            // 
            this.dataGridData_Alt.HeaderText = "Alt";
            this.dataGridData_Alt.Name = "dataGridData_Alt";
            this.dataGridData_Alt.ReadOnly = true;
            this.dataGridData_Alt.Width = 50;
            // 
            // dataGridData_Stars
            // 
            this.dataGridData_Stars.HeaderText = "Stars";
            this.dataGridData_Stars.Name = "dataGridData_Stars";
            this.dataGridData_Stars.ReadOnly = true;
            this.dataGridData_Stars.Width = 50;
            // 
            // dataGridData_FWHM
            // 
            this.dataGridData_FWHM.HeaderText = "FWHM";
            this.dataGridData_FWHM.Name = "dataGridData_FWHM";
            this.dataGridData_FWHM.ReadOnly = true;
            // 
            // dataGridData_MeanRadius
            // 
            this.dataGridData_MeanRadius.HeaderText = "MeanRadius";
            this.dataGridData_MeanRadius.Name = "dataGridData_MeanRadius";
            this.dataGridData_MeanRadius.ReadOnly = true;
            this.dataGridData_MeanRadius.Width = 50;
            // 
            // dataGridData_Bg
            // 
            this.dataGridData_Bg.HeaderText = "Bg";
            this.dataGridData_Bg.Name = "dataGridData_Bg";
            this.dataGridData_Bg.ReadOnly = true;
            this.dataGridData_Bg.Width = 50;
            // 
            // dataGridData_Exp
            // 
            this.dataGridData_Exp.HeaderText = "Exposure";
            this.dataGridData_Exp.MinimumWidth = 100;
            this.dataGridData_Exp.Name = "dataGridData_Exp";
            this.dataGridData_Exp.ReadOnly = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBox2);
            this.tabSettings.Location = new System.Drawing.Point(8, 39);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(1476, 473);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
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
            this.toolStripStatus_Connection,
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
            // toolStripStatus_Connection
            // 
            this.toolStripStatus_Connection.AutoSize = false;
            this.toolStripStatus_Connection.Name = "toolStripStatus_Connection";
            this.toolStripStatus_Connection.Size = new System.Drawing.Size(200, 33);
            this.toolStripStatus_Connection.Text = "Images: 0";
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
            // monitorTmer
            // 
            this.monitorTmer.Interval = 1000;
            this.monitorTmer.Tick += new System.EventHandler(this.monitorTmer_Tick);
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
            this.Controls.Add(this.groupBox3);
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
        private System.Windows.Forms.CheckBox checkBox1;
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
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Connection;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownLogLevel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLogSize;
        private System.Windows.Forms.Timer monitorTmer;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Alt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Stars;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_FWHM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_MeanRadius;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Bg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridData_Exp;
    }
}

