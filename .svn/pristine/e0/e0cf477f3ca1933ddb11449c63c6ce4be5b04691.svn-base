using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emr.Report
{
    public partial class ViewerForm : Form
    {

        private string _reportNo;
        private FileReportManager _reportFileMan;
        public ViewerForm(string reportNo)
        {
            InitializeComponent();
            _reportNo = reportNo;
            _reportFileMan = new FileReportManager();
        }

        private void ViewerForm_Load(object sender, EventArgs e)
        {
            var report = Open(_reportNo);
            report.CreateDocument();
            this.documentViewer1.DocumentSource = report;
            this.WindowState = FormWindowState.Maximized;
        }

        public XtraReport Open(string reportNo)
        {
            var reportFile = reportNo + App.ReportExt;
            string localPath = Path.Combine(App.ReportLocalDir, reportFile);
            try
            {
                if (_reportFileMan.FileExists(App.FtpDesignDir, reportFile))
                    _reportFileMan.DownloadFile(App.FtpDesignDir, reportFile, localPath);
                else
                {
                    MessageBox.Show("Không có báo cáo để mở.", $"Không tìm thấy tập tin {reportFile}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return new XtraReport();
                }
            }
            catch (IOException exIO)
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return new XtraReport();
            }
            return ReportReader.Create(reportFile);
        }
    }
}
