using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using BOSLib;

namespace BOSComponent
{
    public class BOSControlUtil
    {
        public static bool IsAnchorControl(Control ctrl)
        {
            Type ctrlType = ctrl.GetType();
            if (ctrlType == typeof(BOSGridControl) || ctrlType.BaseType == typeof(BOSGridControl) ||
                ctrlType == typeof(BOSTreeListControl) || ctrlType.BaseType == typeof(BOSTreeListControl) ||
                ctrlType == typeof(BOSPivotGridControl) || ctrlType == typeof(BOSChartControl) ||
                ctrlType == typeof(BOSGroupControl) || ctrlType == typeof(BOSTabControl))
                return true;
            return false;
        }
      
        /// <summary>
        /// Get STFieldsInfo from control
        /// </summary>
        public static STFieldsInfo GetControlInfo(Control ctrl, int moduleID, int screenID)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            STFieldsController objFieldsController = new STFieldsController();
            STFieldsInfo objFieldsInfo = objFieldsController.GetFieldByFieldNameAndScreenID(ctrl.Name, screenID);
            if (objFieldsInfo == null)
                objFieldsInfo = new STFieldsInfo();
            objFieldsInfo.STScreenID = screenID;
            objFieldsInfo.STUserGroupID = 1;
            objFieldsInfo.STFieldName = ctrl.Name;
            objFieldsInfo.STFieldType = ctrl.GetType().Name;

