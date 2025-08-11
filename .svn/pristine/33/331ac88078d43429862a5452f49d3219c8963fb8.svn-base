using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOSERP.Modules.MEPatient
{
    public partial class guiAddEthnic : BOSERPScreen
    {
        /// <summary>
        /// Gets or sets the occupation description
        /// </summary>
        public string EthnicDesc { get; set; }

        /// <summary>
        /// Gets or sets the occupation no
        /// </summary>
        public string EthnicNo { get; set; }

        public guiAddEthnic()
        {
            InitializeComponent();
        }

        private void fld_btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            EthnicDesc = fld_txtMEEthnicDesc.Text.Trim();
            EthnicNo = fld_txtMEEthnicNo.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
