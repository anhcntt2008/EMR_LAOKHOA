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

namespace BOSERP.Modules.MEParamReports
{
    class MEParamReportsModule : BaseModuleERP
    {
        private MEParamReportsEntities _entity;
        private MEParamsController _paramCtl;
        private MEEmrTypesController _emrTypeCtl;
        private METemplatesController _templateCtl;
        private MEParamReportRelationsController _paramReportRelationController;
        private MEParamLookupsController _paramLookupController;
        private string _macAddress;
        private string _ipAddress;
        private string _hostName;
        #region Constant
        #endregion

        #region Variable

        #endregion

        public MEParamReportsModule()
        {
            Name = "MEParamReports";
            this._paramReportRelationController = new MEParamReportRelationsController();
            _paramCtl = new MEParamsController();
            _emrTypeCtl = new MEEmrTypesController();
            _templateCtl = new METemplatesController();
            _paramLookupController = new MEParamLookupsController();
            CurrentModuleEntity = new MEParamReportsEntities();
            _entity = CurrentModuleEntity as MEParamReportsEntities;
            CurrentModuleEntity.Module = this;
            InitializeModule();
            SetMachineInfo();
        }

        private void SetMachineInfo()
        {
            _macAddress = BOSApp.GetMachineMac();
            _ipAddress = BOSApp.GetMachineIp();
            _hostName = System.Net.Dns.GetHostName();
        }

        #region Override Search
        public override void Search()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var stateConds = GetStatePermiQueryConditionStr(TableName.MEParamsTableName, false);
                var view = BOSApp.GetUserEmrViewPermission();
                DataSet ds;
                ds = _paramCtl.GetAllByMode("Report");
                Toolbar.SetToolbar(ds);
                InvalidateAfterSearch(null, string.Empty);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public override void QuickSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var stateConds = base.GetStatePermiQueryConditionStr(TableName.MEParamsTableName, false);
                var ds = new DataSet();
                var view = BOSApp.GetUserEmrViewPermission();
                ds = _paramCtl.GetAllByMode("Report");
                //InvalidateSearchResult(ds);
                InvalidateAfterSearch(null, string.Empty);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                if (e is System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Có lỗi trong quá trình lấy dữ liệu. Vui lòng thử lại.");
                    return;
                }

