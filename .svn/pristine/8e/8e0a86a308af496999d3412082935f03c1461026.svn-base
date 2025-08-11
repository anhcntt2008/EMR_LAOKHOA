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
using Clas.Emr.Core;
using BOSCommon;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiSignerRolesSelection : BOSERPScreen
    {
        private Dictionary<string, List<EmrField>> roles;
        public List<string> SelectedRoles;
        private readonly bool _multiSelect;

        public guiSignerRolesSelection(Dictionary<string, List<EmrField>> roles, bool multiSelect = true)
        {
            this.roles = roles;
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            _multiSelect = multiSelect;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            GridView grid = fld_dgcSignerRoleSelections.MainView as GridView;
            grid.OptionsSelection.EnableAppearanceFocusedCell = false;
            grid.OptionsSelection.EnableAppearanceFocusedRow = true;
            grid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            grid.OptionsSelection.MultiSelect = _multiSelect;
            grid.OptionsBehavior.Editable = false;
            grid.OptionsView.ShowGroupPanel = false;

            var col = grid.Columns.Add();
            col.Visible = true;
            col.FieldName = col.Name = "MEParamNo";
            col.Caption = "Mã vai trò";

            col = grid.Columns.Add();
            col.FieldName = col.Name = "MEParamName";
            col.Caption = "Tên vai trò";
            col.Visible = true;

            var list = new List<MEParamsInfo>();
            foreach (var item in roles)
            {
                if (item.Key == EmrParam.Anonymous)
                    list.Add(new MEParamsInfo()
                    {
                        MEParamNo = EmrParam.Anonymous,
                        MEParamName = "Không xác định"
                    });
                else
                {
                    var param = AppMemCache.GetParamFromDictKeyNo(item.Key);
                    if (param == null)
                    {
                        param = new MEParamsInfo()
                        {
                            MEParamNo = item.Key,
                            MEParamName = $"Không tìm thấy thẻ {item.Key} trong cơ sở dữ liệu",
                            MEParamCaption = $"Không tìm thấy thẻ {item.Key} trong cơ sở dữ liệu",
                        };
                    }
                    list.Add(param);
                }
            }
            this.fld_dgcSignerRoleSelections.DataSource = list;
            this.fld_dgcSignerRoleSelections.RefreshDataSource();
            this.fld_dgcSignerRoleSelections.Refresh();
            SelectedRoles = new List<string>();
            grid.BestFitColumns();
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
            GridView grid = fld_dgcSignerRoleSelections.MainView as GridView;
            if (grid.GetSelectedRows().Count() == 0)
            {
                MessageBox.Show("Chọn ít nhất 01 vai trò cho 01 lần ký", "Chọn lại vai trò", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (int rowidx in grid.GetSelectedRows())
            {
                var row = grid.GetRow(rowidx) as MEParamsInfo;
                SelectedRoles.Add(row.MEParamNo.ToString());
            }
            DialogResult = DialogResult.OK;
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
