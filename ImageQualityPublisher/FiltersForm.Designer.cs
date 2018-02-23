namespace ImageQualityPublisher
{
    partial class FiltersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiltersForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerBefore = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerAfter = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkFilterDate = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.chkFilterHistory = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilterInstrumeContains = new System.Windows.Forms.TextBox();
            this.txtFilterTelescopContains = new System.Windows.Forms.TextBox();
            this.txtHistoryMaxCount = new System.Windows.Forms.TextBox();
            this.txtFilterObserverContains = new System.Windows.Forms.TextBox();
            this.chkFilterInstrume = new System.Windows.Forms.CheckBox();
            this.chkFilterTelescop = new System.Windows.Forms.CheckBox();
            this.chkFilterObserver = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFilterFileNameExclude = new System.Windows.Forms.TextBox();
            this.txtFilterDirNameExclude = new System.Windows.Forms.TextBox();
            this.chkFilterExclueFileName = new System.Windows.Forms.CheckBox();
            this.chkFilterExclueDirName = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilterMinAltitude = new System.Windows.Forms.TextBox();
            this.txtFilterExcludeFiltersSt = new System.Windows.Forms.TextBox();
            this.txtFilterMaxBackground = new System.Windows.Forms.TextBox();
            this.txtFilterMinStarsCount = new System.Windows.Forms.TextBox();
            this.txtFilterMaxFWHM = new System.Windows.Forms.TextBox();
            this.chkFilterQualityMinAltitude = new System.Windows.Forms.CheckBox();
            this.chkFilterExcludeFilters = new System.Windows.Forms.CheckBox();
            this.chkFilterQualityBackgroundLevel = new System.Windows.Forms.CheckBox();
            this.chkFilterQualityFWHM = new System.Windows.Forms.CheckBox();
            this.chkFilterQualityStarsCount = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePickerBefore);
            this.groupBox1.Controls.Add(this.dateTimePickerAfter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkFilterDate);
            this.groupBox1.Location = new System.Drawing.Point(6, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date";
            // 
            // dateTimePickerBefore
            // 
            this.dateTimePickerBefore.Location = new System.Drawing.Point(260, 54);
            this.dateTimePickerBefore.Name = "dateTimePickerBefore";
            this.dateTimePickerBefore.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerBefore.TabIndex = 2;
            // 
            // dateTimePickerAfter
            // 
            this.dateTimePickerAfter.Location = new System.Drawing.Point(260, 22);
            this.dateTimePickerAfter.Name = "dateTimePickerAfter";
            this.dateTimePickerAfter.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerAfter.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "before";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "after";
            // 
            // chkFilterDate
            // 
            this.chkFilterDate.AutoSize = true;
            this.chkFilterDate.Location = new System.Drawing.Point(12, 25);
            this.chkFilterDate.Name = "chkFilterDate";
            this.chkFilterDate.Size = new System.Drawing.Size(114, 24);
            this.chkFilterDate.TabIndex = 0;
            this.chkFilterDate.Text = "Filter dates";
            this.chkFilterDate.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(524, 9);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(117, 35);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(524, 51);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(117, 35);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // chkFilterHistory
            // 
            this.chkFilterHistory.AutoSize = true;
            this.chkFilterHistory.Checked = true;
            this.chkFilterHistory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterHistory.Location = new System.Drawing.Point(12, 26);
            this.chkFilterHistory.Name = "chkFilterHistory";
            this.chkFilterHistory.Size = new System.Drawing.Size(258, 24);
            this.chkFilterHistory.TabIndex = 0;
            this.chkFilterHistory.Text = "HISTORY present less or equal";
            this.chkFilterHistory.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtFilterInstrumeContains);
            this.groupBox2.Controls.Add(this.txtFilterTelescopContains);
            this.groupBox2.Controls.Add(this.txtHistoryMaxCount);
            this.groupBox2.Controls.Add(this.txtFilterObserverContains);
            this.groupBox2.Controls.Add(this.chkFilterInstrume);
            this.groupBox2.Controls.Add(this.chkFilterTelescop);
            this.groupBox2.Controls.Add(this.chkFilterObserver);
            this.groupBox2.Controls.Add(this.chkFilterHistory);
            this.groupBox2.Location = new System.Drawing.Point(6, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 162);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FITS Header";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "times";
            // 
            // txtFilterInstrumeContains
            // 
            this.txtFilterInstrumeContains.Location = new System.Drawing.Point(212, 120);
            this.txtFilterInstrumeContains.Name = "txtFilterInstrumeContains";
            this.txtFilterInstrumeContains.Size = new System.Drawing.Size(229, 26);
            this.txtFilterInstrumeContains.TabIndex = 7;
            // 
            // txtFilterTelescopContains
            // 
            this.txtFilterTelescopContains.Location = new System.Drawing.Point(212, 88);
            this.txtFilterTelescopContains.Name = "txtFilterTelescopContains";
            this.txtFilterTelescopContains.Size = new System.Drawing.Size(229, 26);
            this.txtFilterTelescopContains.TabIndex = 5;
            // 
            // txtHistoryMaxCount
            // 
            this.txtHistoryMaxCount.Location = new System.Drawing.Point(279, 23);
            this.txtHistoryMaxCount.Name = "txtHistoryMaxCount";
            this.txtHistoryMaxCount.Size = new System.Drawing.Size(48, 26);
            this.txtHistoryMaxCount.TabIndex = 1;
            this.txtHistoryMaxCount.Text = "1";
            // 
            // txtFilterObserverContains
            // 
            this.txtFilterObserverContains.Location = new System.Drawing.Point(212, 55);
            this.txtFilterObserverContains.Name = "txtFilterObserverContains";
            this.txtFilterObserverContains.Size = new System.Drawing.Size(229, 26);
            this.txtFilterObserverContains.TabIndex = 3;
            // 
            // chkFilterInstrume
            // 
            this.chkFilterInstrume.AutoSize = true;
            this.chkFilterInstrume.Location = new System.Drawing.Point(12, 123);
            this.chkFilterInstrume.Name = "chkFilterInstrume";
            this.chkFilterInstrume.Size = new System.Drawing.Size(146, 24);
            this.chkFilterInstrume.TabIndex = 6;
            this.chkFilterInstrume.Text = "INSTRUME tag";
            this.chkFilterInstrume.UseVisualStyleBackColor = true;
            // 
            // chkFilterTelescop
            // 
            this.chkFilterTelescop.AutoSize = true;
            this.chkFilterTelescop.Location = new System.Drawing.Point(12, 91);
            this.chkFilterTelescop.Name = "chkFilterTelescop";
            this.chkFilterTelescop.Size = new System.Drawing.Size(146, 24);
            this.chkFilterTelescop.TabIndex = 4;
            this.chkFilterTelescop.Text = "TELESCOP tag";
            this.chkFilterTelescop.UseVisualStyleBackColor = true;
            // 
            // chkFilterObserver
            // 
            this.chkFilterObserver.AutoSize = true;
            this.chkFilterObserver.Location = new System.Drawing.Point(12, 58);
            this.chkFilterObserver.Name = "chkFilterObserver";
            this.chkFilterObserver.Size = new System.Drawing.Size(153, 24);
            this.chkFilterObserver.TabIndex = 2;
            this.chkFilterObserver.Text = "OBSERVER tag";
            this.chkFilterObserver.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFilterFileNameExclude);
            this.groupBox3.Controls.Add(this.txtFilterDirNameExclude);
            this.groupBox3.Controls.Add(this.chkFilterExclueFileName);
            this.groupBox3.Controls.Add(this.chkFilterExclueDirName);
            this.groupBox3.Location = new System.Drawing.Point(6, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(488, 102);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filename";
            // 
            // txtFilterFileNameExclude
            // 
            this.txtFilterFileNameExclude.Location = new System.Drawing.Point(260, 55);
            this.txtFilterFileNameExclude.Name = "txtFilterFileNameExclude";
            this.txtFilterFileNameExclude.Size = new System.Drawing.Size(200, 26);
            this.txtFilterFileNameExclude.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtFilterFileNameExclude, "multiple patterns should be separated by \";\"");
            // 
            // txtFilterDirNameExclude
            // 
            this.txtFilterDirNameExclude.Location = new System.Drawing.Point(260, 20);
            this.txtFilterDirNameExclude.Name = "txtFilterDirNameExclude";
            this.txtFilterDirNameExclude.Size = new System.Drawing.Size(200, 26);
            this.txtFilterDirNameExclude.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtFilterDirNameExclude, "multiple patterns should be separated by \";\"");
            // 
            // chkFilterExclueFileName
            // 
            this.chkFilterExclueFileName.AutoSize = true;
            this.chkFilterExclueFileName.Location = new System.Drawing.Point(12, 58);
            this.chkFilterExclueFileName.Name = "chkFilterExclueFileName";
            this.chkFilterExclueFileName.Size = new System.Drawing.Size(193, 24);
            this.chkFilterExclueFileName.TabIndex = 2;
            this.chkFilterExclueFileName.Text = "exclude from file name";
            this.chkFilterExclueFileName.UseVisualStyleBackColor = true;
            // 
            // chkFilterExclueDirName
            // 
            this.chkFilterExclueDirName.AutoSize = true;
            this.chkFilterExclueDirName.Location = new System.Drawing.Point(12, 22);
            this.chkFilterExclueDirName.Name = "chkFilterExclueDirName";
            this.chkFilterExclueDirName.Size = new System.Drawing.Size(233, 24);
            this.chkFilterExclueDirName.TabIndex = 0;
            this.chkFilterExclueDirName.Text = "exclude from directory name";
            this.chkFilterExclueDirName.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(524, 92);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 35);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtFilterMinAltitude);
            this.groupBox4.Controls.Add(this.txtFilterExcludeFiltersSt);
            this.groupBox4.Controls.Add(this.txtFilterMaxBackground);
            this.groupBox4.Controls.Add(this.txtFilterMinStarsCount);
            this.groupBox4.Controls.Add(this.txtFilterMaxFWHM);
            this.groupBox4.Controls.Add(this.chkFilterQualityMinAltitude);
            this.groupBox4.Controls.Add(this.chkFilterExcludeFilters);
            this.groupBox4.Controls.Add(this.chkFilterQualityBackgroundLevel);
            this.groupBox4.Controls.Add(this.chkFilterQualityFWHM);
            this.groupBox4.Controls.Add(this.chkFilterQualityStarsCount);
            this.groupBox4.Location = new System.Drawing.Point(6, 391);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(488, 195);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Quality Filter";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(274, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "degree";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(274, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(274, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "\"";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(274, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "stars";
            // 
            // txtFilterMinAltitude
            // 
            this.txtFilterMinAltitude.Location = new System.Drawing.Point(212, 85);
            this.txtFilterMinAltitude.Name = "txtFilterMinAltitude";
            this.txtFilterMinAltitude.Size = new System.Drawing.Size(48, 26);
            this.txtFilterMinAltitude.TabIndex = 5;
            // 
            // txtFilterExcludeFiltersSt
            // 
            this.txtFilterExcludeFiltersSt.Enabled = false;
            this.txtFilterExcludeFiltersSt.Location = new System.Drawing.Point(212, 160);
            this.txtFilterExcludeFiltersSt.Name = "txtFilterExcludeFiltersSt";
            this.txtFilterExcludeFiltersSt.Size = new System.Drawing.Size(108, 26);
            this.txtFilterExcludeFiltersSt.TabIndex = 7;
            // 
            // txtFilterMaxBackground
            // 
            this.txtFilterMaxBackground.Location = new System.Drawing.Point(212, 115);
            this.txtFilterMaxBackground.Name = "txtFilterMaxBackground";
            this.txtFilterMaxBackground.Size = new System.Drawing.Size(48, 26);
            this.txtFilterMaxBackground.TabIndex = 7;
            // 
            // txtFilterMinStarsCount
            // 
            this.txtFilterMinStarsCount.Location = new System.Drawing.Point(212, 23);
            this.txtFilterMinStarsCount.Name = "txtFilterMinStarsCount";
            this.txtFilterMinStarsCount.Size = new System.Drawing.Size(48, 26);
            this.txtFilterMinStarsCount.TabIndex = 1;
            this.txtFilterMinStarsCount.Text = "1";
            // 
            // txtFilterMaxFWHM
            // 
            this.txtFilterMaxFWHM.Location = new System.Drawing.Point(212, 54);
            this.txtFilterMaxFWHM.Name = "txtFilterMaxFWHM";
            this.txtFilterMaxFWHM.Size = new System.Drawing.Size(48, 26);
            this.txtFilterMaxFWHM.TabIndex = 3;
            // 
            // chkFilterQualityMinAltitude
            // 
            this.chkFilterQualityMinAltitude.AutoSize = true;
            this.chkFilterQualityMinAltitude.Location = new System.Drawing.Point(12, 88);
            this.chkFilterQualityMinAltitude.Name = "chkFilterQualityMinAltitude";
            this.chkFilterQualityMinAltitude.Size = new System.Drawing.Size(173, 24);
            this.chkFilterQualityMinAltitude.TabIndex = 4;
            this.chkFilterQualityMinAltitude.Text = "Altitude higher than";
            this.chkFilterQualityMinAltitude.UseVisualStyleBackColor = true;
            // 
            // chkFilterExcludeFilters
            // 
            this.chkFilterExcludeFilters.AutoSize = true;
            this.chkFilterExcludeFilters.Enabled = false;
            this.chkFilterExcludeFilters.Location = new System.Drawing.Point(12, 163);
            this.chkFilterExcludeFilters.Name = "chkFilterExcludeFilters";
            this.chkFilterExcludeFilters.Size = new System.Drawing.Size(133, 24);
            this.chkFilterExcludeFilters.TabIndex = 6;
            this.chkFilterExcludeFilters.Text = "Exclude filters";
            this.chkFilterExcludeFilters.UseVisualStyleBackColor = true;
            // 
            // chkFilterQualityBackgroundLevel
            // 
            this.chkFilterQualityBackgroundLevel.AutoSize = true;
            this.chkFilterQualityBackgroundLevel.Location = new System.Drawing.Point(12, 118);
            this.chkFilterQualityBackgroundLevel.Name = "chkFilterQualityBackgroundLevel";
            this.chkFilterQualityBackgroundLevel.Size = new System.Drawing.Size(189, 24);
            this.chkFilterQualityBackgroundLevel.TabIndex = 6;
            this.chkFilterQualityBackgroundLevel.Text = "Background less than";
            this.chkFilterQualityBackgroundLevel.UseVisualStyleBackColor = true;
            // 
            // chkFilterQualityFWHM
            // 
            this.chkFilterQualityFWHM.AutoSize = true;
            this.chkFilterQualityFWHM.Location = new System.Drawing.Point(12, 57);
            this.chkFilterQualityFWHM.Name = "chkFilterQualityFWHM";
            this.chkFilterQualityFWHM.Size = new System.Drawing.Size(153, 24);
            this.chkFilterQualityFWHM.TabIndex = 2;
            this.chkFilterQualityFWHM.Text = "FWHM less than";
            this.chkFilterQualityFWHM.UseVisualStyleBackColor = true;
            // 
            // chkFilterQualityStarsCount
            // 
            this.chkFilterQualityStarsCount.AutoSize = true;
            this.chkFilterQualityStarsCount.Checked = true;
            this.chkFilterQualityStarsCount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterQualityStarsCount.Location = new System.Drawing.Point(12, 26);
            this.chkFilterQualityStarsCount.Name = "chkFilterQualityStarsCount";
            this.chkFilterQualityStarsCount.Size = new System.Drawing.Size(193, 24);
            this.chkFilterQualityStarsCount.TabIndex = 0;
            this.chkFilterQualityStarsCount.Text = "Stars count more than";
            this.chkFilterQualityStarsCount.UseVisualStyleBackColor = true;
            // 
            // FiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 592);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FiltersForm";
            this.Text = "Filters";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FiltersForm_FormClosing);
            this.Load += new System.EventHandler(this.FiltersForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.CheckBox chkFilterHistory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkFilterInstrume;
        private System.Windows.Forms.CheckBox chkFilterTelescop;
        private System.Windows.Forms.CheckBox chkFilterObserver;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkFilterDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkFilterExclueFileName;
        private System.Windows.Forms.CheckBox chkFilterExclueDirName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkFilterQualityMinAltitude;
        private System.Windows.Forms.CheckBox chkFilterQualityBackgroundLevel;
        private System.Windows.Forms.CheckBox chkFilterQualityFWHM;
        private System.Windows.Forms.CheckBox chkFilterQualityStarsCount;
        internal System.Windows.Forms.DateTimePicker dateTimePickerBefore;
        internal System.Windows.Forms.DateTimePicker dateTimePickerAfter;
        internal System.Windows.Forms.TextBox txtFilterInstrumeContains;
        internal System.Windows.Forms.TextBox txtFilterTelescopContains;
        internal System.Windows.Forms.TextBox txtFilterObserverContains;
        internal System.Windows.Forms.TextBox txtFilterDirNameExclude;
        internal System.Windows.Forms.TextBox txtFilterFileNameExclude;
        internal System.Windows.Forms.TextBox txtFilterMinAltitude;
        internal System.Windows.Forms.TextBox txtFilterMaxBackground;
        internal System.Windows.Forms.TextBox txtFilterMinStarsCount;
        internal System.Windows.Forms.TextBox txtFilterMaxFWHM;
        internal System.Windows.Forms.TextBox txtFilterExcludeFiltersSt;
        private System.Windows.Forms.CheckBox chkFilterExcludeFilters;
        internal System.Windows.Forms.TextBox txtHistoryMaxCount;
    }
}