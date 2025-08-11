using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOSERP.Modules.UserManagement
{
    public partial class guiColumnPermission : BOSERPScreen
    {
        /// <summary>
        /// The name of table of grid control
        /// </summary>
        private string TableName = string.Empty;
        public guiColumnPermission()
        {
            InitializeComponent();
        }

        public guiColumnPermission(string tableName)
        {
            InitializeComponent();
            TableName = tableName;
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void fld_btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void guiColumnPermission_Load(object sender, EventArgs e)
        {
            fld_dgcSTFieldColumnPermissions.Screen = this;
            fld_dgcSTFieldColumnPermissions.InitializeControl();

            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.STFieldColumnPermissionList.InitBOSListGridControl(fld_dgcSTFieldColumnPermissions);
            ((UserManagementModule)Module).InvalidateColumnPermissionList(TableName);
        }
    }
}
