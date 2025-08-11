using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Windows.Forms;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace BOSERP.Modules.Product
{
    public partial class ProductSuppliersGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            ProductEntities entity = (ProductEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.ICProductSuppliersList;
            DataSource = bds;
        }
        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
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
                ((ProductModule)Screen.Module).RemoveSelectedItemFromProductSupplier(this);
            }
        }
    }
}
