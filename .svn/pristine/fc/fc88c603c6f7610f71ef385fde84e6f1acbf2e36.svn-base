using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BOSComponent;
using BOSLib;
using DevExpress.XtraTreeList;

namespace BOSERP
{
    public partial class BOSSearchResultsTreeListControl : BOSTreeListControl
    {
        private readonly BOSDbUtil _dbUtil;
        public BOSSearchResultsTreeListControl()
        {
            _dbUtil = new BOSDbUtil();
        }
        /// <summary>
        ///     Binding search result to the tree list control
        /// </summary>
        /// <param name="dsSearchResults">Search result data</param>
        public virtual void BindingSearchResult(DataSet dsSearchResults)
        {
            if (dsSearchResults.Tables.Count <= 0) return;
            var entity = ((BaseModuleERP) Screen.Module).CurrentModuleEntity;
            var mainObjectControllerName = BOSUtil.GetBusinessControllerNameFromBusinessObject(entity.MainObject);
            var mainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(entity.MainObject);
            var mainTablePrefix = mainObjectTableName.Substring(0, mainObjectTableName.Length - 1);
            var objCurrentObjectController =
                BusinessControllerFactory.GetBusinessController(mainObjectControllerName);

            var objects = (from DataRow row in dsSearchResults.Tables[0].Rows select (BOSTreeListObject) objCurrentObjectController.GetObjectFromDataRow(row)).ToList();

            var showAll = false;
            var count = objCurrentObjectController.GetRecordsCount();
            if (objects.Count == count)
                showAll = true;

            if (showAll)
            {
                //Remove child objects
                for (var i = 0; i < objects.Count; i++)
                {
                    var parentId = _dbUtil.GetPropertyIntValue(objects[i], mainTablePrefix + "ParentID");
                    if (parentId <= 0) continue;
                    objects.RemoveAt(i);
                    i--;
                }

                var treeList = new BOSTreeList();
                treeList.InitBOSList(entity,
                    string.Empty,
                    mainObjectTableName,
                    BOSTreeList.cstRelationNone);
                treeList.Invalidate(objects);
                DataSource = treeList;
                ExpandAll();
            }
            else
            {
                var treeList = new BOSTreeList();
                treeList.AddRange(from DataRow dr in dsSearchResults.Tables[0].Rows select (BOSTreeListObject) objCurrentObjectController.GetObjectFromDataRow(dr));
                DataSource = treeList;
                ExpandAll();
            }
        }

        public override void InitializeControl()
        {
            base.InitializeControl();

            FocusedNodeChanged += BOSSearchResultsTreeListControl_FocusedNodeChanged;
            BOSDisplayRoot = true;
        }

        protected virtual void BOSSearchResultsTreeListControl_FocusedNodeChanged(object sender,
            FocusedNodeChangedEventArgs e)
        {
           
            var obj = (BOSTreeListObject) GetDataRecordByNode(e.Node);
            var mainTableName =
                BOSUtil.GetTableNameFromBusinessObject(((BaseModuleERP) Screen.Module).CurrentModuleEntity.MainObject);
            var mainTablePrimaryColumn = _dbUtil.GetTablePrimaryColumn(mainTableName);
            var rows = Screen.Module.Toolbar.ObjectCollection.Tables[0].Rows;
            for (var i = 0; i < rows.Count; i++)
            {
                var objectId = _dbUtil.GetPropertyIntValue(obj, mainTablePrimaryColumn);
                if (objectId != Convert.ToInt32(rows[i][mainTablePrimaryColumn])) continue;
                Screen.Module.Toolbar.CurrentIndex = i;
                Screen.Module.Toolbar.Invalidate();
            }
        }
    }
}