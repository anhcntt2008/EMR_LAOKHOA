using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Localization;
using DevExpress.XtraGrid.Columns;

namespace BOSERP.Modules.SellStaff
{
    public partial class guiAddEmployeeState : BOSERPScreen
    {
        public int _hrEmployeeStateID { get; set; }
        public guiAddEmployeeState(DataSet dataSet)
        {
            InitializeComponent();
            this.fld_dgcHREmployeeStates.DataSource = dataSet.Tables[0];
            this.fld_dgvGridControl.Columns[0].Visible = false;
            this.fld_dgvGridControl.Columns[1].Visible = false;
            this.fld_dgvGridControl.Columns[2].Caption = "Mã trạng thái";
            this.fld_dgvGridControl.Columns[3].Caption = "Tên trạng thái";
        }

        private void fld_btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fld_txtAttributeCode.Text) || String.IsNullOrEmpty(fld_txtAttributeName.Text))
            {
                MessageBox.Show("Mã trạng thái hoặc tên trạng thái không được trống!", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HREmployeeStatesController objHREmployeeStatesController = new HREmployeeStatesController();
            HREmployeeStatesInfo newHREmployeeStatesInfo = new HREmployeeStatesInfo();
            newHREmployeeStatesInfo = (HREmployeeStatesInfo)objHREmployeeStatesController.GetObjectByName(fld_txtAttributeName.Text);
            if (_hrEmployeeStateID == 0 && newHREmployeeStatesInfo != null && newHREmployeeStatesInfo.HREmployeeStateName != "")
            {
                MessageBox.Show("Trạng thái đã tồn tại!", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void fld_dgvGridControl_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int temp = e.RowHandle;
            _hrEmployeeStateID = Convert.ToInt32(this.fld_dgvGridControl.GetRowCellValue(e.RowHandle, "HREmployeeStateID"));
            fld_txtAttributeCode.Text = this.fld_dgvGridControl.GetRowCellValue(e.RowHandle, "HREmployeeStateCode").ToString();
            fld_txtAttributeName.Text = this.fld_dgvGridControl.GetRowCellValue(e.RowHandle, "HREmployeeStateName").ToString();
        }
    }
}