using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.UI;
using DevExpress.XtraGrid.Views.Grid;
using Clas.Model.Middle;
using System.Collections.Generic;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DMMEEMR104
    /// </summary>
    public partial class DMMEEMR104 : BOSERPScreen
    {
        public DMMEEMR104()
        {
            //
            // Required designer variable
            //
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
        }

        private void btnRunAgainMEEmrDocumentBackground_Click(object sender, EventArgs e)
        {
            var grid = fld_dgcMdAutoGenDocumentDto.MainView as GridView;
            if (grid.GetSelectedRows().Length == 0)
            {
                MessageBox.Show($"Vui lòng chọn tờ bệnh án dưới lưới để thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var selects = new List<MdAutoGenDocumentDto>();
            foreach (var item in grid.GetSelectedRows())
            {
                if (!grid.IsGroupRow(item))
                {
                    selects.Add(grid.GetRow(item) as MdAutoGenDocumentDto);
                }
            }
            ((MEEmrModule)Module).RunAgainEmrDocumentsBackground(selects);
        }

        private void fld_btnRefreshHistory_Click(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).GetEmrDocumentsBackground();
        }
    }
}
