using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using BOSCommon;
using BOSERP.Utilities;
using BOSComponent;
using System.Linq;
using System.Windows.Forms;
using Localization;
using BOSLib;

namespace BOSERP.Modules.MEParams
{
    class MEParamsModule : BaseModuleERP
    {
        private MEParamsEntities _entity;
        private MEParamsController _paramsController;
        private MEParamRelationsController _paramRelationsController;

        #region Constant
        #endregion

        #region Variable

        #endregion

        public MEParamsModule()
        {
            Name = "MEParams";
            this._paramsController = new MEParamsController();
            this._paramRelationsController = new MEParamRelationsController();
            CurrentModuleEntity = new MEParamsEntities();
            _entity = CurrentModuleEntity as MEParamsEntities;
            CurrentModuleEntity.Module = this;
            InitializeModule();
        }

        public override int ActionSave()
        {
            var meParamE = CurrentModuleEntity.MainObject as MEParamsInfo;
            if (meParamE != null && string.IsNullOrEmpty(meParamE.MEParamNo.Trim()))
            {
                MessageBox.Show("Mã thẻ không để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return base.ActionSave();
        }

        internal void DeleteParamFromRelationList()
        {
            _entity.MEParamRelationsList.RemoveSelectedRowObjectFromList();
        }
        internal void DeleteParamFromTemplateParamRelationList()
        {
            _entity.METemplateParamList.RemoveSelectedRowObjectFromList();
        }

        #region Override Search
        public override void Search()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var stateConds = GetStatePermiQueryConditionStr(TableName.MEParamsTableName, false);
                var view = BOSApp.GetUserEmrViewPermission();
                DataSet ds;
                ds = _paramsController.GetAllExMode("Report");
                Toolbar.SetToolbar(ds);
                InvalidateAfterSearch(null, string.Empty);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public override void QuickSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var stateConds = base.GetStatePermiQueryConditionStr(TableName.MEParamsTableName, false);
                var ds = new DataSet();
                var view = BOSApp.GetUserEmrViewPermission();
                ds = _paramsController.GetAllExMode("Report");
                //InvalidateSearchResult(ds);
                InvalidateAfterSearch(null, string.Empty);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                if (e is System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Có lỗi trong quá trình lấy dữ liệu. Vui lòng thử lại.");
                    return;
                }

                MessageBox.Show(e.ToString());
            }
        }
        //private void InvalidateSearchResult(DataSet ds)
        //{
        //    var preIndex = Toolbar.CurrentIndex;
        //    Toolbar.SetToolbar(ds);
        //    InvalidateAfterSearch(null, string.Empty);
        //    var searchResultControl = Controls.Values.Cast<Control>().FirstOrDefault(ctrl => (string)ctrl.Tag == BOSScreen.SearchResultControl);
        //    if (searchResultControl != null)
        //    {
        //        var control = searchResultControl as BOSSearchResultsGridControl;
        //        if (control != null)
        //            control.InvalidateLookupEditColumns();
        //    }
        //    var currID = (_entity.MainObject as MEParamsInfo)?.MEParamID;
        //    if (preIndex == 0 && Toolbar.CurrentIndex == 0 && Toolbar.CurrentObjectID != currID)
        //    {
        //        // force invalidate in case current index not change
        //        // invoke required due to cross thread exception
        //        Toolbar.Invalidate();
        //    }
        //}
        #endregion
    }
}
