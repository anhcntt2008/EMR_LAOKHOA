using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOSLib;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace BOSERP.Modules.UserManagement
{
    public partial class guiListUsers : BOSERPScreen
    {
        public guiListUsers()
        {
            InitializeComponent();
        }

        public override void InitializeScreen()
        {
            fld_dgcADUsers.Screen = this;
            fld_dgcADUsers.InitializeControl();
            //NUThao [ADD] [23/11/2013] [DB centre] [Permission configuration], START
            fld_dgcADDataViewPermissions.Screen = this;
            fld_dgcADDataViewPermissions.InitializeControl();
            //NUThao [ADD] [23/11/2013] [DB centre] [Permission configuration], END

            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.ADUserList.InitBOSListGridControl(fld_dgcADUsers);
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_btnAdd_Click(object sender, EventArgs e)
        {
            ((UserManagementModule)Module).AddUser();
        }

        /// <summary>
        /// Edit a user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_btnEdit_Click(object sender, EventArgs e)
        {
            ((UserManagementModule)Module).EditUser();
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_btnDelete_Click(object sender, EventArgs e)
        {
            ((UserManagementModule)Module).DeleteUser();
        }

        //NUThao [ADD] [23/11/2013] [DB centre] [Permission configuration], START
        public void RefreshDataVewPermissionGridControlDataSource(DataTable dt)
        {
            fld_dgcADDataViewPermissions.RefreshDataSource(dt);
        }

        private void bosButton2_Click(object sender, EventArgs e)
        {
            ((UserManagementModule)Module).SaveDataViewPermissions();
        }
        //NUThao [ADD] [23/11/2013] [DB centre] [Permission configuration], START
    }
}