using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageQuilityPublisher
{
    public partial class MainForm : Form
    {
        DSSWrapper DSSObj;


        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            DSSObj = new DSSWrapper();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DSSObj.EvaluateFile(@"d:\NGC247_20171020_R_600s_1x1_-25degC_0.0degN_000004460_c_cc_r_a.fit");
            DSSObj.GetEvaluationResults();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
