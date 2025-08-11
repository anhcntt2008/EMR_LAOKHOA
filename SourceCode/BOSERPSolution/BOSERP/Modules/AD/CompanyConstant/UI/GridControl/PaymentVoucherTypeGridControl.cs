using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using BOSLib;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using Localization;
using BOSComponent;

namespace BOSERP.Modules.CompanyConstant
{
    public partial class PaymentVoucherTypeGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.PaymentVoucherTypeList;
            this.DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.Columns.AddVisible("ADConfigText");
            gridView.OptionsView.ShowColumnHeaders = false;
            gridView.OptionsView.ColumnAutoWidth = true;
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            return gridView;
        }

        protected override void GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            base.GridView_ValidatingEditor(sender, e);

            GridView gridView = (GridView)sender;
            string configText = Convert.ToString(gridView.GetFocusedRowCellValue("ADConfigText"));
            if (e.Value != null)
            {
                if (gridView.FocusedColumn.FieldName == "ADConfigText")
                {
                    string value = e.Value.ToString().Trim();
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        e.ErrorText = CompanyConstantLocalizedResources.PaymentVoucherTypeIsRequiredMessage.ToString();
                        e.Valid = false;
                    }
                }
            }
        }

        protected override void GridView_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);
            if (e.KeyCode == Keys.Delete)
            {
                ((CompanyConstantModule)Screen.Module).RemoveSelectedPaymentVoucherType();
            }
        }
    }
}
