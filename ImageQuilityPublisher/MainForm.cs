using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageQualityPublisher
{
    public partial class MainForm : Form
    {
        public MonitorClass Monitor;

        public FITSHeaderParser FITSobj;

        public MainForm()
        {
            Monitor = new MonitorClass(this);
            FITSobj = new FITSHeaderParser();

            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            DefBackColor = btnExit.BackColor;

            //Load config
            ConfigManagement.Load();

            //Load parameters
            //LoadParams();


            //Dump log, because interface may hang wating for connection
            Logging.DumpToFile();


            Monitor.FileMonitorPath = @"d:\2";
            txtMonitorPath.Text = Monitor.FileMonitorPath;

            //Init Log DropDown box
            foreach (LogLevel C in Enum.GetValues(typeof(LogLevel)))
            {
                toolStripDropDownLogLevel.DropDownItems.Add(Enum.GetName(typeof(LogLevel), C));
            }
            toolStripDropDownLogLevel.Text = Enum.GetName(typeof(LogLevel), LogLevel.Activity);


            //Run all timers at the end
            logRefreshTimer.Enabled = true;

        }

        Color OnColor = Color.DarkSeaGreen;
        Color DefBackColor;

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (monitorTmer.Enabled)
            // if runnig - stop
            {
                monitorTmer.Enabled = false;
                btnStart.Text = "Start";
                btnStart.BackColor = DefBackColor;
            }
            else
            {
                monitorTmer.Enabled = true;
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

        public void PublishQualityData(string LastImageName, FITSQualityData LastImageQuality)
        {
            txtLastFileName.Text = LastImageName;

            txtBgLevel.Text = LastImageQuality.SkyBackground.ToString();
            txtMeanRadius.Text = LastImageQuality.MeanRadius.ToString();
            txtStarsNum.Text = LastImageQuality.StarsNumber.ToString();
            txtSumMeas.Text = LastImageQuality.MeanRadiusSum.ToString();
            txtNumMeasur.Text = LastImageQuality.MeanRadiusNum.ToString();

            int curRowIndex = dataGridFileData.Rows.Add();
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_filename"].Value = Path.GetFileName(LastImageName);
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_Bg"].Value = LastImageQuality.SkyBackground.ToString();
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_MeanRadius"].Value = LastImageQuality.MeanRadius.ToString();
            dataGridFileData.Rows[curRowIndex].Cells["dataGridData_Stars"].Value = LastImageQuality.StarsNumber.ToString();

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
                Monitor.FileMonitorPath = txtMonitorPath.Text;
                Monitor.ClearFileList(); //очисить список
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

                Monitor.CheckForNewFiles();
                
                AlreadyRunning = false;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            FITSobj.ReadFITSHeader(@"d:\2\NGC247_20171212_L_600s_1x1_-30degC_0.0degN_000005308.FIT");
        }
    }
}
