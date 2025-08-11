using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using BOSLib;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using Localization;
using DevExpress.XtraGrid.Views.Base;

namespace BOSERP.Modules.CompanyConstant
{
    public partial class WorkingShiftGridControl : BOSComponent.BOSGridControl
    {
        #region Private variables
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
        private string WorkingShiftName = String.Empty;
        private string WorkingShiftFromTime = String.Empty;
        private string WorkingShiftToTime = String.Empty;
        #endregion

        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.HRWorkingShiftList;
            this.DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            
            // repositoryItemDateEdit
            repositoryItemDateEdit.AutoHeight = false;
            repositoryItemDateEdit.DisplayFormat.FormatString = "HH:mm:ss";
            repositoryItemDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit.EditFormat.FormatString = "HH:mm:ss";
            repositoryItemDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit.Mask.EditMask = "HH:mm:ss";
            repositoryItemDateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            repositoryItemDateEdit.Name = "repositoryItemDateEdit1";

            GridColumn column = gridView.Columns["HRWorkingShiftName"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;

            column = gridView.Columns["HRWorkingShiftDesc"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;

            column = gridView.Columns["HRWorkingShiftFromTime"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = repositoryItemDateEdit;
            }

            column = gridView.Columns["HRWorkingShiftToTime"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = repositoryItemDateEdit;
            }

            gridView.InvalidRowException += new InvalidRowExceptionEventHandler(GridView_InvalidRowException);
            gridView.KeyUp += new KeyEventHandler(GridView_KeyUp);
            return gridView;
        }

        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ((CompanyConstantModule)Screen.Module).RemoveSelectedWorkingShift();
            }
        }

        protected void GridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        protected override void GridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            base.GridView_ValidateRow(sender, e);
            ColumnView view = sender as ColumnView;
            GridColumn columnWorkingShiftName = view.Columns["HRWorkingShiftName"];
            GridColumn columnWorkingShiftFromTime = view.Columns["HRWorkingShiftFromTime"];
            GridColumn columnWorkingShiftToTime = view.Columns["HRWorkingShiftToTime"];
                       
            //Get the value of columns

            string workingShiftName = view.GetRowCellValue(e.RowHandle, columnWorkingShiftName).ToString();
            string workingShiftFromTime = view.GetRowCellValue(e.RowHandle, columnWorkingShiftFromTime).ToString();
            string workingShiftToTime = view.GetRowCellValue(e.RowHandle, columnWorkingShiftToTime).ToString();

            if (string.IsNullOrEmpty(workingShiftName))
            {
                e.Valid = false;
                view.SetColumnError(columnWorkingShiftName, CompanyConstantLocalizedResources.NotNullOrEmptyWorkingShiftNameMessage); 
            }

            if (string.IsNullOrEmpty(workingShiftFromTime))
            {
                e.Valid = false;
                view.SetColumnError(columnWorkingShiftFromTime, CompanyConstantLocalizedResources.NotNullOrEmptyWorkingShiftFromTimeMessage); 
            }

            if (string.IsNullOrEmpty(workingShiftToTime))
            {
                e.Valid = false;
                view.SetColumnError(columnWorkingShiftToTime, CompanyConstantLocalizedResources.NotNullOrEmptyWorkingShiftToTimeMessage); 
            }

            

        }

      
    }
}
