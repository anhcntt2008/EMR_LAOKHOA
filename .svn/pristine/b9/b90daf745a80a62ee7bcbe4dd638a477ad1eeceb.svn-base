using System;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.XtraBars;
using System.Text;
using BOSLib;
using BOSComponent;

namespace BOSERP
{
    partial class BaseModuleERP
    {     
        #region Set Default Values From Customer,Supplier
        public virtual void SetDefaultValuesFromCustomer()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            int customerID = Convert.ToInt32(dbUtil.GetPropertyValue(CurrentModuleEntity.MainObject, "FK_ARCustomerID"));
            ARCustomersController objCustomersController = new ARCustomersController();
            ARCustomersInfo objCustomersInfo = (ARCustomersInfo)objCustomersController.GetObjectByID(customerID);
            if (objCustomersInfo != null)
            {
                CurrentModuleEntity.SetDefaultValuesFromCustomer(objCustomersInfo);
                DisplayLabelText(objCustomersInfo);
                DisplayLabelText(CurrentModuleEntity.MainObject);
            }
        }

        public virtual void SetDefaultValuesFromSupplier()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            int supplierID = Convert.ToInt32(dbUtil.GetPropertyValue(CurrentModuleEntity.MainObject, "FK_APSupplierID"));
            APSuppliersController objSuppliersController = new APSuppliersController();
            APSuppliersInfo objSuppliersInfo = (APSuppliersInfo)objSuppliersController.GetObjectByID(supplierID);
            if (objSuppliersInfo != null)
            {
                CurrentModuleEntity.SetDefaultValuesFromSupplier(objSuppliersInfo);
                DisplayLabelText(objSuppliersInfo);
                DisplayLabelText(CurrentModuleEntity.MainObject);
            }            
        }
        #endregion        

        #region Generate Search Query based on Search Fields of Module
    
        public virtual String GenerateSearchQuery(String strTableName)
        {
            StringBuilder strSearchQueryBuilder = new StringBuilder();
            strSearchQueryBuilder.Append(GenerateSearchQueryHeader(strTableName));
            strSearchQueryBuilder.Append("WHERE" + BOSUtil.NewLine);
            strSearchQueryBuilder.Append(GenerateConditionsForSearch(strTableName));
            strSearchQueryBuilder.Append(BOSUtil.NewLine);
            return strSearchQueryBuilder.ToString();
        }

        public virtual String GenerateSearchQueryHeader(String strTableName)
        {
            StringBuilder strSearchQueryHeaderBuilder = new StringBuilder();
            if (Controls[BOSApp.cstTopResultsSearchControl] != null)
            {
                int iTopResults = Convert.ToInt32(((DevExpress.XtraEditors.BaseEdit)Controls[BOSApp.cstTopResultsSearchControl]).EditValue);
                //iTopResults must be greater or equal to 0
                if (iTopResults < 0)
                    iTopResults = 0;
                strSearchQueryHeaderBuilder.Append(String.Format("SELECT TOP({0}) ", iTopResults));
                strSearchQueryHeaderBuilder.Append("* FROM [dbo]." + strTableName + BOSUtil.NewLine);
            }
            else
            {
                strSearchQueryHeaderBuilder.Append("SELECT * FROM [dbo]." + strTableName + BOSUtil.NewLine);
            }

            return strSearchQueryHeaderBuilder.ToString();
        }

        public virtual String GenerateConditionsForSearch(String strTableName)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            StringBuilder strConditionBuilder = new StringBuilder();
            STFieldsController objSTFieldsController = new STFieldsController();
            foreach (Control ctrl in SearchScreen.CriteriaSection.Controls)
                if (ctrl.Tag != null && ctrl.Tag.ToString() == BOSERPScreen.SearchControl)
            {
                String strColumnName = dbUtil.GetPropertyStringValue(ctrl, BOSERPScreen.cstDataMemberPropertyName);
                strConditionBuilder.Append(GenerateConditionsForSearch(ctrl, strTableName, strColumnName));
            }
            strConditionBuilder.Append(BOSUtil.Tab + String.Format("([AAStatus]='Alive')") + BOSUtil.NewLine);
            return strConditionBuilder.ToString();
        }

        public virtual String GenerateConditionsForSearch(Control ctrl, String strTableName, String strColumnName)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            StringBuilder strConditionBuilder = new StringBuilder();
            String strFieldName = ctrl.Name;
            if (strFieldName.Contains("TopResult"))
                return String.Empty;
            String strColumnDbType = dbUtil.GetColumnDbType(strTableName, strColumnName);
            if (((DevExpress.XtraEditors.BaseEdit)ctrl).EditValue == null)
                return String.Empty;
            if (((DevExpress.XtraEditors.BaseEdit)ctrl).EditValue.ToString() == String.Empty)
                return String.Empty;

            if (!dbUtil.IsForeignKey(strTableName, strColumnName))
            {
                if (strColumnDbType.Contains("varchar") || strColumnDbType.Contains("nvarchar"))
                {
                    #region varchar
                    String strColumnValue = ((DevExpress.XtraEditors.BaseEdit)ctrl).EditValue.ToString();
                    if (strFieldName.Contains("SearchFrom"))
                    {
                        strConditionBuilder.Append(BOSUtil.Tab + String.Format("([{0}] >= '{1}')", strColumnName, strColumnValue));
                    }
                    else if (strFieldName.Contains("SearchTo"))
                    {
                        strConditionBuilder.Append(BOSUtil.Tab + String.Format("([{0}] <= '{1}')", strColumnName, strColumnValue));
                    }
                    else
                    {
                        string configGroup = string.Empty;
                        if (strColumnName.Contains("Combo"))
                        {
                            configGroup = strColumnName.Substring(2, strColumnName.Length - 7);
                        }
                        else
                        {
                            configGroup = strColumnName.Substring(2, strColumnName.Length - 2);
                        }
                        bool isConfigValue = false;
                        if (ADConfigValueUtility.glbdsConfigValues.Tables[configGroup] != null)
                        {
                            isConfigValue = true;
                        }
                        else
                        {
                            isConfigValue = false;
                        }
                        //If column gets data from config values, don't use LIKE to search exactly
                        if (isConfigValue)
                        {
                            strConditionBuilder.Append(BOSUtil.Tab + String.Format("([{0}] = N'{1}')", strColumnName, strColumnValue));
                        }
                        else
                        {
                            strColumnValue = BOSUtil.GetSearchString(strColumnValue);
                            strConditionBuilder.Append(BOSUtil.Tab + String.Format("([{0}] LIKE N'%{1}%')", strColumnName, strColumnValue));
                        }
                    }

                    strConditionBuilder.Append(BOSUtil.NewLine + BOSUtil.Tab + "AND" + BOSUtil.NewLine);
                    #endregion

                }
                else if (strColumnDbType.Contains("datetime"))
                {
                    #region datetime
                    DateTime dtColumnValue = Convert.ToDateTime(((DevExpress.XtraEditors.BaseEdit)ctrl).EditValue);
                    String strFormatDatetime = String.Format("yyyyMMdd");
                    if (strFieldName.Contains("SearchFrom"))
                    {
                        strConditionBuilder.Append(BOSUtil.Tab + String.Format("((CONVERT(VARCHAR(10), [{0}], 112) >= CONVERT(VARCHAR(10),'{1}', 112)))",
                            strColumnName, dtColumnValue.ToString(strFormatDatetime)));
                    }
                    else if (strFieldName.Contains("SearchTo"))
                    {
                        strConditionBuilder.Append(BOSUtil.Tab + String.Format("((CONVERT(VARCHAR(10), [{0}], 112) <= CONVERT(VARCHAR(10),'{1}', 112)))",
                            strColumnName, dtColumnValue.ToString(strFormatDatetime)));
                    }
                    else
                    {
                        strConditionBuilder.Append(BOSUtil.Tab + String.Format("((CONVERT(VARCHAR(10), [{0}], 112) = CONVERT(VARCHAR(20),'{1}', 112)))",
                            strColumnName, dtColumnValue.ToString(strFormatDatetime)));
                    }

                    strConditionBuilder.Append(BOSUtil.NewLine + BOSUtil.Tab + "AND" + BOSUtil.NewLine);
                    #endregion
                }

                else if (strColumnDbType.Contains("int"))
                {
                    #region int
                    int iColumnValue = Convert.ToInt32(((DevExpress.XtraEditors.BaseEdit)ctrl).EditValue.ToString());

                    if (strFieldName.Contains("SearchFrom"))
                    {
                        strConditionBuilder.Append(BOSUtil.Tab + String.Format("([{0}] >= {1})", strColumnName, iColumnValue));
                    }
                    else if (strFieldName.Contains("SearchTo"))
                    {
                        strConditionBuilder.Append(BOSUtil.Tab + String.Format("([{0}] <= {1})", strColumnName, iColumnValue));
                    }
                    else
                    {
                        strConditionBuilder.Append(BOSUtil.Tab + String.Format("([{0}] = {1})", strColumnName, iColumnValue));
                    }

                    strConditionBuilder.Append(BOSUtil.NewLine + BOSUtil.Tab + "AND" + BOSUtil.NewLine);
                    #endregion
                }
                else if (strColumnDbType.Contains("float"))
                {
                    #region float
                    double dbColumnValue = Convert.ToDouble(((DevExpress.XtraEditors.BaseEdit)ctrl).EditValue.ToString());
                    if (strFieldName.Contains("SearchFrom"))
                    {
                        strConditionBuilder.Append(BOSUtil.Tab + String.Format("([{0}] >= {1})", strColumnName, dbColumnValue));
                    }
                    else if (strFieldName.Contains("SearchTo"))
                    {
                        strConditionBuilder.Append(BOSUtil.Tab + String.Format("([{0}] <= {1})", strColumnName, dbColumnValue));
                    }
                    else
                    {
                        strConditionBuilder.Append(BOSUtil.Tab + String.Format("([{0}] = {1})", strColumnName, dbColumnValue));
                    }

                    strConditionBuilder.Append(BOSUtil.NewLine + BOSUtil.Tab + "AND" + BOSUtil.NewLine);
                    #endregion
                }
                else if (strColumnDbType.Contains("bit"))
                {
                    #region Bit
                    bool bColumnValue = Convert.ToBoolean(((DevExpress.XtraEditors.BaseEdit)ctrl).EditValue);
                    strConditionBuilder.Append(BOSUtil.Tab + String.Format("([{0}] = {1})", strColumnName, bColumnValue));

                    strConditionBuilder.Append(BOSUtil.NewLine + BOSUtil.Tab + "AND" + BOSUtil.NewLine);
                    #endregion
                }
                else
                {
                    return String.Empty;
                }
            }
            else
            {
                int iColumnValue = Convert.ToInt32(((DevExpress.XtraEditors.BaseEdit)ctrl).EditValue);
                strConditionBuilder.Append(BOSUtil.Tab + String.Format("(([{0}] ={1})OR({1} =0))", strColumnName, iColumnValue));
                strConditionBuilder.Append(BOSUtil.NewLine + BOSUtil.Tab + "AND" + BOSUtil.NewLine);
            }
            return strConditionBuilder.ToString();
        }
        #endregion
        
        /// <summary>
        /// Set label's text to corresponding property of the given object
        /// </summary>
        /// <param name="obj">The given object</param>
        /// <param name="ctrl">Label needs to be set</param>
        public virtual void DisplayLabelText(BusinessObject obj, Control ctrl)
        {
            if (ctrl.GetType() == typeof(BOSLabel) || ctrl.GetType() == typeof(Label) || ctrl.GetType() == typeof(DevExpress.XtraEditors.LabelControl))
            {
                //Ignore labels belonging to "NoBinding" group for other purposes
                if (ctrl.GetType() == typeof(BOSLabel))
                {
                    String fieldGroup = ((BOSLabel)ctrl).BOSFieldGroup;
                    if (!String.IsNullOrEmpty(fieldGroup) && fieldGroup.Equals(BOSERPScreen.cstFieldGroupNoBinding))
                        return;
                }

                BOSDbUtil dbUtil = new BOSDbUtil();
                String strObjectTableName = BOSUtil.GetTableNameFromBusinessObject(obj);
                String strDataSource = dbUtil.GetPropertyStringValue(ctrl, BOSERPScreen.cstDataSourcePropertyName);
                String strDataMember = dbUtil.GetPropertyStringValue(ctrl, BOSERPScreen.cstDataMemberPropertyName);
                if (!String.IsNullOrEmpty(ctrl.AccessibleName))
                {
                    strDataSource = ctrl.AccessibleName.Split(';')[0];
                    strDataMember = ctrl.AccessibleName.Split(';')[1];
                }
                if (!String.IsNullOrEmpty(strDataSource) && !String.IsNullOrEmpty(strDataMember))
                {
                    if (strDataSource == strObjectTableName)
                    {
                        PropertyInfo prop = obj.GetType().GetProperty(strDataMember);
                        if (prop != null)
                        {
                            object objValue = prop.GetValue(obj, null);
                            Type columnType = objValue.GetType();
                            if (columnType == typeof(String))
                                ctrl.Text = objValue.ToString();
                            else if (columnType == typeof(int))
                                ctrl.Text = BOSUtil.GetNumberDisplayFormat(Convert.ToInt32(objValue));
                            else if (columnType == typeof(double))
                            {
                                double dblValue = Convert.ToDouble(objValue);
                                ctrl.Text = BOSUtil.GetNumberDisplayFormat(dblValue);
                            }
                            else if (columnType == typeof(decimal))
                            {
                                decimal decValue = Convert.ToDecimal(objValue);
                                ctrl.Text = BOSUtil.GetNumberDisplayFormat(decValue);
                            }
                            else if (columnType == typeof(DateTime))
                                ctrl.Text = objValue.ToString();
                            else if (columnType == typeof(bool))
                                ctrl.Text = objValue.ToString();
                            else
                                ctrl.Text = objValue.ToString();
                        }
                    }
                }
            }
        }

        public virtual void DisplayLabelText(BusinessObject obj)
        {
            foreach (DictionaryEntry entry in Controls)
            {
                Control ctrl = (Control)entry.Value;
                DisplayLabelText(obj, ctrl);
            }
        }

        /// <summary>
        /// Show inventory info of a product for the current transaction
        /// </summary>
        /// <param name="productID">Product id</param>
        public void ShowInventory(int productID)
        {
            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = objProductsController.GetProductByIDAndStockID(
                                                                                        productID,
                                                                                        BOSApp.CurrentCompanyInfo.FK_ICStockID);
            if (objProductsInfo != null)
            {
                objProductsInfo.ICInventoryStockAvailableQuantity = objProductsInfo.ICInventoryStockQuantity - objProductsInfo.ICInventoryStockSaleOrderQuantity;
                foreach (Control ctrl in ParentScreen.InventoryPanel.Controls)
                    DisplayLabelText(objProductsInfo, ctrl);
            }
        }
    }
}
