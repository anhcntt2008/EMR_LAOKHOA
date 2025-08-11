using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;

namespace BOSERP.Modules.EmrAbbrev.UI
{
    /// <summary>
    /// Summary description for DMEAB100
    /// </summary>
    public partial class guiAbbrevSelection : BOSERPScreen
    {

        public guiAbbrevSelection()
        {
            //
            // Required designer variable
            //
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            var grid = this.fld_dgcMEEmrAbbrevs.MainView as GridView;
            if (grid.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 dòng?", "Chọn mã tắt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var list = new List<MEEmrAbbrevsInfo>();
            foreach (var item in grid.GetSelectedRows())
            {
                list.Add(grid.GetRow(item) as MEEmrAbbrevsInfo);
            }
             ((EmrAbbrevModule)this.Module).AddSharedAbbrevList(list);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void guiAbbrevSelection_Load(object sender, EventArgs e)
        {
            this.fld_dgcMEEmrAbbrevs.Screen = this;
            this.fld_dgcMEEmrAbbrevs.InitializeControl();
            ((EmrAbbrevModule)this.Module).InvalidateSharedAbbrevList();
        }
    }
}
