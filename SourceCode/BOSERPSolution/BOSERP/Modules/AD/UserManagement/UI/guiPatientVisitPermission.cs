using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;

namespace BOSERP.Modules.UserManagement
{
    public partial class guiPatientVisitPermission : BOSERPScreen
    {        
        public guiPatientVisitPermission()
        {
            InitializeComponent();
        }

        public override void InitializeControls()
        {            
            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)this.Module).CurrentModuleEntity;
            entity.MECommandsTreeList.InitBOSTreeListControl(fld_trlstMECommands);
            fld_trlstMECommands.Screen = this;
            fld_trlstMECommands.InitializeControl();
        }

        private void fld_btnSave1000_Click(object sender, EventArgs e)
        {
            ((UserManagementModule)Module).SaveCommandPermission();
        }

        private void fld_trlstMECommands_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        
    }
}
