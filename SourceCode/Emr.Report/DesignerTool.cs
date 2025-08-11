using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;

namespace Emr.Report
{
    public class DesignerTool : XRDesignRibbonForm
    {
        // private XRDesignRibbonForm _designForm;
        private FileReportManager _reportFileMan;
        private string _reportNo;

        /// <summary>
        /// Construct and initialize designer form.
        /// </summary>
        public DesignerTool() : base()
        {
            _reportFileMan = new FileReportManager();
            this.DesignMdiController.DesignPanelLoaded += this.OnDesignPanelLoaded;
            // this.DesignMdiController.SetCommandVisibility(ReportCommand.NewReport, CommandVisibility.None);
            // this.DesignMdiController.SetCommandVisibility(ReportCommand.NewReportWizard, CommandVisibility.None);
            this.DesignMdiController.SetCommandVisibility(ReportCommand.SaveAll, CommandVisibility.None);
        }
        public DesignerTool(string reportNo) : this()
        {
            _reportNo = reportNo;

            // co report no thi khong hien thi buttom open file
            if (!string.IsNullOrEmpty(_reportNo))
            {
                // this.DesignMdiController.SetCommandVisibility(ReportCommand.OpenFile, CommandVisibility.None);
                this.DesignMdiController.SetCommandVisibility(ReportCommand.AddNewDataSource, CommandVisibility.None);
                Open(_reportNo);
            }
        }
        /// <summary>
        /// Function to be invoked when design panel is loaded.
        /// </summary>
        private void OnDesignPanelLoaded(object sender, DesignerLoadedEventArgs args)
        {
            XRDesignPanel designPanel = sender as XRDesignPanel;
            designPanel.AddCommandHandler(new Commands.SaveCommand(designPanel, _reportFileMan, _reportNo, this));
        }

        /// <summary>
        /// Open a report.
        /// </summary>
        public void Open(string reportNo)
        {
            var reportFile = reportNo + App.ReportExt;
            string localPath = Path.Combine(App.ReportLocalDir, reportFile);
            try
            {
                if (_reportFileMan.FileExists(App.FtpDesignDir, reportFile))
                    _reportFileMan.DownloadFile(App.FtpDesignDir, reportFile, localPath);
                else
                    MessageBox.Show("Sẽ tự động tạo file báo cáo mới.", $"Không tìm thấy tập tin {reportFile}", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            var report = ReportReader.Create(reportFile);
            this.DesignMdiController.OpenReport(report);
        }
    }
}
