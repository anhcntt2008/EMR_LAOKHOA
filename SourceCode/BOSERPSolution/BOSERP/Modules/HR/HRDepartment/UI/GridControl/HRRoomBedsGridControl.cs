using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using BOSLib;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace BOSERP.Modules.HRDepartment
{
    public partial class HRRoomBedsGridControl : BOSGridControl
    {
        /// <summary>
        /// Invalidate room bed data source
        /// </summary>
        /// <param name="dataSource">The list of room bed</param>
        public void InvalidateDataSource(IBOSList<HRRoomBedsInfo> dataSource)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = dataSource;
            DataSource = bds;
            RefreshDataSource();
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            // Set all column is enable
            foreach (GridColumn column in gridView.Columns)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            gridView.KeyUp += new KeyEventHandler(GridView_KeyUp);
            return gridView;
        }

        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ((HRDepartmentModule)Screen.Module).RemoveSelectedItemFromRoomBedList();
            }
        }
    }
}
