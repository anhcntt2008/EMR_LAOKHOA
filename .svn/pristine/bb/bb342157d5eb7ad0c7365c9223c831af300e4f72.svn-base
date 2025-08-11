using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


namespace BOSERP.Modules.Report.UI
{
    /// <summary>
    /// Summary description for DMRD100
    /// </summary>
    public partial class DMRD100 : BOSERPScreen
    {

        public DMRD100()
        {
            //
            // Required designer variable
            //
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa báo cáo này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                (this.Module as ReportModule).ActionDelete();
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
