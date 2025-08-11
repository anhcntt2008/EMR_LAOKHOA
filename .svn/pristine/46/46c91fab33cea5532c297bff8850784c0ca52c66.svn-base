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
using BOSLib;
using BOSComponent;

namespace BOSERP
{
    partial class BaseModuleERP:BaseModule,IBaseModule
    {
        #region Module handler Functions
        public void MoveNextControlOnEnter(object sender, String strEventName)
        {
            String strNextControlName = GetBOSParameterValueFromFunctionNameAndParameterName(
                                        sender, strEventName,
                                        "MoveNextControlOnEnter", "NextControlName");
            Controls[strNextControlName].Focus();
            if (Controls[strNextControlName] is DevExpress.XtraEditors.TextEdit)
                ((DevExpress.XtraEditors.TextEdit)Controls[strNextControlName]).SelectAll();
            else if (Controls[strNextControlName] is ComboBox)
                ((ComboBox)Controls[strNextControlName]).SelectAll();
        }

        protected void InvokeAllMethodsForControlEvent(object sender, String strEventName)
        {
            Control ctrl = sender as Control;

            STFieldsInfo objSTFieldsInfo = new STFieldsController().GetFieldBySTModuleIDAndSTUserGroupIDAndSTFieldName(
                                                                        ModuleID,
                                                                        BOSApp.CurrentUserGroupInfo.ADUserGroupID,
                                                                        ctrl.Name);
            if (objSTFieldsInfo != null)
            {
                //Get Field Event
                STFieldEventsInfo objSTFieldEventsInfo = new STFieldEventsController().GetFieldEventByFieldIDAndEventName(objSTFieldsInfo.STFieldID, strEventName);

                if (objSTFieldEventsInfo != null)
                {
                    //Get all Functions implement field event
                    DataSet dsFieldEventFunctions = new STFieldEventFunctionsController().GetFieldEventFunctionByFieldEventID(objSTFieldEventsInfo.STFieldEventID);
                    if (dsFieldEventFunctions.Tables.Count > 0)
                    {
                        foreach (DataRow rowFieldEventFunction in dsFieldEventFunctions.Tables[0].Rows)
                        {
                            STFieldEventFunctionsInfo objSTFieldEventFunctionsInfo = (STFieldEventFunctionsInfo)new STFieldEventFunctionsController().GetObjectFromDataRow(rowFieldEventFunction);

                            MethodInfo method = GetMethodInfoByMethodFullNameAndMethodClass(objSTFieldEventFunctionsInfo.STFieldEventFunctionName,
                                                                                            objSTFieldEventFunctionsInfo.STFieldEventFunctionFullName,
                                                                                            objSTFieldEventFunctionsInfo.STFieldEventFunctionClass);
                            if (method != null)
                                //Invoke method                                
                                method.Invoke(this, GetMethodParameterValues(method.GetParameters(), sender, strEventName));
                        }
                    }
                    dsFieldEventFunctions.Dispose();
                }
            }

        }

        /// <summary>
        /// Control Click Function
        /// </summary>
        /// <param name="sender">object send the click event</param>
        /// <param name="e">Event Arguments</param>
        public void Control_Click(object sender, EventArgs e)
        {
            InvokeAllMethodsForControlEvent(sender, "Click");
        }


        public void Control_MouseUp(object sender, MouseEventArgs e)
        {
            InvokeAllMethodsForControlEvent(sender, "MouseUp");
        }

        public void Control_TextChanged(object sender, EventArgs e)
        {
            InvokeAllMethodsForControlEvent(sender, "TextChanged");
            
        }


