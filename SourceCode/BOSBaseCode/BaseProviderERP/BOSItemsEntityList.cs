using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using BOSCommon;
using BOSLib;
using Localization;

namespace BOSERP
{
    public class BOSItemsEntityList<T> : BOSList<T>
        where T : ERPModuleItemsEntity, new()
    {
        #region Public Properties
        #endregion

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
                    T objT = (T)objItemInfo.Clone();
                    this.Add(objT);
                }
            }

            //Invalidate original list same as itself
            OriginalList.Clear();
            foreach (T obj in this)
                OriginalList.Add((T)obj.Clone());

            //Invalidate backup list same as itself
            BackupList.Clear();
            foreach (T obj in this)
            {
                BackupList.Add((T)obj.Clone());
            }

            if (GridControl != null)
            {
                if (GridControl.InvokeRequired)
                    GridControl.Invoke(new Action(() =>
                    {
                        GridControl.RefreshDataSource();
                    }));
                else GridControl.RefreshDataSource();

                if (this.Count > 0)
                {
                    if (CurrentIndex >= 0 && CurrentIndex < Count)
                    {
                        GridViewFocusRow(CurrentIndex);
                    }
                    else
                    {
                        GridViewFocusRow(0);
                    }
                }
                else
                {
                    Entity.InvalidateModuleObject(BusinessObjectFactory.GetBusinessObject(ItemTableName + "Info"));
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
            T objT = (T)Entity.ModuleObjects[ItemTableName].Clone();
            if (IsNew)
            {
                String strPrimaryKey = ItemTableName.Substring(0, ItemTableName.Length - 1) + "ID";
                dbUtil.SetPropertyValue(objT, strPrimaryKey, 0);
                objT.BackupObject = null;
                objT.OldObject = null;
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
            if (!IsEndCurrentEdit)
            {
                DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)GridControl.Views[0];
                if (CurrentIndex >= 0)
                {
                    InvalidateItem();
                }
            }
            IsEndCurrentEdit = false;
        }

        public override void GridViewFocusRow(int iRowHandle)
        {
            if (GridView != null)
            {
                if (GridView.FocusedRowHandle == iRowHandle)
                {
                    if (CurrentIndex >= 0)
                    {
                        InvalidateItem();
                    }
                }
                else
                {
                    GridView.FocusedRowHandle = iRowHandle;
                }
            }
        }

        /// <summary>
        /// Invalidate item
        /// </summary>
        private void InvalidateItem()
        {
            //Set item picture
            BOSDbUtil dbUtil = new BOSDbUtil();
            ICProductsController objProductsController = new ICProductsController();
            int productID = dbUtil.GetPropertyIntValue(this[CurrentIndex], "FK_ICProductID");
            ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(productID);
            if (objProductsInfo != null)
            {
                string itemTablePrefix = ItemTableName.Substring(0, ItemTableName.Length - 1);
                dbUtil.SetPropertyValue(this[CurrentIndex], itemTablePrefix + "ProductPicture", objProductsInfo.ICProductPicture);
            }

            Entity.InvalidateModuleObject((T)this[CurrentIndex].Clone(), ItemTableName);
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
                    int iItemObjectID = (int)dbUtil.GetPropertyValue(objT, strItemTablePrimaryKey);
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
                                    if (dbUtil.GetPropertyValue(objT, ItemTableForeignKey) != null)
                                        dbUtil.SetPropertyValue(objT, ItemTableForeignKey, iParentObjectID);
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
                        dbUtil.SetPropertyValue(objT, ERPModuleEntities.AAUpdatedUser, BOSApp.CurrentUser);
                        dbUtil.SetPropertyValue(objT, ERPModuleEntities.AAUpdatedDate, DateTime.Now);
                        objItemsController.UpdateObject(objT);
                    }
                    else
                    {
                        dbUtil.SetPropertyValue(objT, ERPModuleEntities.AACreatedUser, BOSApp.CurrentUser);
                        dbUtil.SetPropertyValue(objT, ERPModuleEntities.AACreatedDate, DateTime.Now);
                        iItemObjectID = objItemsController.CreateObject(objT);
                    }
                    dbUtil.SetPropertyValue(objT, strItemTablePrimaryKey, iItemObjectID);
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

        /// <summary>
        /// Check whether all items of list satisfy inventory conditions.
        /// If exists any invalid item, show status sub screen to confirm user.
        /// </summary>
        /// <param name="updateType">Inventory update type</param>
        public virtual bool IsInvalidInventory(String updateType)
        {
            //Merge the item list with its back-up one for merging on-hand quantity
            //between new and old
            BOSDbUtil dbUtil = new BOSDbUtil();
            BOSItemsEntityList<T> mergedItems = (BOSItemsEntityList<T>)this.Clone();
            String qtyColumnName = ItemTableName.Substring(0, ItemTableName.Length - 1) + "ProductQty";
            foreach (T item in BackupList)
            {
                T backupItem = (T)item.Clone();
                double qty = Convert.ToDouble(dbUtil.GetPropertyValue(backupItem, qtyColumnName));
                dbUtil.SetPropertyValue(backupItem, qtyColumnName, -qty);
                mergedItems.Add(backupItem);
            }

            mergedItems = mergedItems.MergeBySameItems();

            guiInventoryStatus guiInventoryStatus = new guiInventoryStatus();
            guiInventoryStatus.Module = Entity.Module;
            bool isInvalid = false;
            ICProductsController objProductsController = new ICProductsController();
            List<ICProductsInfo> invalidProducts = new List<ICProductsInfo>();
            foreach (ERPModuleItemsEntity item in mergedItems)
            {
                String tableName = BOSUtil.GetTableNameFromBusinessObject(item);
                int productID = Convert.ToInt32(dbUtil.GetPropertyValue(item, "FK_ICProductID"));
                ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(productID);
                if (objProductsInfo != null && !objProductsInfo.HasComponent)
                {
                    InventoryStatus status = Entity.GetInventoryStatus(item, tableName, updateType);
                    if (status == InventoryStatus.Empty)
                    {
                        objProductsInfo.InventoryStatus = GetInventoryStatusMessage(status);
                        invalidProducts.Add(objProductsInfo);
                        isInvalid = true;
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

        //DDCan [ADD] [08/06/2017] [Ordered Inventory], START
        public virtual bool IsInvalidInventory_AvailableQty(String updateType)
        {
            //Merge the item list with its back-up one for merging on-hand quantity
            //between new and old
            BOSDbUtil dbUtil = new BOSDbUtil();
            BOSItemsEntityList<T> mergedItems = (BOSItemsEntityList<T>)this.Clone();
            String qtyColumnName = ItemTableName.Substring(0, ItemTableName.Length - 1) + "ProductQty";
            foreach (T item in BackupList)
            {
                T backupItem = (T)item.Clone();
                double qty = Convert.ToDouble(dbUtil.GetPropertyValue(backupItem, qtyColumnName));
                dbUtil.SetPropertyValue(backupItem, qtyColumnName, -qty);
                mergedItems.Add(backupItem);
            }

            mergedItems = mergedItems.MergeBySameItems();

            guiInventoryStatus guiInventoryStatus = new guiInventoryStatus();
            guiInventoryStatus.Module = Entity.Module;
            bool isInvalid = false;
            ICProductsController objProductsController = new ICProductsController();
            List<ICProductsInfo> invalidProducts = new List<ICProductsInfo>();
            foreach (ERPModuleItemsEntity item in mergedItems)
            {
                String tableName = BOSUtil.GetTableNameFromBusinessObject(item);
                int productID = Convert.ToInt32(dbUtil.GetPropertyValue(item, "FK_ICProductID"));
                ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(productID);
                if (objProductsInfo != null && !objProductsInfo.HasComponent)
                {
                    InventoryStatus status = Entity.GetInventoryStatus_AvailableQty(item, tableName, updateType);
                    if (status == InventoryStatus.Empty)
                    {
                        objProductsInfo.InventoryStatus = GetInventoryStatusMessage(status);
                        invalidProducts.Add(objProductsInfo);
                        isInvalid = true;
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
        //DDCan [ADD] [08/06/2017] [Ordered Inventory], END

        /// <summary>
        /// UtHV 05/05/2017
        /// Only check 
        /// Check whether all items of list satisfy inventory conditions.
        /// If exists any invalid item, show status sub screen to confirm user.
        /// </summary>
        /// <param name="updateType">Inventory update type</param>
        /// <param name="productType">Only check for productType</param>
        public virtual bool IsInvalidInventory(String updateType, string productType)
        {
            //Merge the item list with its back-up one for merging on-hand quantity
            //between new and old
            BOSDbUtil dbUtil = new BOSDbUtil();
            BOSItemsEntityList<T> mergedItems = (BOSItemsEntityList<T>)this.Clone();
            String qtyColumnName = ItemTableName.Substring(0, ItemTableName.Length - 1) + "ProductQty";
            foreach (T item in BackupList)
            {
                T backupItem = (T)item.Clone();
                double qty = Convert.ToDouble(dbUtil.GetPropertyValue(backupItem, qtyColumnName));
                dbUtil.SetPropertyValue(backupItem, qtyColumnName, -qty);
                mergedItems.Add(backupItem);
            }

            mergedItems = mergedItems.MergeBySameItems();

            guiInventoryStatus guiInventoryStatus = new guiInventoryStatus();
            guiInventoryStatus.Module = Entity.Module;
            bool isInvalid = false;
            ICProductsController objProductsController = new ICProductsController();
            List<ICProductsInfo> invalidProducts = new List<ICProductsInfo>();
            foreach (ERPModuleItemsEntity item in mergedItems)
            {
                String tableName = BOSUtil.GetTableNameFromBusinessObject(item);
                int productID = Convert.ToInt32(dbUtil.GetPropertyValue(item, "FK_ICProductID"));
                ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(productID);
                if (objProductsInfo != null && !objProductsInfo.HasComponent && objProductsInfo.ICProductType == productType)
                {
                    InventoryStatus status = Entity.GetInventoryStatus(item, tableName, updateType);
                    if (status == InventoryStatus.Empty)
                    {
                        objProductsInfo.InventoryStatus = GetInventoryStatusMessage(status);
                        invalidProducts.Add(objProductsInfo);
                        isInvalid = true;
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
