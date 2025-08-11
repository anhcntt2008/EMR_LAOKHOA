using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraRichEdit;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;

namespace BOSERP.Modules.EmrShared.UI
{
    /// <summary>
    /// Summary description for DMEAB100
    /// </summary>
    public partial class DMESD100 : BOSERPScreen
    {

        public DMESD100()
        {
            //
            // Required designer variable
            //
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ((EmrSharedModule)Module).InvalidateEmrShared();
        }

        private void btnStopShare_Click(object sender, EventArgs e)
        {
            GridView grid = fld_dgcMEEmrs.MainView as GridView;
            if (grid.GetSelectedRows().Length <= 0)
                return;
            if (MessageBox.Show("Bạn muốn ngừng chia sẻ các bệnh án này.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            foreach (int rowidx in grid.GetSelectedRows())
            {
                var row = grid.GetRow(rowidx) as MEEmrsInfo;
                ((EmrSharedModule)Module).StopShareEmr(row);
            }
            ((EmrSharedModule)Module).InvalidateEmrShared();
        }
    }
}
