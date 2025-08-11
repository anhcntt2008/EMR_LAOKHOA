using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraReports.UserDesigner;

namespace Emr.Report.Commands
{
    public class SaveCommand : ICommandHandler
    {
        private XRDesignPanel designPanel;
        private FileReportManager _reportFileMan;
        private string _reportNo;
        private DesignerTool _designerTool;

        public SaveCommand(XRDesignPanel designPanel, FileReportManager reportFileMan, string reportNo, DesignerTool designerTool)
        {
            this.designPanel = designPanel;
            this._reportFileMan = reportFileMan;
            this._reportNo = reportNo;
            this._designerTool = designerTool;
        }
        public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
        {
            useNextHandler = !(command == ReportCommand.SaveFile/* || command == ReportCommand.SaveFileAs*/);
            return !useNextHandler;
        }

        public void HandleCommand(ReportCommand command, object[] args)
        {
            var reportFile = _reportNo + App.ReportExt;
            var localPath = Path.Combine(App.ReportLocalDir, reportFile);
            designPanel.Report.SaveLayout(localPath);
            try
            {
                _reportFileMan.UploadFile(App.FtpDesignDir, reportFile, localPath);
                designPanel.ReportState = ReportState.Saved;
                var text = _designerTool.Text;
                var idx = text.IndexOf(" (Last saved");
                if (idx > 1)
                {
                    text = text.Substring(0, idx);
                }
                _designerTool.Text = text + " (Last saved " + DateTime.Now.ToString("HH:mm:ss") + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
