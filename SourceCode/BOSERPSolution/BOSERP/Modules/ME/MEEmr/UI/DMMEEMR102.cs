using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.UI;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DMMEEMR101
    /// </summary>
    public partial class DMMEEMR102 : BOSERPScreen
    {
        private DevExpress.XtraPdfViewer.Bars.PdfCommandBar pdfCommandBar4;
        private DevExpress.XtraPdfViewer.Bars.PdfFileSaveAsBarItem pdfFileSaveAsBarItem2;
        private DevExpress.XtraPdfViewer.Bars.PdfFilePrintBarItem pdfFilePrintBarItem2;
        private DevExpress.XtraPdfViewer.Bars.PdfFindTextBarItem pdfFindTextBarItem2;
        private DevExpress.XtraPdfViewer.Bars.PdfPreviousPageBarItem pdfPreviousPageBarItem2;
        private DevExpress.XtraPdfViewer.Bars.PdfNextPageBarItem pdfNextPageBarItem2;
        private DevExpress.XtraPdfViewer.Bars.PdfSetPageNumberBarItem pdfSetPageNumberBarItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemPageNumberEdit repositoryItemPageNumberEdit4;
        private DevExpress.XtraPdfViewer.Bars.PdfZoomOutBarItem pdfZoomOutBarItem2;
        private DevExpress.XtraPdfViewer.Bars.PdfZoomInBarItem pdfZoomInBarItem2;
        private DevExpress.XtraPdfViewer.Bars.PdfExactZoomListBarSubItem pdfExactZoomListBarSubItem2;
        private DevExpress.XtraPdfViewer.Bars.PdfBarController pdfBarController1;
        public DMMEEMR102()
        {
            //
            // Required designer variable
            //
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            pdfViewerEmrArchive.UriOpening += pdfViewer_UriOpening;
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
        public override void AddControlsToParentScreen()
        {
            base.AddControlsToParentScreen();
            AddCustomControls();
        }
        private void AddCustomControls()
        {
            ((MEEmrModule)Module).Controls.Add("pdfViewerEmrArchive", this.pdfViewerEmrArchive);
        }
        private void fld_btnRefreshAchiveHistory_Click(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).InvalidateEmrArchives();
            InitPdfViewer();
        }
        private void InitPdfViewer()
        {
            if (this.pdfCommandBar4 != null) return;
            this.pdfBarController1 = new DevExpress.XtraPdfViewer.Bars.PdfBarController();
            // ERROR CTRL + S
            this.pdfCommandBar4 = new DevExpress.XtraPdfViewer.Bars.PdfCommandBar();
            this.pdfFileSaveAsBarItem2 = new DevExpress.XtraPdfViewer.Bars.PdfFileSaveAsBarItem();
            this.pdfFilePrintBarItem2 = new DevExpress.XtraPdfViewer.Bars.PdfFilePrintBarItem();
            this.pdfFindTextBarItem2 = new DevExpress.XtraPdfViewer.Bars.PdfFindTextBarItem();
            this.pdfPreviousPageBarItem2 = new DevExpress.XtraPdfViewer.Bars.PdfPreviousPageBarItem();
            this.pdfNextPageBarItem2 = new DevExpress.XtraPdfViewer.Bars.PdfNextPageBarItem();
            this.pdfSetPageNumberBarItem2 = new DevExpress.XtraPdfViewer.Bars.PdfSetPageNumberBarItem();
            this.repositoryItemPageNumberEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemPageNumberEdit();
            this.pdfZoomOutBarItem2 = new DevExpress.XtraPdfViewer.Bars.PdfZoomOutBarItem();
            this.pdfZoomInBarItem2 = new DevExpress.XtraPdfViewer.Bars.PdfZoomInBarItem();
            this.pdfExactZoomListBarSubItem2 = new DevExpress.XtraPdfViewer.Bars.PdfExactZoomListBarSubItem();

            ((System.ComponentModel.ISupportInitialize)(this.pdfBarController1)).BeginInit();

            this.pdfBarController1.BarItems.Add(this.pdfFileSaveAsBarItem2);
            this.pdfBarController1.BarItems.Add(this.pdfFilePrintBarItem2);
            this.pdfBarController1.BarItems.Add(this.pdfFindTextBarItem2);
            this.pdfBarController1.BarItems.Add(this.pdfPreviousPageBarItem2);
            this.pdfBarController1.BarItems.Add(this.pdfNextPageBarItem2);
            this.pdfBarController1.BarItems.Add(this.pdfSetPageNumberBarItem2);
            this.pdfBarController1.BarItems.Add(this.pdfZoomOutBarItem2);
            this.pdfBarController1.BarItems.Add(this.pdfZoomInBarItem2);
            this.pdfBarController1.BarItems.Add(this.pdfExactZoomListBarSubItem2);
            this.pdfBarController1.Control = this.pdfViewerEmrArchive;

            // 
            // pdfFileSaveAsBarItem2
            // 
            this.pdfFileSaveAsBarItem2.Id = 1;
            this.pdfFileSaveAsBarItem2.Name = "pdfFileSaveAsBarItem2";
            this.pdfFileSaveAsBarItem2.ItemShortcut = null;
            // 
            // pdfFilePrintBarItem2
            // 
            this.pdfFilePrintBarItem2.Id = 2;
            this.pdfFilePrintBarItem2.Name = "pdfFilePrintBarItem2";
            this.pdfFilePrintBarItem2.ItemShortcut = null;
            // 
            // pdfFindTextBarItem2
            // 
            this.pdfFindTextBarItem2.Id = 3;
            this.pdfFindTextBarItem2.Name = "pdfFindTextBarItem2";
            this.pdfFindTextBarItem2.ItemShortcut = null;
            // 
            // pdfPreviousPageBarItem2
            // 
            this.pdfPreviousPageBarItem2.Id = 4;
            this.pdfPreviousPageBarItem2.Name = "pdfPreviousPageBarItem2";
            this.pdfPreviousPageBarItem2.ItemShortcut = null;
            // 
            // pdfNextPageBarItem2
            // 
            this.pdfNextPageBarItem2.Id = 5;
            this.pdfNextPageBarItem2.Name = "pdfNextPageBarItem2";
            this.pdfNextPageBarItem2.ItemShortcut = null;
            // 
            // pdfSetPageNumberBarItem2
            // 
            this.pdfSetPageNumberBarItem2.Edit = this.repositoryItemPageNumberEdit4;
            this.pdfSetPageNumberBarItem2.EditValue = 0;
            this.pdfSetPageNumberBarItem2.Enabled = false;
            this.pdfSetPageNumberBarItem2.Id = 6;
            this.pdfSetPageNumberBarItem2.Name = "pdfSetPageNumberBarItem2";
            this.pdfSetPageNumberBarItem2.ItemShortcut = null;

            // 
            // repositoryItemPageNumberEdit4
            // 
            this.repositoryItemPageNumberEdit4.AutoHeight = false;
            this.repositoryItemPageNumberEdit4.Mask.EditMask = "########;";
            this.repositoryItemPageNumberEdit4.Name = "repositoryItemPageNumberEdit4";
            this.repositoryItemPageNumberEdit4.Orientation = DevExpress.XtraEditors.PagerOrientation.Horizontal;

            // 
            // pdfZoomOutBarItem2
            // 
            this.pdfZoomOutBarItem2.Id = 7;
            this.pdfZoomOutBarItem2.Name = "pdfZoomOutBarItem2";
            this.pdfZoomOutBarItem2.ItemShortcut = null;

            // 
            // pdfZoomInBarItem2
            // 
            this.pdfZoomInBarItem2.Id = 8;
            this.pdfZoomInBarItem2.Name = "pdfZoomInBarItem2";
            this.pdfZoomInBarItem2.ItemShortcut = null;


            this.pdfCommandBar4.BarName = "Pdf Toolbar";
            this.pdfCommandBar4.Control = this.pdfViewerEmrArchive;
            this.pdfCommandBar4.DockCol = 0;
            this.pdfCommandBar4.DockRow = 0;
            this.pdfCommandBar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.pdfCommandBar4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new LinkPersistInfo(this.pdfFileSaveAsBarItem2),
            new LinkPersistInfo(this.pdfFilePrintBarItem2),
            new LinkPersistInfo(this.pdfFindTextBarItem2),
            new LinkPersistInfo(this.pdfPreviousPageBarItem2),
            new LinkPersistInfo(this.pdfNextPageBarItem2),
            new LinkPersistInfo(this.pdfSetPageNumberBarItem2),
            new LinkPersistInfo(this.pdfZoomOutBarItem2),
            new LinkPersistInfo(this.pdfZoomInBarItem2),
            new LinkPersistInfo(this.pdfExactZoomListBarSubItem2)});
            this.pdfCommandBar4.Text = "";

            ((System.ComponentModel.ISupportInitialize)(this.pdfBarController1)).EndInit();

            BarManager BarManager = new BarManager
            {
                Form = this.xtraUserControl1
            };
            BarManager.ForceInitialize();
            StandaloneBarDockControl DockFilter = new StandaloneBarDockControl
            {
                AutoSize = true
            };
            BarManager.DockControls.Add(DockFilter);
            this.splitContainerControl1.Panel2.Controls.Add(DockFilter);
            DockFilter.Dock = DockStyle.Top;
            BarManager.Bars.Add(this.pdfCommandBar4);

            Bar BarFilter = new Bar(BarManager, "Pdf Toolbar");
            BarFilter.AddItem(this.pdfFileSaveAsBarItem2);
            BarFilter.AddItem(this.pdfFilePrintBarItem2);
            BarFilter.AddItem(this.pdfFindTextBarItem2);
            BarFilter.AddItem(this.pdfPreviousPageBarItem2);
            BarFilter.AddItem(this.pdfNextPageBarItem2);
            BarFilter.AddItem(this.pdfSetPageNumberBarItem2);
            BarFilter.AddItem(this.pdfZoomOutBarItem2);
            BarFilter.AddItem(this.pdfZoomInBarItem2);
            BarFilter.AddItem(this.pdfExactZoomListBarSubItem2);

            if (!string.IsNullOrEmpty(BOSApp.CurrentUsersInfo.ADUserCaIdentity))
            {
                BarFilter.AddItem(this.GetDigitalSignPdfBarButtonItem(BarManager));
            }

            BarFilter.StandaloneBarDockControl = DockFilter;
            BarFilter.CanDockStyle = BarCanDockStyle.Standalone;
            BarFilter.DockStyle = BarDockStyle.Standalone;
        }

        internal void ViewArchivePdf(MEEmrArchivesInfo mEEmrArchivesInfo)
        {
            InitPdfViewer();
            var module = ((MEEmrModule)((BaseModuleERP)Module));
            module.ViewArchivePdf(mEEmrArchivesInfo);
        }

        private BarButtonItem GetDigitalSignPdfBarButtonItem(BarManager barManager)
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(DMMEEMR102));
            var btn = new BarButtonItem(barManager, "Ký số CA");
            btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnDigitalSign.ImageOptions.Img16x16")));
            btn.ItemClick += barBtnDigitalSign_ItemClick;
            return btn;
        }
        private void barBtnDigitalSign_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridView gridView = (GridView)this.fld_dgcMEEmrArchives.MainView;
            var module = ((MEEmrModule)((BaseModuleERP)Module));
            if (gridView.FocusedRowHandle >= 0)
            {
                module.DigitalSignEmrArchivePdf(gridView.GetRow(gridView.FocusedRowHandle) as MEEmrArchivesInfo);
            }
        }
    }
}
