using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using BOSLib;
using DevExpress.XtraEditors;

namespace BOSERP
{
    partial class BaseModuleERP
    {
        /// <summary>
        ///     Set label's text to corresponding property of the given object
        /// </summary>
        /// <param name="obj">The given object</param>
        /// <param name="ctrl">Label needs to be set</param>
        public virtual void DisplayLabelText(BusinessObject obj, Control ctrl)
        {
            if (ctrl is BOSTextBox)
            {
                var b = (BOSTextBox)ctrl;
                var strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);


                //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], START
                //GENumberingInfo objNumberingInfo = (GENumberingInfo)objNumberingController.GetObjectByName(this.Name);
                GENumberingInfo objNumberingInfo;
                var nuberingList = _geNumberingController.GetNumberingListByName(Name);
                if (nuberingList.Count == 1)
                    objNumberingInfo = nuberingList[0];
                else
                    objNumberingInfo =
                        nuberingList
                            .FirstOrDefault(i => i.FK_BRBranchID == BOSApp.CurrentCompanyInfo.FK_BRBranchID);
                //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], END

                if (strMainObjectTableName.Substring(0, strMainObjectTableName.Length - 1) + "No" != b.BOSDataMember ||
                    objNumberingInfo == null || !objNumberingInfo.GENumberingLockNo) return;
                if (b.Tag == null || !b.Tag.ToString().StartsWith("S"))
                    b.Properties.ReadOnly = true;
            }
            else if (ctrl is BOSLabel || ctrl is Label || ctrl is LabelControl || ctrl is BOSHyperLinkEdit)
            {
                var strObjectTableName = BOSUtil.GetTableNameFromBusinessObject(obj);
                var strDataSource = _dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstDataSourcePropertyName);
                var strDataMember = _dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstDataMemberPropertyName);
                if (!string.IsNullOrEmpty(ctrl.AccessibleName))
                {
                    strDataSource = ctrl.AccessibleName.Split(';')[0];
                    strDataMember = ctrl.AccessibleName.Split(';')[1];
                }
                if (string.IsNullOrEmpty(strDataSource) || string.IsNullOrEmpty(strDataMember)) return;
                if (strDataSource != strObjectTableName) return;
                var prop = obj.GetType().GetProperty(strDataMember);
                if (prop == null) return;
                var objValue = prop.GetValue(obj, null);
                if (objValue == null) return;
                var columnType = objValue.GetType();
                if (columnType == typeof(string))
                {
                    ctrl.Text = objValue.ToString();
                }
                else if (columnType == typeof(int))
                {
                    ctrl.Text = BOSUtil.GetNumberDisplayFormat(Convert.ToInt32(objValue));
                }
                else if (columnType == typeof(double))
                {
                    var dblValue = Convert.ToDouble(objValue);
                    ctrl.Text = BOSUtil.GetNumberDisplayFormat(dblValue);
                }
                else if (columnType == typeof(decimal))
                {
                    var decValue = Convert.ToDecimal(objValue);
                    ctrl.Text = BOSUtil.GetNumberDisplayFormat(decValue);
                }
                else if (columnType == typeof(DateTime))
                {
                    ctrl.Text = objValue.ToString();
                }
                else if (columnType == typeof(bool))
                {
                    ctrl.Text = objValue.ToString();
                }
                else
                {
                    ctrl.Text = objValue.ToString();
                }
            }
        }

        public virtual void DisplayLabelText(BusinessObject obj)
        {
            foreach (DictionaryEntry entry in Controls)
            {
                var ctrl = (Control)entry.Value;
                DisplayLabelText(obj, ctrl);
            }
        }

        /// <summary>
        ///     Show inventory info of a product for the current transaction
        /// </summary>
        /// <param name="productId">Product id</param>
        public virtual void ShowInventory(int productId)
        {
        }

        /// <summary>
        ///     Show inventory details of a product based on inventory permission
        ///     of the current user
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <param name="inventoryType">Inventory type</param>
        public virtual void ShowInventoryDetails(int productId, string inventoryType)
        {
        }

        /// <summary>
        ///     Synchronize serie for an object when transferring from a branch to another
        /// </summary>
        /// <param name="obj">Given object</param>
        public void SynProductSerie(BusinessObject obj)
        {
            var entity = CurrentModuleEntity;
            entity.SynProductSerie(obj);
        }

        #region Set Default Values From Customer,Supplier

        public virtual void SetDefaultValuesFromCustomer()
        {
            var customerId = Convert.ToInt32(_dbUtil.GetPropertyValue(CurrentModuleEntity.MainObject, "FK_ARCustomerID"));
            var objCustomersInfo = (ARCustomersInfo)_customersController.GetObjectByID(customerId);
            if (objCustomersInfo == null) return;
            CurrentModuleEntity.SetDefaultValuesFromCustomer(objCustomersInfo);
            DisplayLabelText(objCustomersInfo);
            DisplayLabelText(CurrentModuleEntity.MainObject);
        }


        #endregion

        #region Generate Search Query based on Search Fields of Module

        public virtual string GenerateSearchQuery(string strTableName)
        {
            var strSearchQueryBuilder = new StringBuilder();
            strSearchQueryBuilder.Append(GenerateSearchQueryHeader(strTableName));
            strSearchQueryBuilder.Append("WHERE" + BOSUtil.NewLine);
            strSearchQueryBuilder.Append(GenerateConditionsForSearch(strTableName));
            strSearchQueryBuilder.Append(GetStatePermiQueryConditionStr(strTableName));
            strSearchQueryBuilder.Append(BOSUtil.NewLine);
            return strSearchQueryBuilder.ToString();
        }

        public string GenerateGetTop(string strTableName, int top, string orderBy, string orderType)
        {
            var str = $"SELECT TOP {top} * FROM {strTableName} WHERE AAStatus='Alive' ORDER BY {orderBy} {orderType}" +
                      BOSUtil.NewLine;
            return str;
        }

        public virtual string GenerateSearchQueryHeader(string strTableName)
        {
            var strSearchQueryHeaderBuilder = new StringBuilder();
            if (Controls[BOSApp.cstTopResultsSearchControl] != null)
            {
                var iTopResults = Convert.ToInt32(((BaseEdit)Controls[BOSApp.cstTopResultsSearchControl]).EditValue);
                //iTopResults must be greater or equal to 0
                if (iTopResults < 0)
                    iTopResults = 0;
                strSearchQueryHeaderBuilder.Append(string.Format("SELECT TOP({0}) ", iTopResults));
                strSearchQueryHeaderBuilder.Append("* FROM [dbo]." + strTableName + BOSUtil.NewLine);
            }
            else
            {
                strSearchQueryHeaderBuilder.Append("SELECT * FROM [dbo]." + strTableName + BOSUtil.NewLine);
            }

            return strSearchQueryHeaderBuilder.ToString();
        }

        public virtual string GenerateConditionsForSearch(string strTableName)
        {
            var dbUtil = new BOSDbUtil();
            var strConditionBuilder = new StringBuilder();
            foreach (Control ctrl in SearchScreen.CriteriaSection.Controls)
                if (ctrl.Tag != null && ctrl.Tag.ToString() == BOSScreen.SearchControl)
                {
                    var strColumnName = dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstDataMemberPropertyName);
                    strConditionBuilder.Append(GenerateConditionsForSearch(ctrl, strTableName, strColumnName));
                }
            strConditionBuilder.Append(BOSUtil.Tab + "([AAStatus]=\'Alive\')" + BOSUtil.NewLine);

            return strConditionBuilder.ToString();
        }

        public virtual string GenerateConditionsForSearch(Control ctrl, string strTableName, string strColumnName)
        {
            var objSearch = CurrentModuleEntity.SearchObject;
            var strConditionBuilder = new StringBuilder();
            var strFieldName = ctrl.Name;
            if (strFieldName.Contains("TopResult"))
                return string.Empty;
            var strColumnDbType = _dbUtil.GetColumnDbType(strTableName, strColumnName);
            var editValue = ((BaseEdit)ctrl).EditValue;
            if (objSearch != null)
            {
                var objValue = _dbUtil.GetPropertyStringValue(objSearch, strColumnName);
                //uthv bo sung trong truong hop moi khoi tao module se ko co value cua control do chua binding
                if ((editValue == null || editValue.ToString() == string.Empty) && !string.IsNullOrEmpty(objValue) && objValue != "0")
                    editValue = objValue;
            }

            if (editValue == null)
                return string.Empty;
            if (editValue.ToString() == string.Empty)
                return string.Empty;

            if (strColumnDbType.Contains("varchar") || strColumnDbType.Contains("nvarchar"))
            {
                #region varchar

                var strColumnValue = BOSUtil.GetSearchString(editValue.ToString());
                if (string.IsNullOrEmpty(strColumnValue)) return strConditionBuilder.ToString();
                if (strFieldName.Contains("SearchFrom"))
                    strConditionBuilder.Append(BOSUtil.Tab +
                                               string.Format("([{0}] >= '{1}')", strColumnName, strColumnValue));
                else if (strFieldName.Contains("SearchTo"))
                    strConditionBuilder.Append(BOSUtil.Tab +
                                               string.Format("([{0}] <= '{1}')", strColumnName, strColumnValue));
                else if (strFieldName.Contains("Phone"))
                {
                    var value0 = strColumnValue;
                    var value84 = strColumnValue;
                    if (strColumnValue.StartsWith("0"))
                        value84 = "+84" + strColumnValue.Remove(0, 1);
                    else if (strColumnValue.StartsWith("+84"))
                        value0 = "0" + strColumnValue.Remove(0, 3);
                    strConditionBuilder.Append(BOSUtil.Tab +
                                               string.Format("([{0}] LIKE N'%{1}%') OR ([{0}] LIKE N'%{2}%')", strColumnName, value0, value84));
                }
                else
                    strConditionBuilder.Append(BOSUtil.Tab +
                                               string.Format("([{0}] LIKE N'%{1}%')", strColumnName, strColumnValue));

                strConditionBuilder.Append(BOSUtil.NewLine + BOSUtil.Tab + "AND" + BOSUtil.NewLine);

                #endregion
            }
            else if (strColumnDbType.Contains("datetime"))
            {
                #region datetime

                var dtColumnValue = Convert.ToDateTime(editValue);
                var strFormatDatetime = "yyyyMMdd";
                if (strFieldName.Contains("SearchFrom"))
                    strConditionBuilder.Append(BOSUtil.Tab +
                                               string.Format(
                                                   "((CONVERT(VARCHAR(10), [{0}], 112) >= CONVERT(VARCHAR(10),'{1}', 112)))",
                                                   strColumnName, dtColumnValue.ToString(strFormatDatetime)));
                else if (strFieldName.Contains("SearchTo"))
                    strConditionBuilder.Append(BOSUtil.Tab +
                                               string.Format(
                                                   "((CONVERT(VARCHAR(10), [{0}], 112) <= CONVERT(VARCHAR(10),'{1}', 112)))",
                                                   strColumnName, dtColumnValue.ToString(strFormatDatetime)));
                else
                    strConditionBuilder.Append(BOSUtil.Tab +
                                               string.Format(
                                                   "((CONVERT(VARCHAR(10), [{0}], 112) = CONVERT(VARCHAR(20),'{1}', 112)))",
                                                   strColumnName, dtColumnValue.ToString(strFormatDatetime)));

                strConditionBuilder.Append(BOSUtil.NewLine + BOSUtil.Tab + "AND" + BOSUtil.NewLine);

                #endregion
            }

            else if (strColumnDbType.Contains("int"))
            {
                #region int

                var iColumnValue = Convert.ToInt32(editValue.ToString());
                if (iColumnValue > 0)
                {
                    if (strFieldName.Contains("SearchFrom"))
                        strConditionBuilder.Append(BOSUtil.Tab +
                                                   string.Format("([{0}] >= {1})", strColumnName, iColumnValue));
                    else if (strFieldName.Contains("SearchTo"))
                        strConditionBuilder.Append(BOSUtil.Tab +
                                                   string.Format("([{0}] <= {1})", strColumnName, iColumnValue));
                    else
                        strConditionBuilder.Append(BOSUtil.Tab +
                                                   string.Format("([{0}] = {1})", strColumnName, iColumnValue));

                    strConditionBuilder.Append(BOSUtil.NewLine + BOSUtil.Tab + "AND" + BOSUtil.NewLine);
                }

                #endregion
            }
            else if (strColumnDbType.Contains("float"))
            {
                #region float

                var dbColumnValue = Convert.ToDouble(editValue.ToString());
                if (strFieldName.Contains("SearchFrom"))
                    strConditionBuilder.Append(BOSUtil.Tab +
                                               string.Format("([{0}] >= {1})", strColumnName, dbColumnValue));
                else if (strFieldName.Contains("SearchTo"))
                    strConditionBuilder.Append(BOSUtil.Tab +
                                               string.Format("([{0}] <= {1})", strColumnName, dbColumnValue));
                else
                    strConditionBuilder.Append(BOSUtil.Tab +
                                               string.Format("([{0}] = {1})", strColumnName, dbColumnValue));

                strConditionBuilder.Append(BOSUtil.NewLine + BOSUtil.Tab + "AND" + BOSUtil.NewLine);

                #endregion
            }
            else if (strColumnDbType.Contains("bit"))
            {
                #region Bit

                var bColumnValue = Convert.ToBoolean(editValue);
                strConditionBuilder.Append(BOSUtil.Tab + string.Format("([{0}] = {1})", strColumnName, bColumnValue));
                strConditionBuilder.Append(BOSUtil.NewLine + BOSUtil.Tab + "AND" + BOSUtil.NewLine);

                #endregion
            }
            else
            {
                return string.Empty;
            }
            return strConditionBuilder.ToString();
        }

        #endregion
    }
}