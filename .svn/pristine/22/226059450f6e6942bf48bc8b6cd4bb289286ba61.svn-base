using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOSERP.Modules.ImportData
{
    public partial class guiChooseBranch : BOSERPScreen
    {
        /// <summary>
        /// Gets or sets the selected branch id
        /// </summary>
        public int SelectedBranchID { get; set; }

        public guiChooseBranch()
        {
            InitializeComponent();
        }

        private void guiChooseBranch_Load(object sender, EventArgs e)
        {
            InitializeControls(Controls);
        }

        public override void InitializeControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                InitializeControl(ctrl);
                if (ctrl.Controls.Count > 0)
                {
                    InitializeControls(ctrl.Controls);
                }
            }
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            SelectedBranchID = Convert.ToInt32(fld_lkeBRBranchID.EditValue);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
