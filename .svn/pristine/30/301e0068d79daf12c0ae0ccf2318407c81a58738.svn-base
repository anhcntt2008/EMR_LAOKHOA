using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using BOSLib;
using CommonResources;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraTab;
using Localization;

namespace BOSERP
{
    public class BOSERPScreen : BOSScreen
    {
        private readonly BOSDbUtil _dbUtil;
        private readonly STFieldPermissionsController _objFieldPermissionsController;
        private readonly STFieldsController _objFieldsController;
        private readonly STScreensController _objStScreensController;

        #region Constructor

        public BOSERPScreen()
        {
            Fields = new SortedList<string, STFieldsInfo>();
            FieldPermissions = new SortedList<string, STFieldPermissionsInfo>();
            CustomRequiredFields = new SortedList<string, List<string>>();
            Load += BOSERPScreen_Load0;
            _dbUtil = new BOSDbUtil();
            _objFieldsController = new STFieldsController();
            _objFieldPermissionsController = new STFieldPermissionsController();
            _objStScreensController = new STScreensController();
        }

        #endregion

        /// <summary>
        ///     Init display format of a specific control
        /// </summary>
        public virtual void InitializeFieldFormat(Control ctrl)
        {
            var tableName = _dbUtil.GetPropertyStringValue(ctrl, cstDataSourcePropertyName);
            var columnName = _dbUtil.GetPropertyStringValue(ctrl, cstDataMemberPropertyName);
            if (!string.IsNullOrEmpty(tableName) && !string.IsNullOrEmpty(columnName))
            {
                var objFieldFormatGroupsInfo = Module.GetColumnFormat(tableName, columnName);
                if (objFieldFormatGroupsInfo != null)
                {
                    if (objFieldFormatGroupsInfo.STFieldFormatGroupBackColor > 0)
                        ctrl.BackColor = Color.FromArgb(objFieldFormatGroupsInfo.STFieldFormatGroupBackColor);
                    if (objFieldFormatGroupsInfo.STFieldFormatGroupForeColor > 0)
                        ctrl.ForeColor = Color.FromArgb(objFieldFormatGroupsInfo.STFieldFormatGroupForeColor);

                    var strDefaultFontName = "Tahoma";
                    var fDefaultFontSize = 8.25F;
                    if (!string.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupFontName))
                        strDefaultFontName = objFieldFormatGroupsInfo.STFieldFormatGroupFontName;
                    if (objFieldFormatGroupsInfo.STFieldFormatGroupFontSize > 0)
                        fDefaultFontSize = objFieldFormatGroupsInfo.STFieldFormatGroupFontSize;
                    ctrl.Font = new Font(strDefaultFontName, fDefaultFontSize);

                    if (BOSUtil.IsEditControl(ctrl))
                    {
                        var txt = (TextEdit)ctrl;
                        if (objFieldFormatGroupsInfo.STFieldFormatGroupDecimalRound > 0)
                        {
                            txt.Properties.Mask.MaskType = MaskType.Numeric;
                            txt.Properties.Mask.EditMask = string.Format("n{0}",
                                objFieldFormatGroupsInfo.STFieldFormatGroupDecimalRound);
                            txt.Properties.Mask.UseMaskAsDisplayFormat = true;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupMaskType))
                            {
                                txt.Properties.Mask.MaskType =
                                    BOSUtil.GetMaskTypeFromText(objFieldFormatGroupsInfo.STFieldFormatGroupMaskType);
                                txt.Properties.Mask.EditMask = objFieldFormatGroupsInfo.STFieldFormatGroupMaskEdit;
                                txt.Properties.Mask.UseMaskAsDisplayFormat = true;
                            }
                            if (!string.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupFormatType))
                            {
                                txt.Properties.DisplayFormat.FormatType =
                                    BOSUtil.GetFormatTypeFromText(objFieldFormatGroupsInfo.STFieldFormatGroupFormatType);
                                txt.Properties.DisplayFormat.FormatString =
                                    objFieldFormatGroupsInfo.STFieldFormatGroupFormatString;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Add all controls of module screens to various sections of parent screen
        ///     based on control's tag
        /// </summary>
        public virtual void AddControlsToParentScreen()
        {
            //If screen is data main one, add tab page to screen container
            if (IsDataMainScreen())
            {
                var tpScreen = new XtraTabPage
                {
                    Text = Text,
                    Name = ScreenNumber,
                    AutoScroll = true,
                    AutoScrollMinSize = new Size(Width, Height - 100)
                };
                var itemGridControls = FindControls("ItemGridControl");
                if (itemGridControls.Count > 0)
                    tpScreen.AutoScrollMinSize = new Size(Width, Height);
                ((BaseModuleERP)Module).ParentScreen.ScreenContainer.TabPages.Add(tpScreen);
            }

            var parentScreen = ((BaseModuleERP)Module).ParentScreen;
            if (IsSearchQuickScreen())
            {
                if (Controls.Count > 0)
                {
                    parentScreen.SearchQuickContainer.Height = Controls[0].Height + parentScreen.SearchQuickContainer.Height;
                    for (var i = 0; i < Controls[0].Controls.Count; i++)
                    {
                        var ctrl = Controls[0].Controls[i];
                        parentScreen.SearchQuickContainer.Controls.Add(ctrl);
                        i--;
                    }
                    parentScreen.SearchResultsContainer.Location = new Point(0, parentScreen.SearchResultsContainer.Location.Y + Controls[0].Height);
                    parentScreen.SearchResultsContainer.Height = parentScreen.SearchResultsContainer.Height - Controls[0].Height;
                }
                return;
            }
            for (var i = 0; i < Controls.Count; i++)
            {
                var ctrl = Controls[i];

                var flag = false;
                if (ctrl.Tag != null)
                    switch (ctrl.Tag.ToString())
                    {
                        case SearchResultControl:
                            var controlSize = parentScreen.SearchResultsContainer.Size;
                            ctrl.Size = controlSize;
                            ctrl.TabStop = false;
                            parentScreen.SearchResultsContainer.Controls.Add(ctrl);
                            parentScreen.SearchResultsContainer.Controls[ctrl.Name].Dock = DockStyle.Fill;
                            i--;
                            flag = true;
                            break;
                        case SearchInfo:
                        case SearchControl:
                            if (IsSearchMainScreen())
                            {
                                ((BaseModuleERP)Module).SearchScreen.CriteriaSection.Controls.Add(ctrl);
                                i--;
                                flag = true;
                            }
                            break;
                    }
                if (flag == false)
                    if (parentScreen.ScreenContainer.TabPages.Count > 0)
                    {
                        parentScreen.ScreenContainer.TabPages[parentScreen.ScreenContainer.TabPages.Count - 1].Controls
                            .Add(ctrl);
                        i--;
                    }
            }
        }

        /// <summary>
        ///     Find controls by a given type
        /// </summary>
        /// <param name="controlType">Control type</param>
        /// <returns>Controls match the given type</returns>
        public List<Control> FindControls(string controlType)
        {
            var result = new List<Control>();
            FindControls(controlType, Controls, ref result);
            return result;
        }

        /// <summary>
        ///     Find controls by a given type
        /// </summary>
        /// <param name="controlType">Control type</param>
        /// <param name="controls">Control collection to find</param>
        /// <param name="result">A ref parameter contains matching controls</param>
        private void FindControls(string controlType, Control.ControlCollection controls, ref List<Control> result)
        {
            foreach (Control ctrl in controls)
            {
                var memberInfo = ctrl.GetType().BaseType;
                if (memberInfo != null && (ctrl.GetType().Name == controlType || memberInfo.Name == controlType))
                    result.Add(ctrl);
                if (ctrl.Controls.Count > 0)
                    FindControls(controlType, ctrl.Controls, ref result);
            }
        }

        /// <summary>
        ///     Display text basing on business object for all labels of the screen
        /// </summary>
        public virtual void DisplayLabelText(BusinessObject obj, Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                ((BaseModuleERP)Module).DisplayLabelText(obj, ctrl);
                if (ctrl.Controls.Count > 0)
                    DisplayLabelText(obj, ctrl.Controls);
            }
        }

        #region Constants

        #endregion

        #region Variables

        protected STScreensInfo _screenInfo;
        protected int _sortOrder;

        /// <summary>
        ///     A variable to store custom required fields of the screen
        /// </summary>
        protected SortedList<string, List<string>> CustomRequiredFields;

        #endregion

        #region Properties

        /// <summary>
        ///     STScreensInfo of the screen
        /// </summary>
        public STScreensInfo ScreenInfo
        {
            get { return _screenInfo; }
            set { _screenInfo = value; }
        }

        /// <summary>
        ///     The order of the screen in the screen list of a module
        /// </summary>
        public int SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }

