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
            this.comboBoxDatesSinceType = new System.Windows.Forms.ComboBox();
            this.numericUpDownNumDatesSince = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerBefore = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerAfter = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.bntCancel = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumDatesSince)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxDatesSinceType);
            this.groupBox1.Controls.Add(this.numericUpDownNumDatesSince);
            this.groupBox1.Controls.Add(this.dateTimePickerBefore);
            this.groupBox1.Controls.Add(this.dateTimePickerAfter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date";
            // 
            // comboBoxDatesSinceType
            // 
            this.comboBoxDatesSinceType.FormattingEnabled = true;
            this.comboBoxDatesSinceType.Items.AddRange(new object[] {
            "Days",
            "Weeks",
            "Month"});
            this.comboBoxDatesSinceType.Location = new System.Drawing.Point(467, 40);
            this.comboBoxDatesSinceType.Name = "comboBoxDatesSinceType";
            this.comboBoxDatesSinceType.Size = new System.Drawing.Size(121, 28);
            this.comboBoxDatesSinceType.TabIndex = 4;
            this.comboBoxDatesSinceType.Text = "Days";
            // 
            // numericUpDownNumDatesSince
            // 
            this.numericUpDownNumDatesSince.Location = new System.Drawing.Point(341, 42);
            this.numericUpDownNumDatesSince.Name = "numericUpDownNumDatesSince";
            this.numericUpDownNumDatesSince.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownNumDatesSince.TabIndex = 3;
            // 
            // dateTimePickerBefore
            // 
            this.dateTimePickerBefore.Location = new System.Drawing.Point(106, 55);
            this.dateTimePickerBefore.Name = "dateTimePickerBefore";
            this.dateTimePickerBefore.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerBefore.TabIndex = 2;
            // 
            // dateTimePickerAfter
            // 
            this.dateTimePickerAfter.Location = new System.Drawing.Point(106, 23);
            this.dateTimePickerAfter.Name = "dateTimePickerAfter";
            this.dateTimePickerAfter.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerAfter.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "before";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "after";
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(682, 26);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(117, 35);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // bntCancel
            // 
            this.bntCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntCancel.Location = new System.Drawing.Point(682, 72);
            this.bntCancel.Name = "bntCancel";
            this.bntCancel.Size = new System.Drawing.Size(117, 35);
            this.bntCancel.TabIndex = 1;
            this.bntCancel.Text = "Cancel";
            this.bntCancel.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(19, 38);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(192, 24);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "HISTORY not present";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(623, 132);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FITS Header";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "exclude from directory name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(232, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(356, 26);
            this.textBox1.TabIndex = 3;
            // 
            // FiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 279);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bntCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox1);
            this.Name = "FiltersForm";
            this.Text = "FiltersForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FiltersForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumDatesSince)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxDatesSinceType;
        private System.Windows.Forms.NumericUpDown numericUpDownNumDatesSince;
        private System.Windows.Forms.DateTimePicker dateTimePickerBefore;
        private System.Windows.Forms.DateTimePicker dateTimePickerAfter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button bntCancel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}