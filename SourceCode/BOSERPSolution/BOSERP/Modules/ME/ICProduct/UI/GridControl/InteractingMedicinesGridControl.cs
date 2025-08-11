using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace BOSERP.Modules.ICProduct
{
    public partial class InteractingMedicinesGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            ICProductEntities entity = (ICProductEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.InteractingProductList;
            DataSource = bds;
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            GridColumn column = gridView.Columns["FK_ICInteractingProductID"];
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
                ((ICProductModule)Screen.Module).RemoveInteractingProduct();
            }
        }
    }
}
