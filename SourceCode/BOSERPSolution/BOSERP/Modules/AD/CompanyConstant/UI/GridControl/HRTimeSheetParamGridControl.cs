using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using BOSLib;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using System.Windows.Forms;
using BOSComponent;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using Localization;

namespace BOSERP.Modules.CompanyConstant
{
    public partial class HRTimeSheetParamGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.HRTimeSheetParamList;
            this.DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            GridColumn column = gridView.Columns["HRTimeSheetParamNo"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["HRTimeSheetParamName"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["HRTimeSheetParamType"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }     

            column = gridView.Columns["HRTimeSheetParamValue1"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["HRTimeSheetParamValue2"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["IsOTCalculated"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }                       
            return gridView;
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ((CompanyConstantModule)Screen.Module).RemoveSelectedTimeSheetParam();
            }
        }        

        protected override void GridView_ValidatingEditor(object sender,BaseContainerValidateEditorEventArgs e)
        {
            GridView gridView = (GridView)sender;
            if (e.Value != null)
            {
                if (gridView.FocusedColumn.FieldName == "HRTimeSheetParamNo")
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        e.ErrorText = CompanyConstantLocalizedResources.NotNullOrEmptyTimeSheetParamNoMessage;
                        e.Valid = false;
                    }
                }
                if (gridView.FocusedColumn.FieldName == "HRTimeSheetParamName")
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        e.ErrorText = CompanyConstantLocalizedResources.NotNullOrEmptyTimeSheetParamNameMessage;
                        e.Valid = false;
                    }
                }
            }
            
        }
    }
}
