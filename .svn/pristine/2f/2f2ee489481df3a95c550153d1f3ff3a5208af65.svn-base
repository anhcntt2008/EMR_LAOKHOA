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
using System.Drawing;

namespace BOSERP.Modules.CompanyConstant
{
    public partial class PaymentTypeGridControl : BOSComponent.BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.PaymentMethodList;
            this.DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = new GridView();
           
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            gridView.GridControl = this;
            gridView.Columns.AddVisible("ADConfigText");
            gridView.Columns.AddVisible("IsActive");
            gridView.Columns["ADConfigText"].OptionsColumn.AllowEdit = false;
            gridView.Columns["ADConfigText"].AppearanceCell.BackColor = Color.WhiteSmoke;
            gridView.OptionsView.ShowColumnHeaders = false;
            gridView.OptionsView.ShowGroupPanel = false;

            return gridView;
        }
    }
}
