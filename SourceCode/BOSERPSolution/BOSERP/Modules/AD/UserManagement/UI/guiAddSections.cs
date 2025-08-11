using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using BOSLib;
using Localization;

namespace BOSERP.Modules.UserManagement
{
    public enum AddSectionMode { Add, Edit }

    public partial class guiAddSections : BOSERPScreen
    {
        private TreeList TreeList = null;
        private AddSectionMode Mode;

        public guiAddSections()
        {
            InitializeComponent();
        }
        public guiAddSections(TreeList treeList, AddSectionMode mode)
        {
            InitializeComponent();
            TreeList = treeList;
            Mode = mode;
        }

        private void fld_btnCloseSection_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fld_btnAddSection_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fld_txtSection.Text))
            {
                MessageBox.Show(UserManagementLocalizedResources.SectionNameRequiredMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ADUserGroupSectionsController objUserGroupSectionsController = new ADUserGroupSectionsController();
            if (Mode == AddSectionMode.Add)
            {
                ADUserGroupSectionsInfo objADUserGroupSectionsInfo = new ADUserGroupSectionsInfo();
                objADUserGroupSectionsInfo.ADUserGroupID = Convert.ToInt32(TreeList.FocusedNode.Tag);
                objADUserGroupSectionsInfo.ADUserGroupSectionName = fld_txtSection.Text;
                objADUserGroupSectionsInfo.ADUserGroupSectionDesc = objADUserGroupSectionsInfo.ADUserGroupSectionName;
                int maxOrder = objUserGroupSectionsController.GetMaxSortOrderSectionByUserGroupID(objADUserGroupSectionsInfo.ADUserGroupID);
                objADUserGroupSectionsInfo.ADUserGroupSectionSortOrder = maxOrder + 1;
                objUserGroupSectionsController.CreateObject(objADUserGroupSectionsInfo);
            }
            else if (Mode == AddSectionMode.Edit)
            {
                ADUserGroupSectionsInfo objADUserGroupSectionsInfo = (ADUserGroupSectionsInfo)objUserGroupSectionsController.GetObjectByID(Convert.ToInt32(TreeList.FocusedNode.Tag));
                objADUserGroupSectionsInfo.ADUserGroupSectionName = fld_txtSection.Text;
                objADUserGroupSectionsInfo.ADUserGroupSectionDesc = fld_txtSection.Text;
                objUserGroupSectionsController.UpdateObject(objADUserGroupSectionsInfo);
            }
            ((UserManagementModule)this.Module).InitializeTreeList(TreeList);
            this.Close();
        }
    }
}