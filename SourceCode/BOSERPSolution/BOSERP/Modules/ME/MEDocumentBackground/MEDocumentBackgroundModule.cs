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
using BOSERP.Modules.MEDocumentBackground.UI;
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
using BOSERP.Modules.MEDocumentBackground;
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
using Clas.Model.Middle;
#endregion

namespace BOSERP.Modules.MEDocumentBackground
{
    public class MEDocumentBackgroundModule : BaseModuleERP
    {
        private MEDocumentBackgroundEntities _entity;
        private DigitalSignatureProvider _caProvider;
        private IDigitalSignatureBase _digitalSig;
        private string _macAddress;
        private string _ipAddress;
        private string _hostName;
        private MEEmrsController _emrCtrl;
        #region Constant

        #endregion

        #region Variable
        private ApiHelper _apiEmr;
        private MdAutoGenDocumentDtoGridControl _genGrid;
        private MdAutoSignDocumentDtoGridControl _signGrid;
        #endregion

        #region Public

        #endregion
        public MEDocumentBackgroundModule()
        {
            Name = "MEDocumentBackground";
            CurrentModuleEntity = new MEDocumentBackgroundEntities
            {
                Module = this
            };
            _entity = CurrentModuleEntity as MEDocumentBackgroundEntities;
            InitializeModule();
        }
        public override void InitializeModule()
        {
            base.InitializeModule();
            SetMachineInfo();
            _emrCtrl = new MEEmrsController();
            _genGrid = this.Controls["fld_dgcMdAutoGenDocumentDto"] as MdAutoGenDocumentDtoGridControl;
            _signGrid = this.Controls["fld_dgcMdAutoSignDocumentDto"] as MdAutoSignDocumentDtoGridControl;
            //var emrEndpoint = BOSApp.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_EMR_API_ENDPOINT);
            var emrEndpoint = SqlDatabaseHelper._EMR_API_ENDPOINT;
            if (!string.IsNullOrEmpty(emrEndpoint) && !string.IsNullOrEmpty(BOSApp.EmrApiAuthToken))
                _apiEmr = new ApiHelper(emrEndpoint, BOSApp.EmrApiAuthToken, "EMR");

            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        private void SetMachineInfo()
        {
            _macAddress = BOSApp.GetMachineMac();
            _ipAddress = BOSApp.GetMachineIp();
            _hostName = System.Net.Dns.GetHostName();
        }

        #region MD_AUTO_GEN_DOCUMENTS
        public void MdAutoGenDocumentsSearch(string emrNo, object state, DateTime fromDate, DateTime toDate)
        {
            Cursor.Current = Cursors.WaitCursor;
            var paramList = new Dictionary<string, object>
                {
                    { "state", state != null ? state.ToString(): string.Empty },
                    { "emrNo", emrNo },
                    { "fromDate", fromDate },
                    { "toDate", toDate }
                };

            MdAutoGenDocumentsGet(paramList);
        }

        internal void MdAutoGenDocumentsSearchByPatient(object patientId)
        {
            var emrNos = _emrCtrl.GetAllEmrNoByPatient(Convert.ToInt32(patientId));
            if (emrNos.Count() > 0)
            {
                var paramList = new Dictionary<string, object>
                {
                    { "emrNos", JsonConvert.SerializeObject(emrNos) }
                };

                MdAutoGenDocumentsGet(paramList);
            }
            else
            {
                var gridControl = this.Controls["fld_dgcMdAutoGenDocumentDto"] as MdAutoGenDocumentDtoGridControl;
                if (gridControl != null)
                    gridControl.LoadDataToGridMdAutoGenDocumentDto(new List<MdAutoGenDocumentDto>());
            }
        }

        internal void MdAutoGenDocumentsRunAgain()
        {
            List<ADConfigValuesInfo> adConfigs = _objConfigValuesController.GetConfigValuesByGroup("MdAutoGenDocumentsStatus");
            var conditionStatus = new List<string>()
            {
                AutoGenDocumentStatus.CREATED.ToString(),
                AutoGenDocumentStatus.DISCARDED.ToString()
            };
            var conditionAdConfigs = adConfigs.Where(m => conditionStatus.Contains(m.ADConfigKeyValue)).Select(m => m.ADConfigText).ToList(); //.FirstOrDefault().ADConfigText;

            GridView grid = (_genGrid.MainView as GridView);
            var rows = grid.GetSelectedRows();
            if (rows.Length == 0)
            {
                MessageBox.Show($"Vui lòng chọn tờ bệnh án dưới lưới có trạng thái = [{String.Join("] hoặc [", conditionAdConfigs.ToArray())}] để tạo lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            foreach (int rowidx in rows)
            {
                // duplicate cause select group.
                if (!grid.IsGroupRow(rowidx))
                {
                    var document = grid.GetRow(rowidx) as MdAutoGenDocumentDto;
                    if (!conditionAdConfigs.Contains(document.STATE))
                    {
                        MessageBox.Show($"Chức năng chỉ áp dụng với tờ bệnh án có trạng thái = [{String.Join("] hoặc [", conditionAdConfigs.ToArray())}]. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
            }


            try
            {
                BOSProgressBar.Start($"Đang xử lý tờ bệnh án");
                var newestSelects = new List<MdAutoGenDocumentDto>();
                var notices = new List<string>();
                var selects = new List<MdAutoGenDocumentDto>();
                foreach (int rowidx in rows)
                {
                    // duplicate cause select group.
                    if (!grid.IsGroupRow(rowidx))
                    {
                        selects.Add(grid.GetRow(rowidx) as MdAutoGenDocumentDto);
                    }
                }
                var groups = selects.GroupBy(m => m.VENDOR_DOC_NO).Select((n) => new { Key = n.Key, Items = n.ToList() });
                foreach (var group in groups)
                {
                    if (group.Items.Count > 1)
                    {
                        var sortItems = group.Items.OrderByDescending(m => m.ID);
                        var newestItem = sortItems.FirstOrDefault();
                        var othersItem = group.Items.Where(m => !m.ID.Equals(newestItem.ID)).Select(m => m.ID).ToList();
                        notices.Add($"Mã tờ HIS [{group.Key}]: ID mới [{newestItem.ID}] - cũ [{string.Join(";", othersItem)}]");
                        newestSelects.Add(newestItem);
                    }
                    else
                    {
                        var item = group.Items.FirstOrDefault();
                        if (item != null)
                        {
                            newestSelects.Add(item);
                        }
                    }
                }

                if (notices.Count() > 0)
                {
                    MessageBox.Show(string.Join("\n", notices), "Các dòng đã cũ [sẽ không chạy lại]", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                #region Apply newest id
                if (_apiEmr != null)
                {
                    var actionUri = BOSApp.GetSystemConfigValue(SysCfgConsts.EMR_API_ENDPOINT, SysCfgConsts.EMR_DOCUMENTS_BACKGROUND_ALL_BY_EMR);
                    if (!string.IsNullOrEmpty(actionUri))
                    {
                        var groupEmrNos = newestSelects.GroupBy(m => m.EMR_NO).Select((n) => new { Key = n.Key, Items = n.ToList() });
                        foreach (var groupEmrNo in groupEmrNos)
                        {
                            var emrNo = groupEmrNo.Key;
                            var paramList = new Dictionary<string, object>{
                                { "emrNo", emrNo }
                            };
                            var listMdAutoGenDocumentDto = new List<MdAutoGenDocumentDto>();
                            var response = _apiEmr.Post<Emr.Base.Models.Abp.AjaxResponse, JArray>(actionUri, null, paramList);
                            if (response != null)
                            {
                                if (response.Success)
                                {
                                    if (response.Result != null && response.Result.Count > 0)
                                    {
                                        listMdAutoGenDocumentDto = response.Result.ToObject<List<MdAutoGenDocumentDto>>();
                                    }
                                }
                            }
                            foreach (var document in groupEmrNo.Items)
                            {
                                var maxE = listMdAutoGenDocumentDto.Where(d => d.VENDOR_DOC_NO == document.VENDOR_DOC_NO).OrderByDescending(m => m.ID).FirstOrDefault();
                                if (maxE == null) continue;
                                if (maxE.ID != document.ID)
                                {
                                    if (maxE.STATE == AutoGenDocumentStatus.DISCARDED.ToString())
                                    {
                                        MessageBox.Show($"{document.VENDOR_DOC_NO} đang chọn ID cũ [{document.ID}], có ID mới hơn [{maxE.ID}]. " +
                                        $"\nVui lòng tải lại dữ liệu và chọn ID mới nhất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        return;
                                    }
                                    else if (maxE.STATE == AutoGenDocumentStatus.CREATED.ToString())
                                    {
                                        MessageBox.Show($"{document.VENDOR_DOC_NO} [Đã tạo] thành công với ID [{maxE.ID}].", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        return;
                                    }
                                    else if (maxE.STATE == AutoGenDocumentStatus.SCHEDULED.ToString() || maxE.STATE == AutoGenDocumentStatus.RETRYING.ToString())
                                    {
                                        MessageBox.Show($"{document.VENDOR_DOC_NO} đã được lên lịch [Chờ thực hiện] / [Đang thử lại] với ID [{maxE.ID}].", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show($"{document.VENDOR_DOC_NO} [Đang tạo] với ID [{maxE.ID}].", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        return;
                                    }
                                }
                            }
                        }

                    }
                }
                #endregion

                MdAutoGenDocumentsUpdate(newestSelects);
                BOSProgressBar.Close();
                var btnSearch = this.Controls["btnMdAutoGenDocumentSearch"] as SimpleButton;
                btnSearch.PerformClick();
            }
            catch (Exception ex)
            {
                BOSProgressBar.Close();
                MessageBox.Show("Có lỗi xảy ra."
                    + "\n\nTải lại danh sách tờ bệnh án để tiếp tục." +
                    "\n\n Chi tiết lỗi: " + ex.ToString(), "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BOSProgressBar.Close();
            }
        }

        private void MdAutoGenDocumentsGet(Dictionary<string, object> paramList)
        {
            if (_apiEmr != null)
            {
                var actionUri = BOSApp.GetSystemConfigValue(SysCfgConsts.EMR_API_ENDPOINT, SysCfgConsts.MD_AUTO_GEN_DOCUMENTS_GET);
                if (!string.IsNullOrEmpty(actionUri))
                {
                    var listMdAutoGenDocumentDto = new List<MdAutoGenDocumentDto>();
                    var response = _apiEmr.Post<Emr.Base.Models.Abp.AjaxResponse, JArray>(actionUri, null, paramList);
                    if (response != null)
                    {
                        if (response.Success)
                        {
                            if (response.Result != null && response.Result.Count > 0)
                            {
                                listMdAutoGenDocumentDto = response.Result.ToObject<List<MdAutoGenDocumentDto>>();
                            }
                        }
                    }

                    List<ADConfigValuesInfo> adConfigs = _objConfigValuesController.GetConfigValuesByGroup("MdAutoGenDocumentsStatus");
                    var finalList = new List<MdAutoGenDocumentDto>();
                    foreach (var item in listMdAutoGenDocumentDto)
                    {
                        var configE = adConfigs.Where(m => m.ADConfigKeyValue.Equals(item.STATE)).FirstOrDefault();
                        item.STATE = configE == null ? item.STATE : configE.ADConfigText;
                        finalList.Add(item);
                    }

                    var gridControl = this.Controls["fld_dgcMdAutoGenDocumentDto"] as MdAutoGenDocumentDtoGridControl;
                    if (gridControl != null)
                        gridControl.LoadDataToGridMdAutoGenDocumentDto(finalList);
                }
            }
        }

        private void MdAutoGenDocumentsUpdate(List<MdAutoGenDocumentDto> newestSelects)
        {
            if (newestSelects.Count <= 0) return;
            var ids = newestSelects.Select(m => m.ID).Distinct().ToList();
            var vendorDocs = newestSelects.Select(m => m.EMR_NO + " - " + m.VENDOR_DOC_NO).Distinct().ToList();
            if (_apiEmr != null)
            {
                var actionUri = BOSApp.GetSystemConfigValue(SysCfgConsts.EMR_API_ENDPOINT, SysCfgConsts.MD_AUTO_GEN_DOCUMENTS_UPDATE);
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
                            MessageBox.Show($"Đã kích hoạt thành công.\n{string.Join("\n", vendorDocs)}" +
                              $"\nTác vụ ký ngầm của các tờ này cũng đã được kích hoạt." +
                              "\n\nXin chờ trong ít phút để hệ thống tạo lại tờ.\n[Tải lại] để xem tình trạng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(response.Error.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }
        #endregion

        #region MD_AUTO_SIGN_DOCUMENTS
        public void MdAutoSignDocumentsSearch(string emrNo, object state, DateTime fromDate, DateTime toDate)
        {
            Cursor.Current = Cursors.WaitCursor;
            var paramList = new Dictionary<string, object>
                {
                    { "state", state != null ? state.ToString(): string.Empty },
                    { "emrNo", emrNo },
                    { "fromDate", fromDate },
                    { "toDate", toDate }
                };

            MdAutoSignDocumentsGet(paramList);
        }

        internal void MdAutoSignDocumentsSearchByPatient(object patientId)
        {
            var emrNos = _emrCtrl.GetAllEmrNoByPatient(Convert.ToInt32(patientId));
            if (emrNos.Count() > 0)
            {
                var paramList = new Dictionary<string, object>
                {
                    { "emrNos", JsonConvert.SerializeObject(emrNos) }
                };

                MdAutoSignDocumentsGet(paramList);
            }
            else
            {
                var gridControl = this.Controls["fld_dgcMdAutoSignDocumentDto"] as MdAutoSignDocumentDtoGridControl;
                if (gridControl != null)
                    gridControl.LoadDataToGridMdAutoSignDocumentDto(new List<MdAutoSignDocumentDto>());
            }
        }

        internal void MdAutoSignDocumentsRunAgain()
        {
            List<ADConfigValuesInfo> adConfigs = _objConfigValuesController.GetConfigValuesByGroup("MdAutoSignDocumentsStatus");
            var adConfigsDiscarded = adConfigs.Where(m => m.ADConfigKeyValue.Equals(AutoSignDocumentStatus.DISCARDED.ToString())).FirstOrDefault().ADConfigText;

            GridView grid = (_signGrid.MainView as GridView);
            var rows = grid.GetSelectedRows();
            if (rows.Length == 0)
            {
                MessageBox.Show($"Vui lòng chọn tờ bệnh án dưới lưới có trạng thái = {adConfigsDiscarded} để ký lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            foreach (int rowidx in rows)
            {
                // duplicate cause select group.
                if (!grid.IsGroupRow(rowidx))
                {
                    var document = grid.GetRow(rowidx) as MdAutoSignDocumentDto;
                    if (document.STATE != adConfigsDiscarded)
                    {
                        MessageBox.Show($"Chức năng chỉ áp dụng với tờ bệnh án có trạng thái = {adConfigsDiscarded}. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
            }
            try
            {
                var ids = new List<int>();
                foreach (int rowidx in rows)
                {
                    // duplicate cause select group.
                    if (!grid.IsGroupRow(rowidx))
                    {
                        var document = grid.GetRow(rowidx) as MdAutoSignDocumentDto;
                        BOSProgressBar.Start($"Đang xử lý tờ bệnh án:");
                        ids.Add(document.ID);
                    }
                }
                MdAutoSignDocumentsUpdate(ids.Distinct().ToList());
                BOSProgressBar.Close();
                var btnSearch = this.Controls["btnMdAutoSignDocumentSearch"] as SimpleButton;
                btnSearch.PerformClick();
            }
            catch (Exception ex)
            {
                BOSProgressBar.Close();
                MessageBox.Show("Có lỗi xảy ra."
                    + "\n\nTải lại danh sách tờ bệnh án để tiếp tục." +
                    "\n\n Chi tiết lỗi: " + ex.ToString(), "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BOSProgressBar.Close();
            }
        }

        private void MdAutoSignDocumentsGet(Dictionary<string, object> paramList)
        {
            if (_apiEmr != null)
            {
                var actionUri = BOSApp.GetSystemConfigValue(SysCfgConsts.EMR_API_ENDPOINT, SysCfgConsts.MD_AUTO_SIGN_DOCUMENTS_GET);
                if (!string.IsNullOrEmpty(actionUri))
                {
                    var listMdAutoSignDocumentDto = new List<MdAutoSignDocumentDto>();
                    var response = _apiEmr.Post<Emr.Base.Models.Abp.AjaxResponse, JArray>(actionUri, null, paramList);
                    if (response != null)
                    {
                        if (response.Success)
                        {
                            if (response.Result != null && response.Result.Count > 0)
                            {
                                listMdAutoSignDocumentDto = response.Result.ToObject<List<MdAutoSignDocumentDto>>();
                            }
                        }
                    }

                    List<ADConfigValuesInfo> adConfigs = _objConfigValuesController.GetConfigValuesByGroup("MdAutoSignDocumentsStatus");
                    var finalList = new List<MdAutoSignDocumentDto>();
                    foreach (var item in listMdAutoSignDocumentDto)
                    {
                        var configE = adConfigs.Where(m => m.ADConfigKeyValue.Equals(item.STATE)).FirstOrDefault();
                        item.STATE = configE == null ? item.STATE : configE.ADConfigText;
                        finalList.Add(item);
                    }

                    var gridControl = this.Controls["fld_dgcMdAutoSignDocumentDto"] as MdAutoSignDocumentDtoGridControl;
                    if (gridControl != null)
                        gridControl.LoadDataToGridMdAutoSignDocumentDto(listMdAutoSignDocumentDto);
                }
            }
        }

        private void MdAutoSignDocumentsUpdate(List<int> ids)
        {
            if (_apiEmr != null)
            {
                var actionUri = BOSApp.GetSystemConfigValue(SysCfgConsts.EMR_API_ENDPOINT, SysCfgConsts.MD_AUTO_SIGN_DOCUMENTS_UPDATE);
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
                            MessageBox.Show("Thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(response.Error.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
