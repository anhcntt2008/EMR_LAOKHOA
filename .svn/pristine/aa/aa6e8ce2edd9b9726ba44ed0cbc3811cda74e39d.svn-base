using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using BOSLib;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Localization;

namespace BOSERP.Modules.CompanyConstant
{
    public partial class ProductStatusGridControl : BOSComponent.BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.ProductStatusList;
            this.DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = new GridView();
            gridView.Columns.AddVisible("ADConfigText");
            gridView.OptionsView.ShowColumnHeaders = false;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gridView.KeyUp += new System.Windows.Forms.KeyEventHandler(GridView_KeyUp);
            gridView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(GridView_ValidatingEditor);
            gridView.InvalidValueException += new InvalidValueExceptionEventHandler(GridView_InvalidValueException);
            return gridView;
        }

        protected void GridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            
            e.ExceptionMode = ExceptionMode.DisplayError;
            
        }

        protected void GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView gridView = (GridView)sender;
            string configText = Convert.ToString(gridView.GetFocusedRowCellValue("ADConfigText"));
                
            if (e.Value != null)
            {
                if (gridView.FocusedColumn.FieldName == "ADConfigText")
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        e.ErrorText = CompanyConstantLocalizedResources.NotNullOrEmptyProductStatusMessage.ToString();
                        e.Valid = false;
                    }
                    else
                    {
                        if (!configText.Equals(e.Value.ToString().Trim()))
                        {
                            string configValuesType = "ProductStatus";
                            ((CompanyConstantModule)Screen.Module).CheckConfigValues(e.Value.ToString().Trim(), e, configValuesType);
                            
                        }
                    }
                }
            }
        }

        protected override void GridView_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);
            if (e.KeyCode == Keys.Delete)
            {
                ((CompanyConstantModule)Screen.Module).RemoveSelectedProductStatus();
            }
        }
    }
}
