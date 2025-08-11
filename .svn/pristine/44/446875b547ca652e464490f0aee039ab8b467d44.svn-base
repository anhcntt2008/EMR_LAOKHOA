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
    public partial class HospitalRankGridControl : BOSComponent.BOSGridControl
    {

        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEHospitalRankList;
            this.DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;


            GridColumn column = gridView.Columns["MEHospitalRankNo"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;

            column = gridView.Columns["MEHospitalRankName"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            column = gridView.Columns["MEHospitalRankPlaceLevelType"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;

            gridView.InvalidRowException += new InvalidRowExceptionEventHandler(GridView_InvalidRowException);
            gridView.KeyUp += new KeyEventHandler(GridView_KeyUp);
            return gridView;
        }

        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ((CompanyConstantModule)Screen.Module).RemoveSelectedHospitalRank();
            }
        }

        protected void GridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
    }
}
