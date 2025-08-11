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
    public partial class TaxPercentTypeGridControl : BOSComponent.BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.GEVATsList;
            this.DataSource = bds;   
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView.Columns)
                column.OptionsColumn.AllowEdit = true;
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gridView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(GridView_ValidatingEditor);
            gridView.InvalidValueException += new InvalidValueExceptionEventHandler(GridView_InvalidValueException);
            gridView.KeyUp += new KeyEventHandler(GridView_KeyUp);
            return gridView;
        }

        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ((CompanyConstantModule)Screen.Module).RemoveSelectedVAT();
            }
        }

        protected void GridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
        }

        protected void GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView gridView = (GridView)sender;
            string vATNo = gridView.GetFocusedRowCellValue("GEVATNo").ToString();

            if (e.Value != null)
            {
                if (gridView.FocusedColumn.FieldName == "GEVATNo")
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        e.ErrorText = CompanyConstantLocalizedResources.NotNullOrEmptyTaxNumberMessage;
                        e.Valid = false;
                    }
                    else
                    {
                        if (!vATNo.Equals(e.Value.ToString().Trim()))
                        {
                            ((CompanyConstantModule)Screen.Module).CheckVATNoConfig(e.Value.ToString().Trim(), e);
                        }
                        
                    }
                }
                if (gridView.FocusedColumn.FieldName == "GEVATPercentValue")
                {
                    double percentValue = Convert.ToDouble(e.Value);
                    if (percentValue < 0 || percentValue > 100)
                    {
                        e.ErrorText = CompanyConstantLocalizedResources.LimitOfPercentValueMessage;
                        e.Valid = false;
                        
                    }
                }
           }
        }
    }
}
