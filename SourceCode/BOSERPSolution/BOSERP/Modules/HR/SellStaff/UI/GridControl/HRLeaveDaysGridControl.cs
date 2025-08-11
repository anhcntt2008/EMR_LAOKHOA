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
using DevExpress.XtraGrid.Views.Base;
using Localization;
using System.Data;

namespace BOSERP.Modules.SellStaff
{
    public partial class HRLeaveDaysGridControl : BOSGridControl
    {
        //private DateTime FromDate = DateTime.MinValue;
        //private DateTime ToDate = DateTime.MaxValue;
        //private int Quantity = 0;
        //private string InvalidEditorValueMessage = string.Empty;
        public override void InitGridControlDataSource()
        {
            SellStaffEntities entity = (SellStaffEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.LeaveDayList;
            DataSource = bds;
        }
        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = LeaveDayLocalizedResources.TotalLeaveDays;
            column.FieldName = "TotalLeaveDays";
            gridView.Columns.Add(column);

            
        }
        //protected override GridView InitializeGridView()
        //{
        //    GridView gridView = base.InitializeGridView();
        //    //gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
        //    //gridView.KeyUp += new KeyEventHandler(DeleteSelectedLeaveDay);
        //    //Set all column is enable
        //    foreach (GridColumn column in gridView.Columns)
        //    {
        //        column.OptionsColumn.AllowEdit = true;
        //    }
        //    // Check correct from date, to date and quantity of leave days
        //    gridView.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(ValidatingLeaveDaysEditor);
        //    gridView.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(ShowInvalidEditorError);
        //    //gridView.CellValueChanged += new CellValueChangedEventHandler(InvalidateLeaveDaysGridControl);
        //    return gridView;
        //}

        ///// <summary>
        ///// Show error message of invalid leave day's values.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ShowInvalidEditorError(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        //{
        //    GridView gridView = (GridView)sender;
        //    if (gridView.FocusedColumn.FieldName == "HRLeaveDayFromDate")
        //    {
        //        InvalidEditorValueMessage = SellStaffLocalizedResource.FromDateErrorMessage;
        //    }
        //    if (gridView.FocusedColumn.FieldName == "HRLeaveDayToDate")
        //    {
        //        InvalidEditorValueMessage = SellStaffLocalizedResource.TodateErrorMessage;
        //    }
        //    if (gridView.FocusedColumn.FieldName == "HRLeaveDayQty")
        //    {
        //        InvalidEditorValueMessage = SellStaffLocalizedResource.LeaveDaysQtyErrorMessage;
        //    }
        //    e.ErrorText = InvalidEditorValueMessage;
        //    e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
        //}
        ///// <summary>
        ///// Invalidate leave day grid control to update leave day's quantity 
        ///// and leave day from date and leave day to date
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void InvalidateLeaveDaysGridControl(object sender, CellValueChangedEventArgs e)
        //{
        //    GridView gridView = (GridView)sender;
        //    if (e.Column == gridView.Columns["HRLeaveDayFromDate"])
        //    {
        //        ((SellStaffModule)Screen.Module).InvalidateLeaveDays(e.Column.FieldName, gridView.FocusedRowHandle);
        //    }
        //    if (e.Column == gridView.Columns["HRLeaveDayToDate"])
        //    {
        //        ((SellStaffModule)Screen.Module).InvalidateLeaveDays(e.Column.FieldName, gridView.FocusedRowHandle);
        //    }
        //    if (e.Column == gridView.Columns["HRLeaveDayQty"])
        //    {
        //        ((SellStaffModule)Screen.Module).InvalidateLeaveDays(e.Column.FieldName, gridView.FocusedRowHandle);
        //    }
        //    if (e.Column == gridView.Columns["HRLeaveDayType"])
        //    {
        //        ((SellStaffModule)Screen.Module).InvalidateLeaveDays(e.Column.FieldName, gridView.FocusedRowHandle);
        //    }
        //    ((SellStaffModule)Screen.Module).UpdateLeaveDayQtyOnScreen();
        //}

        ///// <summary>
        ///// Check correct from leave days to end leave days and leave day's quantity
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ValidatingLeaveDaysEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        //{
        //    GridView gridView = (GridView)sender;
        //    ColumnView colView = (ColumnView)sender;
        //    GridColumn colFromDate = colView.Columns["HRLeaveDayFromDate"];
        //    GridColumn colToDate = colView.Columns["HRLeaveDayToDate"];
        //    GridColumn colQty = colView.Columns["HRLeaveDayQty"];
        //    HRLeaveDaysInfo objLeaveDaysInfo = new HRLeaveDaysInfo();
        //    if (gridView.FocusedRowHandle >= 0)
        //    {
        //        objLeaveDaysInfo = (HRLeaveDaysInfo)gridView.GetRow(gridView.FocusedRowHandle);
        //    }
        //    if (gridView.FocusedColumn == colFromDate)
        //    {
        //        FromDate = Convert.ToDateTime(e.Value);
        //        ToDate = objLeaveDaysInfo.HRLeaveDayToDate;
        //        if (FromDate > ToDate)
        //        {
        //            e.Valid = false;
        //        }
        //    }
        //    if (gridView.FocusedColumn == colToDate)
        //    {
        //        FromDate = objLeaveDaysInfo.HRLeaveDayFromDate;
        //        ToDate = Convert.ToDateTime(e.Value);
        //        if (FromDate > ToDate)
        //        {
        //            e.Valid = false;
        //        }
        //    }
        //    if (gridView.FocusedColumn == colQty)
        //    {
        //        Quantity = Convert.ToInt32(e.Value);
        //        if (Quantity <= 0)
        //        {
        //            e.Valid = false;
        //        }
        //    }
        //}
        ///// <summary>
        ///// Delete selected item in leave day gridcontrol
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void DeleteSelectedLeaveDay(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Delete)
        //    {
        //        ((SellStaffModule)Screen.Module).RemoveItemFromLeaveDayList();
        //    }
        //}
    }
}
