using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using BOSLib;

namespace BOSERP.UI
{
    public partial class guiSearchPatient : BOSERPScreen
    {
        private string query;
        public MEPatientsInfo Patient;
        private readonly MEPatientsController _patientCtrl;

        public guiSearchPatient()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            _patientCtrl = new MEPatientsController();
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
                this.Ok();
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        public guiSearchPatient(string searchCriteria)
        {
            InitializeComponent();
            this.query = searchCriteria;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            _patientCtrl = new MEPatientsController();
        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.fld_txtSearchCriteria.Text = query;
            this.InitializeControls(this.Controls);
            if (!string.IsNullOrEmpty(this.query))
                SearchPatient(this.query);
            this.KeyPreview = true;
            this.fld_grdPatientSearchLocalResult.DoubleClick += new System.EventHandler(this.fld_grdPatientSearchLocalResult_DoubleClick);
            this.StartPosition = FormStartPosition.CenterParent;
        }
        public void Ok()
        {
            var grd = fld_grdPatientSearchLocalResult.MainView as GridView;
            if (grd.FocusedRowHandle >= 0)
            {
                DialogResult = DialogResult.OK;
                Patient = _patientCtrl.GetObjectFromDataRow(grd.GetDataRow(grd.FocusedRowHandle)) as MEPatientsInfo;
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
        private void SearchPatient(string query)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = this._patientCtrl.SearchByOneCriteria(query);
                fld_grdPatientSearchLocalResult.DataSource = ds.Tables[0];
                fld_grdPatientSearchLocalResult.RefreshDataSource();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            this.Activate();
        }
        private void fld_txtSearchCriteria_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (string.IsNullOrEmpty(this.fld_txtSearchCriteria.Text)) return;
            SearchPatient(this.fld_txtSearchCriteria.Text);
        }

        private void fld_tbnSearchPatient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.fld_txtSearchCriteria.Text)) return;
            SearchPatient(this.fld_txtSearchCriteria.Text);
        }

        private void fld_grdPatientSearchLocalResult_DoubleClick(object sender, EventArgs e)
        {
            Ok();
        }
    }
}
