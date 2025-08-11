using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOSComponent;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Data;

namespace BOSERP.Modules.Product
{
    public partial class EditPurchasePriceByCurrencyGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            ProductEntities entity = (ProductEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.ProductPurchasePriceList;
            DataSource = bds;
        }
        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            GridColumn column = gridView.Columns["ICProductBranchPrice"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            return gridView;
        }

    }
}
