using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.MEEmr;
using DevExpress.XtraGrid.Views.Grid;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiSearchPatientExternal : BOSERPScreen
    {
        private string patientNo;

        public guiSearchPatientExternal()
        {
            //
            // Required designer variable
            //
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
        }
        public guiSearchPatientExternal(string patientNo)
        {
            InitializeComponent();
            this.patientNo = patientNo;

        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.fld_txtSearchCriteria.Text = patientNo;
            MEEmrEntities entity = (MEEmrEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.MEPatientsSearchList.InitBOSListGridControl(fld_grdPatientSearchResult);
            entity.MEPatientsSearchList.GridControl.Screen = this;
            entity.MEPatientsSearchList.GridControl.InitializeControl();
            entity.MEPatientsSearchList.SetDefaultListAndRefreshGridControl();
            if (!string.IsNullOrEmpty(this.patientNo))
            {
                (Module as MEEmrModule).SearchPatientFromExternal(this.patientNo);
            }
            this.KeyPreview = true;
            this.fld_grdPatientSearchResult.DoubleClick += new System.EventHandler(this.fld_grdPatientSearchResult_DoubleClick);
        }
        public void Ok()
        {
            var grd = fld_grdPatientSearchResult.MainView as GridView;
            if (grd.FocusedRowHandle >= 0)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void fld_btn_Ok_Click(object sender, EventArgs e)
        {
            Ok();
        }

        private void fld_btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void fld_txtSearchCriteria_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (string.IsNullOrEmpty(this.fld_txtSearchCriteria.Text)) return;
            (Module as MEEmrModule).SearchPatientFromExternal(this.fld_txtSearchCriteria.Text);
        }

        private void fld_tbnSearchPatient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.fld_txtSearchCriteria.Text)) return;
            (Module as MEEmrModule).SearchPatientFromExternal(this.fld_txtSearchCriteria.Text);
        }

        private void fld_grdPatientSearchResult_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
