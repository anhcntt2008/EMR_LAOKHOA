using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
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
using BOSLib;

namespace BOSERP
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiSelectUserGroups : BOSERPScreen
    {
        private readonly ADUserGroupsController _userGroupsCtrl;
        public List<ADUserGroupsInfo> Selections;
        public guiSelectUserGroups()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            _userGroupsCtrl = new ADUserGroupsController();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.fld_dgcUserGroups.Screen = this;
            this.fld_dgcUserGroups.InitializeControl();

            var gridView = fld_dgcUserGroups.MainView as GridView;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsCustomization.AllowFilter = true;
            gridView.OptionsView.ShowAutoFilterRow = true;

            this.fld_dgcUserGroups.DataSource = _userGroupsCtrl.GetAllObjects().Tables[0];
            this.fld_dgcUserGroups.RefreshDataSource();
            this.fld_dgcUserGroups.Refresh();
            Selections = new List<ADUserGroupsInfo>();
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
            GridView grid = fld_dgcUserGroups.MainView as GridView;
            foreach (int rowidx in grid.GetSelectedRows())
            {
                var row = grid.GetDataRow(rowidx);
                Selections.Add(_userGroupsCtrl.GetObjectFromDataRow(row as DataRow) as ADUserGroupsInfo);
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
    }
}
