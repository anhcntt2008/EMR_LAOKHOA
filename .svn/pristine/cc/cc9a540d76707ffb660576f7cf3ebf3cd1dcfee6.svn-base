using BOSComponent;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Localization;
using System;
using BOSCommon;

namespace BOSERP.Modules.SellStaff
{
    public partial class HRDisciplinesGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            SellStaffEntities entity = (SellStaffEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.DisciplineList;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = SellStaffLocalizedResource.HREmployeeDisciplineValue;
            column.FieldName = "HREmployeeDisciplineValue";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = SellStaffLocalizedResource.HREmployeeDisciplineValueAmount;
            column.FieldName = "HREmployeeDisciplineValueAmount";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            gridView.DoubleClick += new EventHandler(GridView_DoubleClick);
            return gridView;
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            GridView gridView = (GridView)MainView;
            if (gridView.FocusedRowHandle >= 0)
            {
                HRDisciplinesController objRewardsController = new HRDisciplinesController();
                HRDisciplinesInfo objDisciplinesInfo = (HRDisciplinesInfo)gridView.GetRow(gridView.FocusedRowHandle);
                if (objDisciplinesInfo != null)
                {
                    //BOSERP.Modules.HRDiscipline.HRDisciplineModule disciplineModule = (BOSERP.Modules.HRDiscipline.HRDisciplineModule)BOSApp.ShowModule(ModuleName.HRDiscipline);
                    //if (disciplineModule != null)
                    //{
                    //    disciplineModule.ActionInvalidate(objDisciplinesInfo.HRDisciplineID);
                    //}
                }
            }
        }
    }
}