        #endregion

        #region Functions to Init Screen

        public override BOSScreen Recreate()
        {
            var scr = BOSERPScreenFactory.GetScreen(ScreenNumber, Module.Name);
            scr.Name = Name;
            scr.ScreenNumber = ScreenNumber;
            scr.Module = Module;
            scr.InitializeScreen(_screenInfo);
            return scr;
        }

        private void BOSERPScreen_Load0(object sender, EventArgs e)
        {
            Icon = Resources.clas_logo;
        }

        public virtual void InitializeScreen(STScreensInfo objStScreensInfo)
        {
            SuspendLayout();

            ScreenInfo = objStScreensInfo;

            if (ScreenInfo != null)
            {
                ScreenID = ScreenInfo.STScreenID;
                ScreenNumber = ScreenInfo.STScreenNumber;

                MouseUp += Screen_MouseUp;
                ForeColor = Color.FromArgb(ScreenInfo.STScreenForeColor);
                Font = new Font(ScreenInfo.STScreenFontName, (float)ScreenInfo.STScreenFontSize,
                    (FontStyle)Enum.Parse(typeof(FontStyle), ScreenInfo.STScreenFontStyle));
                Tag = ScreenInfo.STScreenTag;
                Icon = Resources.clas_logo;
                if (IsDataSubScreen())
                    FormClosing += Screen_Closing;
                if (ScreenInfo.STScreenTag == BaseModule.cstDataSubScreen)
                {
                    Location = new Point(ScreenInfo.STScreenLocationX, ScreenInfo.STScreenLocationY);
                    Size = new Size(ScreenInfo.STScreenSizeWidth, ScreenInfo.STScreenSizeHeight);
                }

                GetFields();
                GetFieldPermissions();

                //AddCustomControls(Module.Screens);                
                //CustomizeControls(this.Controls);
                InitializeControls(Controls);
                ResumeLayout(false);
                PerformLayout();
            }
        }