        public void Control_Validated(object sender, EventArgs e)
        {
            bool isContinue = true;
            BOSDbUtil dbUtil = new BOSDbUtil();
            Control ctrl = sender as Control;
            if (ctrl is DevExpress.XtraEditors.TextEdit && ctrl.Tag.Equals("DC"))
            {
                if (!Toolbar.IsNullOrNoneAction())
                {
                    STFieldsInfo objSTFieldsInfo = new STFieldsController().GetFieldBySTModuleIDAndSTUserGroupIDAndSTFieldName
                                                                            (ModuleID, BOSApp.CurrentUserGroupInfo.ADUserGroupID,
                                                                             ctrl.Name);
                    if (objSTFieldsInfo != null)
                    {
                        String strTableName = objSTFieldsInfo.STFieldDataSource;
                        String strColumnName = objSTFieldsInfo.STFieldDataMember;
                        if (dbUtil.IsForeignKey(strTableName, strColumnName))
                        {
                            int id = Convert.ToInt32((ctrl as DevExpress.XtraEditors.TextEdit).EditValue);
                            if (id > 0)
                            {
                                String strLookupTable = new BOSDbUtil().GetPrimaryTableWhichForeignColumnReferenceTo(strTableName, strColumnName);
                                BaseBusinessController objBusinessController = BusinessControllerFactory.GetBusinessController(strLookupTable + "Controller");
                                if (!objBusinessController.IsExist(id))
                                {
                                    MessageBox.Show("Invalid input", "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    isContinue = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    isContinue = ctrl.Enabled;
                }
            }

            if (isContinue)
                InvokeAllMethodsForControlEvent(sender, "Validated");
            else
            {
                if (ctrl.Enabled)
                {
                    ctrl.Focus();
                    (ctrl as DevExpress.XtraEditors.TextEdit).EditValue = 0;
                    (ctrl as DevExpress.XtraEditors.TextEdit).SendKeyUp(new KeyEventArgs(Keys.F2));
                }
            }
        }


        public virtual void Control_EditValueChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl is DevExpress.XtraEditors.TextEdit)
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                STFieldsInfo objSTFieldsInfo = new STFieldsController().GetFieldBySTModuleIDAndSTUserGroupIDAndSTFieldName(
                                                                            ModuleID, BOSApp.CurrentUserGroupInfo.ADUserGroupID,
                                                                            ctrl.Name);
                if (objSTFieldsInfo != null)
                {
                    if (dbUtil.IsForeignKey(objSTFieldsInfo.STFieldDataSource, objSTFieldsInfo.STFieldDataMember))
                    {
                        int id = Convert.ToInt32((ctrl as DevExpress.XtraEditors.TextEdit).EditValue);
                        String strLabelName = "fld_lbl" + ctrl.Name.Substring(7);
                        if (Controls[strLabelName] != null)
                        {
                            String strLookupTable = new BOSDbUtil().GetPrimaryTableWhichForeignColumnReferenceTo(objSTFieldsInfo.STFieldDataSource, objSTFieldsInfo.STFieldDataMember);
                            BaseBusinessController objBusinessController = BusinessControllerFactory.GetBusinessController(strLookupTable + "Controller");
                            String strName = objBusinessController.GetObjectNameByID(id);
                            Controls[strLabelName].Text = strName;
                        }
                    }
                }
            }
        }



        public void Control_Enter(object sender, EventArgs e)
        {
            InvokeAllMethodsForControlEvent(sender, "Enter");
        }

        public void Control_Leave(object sender, EventArgs e)
        {
            InvokeAllMethodsForControlEvent(sender, "Leave");
           
        }

        public virtual void Control_KeyDown(object sender, KeyEventArgs e)
        {
            InvokeAllMethodsForControlEvent(sender, "KeyDown");
        }

        public virtual void Control_KeyUp(object sender, KeyEventArgs e)
        {
            BaseActionForControlKeyUp(sender as Control, e);
            InvokeAllMethodsForControlEvent(sender, "KeyUp");
        }

        protected void BaseActionForControlKeyUp(Control ctrl, KeyEventArgs e)
        {
            BOSERPScreen scr = null;
            try
            {
                 scr = (BOSERPScreen)((Control)ctrl.FindForm());
            }
            catch (Exception ex)
            {
                return;
            }
            STFieldsInfo objSTFieldsInfo = new STFieldsController().GetFieldByFieldNameAndScreenIDAndUserGroupID(
                                                                                ctrl.Name,
                                                                                scr.ScreenID,
                                                                                BOSApp.CurrentUserGroupInfo.ADUserGroupID);
            if (objSTFieldsInfo != null)
            {

                if (e.KeyCode == Keys.F2)
                {
                    BOSDbUtil dbUtil = new BOSDbUtil();
                    if (dbUtil.IsForeignKey(objSTFieldsInfo.STFieldDataSource, objSTFieldsInfo.STFieldDataMember))
                    {
                        String strPrimaryTableName = dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(objSTFieldsInfo.STFieldDataSource, objSTFieldsInfo.STFieldDataMember);
                    }
                    else if ((objSTFieldsInfo.STFieldTag == BOSScreen.SearchControl) && !String.IsNullOrEmpty(objSTFieldsInfo.STFieldGroup))
                    {
                        String strPrimaryTableName = objSTFieldsInfo.STFieldGroup;
                    }
                }
                
                else if (e.KeyCode == Keys.Enter)
                {
                    String strFieldTabStopsGroupName = new STFieldTabStopsController().GetFieldTabStopsGroupNameByModuleNameAndFieldName(this.Name, objSTFieldsInfo.STFieldName);
                    if (objSTFieldsInfo.STFieldTag == "DC")
                    {
                        //MoveNextErrorControl(ctrl);
                    }
                    else if (objSTFieldsInfo.STFieldTag == "SC")
                    {
                        Search();
                    }
                    MoveNextControlInFieldTabStopsGroup(strFieldTabStopsGroupName, objSTFieldsInfo.STFieldName);
                }
            }
            
            if (e.KeyCode == Keys.NumLock || e.KeyCode == Keys.CapsLock || e.KeyCode == Keys.Scroll)
            {

                this.ParentScreen.CheckKeyBoard(e);
            }
        }


        public virtual void LookupEdit_PropertiesChanged(object sender, EventArgs e)
        {
            InvokeAllMethodsForControlEvent(sender, "PropertiesChanged");
        }

        public virtual void LookupEdit_EditValueChanged(object sender, EventArgs e)
        {         
            InvokeAllMethodsForControlEvent(sender, "EditValueChanged");
        }
      
        public virtual void CheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            InvokeAllMethodsForControlEvent(sender, "CheckedChanged");
        }

        public virtual void CheckEdit_EditValueChanged(object sender, EventArgs e)
        {
            InvokeAllMethodsForControlEvent(sender, "EditValueChanged");
        }

        public virtual void TextEdit_EditValueChanged(object sender, EventArgs e)
        {
            InvokeAllMethodsForControlEvent(sender, "EditValueChanged");
            
        }
        /// <summary>
        /// Toolbar Button Item Click function
        /// </summary>
        /// <param name="sender">object send Item Click event</param>
        /// <param name="e">Item Click Event Arguments</param>
        public void ScreenToolbarButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraBars.BarLargeButtonItem toolbarButton = (DevExpress.XtraBars.BarLargeButtonItem)e.Item;

            int iScreenID = new STScreensController().GetScreenIDByModuleIDAndUserGroupIDAndScreenName(
                                                        ModuleID, BOSApp.CurrentUserGroupInfo.ADUserGroupID,
                                                        toolbarButton.Manager.Form.Name);
            if (iScreenID > 0)
            {
                BOSLib.STFieldsInfo objSTFieldsInfo = new STFieldsController().GetFieldByFieldNameAndScreenIDAndUserGroupID(toolbarButton.Name, iScreenID, BOSApp.CurrentUserGroupInfo.ADUserGroupID);
                if (objSTFieldsInfo != null)
                {
                    STFieldEventsInfo objSTFieldEventsInfo = new STFieldEventsController().GetFieldEventByFieldIDAndEventName(objSTFieldsInfo.STFieldID, "ItemClick");
                    if (objSTFieldEventsInfo != null)
                    {
                        DataSet dsFieldEventFunctions = new STFieldEventFunctionsController().GetFieldEventFunctionByFieldEventID(objSTFieldEventsInfo.STFieldEventID);
                        if (dsFieldEventFunctions.Tables.Count > 0)
                        {
                            foreach (DataRow rowFieldEventFunction in dsFieldEventFunctions.Tables[0].Rows)
                            {
                                STFieldEventFunctionsInfo objSTFieldEventFunctionsInfo = (STFieldEventFunctionsInfo)new STFieldEventFunctionsController().GetObjectFromDataRow(rowFieldEventFunction);

                                MethodInfo method = GetMethodInfoByMethodFullNameAndMethodClass(objSTFieldEventFunctionsInfo.STFieldEventFunctionName,
                                                                                                objSTFieldEventFunctionsInfo.STFieldEventFunctionFullName,
                                                                                                objSTFieldEventFunctionsInfo.STFieldEventFunctionClass);
                                method.Invoke(this, GetMethodParameterValues(method.GetParameters(), sender, "ItemClick"));
                            }
                        }
                        dsFieldEventFunctions.Dispose();
                    }
                }
            }
        }               

