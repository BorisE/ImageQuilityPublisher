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

            DSSObj.EvaluateFile(@"c:\Users\Emchenko Boris\Documents\DSlrRemote\NGC247 CetusGalaxy\Attempt 2017-12-31\c_SUMs\NGC247_20170928_L_600s_1x1_-30degC_0.0degN_000003726_c_cc_r_x212.fit");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
