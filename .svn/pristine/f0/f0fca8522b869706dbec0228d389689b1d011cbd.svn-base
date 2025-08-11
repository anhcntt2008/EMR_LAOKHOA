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
using BOSERP.Modules.MEEmrAction.UI;
using Clas.Emr.Intergration;
using Newtonsoft.Json;
using System.Configuration;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Activities.Expressions;
using System.Runtime.InteropServices;
using Clas.Emr.Core;
using BOSERP.Modules.MEEmrType.UI;
using BOSERP.Modules.MEEmr.UI;

namespace BOSERP.Modules.MEEmrType
{
    class MEEmrTypeModule : BaseModuleERP
    {
        private MEEmrTypeEntities _entity;
        private METemplateIndexsController _templateIndexsCtrl;
        private MEEmrTypeTemplatesController _typeTemplateCtrl;
        private MEEmrDocumentsController _emrDocumentCtrl;
        private MEEmrsController _emrCtrl;
        private HREmployeesController _employeeCtrl;
        private METemplatesController _templateCtrl;
        private MEEmrActionsController _actionsController;
        private string _macAddress;
        private string _ipAddress;
        private string _hostName;
        #region Constant
        private const string fld_dgcRequestParamPoolControlName = "fld_dgcRequestParamPool";
        #endregion

        #region Variable
        #endregion

        public MEEmrTypeModule()
        {
            Name = "MEEmrType";
            CurrentModuleEntity = new MEEmrTypeEntities();
            _entity = CurrentModuleEntity as MEEmrTypeEntities;

            CurrentModuleEntity.Module = this;
            InitializeModule();
        }

        public override void InitializeModule()
        {
            base.InitializeModule();
            _templateIndexsCtrl = new METemplateIndexsController();
            _typeTemplateCtrl = new MEEmrTypeTemplatesController();
            _emrDocumentCtrl = new MEEmrDocumentsController();
            _emrCtrl = new MEEmrsController();
            _employeeCtrl = new HREmployeesController();
            _templateCtrl = new METemplatesController();
            _actionsController = new MEEmrActionsController();
            SetMachineInfo();
            InvalidateRefreshActions();
        }

        private void SetMachineInfo()
        {
            _macAddress = BOSApp.GetMachineMac();
            _ipAddress = BOSApp.GetMachineIp();
            _hostName = System.Net.Dns.GetHostName();
        }

        public override int ActionSave()
        {
            var type = _entity.MainObject as MEEmrTypesInfo;
            int id = base.ActionSave();
            return id;
        }
        public override void Invalidate(int iObjectId)
        {
            base.Invalidate(iObjectId);
            var tempIndexGrid = _entity.MEEmrTypeTemplateList.GridView;
            var column = tempIndexGrid.Columns["FK_METemplateIndexID"];
            if (column != null)
            {
                var oldRep = (column.ColumnEdit as RepositoryItemLookUpEdit);
                var rep = new RepositoryItemLookUpEdit
                {
                    DataSource = _entity.METemplateIndexList,
                };
                rep.ValueMember = "METemplateIndexID";
                rep.DisplayMember = "METemplateIndexName";
                rep.Columns.AddRange(oldRep.Columns.ToArray());
                column.ColumnEdit = rep;
            }
        }
        internal void AddTemplateToType(METemplatesInfo template)
        {
            var type = _entity.MainObject as MEEmrTypesInfo;
            _entity.MEEmrTypeTemplateList.Add(new MEEmrTypeTemplatesInfo()
            {
                FK_MEEmrTypeID = type.MEEmrTypeID,
                FK_METemplateID = template.METemplateID
            });
            _entity.METemplateList.Remove(template);
            _entity.METemplateList.GridControl.RefreshDataSource();
            _entity.METemplateList.GridControl.Refresh();
            _entity.MEEmrTypeTemplateList.GridControl.RefreshDataSource();
            _entity.MEEmrTypeTemplateList.GridControl.Refresh();
        }

        internal void RemoveTemplateFromType(MEEmrTypeTemplatesInfo typeTemplate)
        {
            var type = _entity.MainObject as MEEmrTypesInfo;
            _entity.MEEmrTypeTemplateList.Remove(typeTemplate);
            _entity.MEEmrTypeTemplateList.GridControl.RefreshDataSource();
            _entity.MEEmrTypeTemplateList.GridControl.Refresh();

            _entity.InvalidateTemplateList(type.MEEmrTypeID);
        }

        internal void DeleteTemplateIndexList()
        {
            _entity.METemplateIndexList.RemoveSelectedRowObjectFromList();
        }

