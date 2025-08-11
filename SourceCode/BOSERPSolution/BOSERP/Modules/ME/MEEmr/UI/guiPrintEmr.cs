using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.MEEmr;
using DevExpress.XtraGrid.Views.Grid;
using Clas.Emr.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Linq;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.ViewInfo;
using BOSCommon;
using BOSLib;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiPrintEmr : BOSERPScreen
    {
        private List<MEEmrDocumentsInfo> _documentList;

        public guiPrintEmr(List<MEEmrDocumentsInfo> docs)
        {
            InitializeComponent();
            this._documentList = docs.Where(o => o.MEEmrDocumentStatus != EmrDocumentStatus.Hidden.ToString()).ToList();
        }

        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.InitializeControls(this.Controls);
            fld_dgcMEEmrDocuments1.DataSource = this._documentList;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DSMEEMR106_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        private void Print()
        {
            GridView grid = fld_dgcMEEmrDocuments1.MainView as GridView;
            var rows = grid.GetSelectedRows().Where(o => o >= 0).ToList();
            var count = rows.Count;
            if (count == 0) return;

            BOSProgressBar.Start("Đang tải xuống và xử lý tập tin");
            var msg = "Danh sách tờ bệnh án đã in:\n";
            try
            {
                for (int i = 0; i < count; i++)
                {
                    int rowidx = rows[i];
                    var row = grid.GetRow(rowidx) as MEEmrDocumentsInfo;
                    BOSProgressBar.SetText($"Đang in tờ {i + 1}/{count}: {row.MEEmrDocumentCode}-{row.MEEmrDocumentGroup}");
                    ((MEEmrModule)this.Module).QuickPrintDocument(row);
                    System.Threading.Thread.Sleep(1000);
                    msg += $"({i + 1}) #{row.MEEmrDocumentSubOrder}.{row.MEEmrDocumentCode}-{row.MEEmrDocumentGroup} ({row.MEEmrDocumentFile})\n";
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                BOSProgressBar.Close();
                msg += "\nCTRL+C để copy danh sách này. Lưu lại kết quả in để theo dõi";
                MessageBox.Show(msg, "Các tờ bệnh án đã xử lý in thành công.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnPrintSelect_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            GridView grid = fld_dgcMEEmrDocuments1.MainView as GridView;
            grid.SelectAll();
            Print();
            ((MEEmrModule)this.Module).PrintHistory();
        }
    }
}
