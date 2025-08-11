using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.MEEmr;
using DevExpress.XtraGrid.Views.Grid;
using Clas.Emr.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Linq;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.ViewInfo;
using BOSCommon;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiShareEmployeeSelection : BOSERPScreen
    {
        private DataTable _data;
        public List<int> SelectedIDs;
        public string emrShareHistoryMode;
        public bool _closeEmr;
        public guiShareEmployeeSelection(DataTable data, bool closeEmr)
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            _data = data;
            _closeEmr = closeEmr;
        }
        private void Form_Load(object sender, EventArgs e)
        {
            emrShareHistoryMode = EmrShareHistoryMode.Edit.ToString();
            fld_lkeEmrShareHistoryModeEmployee.EditValue = emrShareHistoryMode;
            // US1621: Chế độ chia sẻ khi chia bệnh án đã đóng
            if (_closeEmr)
            {
                this.fld_lkeEmrShareHistoryModeEmployee.EditValue = EmrShareHistoryMode.Read.ToString();
                this.fld_lkeEmrShareHistoryModeEmployee.Enabled = false;
            }
            this.KeyPreview = true;
            this.fld_dgcEmployeeSelections.Screen = this;
            this.fld_dgcEmployeeSelections.InitializeControl();
            this.fld_dgcEmployeeSelections.DataSource = this._data;
            this.fld_dgcEmployeeSelections.RefreshDataSource();
            this.fld_dgcEmployeeSelections.Refresh();
            SelectedIDs = new List<int>();
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
        }

        private void Ok()
        {
            DialogResult = DialogResult.OK;
            emrShareHistoryMode = fld_lkeEmrShareHistoryModeEmployee.EditValue.ToString();
            GridView grid = fld_dgcEmployeeSelections.MainView as GridView;
            foreach (int rowidx in grid.GetSelectedRows())
            {
                var row = grid.GetDataRow(rowidx);
                SelectedIDs.Add(int.Parse(row["HREmployeeID"].ToString()));
            }
            this.Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DSMEEMR106_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void DSMEEMR106_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

    }
}
