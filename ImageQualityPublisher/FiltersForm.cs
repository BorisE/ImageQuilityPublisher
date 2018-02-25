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
            ParentMF.EngineObj.MonitorObj.settingsFilterDate_UseFlag = chkFilterDate.Checked;
            ParentMF.EngineObj.MonitorObj.settingsFilterDateAfter = dateTimePickerAfter.Value;
            ParentMF.EngineObj.MonitorObj.settingsFilterDateBefore = dateTimePickerBefore.Value;

            //FileFilter
            ParentMF.EngineObj.MonitorObj.settingsFilterFileName_UseFlag = chkFilterExclueFileName.Checked;
            string[] FileExcl = txtFilterFileNameExclude.Text.Split(';');
            ParentMF.EngineObj.MonitorObj.settingsFilterFileName_ExcludeSt = new List<string>(FileExcl);

            //DirFilter
            ParentMF.EngineObj.MonitorObj.settingsFilterDirName_UseFlag = chkFilterExclueDirName.Checked;
            string[] DirExcl = txtFilterDirNameExclude.Text.Split(';');
            ParentMF.EngineObj.MonitorObj.settingsFilterDirName_ExcludeSt = new List<string>(DirExcl);

            //HistoryFilter
            ParentMF.EngineObj.ProcessingObj.settingsFilterHistoryTag_UseFlag = chkFilterHistory.Checked;
            if (! UInt16.TryParse (txtHistoryMaxCount.Text,out ParentMF.EngineObj.ProcessingObj.settingsFilterHistoryTag_MaxCount))
            {
                ParentMF.EngineObj.ProcessingObj.settingsFilterHistoryTag_MaxCount = 1;
            }

            //ObserverFilter
            ParentMF.EngineObj.ProcessingObj.settingsFilterObserverTag_UseFlag = chkFilterObserver.Checked;
            ParentMF.EngineObj.ProcessingObj.settingsFilterObserverTag_Contains = txtFilterObserverContains.Text;

            //TelescopeFilter
            ParentMF.EngineObj.ProcessingObj.settingsFilterTelescopTag_UseFlag = chkFilterTelescop.Checked;
            ParentMF.EngineObj.ProcessingObj.settingsFilterTelescopTag_Contains = txtFilterTelescopContains.Text;

            //InstrumeFilter
            ParentMF.EngineObj.ProcessingObj.settingsFilterInstrumeTag_UseFlag = chkFilterInstrume.Checked;
            ParentMF.EngineObj.ProcessingObj.settingsFilterInstrumeTag_Contains = txtFilterInstrumeContains.Text;

            //QualityFilters: StarsNum
            ParentMF.EngineObj.ProcessingObj.settingsFilterStarsNum_UseFlag = chkFilterQualityStarsCount.Checked;
            if (!UInt16.TryParse(txtFilterMinStarsCount.Text, out ParentMF.EngineObj.ProcessingObj.settingsFilterStarsNum_MinCount))
            {
                ParentMF.EngineObj.ProcessingObj.settingsFilterStarsNum_MinCount = 1;
            }
            //QualityFilters: FWHM
            ParentMF.EngineObj.ProcessingObj.settingsFilterFWHM_UseFlag = chkFilterQualityFWHM.Checked;
            if (!Double.TryParse(txtFilterMaxFWHM.Text, out ParentMF.EngineObj.ProcessingObj.settingsFilterFWHM_MaxVal))
            {
                ParentMF.EngineObj.ProcessingObj.settingsFilterFWHM_MaxVal = 10.0;
            }
            //QualityFilters: MinAltitude
            ParentMF.EngineObj.ProcessingObj.settingsFilterMinAltitude_UseFlag = chkFilterQualityMinAltitude.Checked;
            if (!Double.TryParse(txtFilterMinAltitude.Text, out ParentMF.EngineObj.ProcessingObj.settingsFilterMinAltitude_MinVal))
            {
                ParentMF.EngineObj.ProcessingObj.settingsFilterMinAltitude_MinVal = 19.0;
            }
            //QualityFilters: BgLevel
            ParentMF.EngineObj.ProcessingObj.settingsFilterBackground_UseFlag = chkFilterQualityBackgroundLevel.Checked;
            if (!Double.TryParse(txtFilterMaxBackground.Text, out ParentMF.EngineObj.ProcessingObj.settingsFilterBackground_MaxVal))
            {
                ParentMF.EngineObj.ProcessingObj.settingsFilterBackground_MaxVal = 30.0;
            }
            ParentMF.EngineObj.ProcessingObj.settingsFilterBackground_MaxVal = ParentMF.EngineObj.ProcessingObj.settingsFilterBackground_MaxVal / 100.0; //from percent to double

            ParentMF.Invoke(new Action(() => ParentMF.FiltersEnable()));
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ParentMF.EngineObj.MonitorObj.settingsFilterDate_UseFlag = false;

            ParentMF.EngineObj.ProcessingObj.settingsFilterHistoryTag_UseFlag = false;
            ParentMF.EngineObj.ProcessingObj.settingsFilterObserverTag_UseFlag = false;
            ParentMF.EngineObj.ProcessingObj.settingsFilterTelescopTag_UseFlag = false;
            ParentMF.EngineObj.ProcessingObj.settingsFilterInstrumeTag_UseFlag = false;

            ParentMF.Invoke(new Action(() => ParentMF.FiltersDisabe()));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