        #region Event for Product Validated, Product Qty Validated, Product unit Price Validated

        public virtual void BOSProductLookupEdit_Validated(object sender, EventArgs e)
        {
            if (!Toolbar.IsNullOrNoneAction())
            {
                BOSLookupEdit lkeProduct = (BOSLookupEdit)sender;
                if (lkeProduct == null)
                    return;
                String strItemTableName = lkeProduct.BOSDataSource;
                int iICProductID = Convert.ToInt32(lkeProduct.EditValue);
                if (iICProductID > 0 && !String.IsNullOrEmpty(strItemTableName))
                {
                    CurrentModuleEntity.SetValuesAfterValidateProduct(iICProductID);
                }
            }
        }

        public virtual void ProductQtyTextEdit_Validated(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit txtProductQty = (DevExpress.XtraEditors.TextEdit)sender;
            if (txtProductQty == null)
                return;
            if (txtProductQty.OldEditValue == txtProductQty.EditValue)
                return;

            CurrentModuleEntity.SetValuesAfterValidateProductQty();
        }

        public virtual void ProductUnitPriceTextEdit_Validated(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit txtProductUnitPrice = (DevExpress.XtraEditors.TextEdit)sender;
            if (txtProductUnitPrice == null)
                return;
            if (txtProductUnitPrice.OldEditValue == txtProductUnitPrice.EditValue)
                return;

            CurrentModuleEntity.SetValuesAfterValidateProductUnitPrice();
        }
        #endregion
        #endregion

