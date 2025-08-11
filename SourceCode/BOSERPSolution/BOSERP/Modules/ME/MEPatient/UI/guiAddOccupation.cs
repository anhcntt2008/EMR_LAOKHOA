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
    public partial class guiAddOccupation : BOSERPScreen
    {
        /// <summary>
        /// Gets or sets the occupation description
        /// </summary>
        public string OccupationDesc { get; set; }

        /// <summary>
        /// Gets or sets the occupation no
        /// </summary>
        public string OccupationNo { get; set; }

        public guiAddOccupation()
        {
            InitializeComponent();
        }

        private void fld_btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            OccupationDesc = fld_txtMEOccupationDesc.Text.Trim();
            OccupationNo = fld_txtMEOccupationNo.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
