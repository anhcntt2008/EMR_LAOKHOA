using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using Localization;
using BOSERP.Modules.ME.ICProduct.Localization;

namespace BOSERP.Modules.ICProduct
{
    public partial class ProductAccountsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            ICProductEntities entity = (ICProductEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.ICProductAccountList;
            DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            GridColumn column = gridView.Columns["FK_ACAccountID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            return gridView;
        }

        protected override void GridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView gridView = (GridView)MainView;
            if (e.Value != null)
            {
                if (gridView.FocusedColumn.FieldName == "FK_ACAccountID")
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        e.ErrorText = ProductLocalizedResources1.NotNullOrEmptyAccountMessage;
                        e.Valid = false;
                    }
                    else
                    {
                        ((ICProductModule)Screen.Module).CheckExistComponent(Convert.ToInt32(e.Value), e);
                    }
                }
            }
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((ICProductModule)Screen.Module).DeleteItemFromProductAccountList();
            }
        }
    }
}
