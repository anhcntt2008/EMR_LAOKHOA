using System;
using System.Collections.Generic;
using BOSComponent;
using BOSLib;
using DevExpress.XtraGrid.Views.Grid;
using Localization;

namespace BOSERP
{
    public partial class ADCriterasGridControl : BOSGridControl
    {
        public override void InitializeControl()
        {
            base.InitializeControl();
            UseEmbeddedNavigator = false;
        }

        public override void InitGridControlDataSource()
        {
            ADCriteriasInfo showAllCriteria = null;
            if (DataSource != null)
                showAllCriteria = ((List<ADCriteriasInfo>) DataSource)[0];
            var objCriteriasController = new ADCriteriasController();
            var criteriaList =
                objCriteriasController.GetAllObjectByModuleAndUser(((IBaseModuleERP) Screen.Module).ModuleID,
                    BOSApp.CurrentUsersInfo.ADUserID);
            //Add 'Show All' criteria
            if (showAllCriteria == null)
            {
                var module = (BaseModuleERP) Screen.Module;
                showAllCriteria = new ADCriteriasInfo();
                showAllCriteria.ADCriteriaName = BaseLocalizedResources.ShowAll;
                showAllCriteria.ADCriteriaQueryString =
                    module.GenerateSearchQuery(
                        BOSUtil.GetTableNameFromBusinessObject(module.CurrentModuleEntity.MainObject));
            }
            criteriaList.Insert(0, showAllCriteria);

            DataSource = criteriaList;
            RefreshDataSource();
        }

        protected override GridView InitializeGridView()
        {
            var gridView = base.InitializeGridView();
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowColumnHeaders = false;
            gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsView.ColumnAutoWidth = true;

            var column = gridView.Columns["ADCriteriaName"];
            if (column != null)
                column.VisibleIndex = 0;

            return gridView;
        }

        protected override void OnDoubleClick(EventArgs ev)
        {
            var gridView = (GridView) Views[0];
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                var objCriteriasInfo = (ADCriteriasInfo) gridView.GetRow(gridView.FocusedRowHandle);
                if (objCriteriasInfo != null)
                    if (objCriteriasInfo.ADCriteriaName == BaseLocalizedResources.ShowAll)
                        ((BaseModuleERP) Screen.Module).SearchAll(objCriteriasInfo.ADCriteriaQueryString);
                    else
                        ((BaseModuleERP) Screen.Module).SearchByQuery(objCriteriasInfo.ADCriteriaQueryString);
            }
        }
    }
}