        public void BOSLookupEditEmployee_Validated(object sender, EventArgs e)
        {
            BOSLookupEdit lke = (BOSLookupEdit)sender;
            if (lke != null)
            {
                int iEmployeeID = Convert.ToInt32(lke.EditValue);
                if (iEmployeeID > 0)
                {
                    String strTableName = lke.BOSDataSource;
                    CurrentModuleEntity.SetDefaultValuesFromEmployee(iEmployeeID, strTableName); 
                }
            }
        }

        
        /// <summary>
        /// Move next control in TabStop group
        /// </summary>
        public virtual void MoveNextControlInFieldTabStopsGroup(String strGroupName, String strFieldName)
        {
            STFieldTabStopsController objFieldTabStopsController = new STFieldTabStopsController();
            List<STFieldTabStopsInfo> lstFieldTabStopsGroup = objFieldTabStopsController.GetFieldTabStopsGroupByModuleNameAndGroupName(this.Name, strGroupName);

            foreach (STFieldTabStopsInfo objFieldTabStopsInfo in lstFieldTabStopsGroup)
                if (objFieldTabStopsInfo.STFieldName == strFieldName)
                {
                    String strNextControlName;
                    if (objFieldTabStopsInfo.STFieldTabStopAction == "END")
                        strNextControlName = GetNextControlNameByFieldTabStopAction(lstFieldTabStopsGroup, "BEGIN");
                    else
                        strNextControlName = GetNextControlNameByFieldTabStopSortOrder(lstFieldTabStopsGroup, objFieldTabStopsInfo.STFieldTabStopSortOrder + 1);
                    if (Controls[strNextControlName] != null)
                    {
                        Controls[strNextControlName].Focus();
                        (Controls[strNextControlName] as DevExpress.XtraEditors.BaseEdit).SelectAll();
                    }
                    return;
                }
        }

        public String GetNextControlNameByFieldTabStopAction(List<STFieldTabStopsInfo> lstFieldTabStopsGroup, String strFieldTabStopAction)
        {
            foreach (STFieldTabStopsInfo objFieldTabStopsInfo in lstFieldTabStopsGroup)
                if (objFieldTabStopsInfo.STFieldTabStopAction == strFieldTabStopAction)
                    return objFieldTabStopsInfo.STFieldName;
            return String.Empty;
        }

        public String GetNextControlNameByFieldTabStopSortOrder(List<STFieldTabStopsInfo> lstFieldTabStopsGroup, int iSortOrder)
        {
            foreach (STFieldTabStopsInfo objFieldTabStopsInfo in lstFieldTabStopsGroup)
                if (objFieldTabStopsInfo.STFieldTabStopSortOrder == iSortOrder)
                    return objFieldTabStopsInfo.STFieldName;
            return String.Empty;
        }

        /// <summary>
        /// Check whether the module can switch to edit mode
        /// </summary>
        /// <returns>True if can, otherwise false</returns>
        public bool IsEditable()
        {
            BarItem barItem = ParentScreen.GetToolbarButton(BaseToolbar.ToolbarButtonEdit);
            if (barItem != null && barItem.Visibility != BarItemVisibility.Never && barItem.Enabled)
            {
                if (Toolbar.IsNullOrNoneAction() && Toolbar.CurrentObjectID > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Automatically switch module to edit mode whenever an object is changed
        /// </summary>
        /// <param name="obj">Business object is changed</param>
        /// <param name="strPropertyName">Property name whose value is changed</param>
        /// <returns>True if can switch module to edit mode, otherwise false</returns>
        public virtual bool SwitchToEditMode(BusinessObject obj, String strPropertyName)
        {
            if (IsEditable())
            {
                if (obj.AllowPropertyChangedEvent)
                {
                    BOSDbUtil dbUtil = new BOSDbUtil();
                    if (String.IsNullOrEmpty(strPropertyName) || dbUtil.ColumnIsExist(BOSUtil.GetTableNameFromBusinessObject(obj), strPropertyName))
                    {
                        ActionEdit();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
