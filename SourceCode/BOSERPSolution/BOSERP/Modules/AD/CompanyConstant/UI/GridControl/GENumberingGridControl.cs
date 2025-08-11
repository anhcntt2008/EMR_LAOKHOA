using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using BOSLib;
using Localization;
using System.Linq;

namespace BOSERP.Modules.CompanyConstant
{
    public partial class GENumberingGridControl : BOSComponent.BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.GENumberingsList;
            this.DataSource = bds;           
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView.Columns)
                if (column.FieldName != "GENumberingName" && column.FieldName != "GENumberingDesc")
                    column.OptionsColumn.AllowEdit = true;
            return gridView;
        }

        protected override void GridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            base.GridView_ValidateRow(sender, e);

            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)this.MainView;
            try
            {
                object objLength = gridView.GetRowCellValue(e.RowHandle, "GENumberingLength");
                bool isError = true;

                int iLength = Convert.ToInt32(objLength);
                int iNumberingStart = Convert.ToInt32(gridView.GetRowCellValue(e.RowHandle, "GENumberingStart"));
                int iMaxValue = GetMaxValueByLength(iLength);
                int iMinValue = GetMinValueByLength(iLength);
                if (iNumberingStart <= iMaxValue)
                    isError = false;
                if (isError)
                {
                    MessageBox.Show(String.Format("Number must be less than {0}", iMaxValue), CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridView.SetRowCellValue(e.RowHandle, "GENumberingLength", GetCurrentLength(gridView.GetRowCellValue(e.RowHandle, "GENumberingName").ToString()));
                    gridView.SetRowCellValue(e.RowHandle, "GENumberingStart", GetCurrentNumberingStart(gridView.GetRowCellValue(e.RowHandle, "GENumberingName").ToString(), iLength));
                    gridView.FocusedRowHandle = e.RowHandle;
                    if (gridView.Columns["GENumberingStart"] != null)
                        gridView.FocusedColumn = gridView.Columns["GENumberingStart"];
                }
            }
            catch (Exception)
            {
                gridView.FocusedRowHandle = e.RowHandle;
                if (gridView.Columns["GENumberingLength"] != null)
                    gridView.FocusedColumn = gridView.Columns["GENumberingLength"];
            }
        }

        #region Utility Functions
        private void InitNumberingNameColumn()
        {
            DataTable tblModule = new DataTable();
            tblModule.TableName = "Module";

            DataColumn columnModuleName = new DataColumn();
            columnModuleName.ColumnName = "Name";
            columnModuleName.DataType = typeof(string);
            tblModule.Columns.Add(columnModuleName);

            DataColumn columnModuleDesc = new DataColumn();
            columnModuleDesc.ColumnName = "Desc";
            columnModuleDesc.DataType = typeof(string);
            tblModule.Columns.Add(columnModuleDesc);

            DataSet dsModules = new STModulesController().GetAllObjects();
            foreach (DataRow rowModule in dsModules.Tables[0].Rows)
            {
                STModulesInfo objSTModulesInfo = (STModulesInfo)new STModulesController().GetObjectFromDataRow(rowModule);
                if (objSTModulesInfo != null)
                {
                    String strModuleDesc = new STModuleDescriptionsController().GetDescriptionByModuleNameAndLanguageName(objSTModulesInfo.STModuleName, BOSApp.CurrentLang);
                    if (!String.IsNullOrEmpty(strModuleDesc))
                    {
                        tblModule.Rows.Add(new object[2] { objSTModulesInfo.STModuleName, strModuleDesc });
                    }

                }
            }

            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)this.MainView;
            if (gridView.Columns["GENumberingName"] != null)
            {
                DevExpress.XtraGrid.Columns.GridColumn column = gridView.Columns["GENumberingName"];
                column.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                (column.ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit).DataSource = tblModule;
                (column.ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit).DisplayMember = "Desc";
                (column.ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit).ValueMember = "Name";
            }
        }

        private int GetMaxValueByLength(int iLength)
        {
            String strMaxValue = String.Empty;
            if (iLength > 0)
            {
                for (int i = 0; i < iLength; i++)
                {
                    strMaxValue += "9";
                }
                return Convert.ToInt32(strMaxValue);
            }
            return 1;
        }

        private int GetCurrentNumberingStart(String strModuleName, int iLength)
        {
            int iCurrentNumberingStart = GetMinValueByLength(iLength);
            
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], START
            //GENumberingInfo objGENumberingInfo = (GENumberingInfo)new GENumberingController().GetObjectByName(strModuleName);
            GENumberingInfo objGENumberingInfo;
            GENumberingController objGENumberingController = new GENumberingController();
            List<GENumberingInfo> nuberingList = objGENumberingController.GetNumberingListByName(strModuleName);
            if (nuberingList.Count == 1)
            {
                objGENumberingInfo = nuberingList[0];
            }
            else
            {
                objGENumberingInfo = nuberingList.Where(i => i.FK_BRBranchID == BOSApp.CurrentCompanyInfo.FK_BRBranchID).FirstOrDefault();
            }
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], END
            if (objGENumberingInfo != null)
            {
                iCurrentNumberingStart = objGENumberingInfo.GENumberingStart;

            }

            return iCurrentNumberingStart;
        }

        private int GetCurrentLength(String strModuleName)
        {
            int iLength = 0;
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], START
            //GENumberingInfo objGENumberingInfo = (GENumberingInfo)new GENumberingController().GetObjectByName(strModuleName);
            GENumberingInfo objGENumberingInfo;
            GENumberingController objGENumberingController = new GENumberingController();
            List<GENumberingInfo> nuberingList = objGENumberingController.GetNumberingListByName(strModuleName);
            if (nuberingList.Count == 1)
            {
                objGENumberingInfo = nuberingList[0];
            }
            else
            {
                objGENumberingInfo = nuberingList.Where(i => i.FK_BRBranchID == BOSApp.CurrentCompanyInfo.FK_BRBranchID).FirstOrDefault();
            }
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], END

            if (objGENumberingInfo != null)
            {
                iLength = objGENumberingInfo.GENumberingLength;

            }

            return iLength;
        }

        private int GetMinValueByLength(int iLength)
        {
            int iMinValue = 1;
            String strMinValue = String.Empty;
            if (iLength > 1)
            {
                strMinValue = "1";
                for (int i = 1; i < iLength; i++)
                {
                    strMinValue += "0";
                }
                iMinValue = Convert.ToInt32(strMinValue);
            }
            return iMinValue;
        }

        #endregion


    }
}
