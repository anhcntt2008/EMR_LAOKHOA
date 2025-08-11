using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Data;
using BOSLib;
using BOSComponent;
using DevExpress.XtraGrid.Columns;
using Localization;

namespace BOSERP
{
    public partial class ADCriterasGridControl : BOSGridControl
    {
        public override void InitializeControl()
        {
            base.InitializeControl();
            this.UseEmbeddedNavigator = false;
        }

        public override void InitGridControlDataSource()
        {
            ADCriteriasInfo objShowAllCriteriasInfo = null;
            if (DataSource != null)
            {
                objShowAllCriteriasInfo = ((List<ADCriteriasInfo>)DataSource)[0];
            }
            ADCriteriasController objCriteriasController = new ADCriteriasController();
            List<ADCriteriasInfo> criteriaList = objCriteriasController.GetAllObjectByModuleAndUser(((IBaseModuleERP)Screen.Module).ModuleID, BOSApp.CurrentUsersInfo.ADUserID);
            //Add 'Show All' criteria
            if (objShowAllCriteriasInfo == null)
            {
                BaseModuleERP module = (BaseModuleERP)Screen.Module;
                objShowAllCriteriasInfo = new ADCriteriasInfo();
                objShowAllCriteriasInfo.ADCriteriaName = BaseLocalizedResources.ShowAll;
                objShowAllCriteriasInfo.ADCriteriaQueryString = module.GenerateSearchQuery(BOSUtil.GetTableNameFromBusinessObject(module.CurrentModuleEntity.MainObject));
            }
            criteriaList.Insert(0, objShowAllCriteriasInfo);

            DataSource = criteriaList;
            RefreshDataSource();
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowColumnHeaders = false;
            gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsView.ColumnAutoWidth = true;
            
            GridColumn column = gridView.Columns["ADCriteriaName"];
            if (column != null)
            {
                column.VisibleIndex = 0;
            }

            return gridView;
        }
        protected override void OnDoubleClick(EventArgs ev)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)this.Views[0];
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                ADCriteriasInfo objADCriteriasInfo = (ADCriteriasInfo)gridView.GetRow(gridView.FocusedRowHandle);
                if (objADCriteriasInfo != null)
                {
                    ((BaseModuleERP)Screen.Module).SearchByCriteriaName(objADCriteriasInfo.ADCriteriaQueryString);
                }
            }
        }
    }
}