        /// <summary>
        ///     Get all fields of the screen
        /// </summary>
        public virtual void GetFields()
        {
            Fields.Clear();
            var fieldList = _objFieldsController.GetAllFieldsByScreenID(ScreenID);
            foreach (var objFieldsInfo in fieldList)
                if (!Fields.ContainsKey(objFieldsInfo.STFieldName))
                    Fields.Add(objFieldsInfo.STFieldName, objFieldsInfo);
        }

        /// <summary>
        ///     Get permission list of all fields of the screen
        /// </summary>
        private void GetFieldPermissions()
        {
            FieldPermissions.Clear();
            var fieldPermissionList =
                _objFieldPermissionsController.GetFieldPermissionsByUserGroupIDAndModuleNameAndScreenName(
                    BOSApp.CurrentUserGroupInfo.ADUserGroupID, Module.Name, Name);
            foreach (var objFieldPermissionsInfo in fieldPermissionList)
                if (!FieldPermissions.ContainsKey(objFieldPermissionsInfo.STFieldName))
                    FieldPermissions.Add(objFieldPermissionsInfo.STFieldName, objFieldPermissionsInfo);
        }

        private void InitScreenLookAndFeel()
        {
            var objADUsersInfo = (ADUsersInfo)new ADUsersController().GetObjectByName(BOSApp.CurrentUser);
            if (!string.IsNullOrEmpty(objADUsersInfo.ADUserStyle))
            {
                if (objADUsersInfo.ADUserStyle == "XP")
                    LookAndFeel.SetStyle((LookAndFeelStyle)Enum.Parse(typeof(LookAndFeelStyle), "Office2003"), true,
                        true, objADUsersInfo.ADUserStyleSkin);
                else
                    LookAndFeel.SetStyle(
                        (LookAndFeelStyle)Enum.Parse(typeof(LookAndFeelStyle), objADUsersInfo.ADUserStyle), false,
                        false, objADUsersInfo.ADUserStyleSkin);
                if (objADUsersInfo.ADUserStyle.Equals("Skin"))
                    LookAndFeel.SetSkinStyle(objADUsersInfo.ADUserStyleSkin);
            }
            else
            {
                LookAndFeel.SetStyle(LookAndFeelStyle.Office2003, false, false, objADUsersInfo.ADUserStyleSkin);
            }
        }
        public virtual void InitializeControls(Control.ControlCollection controls)
        {
            try
            {
                //Comment for not using
                //STModulesController objModulesController = new STModulesController();
                //STFieldsController objFieldsController = new STFieldsController();
                //STFieldFormatGroupsController objFieldFormatGroupsController = new STFieldFormatGroupsController();
                for (var i = 0; i < controls.Count; i++)
                {
                    var ctrl = controls[i];
                    ctrl = InitializeControl(ctrl);

                    SetPermission(ctrl);

                    //Init field format
                    InitializeFieldFormat(ctrl);

                    var strDataSource = _dbUtil.GetPropertyStringValue(ctrl, cstDataSourcePropertyName);
                    var strDataMember = _dbUtil.GetPropertyStringValue(ctrl, cstDataMemberPropertyName);
                    ctrl.AccessibleName = string.Format("{0};{1}", strDataSource, strDataMember);

                    var strFieldGroup = _dbUtil.GetPropertyStringValue(ctrl, cstFieldGroupPropertyName);
                    //Add field to module's control collection 
                    if (!Module.Contains(ctrl.Name))
                        Module.Controls.Add(ctrl.Name, ctrl);
                    else
                        Module.Controls[ctrl.Name] = ctrl;

                    //Add control to its corresponding group
                    if (!string.IsNullOrEmpty(strFieldGroup))
                    {
                        var groups = strFieldGroup.Split(';');
                        for (var j = 0; j < groups.Length; j++)
                        {
                            var group = groups[j].Trim();
                            if (!string.IsNullOrEmpty(group))
                            {
                                var module = (BaseModuleERP)Module;
                                if (!module.FieldGroupControls.ContainsKey(group))
                                    module.FieldGroupControls.Add(group, new BOSLib.ControlCollection());
                                if (!module.FieldGroupControls[group].Contains(ctrl.Name))
                                    module.FieldGroupControls[group].Add(ctrl.Name, ctrl);
                                else
                                    module.FieldGroupControls[group][ctrl.Name] = ctrl;
                                switch (group)
                                {
                                    case cstFieldGroupNonCreatable:
                                    case cstFieldGroupNonEditable:
                                    case cstFieldGroupAction:
                                        ctrl.Enabled = false;
                                        break;
                                    case cstFieldGroupNonAction:
                                        ctrl.Enabled = true;
                                        break;
                                }
                            }
                        }
                    }

                    //Add custom require fields
                    if (!string.IsNullOrEmpty(strDataSource))
                        if (!CustomRequiredFields.ContainsKey(strDataSource))
                        {
                            var requiredFields = new List<string>();
                            var objectType = BusinessObjectFactory.GetBusinessObjectType(strDataSource + "Info");
                            if (objectType != null)
                            {
                                var props = objectType.GetProperties();
                                foreach (var prop in props)
                                {
                                    //Find property binding to this column then get its required attribute
                                    RequiredAttribute requiredAttr = null;
                                    var attrs = prop.GetCustomAttributes(typeof(RequiredAttribute), true);
                                    if (attrs.Length > 0)
                                        requiredAttr = (RequiredAttribute)attrs[0];
                                    if (requiredAttr != null)
                                        requiredFields.Add(prop.Name);
                                }
                            }
                            CustomRequiredFields.Add(strDataSource, requiredFields);
                        }

                    if (ctrl.Controls.Count > 0)
                        InitializeControls(ctrl.Controls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///     Add custom controls to screen. These controls are added by user
        /// </summary>
        /// <param name="screens">Screen list of the module</param>
        public virtual void AddCustomControls(IList<BOSScreen> screens)
        {
            var ds = _objFieldsController.GetFieldsByScreenIDAndFieldGroup(ScreenID, cstFieldGroupCustom);
            if (ds.Tables.Count > 0)
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var objFieldsInfo = (STFieldsInfo)_objFieldsController.GetObjectFromDataRow(row);
                    Control ctrl;
                    if (objFieldsInfo.STFieldType == typeof(XtraTabPage).Name)
                        ctrl = new XtraTabPage();
                    else
                        ctrl =
                            (Control)
                            BaseClassFactory.GetClass(string.Format("{0}.{1}", "BOSComponent", objFieldsInfo.STFieldType));
                    if (ctrl != null)
                    {
                        BOSControlUtil.SetControlCommonProperties(ctrl, objFieldsInfo);
                        var mi = ctrl.GetType().GetMethod("InitializeControl", new[] { typeof(STFieldsInfo) });
                        if (mi != null)
                            mi.Invoke(ctrl, new object[] { objFieldsInfo });
                        Controls.Add(ctrl);
                    }
                }

            //Through customization, user may move controls from one screen to another
            //Add controls of other screens to the target one
            foreach (var objFieldsInfo in Fields.Values)
                if (!string.IsNullOrEmpty(objFieldsInfo.STFieldName) && objFieldsInfo.STScreenID == ScreenID)
                {
                    var foundControls = Controls.Find(objFieldsInfo.STFieldName, true);
                    if (foundControls.Length == 0)
                        foreach (var screen in screens)
                            if (screen.ScreenID != ScreenID)
                            {
                                foundControls = screen.Controls.Find(objFieldsInfo.STFieldName, true);
                                if (foundControls.Length > 0)
                                {
                                    Controls.Add(foundControls[0]);
                                    break;
                                }
                            }
                }
        }

        /// <summary>
        ///     Add asterisk, search button... next to their owner
        /// </summary>
        public virtual void AddExtraControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                //uthv mot so control dc add bang tay ko co trong db
                //if (ctrl.Visible && ctrl.Enabled)
                if (ctrl.Enabled)
                    if (!(ctrl is BOSLabel) && !(ctrl is BOSRadioGroup))
                    {
                        //Create * label automatic for all labels which is not allow null
                        var dataSource = _dbUtil.GetPropertyStringValue(ctrl, cstDataSourcePropertyName);
                        var dataMember = _dbUtil.GetPropertyStringValue(ctrl, cstDataMemberPropertyName);
                        if (!string.IsNullOrEmpty(dataSource) && !string.IsNullOrEmpty(dataMember))
                        {
                            var isRequired = !_dbUtil.ColumnIsAllowNull(dataSource, dataMember);
                            if (!isRequired)
                                if (CustomRequiredFields.ContainsKey(dataSource))
                                {
                                    var temp =
                                        CustomRequiredFields[dataSource].Where(propName => propName == dataMember)
                                            .FirstOrDefault();
                                    if (!string.IsNullOrEmpty(temp))
                                        isRequired = true;
                                }
                            if (isRequired)
                            {
                                //uthv chi thay doi mau control. ko them label chi

                                ctrl.BackColor = Color.LightYellow;

                                //var asterisk = new BOSLabel { Text = "*" };
                                //asterisk.Appearance.ForeColor = Color.Red;
                                //asterisk.Location = new Point(ctrl.Location.X + ctrl.Width + 3, ctrl.Location.Y);
                                //asterisk.Parent = ctrl.Parent;
                                //asterisk.Anchor = AnchorStyles.None;
                                //if ((ctrl.Anchor & AnchorStyles.Right) == AnchorStyles.Right)
                                //    asterisk.Anchor = asterisk.Anchor | AnchorStyles.Right;
                                //else
                                //    asterisk.Anchor = asterisk.Anchor | AnchorStyles.Left;
                                //if ((ctrl.Anchor & AnchorStyles.Bottom) == AnchorStyles.Bottom)
                                //    asterisk.Anchor = asterisk.Anchor | AnchorStyles.Bottom;
                                //else
                                //    asterisk.Anchor = asterisk.Anchor | AnchorStyles.Top;
                            }
                        }
                    }
                if (ctrl.Controls.Count > 0)
                    AddExtraControls(ctrl.Controls);
            }
        }


        /// <summary>
        ///     Customize controls based on database
        /// </summary>
        /// <param name="controls">Control collection of screen</param>
        public void CustomizeControls(Control.ControlCollection controls)
        {
            for (var i = 0; i < controls.Count; i++)
            {
                var ctrl = controls[i];
                if (!string.IsNullOrEmpty(ctrl.Name))
                {
                    STFieldsInfo objFieldsInfo = null;
                    if (Fields.ContainsKey(ctrl.Name))
                        objFieldsInfo = Fields[ctrl.Name];
                    if (objFieldsInfo != null)
                    {
                        //Set control's common properties
                        BOSControlUtil.SetControlCommonProperties(ctrl, objFieldsInfo);
                        //Set own properties of a specific control
                        var mi = ctrl.GetType().GetMethod("InitializeControl", new[] { typeof(STFieldsInfo) });
                        if (mi != null)
                            mi.Invoke(ctrl, new object[] { objFieldsInfo });

                        if (objFieldsInfo.STFieldParentID > 0)
                        {
                            var objFieldsParentInfo =
                                Fields.Values.Where(f => f.STFieldID == objFieldsInfo.STFieldParentID).FirstOrDefault();
                            if (objFieldsParentInfo != null)
                            {
                                var arr = Controls.Find(objFieldsParentInfo.STFieldName, true);
                                if (arr.Length > 0)
                                {
                                    var parentCtrl = arr[0];
                                    if (ctrl.Parent.Name != parentCtrl.Name)
                                        i--;
                                    if (parentCtrl.GetType() == typeof(BOSTabControl))
                                        (parentCtrl as BOSTabControl).TabPages.Add(ctrl as XtraTabPage);
                                    else
                                        ctrl.Parent = parentCtrl;
                                    ctrl.Location =
                                        new Point(
                                            objFieldsInfo.STFieldLocationX - objFieldsParentInfo.STFieldLocationX,
                                            objFieldsInfo.STFieldLocationY - objFieldsParentInfo.STFieldLocationY);
                                }
                            }
                        }
                        else
                        {
                            if (ctrl.Parent.Name != Name)
                                i--;
                            ctrl.Parent = this;
                        }
                    }
                }

                if (ctrl.Controls.Count > 0 && !(ctrl is UserControl))
                    CustomizeControls(ctrl.Controls);
            }
        }

        /// <summary>
        ///     Event handler for search button of lookup edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SearchButton_Click(object sender, EventArgs e)
        {
            //String tableName = (sender as BOSButton).Tag.ToString();
            //String buttonName = (sender as BOSButton).Name;
            //String ownerControlName = buttonName.Substring(7, buttonName.Length - 7);            
            //guiFind findForm = new guiFind(tableName, String.Empty, this.Module.Controls[ownerControlName], this.Module);
            //findForm.ShowDialog();
        }

        /// <summary>
        ///     Initialize specific control
        /// </summary>
        public virtual Control InitializeControl(Control ctrl)
        {
            //try
            //{
            var bosControl = ctrl as IBOSControl;
            if (bosControl != null)
            {
                var control = bosControl;
                control.Screen = this;
                control.InitializeControl();
            }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return ctrl;
        }

        public void InitializeControlEvent(STFieldsInfo objStFieldsInfo, Control ctrl)
        {
            try
            {
                var objSTFieldEventsController = new STFieldEventsController();
                var dsFieldEvent = objSTFieldEventsController.GetFieldEventByFieldID(objStFieldsInfo.STFieldID);
                if (dsFieldEvent.Tables.Count > 0)
                    foreach (DataRow rowFieldEvent in dsFieldEvent.Tables[0].Rows)
                    {
                        var objSTFieldEventsInfo =
                            (STFieldEventsInfo)objSTFieldEventsController.GetObjectFromDataRow(rowFieldEvent);

                        var ctrlEvent = ctrl.GetType().GetEvent(objSTFieldEventsInfo.STFieldEventName);
                        if (!ctrlEvent.Name.Equals("KeyUp"))
                        {
                            var strMethodName = objSTFieldEventsInfo.STFieldEventDelegateFunctionName;

                            var ctrlMethod =
                                Module.GetMethodInfoByMethodFullNameAndMethodClass(
                                    objSTFieldEventsInfo.STFieldEventDelegateFunctionName,
                                    objSTFieldEventsInfo.STFieldEventDelegateFunctionFullName,
                                    objSTFieldEventsInfo.STFieldEventDelegateFunctionClass);

                            Delegate ctrlEventDelegate = null;

                            ctrlEventDelegate = Delegate.CreateDelegate(ctrlEvent.EventHandlerType, Module, ctrlMethod);

                            ctrlEvent.AddEventHandler(ctrl, ctrlEventDelegate);
                        }
                    }
                dsFieldEvent.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(GetType().Name + ".InitializeControlEvent:" + e.Message);
            }
        }

        public override void BindingDataControl(Control ctrl)
        {
            try
            {
                var strDataSource = _dbUtil.GetPropertyStringValue(ctrl, cstDataSourcePropertyName);
                var strDataMember = _dbUtil.GetPropertyStringValue(ctrl, cstDataMemberPropertyName);
                var strPropertyName = _dbUtil.GetPropertyStringValue(ctrl, "BOSPropertyName");
                var entity = ((BaseModuleERP)Module).CurrentModuleEntity;
                if (ctrl.Tag != null)
                    if (ctrl.Tag.Equals(DataControl))
                    {
                        var strMainModuleTable = BOSUtil.GetTableNameFromBusinessObject(entity.MainObject);
                        if (strDataSource.Equals(strMainModuleTable))
                        {
                            if (((BaseModuleERP)Module).CurrentModuleEntity.MainObject != null)
                                ctrl.DataBindings.Add(
                                    new Binding(strPropertyName,
                                        entity.MainObjectBindingSource,
                                        strDataMember,
                                        true,
                                        DataSourceUpdateMode.OnPropertyChanged));
                        }
                        else if (((BaseModuleERP)Module).CurrentModuleEntity.ModuleObjects[strDataSource] != null)
                        {
                            ctrl.DataBindings.Add(
                                new Binding(strPropertyName,
                                    entity.ModuleObjectsBindingSource[strDataSource],
                                    strDataMember,
                                    true,
                                    DataSourceUpdateMode.OnPropertyChanged));
                        }
                    }
                    else if (ctrl.Tag.Equals(SearchControl))
                    {
                        if (entity.SearchObjectBindingSource != null)
                            ctrl.DataBindings.Add(
                                new Binding(strPropertyName,
                                    entity.SearchObjectBindingSource,
                                    strDataMember,
                                    true,
                                    DataSourceUpdateMode.OnPropertyChanged));
                    }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region Screen Event Handlers

        private void InitializeComponent()
        {
            var resources = new ComponentResourceManager(typeof(BOSERPScreen));
            SuspendLayout();
            // 
            // BOSERPScreen
            // 
            Appearance.BackColor = Color.Transparent;
            Appearance.Options.UseBackColor = true;
            ClientSize = new Size(1136, 589);
            Icon = (Icon)resources.GetObject("$this.Icon");
            LookAndFeel.Style = LookAndFeelStyle.Office2003;
            LookAndFeel.UseDefaultLookAndFeel = false;
            Name = "BOSERPScreen";
            ResumeLayout(false);
        }

        public void Screen_Activated(object sender, EventArgs e)
        {
            base.Activate();
            SuspendLayout();
            Module.ActiveScreen = (BOSScreen)sender;
            ResumeLayout(true);
        }

        private void Screen_Closing(object sender, FormClosingEventArgs e)
        {
            var scr = (BOSERPScreen)sender;
            if (scr.ScreenInfo == null) return;
            ScreenInfo.STScreenLocationX = Location.X;
            ScreenInfo.STScreenLocationY = Location.Y;
            ScreenInfo.STScreenSizeHeight = Size.Height;
            ScreenInfo.STScreenSizeWidth = Size.Width;
            _objStScreensController.UpdateObject(ScreenInfo);
        }

        private void Screen_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var baseModuleErp = Module as BaseModuleERP;
            baseModuleErp?.ParentScreen.popupMenuToolbar.ShowPopup(MousePosition);
        }

        private void BOSERPScreen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumLock || e.KeyCode == Keys.CapsLock || e.KeyCode == Keys.Scroll)
            {
                var temp = (BaseModuleERP)Module;
                temp.ParentScreen.CheckKeyBoard(e);
            }
        }

