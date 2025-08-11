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
using Localization;
using BOSLib;
using DevExpress.XtraGrid.Views.Base;

namespace BOSERP.Modules.SellStaff
{
    public partial class HREmployeeWorkingShiftsGridControl : BOSGridControl
    {
        private DateTime FromDate = BOSUtil.GetYearBeginDate();
        private DateTime ToDate = BOSUtil.GetYearEndDate();
        
        public override void InitGridControlDataSource()
        {
            SellStaffEntities entity = (SellStaffEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.EmployeeWorkingShiftList;
            DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            GridColumn column = gridView.Columns["FK_HRWorkingShiftID"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;

            column = gridView.Columns["HREmployeeWorkingShiftFromDate"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;

            column = gridView.Columns["HREmployeeWorkingShiftToDate"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;

            gridView.ValidatingEditor += new DevExpress.XtraEditors.Controls
                                                .BaseContainerValidateEditorEventHandler(GridView_ValidatingEditor);
            gridView.InvalidValueException += new DevExpress.XtraEditors.Controls
                                                .InvalidValueExceptionEventHandler(GridView_InvalidValueException);

            gridView.KeyUp += new KeyEventHandler(GridView_KeyUp);
            return gridView;
        }

        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ((SellStaffModule)Screen.Module).RemoveSelectedItemFromWorkingShiftGridControl();
            }
        }

        private void GridView_InvalidValueException(object sender, DevExpress.XtraEditors.Controls
                                                                                    .InvalidValueExceptionEventArgs e)
        {
            string errorMessage = string.Empty;
            GridView gridView = (GridView)sender;
            if (gridView.FocusedColumn == gridView.Columns["HREmployeeWorkingShiftFromDate"])
            {
                errorMessage = SellStaffLocalizedResource.FromDateLargerToDateErrorMessage;
            }
            if (gridView.FocusedColumn == gridView.Columns["HREmployeeWorkingShiftToDate"])
            {
                errorMessage = SellStaffLocalizedResource.ToDateLessFromDateErrorMessage;
            }
            e.ErrorText = errorMessage;
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
        }

        private void GridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls
                                                .BaseContainerValidateEditorEventArgs e)
        {
            SellStaffEntities entity = (SellStaffEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            GridView gridView = (GridView)sender;
            if (gridView.FocusedColumn == gridView.Columns["FK_HRWorkingShiftID"])
            {
                return;
            }

            ColumnView colView = (ColumnView)sender;
            GridColumn colFromDate = colView.Columns["HREmployeeWorkingShiftFromDate"];
            GridColumn colToDate = colView.Columns["HREmployeeWorkingShiftToDate"];

            HREmployeeWorkingShiftsInfo objEmployeeWorkingShiftsInfo = new HREmployeeWorkingShiftsInfo();
            if (entity.EmployeeWorkingShiftList.CurrentIndex >= 0)
            {
                objEmployeeWorkingShiftsInfo = (HREmployeeWorkingShiftsInfo)entity.EmployeeWorkingShiftList[entity.EmployeeWorkingShiftList.CurrentIndex];
            }
            if (gridView.FocusedColumn == colFromDate)
            {
                FromDate = Convert.ToDateTime(e.Value);
                ToDate = objEmployeeWorkingShiftsInfo.HREmployeeWorkingShiftToDate;
                if (FromDate > ToDate)
                {
                    e.Valid = false;
                }
            }
            if (gridView.FocusedColumn == colToDate)
            {
                FromDate = objEmployeeWorkingShiftsInfo.HREmployeeWorkingShiftFromDate;
                ToDate = Convert.ToDateTime(e.Value);
                if (FromDate > ToDate)
                {
                    e.Valid = false;
                }
            }
        }
    }
}