                MessageBox.Show(e.ToString());
            }
        }
        #endregion

        public override void Invalidate(int iObjectId)
        {
            base.Invalidate(iObjectId);
            // Load data
            LoadEmrType();
            LoadParamLookup();
            EnableField(false);
        }

        public override void ActionNew()
        {
            base.ActionNew();
            EnableField(true);
        }

        public override void ActionEdit()
        {
            base.ActionEdit();
            EnableField(true);
        }

        public override void ActionCancel()
        {
            base.ActionCancel();
            EnableField(false);
        }

        public override int ActionSave()
        {
            var mainE = CurrentModuleEntity.MainObject as MEParamsInfo;
            if (mainE != null && string.IsNullOrEmpty(mainE.MEParamNo.Trim()))
            {
                MessageBox.Show("Mã thẻ không để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            if (mainE != null && string.IsNullOrEmpty(mainE.MEParamName.Trim()))
            {
                MessageBox.Show("Tên thẻ không để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            if (mainE != null && string.IsNullOrEmpty(mainE.MEParamXMLTag.Trim()))
            {
                MessageBox.Show("Mã XML không để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            mainE.MEParamType = EmrParamTypes.Single.ToString(); // Only bind data
            mainE.MEParamMode = EmrParamModes.Report.ToString();
            var objectID = base.ActionSave();
            Invalidate(objectID);
            return objectID;
        }

        #region UI
        private void EnableField(bool status)
        {
            Controls["fld_txtMEParamNo"].Enabled = status;
            Controls["fld_txtMEParamName"].Enabled = status;
            Controls["fld_txtMEParamCaption"].Enabled = status;
            Controls["fld_txtMEParamXMLTag"].Enabled = status;
            Controls["fld_lkeMEParamFormatType"].Enabled = status;
            Controls["fld_txtMEParamFormatString"].Enabled = status;
            Controls["fld_txtMEParamMaxLength"].Enabled = status;

            Controls["fld_lkeFK_MEEmrTypeIDRelation"].Enabled = status;
            Controls["fld_lkeFK_METemplateIDRelation"].Enabled = status;
            Controls["fld_lkeMEParamReportMap"].Enabled = status;
            Controls["fld_lkeMEParamReportRelationEncode"].Enabled = status;
            Controls["fld_txtMEParamReportMapFilter"].Enabled = status;
            
            Controls["fld_chkMEParamReportRelationXML"].Enabled = status;
            Controls["fld_txtMEParamReportRelationXMLOrder"].Enabled = status;

            Controls["fld_lkeFK_METemplateIDRelation2"].Enabled = status;
            Controls["fld_lkeMEParamReportMap2"].Enabled = status;
            //Controls["fld_lkeMEParamReportRelationEncode2"].Enabled = status;

            Controls["fld_lkeFK_METemplateIDRelation3"].Enabled = status;
            Controls["fld_lkeMEParamReportMap3"].Enabled = status;
            //Controls["fld_lkeMEParamReportRelationEncode3"].Enabled = status;
        }

        internal void AddEmrTypeToRelation(MEParamReportRelationsInfo item)
        {
            // check exist: 1 thẻ 1 loại bệnh án.
            var list = _entity.MEParamReportRelationsList.ToList();
            var existE = _entity.MEParamReportRelationsList.Count(m => m.FK_MEEmrTypeID.Equals(item.FK_MEEmrTypeID));
            if (existE > 0)
            {
                MessageBox.Show("Thẻ dữ liệu và mẫu bệnh án đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Add to grid
            item.METemplateNo = _templateCtl.GetObjectNoByID(item.FK_METemplateID);
            if (item.FK_METemplateID2 > 0)
            {
                item.METemplateNo2 = _templateCtl.GetObjectNoByID(item.FK_METemplateID2);
            }
            if (item.FK_METemplateID3 > 0)
            {
                item.METemplateNo3 = _templateCtl.GetObjectNoByID(item.FK_METemplateID3);
            }
            _entity.MEParamReportRelationsList.Add(item);
            _entity.MEParamReportRelationsList.GridControl.RefreshDataSource();
            _entity.MEParamReportRelationsList.GridControl.Refresh();
        }

        internal void RemoveItemFromRelationList(MEParamReportRelationsInfo relationInfo)
        {
            _entity.MEParamReportRelationsList.Remove(relationInfo);
            _entity.MEParamReportRelationsList.GridControl.RefreshDataSource();
            _entity.MEParamReportRelationsList.GridControl.Refresh();
        }
        internal void DeleteItemFromRelationList()
        {
            _entity.MEParamReportRelationsList.RemoveSelectedRowObjectFromList();
        }
        internal void LoadEmrType()
        {
            var typeLookupEdit = (BOSLookupEdit)Controls["fld_lkeFK_MEEmrTypeIDRelation"];
            var list = _emrTypeCtl.GetAll();
            list.Insert(0, new MEEmrTypesInfo
            {
                MEEmrTypeID = 0
            });
            typeLookupEdit.Properties.DataSource = list;
        }
        internal void LoadParamLookup()
        {
            var ctLookup = (BOSLookupEdit)Controls["fld_lkeMEParamReportRelationEncode"];
            var ctLookup2 = (BOSLookupEdit)Controls["fld_lkeMEParamReportRelationEncode"];
            var ctLookup3 = (BOSLookupEdit)Controls["fld_lkeMEParamReportRelationEncode"];

            var list = _paramLookupController.GetAll();
            list.Insert(0, new MEParamLookupsInfo
            {
                MEParamLookupID = 0
            });
            ctLookup.Properties.DataSource = list;
            ctLookup2.Properties.DataSource = list;
            ctLookup3.Properties.DataSource = list;
        }
        internal void ChangeEmrTypeRelation(int typeId)
        {
            var templateRelationLookupEdit = (BOSLookupEdit)Controls["fld_lkeFK_METemplateIDRelation"];
            var templateRelationLookupEdit2 = (BOSLookupEdit)Controls["fld_lkeFK_METemplateIDRelation2"];
            var templateRelationLookupEdit3 = (BOSLookupEdit)Controls["fld_lkeFK_METemplateIDRelation3"];
            var list = _templateCtl.GetTemplatesByTypeAndEmrType(TemplateType.ProgressNote.ToString(), typeId);
            list.Insert(0, new METemplatesInfo
            {
                METemplateID = 0
            });
            templateRelationLookupEdit.Properties.DataSource = list;
            templateRelationLookupEdit2.Properties.DataSource = list;
            templateRelationLookupEdit3.Properties.DataSource = list;
        }
        internal void ChangeTemplateRelation(int templateId, string controlName)
        {
            var paramRelationLookupEdit = (BOSLookupEdit)Controls[controlName];
            paramRelationLookupEdit.EditValue = string.Empty;
            var paramsList = _paramCtl.GetAllByTemplate(templateId);
            paramsList.Insert(0, new MEParamsInfo
            {
                MEParamID = 0
            });
            paramRelationLookupEdit.Properties.DataSource = paramsList;
        }
        #endregion
    }
}
