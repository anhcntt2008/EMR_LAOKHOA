using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using Localization;

namespace BOSERP.Modules.CompanyConstant
{
    public partial class ICMeasureUnitsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.ICMeasureUnitsList;
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
                ((CompanyConstantModule)Screen.Module).RemoveSelectedMeasureUnit();
            }
        }

        protected void GridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
        }

        protected void GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView gridView = (GridView)sender;
            string measureUnitName = gridView.GetFocusedRowCellValue("ICMeasureUnitName").ToString();
                
            if (gridView.FocusedColumn.FieldName == "ICMeasureUnitName")
            {
                if (e.Value != null)
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        e.ErrorText = CompanyConstantLocalizedResources.NotNullOrEmptyMeasureUnitListMessage;
                        e.Valid = false;
                    }
                    else
                    {
                        if (!measureUnitName.Equals(e.Value.ToString().Trim()))
                        {
                            ((CompanyConstantModule)Screen.Module).CheckMeasureUnits(e.Value.ToString().Trim(), e);
                            
                        }
                    }
                }
            }
        }
    }
}
