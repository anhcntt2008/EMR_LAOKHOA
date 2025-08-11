using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.UI;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DMMEEMR101
    /// </summary>
    public partial class DMMEEMR101 : BOSERPScreen
    {
        public DMMEEMR101()
        {
            //
            // Required designer variable
            //
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
        }

        private void fld_txtMEPatientNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchPatient(this.fld_txtMEPatientNo.Text);
        }
        private void fld_tbnSearchPatientLocal_Click(object sender, EventArgs e)
        {
            SearchPatient(this.fld_txtMEPatientNo.Text);
        }

        private void SearchPatient(string text)
        {
            var gui = new guiSearchPatient(text);
            gui.Module = this.Module;
            gui.StartPosition = FormStartPosition.CenterParent;
            if (gui.ShowDialog() == DialogResult.OK)
            {
                var entity = ((MEEmrModule)Module).CurrentModuleEntity;
                var emr = entity.MainObject as MEEmrsInfo;
                entity.InvalidateModuleObject(gui.Patient);
                emr.FK_MEPatientID = gui.Patient.MEPatientID;
            }
        }

        private void fld_txtMEEmrNo2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ((MEEmrModule)Module).SearchPatientExternal(this.fld_txtMEEmrNo2.Text != "***NEW***" ? this.fld_txtMEEmrNo2.Text : string.Empty);
        }
        private void fld_tbnSearchPatientFromHis_Click(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).SearchPatientExternal(this.fld_txtMEEmrNo2.Text != "***NEW***" ? this.fld_txtMEEmrNo2.Text : string.Empty);
        }

        private void fld_lkeFK_MEPatientID1_QueryCloseUp(object sender, CancelEventArgs e)
        {
        }
        private void fld_btnTransfer_Click(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).TransferDepartment();
        }

        private void fld_btnSelectEmployee_Click(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).SelectEmployeeForShare();
        }

        private void fld_btnSelectDepartment_Click(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).SelectDepartmentForShare();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fld_lkeFK_MEEmrTypeID_EditValueChanged(object sender, EventArgs e)
        {
            var lke = (BOSComponent.BOSLookupEdit)sender;
            if (string.IsNullOrEmpty(lke.EditValue.ToString())) return;
            ((MEEmrModule)Module).ChangeEmrType((int)lke.EditValue);
        }

        private void fld_lkeFK_MEEmrTypeID_QueryCloseUp(object sender, CancelEventArgs e)
        {
        }

        private void fld_tbnSaveShareEmrClose_Click(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).ShareEmrClose();
        }

        private void fld_btnRefreshMergeHistory_Click(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).MergeEmrRefresh();
        }
    }
}