        private void BOSERPScreen_Activated(object sender, EventArgs e)
        {
            var temp = (BaseModuleERP)Module;
            temp.ParentScreen.CheckKeyBoard(null);
        }

        public void Control_Enter(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            ctrl.BackColor = Color.Yellow;
            if (ctrl is TextEdit)
                (ctrl as TextEdit).SelectAll();
        }

        public void Control_Leave(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception)
            {
            }
        }

        public virtual void Activate()
        {
            base.Activate();
        }

        #endregion

        #region Init Context Menu Item

        private void ContextMenuItemNew_Click(object sender, EventArgs e)
        {
            var baseModuleErp = Module as BaseModuleERP;
            baseModuleErp?.ActionNew();
        }

        private void ContextMenuItemEdit_Click(object sender, EventArgs e)
        {
            (Module as BaseModuleERP).ActionEdit();
        }

        private void ContextMenuItemDelete_Click(object sender, EventArgs e)
        {
            (Module as BaseModuleERP).ActionDelete();
        }

        private void ContextMenuItemCancel_Click(object sender, EventArgs e)
        {
            (Module as BaseModuleERP).ActionCancel();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <BOSParam name="SearchResultsControlName" type="String"></BOSParam>
        private void ContextMenuItemSave_Click(object sender, EventArgs e)
        {
            var method = GetType()
                .GetMethod("ContextMenuItemSave_Click",
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null,
                    new Type[2] { typeof(object), typeof(EventArgs) }, null);
            var strSearchResultsControlName =
                (Module as BaseModuleERP).GetModuleFunctionParameterValue(method.ToString(),
                    method.DeclaringType.ToString(), "SearchResultsControlName");
            (Module as BaseModuleERP).ActionSave();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <BOSParam name="SearchResultsControlName" type="String"></BOSParam>
        private void ContextMenuItemPrevious_Click(object sender, EventArgs e)
        {
            var method = GetType()
                .GetMethod("ContextMenuItemPrevious_Click",
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null,
                    new Type[2] { typeof(object), typeof(EventArgs) }, null);
            var strSearchResultsControlName =
                (Module as BaseModuleERP).GetModuleFunctionParameterValue(method.ToString(),
                    method.DeclaringType.ToString(), "SearchResultsControlName");
            (Module as BaseModuleERP).ActionGoPrevious();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <BOSParam name="SearchResultsControlName" type="String"></BOSParam>
        private void ContextMenuItemNext_Click(object sender, EventArgs e)
        {
            var method = GetType()
                .GetMethod("ContextMenuItemNext_Click",
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null,
                    new Type[2] { typeof(object), typeof(EventArgs) }, null);
            var strSearchResultsControlName =
                (Module as BaseModuleERP).GetModuleFunctionParameterValue(method.ToString(),
                    method.DeclaringType.ToString(), "SearchResultsControlName");
            (Module as BaseModuleERP).ActionGoNext();
        }


        private void RegisterContextMenuItemsEvent()
        {
            fld_mnuNew.Click += ContextMenuItemNew_Click;
            fld_mnuEdit.Click += ContextMenuItemEdit_Click;
            fld_mnuDelete.Click += ContextMenuItemDelete_Click;
            fld_mnuCancel.Click += ContextMenuItemCancel_Click;
            fld_mnuSave.Click += ContextMenuItemSave_Click;
            fld_mnuPrevious.Click += ContextMenuItemPrevious_Click;
            fld_mnuNext.Click += ContextMenuItemNext_Click;
        }

        #endregion

        #region Generate Search Query

        protected virtual string GenerateSearchQuery(string strTableName)
        {
            var strSearchQueryBuilder = new StringBuilder();
            strSearchQueryBuilder.Append(GenerateSearchQueryHeader(strTableName));
            if (Tag.ToString().Equals("SS"))
            {
                strSearchQueryBuilder.Append("WHERE" + BOSUtil.NewLine);
                strSearchQueryBuilder.Append(GenerateConditionsForSearch(strTableName));
            }

            strSearchQueryBuilder.Append(BOSUtil.NewLine);

            return strSearchQueryBuilder.ToString();
        }

        protected virtual string
            GenerateSearchQueryHeader(string strTableName)
        {
            return ((BaseModuleERP)Module).GenerateSearchQueryHeader(strTableName);
        }

        protected virtual string GenerateConditionsForSearch(string strTableName, Control.ControlCollection ctrls)
        {
            var strConditionBuilder = new StringBuilder();

            foreach (Control ctrl in ctrls)
            {
                if (ctrl.Tag != null)
                    if (ctrl.Tag.ToString().Equals("SC"))
                    {
                        var strColumnName = (ctrl as BaseEdit).Properties.AccessibleName;
                        if (string.IsNullOrEmpty(strColumnName))
                            strColumnName = _dbUtil.GetPropertyStringValue(ctrl, cstDataMemberPropertyName);
                        strConditionBuilder.Append(((BaseModuleERP)Module).GenerateConditionsForSearch(ctrl,
                            strTableName, strColumnName));
                    }
                if (ctrl.Controls.Count > 0)
                    strConditionBuilder.Append(GenerateConditionsForSearch(strTableName, ctrl.Controls));
            }
            return strConditionBuilder.ToString();
        }

        protected virtual string GenerateConditionsForSearch(string strTableName)
        {
            var strConditionBuilder = new StringBuilder();
            strConditionBuilder.Append(GenerateConditionsForSearch(strTableName, Controls));
            strConditionBuilder.Append(BOSUtil.Tab + "([AAStatus]=\'Alive\')" + BOSUtil.NewLine);
            return strConditionBuilder.ToString();
        }

        #endregion

        #region Permission

        /// <summary>
        ///     Set permission for all controls of the screen
        /// </summary>
        public virtual void SetPermission()
        {
            SetPermission(Controls);
        }

        protected virtual void SetPermission(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                SetPermission(ctrl);
                if (ctrl.Controls.Count > 0)
                    SetPermission(ctrl.Controls);
            }
        }

        protected virtual void SetPermission(Control ctrl)
        {
            if (FieldPermissions.ContainsKey(ctrl.Name))
            {
                var objFieldPermissionsInfo = FieldPermissions[ctrl.Name];
                if (objFieldPermissionsInfo != null)
                    if (ctrl is XtraTabPage)
                    {
                        var tabPage = (XtraTabPage)ctrl;
                        if (objFieldPermissionsInfo.STFieldPermissionType == Convert.ToByte(FieldPermissionType.Hided))
                            tabPage.PageVisible = false;
                    }
                    else
                    {
                        if (objFieldPermissionsInfo.STFieldPermissionType == Convert.ToByte(FieldPermissionType.Hided))
                        {
                            ctrl.Visible = false;
                        }
                        else if (objFieldPermissionsInfo.STFieldPermissionType ==
                                 Convert.ToByte(FieldPermissionType.Disabled))
                        {
                            ctrl.Enabled = false;
                        }
                        else if (objFieldPermissionsInfo.STFieldPermissionType ==
                                 Convert.ToByte(FieldPermissionType.HidedDisabled))
                        {
                            ctrl.Visible = false;
                        }
                        else if (objFieldPermissionsInfo.STFieldPermissionType == Convert.ToByte(FieldPermissionType.None))
                        {
                            ctrl.Visible = true;
                            ctrl.Enabled = true;
                            if (ctrl is BaseEdit)
                                (ctrl as BaseEdit).Properties.ReadOnly = false;
                        }
                    }
            }
        }

        public virtual void AddCustomeControlsToModule()
        {

        }

        #endregion
    }
}