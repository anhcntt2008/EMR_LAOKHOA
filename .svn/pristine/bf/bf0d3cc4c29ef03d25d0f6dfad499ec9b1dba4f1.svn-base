using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Localization;
using BOSComponent;
using System.Data;

namespace BOSERP.Modules.Product
{
    public partial class ICProductBranchPricesGridControl  : BOSGridControl
    {        
        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.Columns.Clear();
            UseEmbeddedNavigator = false;
            return gridView;
        }

        protected override void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.GridView_CellValueChanged(sender, e);            
                        
            GridView gridView = (GridView)sender;
            if (gridView.FocusedRowHandle >= 0)
            {
                int index = gridView.GetDataSourceRowIndex(gridView.FocusedRowHandle);
                ((ProductModule)Screen.Module).ChangeProductBranchPrice(this, index, e.Column.FieldName);                
            }
        }   
    }
}
