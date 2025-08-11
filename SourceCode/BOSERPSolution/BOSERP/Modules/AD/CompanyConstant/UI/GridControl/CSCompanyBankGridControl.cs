using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using BOSLib;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;


namespace BOSERP.Modules.CompanyConstant
{
    public partial class CSCompanyBankGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.CSCompanyBankList;
            this.DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            
            GridColumn column = gridView.Columns["FK_GECurrenyID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["CSCompanyBankCode"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["CSCompanyBankName"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["CSCompanyBankAccount"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["IsDefault"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["FK_BRBranchID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
           
            gridView.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(GridView_CellValueChanging);
            return gridView;
        }

        private void GridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView gridView = (GridView)MainView;
            if (e.Column.FieldName == "IsDefault" && e.Value != null)
            {
                if (gridView.FocusedRowHandle >= 0)
                {
                    bool isDefault = Convert.ToBoolean(e.Value);
                    if (isDefault)
                    {
                        CSCompanyBanksInfo objCompanyBanksInfo = (CSCompanyBanksInfo)gridView.GetRow(gridView.FocusedRowHandle);
                        ((CompanyConstantModule)Screen.Module).CheckDefaultCompanyBank(objCompanyBanksInfo);
                    }
                }
            }
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            GridView gridView = (GridView)sender;
            if (e.KeyCode == Keys.Delete)
            {                
                if (gridView.FocusedRowHandle >= 0)
                {
                    ((CompanyConstantModule)Screen.Module).RemoveSelectedBank();
                }
            }
        }
    }
}
