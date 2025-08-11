using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOSLib;
using BOSComponent;
using BOSCommon;
using Localization;

namespace BOSERP
{
    public partial class guiInventoryStatus : BOSERPScreen
    {
        public BOSGridControl InventoryStatusGridControl
        {
            get { return fld_dgcInventoryStatus; }
        }

        public guiInventoryStatus()
        {
            InitializeComponent();
        }

        private void fld_btnContinue_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void guiInventoryStatus_Load(object sender, EventArgs e)
        {
            fld_dgcInventoryStatus.Screen = this;
            fld_dgcInventoryStatus.InitializeControl();
        }
    }
}