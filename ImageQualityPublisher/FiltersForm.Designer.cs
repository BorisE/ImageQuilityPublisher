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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePickerBefore);
            this.groupBox1.Controls.Add(this.dateTimePickerAfter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkFilterDate);
            this.groupBox1.Location = new System.Drawing.Point(4, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(307, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date";
            // 
            // dateTimePickerBefore
            // 
            this.dateTimePickerBefore.Location = new System.Drawing.Point(160, 36);
            this.dateTimePickerBefore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerBefore.Name = "dateTimePickerBefore";
            this.dateTimePickerBefore.Size = new System.Drawing.Size(135, 20);
            this.dateTimePickerBefore.TabIndex = 2;
            // 
            // dateTimePickerAfter
            // 
            this.dateTimePickerAfter.Location = new System.Drawing.Point(160, 14);
            this.dateTimePickerAfter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerAfter.Name = "dateTimePickerAfter";
            this.dateTimePickerAfter.Size = new System.Drawing.Size(135, 20);
            this.dateTimePickerAfter.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "before";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "after";
            // 
            // chkFilterDate
            // 
            this.chkFilterDate.AutoSize = true;
            this.chkFilterDate.Location = new System.Drawing.Point(8, 16);
            this.chkFilterDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkFilterDate.Name = "chkFilterDate";
            this.chkFilterDate.Size = new System.Drawing.Size(77, 17);
            this.chkFilterDate.TabIndex = 2;
            this.chkFilterDate.Text = "Filter dates";
            this.chkFilterDate.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(327, 6);
            this.btnApply.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(78, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(327, 33);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(78, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // chkFilterHistory
            // 
            this.chkFilterHistory.AutoSize = true;
            this.chkFilterHistory.Checked = true;
            this.chkFilterHistory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterHistory.Location = new System.Drawing.Point(8, 17);
            this.chkFilterHistory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkFilterHistory.Name = "chkFilterHistory";
            this.chkFilterHistory.Size = new System.Drawing.Size(174, 17);
            this.chkFilterHistory.TabIndex = 2;
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
            this.groupBox2.Location = new System.Drawing.Point(4, 119);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(307, 105);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FITS Header";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "times";
            // 
            // txtFilterInstrumeContains
            // 
            this.txtFilterInstrumeContains.Location = new System.Drawing.Point(141, 78);
            this.txtFilterInstrumeContains.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFilterInstrumeContains.Name = "txtFilterInstrumeContains";
            this.txtFilterInstrumeContains.Size = new System.Drawing.Size(154, 20);
            this.txtFilterInstrumeContains.TabIndex = 3;
            // 
            // txtFilterTelescopContains
            // 
            this.txtFilterTelescopContains.Location = new System.Drawing.Point(141, 57);
            this.txtFilterTelescopContains.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFilterTelescopContains.Name = "txtFilterTelescopContains";
            this.txtFilterTelescopContains.Size = new System.Drawing.Size(154, 20);
            this.txtFilterTelescopContains.TabIndex = 3;
            // 
            // txtHistoryMaxCount
            // 
            this.txtHistoryMaxCount.Location = new System.Drawing.Point(186, 15);
            this.txtHistoryMaxCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtHistoryMaxCount.Name = "txtHistoryMaxCount";
            this.txtHistoryMaxCount.Size = new System.Drawing.Size(33, 20);
            this.txtHistoryMaxCount.TabIndex = 3;
            this.txtHistoryMaxCount.Text = "1";
            // 
            // txtFilterObserverContains
            // 
            this.txtFilterObserverContains.Location = new System.Drawing.Point(141, 36);
            this.txtFilterObserverContains.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFilterObserverContains.Name = "txtFilterObserverContains";
            this.txtFilterObserverContains.Size = new System.Drawing.Size(154, 20);
            this.txtFilterObserverContains.TabIndex = 3;
            // 
            // chkFilterInstrume
            // 
            this.chkFilterInstrume.AutoSize = true;
            this.chkFilterInstrume.Location = new System.Drawing.Point(8, 80);
            this.chkFilterInstrume.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkFilterInstrume.Name = "chkFilterInstrume";
            this.chkFilterInstrume.Size = new System.Drawing.Size(101, 17);
            this.chkFilterInstrume.TabIndex = 2;
            this.chkFilterInstrume.Text = "INSTRUME tag";
            this.chkFilterInstrume.UseVisualStyleBackColor = true;
            // 
            // chkFilterTelescop
            // 
            this.chkFilterTelescop.AutoSize = true;
            this.chkFilterTelescop.Location = new System.Drawing.Point(8, 59);
            this.chkFilterTelescop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkFilterTelescop.Name = "chkFilterTelescop";
            this.chkFilterTelescop.Size = new System.Drawing.Size(100, 17);
            this.chkFilterTelescop.TabIndex = 2;
            this.chkFilterTelescop.Text = "TELESCOP tag";
            this.chkFilterTelescop.UseVisualStyleBackColor = true;
            // 
            // chkFilterObserver
            // 
            this.chkFilterObserver.AutoSize = true;
            this.chkFilterObserver.Location = new System.Drawing.Point(8, 38);
            this.chkFilterObserver.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkFilterObserver.Name = "chkFilterObserver";
            this.chkFilterObserver.Size = new System.Drawing.Size(103, 17);
            this.chkFilterObserver.TabIndex = 2;
            this.chkFilterObserver.Text = "OBSERVER tag";
            this.chkFilterObserver.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(4, 72);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(307, 43);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filename";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "exclude from directory name";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(157, 13);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 20);
            this.textBox1.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(327, 60);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 227);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FiltersForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Filters";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FiltersForm_FormClosing);
            this.Load += new System.EventHandler(this.FiltersForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerBefore;
        private System.Windows.Forms.DateTimePicker dateTimePickerAfter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.CheckBox chkFilterHistory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFilterInstrumeContains;
        private System.Windows.Forms.TextBox txtFilterTelescopContains;
        private System.Windows.Forms.TextBox txtFilterObserverContains;
        private System.Windows.Forms.CheckBox chkFilterInstrume;
        private System.Windows.Forms.CheckBox chkFilterTelescop;
        private System.Windows.Forms.CheckBox chkFilterObserver;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHistoryMaxCount;
        private System.Windows.Forms.CheckBox chkFilterDate;
        private System.Windows.Forms.Button btnClose;
    }
}