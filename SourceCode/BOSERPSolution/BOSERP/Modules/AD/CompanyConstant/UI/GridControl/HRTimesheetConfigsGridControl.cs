using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using BOSLib;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Localization;


namespace BOSERP.Modules.CompanyConstant
{
    public partial class HRTimesheetConfigsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.HRTimesheetConfigList;
            this.DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            foreach (GridColumn col in gridView.Columns)
            {
                col.OptionsColumn.AllowEdit = true;
            }

            GridColumn c = new GridColumn();
            c.FieldName = "HRTimesheetGroupName";
            c.Caption = "Tên nhóm";
            c.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(c);
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
           
            gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(GridView_CellValueChanging);
            return gridView;
        }

        private void GridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView gridView = (GridView)MainView;
            if (MessageBox.Show("Bạn có muốn áp dụng cho tất cả các tháng khác?",
                CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                HRTimesheetConfigsInfo obj = (HRTimesheetConfigsInfo)gridView.GetRow(e.RowHandle);
                obj.HRTimesheetConfigJan = obj.HRTimesheetConfigFeb = obj.HRTimesheetConfigApr = obj.HRTimesheetConfigAug =
                    obj.HRTimesheetConfigDec = obj.HRTimesheetConfigJul = obj.HRTimesheetConfigJun = obj.HRTimesheetConfigMar =
                    obj.HRTimesheetConfigMay = obj.HRTimesheetConfigNov = obj.HRTimesheetConfigOct = obj.HRTimesheetConfigSep = int.Parse(e.Value.ToString());
            }
        }
    }
}
