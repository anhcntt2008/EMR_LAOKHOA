using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using Localization;

namespace BOSERP.Modules.MENotification.UI
{
    /// <summary>
    /// Summary description for DMNM100
    /// </summary>
    public partial class DMNM100 : BOSERPScreen
    {

        public DMNM100()
        {
            //
            // Required designer variable
            //
            InitializeComponent();
        }

        private void fld_lkeMENotificationType_EditValueChanged(object sender, EventArgs e)
        {
            // value: all => disable HR
            // else enable HR
            if (fld_lkeMENotificationType.EditValue.ToString() == "All")
            {
                fld_ccbeMENotificationDepartment.EditValue = string.Empty;
                fld_ccbeMENotificationDepartment.Enabled = false;
            }
            else
            {
                fld_ccbeMENotificationDepartment.Enabled = true;
            }
        }
    }
}