            //Get common Properties
            objFieldsInfo.STFieldBackColor = ctrl.BackColor.ToArgb();
            objFieldsInfo.STFieldForeColor = ctrl.ForeColor.ToArgb();
            objFieldsInfo.STFieldFontName = ctrl.Font.Name;
            objFieldsInfo.STFieldText = ctrl.Text;
            objFieldsInfo.STFieldFontSize = Convert.ToDouble(ctrl.Font.Size);
            objFieldsInfo.STFieldFontStyle = ctrl.Font.Style.ToString();
            objFieldsInfo.STFieldEnabled = ctrl.Enabled;
            objFieldsInfo.STFieldLocationX = ctrl.Location.X;
            objFieldsInfo.STFieldLocationY = ctrl.Location.Y;
            objFieldsInfo.STFieldSizeWidth = ctrl.Size.Width;
            objFieldsInfo.STFieldSizeHeight = ctrl.Size.Height;
            objFieldsInfo.STFieldTabIndex = ctrl.TabIndex;
            objFieldsInfo.STFieldDock = ctrl.Dock.ToString();
            objFieldsInfo.STFieldStatus = "Active";
            if (ctrl.Tag != null)
                objFieldsInfo.STFieldTag = ctrl.Tag.ToString();
            objFieldsInfo.STFieldVisible = ctrl.Visible;
            objFieldsInfo.STFieldHint = dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstCommentPropertyName);
            objFieldsInfo.STFieldGroup = dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstFieldGroupPropertyName);
            objFieldsInfo.STFieldDataSource = dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstDataSourcePropertyName);
            objFieldsInfo.STFieldDataMember = dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstDataMemberPropertyName);
            objFieldsInfo.STFieldBindingPropertyName = dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstBindingPropertyName);
            objFieldsInfo.STFieldError = dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstErrorPropertyName);
            objFieldsInfo.STFieldPrivilege = dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstPrivilegePropertyName);
            objFieldsInfo.STFieldDesc = dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstDescriptionPropertyName);

            //Get specific properties
            #region case:BOSTextBox
            if (ctrl.GetType().Name == typeof(BOSTextBox).Name)
            {
                BOSTextBox txt = (BOSTextBox)ctrl;
                objFieldsInfo.STFieldEditMask = txt.Properties.Mask.EditMask;
                objFieldsInfo.STFieldMaskType = txt.Properties.Mask.MaskType.ToString();
                objFieldsInfo.STFieldCharacterCase = txt.Properties.CharacterCasing.ToString();
                objFieldsInfo.STFieldReadOnly = txt.Properties.ReadOnly;
                objFieldsInfo.STFieldRightToLeft = txt.RightToLeft.ToString();
                objFieldsInfo.STFieldBorderStyle = txt.Properties.BorderStyle.ToString();
            }
            #endregion

            #region case:BOSMemoEdit
            else if (ctrl.GetType().Name == typeof(BOSMemoEdit).Name)
            {
                BOSMemoEdit med = (BOSMemoEdit)ctrl;
                objFieldsInfo.STFieldCharacterCase = med.Properties.CharacterCasing.ToString();
                objFieldsInfo.STFieldReadOnly = med.Properties.ReadOnly;
                objFieldsInfo.STFieldScrollBars = med.Properties.ScrollBars.ToString();
            }
            #endregion

            #region case:BOSButton
            else if (ctrl.GetType().Name == typeof(BOSButton).Name)
            {
                BOSButton btn = (BOSButton)ctrl;
            }
            #endregion

            #region case:BOSComboBox
            else if (ctrl.GetType().Name == typeof(BOSComboBox).Name)
            {
                BOSComboBox cmb = (BOSComboBox)ctrl;
                objFieldsInfo.STFieldTextEditStyle = cmb.Properties.TextEditStyle.ToString();
            }
            #endregion

            #region case:BOSDateEdit
            else if (ctrl.GetType().Name == typeof(BOSDateEdit).Name)
            {
                BOSDateEdit dtp = (BOSDateEdit)ctrl;
                objFieldsInfo.STFieldEditMask = dtp.Properties.Mask.EditMask;
            }
            #endregion

            #region case:BOSTimeEdit
            else if (ctrl.GetType().Name == typeof(BOSDateEdit).Name)
            {
                BOSTimeEdit ted = (BOSTimeEdit)ctrl;
            }
            #endregion

            #region case:BOSLabel
            else if (ctrl.GetType().Name == typeof(BOSLabel).Name)
            {
                BOSLabel lbl = (BOSLabel)ctrl;
                objFieldsInfo.STFieldTextAlign = ContentAlignment.TopLeft.ToString();
            }
            #endregion

            #region case:BOSCheckEdit
            else if (ctrl.GetType().Name == typeof(BOSCheckEdit).Name)
            {
                BOSCheckEdit chk = (BOSCheckEdit)ctrl;
                objFieldsInfo.STFieldCheckedStyle = chk.Properties.CheckStyle.ToString();
            }
            #endregion

            #region case:Line
            else if (ctrl.GetType().Name == typeof(BOSLine).Name)
            {
                BOSLine line = (BOSLine)ctrl;
            }
            #endregion

            #region case:PictureEdit
            else if (ctrl.GetType().Name == typeof(BOSPictureEdit).Name)
            {
                BOSPictureEdit pictureEdit = (BOSPictureEdit)ctrl;
            }
            #endregion

            #region case:LookupEdit
            else if (ctrl.GetType().Name == typeof(BOSLookupEdit).Name || ctrl.GetType().BaseType.Name == typeof(BOSLookupEdit).Name)
            {
                BOSLookupEdit lookupEdit = (BOSLookupEdit)ctrl;
                objFieldsInfo.STFieldDisplayMember = lookupEdit.Properties.DisplayMember;
                objFieldsInfo.STFieldValueMember = lookupEdit.Properties.ValueMember;
                objFieldsInfo.STFieldFieldParent = lookupEdit.BOSFieldParent;
                objFieldsInfo.STFieldAllowDummy = lookupEdit.BOSAllowDummy;
                objFieldsInfo.STFieldSelectType = lookupEdit.BOSSelectType;
                objFieldsInfo.STFieldSelectTypeValue = lookupEdit.BOSSelectTypeValue;
            }
            #endregion

            #region case: BOSGridControl
            else if (ctrl.GetType().Name == typeof(BOSGridControl).Name || ctrl.GetType().BaseType.Name == typeof(BOSGridControl).Name)
            {
                BOSGridControl gridControl = (BOSGridControl)ctrl;
            }
            #endregion

            #region case:BOSGroupControl
            else if (ctrl.GetType().Name == typeof(BOSGroupControl).Name)
            {
                BOSGroupControl grc = (BOSGroupControl)ctrl;
            }
            #endregion

            #region case: BOSTreeList
            else if (ctrl.GetType().Name == typeof(BOSTreeListControl).Name || ctrl.GetType().BaseType.Name == typeof(BOSTreeListControl).Name)
            {
                BOSTreeListControl treeList = (BOSTreeListControl)ctrl;
                objFieldsInfo.STFieldDisplayRoot = treeList.BOSDisplayRoot;
                objFieldsInfo.STFieldDisplayOption = treeList.BOSDisplayOption;
            }
            #endregion

            #region case: BOSPivotGridControl
            else if (ctrl.GetType().Name == typeof(BOSPivotGridControl).Name)
            {
                BOSPivotGridControl pivotGrid = (BOSPivotGridControl)ctrl;
            }
            #endregion

            #region case: BOSChartControl
            else if (ctrl.GetType().Name == typeof(BOSChartControl).Name)
            {
                BOSChartControl chartControl = (BOSChartControl)ctrl;
            }
            #endregion

            #region case: BOSTabControl
            else if (ctrl.GetType().Name == typeof(BOSTabControl).Name)
            {
                BOSTabControl tabControl = (BOSTabControl)ctrl;
            }
            #endregion

            #region case: BOSButtonEdit
            else if (ctrl.GetType().Name == typeof(BOSButtonEdit).Name)
            {
                BOSButtonEdit bed = (BOSButtonEdit)ctrl;
                objFieldsInfo.STFieldEditMask = bed.Properties.Mask.EditMask;
                objFieldsInfo.STFieldMaskType = bed.Properties.Mask.MaskType.ToString();
                objFieldsInfo.STFieldCharacterCase = bed.Properties.CharacterCasing.ToString();
                objFieldsInfo.STFieldReadOnly = bed.Properties.ReadOnly;
                objFieldsInfo.STFieldRightToLeft = bed.RightToLeft.ToString();
                objFieldsInfo.STFieldBorderStyle = bed.Properties.BorderStyle.ToString();
            }
            #endregion
            return objFieldsInfo;
        }

        public static void SetControlCommonProperties(Control ctrl, STFieldsInfo objFieldInfo)
        {
            ctrl.Name = objFieldInfo.STFieldName;
            if (ctrl.GetType() != typeof(BOSPictureEdit))
            {
                ctrl.Text = objFieldInfo.STFieldText;
            }
            //ctrl.BackColor = Color.FromArgb(objFieldInfo.STFieldBackColor);
            ctrl.ForeColor = Color.FromArgb(objFieldInfo.STFieldForeColor);
            ctrl.Font = new Font(objFieldInfo.STFieldFontName, (float)objFieldInfo.STFieldFontSize, (FontStyle)Enum.Parse(typeof(FontStyle), objFieldInfo.STFieldFontStyle));
            ctrl.Location = new Point(objFieldInfo.STFieldLocationX, objFieldInfo.STFieldLocationY);
            ctrl.Size = new Size(objFieldInfo.STFieldSizeWidth, objFieldInfo.STFieldSizeHeight);
            ctrl.Enabled = objFieldInfo.STFieldEnabled;
            ctrl.TabIndex = objFieldInfo.STFieldTabIndex;
            ctrl.Tag = objFieldInfo.STFieldTag;
            if (!String.IsNullOrEmpty(objFieldInfo.STFieldDock))
                ctrl.Dock = (DockStyle)Enum.Parse(typeof(DockStyle), objFieldInfo.STFieldDock);
            ctrl.Visible = objFieldInfo.STFieldVisible;

            BOSDbUtil dbUtil = new BOSDbUtil();
            dbUtil.SetPropertyValue(ctrl, BOSScreen.cstDataSourcePropertyName, objFieldInfo.STFieldDataSource);
            dbUtil.SetPropertyValue(ctrl, BOSScreen.cstDataMemberPropertyName, objFieldInfo.STFieldDataMember);
            dbUtil.SetPropertyValue(ctrl, BOSScreen.cstBindingPropertyName, objFieldInfo.STFieldBindingPropertyName);
            dbUtil.SetPropertyValue(ctrl, BOSScreen.cstFieldGroupPropertyName, objFieldInfo.STFieldGroup);
            dbUtil.SetPropertyValue(ctrl, BOSScreen.cstCommentPropertyName, objFieldInfo.STFieldHint);
            dbUtil.SetPropertyValue(ctrl, BOSScreen.cstErrorPropertyName, objFieldInfo.STFieldError);
            dbUtil.SetPropertyValue(ctrl, BOSScreen.cstPrivilegePropertyName, objFieldInfo.STFieldPrivilege);
            dbUtil.SetPropertyValue(ctrl, BOSScreen.cstDescriptionPropertyName, objFieldInfo.STFieldDesc);
        }

        /// <summary>
        /// Remove control events 
        /// </summary>
        /// <param name="ctrl">Control whose events will be removed</param>
        public static void RemoveControlEvents(Control ctrl)
        {
            if (ctrl is LinkLabel)
            {
                PropertyInfo pi = ctrl.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                if (pi != null)
                {
                    EventHandlerList list = (EventHandlerList)pi.GetValue(ctrl, null);
                    FieldInfo fi = typeof(LinkLabel).GetField("EventLinkClicked", 
                                                                        BindingFlags.Static | BindingFlags.NonPublic);
                    
                    if (list != null && fi != null)
                    {
                        object obj = fi.GetValue(ctrl);
                        list.RemoveHandler(obj, list[obj]);
                    }
                }
            }

            if (ctrl is ComboBoxEdit)
            {
                PropertyInfo pi = ctrl.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                if (pi != null)
                {
                    EventHandlerList list = (EventHandlerList)pi.GetValue(ctrl, null);
                    Type type = ctrl.GetType();
                    FieldInfo[] fis = typeof(System.Windows.Forms.ComboBox).GetFields(BindingFlags.Static | BindingFlags.NonPublic);
                    FieldInfo fi = typeof(System.Windows.Forms.ComboBox).GetField("EVENT_SELECTEDINDEXCHANGED", BindingFlags.Static | BindingFlags.NonPublic);

                    if (list != null && fi != null)
                    {
                        object obj = fi.GetValue(ctrl);
                        list.RemoveHandler(obj, list[obj]);
                    }
                }
            }

            EventInfo[] eventInfos = typeof(Control).GetEvents();
            foreach (EventInfo eventInfo in eventInfos)
            {
                if (ctrl is TextBox)
                {
                    if (eventInfo.Name == "MouseDown" || eventInfo.Name == "MouseMove")
                    {
                        continue;
                    }
                }
                BOSControlUtil.RemoveControlEvent(ctrl, string.Format("Event{0}", eventInfo.Name));
            }
        }

        /// <summary>
        /// Remove the specific event from a control
        /// </summary>
        /// <param name="ctrl">Control from which the event is removed</param>
        /// <param name="eventName">Event name</param>
        public static void RemoveControlEvent(Control ctrl, String eventName)
        {
            PropertyInfo pi = ctrl.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
            if (pi != null)
            {
                EventHandlerList list = (EventHandlerList)pi.GetValue(ctrl, null);
                FieldInfo fi = typeof(Control).GetField(eventName, BindingFlags.Static | BindingFlags.NonPublic);
                if (list != null && fi != null)
                {
                    object obj = fi.GetValue(ctrl);
                    list.RemoveHandler(obj, list[obj]);
                }
            }
        }
    }
}