        #region Template Emr
        public void UpdateTemplate()
        {
            var type = _entity.MainObject as MEEmrTypesInfo;
            var gui = new guiUpdateEmrsTemplate(type.MEEmrTypeID)
            {
                Module = this
            };
            gui.InitializeControls(gui.Controls);
            gui.StartPosition = FormStartPosition.CenterParent;
            if (gui.ShowDialog() == DialogResult.OK)
            {
                var emrs = _emrCtrl.GetAllEmrByTypeAndStatus(type.MEEmrTypeID, EmrStatus.InProgress.ToString());
                if (emrs != null && emrs.Count > 0)
                {
                    var documentsHandOn = new List<MEEmrDocumentsInfo>();
                    foreach (var emr in emrs)
                    {
                        var documents = _emrDocumentCtrl.GetListBusinessObjects<MEEmrDocumentsInfo>(_emrDocumentCtrl.GetAllDataByForeignColumn("FK_MEEmrID", emr.MEEmrID));
                        if (documents != null && documents.Count > 0)
                        {
                            foreach (var document in documents)
                            {
                                if (document.FK_EditingUserID > 0 && document.MEEmrDocumentHoldMachineMac != _macAddress && document.MEEmrDocumentFileExt == EmrDocumentFileExtention.docx.ToString())
                                {
                                    documentsHandOn.Add(document);
                                }
                            }
                        }
                    }
                    if (documentsHandOn.Count > 0)
                    {
                        var guiEmrDocuments = new guiEmrDocuments(documentsHandOn)
                        {
                            Module = this
                        };
                        guiEmrDocuments.InitializeControls(guiEmrDocuments.Controls);
                        guiEmrDocuments.StartPosition = FormStartPosition.CenterParent;
                        if (guiEmrDocuments.ShowDialog() != DialogResult.OK) return;
                    }

                    var guiEmrs = new guiEmrs(emrs)
                    {
                        Module = this
                    };
                    guiEmrs.InitializeControls(guiEmrs.Controls);
                    guiEmrs.StartPosition = FormStartPosition.CenterParent;
                    if (guiEmrs.ShowDialog() != DialogResult.OK) return;
                }

                BOSProgressBar.Start("Đang cập nhật dữ liệu");
                try
                {
                    foreach (var templateIndex in gui.MappingList)
                    {
                        if (templateIndex.METemplateIndexIDNew > 0)
                        {
                            var objTemplateIndex = _templateIndexsCtrl.GetObjectByID(templateIndex.METemplateIndexIDNew) as METemplateIndexsInfo;
                            if (templateIndex.METemplateIndexName != objTemplateIndex.METemplateIndexName || templateIndex.METemplateIndexOrder != objTemplateIndex.METemplateIndexOrder)
                            {
                                var result = _emrDocumentCtrl.UpdateAllByTemplateIndex(type.MEEmrTypeID, templateIndex.METemplateIndexName, 
                                    templateIndex.METemplateIndexOrder, objTemplateIndex.METemplateIndexName, objTemplateIndex.METemplateIndexOrder);
                                if (!result)
                                {
                                    MessageBox.Show($"Cập nhật tới gáy {templateIndex.METemplateIndexOrder}. {templateIndex.METemplateIndexName} không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    }

                    BOSProgressBar.Close();
                    MessageBox.Show("Cập nhật gáy thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Cập nhật gáy không thành công.{Environment.NewLine}Chi tiết lỗi:{Environment.NewLine}{ex.ToString()}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    BOSProgressBar.Close();
                }
            }
        }
        #endregion

        #region Start up Action
        internal void InvalidateRefreshActions()
        {
            var ds = _actionsController.GetAllObjects();
            _entity.MEEmrActionList.Invalidate(ds);
            _entity.MEEmrActionList.GridControl.RefreshDataSource();
            _entity.MEEmrActionList.GridControl.Refresh();
        }

        internal void AddStartupActionToType(MEEmrActionsInfo mEEmrActionsInfo)
        {
            if (mEEmrActionsInfo == null) return;
            var typeE = _entity.MainObject as MEEmrTypesInfo;
            _entity.MEEmrTypeActionList.Add(new MEEmrTypeActionsInfo()
            {
                FK_MEEmrActionID = mEEmrActionsInfo.MEEmrActionID,
                FK_MEEmrTypeID = typeE.MEEmrTypeID,
                MEEmrTypeActionWhen = EmrTypeActionWhen.Init.ToString(),
                MEEmrTypeActionDo = EmrTypeActionDo.UpdateDoc.ToString(),
            });
            _entity.MEEmrTypeActionList.GridControl.RefreshDataSource();
        }

        internal void RemoteStartupActionToTemplate(MEEmrTypeActionsInfo MEEmrTypeActionsInfo)
        {
            if (MEEmrTypeActionsInfo == null) return;
            var typeE = _entity.MainObject as MEEmrTypesInfo;
            _entity.MEEmrTypeActionList.Remove(MEEmrTypeActionsInfo);
            _entity.MEEmrTypeActionList.GridControl.RefreshDataSource();
        }
        #endregion
    }
}
