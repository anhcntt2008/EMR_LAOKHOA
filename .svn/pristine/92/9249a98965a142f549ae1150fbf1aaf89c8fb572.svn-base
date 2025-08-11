using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Windows.Forms;
using BOSComponent;
using BOSLib;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Localization;
using BOSCommon;

namespace BOSERP.Modules.UserManagement
{
    public partial class ADUserExtrasOfGroupGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource
            {
                DataSource = entity.ADUserExtraOfGroupList
            };
            DataSource = bds;
        }
        protected override GridView InitializeGridView()
        {
            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            GridColumn column = gridView.Columns["FK_ADUserID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                var rep = new RepositoryItemBOSLookupEdit
                {
                    TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard,
                    SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter,
                    NullText = string.Empty,
                    BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup,
                    ValueMember = "ADUserID",
                    DisplayMember = "ADUserName",
                    DataSource = entity.ADUserList
                };
                var colName = new DevExpress.XtraEditors.Controls.LookUpColumnInfo
                {
                    Caption = "Tên người dùng",
                    FieldName = rep.DisplayMember,
                    Width = 100
                };
                rep.Columns.Add(colName);
                column.ColumnEdit = rep;
            }
            column = gridView.Columns["ADUserGroupExtraDateAdd"];
            if (column != null)
            {
                column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                column.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            }
            return gridView;
        }
        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
        }
        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((UserManagementModule)Screen.Module).DeleteUserExtraOfGroupList();
            }
        }
    }
}
