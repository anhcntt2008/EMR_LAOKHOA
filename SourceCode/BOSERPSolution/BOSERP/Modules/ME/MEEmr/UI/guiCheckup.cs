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
using DevExpress.XtraBars;

namespace BOSERP.Modules.MEEmr.UI
{
    public partial class guiCheckup : BOSERPScreen
    {
        private List<MEEmrDocumentsInfo> _documentList;

        public guiCheckup(List<MEEmrDocumentsInfo> docs)
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width - 100;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 60;
            this._documentList = docs.Where(o => o.MEEmrDocumentStatus != EmrDocumentStatus.Hidden.ToString()).ToList();
            BarManager BarManager = new BarManager
            {
                Form = this
            };
            BarManager.ForceInitialize();
            StandaloneBarDockControl DockFilter = new StandaloneBarDockControl
            {
                AutoSize = true
            };
            BarManager.DockControls.Add(DockFilter);
            this.splitContainerControl1.Panel2.Controls.Add(DockFilter);
            DockFilter.Dock = DockStyle.Top;
            BarManager.Bars.Add(this.pdfCommandBar1);

            Bar BarFilter = new Bar(BarManager, "Pdf Toolbar");
            BarFilter.AddItem(this.pdfFileOpenBarItem1);
            BarFilter.AddItem(this.pdfFileSaveAsBarItem1);
            BarFilter.AddItem(this.pdfFilePrintBarItem1);
            BarFilter.AddItem(this.pdfFindTextBarItem1);
            BarFilter.AddItem(this.pdfPreviousPageBarItem1);
            BarFilter.AddItem(this.pdfNextPageBarItem1);
            BarFilter.AddItem(this.pdfSetPageNumberBarItem1);
            BarFilter.AddItem(this.pdfZoomOutBarItem1);
            BarFilter.AddItem(this.pdfZoomInBarItem1);
            BarFilter.AddItem(this.pdfExactZoomListBarSubItem1);
            BarFilter.AddItem(this.pdfZoom10CheckItem1);
            BarFilter.AddItem(this.pdfZoom25CheckItem1);
            BarFilter.AddItem(this.pdfZoom50CheckItem1);
            BarFilter.AddItem(this.pdfZoom75CheckItem1);
            BarFilter.AddItem(this.pdfZoom100CheckItem1);
            BarFilter.AddItem(this.pdfZoom125CheckItem1);
            BarFilter.AddItem(this.pdfZoom150CheckItem1);
            BarFilter.AddItem(this.pdfZoom200CheckItem1);
            BarFilter.AddItem(this.pdfZoom400CheckItem1);
            BarFilter.AddItem(this.pdfZoom500CheckItem1);
            BarFilter.AddItem(this.pdfSetActualSizeZoomModeCheckItem1);
            BarFilter.AddItem(this.pdfSetPageLevelZoomModeCheckItem1);
            BarFilter.AddItem(this.pdfSetFitWidthZoomModeCheckItem1);
            BarFilter.AddItem(this.pdfSetFitVisibleZoomModeCheckItem1);

            BarFilter.StandaloneBarDockControl = DockFilter;
            BarFilter.CanDockStyle = BarCanDockStyle.Standalone;
            BarFilter.DockStyle = BarDockStyle.Standalone;
            pdfViewer1.UriOpening += pdfViewer_UriOpening;
        }
        private void pdfViewer_UriOpening(object sender, DevExpress.XtraPdfViewer.PdfUriOpeningEventArgs e)
        {
            if (e.Uri.Scheme == "http" || e.Uri.Scheme == "https")
            {
                ((MEEmrModule)Module).OpenWebBrowser(e.Uri.AbsoluteUri);
                e.Handled = true;
                e.Cancel = true;
            }
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
                msg += "\nCTRL + C để copy danh sách này. Lưu lại kết quả in để theo dõi";
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
        }

        internal void ViewLocalPdfFile(MEEmrDocumentsInfo document)
        {
            ((MEEmrModule)this.Module).ViewLocalPdfFile(document, pdfViewer1);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
