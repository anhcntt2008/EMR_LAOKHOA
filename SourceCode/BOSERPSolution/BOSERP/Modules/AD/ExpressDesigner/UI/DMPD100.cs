using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.XtraNavBar;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using BOSLib;
using BOSComponent;
using Localization;

namespace BOSERP.Modules.ExpressDesigner
{
    public partial class guiStudio : BOSERPScreen
    {
        public enum SamePosType { Left, Right, Top, Bottom };

        #region Variables
        private STModulesInfo CurrentModuleInfo;
        private List<BOSScreen> lstOpenScreens = new List<BOSScreen>();
        private Control CurrentControl = new Control();
        private Point ptCursorOffset = new Point();
        #endregion

        #region Constructors
        public guiStudio()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers of Main UI
        private void guiStudio_Load(object sender, EventArgs e)
        {
            InitializeModuleList();  
        }

        private void fld_dgvModules_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                if (fld_dgvModules.FocusedRowHandle >= 0)
                {
                    STModuleDescriptionsInfo objModuleDescriptionsInfo = (STModuleDescriptionsInfo)fld_dgvModules.GetRow(fld_dgvModules.FocusedRowHandle);
                    STModulesController objModulesController = new STModulesController();
                    STModulesInfo objModulesInfo = (STModulesInfo)objModulesController.GetObjectByID(objModuleDescriptionsInfo.STModuleID);
                    if (objModulesInfo != null)
                    {
                        objModulesInfo.STModuleDescription = objModuleDescriptionsInfo.STModuleDescriptionDescription;
                        CurrentModuleInfo = objModulesInfo;
                        LoadModule();
                    }
                }
            }
        }

        private void fld_barbtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            STScreensController objScreensController = new STScreensController();
            STFieldsController objFieldsController = new STFieldsController();
            foreach (BOSERPScreen screen in lstOpenScreens)
            {
                STScreensInfo objScreensInfo = GetScreenInfo(screen);
                if (objScreensInfo.STScreenID == 0)
                {
                    if (screen.Visible)
                        objScreensController.CreateObject(objScreensInfo);
                }
                else
                {
                    objScreensController.UpdateObject(objScreensInfo);
                    if (!screen.Visible)
                    {                        
                        objFieldsController.UpdateByScreenID(objScreensInfo.STScreenID, false);
                    }
                }

                SaveControls(screen.Controls, objScreensInfo.STScreenID);                
            }
            MessageBox.Show("Save successfully", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fld_barbtnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CurrentModuleInfo != null)
            {
                String moduleName = new STModulesController().GetObjectNameByID(CurrentModuleInfo.STModuleID);
                String strExportedFileName = String.Format("{0}_{1}_{2}_{3}", moduleName, DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString());
                SaveFileDialog saveExportedFile = new SaveFileDialog();
                saveExportedFile.InitialDirectory = "C:\\";
                saveExportedFile.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                saveExportedFile.FileName = strExportedFileName;
                saveExportedFile.FilterIndex = 1;
                saveExportedFile.RestoreDirectory = true;
                if (saveExportedFile.ShowDialog() == DialogResult.OK)
                {
                    strExportedFileName = saveExportedFile.FileName;
                }
                else
                    return;

                ExportModule(strExportedFileName);
                MessageBox.Show("Export successfully.", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fld_barbtnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CurrentModuleInfo != null)
            {
                String strImportFileName = String.Empty;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    strImportFileName = openFileDialog.FileName;
                }
                else
                    return;
                Cursor.Current = Cursors.WaitCursor;
                ImportModule(strImportFileName);
                LoadModule();
            }
        }

        private void guiStudio_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExpressDesignerModule module = (ExpressDesignerModule)Module;
            BOSApp.MainScreen.OpenModulesToolStrip.Items.RemoveByKey(module.Name);
            module.Close();
            BOSApp.RemoveOpenedModule(module.Name);
            if (BOSApp.CurrentUser != null)
                module.DeleteUserAudit(module.Name);
        }

        private void fld_barbtnDeleteScreen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                RemoveScreen((BOSERPScreen)ActiveMdiChild);
            }
        }

        private void fld_barbtnCreateModule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            guiCreateModule guiCreateModule = new guiCreateModule();
            guiCreateModule.Module = Module;
            if (guiCreateModule.ShowDialog() == DialogResult.OK)
            {
                STModulesInfo objModulesInfo = new STModulesInfo();
                objModulesInfo.STModuleName = guiCreateModule.ModuleDescription;
                objModulesInfo.STModuleDescription = guiCreateModule.ModuleDescription;
                CreateModule(objModulesInfo);
            }
        }
        #endregion

        #region Processing Functions
        /// <summary>
        /// Initialize module list
        /// </summary>
        private void InitializeModuleList()
        {
            STModulesController objModulesController = new STModulesController();
            STModuleDescriptionsController objModuleDescriptionsController = new STModuleDescriptionsController();
            DataSet ds = objModulesController.GetAllModules();
            if (ds.Tables.Count > 0)
            {
                List<STModuleDescriptionsInfo> lstModules = new List<STModuleDescriptionsInfo>();
                int currentIndex = 0;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    STModulesInfo objModulesInfo = (STModulesInfo)objModulesController.GetObjectFromDataRow(row);
                    STModuleDescriptionsInfo objModuleDescriptionsInfo = objModuleDescriptionsController.GetModuleDescriptionByModuleNameAndLanguageName(objModulesInfo.STModuleName, BOSApp.CurrentLang);
                    if (objModuleDescriptionsInfo != null)
                    {
                        lstModules.Add(objModuleDescriptionsInfo);
                        if (CurrentModuleInfo != null && objModuleDescriptionsInfo.STModuleDescriptionDescription == CurrentModuleInfo.STModuleDescription)
                            currentIndex = lstModules.Count - 1;
                    }
                }
                fld_dgcModules.DataSource = lstModules;
                fld_dgcModules.RefreshDataSource();
                fld_dgvModules.FocusedRowHandle = fld_dgvModules.GetRowHandle(currentIndex);
            }            
        }

        /// <summary
        /// Create new module
        /// </summary>        
        /// <param name="objModulesInfo">Module object needs to be created</param>
        private void CreateModule(STModulesInfo objModulesInfo)
        {
            STModulesController objModulesController = new STModulesController();
            objModulesController.CreateObject(objModulesInfo);
            if (objModulesInfo.STModuleID > 0)
            {
                STModuleDescriptionsController objModuleDescriptionsController = new STModuleDescriptionsController();
                STModuleDescriptionsInfo objModuleDescriptionsInfo = new STModuleDescriptionsInfo();
                objModuleDescriptionsInfo.STModuleID = objModulesInfo.STModuleID;
                objModuleDescriptionsInfo.STLanguageID = BOSApp.CurrentCompanyInfo.FK_GELanguageID;
                objModuleDescriptionsInfo.STModuleDescriptionDescription = objModulesInfo.STModuleDescription;
                objModuleDescriptionsController.CreateObject(objModuleDescriptionsInfo);
                if (objModuleDescriptionsInfo.STModuleDescriptionID > 0)
                {
                    CurrentModuleInfo = objModulesInfo;
                    InitializeModuleList();                    
                    LoadModule();
                }
            }
        }

        private void LoadModule()
        {
            if (CurrentModuleInfo != null)
            {
                CurrentControl = new Control();
                //Close all open screens
                foreach (BOSERPScreen scr in lstOpenScreens)
                    scr.Close();
                lstOpenScreens.Clear();
               
                STScreensController objScreensController = new STScreensController();
                DataSet ds = objScreensController.GetScreenByModuleNameAndUserGroupID(CurrentModuleInfo.STModuleName, BOSApp.UserGroupAdmin);
                if (ds.Tables.Count > 0)
                {
                    fld_navbgrAvailableFields.ItemLinks.Clear();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        STScreensInfo objSTScreensInfo = (STScreensInfo)objScreensController.GetObjectFromDataRow(row);
                        if (objSTScreensInfo.STScreenVisible)
                        {
                            BOSERPScreen scr = BOSERPScreenFactory.GetScreen(objSTScreensInfo.STScreenNumber, (CurrentModuleInfo.STModuleName));
                            scr.Module = Module;
                            //scr.Text = objSTScreensInfo.STScreenText;
                            scr.ScreenNumber = objSTScreensInfo.STScreenNumber;
                            scr.Name = objSTScreensInfo.STScreenName;
                            scr.ScreenID = objSTScreensInfo.STScreenID;
                            scr.SortOrder = objSTScreensInfo.STScreenSortOrder;
                            lstOpenScreens.Add(scr);
                        }
                    }
                }

                foreach (BOSERPScreen screen in lstOpenScreens)
                {
                    ShowScreen(screen);

                    //Add invisible controls to group of available fields
                    AddAvailableFields(screen.Controls);
                }

                //Enable all module toolbar buttons
                foreach (DevExpress.XtraBars.BarItemLink link in fld_barModuleToolbar.ItemLinks)
                    link.Item.Enabled = true;
            }
        }

        private void ShowScreen(BOSERPScreen scr)
        {
            scr.GetFields();
            //scr.AddCustomControls(lstOpenScreens);
            //scr.CustomizeControls(scr.Controls);    
            InitializeControls(scr.Controls, scr);

            scr.MdiParent = this;
            scr.ControlBox = true;
            scr.AutoScroll = true;
            scr.AllowDrop = true;
            scr.DragDrop += new DragEventHandler(Screen_DragDrop);
            scr.DragEnter += new DragEventHandler(Screen_DragEnter);
            scr.MouseDown += new MouseEventHandler(Screen_MouseDown);
            scr.Activated += new EventHandler(Screen_Activated);
            scr.Show();         
        }

        private void AddAvailableFields(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                AddAvailableFields(ctrl);
            }
        }

        private void AddAvailableFields(Control ctrl)
        {
            //If its container is TabPage, show TabPage first to invalidate control's visibility
            if (ctrl.Parent != null && ctrl.Parent.GetType() == typeof(DevExpress.XtraTab.XtraTabPage))
                ctrl.Parent.Show();

            BOSDbUtil dbUtil = new BOSDbUtil();
            if (ctrl.Visible == false)
            {
                if (!String.IsNullOrEmpty(dbUtil.GetPropertyStringValue(ctrl, BOSERPScreen.cstDataSourcePropertyName)))
                {
                    //Check whether the item already exists
                    foreach (NavBarItemLink link in fld_navbgrAvailableFields.ItemLinks)
                        if (link.Item.Hint == ctrl.Name)
                            return;
                    //Create new item link
                    NavBarItem item = new NavBarItem();
                    item.Caption = dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstDescriptionPropertyName);
                    if (String.IsNullOrEmpty(item.Caption))
                        item.Caption = dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstDataMemberPropertyName);
                    if (String.IsNullOrEmpty(item.Caption))
                        item.Caption = dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstDataSourcePropertyName);
                    if (!String.IsNullOrEmpty(item.Caption))
                    {
                        item.Hint = ctrl.Name;
                        String controlTypeName = ctrl.GetType().Name;
                        if (controlTypeName.Contains("GridControl"))
                            item.SmallImage = fld_imgcltImage.Images["BOSGridControl.png"];  
                        else if (controlTypeName.Contains("TreeListControl"))
                            item.SmallImage = fld_imgcltImage.Images["BOSTreeListControl.png"];  
                        else
                            item.SmallImage = fld_imgcltImage.Images[ctrl.GetType().Name + ".png"];
                        fld_navbgrAvailableFields.ItemLinks.Add(item);
                    }
                }
                else
                {
                    ctrl.Location = new Point(Int32.MaxValue, Int32.MaxValue);
                }
            }
            if (ctrl.Controls.Count > 0)
                AddAvailableFields(ctrl.Controls);
        }

        public void InitializeControls(Control.ControlCollection controls, BOSERPScreen scr)
        {
            foreach (Control ctrl in controls)
            {
                InitializeControl(ctrl, scr);
                if (ctrl.Controls.Count > 0)
                    InitializeControls(ctrl.Controls, scr);
            }
        }

        public Control InitializeControl(Control ctrl, BOSERPScreen scr)
        {
            BOSControlUtil.RemoveControlEvents(ctrl);                        

            //Set control's properties for customization
            ctrl.Enabled = true;            
            if (!String.IsNullOrEmpty(ctrl.Name))
            {
                ctrl.MouseDown += new MouseEventHandler(Ctrl_MouseDown);
                ctrl.MouseMove += new MouseEventHandler(Ctrl_MouseMove);
                ctrl.MouseMove += new MouseEventHandler(Ctrl_Resize);
                ctrl.MouseUp += new MouseEventHandler(Ctrl_MouseUp);
                ctrl.KeyDown += new KeyEventHandler(Ctrl_KeyDown);
                ctrl.KeyUp += new KeyEventHandler(Ctrl_KeyUp);

                if (ctrl.GetType() == typeof(BOSTabControl))
                    ctrl.ControlAdded += new ControlEventHandler(TabControl_ControlAdded);                                                
                if (ctrl.GetType() == typeof(BOSLookupEdit))
                {
                    BOSDbUtil dbUtil = new BOSDbUtil();
                    BOSLookupEdit lookupEdit = (BOSLookupEdit)(ctrl);
                    if (dbUtil.IsForeignKey(lookupEdit.BOSDataSource, lookupEdit.BOSDataMember))
                    {
                        lookupEdit.Screen = scr;
                        lookupEdit.InitLookupEditColumns();
                    }
                }
            }
            return ctrl;
        }

        private void SaveControls(Control.ControlCollection controls, int screenID)
        {
            foreach (Control ctrl in controls)
            {
                SaveControl(ctrl, screenID);
                if (ctrl.Controls.Count > 0 && !(ctrl is UserControl))
                    SaveControls(ctrl.Controls, screenID);
            }
        }

        private void SaveControl(Control ctrl, int screenID)
        {
            //If its container is TabPage, show TabPage first to invalidate control's visibility
            if (ctrl.Parent.GetType() == typeof(DevExpress.XtraTab.XtraTabPage))
                ctrl.Parent.Show();

            if (!String.IsNullOrEmpty(ctrl.Name))
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                STFieldsController objFieldsController = new STFieldsController();
                STFieldsInfo objFieldsInfo = GetControlInfo(screenID, ctrl);
                if (objFieldsInfo.STFieldID == 0)
                    objFieldsController.CreateObject(objFieldsInfo);
                else
                    objFieldsController.UpdateObject(objFieldsInfo);                                

                //Save field columns
                if (ctrl.GetType() == typeof(BOSLookupEdit))
                {
                    BOSLookupEdit lookupEdit = (BOSLookupEdit)(ctrl);
                    STFieldColumnsController objFieldColumnsController = new STFieldColumnsController();
                    objFieldColumnsController.DeleteByForeignColumn("STFieldID", objFieldsInfo.STFieldID);
                    int countColumnsCollection = lookupEdit.Properties.Columns.Count;
                    if (countColumnsCollection > 0)
                    {
                        for (int i = 0; i < countColumnsCollection; i++)
                        {
                            STFieldColumnsInfo objFieldColumnsInfo = new STFieldColumnsInfo();
                            objFieldColumnsInfo.STFieldID = objFieldsInfo.STFieldID;
                            objFieldColumnsInfo.STFieldColumnFieldName = lookupEdit.Properties.Columns[i].FieldName;
                            objFieldColumnsInfo.STFieldColumnName = lookupEdit.Properties.Columns[i].FieldName;
                            objFieldColumnsInfo.STFieldColumnCaption = lookupEdit.Properties.Columns[i].Caption;
                            objFieldColumnsInfo.STFieldColumnFormatType = lookupEdit.Properties.Columns[i].FormatType.ToString();
                            objFieldColumnsInfo.STFieldColumnFormatString = lookupEdit.Properties.Columns[i].FormatString;
                            objFieldColumnsInfo.STFieldColumnWidth = lookupEdit.Properties.Columns[i].Width;
                            objFieldColumnsController.CreateObject(objFieldColumnsInfo);
                        }
                    }
                }
            }
        }

        private STFieldsInfo GetControlInfo(int screenID, Control ctrl)
        {
            STFieldsController objFieldsController = new STFieldsController();
            STFieldsInfo objFieldsInfo = BOSControlUtil.GetControlInfo(ctrl, CurrentModuleInfo.STModuleID, screenID);
            Point location = GetControlLocation(ctrl);
            objFieldsInfo.STFieldLocationX = location.X;
            objFieldsInfo.STFieldLocationY = location.Y;
            if (ctrl.Tag != null && ctrl.Tag.ToString() == BOSScreen.cstFieldGroupCustom)
                objFieldsInfo.STFieldGroup = BOSScreen.cstFieldGroupCustom;
            STFieldsInfo objFieldParentInfo = objFieldsController.GetFieldByFieldNameAndScreenID(ctrl.Parent.Name, screenID);
            if (objFieldParentInfo != null)
                objFieldsInfo.STFieldParentID = objFieldParentInfo.STFieldID;
            else
                objFieldsInfo.STFieldParentID = 0;
            return objFieldsInfo;
        }

        private Point GetControlLocation(Control ctrl)
        {
            Point location = new Point(ctrl.Location.X, ctrl.Location.Y);
            if (ctrl.Parent.GetType() != typeof(BOSERPScreen) && ctrl.Parent.GetType().BaseType != typeof(BOSERPScreen))
            {
                Point parentLocation = GetControlLocation(ctrl.Parent);
                location.X += parentLocation.X;
                location.Y += parentLocation.Y;
            }
            return location;
        }

        private void ExportModule(String fileName)
        {
            DataSet dsExportModules = new DataSet();
            dsExportModules.DataSetName = CurrentModuleInfo.STModuleName;

            //Export module info
            STModulesController objModulesController = new STModulesController();
            DataSet dsModules = objModulesController.GetDataSetByID(CurrentModuleInfo.STModuleID);
            if (dsModules.Tables.Count > 0 && dsModules.Tables[0].Rows.Count > 0)
            {
                DataTable tblSTModules = dsModules.Tables[0].Copy();
                tblSTModules.TableName = BOSUtil.GetTableNameFromBusinessObjectType(typeof(STModulesInfo));
                DataColumn colDescription = tblSTModules.Columns.Add("STModuleDescription");
                tblSTModules.Rows[0][colDescription] = CurrentModuleInfo.STModuleDescription;
                dsExportModules.Tables.Add(tblSTModules);
            }
            
            //Export all screens of the module
            STScreensController objSTScreensController = new STScreensController();
            DataSet dsScreens = objSTScreensController.GetScreenByUserGroupIDAndModuleID(1, CurrentModuleInfo.STModuleID);
            if (dsScreens.Tables.Count > 0)
            {
                DataTable tblSTScreens = dsScreens.Tables[0].Copy();
                tblSTScreens.TableName = BOSUtil.GetTableNameFromBusinessObjectType(typeof(STScreensInfo));
                dsExportModules.Tables.Add(tblSTScreens);
            }

            //Export all fields of the module
            STFieldsController objSTFieldsController = new STFieldsController();
            DataSet dsFields = objSTFieldsController.GetFieldBySTModuleIDAndSTUserGroupID(CurrentModuleInfo.STModuleID, 1);
            if (dsFields.Tables.Count > 0)
            {
                DataTable tblSTFields = dsFields.Tables[0].Copy();
                tblSTFields.Columns.Add(new DataColumn("STFieldParentName"));
                foreach (DataRow row in tblSTFields.Rows)
                    if (row["STFieldParentID"] != DBNull.Value)
                    {
                        STFieldsInfo objParentFieldsInfo = (STFieldsInfo)objSTFieldsController.GetObjectByID(Convert.ToInt32(row["STFieldParentID"]));
                        if (objParentFieldsInfo != null)
                            row["STFieldParentName"] = objParentFieldsInfo.STFieldName;
                        else
                            row["STFieldParentName"] = String.Empty;
                    }
                tblSTFields.TableName = BOSUtil.GetTableNameFromBusinessObjectType(typeof(STFieldsInfo));
                dsExportModules.Tables.Add(tblSTFields);
            }

            dsExportModules.WriteXml(fileName, XmlWriteMode.WriteSchema);
        }

        public void ImportModule(String strImportFileName)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            String strSTScreensTableName = BOSUtil.GetTableNameFromBusinessObjectType(typeof(STScreensInfo));
            String strSTFieldsTableName = BOSUtil.GetTableNameFromBusinessObjectType(typeof(STFieldsInfo));            

            //Delete all first    
            DeleteAllExistDataFromModule(CurrentModuleInfo.STModuleName);

            DataSet dsImport = new DataSet();
            dsImport.ReadXml(strImportFileName, XmlReadMode.ReadSchema);

            //Import module
            STModulesController objModulesController = new STModulesController();
            String moduleTableName = BOSUtil.GetTableNameFromBusinessObjectType(typeof(STModulesInfo));
            if (dsImport.Tables[moduleTableName] != null && dsImport.Tables[moduleTableName].Rows.Count > 0)
            {                
                STModulesInfo objModulesInfo = (STModulesInfo)objModulesController.GetObjectFromDataRow(dsImport.Tables[moduleTableName].Rows[0]);
                CreateModule(objModulesInfo);
            }

            //Import all screens of the module
            STScreensController objSTScreensController = new STScreensController();
            STFieldsController objSTFieldsController = new STFieldsController();
            foreach (DataRow rowSTScreen in dsImport.Tables[strSTScreensTableName].Rows)
            {
                STScreensInfo objSTScreensInfo = (STScreensInfo)objSTScreensController.GetObjectFromDataRow(rowSTScreen);
                objSTScreensInfo.STModuleID = CurrentModuleInfo.STModuleID;
                objSTScreensInfo.STUserGroupID = 1;
                int iSTOriginalScreenID = objSTScreensInfo.STScreenID;
                int iSTScreenID = objSTScreensController.CreateObject(objSTScreensInfo);
                if (iSTScreenID > 0)
                {
                    //Import all fields of the module
                    SortedList<String, STFieldsInfo> lstFields = new SortedList<string, STFieldsInfo>();
                    SortedList<int, String> lstParentFieldNames = new SortedList<int, string>();
                    String strFieldCriteria = String.Format("STScreenID={0}", iSTOriginalScreenID);
                    DataRow[] arrRowFields = dsImport.Tables[strSTFieldsTableName].Select(strFieldCriteria);
                    foreach (DataRow rowField in arrRowFields)
                    {
                        STFieldsInfo objSTFieldsInfo = (STFieldsInfo)objSTFieldsController.GetObjectFromDataRow(rowField);
                        objSTFieldsInfo.STScreenID = iSTScreenID;
                        objSTFieldsInfo.STUserGroupID = 1;
                        int iSTOriginalFieldID = objSTFieldsInfo.STFieldID;
                        int iSTFieldID = objSTFieldsController.CreateObject(objSTFieldsInfo);
                        lstFields.Add(objSTFieldsInfo.STFieldName, objSTFieldsInfo);
                        if (!String.IsNullOrEmpty(rowField["STFieldParentName"].ToString()))
                            lstParentFieldNames.Add(objSTFieldsInfo.STFieldID, rowField["STFieldParentName"].ToString());
                    }
                    //Update field parent id
                    foreach (STFieldsInfo objFieldsInfo in lstFields.Values)
                    {
                        if (lstParentFieldNames.ContainsKey(objFieldsInfo.STFieldID) &&
                            lstFields.ContainsKey(lstParentFieldNames[objFieldsInfo.STFieldID]))
                        {
                            objFieldsInfo.STFieldParentID = lstFields[lstParentFieldNames[objFieldsInfo.STFieldID]].STFieldID;
                            objSTFieldsController.UpdateObject(objFieldsInfo);
                        }
                    }
                }
            }
        }

        private void DeleteAllExistDataFromModule(String moduleName)
        {
            STModulesController objModulesController = new STModulesController();
            STModulesInfo objModulesInfo = (STModulesInfo)objModulesController.GetObjectByName(moduleName);
            if (objModulesInfo != null)
            {
                objModulesController.DeleteObject(objModulesInfo.STModuleID);
            }
        }
        #endregion

        #region Screen DragDrop
        public void Screen_DragDrop(object sender, DragEventArgs e)
        {
            BOSERPScreen screen = (BOSERPScreen)sender;
            NavBarItemLink navBarItemLinkControl = GetItemLink(e.Data);
            Point ptLocation = new Point(e.X, e.Y);
            BOSDbUtil dbUtil = new BOSDbUtil();
            if (navBarItemLinkControl.Group.Name == "fld_navbgrAvailableFields")
            {
                String controlName = navBarItemLinkControl.Item.Hint;
                foreach (BOSERPScreen scr in lstOpenScreens)
                {
                    Control[] arr = scr.Controls.Find(controlName, true);
                    if (arr.Length > 0)
                    {
                        Control ctrl = arr[0];                        
                        ctrl.Visible = true;
                        this.ActiveMdiChild.Controls.Add(ctrl);
                        ctrl.Location = this.ActiveMdiChild.PointToClient(ptLocation);
                        InitializeControl(ctrl, screen);
                        SetParentControl(ctrl, ptLocation);
                        fld_navbgrAvailableFields.ItemLinks.Remove(navBarItemLinkControl.Item);
                        break;
                    }
                }
            }
            else
            {
                Control ctrl = GenerateControlFromToolbox(navBarItemLinkControl, this.ActiveMdiChild.PointToClient(ptLocation));
                InitializeControl(ctrl, screen);
                dbUtil.SetPropertyValue(ctrl, BOSERPScreen.cstFieldGroupPropertyName, BOSERPScreen.cstFieldGroupCustom);
                this.ActiveMdiChild.Controls.Add(ctrl);
                SetParentControl(ctrl, ptLocation);
            }
        }

        public void Screen_DragEnter(object sender, DragEventArgs e)
        {
            NavBarItemLink link = GetItemLink(e.Data);
            if (link != null && link.Item.Enabled)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.Scroll;
        }

        private NavBarItemLink GetItemLink(IDataObject data)
        {
            NavBarItemLink ret = data.GetData(typeof(NavBarItemLink)) as NavBarItemLink;
            return ret;
        }

        public Control GenerateControlFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            if (navBarItemLinkControl != null && navBarItemLinkControl.Item.Enabled)
            {
                switch (navBarItemLinkControl.Item.Tag.ToString())
                {
                    case "TextBox":
                        {
                            BOSTextBox txt = GenerateTextBoxFromToolbox(navBarItemLinkControl, ptLocation);
                            return txt;
                        }
                    case "MemoEdit":
                        {
                            BOSMemoEdit med = GenerateMemoEditFromToolbox(navBarItemLinkControl, ptLocation);
                            return med;
                        }
                    case "Button":
                        {
                            BOSButton btn = GenerateButtonFromToolbox(navBarItemLinkControl, ptLocation);
                            return btn;
                        }
                    case "Label":
                        {
                            BOSLabel lbl = GenerateLabelFromToolbox(navBarItemLinkControl, ptLocation);
                            return lbl;
                        }
                    case "ComboBox":
                        {
                            BOSComboBox cmb = GenerateComboBoxFromToolbox(navBarItemLinkControl, ptLocation);
                            return cmb;
                        }
                    case "DateEdit":
                        {
                            BOSDateEdit dte = GenerateDateEditFromToolbox(navBarItemLinkControl, ptLocation);
                            return dte;
                        }
                    case "PictureEdit":
                        {
                            BOSPictureEdit pte = GeneratePictureEditFromToolbox(navBarItemLinkControl, ptLocation);
                            return pte;
                        }
                    case "CheckEdit":
                        {
                            BOSCheckEdit chk = GenerateCheckEditFromToolbox(navBarItemLinkControl, ptLocation);
                            return chk;
                        }
                    case "GridControl":
                        {
                            BOSGridControl grd = GenerateGridControlFromToolbox(navBarItemLinkControl, ptLocation);
                            return grd;
                        }
                    case "GroupControl":
                        {
                            BOSGroupControl grp = GenerateGroupControlFromToolbox(navBarItemLinkControl, ptLocation);
                            return grp;
                        }
                    case "TabControl":
                        {
                            BOSTabControl tab = GenerateTabControlFromToolbox(navBarItemLinkControl, ptLocation);
                            return tab;
                        }
                }
            }
            return null;
        }

        #region Generate Controls from Toolbox
        private BOSTextBox GenerateTextBoxFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            BOSComponent.BOSTextBox txt = new BOSComponent.BOSTextBox();
            txt.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            txt.Location = ptLocation;
            return txt;
        }

        private BOSMemoEdit GenerateMemoEditFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            BOSComponent.BOSMemoEdit med = new BOSComponent.BOSMemoEdit();
            med.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            med.Location = ptLocation;
            return med;
        }

        private BOSButton GenerateButtonFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            BOSComponent.BOSButton btn = new BOSComponent.BOSButton();
            btn.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            btn.Location = ptLocation;
            btn.Text = btn.Name.Substring(13);
            return btn;
        }

        private BOSLabel GenerateLabelFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            BOSComponent.BOSLabel lbl = new BOSComponent.BOSLabel();
            lbl.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            lbl.Location = ptLocation;
            lbl.Text = lbl.Name.Substring(13);
            return lbl;
        }

        private BOSComboBox GenerateComboBoxFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            BOSComboBox cmb = new BOSComboBox();
            cmb.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            cmb.Location = ptLocation;
            return cmb;
        }

        private BOSDateEdit GenerateDateEditFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            BOSComponent.BOSDateEdit dte = new BOSComponent.BOSDateEdit();
            dte.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            dte.Location = ptLocation;
            return dte;
        }

        private BOSPictureEdit GeneratePictureEditFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            BOSComponent.BOSPictureEdit pte = new BOSComponent.BOSPictureEdit();
            pte.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            pte.Location = ptLocation;
            return pte;
        }

        private BOSCheckEdit GenerateCheckEditFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            BOSComponent.BOSCheckEdit chk = new BOSComponent.BOSCheckEdit();
            chk.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            chk.Location = ptLocation;
            return chk;
        }

        private BOSGridControl GenerateGridControlFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            BOSComponent.BOSGridControl grd = new BOSComponent.BOSGridControl();
            GridView gridView = (GridView)grd.MainView;
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            grd.UseEmbeddedNavigator = true;
            grd.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            grd.Location = ptLocation;
            return grd;
        }

        private BOSGroupControl GenerateGroupControlFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            BOSComponent.BOSGroupControl grp = new BOSComponent.BOSGroupControl();
            grp.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            grp.Location = ptLocation;
            return grp;
        }

        private BOSTabControl GenerateTabControlFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            BOSComponent.BOSTabControl tab = new BOSComponent.BOSTabControl();
            tab.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            tab.Location = ptLocation;
            tab.ControlAdded += new ControlEventHandler(TabControl_ControlAdded);
            DevExpress.XtraTab.XtraTabPage page = new DevExpress.XtraTab.XtraTabPage();
            page.Name = GenerateControlName("TabPage");
            page.Text = "tabPage";
            tab.TabPages.Add(page);
            return tab;
        }
        #endregion

        /// <summary>
        /// Set properties to TabPage when it is added to TabControl manually
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.Name = GenerateControlName("TabPage");
            e.Control.Text = "tabPage";
            e.Control.Tag = BOSScreen.cstFieldGroupCustom;
        }

        private String GenerateControlNamePrefix(String strControlType)
        {
            String strControlNamePrefix = "fld_";
            switch (strControlType)
            {
                case "TextBox":
                    {
                        strControlNamePrefix += "txt";
                        break;
                    }
                case "MemoEdit":
                    {
                        strControlNamePrefix += "med";
                        break;
                    }
                case "Button":
                    {
                        strControlNamePrefix += "btn";
                        break;
                    }
                case "Label":
                    {
                        strControlNamePrefix += "lbl";
                        break;
                    }
                case "ComboBox":
                    {
                        strControlNamePrefix += "cmb";
                        break;
                    }
                case "DateEdit":
                    {
                        strControlNamePrefix += "dte";
                        break;
                    }
                case "PictureEdit":
                    {
                        strControlNamePrefix += "pte";
                        break;
                    }
                case "CheckEdit":
                    {
                        strControlNamePrefix += "chk";
                        break;
                    }
                case "GridControl":
                    {
                        strControlNamePrefix += "dgc";
                        break;
                    }
                case "GroupControl":
                    {
                        strControlNamePrefix += "grc";
                        break;
                    }
                case "TabControl":
                    {
                        strControlNamePrefix += "tab";
                        break;
                    }
                case "TabPage":
                    {
                        strControlNamePrefix += "tpg";
                        break;
                    }
            }
            return strControlNamePrefix;
        }
        private String GenerateControlName(String templateControlName)
        {
            int i = 1;
            String strTemplateControlName = String.Empty;
            strTemplateControlName = GenerateControlNamePrefix(templateControlName) + BOSScreen.cstFieldGroupCustom + templateControlName;
            String strControlName = strTemplateControlName;
            while (true)
            {
                bool flag = false;
                foreach (BOSERPScreen scr in lstOpenScreens)
                {
                    if (scr.Controls.Find(strControlName, true).Length > 0)
                    {
                        strControlName = strTemplateControlName + i.ToString();
                        i++;
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                    break;
            }
            return strControlName;
        }
        #endregion
     
        #region Control Event Handlers
        private void Ctrl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                ptCursorOffset = e.Location;
                Control ctrl = sender as Control;
                if (CurrentResizingOption == ResizingOption.None)
                    ctrl.Cursor = Cursors.SizeAll;
                fld_prodgcProperty.SelectedObject = ctrl;
                fld_prodgcProperty.Refresh();
                dbUtil.SetPropertyValue(CurrentControl, BOSERPScreen.cstCommentPropertyName, fld_medComment.Text);
                fld_medComment.Text = dbUtil.GetPropertyStringValue(ctrl, BOSERPScreen.cstCommentPropertyName);
                UndrawControl(CurrentControl);
                DrawControl(ctrl);
                CurrentControl = ctrl;
            }
        }

        private void Ctrl_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;
            if (e.Button == MouseButtons.Left && CurrentResizingOption == ResizingOption.None)
            {
                UndrawControl(ctrl);

                //Set new location to control
                Point clientPosition = ctrl.Parent.PointToClient(Cursor.Position);
                int left = clientPosition.X - ptCursorOffset.X;
                int right = left + ctrl.Width;
                int top = clientPosition.Y - ptCursorOffset.Y;
                int bottom = top + ctrl.Height;
                if (ctrl.Left != left || ctrl.Top != top)
                {
                    int minDisX = Int32.MaxValue;
                    int minDisY = Int32.MaxValue;
                    foreach (Control ctrl1 in ctrl.Parent.Controls)
                        if (ctrl1.Visible && ctrl1.Name != ctrl.Name)
                        {
                            if (Math.Abs(ctrl1.Left - left) < Math.Abs(minDisX))
                                minDisX = ctrl1.Left - left;
                            if (Math.Abs(ctrl1.Right - right) < Math.Abs(minDisX))
                                minDisX = ctrl1.Right - right;
                            if (Math.Abs(ctrl1.Top - top) < Math.Abs(minDisY))
                                minDisY = ctrl1.Top - top;
                            if (Math.Abs(ctrl1.Bottom - bottom) < Math.Abs(minDisY))
                                minDisY = ctrl1.Bottom - bottom;
                        }
                    if (Math.Abs(minDisX) <= 5)
                        ctrl.Left = left + minDisX;
                    else
                        ctrl.Left = left;
                    if (Math.Abs(minDisY) <= 5)
                        ctrl.Top = top + minDisY;
                    else
                        ctrl.Top = top;
                }

                if (!SetParentControl(ctrl, new Point(Cursor.Position.X - e.X, Cursor.Position.Y - e.Y)))
                {
                    DrawLineSamePos(ctrl, SamePosType.Left);
                    DrawLineSamePos(ctrl, SamePosType.Top);
                    DrawLineSamePos(ctrl, SamePosType.Right);
                    DrawLineSamePos(ctrl, SamePosType.Bottom);
                }
            }
        }

        private void Ctrl_MouseUp(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                UndrawControl(ctrl);
                DrawControl(ctrl);
                CurrentResizingOption = ResizingOption.None;
            }
        }

        private void Ctrl_KeyDown(object sender, KeyEventArgs e)
        {
            Control ctrl = CurrentControl;
            if (!String.IsNullOrEmpty(ctrl.Name))
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        UndrawControl(ctrl);
                        ctrl.Top -= 1;
                        SetParentControl(ctrl, ctrl.Parent.PointToScreen(ctrl.Location));
                        break;
                    case Keys.Down:
                        UndrawControl(ctrl);
                        ctrl.Top += 1;
                        SetParentControl(ctrl, ctrl.Parent.PointToScreen(ctrl.Location));
                        break;
                    case Keys.Left:
                        UndrawControl(ctrl);
                        ctrl.Left -= 1;
                        SetParentControl(ctrl, ctrl.Parent.PointToScreen(ctrl.Location));
                        break;
                    case Keys.Right:
                        UndrawControl(ctrl);
                        ctrl.Left += 1;
                        SetParentControl(ctrl, ctrl.Parent.PointToScreen(ctrl.Location));
                        break;
                }
            }
        }

        private void Ctrl_KeyUp(object sender, KeyEventArgs e)
        {
            Control ctrl = CurrentControl;
            if (!String.IsNullOrEmpty(ctrl.Name))
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.Left:
                    case Keys.Right:
                        DrawControl(ctrl);
                        break;
                    case Keys.Delete:
                        if (ctrl.Visible)
                        {
                            RemoveControl(ctrl);
                            UndrawControl(ctrl);
                            AddAvailableFields(ctrl);
                        }
                        break;
                }
            }
        }

        private void RemoveScreen(BOSERPScreen screen)
        {            
            RemoveControl(screen);
            AddAvailableFields(screen.Controls);
            screen.Visible = false;
        }

        private void Screen_MouseDown(object sender, MouseEventArgs e)
        {
            fld_prodgcProperty.SelectedObject = sender;
            fld_prodgcProperty.Refresh();
        }

        private void Screen_Activated(object sender, EventArgs e)
        {
            fld_prodgcProperty.SelectedObject = sender;
            fld_prodgcProperty.Refresh();
        }

        private void RemoveControl(Control ctrl)
        {
            ctrl.Visible = false;
            foreach (Control childControl in ctrl.Controls)
                RemoveControl(childControl);
        }

        private void DrawLineSamePos(Control ctrl, SamePosType type)
        {
            Point minPos = new Point();
            Point maxPos = new Point();
            List<Control> lstSamePosControl = GetAllControlSamePos(ctrl, type, ref minPos, ref maxPos);
            if (lstSamePosControl.Count > 1)
            {
                Graphics grph = Graphics.FromHwnd(ctrl.Parent.Handle);
                grph.DrawLine(new Pen(Color.Blue, 2), minPos, maxPos);
            }
        }

        private List<Control> GetAllControlSamePos(Control ctrl, SamePosType type, ref Point minPos, ref Point maxPos)
        {
            //Get start, end position of line   
            minPos.X = Int32.MaxValue;
            minPos.Y = Int32.MaxValue;
            maxPos.X = 0;
            maxPos.Y = 0;
            foreach (Control ctrl1 in ctrl.Parent.Controls)
            {
                switch (type)
                {
                    case SamePosType.Left:
                        minPos.X = ctrl.Left;
                        maxPos.X = ctrl.Left;
                        if (ctrl1.Left == ctrl.Left)
                        {
                            if (minPos.Y > ctrl1.Top)
                                minPos.Y = ctrl1.Top;
                            if (maxPos.Y < ctrl1.Bottom)
                                maxPos.Y = ctrl1.Bottom;
                        }
                        break;
                    case SamePosType.Top:
                        minPos.Y = ctrl.Top;
                        maxPos.Y = ctrl.Top;
                        if (ctrl1.Top == ctrl.Top)
                        {
                            if (minPos.X > ctrl1.Left)
                                minPos.X = ctrl1.Left;
                            if (maxPos.X < ctrl1.Right)
                                maxPos.X = ctrl1.Right;
                        }
                        break;
                    case SamePosType.Right:
                        minPos.X = ctrl.Right;
                        maxPos.X = ctrl.Right;
                        if (ctrl1.Right == ctrl.Right)
                        {
                            if (minPos.Y > ctrl1.Top)
                                minPos.Y = ctrl1.Top;
                            if (maxPos.Y < ctrl1.Bottom)
                                maxPos.Y = ctrl1.Bottom;
                        }
                        break;
                    case SamePosType.Bottom:
                        minPos.Y = ctrl.Bottom;
                        maxPos.Y = ctrl.Bottom;
                        if (ctrl1.Bottom == ctrl.Bottom)
                        {
                            if (minPos.X > ctrl1.Left)
                                minPos.X = ctrl1.Left;
                            if (maxPos.X < ctrl1.Right)
                                maxPos.X = ctrl1.Right;
                        }
                        break;
                }
            }

            //Get all relative controls of line
            List<Control> rs = new List<Control>();
            foreach (Control ctrl1 in ctrl.Parent.Controls)
            {
                switch (type)
                {
                    case SamePosType.Left:
                        if (ctrl1.Left <= ctrl.Left && ctrl1.Right >= ctrl.Left && ctrl1.Top >= minPos.Y && ctrl1.Bottom <= maxPos.Y)
                            rs.Add(ctrl1);
                        break;
                    case SamePosType.Top:
                        if (ctrl1.Top <= ctrl.Top && ctrl1.Bottom >= ctrl.Top && ctrl1.Left >= minPos.X && ctrl1.Right <= maxPos.X)
                            rs.Add(ctrl1);
                        break;
                    case SamePosType.Right:
                        if (ctrl1.Left <= ctrl.Right && ctrl1.Right >= ctrl.Right && ctrl1.Top >= minPos.Y && ctrl1.Bottom <= maxPos.Y)
                            rs.Add(ctrl1);
                        break;
                    case SamePosType.Bottom:
                        if (ctrl1.Top <= ctrl.Bottom && ctrl1.Bottom >= ctrl.Bottom && ctrl1.Left >= minPos.X && ctrl1.Right <= maxPos.X)
                            rs.Add(ctrl1);
                        break;
                }
            }
            return rs;
        }

        private void DrawControl(Control ctrl)
        {
            Graphics grph = Graphics.FromHwnd(ctrl.Parent.Handle);
            grph.DrawRectangle(new Pen(Color.Red, 2), ctrl.Bounds);
        }

        private void UndrawControl(Control ctrl)
        {
            if (ctrl != null && ctrl.Parent != null)
            {
                ctrl.Parent.Refresh();
            }
            else
                this.Refresh();
        }

        private bool SetParentControl(Control ctrl, Point location)
        {
            return SetParentControl(ctrl, ctrl.Parent, location, 1);
        }

        private bool SetParentControl(Control ctrl, Control originalParent, Point location, int level)
        {            
            bool changeParent = false;
            Point upperLeft = new Point(ctrl.Bounds.X, ctrl.Bounds.Y);
            if (ctrl.GetType() != typeof(XtraTabPage))
            {
                //Bring control out of its parent
                if (!ctrl.Parent.ClientRectangle.Contains(upperLeft))
                {
                    if (ctrl.Parent.GetType() != typeof(BOSERPScreen) && ctrl.Parent.GetType().BaseType != typeof(BOSERPScreen))
                    {
                        if (ctrl.Parent.GetType() == typeof(XtraTabPage))
                            ctrl.Parent = ctrl.Parent.Parent.Parent;
                        else
                            ctrl.Parent = ctrl.Parent.Parent;
                        changeParent = true;
                    }
                }                
                //Find a new parent
                upperLeft = new Point(ctrl.Bounds.X, ctrl.Bounds.Y);
                foreach (Control ctrl1 in ctrl.Parent.Controls)
                {
                    if (ctrl1.Name != ctrl.Name && ctrl1.Name != originalParent.Name)
                    {
                        if (ctrl1 is BOSGroupControl || ctrl1 is XtraTabPage || ctrl1 is BOSLine || ctrl1 is BOSPanel)
                        {
                            if (ctrl1.Bounds.Contains(upperLeft))
                            {
                                ctrl1.Controls.Add(ctrl);
                                changeParent = true;
                            }
                        }
                        else if (ctrl1 is BOSTabControl)
                        {
                            XtraTabPage tabPage = (ctrl1 as BOSTabControl).SelectedTabPage;
                            if (tabPage.Name != originalParent.Name)
                            {
                                if (ctrl1.Bounds.Contains(upperLeft))   
                                {
                                    tabPage.Controls.Add(ctrl);
                                    changeParent = true;
                                }
                            }
                        }
                    }
                }
            }
            if (changeParent)
            {
                ctrl.Location = ctrl.Parent.PointToClient(location);
                level++;
                if (level <= 5)
                {
                    SetParentControl(ctrl, originalParent, location, level);
                }
            }        
            return changeParent;
        }
        #endregion
              
        #region Make Screen
        private void fld_navbitmScreen_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (CurrentModuleInfo != null)           
            {                
                BOSERPScreen scr = new BOSERPScreen();
                String strTemplateScreenName = "gui" + CurrentModuleInfo.STModuleName;
                String strTemplateScreenNumber = "DM" + CurrentModuleInfo.STModuleCode;
                scr.Name = InitScreenName(strTemplateScreenName);
                scr.Text = scr.Name;
                scr.Tag = "DM";
                scr.ScreenNumber = InitScreenNumber(strTemplateScreenNumber);
                scr.Module = Module;
                lstOpenScreens.Add(scr);
                ShowScreen(scr);
            }
        }

        private STScreensInfo GetScreenInfo(BOSERPScreen scr)
        {
            STScreensController objScreensController = new STScreensController();
            STScreensInfo objScreenInfo = (STScreensInfo)objScreensController.GetObjectByID(scr.ScreenID);
            if (objScreenInfo == null)
                objScreenInfo = new STScreensInfo();
            objScreenInfo.STScreenID = scr.ScreenID;
            objScreenInfo.STScreenName = scr.Name;
            objScreenInfo.STScreenText = scr.Text;
            objScreenInfo.STScreenNumber = scr.ScreenNumber;
            objScreenInfo.STModuleID = CurrentModuleInfo.STModuleID;
            objScreenInfo.STScreenBackColor = scr.BackColor.ToArgb();
            objScreenInfo.STScreenForeColor = scr.ForeColor.ToArgb();
            objScreenInfo.STScreenFontName = scr.Font.Name;
            objScreenInfo.STScreenFontSize = scr.Font.Size;
            objScreenInfo.STScreenFontStyle = scr.Font.Style.ToString();
            objScreenInfo.STScreenVisible = scr.Visible;
            objScreenInfo.STScreenSortOrder = scr.SortOrder;
            if (scr.Tag != null)
                objScreenInfo.STScreenTag = scr.Tag.ToString();

            objScreenInfo.STUserGroupID = 1;
            return objScreenInfo;
        }


        private String InitScreenNumber(String strTemplateScreenNumber)
        {
            int iScreenNumber = 100;
            String strScreenNumber = strTemplateScreenNumber + iScreenNumber;
            while (IsExistScreenNumber(strScreenNumber))
            {
                iScreenNumber++;
                strScreenNumber = strTemplateScreenNumber + iScreenNumber;
            }
            return strScreenNumber;
        }


        private String InitScreenName(String strTemplateScreenName)
        {
            int i = 0;
            String strScreenName = strTemplateScreenName;
            while (IsExistScreenName(strScreenName))
            {
                i++;
                strScreenName = strTemplateScreenName + i.ToString();
            }
            return strScreenName;
        }

        private bool IsExistScreenName(String strScreenName)
        {
            foreach (BOSERPScreen scr in lstOpenScreens)
            {
                if (scr.Name == strScreenName)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsExistScreenNumber(String strScreenNumber)
        {
            foreach (BOSERPScreen scr in lstOpenScreens)
            {
                if (scr.ScreenNumber == strScreenNumber)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
       
        #region Resizing Control
        public enum ResizingOption
        {
            None,
            ResizeTop,
            ResizeRight,
            ResizeLeft,
            ResizeBottom,
            ResizeTopLeft,
            ResizeTopRight,
            ResizeBottomLeft,
            ResizeBottomRight
        }

        private ResizingOption CurrentResizingOption;
        private int endX;
        private int endY;

        private void Ctrl_Resize(object sender, MouseEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl.GetType() != typeof(BOSLabel))
            {
                endX = e.X + ctrl.Location.X;
                endY = e.Y + ctrl.Location.Y;
                if (e.Button == MouseButtons.Left)
                {
                    UndrawControl(ctrl);
                    ResizeControl(ctrl, e);
                }
                else
                {
                    SetResizingOption(ctrl, e);
                }
            }
        }

        private void SetResizingOption(Control ctrl, MouseEventArgs e)
        {
            //TopLeft
            if (new Rectangle(ctrl.Bounds.X, ctrl.Bounds.Y, 5, 5).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeTopLeft;
            //TopRight
            else if (new Rectangle(ctrl.Bounds.X + ctrl.Bounds.Width - 2, ctrl.Bounds.Y, 5, 5).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeTopRight;
            //BottomRight
            else if (new Rectangle(ctrl.Bounds.X + ctrl.Bounds.Width - 2, ctrl.Bounds.Y + ctrl.Bounds.Height - 2, 5, 5).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeBottomRight;
            //BottomLeft
            else if (new Rectangle(ctrl.Bounds.X, ctrl.Bounds.Y + ctrl.Bounds.Height - 2, 5, 5).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeBottomLeft;
            //Top
            else if (new Rectangle(ctrl.Bounds.X, ctrl.Bounds.Y, ctrl.Bounds.Width, 5).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeTop;
            //Right
            else if (new Rectangle(ctrl.Bounds.X + ctrl.Bounds.Width - 2, ctrl.Bounds.Y, 5, ctrl.Bounds.Height).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeRight;
            //Bottom
            else if (new Rectangle(ctrl.Bounds.X, ctrl.Bounds.Y + ctrl.Bounds.Height - 2, ctrl.Bounds.Width, 5).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeBottom;
            //Left
            else if (new Rectangle(ctrl.Bounds.X, ctrl.Bounds.Y, 5, ctrl.Bounds.Height).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeLeft;
            else
                CurrentResizingOption = ResizingOption.None;

            switch (CurrentResizingOption)
            {
                case ResizingOption.ResizeTopLeft:
                    ctrl.Cursor = Cursors.SizeNWSE;
                    break;
                case ResizingOption.ResizeTop:
                    ctrl.Cursor = Cursors.SizeNS;
                    break;
                case ResizingOption.ResizeTopRight:
                    ctrl.Cursor = Cursors.SizeNESW;
                    break;
                case ResizingOption.ResizeRight:
                    ctrl.Cursor = Cursors.SizeWE;
                    break;
                case ResizingOption.ResizeBottomRight:
                    ctrl.Cursor = Cursors.SizeNWSE;
                    break;
                case ResizingOption.ResizeBottom:
                    ctrl.Cursor = Cursors.SizeNS;
                    break;
                case ResizingOption.ResizeBottomLeft:
                    ctrl.Cursor = Cursors.SizeNESW;
                    break;
                case ResizingOption.ResizeLeft:
                    ctrl.Cursor = Cursors.SizeWE;
                    break;
                default:
                    ctrl.Cursor = Cursors.Arrow;
                    break;
            }
        }

        private void ResizeControl(Control ctrl, MouseEventArgs e)
        {
            int height, width;
            width = e.X - ctrl.Width;
            height = e.Y - ctrl.Height;

            if (e.Button == MouseButtons.Left)
            {
                //New location of the ctrl
                int x, y;
                switch (CurrentResizingOption)
                {
                    case ResizingOption.ResizeBottom:
                        if (endY <= ctrl.Location.Y + 4)
                            height = 4;
                        else
                            height = endY - ctrl.Location.Y;
                        ctrl.Height = height;                        
                        break;
                    case ResizingOption.ResizeBottomLeft:
                        if (endX >= ctrl.Location.X + ctrl.Width - 4)
                        {
                            x = ctrl.Location.X + ctrl.Width - 4;
                            width = 4;
                        }
                        else
                        {
                            x = endX;
                            width = Math.Abs(ctrl.Location.X + ctrl.Width - endX);
                        }
                        if (endY <= ctrl.Location.Y + 4)
                            height = 4;
                        else
                            height = Math.Abs(endY - ctrl.Location.Y);
                        ctrl.Location = new System.Drawing.Point(x, ctrl.Location.Y);
                        ctrl.Width = width;
                        ctrl.Height = height;                        
                        break;
                    case ResizingOption.ResizeBottomRight:
                        if (endY <= ctrl.Location.Y + 4)
                            height = 4;
                        else
                            height = Math.Abs(endY - ctrl.Location.Y);
                        if (endX <= ctrl.Location.X + 4)
                            width = 4;
                        else
                            width = Math.Abs(endX - ctrl.Location.X);
                        ctrl.Width = width;
                        ctrl.Height = height;                        
                        break;
                    case ResizingOption.ResizeLeft:
                        if (endX >= ctrl.Location.X + ctrl.Width - 4)
                        {
                            x = ctrl.Location.X + ctrl.Width - 4;
                            width = 4;
                        }
                        else
                        {
                            x = endX;
                            width = Math.Abs(ctrl.Location.X + ctrl.Width - endX);
                        }
                        ctrl.Location = new System.Drawing.Point(x, ctrl.Location.Y);
                        ctrl.Width = width;                        
                        break;
                    case ResizingOption.ResizeRight:
                        if (endX <= ctrl.Location.X + 4)
                            width = 4;
                        else
                            width = Math.Abs(endX - ctrl.Location.X);
                        ctrl.Width = width;                        
                        break;
                    case ResizingOption.ResizeTop:
                        if (endY >= ctrl.Location.Y + ctrl.Height - 4)
                        {
                            height = 4;
                            y = ctrl.Location.Y + ctrl.Height - 4;
                        }
                        else
                        {
                            height = Math.Abs(ctrl.Height + ctrl.Location.Y - endY);
                            y = endY;
                        }
                        ctrl.Location = new System.Drawing.Point(ctrl.Location.X, y);
                        ctrl.Height = height;
                        break;
                    case ResizingOption.ResizeTopLeft:
                        if (endY >= ctrl.Location.Y + ctrl.Height - 4)
                        {
                            height = 4;
                            y = ctrl.Location.Y + ctrl.Height - 4;
                        }
                        else
                        {
                            height = Math.Abs(ctrl.Height + ctrl.Location.Y - endY);
                            y = endY;
                        }
                        if (endX >= ctrl.Location.X + ctrl.Width - 4)
                        {
                            x = ctrl.Location.X + ctrl.Width - 4;
                            width = 4;
                        }
                        else
                        {
                            x = endX;
                            width = Math.Abs(ctrl.Location.X + ctrl.Width - endX);
                        }
                        ctrl.Location = new System.Drawing.Point(x, y);
                        ctrl.Width = width;
                        ctrl.Height = height;
                        break;
                    case ResizingOption.ResizeTopRight:
                        if (endY >= ctrl.Location.Y + ctrl.Height - 4)
                        {
                            height = 4;
                            y = ctrl.Location.Y + ctrl.Height - 4;
                        }
                        else
                        {
                            height = Math.Abs(ctrl.Height + ctrl.Location.Y - endY);
                            y = endY;
                        }
                        if (endX <= ctrl.Location.X + 4)
                            width = 4;
                        else
                            width = Math.Abs(endX - ctrl.Location.X);
                        ctrl.Location = new System.Drawing.Point(ctrl.Location.X, y);
                        ctrl.Width = width;
                        ctrl.Height = height;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion                                                
    }
}


