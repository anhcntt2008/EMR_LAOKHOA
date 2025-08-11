using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using BOSLib;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils;
using Localization;
using DevExpress.XtraEditors;
using BOSCommon;

//NUThao [ADD] [23/11/2013] [DB centre] [Permission configuration], START
namespace BOSERP.Modules.UserManagement
{    
    public partial class ADDataViewPermissionsGridControl : BOSGridControl
    {
        /// <summary>
        /// Gets or sets the grid view main
        /// </summary>
        public GridView GridViewMain { get; set; }

        public override void InitializeControl()
        {            
            base.InitializeControl();
            BandedGridView bandedView = InitializeBandedGridView(GridViewMain);
            bandedView.CellValueChanging += new CellValueChangedEventHandler(bandedView_CellValueChanging);
            MainView = bandedView;
            ViewCollection.AddRange(new BaseView[] { bandedView });
        }

        void bandedView_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {            
            GridView gridView = (GridView)sender;

            DataRowView obj = (System.Data.DataRowView)gridView.GetRow(e.RowHandle);
            if (obj != null)
            {
                DataRow row = obj.Row;
                if (row != null)
                {
                    bool currentValue = (bool)row[gridView.FocusedColumn.FieldName];
                    row[gridView.FocusedColumn.FieldName] = !currentValue;

                    if (gridView.FocusedColumn.FieldName == ADDataViewPermissionColumnNames.RowSelection)
                    {
                        if (e.RowHandle == 0)
                            ((UserManagementModule)Screen.Module).SelectAll(!currentValue);
                        else
                            ((UserManagementModule)Screen.Module).SelectFullRow(obj.Row);
                    }
                    else if (gridView.FocusedColumn.FieldName != ADDataViewPermissionColumnNames.ADUserGroupSectionName &&
                        gridView.FocusedColumn.FieldName != ADDataViewPermissionColumnNames.STModuleName &&
                        gridView.FocusedColumn.FieldName != ADDataViewPermissionColumnNames.RowSelection)
                    {
                        if(e.RowHandle == 0)
                            ((UserManagementModule)Screen.Module).SelectFullColumn(gridView.FocusedColumn.FieldName, !currentValue);
                        else
                            ((UserManagementModule)Screen.Module).SelectionChanged(row, gridView.FocusedColumn.FieldName, !currentValue);
                    }                       
                }
            }
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            GridViewMain = gridView;          
            return gridView;
        }

        public override void InitGridControlDataSource()
        {
            BindingSource bds = new BindingSource();

            bds.DataSource = ((UserManagementModule)Screen.Module).InitProductLocationBranchPricesDataSource();
            this.DataSource = bds;        
        }


        public void RefreshDataSource(DataTable datatable)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = datatable;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
         

        }

        private BandedGridView InitializeBandedGridView(GridView gridView)
        {
            UserManagementModule module = (UserManagementModule)Screen.Module;
            return module.InitBandedGridView(gridView);
        }

    }
}
//NUThao [ADD] [23/11/2013] [DB centre] [Permission configuration], END
