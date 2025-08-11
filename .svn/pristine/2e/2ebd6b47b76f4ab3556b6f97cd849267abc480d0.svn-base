using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.UI;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DMMEEMR103
    /// </summary>
    public partial class DMMEEMR103 : BOSERPScreen
    {
        public DMMEEMR103()
        {
            //
            // Required designer variable
            //
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
        }

        private void fld_btnRefreshHistory_Click(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).InvalidateGEObjectHistory();
        }
    }
}
