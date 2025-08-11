using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using BOSLib;
using BOSCommon;
using Localization;

namespace BOSERP
{
    public class BOSItemsEntityList<T> : BOSList<T>
        where T : ERPModuleItemsEntity, new()
    {
        #region Invalidate
        public override void Invalidate(DataSet ds)
        {
            BaseBusinessController objItemController = BusinessControllerFactory.GetBusinessController(ItemTableName + "Controller");
            this.Clear();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    BusinessObject objItemInfo = (BusinessObject)objItemController.GetObjectFromDataRow(row);
                    T objT = new T();
                    (objT as ERPModuleItemsEntity).GetFromBusinessObject(objItemInfo);
                    this.Add(objT);
                }
            }

            //Invalidate original list same as itself
            OriginalList.Clear();
            foreach (T obj in this)
                OriginalList.Add((T)obj.Clone());

            if (GridControl != null)
            {
                GridControl.RefreshDataSource();
                if (this.Count > 0)
                {
                    GridViewFocusRow(0);
                }
                else
                {
                    Entity.InvalidateModuleObject(BusinessObjectFactory.GetBusinessObject(ItemTableName + "Info"));
                }
            }
        }

        public virtual void InvalidateAndNotUpdateModuleObjects(int iObjectID)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            String strMainTableName = BOSUtil.GetTableNameFromBusinessObject(Entity.MainObject);
            BaseBusinessController objItemController = BusinessControllerFactory.GetBusinessController(ItemTableName + "Controller");
            DataSet ds = new DataSet();

            if (Relation.Equals(cstRelationForeign))
            {
                ds = objItemController.GetAllDataByForeignColumn(ItemTableForeignKey, iObjectID);

            }
            else if (Relation.Equals(cstRelationParent))
            {
                ds = objItemController.GetAllObjectsByObjectParentID(iObjectID);
            }

            this.Clear();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    BusinessObject objItemInfo = (BusinessObject)objItemController.GetObjectFromDataRow(row);
                    T objT = new T();
                    (objT as ERPModuleItemsEntity).GetFromBusinessObject(objItemInfo);
                    this.Add(objT);
                }
            }
        }
        
        #endregion

        #region Save List
        public override T SaveObjectToList(bool IsNew)
        { 
            //Invalidate look up edit columns
            if (GridControl != null)
                GridControl.InvalidateLookupEditColumns();

            BOSDbUtil dbUtil = new BOSDbUtil();
            T objT = new T();

            (objT as ERPModuleItemsEntity).GetFromBusinessObject(Entity.ModuleObjects[ItemTableName]);

            if (IsNew)
            {
                String strPrimaryKey = ItemTableName.Substring(0, ItemTableName.Length - 1) + "ID";
                dbUtil.SetPropertyValue(objT, strPrimaryKey, 0);
                this.Add(objT);
            }
            else
            {
                if (CurrentIndex >= 0)
                    this[CurrentIndex] = objT;
            }
            return objT;
        }
        #endregion

        #region GridControl,GridView event handlers
        protected override void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)GridControl.Views[0];
            if (this.Count > 0)
                if (CurrentIndex >= 0)
                {
                    String strMainTableName = String.Empty;
                    if (Entity.MainObject != null)
                        strMainTableName = BOSUtil.GetTableNameFromBusinessObject(Entity.MainObject);

                    if (ItemTableName.Equals(strMainTableName))
                    {
                        Entity.MainObject = (BusinessObject)this[CurrentIndex].Clone();
                        Entity.UpdateMainObjectBindingSource();
                    }
                    else
                    {
                        Entity.InvalidateModuleObject((T)this[CurrentIndex].Clone(), ItemTableName);                        
                        BOSDbUtil dbUtil = new BOSDbUtil();                        
                        int productID = dbUtil.GetPropertyIntValue(this[CurrentIndex], "FK_ICProductID");
                        Entity.Module.ShowInventory(productID);                       
                    }                    
                }
        }

        public override void GridViewFocusRow(int iRowHandle)
        {
            GridView.FocusedRowHandle = iRowHandle;
            if (CurrentIndex >= 0)
            {
                Entity.InvalidateModuleObject((T)this[CurrentIndex].Clone(), ItemTableName);
                BOSDbUtil dbUtil = new BOSDbUtil();
                int productID = dbUtil.GetPropertyIntValue(this[CurrentIndex], "FK_ICProductID");
                Entity.Module.ShowInventory(productID);
            }
        }       
        #endregion

        #region Save List, Delete List to database
        public override void SaveItemObjects()
        {
            try
            {
                EndCurrentEdit();

                BOSDbUtil dbUtil = new BOSDbUtil();
                String strItemTablePrimaryKey = dbUtil.GetTablePrimaryColumn(ItemTableName);
                BaseBusinessController objItemsController = BusinessControllerFactory.GetBusinessController(ItemTableName + "Controller");

                foreach (T objT in this)
                {
                    BusinessObject obj = objT.SetToBusinessObject(ItemTableName);
                    int iItemObjectID = (int)dbUtil.GetPropertyValue(obj, strItemTablePrimaryKey);
                    switch (Relation)
                    {
                        case cstRelationSwitcher:
                            {
                                break;
                            }
                        case cstRelationForeign:
                            {
                                int iParentObjectID = GetParentObjectID();
                                if (iParentObjectID > 0)
                                {
                                    if (dbUtil.GetPropertyValue(obj, ItemTableForeignKey) != null)
                                        dbUtil.SetPropertyValue(obj, ItemTableForeignKey, iParentObjectID);
                                }
                                break;
                            }
                        case cstRelationParent:
                            {
                                break;
                            }
                        case cstRelationNone:
                            {
                                break;
                            }
                    }

                    //Create or update items
                    if (iItemObjectID > 0)
                    {
                        dbUtil.SetPropertyValue(obj, ERPModuleEntities.AAUpdatedUser, BOSApp.CurrentUser);
                        dbUtil.SetPropertyValue(obj, ERPModuleEntities.AAUpdatedDate, DateTime.Now);
                        objItemsController.UpdateObject(obj);
                    }
                    else
                    {
                        dbUtil.SetPropertyValue(obj, ERPModuleEntities.AACreatedUser, BOSApp.CurrentUser);
                        dbUtil.SetPropertyValue(obj, ERPModuleEntities.AACreatedDate, DateTime.Now);
                        objItemsController.CreateObject(obj);
                    }
                    Entity.SaveObjectItemRelations(objT);
                }

                //Delete items
                foreach (T objT in OriginalList)
                {
                    int iItemObjectID = (int)dbUtil.GetPropertyValue(objT, strItemTablePrimaryKey);
                    if (iItemObjectID > 0 && !this.Exists(strItemTablePrimaryKey, iItemObjectID))
                    {
                        objItemsController.DeleteObject(iItemObjectID);
                        Entity.DeleteObjectRelations(ItemTableName, iItemObjectID);
                    }
                }
                //Invalidate original list
                OriginalList.Clear();
                foreach (T objT in this)
                    OriginalList.Add((T)objT.Clone());
            }
            catch (Exception e)
            {
                MessageBox.Show("BOSList.SaveItemObjects -" + e.Message, "Bug");
            }
        }
        #endregion

        #region Update Inventory
        public void UpdateInventory(String strUpdateStatus)
        {
            foreach (T entItems in this)
            {                
                Entity.UpdateInventory((ERPModuleItemsEntity)entItems, strUpdateStatus, ItemTableName);
            }
        }        

        #endregion
        
        /// <summary>
        /// Check whether all items of list satisfy inventory conditions.
        /// If exists any invalid item, show status sub screen to confirm user.
        /// </summary>
        /// <param name="inventoryUpdateType">Inventory update type</param>
        public virtual bool IsInvalidInventory(String inventoryUpdateType)
        {
            //If items are same, just check one item of which the quantity 
            //is equal to the sum of quantity of identical ones
            BOSDbUtil dbUtil = new BOSDbUtil();
            BOSItemsEntityList<T> mergedItems = (BOSItemsEntityList<T>)this.Clone();
            mergedItems = mergedItems.MergeBySameItems();

            guiInventoryStatus guiInventoryStatus = new guiInventoryStatus();
            guiInventoryStatus.Module = Entity.Module;
            bool isInvalid = false;
            ICProductsController objProductsController = new ICProductsController();
            List<ICProductsInfo> invalidProducts = new List<ICProductsInfo>();
            foreach (ERPModuleItemsEntity entItem in mergedItems)
            {
                BusinessObject obj = entItem.SetToBusinessObject(ItemTableName);
                String tableName = BOSUtil.GetTableNameFromBusinessObject(obj);
                InventoryStatus status = Entity.GetInventoryStatus(obj, tableName, inventoryUpdateType);
                if (status != InventoryStatus.Valid)
                {
                    int productID = dbUtil.GetPropertyIntValue(obj, "FK_ICProductID");
                    ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(productID);                    
                    if (objProductsInfo != null)
                    {
                        int productSerieID = dbUtil.GetPropertyIntValue(obj, "FK_ICProductSerieID");
                        if (productSerieID > 0)
                        {
                            ICProductSeriesController objProductSeriesController = new ICProductSeriesController();
                            ICProductSeriesInfo objProductSeriesInfo = (ICProductSeriesInfo)objProductSeriesController.GetObjectByID(productSerieID);
                            if (objProductSeriesInfo != null)
                            {
                                objProductsInfo.ICProductSerialNo = objProductSeriesInfo.ICProductSerieNo;
                            }
                        }
                        objProductsInfo.InventoryStatus = GetInventoryStatusMessage(status);
                        invalidProducts.Add(objProductsInfo);
                        if (status == InventoryStatus.Empty)
                        {
                            isInvalid = true;
                        }
                    }
                }
            }
            if (invalidProducts.Count > 0)
            {
                guiInventoryStatus.InventoryStatusGridControl.DataSource = invalidProducts;
                guiInventoryStatus.ShowDialog();
            }
            return isInvalid;
        }

        /// <summary>
        /// Merge the list by the same items. If items are same, just get one item of which the quantity 
        /// is equal to the sum of quantity of identical ones        
        /// </summary>        
        /// <returns>List contains merged items</returns>
        public BOSItemsEntityList<T> MergeBySameItems()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            BOSItemsEntityList<T> mergedItems = new BOSItemsEntityList<T>();
            foreach (T entItem in this)
            {
                mergedItems.Add((T)entItem.Clone());
            }
            String qtyColumnName = ItemTableName.Substring(0, ItemTableName.Length - 1) + "ProductQty";
            for (int i = 0; i < mergedItems.Count; i++)
            {
                for (int j = i + 1; j < mergedItems.Count; j++)
                {
                    int productID1 = dbUtil.GetPropertyIntValue(mergedItems[i], "FK_ICProductID");
                    int productID2 = dbUtil.GetPropertyIntValue(mergedItems[j], "FK_ICProductID");
                    int serieID1 = dbUtil.GetPropertyIntValue(mergedItems[i], "FK_ICProductSerieID");
                    int serieID2 = dbUtil.GetPropertyIntValue(mergedItems[j], "FK_ICProductSerieID");
                    int stockID1 = dbUtil.GetPropertyIntValue(mergedItems[i], "FK_ICStockID");
                    int stockID2 = dbUtil.GetPropertyIntValue(mergedItems[j], "FK_ICStockID");
                    if (stockID1 == stockID2 && productID1 == productID2 && serieID1 == serieID2)
                    {
                        double qty1 = Convert.ToDouble(dbUtil.GetPropertyValue(mergedItems[i], qtyColumnName));
                        double qty2 = Convert.ToDouble(dbUtil.GetPropertyValue(mergedItems[j], qtyColumnName));
                        dbUtil.SetPropertyValue(mergedItems[i], qtyColumnName, qty1 + qty2);
                        mergedItems.RemoveAt(j);
                        j--;
                    }
                }
            }
            return mergedItems;
        }

        /// <summary>
        /// Get description for inventory status
        /// </summary>
        private String GetInventoryStatusMessage(InventoryStatus status)
        {
            switch (status)
            {
                case InventoryStatus.Empty:
                    return BaseLocalizedResources.NotEnoughQtyMessage;
                case InventoryStatus.LessThanMinQty:
                    return BaseLocalizedResources.LessThanMinimumQtyMessage;
                case InventoryStatus.GreaterThanMaxQty:
                    return BaseLocalizedResources.GreaterThanMaximumQtyMessage;
                default:
                    return String.Empty;
            }
        }

        /// <summary>
        /// Clone a list
        /// </summary>
        /// <returns>Copied list from the current one</returns>
        public object Clone()
        {
            BOSItemsEntityList<T> result = new BOSItemsEntityList<T>();
            result.InitBOSList(Entity, ParentTableName, ItemTableName, Relation);
            result.ItemTableForeignKey = ItemTableForeignKey;
            foreach (T obj in this)
            {
                result.Add((T)obj.Clone());
            }
            foreach (T obj in OriginalList)
            {
                result.OriginalList.Add((T)obj.Clone());
            }
            foreach (T obj in BackupList)
            {
                result.BackupList.Add((T)obj.Clone());
            }
            return result;
        }
    }
}
