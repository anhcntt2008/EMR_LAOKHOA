#region using
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using BOSCommon;
using BOSERP.Utilities;
using BOSComponent;
using System.Linq;
using System.Windows.Forms;
using Localization;
using BOSLib;
using DevExpress.XtraEditors;
using BOSERP.Modules.MEEmr.UI;
using System.Configuration;
using Clas.Business.Ftp;
using File = System.IO.File;
using DevExpress.XtraRichEdit;
using Clas.Emr.Ipc.Net.Messaging;
using Clas.Emr.Intergration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraGrid.Views.Grid;
using System.Xml;
using DevExpress.XtraRichEdit.Services;
using System.IO;
using System.Diagnostics;
using Clas.Emr.Model;
using System.Globalization;
using BOSERP.Modules.ME;
using System.Drawing;
using System.Drawing.Printing;
using Clas.Emr.Core;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraPdfViewer;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraPrinting;
using Clas.Business.EmrStore;
using AutoMapper;
using Clas.Model.Mongo;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using MongoDB.Bson.Serialization.Serializers;
using DevExpress.Skins;
using Clas.Model.Domain;
using Emr.Devices.GeV100;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Emr.Pluggable.Plugin;
using Emr.Pluggable.Interface;
using DevExpress.XtraRichEdit.API.Layout;
using Emr.Ca;
using Emr.Ca.Core;
using Emr;
using BOSERP.Modules.ME.Helpers;
using Emr.Document.Pdf;
using DevExpress.XtraEditors.Filtering.Templates;
#endregion

namespace BOSERP.Modules.MEEmrStore
{
    public class MEEmrStoreModule : BaseModuleERP
    {
        private MEEmrArchivesController _archivesCtrl;
        private MEEmrStoreEntities _entity;
        private BOSMemoEdit _msgLogs;
        #region Constant

        #endregion

        #region Variable
        private ApiHelper _apiEmr;
        #endregion

        #region Public

        #endregion
        public MEEmrStoreModule()
        {
            Name = "MEEmrStore";
            CurrentModuleEntity = new MEEmrStoreEntities
            {
                Module = this
            };
            _entity = CurrentModuleEntity as MEEmrStoreEntities;
            InitializeModule();
        }
        public override void InitializeModule()
        {
            base.InitializeModule();
            this._msgLogs = this.Controls["txtLogs"] as BOSMemoEdit;
            _archivesCtrl = new MEEmrArchivesController();
            var emrEndpoint = BOSApp.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_EMR_API_ENDPOINT);
            if (!string.IsNullOrEmpty(emrEndpoint) && !string.IsNullOrEmpty(BOSApp.EmrApiAuthToken))
                _apiEmr = new ApiHelper(emrEndpoint, BOSApp.EmrApiAuthToken, "EMR");
        }

        public void SearchEmrStorage(object statusFile, object statusStore, DateTime fromDate, DateTime toDate, DateTime fromDateStore, DateTime toDateStore)
        {
            Cursor.Current = Cursors.WaitCursor;
            object[] paramValues = new object[]
            {
                    statusFile,
                    statusStore,
                    fromDate,
                    toDate,
                    fromDateStore,
                    toDateStore
            };
            _entity.MEEmrArchiveList.Invalidate(_archivesCtrl.Search(paramValues));
        }

        public void UpdateEmrStore()
        {
            var action = "Lên lịch lưu trữ dự phòng";
            GridView grid = _entity.MEEmrArchiveList.GridView;
            var rows = grid.GetSelectedRows();
            if (rows.Length == 0)
            {
                MessageBox.Show($"Chọn ít nhất 01 bệnh án để thực hiện {action}.", "Chưa chọn bệnh án", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            foreach (int rowidx in rows)
            {
                var arc = grid.GetRow(rowidx) as MEEmrArchivesInfo;
                if (arc.MEEmrArchiveBackupStatus != EmrArchiveBackupStatus.Failed.ToString())
                {
                    MessageBox.Show($"{action} chỉ dành cho trạng thái lưu trữ [Lỗi]. Vui lòng chọn lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            try
            {
                BOSProgressBar.Start($"Đang {action}");
                var ids = new List<int>();
                var files = new List<string>();
                foreach (int rowidx in rows)
                {
                    var arc = grid.GetRow(rowidx) as MEEmrArchivesInfo;
                    ids.Add(arc.MEEmrArchiveID);
                    files.Add(arc.MEEmrArchiveFile);
                }
                UpdateEmrArchiveBackupStatus(ids);
                AppendLog(LoggingTag.Info, "LÊN LỊCH SAO LƯU DỰ PHÒNG", $"Đã {action}:{Environment.NewLine} {string.Join(Environment.NewLine, files)}");
                BOSProgressBar.Close();
                var btnSearch = this.Controls["btnSearch"] as SimpleButton;
                btnSearch.PerformClick();
            }
            catch (Exception ex)
            {
                BOSProgressBar.Close();
                MessageBox.Show("Có lỗi xảy ra, xem chi tiết ở màn hình Thông báo."
                    + "\n\nTải lại danh sách bệnh án để tiếp tục. ", $"Có lỗi xảy ra khi {action}",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppendLog(LoggingTag.Error, "LÊN LỊCH SAO LƯU DỰ PHÒNG", ex.ToString());
            }
            finally
            {
                BOSProgressBar.Close();
            }
        }

        private void UpdateEmrArchiveBackupStatus(List<int> ids)
        {
            if (_apiEmr != null)
            {
                var actionUri = BOSApp.GetSystemConfigValue(SysCfgConsts.EMR_API_ENDPOINT, SysCfgConsts.EMR_ARCHIVES_SCHEDULED);
                if (!string.IsNullOrEmpty(actionUri))
                {
                    var paramList = new Dictionary<string, object>
                    {
                        { "ids",  ids },
                        { "userName", BOSApp.CurrentUser },
                    };
                    var response = _apiEmr.Post<Emr.Base.Models.Abp.AjaxResponse, JValue>(actionUri, null, paramList);
                    if (response != null)
                    {
                        if (response.Success)
                        {
                            MessageBox.Show($"File lưu trữ này sẽ được tác vụ ngầm sao lưu dự phòng theo lịch đã cài đặt trong lần tiếp theo. " +
                                $"\nDanh sách chi tiết ở màn hình Thông báo.", "Đã lên lịch sao lưu dự phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi phát sinh, xem ở màn hình Thông báo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            AppendLog(LoggingTag.Error, "LÊN LỊCH SAO LƯU DỰ PHÒNG", response.Error != null ? response.Error.Message : "Api EMR lỗi.");
                        }
                    }
                }
            }
        }

        public void AppendLog(string tag, string title, string message)
        {
            var str = "\r\n" + title + " - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff");
            str += "\r\n" + message;
            str += "\r\n";

            if (_msgLogs.InvokeRequired)
                _msgLogs.Invoke((MethodInvoker)delegate { _msgLogs.Text += str; });
            else
                _msgLogs.Text += str;
        }
    }
}
