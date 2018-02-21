using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageQualityPublisher
{
    public partial class FiltersForm : Form
    {
        MainForm ParentMF;

        public FiltersForm(MainForm ExtMF)
        {
            ParentMF = ExtMF;
            InitializeComponent();
        }

        private void FiltersForm_Load(object sender, EventArgs e)
        {
            //todo - load settings


        }


        private void FiltersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //DateFilter
            ParentMF.MonitorObj.settingsFilterDate_UseFlag = chkFilterDate.Checked;
            ParentMF.MonitorObj.settingsFilterDateAfter = dateTimePickerAfter.Value;
            ParentMF.MonitorObj.settingsFilterDateBefore = dateTimePickerBefore.Value;

            //HistoryFilter
            ParentMF.ProcessingObj.settingsFilterHistoryTag_UseFlag = chkFilterHistory.Checked;
            if (! UInt16.TryParse (txtHistoryMaxCount.Text,out ParentMF.ProcessingObj.settingsFilterHistoryTag_MaxCount))
            {
                ParentMF.ProcessingObj.settingsFilterHistoryTag_MaxCount = 1;
            }

            //ObserverFilter
            ParentMF.ProcessingObj.settingsFilterObserverTag_UseFlag = chkFilterObserver.Checked;
            ParentMF.ProcessingObj.settingsFilterObserverTag_Contains = txtFilterObserverContains.Text;

            //TelescopeFilter
            ParentMF.ProcessingObj.settingsFilterTelescopTag_UseFlag = chkFilterTelescop.Checked;
            ParentMF.ProcessingObj.settingsFilterTelescopTag_Contains = txtFilterTelescopContains.Text;

            //InstrumeFilter
            ParentMF.ProcessingObj.settingsFilterInstrumeTag_UseFlag = chkFilterInstrume.Checked;
            ParentMF.ProcessingObj.settingsFilterInstrumeTag_Contains = txtFilterInstrumeContains.Text;
        }


    }
}
