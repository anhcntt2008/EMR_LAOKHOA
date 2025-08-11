using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOSERP.Modules.MEService
{
    public partial class guiAddServiceGroup : BOSERPScreen
    {
        public string ProduceGroupName ;
        public string ProduceGroupNo;

        public guiAddServiceGroup()
        {
            InitializeComponent();
        }

        private void fld_btnAddServiceGroup_Click(object sender, EventArgs e)
        {
            ProduceGroupName = fld_txtServiceGroupName.Text;
            ProduceGroupNo = fld_txtServiceGroupNo.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fld_btnExit_Click(object sender, EventArgs e)
        {
            ProduceGroupName = string.Empty;
            ProduceGroupNo = string.Empty;

            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
