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
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils.DragDrop;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Dynamic;
using BOSCommon;
using DevExpress.Utils.Behaviors;
using System.Linq;
using BOSERP.Modules.ME.Helpers;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiOrderAndGroupDocument : BOSERPScreen
    {
        public List<MEEmrDocumentsInfo> _data;
        private MEEmrsInfo _emr;
        public bool isChange = false;
        private int _group = 1;
        private readonly MEEmrDocumentsController _emrDocumentCtrl;
        private METemplateIndexsController _templateIndexsCtrl;
        private EmrDocumentSortHelper _emrDocumentSortHelper;
        public guiOrderAndGroupDocument(List<MEEmrDocumentsInfo> data, MEEmrsInfo emr)
        {
            _emrDocumentCtrl = new MEEmrDocumentsController();
            _templateIndexsCtrl = new METemplateIndexsController();
            _emrDocumentSortHelper = new EmrDocumentSortHelper();
            InitializeComponent();
            _data = data;
            _emr = emr;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            txtGroupRef.Text = _group.ToString();
            this.InitializeControls(this.Controls);

            var grid = this.grcData.MainView as GridView;
            grid.OptionsSelection.EnableAppearanceFocusedCell = false;
            grid.OptionsSelection.EnableAppearanceFocusedRow = true;
            grid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            grid.OptionsSelection.MultiSelect = true;
            grid.OptionsCustomization.AllowFilter = true;
            grid.OptionsView.ShowAutoFilterRow = true;

            this.KeyPreview = true;
            this.grcData.DataSource = _emrDocumentSortHelper.SortDocumentTree(_data, _emr);
            this.grcData.RefreshDataSource();
            this.grcData.Refresh();
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            // Update db select base txtgroup
            var grid = this.grcData.MainView as GridView;
            var sourceTable = (grid.GridControl.DataSource as List<MEEmrDocumentsInfo>);
            var firstIndex = -1; var count = 0;
            var rows = grid.GetSelectedRows();
            if (rows.Length == 0)
            {
                MessageBox.Show("Chọn ít nhất 01 tờ bệnh án để thực hiện thao tác.", "Chưa chọn tờ bệnh án", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var refNo = txtGroupRef.Text.ToString();
            if (string.IsNullOrEmpty(refNo))
            {
                MessageBox.Show("Nhập nhóm để thực hiện thao tác.", "Chưa nhập nhóm", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            for (int i = 0; i < sourceTable.Count; i++)
            {
                if (rows.Contains(i))
                {
                    if (firstIndex == -1) firstIndex = i;
                    var oldRow = sourceTable[i];
                    var newRow = oldRow;
                    newRow.MEEmrDocumentRefNo = refNo;
                    sourceTable.Remove(oldRow);
                    sourceTable.Insert(firstIndex + count, newRow);
                    count++;
                }
            }
            isChange = true;
            // sort sourceTable
            _data = sourceTable;

            var orderedDocs = _emrDocumentSortHelper.SortDocumentTree(sourceTable, _emr);

            grid.ClearSelection();
            grcData.DataSource = orderedDocs;
            this.grcData.RefreshDataSource();
            this.grcData.Refresh();
            _group++;
            txtGroupRef.Text = _group.ToString();
        }

        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
        }
        public void Ok()
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Ok();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
