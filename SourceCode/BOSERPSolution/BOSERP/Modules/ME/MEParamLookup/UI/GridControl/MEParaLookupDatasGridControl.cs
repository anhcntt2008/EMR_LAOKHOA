using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using Localization;
using BOSCommon;
using System.Drawing;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.Data;
using System.Reflection;

namespace BOSERP.Modules.MEParamLookup
{
    public partial class MEParamLookupDatasGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            MEParamLookupEntities entity = (MEParamLookupEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEParamLookupDataList;
            DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            GridColumn column = gridView.Columns["FK_MEParamLookupID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEParamLookupDataKey"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEParamLookupDataOrder"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEParamLookupDataText"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEParamLookupDataValue"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEParamLookupDataGroup"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEParamLookupDataGroup1"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEParamLookupDataGroup2"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEParamLookupDataEncode"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["FK_METemplate1ID"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            column = gridView.Columns["FK_METemplate2ID"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            column = gridView.Columns["FK_METemplate3ID"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            column = gridView.Columns["FK_METemplate4ID"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            column = gridView.Columns["FK_METemplate5ID"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;

            column = gridView.Columns["FK_MEEmrSymbolID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEParamLookupDataEmrType"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            return gridView;
        }
        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((MEParamLookupModule)Screen.Module).DeleteLookupData();
            }
        }
    }
}