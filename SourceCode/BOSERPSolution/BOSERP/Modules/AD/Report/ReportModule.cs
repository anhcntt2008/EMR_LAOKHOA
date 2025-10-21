using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using BOSLib;
using BOSERP.Modules.Report.UI;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using BOSCommon;
using System.Linq;
using Newtonsoft.Json;
using BOSLib.DataAccess;

namespace BOSERP.Modules.Report
{
    #region ReportModule
    public class ReportModule : BaseModuleERP
    {
        private ReportEntities _entity;
        private object _ftpHost;
        private string _ftpReportDir;
        private string _ftpUser;
        private string _ftpPassword;
        private ADReportsController _reportCtrl;
        private ADConfigValuesController _configValueCtrl;
        private string _reportType;
        #region Constants
        #endregion

        public ReportModule()
        {
            Name = "Report";
            _entity = new ReportEntities();
            CurrentModuleEntity = _entity;
            CurrentModuleEntity.Module = this;
            Crypto cryp = new Crypto();
            //_ftpHost = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_HOST), true);
            _ftpHost = SqlDatabaseHelper._PRIVATE_FTP_HOST;
            //_ftpPort = Convert.ToInt32(cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_PORT), true));
            _ftpUser = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_USER), true);
            _ftpPassword = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_PASSWORD), true);
            _ftpReportDir = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_REPORT_DIR), true);

            if (string.IsNullOrEmpty(_ftpUser))
                _ftpUser = "anonymous";

            _reportCtrl = new ADReportsController();
            _configValueCtrl = new ADConfigValuesController();

            InitializeModule();
        }

        public override void InitializeScreens()
        {
            guiReportCenter guiReportCenter = new guiReportCenter(this)
            {
                ScreenNumber = "DMRP100"
            };
            guiReportCenter.InitializeControls(guiReportCenter.Controls);
            Screens.Add(guiReportCenter);
            guiReportCenter.AddControlsToParentScreen();
        }
        public override void ActionNew()
        {
            _entity.SetDefaultMainObject();
            var gui = ShowReportEditForm();
            var report = _entity.MainObject as ADReportsInfo;
            report.ADReportNo = "***NEW***";

            base.ActionNew();
            if (gui.ShowDialog() == DialogResult.OK)
            {
                ActionSave();
            }
            else
            {
                ActionCancel();
            }
        }

        private DMRD100 ShowReportEditForm()
        {
            var gui = new DMRD100
            {
                Module = this
            };
            gui.InitializeControls(gui.Controls);
            gui.StartPosition = FormStartPosition.CenterParent;
            return gui;
        }

        public override int ActionSave()
        {
            var report = _entity.MainObject as ADReportsInfo;
            if (report.ADReportID == 0)
            {

            }
            var id = base.ActionSave();
            RefreshReportGrid();
            return id;
        }
        public override void ActionDelete()
        {
            var report = _entity.MainObject as ADReportsInfo;
            _reportCtrl.DeleteObject(report.ADReportID);
            RefreshReportGrid();
            //base.ActionDelete();
        }
        internal string EditReport(DataRow row)
        {
            int id = int.Parse(row["ADReportID"].ToString());
            Invalidate(id);
            var gui = ShowReportEditForm();
            if (gui.ShowDialog() == DialogResult.OK)
            {
                var report = _entity.MainObject as ADReportsInfo;
                _reportCtrl.UpdateObject(report);
                Invalidate(id);
                return report.ADReportType;
            }
            return string.Empty;
        }

        internal void ShowReport(DataRow row, string mode = "VIEWER")
        {
            string reportNo = row["ADReportNo"].ToString();
            string dataSource = row["ADReportDataSource"].ToString();
            var config = _configValueCtrl.GetObjectByGroupAndValue(BOSCommon.Report.ReportDataSource, dataSource);
            if (config == null)
            {
                MessageBox.Show("Không tìm thấy cấu hình dữ liệu nguồn", "Thiếu cấu hình", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(config.ADConfigKeyDesc))
            {
                MessageBox.Show("Chuỗi kết nối dữ liệu bị rỗng", "Thiếu cấu hình", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var reportTool = BOSApp.AppLocation + @"\report\Emr.Report.exe";

#if DEBUG
            //reportTool = @"D:\emr\ProgressNote - master\SourceCode\Emr.Report\bin\Debug\Emr.Report.exe";
#endif
            var rowContext = _reportCtrl.GetRequestPoolParams(
                    BOSApp.CurrentUsersInfo.ADUserID,
                    BOSApp.CurrentEmployeesInfo.HREmployeeID,
                    BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID
                    );
            var context = rowContext.Table.Columns.Cast<DataColumn>().ToDictionary(c => "_" + c.ColumnName, c => rowContext[c]);
            var ctxStr = JsonConvert.SerializeObject(context);
            var plainTextBytes = Encoding.UTF8.GetBytes(ctxStr);
            var ctxBase64 = Convert.ToBase64String(plainTextBytes);

            //DESIGNER localhost anonymous 1 /Report RP12345
            string cmd = $"{mode} {_ftpHost} {_ftpUser} {_ftpPassword} {_ftpReportDir} {reportNo} {dataSource} {config.ADConfigKeyDesc} {ctxBase64}";
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = reportTool,
                Arguments = cmd
            };

            Process[] reportApp = Process.GetProcessesByName("Emr.Report");
            if (reportApp.Count() > 0)
            {
                MessageBox.Show("Có tiến trình Báo cáo thống kê khác đang chạy.", "Chỉ cho phép 01 tiến trình", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            Process.Start(startInfo);
        }

        internal DataSet GetReportByType(string type)
        {
            this._reportType = type;
            return _reportCtrl.GetReportByReportTypeAndReportPermission(
               this._reportType,
              BOSApp.CurrentUserGroupInfo.ADUserGroupID,
           BOSApp.CurrentUserGroupInfo.ADUserGroupRole == UserGroupRole.admin.ToString() ? -1 : Convert.ToInt16(FieldPermissionType.None));
        }
        internal void RefreshReportGrid()
        {
            DataSet ds = GetReportByType(_reportType);
            if (ds.Tables.Count > 0)
            {
                (Controls["fld_dgcReports"] as DevExpress.XtraGrid.GridControl).DataSource = ds.Tables[0];
            }
        }
    }
    #endregion
}
