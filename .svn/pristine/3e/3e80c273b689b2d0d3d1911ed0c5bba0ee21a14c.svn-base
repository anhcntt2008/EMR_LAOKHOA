using System;
using System.Collections.Generic;
using System.Text;
using BOSCommon;
using BOSComponent;

namespace BOSERP.Modules.ICProduct
{
    public class ICProductEntities: ERPModuleEntities
    {
        #region Declare Constant
        #endregion
        
        #region Declare all entities variables
        
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the medicine component list
        /// </summary>
        public BOSList<MEMedicineComponentsInfo> MEMedicineComponentList { get; set; }

        public BOSList<ICProductAccountsInfo> ICProductAccountList { get; set; }

        /// <summary>
        /// Gets or sets the measure unit list of the current product
        /// </summary>
        public BOSList<ICProductUnitsInfo> ICProductUnitsList { get; set; }

        /// <summary>
        /// Gets or sets the interacting product list of the current one
        /// </summary>
        public BOSList<MEInteractingMedicinesInfo> InteractingProductList { get; set; }
        #endregion

        #region Constructor
        public ICProductEntities()
            : base()
        {
            MEMedicineComponentList = new BOSList<MEMedicineComponentsInfo>();
            ICProductUnitsList = new BOSList<ICProductUnitsInfo>();
            InteractingProductList = new BOSList<MEInteractingMedicinesInfo>();
            ICProductAccountList = new BOSList<ICProductAccountsInfo>();
        }

        #endregion

        #region SetDefaultModuleObject
        public override void SetDefaultModuleObjects()
        {
            MEMedicineComponentsInfo objMedicineComponentsInfo = (MEMedicineComponentsInfo)ModuleObjects[TableName.MEMedicineComponentsTableName];
        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new ICProductsInfo();
        }

        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.MEMedicineComponentsTableName, new MEMedicineComponentsInfo());
            ModuleObjects.Add(TableName.MEInteractingMedicinesTableName, new MEInteractingMedicinesInfo());
        }

        public override void InitModuleObjectList()
        {
            MEMedicineComponentList.InitBOSList(
                                        this,
                                        TableName.ICProductsTableName,
                                        TableName.MEMedicineComponentsTableName,
                                        BOSList<MEMedicineComponentsInfo>.cstRelationForeign);
            MEMedicineComponentList.ItemTableForeignKey = "FK_ICProductID";
            ICProductAccountList.InitBOSList(
                                        this,
                                        TableName.ICProductsTableName,
                                        TableName.ICProductAccountsTableName,
                                        BOSList<MEMedicineComponentsInfo>.cstRelationForeign);
            ICProductAccountList.ItemTableForeignKey = "FK_ICProductID";

            ICProductUnitsList.InitBOSList(this,
                                           TableName.ICProductsTableName,
                                           TableName.ICProductUnitsTableName,
                                           BOSList<ICProductUnitsInfo>.cstRelationForeign);
            ICProductUnitsList.ItemTableForeignKey = "FK_ICProductID";

            InteractingProductList.InitBOSList(
                                                this,
                                                TableName.ICProductsTableName,
                                                TableName.MEInteractingMedicinesTableName,
                                                BOSList<MEInteractingMedicinesInfo>.cstRelationForeign);
            InteractingProductList.ItemTableForeignKey = "FK_ICProductID";
        }

        public override void InitGridControlInBOSList()
        {
            MEMedicineComponentList.InitBOSListGridControl();
            ICProductAccountList.InitBOSListGridControl();
            ICProductUnitsList.InitBOSListGridControl();
            InteractingProductList.InitBOSListGridControl(ICProductModule.InteractingProductsGridControlName);
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                MEMedicineComponentList.SetDefaultListAndRefreshGridControl();
                ICProductUnitsList.SetDefaultListAndRefreshGridControl();
                InteractingProductList.SetDefaultListAndRefreshGridControl();
                ICProductAccountList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        #region Invalidate Module Objects functions
        public override void InvalidateMainObject(int iObjectID)
        {
            base.InvalidateMainObject(iObjectID);
            BOSComponent.BOSRadioGroup meDeRadioGroup = (BOSComponent.BOSRadioGroup)Module
                                                                .Controls[ICProductModule.MedicineDeviceRadioGroupName];
            ICProductsInfo objProductsInfo = (ICProductsInfo)MainObject;
            meDeRadioGroup.EditValue = objProductsInfo.FK_ICDepartmentID;
        }

        public override void InvalidateModuleObjects(int iObjectID)
        {
            MEMedicineComponentList.Invalidate(iObjectID);
            ICProductAccountList.Invalidate(iObjectID);
            ICProductUnitsList.Invalidate(iObjectID);
            InteractingProductList.Invalidate(iObjectID);
        }
        #endregion

        #region Save Module Objects functions
        public override int SaveMainObject()
        {
            ICProductsInfo objProductsInfo = (ICProductsInfo)MainObject;
            BOSRadioGroup meDeRadioGroup = (BOSRadioGroup)Module.Controls[ICProductModule.MedicineDeviceRadioGroupName];
            int deparmentID = Convert.ToInt32(meDeRadioGroup.EditValue);
            objProductsInfo.FK_ICDepartmentID = deparmentID;
            if (deparmentID == 6)
            {
                objProductsInfo.ICProductType = ProductType.Medicine.ToString();
            }
            if (deparmentID == 7)
            {
                objProductsInfo.ICProductType = ProductType.Equipment.ToString();
                BOSLookupEdit modelLookupEdit = (BOSLookupEdit)Module.Controls[ICProductModule.ModelAttributeValueLookupEditName];
                BOSLookupEdit sizeLookupEdit = (BOSLookupEdit)Module.Controls[ICProductModule.SizeAttributeValueLookupEditName];
                objProductsInfo.ICProductAttributeKey = string.Format("{0}_{1}", Convert.ToInt32(modelLookupEdit.EditValue)
                                                                               , Convert.ToInt32(sizeLookupEdit.EditValue));
            }
            return base.SaveMainObject();
        }

        public override void SaveModuleObjects()
        {
            MEMedicineComponentList.SaveItemObjects();
            InteractingProductList.SaveItemObjects();
            ICProductAccountList.SaveItemObjects();
        }
        #endregion     
    }
}
