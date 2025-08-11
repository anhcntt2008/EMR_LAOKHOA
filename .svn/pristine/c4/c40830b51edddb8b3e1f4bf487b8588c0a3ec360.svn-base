using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using BOSComponent;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;

namespace BOSERP.Modules.SellStaff
{
    public partial class HREmployeeContactPersonsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            SellStaffEntities entity = (SellStaffEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.HREmployeeContactPersonList;
            DataSource = bds;
        }
        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            return gridView;
        }
        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
        }
        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            DevExpress.XtraGrid.Views.Base.ColumnView view = sender as DevExpress.XtraGrid.Views.Base.ColumnView;
            SellStaffEntities entity = (SellStaffEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;

            if (e.Column.FieldName == "FK_GECountryID")
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString() != string.Empty)
                    {
                        e.DisplayText = ((SellStaffModule)Screen.Module).GetCountryName(int.Parse(e.Value.ToString()));

                    }
                }
            }
            if (e.Column.FieldName == "FK_GEStateProvinceID")
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString() != string.Empty)
                    {
                        e.DisplayText = ((SellStaffModule)Screen.Module).GetProvinceName(int.Parse(e.Value.ToString()));

                    }
                }
            }
            if (e.Column.FieldName == "FK_GEDistrictID")
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString() != string.Empty)
                    {
                        e.DisplayText = ((SellStaffModule)Screen.Module).GetDisctrictName(int.Parse(e.Value.ToString()));

                    }
                }
            }
        }
    }
}
