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
using Localization;

namespace BOSERP.Modules.CompanyConstant
{
    public partial class PriceLevelGridControl : BOSComponent.BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.ARPriceLevelsList;
            this.DataSource = bds;   
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView.Columns)
                column.OptionsColumn.AllowEdit = true;
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gridView.InvalidValueException += new InvalidValueExceptionEventHandler(GridView_InvalidValueException);
            gridView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(GridView_ValidatingEditor);
            gridView.KeyUp += new KeyEventHandler(GridView_KeyUp);
            return gridView;
        }

        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ((CompanyConstantModule)Screen.Module).RemoveSelectedPriceLevel();
            }
        }

        protected void GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView gridView = (GridView)sender;
            string priceLevelName = gridView.GetFocusedRowCellValue("ARPriceLevelName").ToString();

            if (e.Value != null)
            {
                if (gridView.FocusedColumn.FieldName == "ARPriceLevelName")
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        e.ErrorText = CompanyConstantLocalizedResources.NotNullOrEmptyPriceLevelMessage;
                        e.Valid = false;
                    }
                    else
                    {
                        if (!priceLevelName.Equals(e.Value.ToString().Trim()))
                        {
                            ((CompanyConstantModule)Screen.Module).CheckPriceNameConfig(e.Value.ToString().Trim(), e);
                            
                        }
                    }
                }
                if (gridView.FocusedColumn.FieldName == "ARPriceLevelMarkDown")
                {
                    double priceLevelMarkDown=Convert.ToDouble(e.Value);
                    if (priceLevelMarkDown < 0 || priceLevelMarkDown > 100)
                    {
                        e.ErrorText = CompanyConstantLocalizedResources.MarkdownPriceLevelMessage.ToString();
                        e.Valid = false;
                        

                    }
                }
            }
        }

        protected void GridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
        }
    }
}
