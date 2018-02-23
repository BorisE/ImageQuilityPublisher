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

            //FileFilter
            ParentMF.MonitorObj.settingsFilterFileName_UseFlag = chkFilterExclueFileName.Checked;
            string[] FileExcl = txtFilterFileNameExclude.Text.Split(';');
            ParentMF.MonitorObj.settingsFilterFileName_ExcludeSt = new List<string>(FileExcl);

            //DirFilter
            ParentMF.MonitorObj.settingsFilterDirName_UseFlag = chkFilterExclueDirName.Checked;
            string[] DirExcl = txtFilterDirNameExclude.Text.Split(';');
            ParentMF.MonitorObj.settingsFilterDirName_ExcludeSt = new List<string>(DirExcl);

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

            //QualityFilters: StarsNum
            ParentMF.ProcessingObj.settingsFilterStarsNum_UseFlag = chkFilterQualityStarsCount.Checked;
            if (!UInt16.TryParse(txtFilterMinStarsCount.Text, out ParentMF.ProcessingObj.settingsFilterStarsNum_MinCount))
            {
                ParentMF.ProcessingObj.settingsFilterStarsNum_MinCount = 1;
            }
            //QualityFilters: FWHM
            ParentMF.ProcessingObj.settingsFilterFWHM_UseFlag = chkFilterQualityFWHM.Checked;
            if (!Double.TryParse(txtFilterMaxFWHM.Text, out ParentMF.ProcessingObj.settingsFilterFWHM_MaxVal))
            {
                ParentMF.ProcessingObj.settingsFilterFWHM_MaxVal = 10.0;
            }
            //QualityFilters: MinAltitude
            ParentMF.ProcessingObj.settingsFilterMinAltitude_UseFlag = chkFilterQualityMinAltitude.Checked;
            if (!Double.TryParse(txtFilterMinAltitude.Text, out ParentMF.ProcessingObj.settingsFilterMinAltitude_MinVal))
            {
                ParentMF.ProcessingObj.settingsFilterMinAltitude_MinVal = 19.0;
            }
            //QualityFilters: BgLevel
            ParentMF.ProcessingObj.settingsFilterBackground_UseFlag = chkFilterQualityBackgroundLevel.Checked;
            if (!Double.TryParse(txtFilterMaxBackground.Text, out ParentMF.ProcessingObj.settingsFilterBackground_MaxVal))
            {
                ParentMF.ProcessingObj.settingsFilterBackground_MaxVal = 0.30;
            }

            ParentMF.Invoke(new Action(() => ParentMF.FiltersEnable()));
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ParentMF.MonitorObj.settingsFilterDate_UseFlag = false;

            ParentMF.ProcessingObj.settingsFilterHistoryTag_UseFlag = false;
            ParentMF.ProcessingObj.settingsFilterObserverTag_UseFlag = false;
            ParentMF.ProcessingObj.settingsFilterTelescopTag_UseFlag = false;
            ParentMF.ProcessingObj.settingsFilterInstrumeTag_UseFlag = false;

            ParentMF.Invoke(new Action(() => ParentMF.FiltersDisabe()));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
