using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Windows.Forms;



//using BOSBaseProvider;

namespace BOSLib
{
    public class ScreenUtilities
    {
        private const String DefaultText = "---";
        private const int DefaultNumber = 0;
        public ScreenUtilities()
        {
        }

        public static void ResetText(Control ctrlField, Type fieldType, bool required)
        {
            if (!required)
                ctrlField.ResetText();
            else
            {
                if (fieldType == typeof(String))
                    ctrlField.Text = DefaultText;
                else
                    ctrlField.Text = DefaultNumber.ToString();
            }
        }

        #region Utilities for ComboBox
        public static void ResetComboBox(ComboBox cmbItem)
        {
            if (cmbItem.Items.Count > 0)
                cmbItem.SelectedIndex = 0;
        }

       

        public static void AddLanguageToComboBox(ComboBox cmbLanguage, bool isSearchable)
        {
            cmbLanguage.Items.Clear();
            GELanguagesController objGELanguagesController = new GELanguagesController();
            DataSet ds = objGELanguagesController.GetAllObjects();
            if (isSearchable)
                cmbLanguage.Items.Add(String.Empty);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    GELanguagesInfo objGELanguagesInfo = (GELanguagesInfo)objGELanguagesController.GetObjectFromDataRow(row);
                    cmbLanguage.Items.Add(objGELanguagesInfo.GELanguageName.Trim());
                }
                if (cmbLanguage.Items.Count > 0)
                    cmbLanguage.SelectedIndex = 0;
            }
        }

        public static void AddModuleToComboBox(ComboBox cmbModule)
        {
            cmbModule.Items.Clear();
            STModulesController objSTModulesController = new STModulesController();
            DataSet ds = objSTModulesController.GetAllObjects();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    STModulesInfo objSTModulesInfo = (STModulesInfo)objSTModulesController.GetObjectFromDataRow(row);
                    cmbModule.Items.Add(objSTModulesInfo.STModuleName.Trim());
                }
                cmbModule.Text = "";
            }
        }


        public static void AddMatchCodeValueToComboBox(String strMatchCodeColumnName, ComboBox cmbMatchCode)
        {
            cmbMatchCode.Items.Clear();
            ADMatchCodesController objADMatchCodesController = new ADMatchCodesController();
            DataSet dsADMatchCodesValue = objADMatchCodesController.GetADMatchCodesByADMatchCodeColumnName(strMatchCodeColumnName);
            if (dsADMatchCodesValue.Tables.Count > 0)
            {
                if (dsADMatchCodesValue.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dsADMatchCodesValue.Tables[0].Rows)
                    {
                        ADMatchCodesInfo objADMatchCodesInfo = (ADMatchCodesInfo)objADMatchCodesController.GetObjectFromDataRow(row);
                        cmbMatchCode.Items.Add(objADMatchCodesInfo.ADMatchCodeValue);
                    }
                    if (cmbMatchCode.Items.Count > 0)
                        cmbMatchCode.SelectedIndex = 0;
                }
                else
                {
                    cmbMatchCode.DropDownStyle = ComboBoxStyle.Simple;
                }
            }
        }        

        public static void AddModuleToolbarToComboBox(String strModuleName, ComboBox cmbModuleToolbar)
        {
            cmbModuleToolbar.Items.Clear();
            STModuleToolbarsController objSTModuleToolbarsController = new STModuleToolbarsController();
            DataSet dsModuleToolbars = objSTModuleToolbarsController.GetModuleToolbarByModuleName(strModuleName);
            if (dsModuleToolbars.Tables.Count > 0)
            {
                cmbModuleToolbar.DataSource = dsModuleToolbars.Tables[0];
                cmbModuleToolbar.DisplayMember = "ModuleToolbarName";
                cmbModuleToolbar.ValueMember = "ModuleToolbarID";
            }
        }
        #endregion

        #region Utilities for List View
        public static void AddAllUserGroupToListView(ListView lsvUserGroups)
        {
            try
            {
                lsvUserGroups.Items.Clear();
                lsvUserGroups.Columns[0].Width = lsvUserGroups.Width;
                ADUserGroupsController objADUserGroupsController = new ADUserGroupsController();
                DataSet dsUserGroups = objADUserGroupsController.GetAllObjects();
                if (dsUserGroups.Tables.Count > 0)
                {
                    foreach (DataRow row in dsUserGroups.Tables[0].Rows)
                    {
                        ADUserGroupsInfo objADUserGroupsInfo = (ADUserGroupsInfo)objADUserGroupsController.GetObjectFromDataRow(row);
                        ListViewItem lsvItemUserGroup = new ListViewItem();
                        lsvItemUserGroup.Text = objADUserGroupsInfo.ADUserGroupName;
                        lsvItemUserGroup.ImageIndex = 0;

                        lsvUserGroups.Items.Add(lsvItemUserGroup);
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("guiUserManagement.AddAllUserGroupToListView function have error: " + e.Source + e.Message);
            }

        }

        public static void AddUserOfUserGroupToListView(int iUserGroupID, ListView lsvUserOfUserGroup)
        {
            try
            {
                lsvUserOfUserGroup.Items.Clear();
                ADUsersController objADUsersController = new ADUsersController();
                DataSet dsUsers = objADUsersController.GetAllUserByUserGroupID(iUserGroupID);
                if (dsUsers.Tables.Count > 0)
                {
                    for (int i = 0; i < dsUsers.Tables[0].Rows.Count; i++)
                    {
                        ADUsersInfo objADUsersInfo = (ADUsersInfo)objADUsersController.GetObjectFromDataRow(dsUsers.Tables[0].Rows[i]);
                        ListViewItem lsvItemUser = new ListViewItem();
                        lsvItemUser.Text = objADUsersInfo.ADUserName;
                        lsvUserOfUserGroup.Items.Add(lsvItemUser);
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("guiUserGroup.AddUserOfGroupToListView: " + e.Source + " - " + e.Message);
            }
        }

        public static void AddAllUserToListView(ListView lsvUsers)
        {
            try
            {
                lsvUsers.Items.Clear();

                ADUsersController objADUsersController = new ADUsersController();
                DataSet dsUsers = objADUsersController.GetAllObjects();
                if (dsUsers.Tables.Count > 0)
                {
                    foreach (DataRow row in dsUsers.Tables[0].Rows)
                    {
                        ADUsersInfo objADUsersInfo = (ADUsersInfo)objADUsersController.GetObjectFromDataRow(row);
                        ListViewItem lsvItemUser = new ListViewItem();
                        //lsvItemUser.Text = dsUsers.Tables[0].Rows[i]["UserName"].ToString();
                        lsvItemUser.Text = objADUsersInfo.ADUserName;
                        lsvUsers.Items.Add(lsvItemUser);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("guiUserManagement.AddAllUserToListView: " + e.Source + " - " + e.Message);
            }
        }

        public static void AddUserGroupToListViewByUserID(int iUserID, ListView lsvUserGroups)
        {
            try
            {
                lsvUserGroups.Items.Clear();
                ADUserGroupsController objADUserGroupsController = new ADUserGroupsController();
                ADUsersController objADUsersController = new ADUsersController();
                int iUserGroupID = objADUsersController.GetUserGroupOfUser(iUserID);
                ADUserGroupsInfo objUserGroupInfo = (ADUserGroupsInfo)objADUserGroupsController.GetObjectByID(iUserGroupID);
                if (objUserGroupInfo != null)
                {
                    ListViewItem lsvItemUserGroup = new ListViewItem();
                    lsvItemUserGroup.Text = objUserGroupInfo.ADUserGroupName;
                    lsvItemUserGroup.ImageIndex = 0;
                    lsvUserGroups.Items.Add(lsvItemUserGroup);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("guiUserManagement.AddUserGroupToListViewByUserID: " + e.Source + " - " + e.Message);
            }
        }

        public static void AddSectionsToListViewByUserGroup(int iUserGroupID, ListView lsvSection)
        {
            try
            {
                lsvSection.Items.Clear();
                ADUserGroupSectionsController objADUserGroupSectionsController = new ADUserGroupSectionsController();
                DataSet dsSections = objADUserGroupSectionsController.GetUserGroupSectionByUserGroupID(iUserGroupID);

                if (dsSections.Tables.Count > 0)
                {
                    if (dsSections.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in dsSections.Tables[0].Rows)
                        {
                            ADUserGroupSectionsInfo objADUserGroupSectionsInfo = (ADUserGroupSectionsInfo)objADUserGroupSectionsController.GetObjectFromDataRow(row);
                            ListViewItem item = new ListViewItem();
                            item.Text = objADUserGroupSectionsInfo.ADUserGroupSectionName;
                            lsvSection.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("guiUserManagement.AddSectionsToListViewByUserGroup: " + e.Source + " - " + e.Message);
            }

        }

        public static void AddModulesToListViewByUserGroup(int iUserGroupID, ListView lsvModule)
        {
            try
            {
                lsvModule.Items.Clear();
                STModuleToUserGroupSectionsController objSTModuleToUserGroupSectionsController = new STModuleToUserGroupSectionsController();
                DataSet dsModules = objSTModuleToUserGroupSectionsController.GetSectionsAndModulesByUserGroupID(iUserGroupID);
                if (dsModules.Tables.Count > 0)
                {
                    if (dsModules.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in dsModules.Tables[0].Rows)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = row["STModuleName"].ToString();
                            lsvModule.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("guiUserManagement.AddModulesToListViewByUserGroup: " + e.Source + " - " + e.Message);
            }
        }

        public static void AddModulesToListViewBySection(int iUserGrouSectionID, ListView lsvModule)
        {
            try
            {
                lsvModule.Items.Clear();
                STModuleToUserGroupSectionsController objSTModuleToUserGroupSectionsController = new STModuleToUserGroupSectionsController();
                DataSet dsModules = objSTModuleToUserGroupSectionsController.GetAllModuleToUserGroupSectionByUserGroupSectionID(iUserGrouSectionID);
                if (dsModules.Tables.Count > 0)
                {
                    if (dsModules.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in dsModules.Tables[0].Rows)
                        {
                            STModuleToUserGroupSectionsInfo objSTModuleToUserGroupSectionsInfo = (STModuleToUserGroupSectionsInfo)objSTModuleToUserGroupSectionsController.GetObjectFromDataRow(row);
                            ListViewItem item = new ListViewItem();
                            STModulesController objSTModulesController = new STModulesController();
                            STModulesInfo objModuleInfo = (STModulesInfo)objSTModulesController.GetObjectByID(objSTModuleToUserGroupSectionsInfo.STModuleID);
                            if (objModuleInfo != null)
                            {
                                item.Text = objModuleInfo.STModuleName;
                                lsvModule.Items.Add(item);
                            }


                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("guiUserGroup.AddModulesToListViewByUserGroup: " + e.Source + " - " + e.Message);
            }
        }

        public static void AddAllModulesToListView(ListView lsvAllModules)
        {
            try
            {
                lsvAllModules.Items.Clear();
                STModulesController objSTModulesController = new STModulesController();
                DataSet dsModules = objSTModulesController.GetAllObjects();
                if (dsModules.Tables.Count > 0)
                {
                    if (dsModules.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in dsModules.Tables[0].Rows)
                        {
                            STModulesInfo objSTModulesInfo = (STModulesInfo)objSTModulesController.GetObjectFromDataRow(row);
                            ListViewItem item = new ListViewItem();
                            item.Text = objSTModulesInfo.STModuleName;
                            lsvAllModules.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("guiUser.AddAllModuleToListView: " + e.Source + " - " + e.Message);
            }
        }
        #endregion

       

        public static String[] GetDescriptionFromColumnDescription(String strColumnDescription)
        {
            String[] desc = new String[3];
            desc[0] = String.Empty;
            desc[1] = String.Empty;
            desc[2] = String.Empty;

            int i = 0;
            String strCopyColumnDescription = strColumnDescription + ";;;";
            while (strCopyColumnDescription.Contains(";") && i < 3)
            {
                int index = strCopyColumnDescription.IndexOf(";");
                desc[i] = strCopyColumnDescription.Substring(0, index);
                strCopyColumnDescription = strCopyColumnDescription.Remove(0, desc[i].Length + 1);
                i++;
            }
            return desc;
        }


    }
}
