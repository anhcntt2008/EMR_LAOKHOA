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
using BOSLib.DataAccess;

namespace BOSERP.Modules.MEEmrAction
{
    class MEEmrActionModule : BaseModuleERP
    {
        private MEEmrActionEntities _entity;
        private MEEmrActionParamsController _actionParamsController;
        private METemplateParamsController _templateParamsController;
        #region Constant
        private const string fld_dgcRequestParamPoolControlName = "fld_dgcRequestParamPool";
        private const string fld_medMEEmrActionSendParamsControlName = "fld_medMEEmrActionSendParams";
        #endregion

        #region Variable
        private ParamPool _requestParamPool;
        private MEPatientsController _patientCtrl;
        private string _receiveChannel;
        private string _sendToChannel;
        private MEParamsController _paramsController;
        private MEParamRelationsController _paramRelationsController;
        private MEEmrsController _emrController;
        private MEEmrDocumentsController _emrDocumentController;

        private ApiHelper _api;
        #endregion

        public MEEmrActionModule()
        {
            Name = "MEEmrAction";
            CurrentModuleEntity = new MEEmrActionEntities();
            _entity = CurrentModuleEntity as MEEmrActionEntities;
            _emrController = new MEEmrsController();
            _emrDocumentController = new MEEmrDocumentsController();
            _actionParamsController = new MEEmrActionParamsController();
            _paramsController = new MEParamsController();
            _paramRelationsController = new MEParamRelationsController();
            _templateParamsController = new METemplateParamsController();
            CurrentModuleEntity.Module = this;
            InitializeModule();
            this._patientCtrl = new MEPatientsController();

            InitRequestParamPool();
            System.Configuration.Configuration configuration =
             ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            this._receiveChannel = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_EMR_RECEIVE_CHANNEL);
            this._sendToChannel = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_EMR_SEND_TO_CHANNEL);
            this._api = new ApiHelper();

            var cboBorderStyle = this.Controls["fld_cbo_MEEmrActionBorderTopStyle"] as BOSComboBox;
            if (cboBorderStyle != null)
                cboBorderStyle.Properties.Items.AddRange(typeof(DevExpress.XtraRichEdit.API.Native.TableBorderLineStyle).GetEnumNames());
            cboBorderStyle = this.Controls["fld_cbo_MEEmrActionBorderRightStyle"] as BOSComboBox;
            if (cboBorderStyle != null)
                cboBorderStyle.Properties.Items.AddRange(typeof(DevExpress.XtraRichEdit.API.Native.TableBorderLineStyle).GetEnumNames());
            cboBorderStyle = this.Controls["fld_cbo_MEEmrActionBorderBottomStyle"] as BOSComboBox;
            if (cboBorderStyle != null)
                cboBorderStyle.Properties.Items.AddRange(typeof(DevExpress.XtraRichEdit.API.Native.TableBorderLineStyle).GetEnumNames());
            cboBorderStyle = this.Controls["fld_cbo_MEEmrActionBorderLeftStyle"] as BOSComboBox;
            if (cboBorderStyle != null)
                cboBorderStyle.Properties.Items.AddRange(typeof(DevExpress.XtraRichEdit.API.Native.TableBorderLineStyle).GetEnumNames());
        }

        private void InitRequestParamPool()
        {
            _requestParamPool = new ParamPool();
            //get one document for example
            var doc = _emrDocumentController.GetFirstObject() as MEEmrDocumentsInfo;
            MEEmrsInfo emr;
            MEPatientsInfo patient;

            if (doc != null)
                emr = _emrController.GetObjectByID(doc.FK_MEEmrID) as MEEmrsInfo;
            else
                emr = _emrController.GetFirstObject() as MEEmrsInfo;

            if (emr != null)
                patient = _patientCtrl.GetObjectByID(emr.FK_MEPatientID) as MEPatientsInfo;
            else
                patient = _patientCtrl.GetFirstObject() as MEPatientsInfo;

            _requestParamPool.AddFromDataRow(_emrController.GetRequestPoolParams(
                patient != null ? patient.MEPatientNo : "",
                emr != null ? emr.MEEmrNo : "",
                doc != null ? doc.MEEmrDocumentNo : "",
                BOSApp.CurrentUsersInfo.ADUserID,
                BOSApp.CurrentEmployeesInfo.HREmployeeID,
                BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID));

            (this.Controls[fld_dgcRequestParamPoolControlName] as BOSGridControl).DataSource = _requestParamPool.ToList();
        }


        /// <summary>
        /// Add tham so goi di cho action
        /// utility de add nhanh tham so thoi
        /// </summary>
        /// <param name="v"></param>
        internal void AddRequestParamToAction(KeyValuePair<string, object> v)
        {
            (Controls[fld_medMEEmrActionSendParamsControlName] as BOSMemoEdit).Text += ("|" + v.Key + "={" + v.Key + "}");
        }

        public override int ActionSave()
        {
            var action = _entity.MainObject as MEEmrActionsInfo;
            //neu action goi api buoc kieu du lieu phai la json
            if (action.MEEmrActionType == EmrActionTypes.Api.ToString())
                action.MEEmrActionDataType = EmrActionDataTypes.Json.ToString();
            int id = base.ActionSave();
            return id;
        }

        internal void AddParamToAction(MEParamsInfo mEParamsInfo)
        {
            var action = _entity.MainObject as MEEmrActionsInfo;
            _entity.MEEmrActionParamsList.Add(new MEEmrActionParamsInfo()
            {
                FK_MEEmrActionID = action.MEEmrActionID,
                FK_MEParamID = mEParamsInfo.MEParamID
            });
            _entity.MEParamsList.Remove(mEParamsInfo);
            _entity.MEParamsList.GridControl.RefreshDataSource();
            _entity.MEParamsList.GridControl.Refresh();
            _entity.MEEmrActionParamsList.GridControl.RefreshDataSource();
            _entity.MEEmrActionParamsList.GridControl.Refresh();
        }

        internal void RemoveParamFromAction(MEEmrActionParamsInfo mEEmrActionParamsInfo)
        {
            var action = _entity.MainObject as MEEmrActionsInfo;
            _entity.MEEmrActionParamsList.Remove(mEEmrActionParamsInfo);
            _entity.MEEmrActionParamsList.GridControl.RefreshDataSource();
            _entity.MEEmrActionParamsList.GridControl.Refresh();

            _entity.InvalidateParamList(action.MEEmrActionID);
            _entity.MEParamsList.GridControl.RefreshDataSource();
            _entity.MEParamsList.GridControl.Refresh();
        }

        #region Integration Intruction
        public void ShowIntegrationIntruction()
        {
            if (Toolbar.IsNullOrNoneAction() && Toolbar.CurrentObjectID > 0)
            {
                var gui = new guiIntegrationIntruction();
                gui.Module = this;
                gui.ShowDialog();
            }
            else
                MessageBox.Show("Lưu trước khi mở chức năng này.");
        }
        internal string GetIntegrationIntruction()
        {
            var strBuilder = new StringBuilder();
            var action = _entity.MainObject as MEEmrActionsInfo;
            var updateParams = _actionParamsController.GetAllByActionID(action.MEEmrActionID);
            if (updateParams == null || updateParams.Count == 0)
            {
                return "Chức năng này không định nghĩa cập nhật thông tin nào. Kiểm tra lại cấu hình chức năng này.";
            }
            var paramList = new Dictionary<string, object>();
            //params cung, luc nao cung truyen xuong
            paramList.Add("patientNo", "BN-00002");
            paramList.Add("emrNo", "HS-0003");
            paramList.Add("documentNo", "benh an dien tu_01012018_100988");
            paramList.Add("documentDate", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            foreach (var item in _requestParamPool.GetActionParam(action.MEEmrActionSendParams))
            {
                if (!paramList.ContainsKey(item.Key))
                    paramList.Add(item.Key, item.Value);
            }

            if (action.MEEmrActionType == EmrActionTypes.Sql.ToString())
            {
            }
            else if (action.MEEmrActionType == EmrActionTypes.Api.ToString())
            {
                string response = JsonConvert.SerializeObject(GetJsonSampleObject(updateParams), Newtonsoft.Json.Formatting.Indented);
                response = response.Replace("\"", "");
                response = response.Replace(":", "=");
                strBuilder.AppendLine("(1) MESSAGE: ");
                strBuilder.AppendLine(_api.GetHttpRequestMessageString(action.MEEmrActionUri, paramList));
                strBuilder.AppendLine("(2) API CONTROLLER FUNC: ");
                strBuilder.AppendLine("[Route(\"api/" + action.MEEmrActionUri + "\")]");
                strBuilder.AppendLine("[HttpGet]");
                strBuilder.Append("public object " + action.MEEmrActionNo + "(");
                foreach (var item in paramList)
                {
                    strBuilder.Append(", " + item.Value.GetType().Name + " " + item.Key);
                }
                strBuilder.Append(")");
                strBuilder.AppendLine("");
                strBuilder.AppendLine("{");
                strBuilder.AppendLine("     var result = new");
                strBuilder.AppendLine(response);
                strBuilder.AppendLine("     return result;");
                strBuilder.AppendLine("}");
            }
            else if (action.MEEmrActionType == EmrActionTypes.App.ToString())
            {
                var message = new
                {
                    msg = action.MEEmrActionNo,
                    patientNo = _requestParamPool["MEPatientNo"],
                    emrNo = "HS-0001",
                    documentName = "benh an dien tu",
                    documentNo = "benh an dien tu_01012018_100988",
                    documentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                    query = _requestParamPool.GetActionParam(action.MEEmrActionSendParams)
                };


                var data = new
                {
                    msg = action.MEEmrActionUri,
                    patientNo = _requestParamPool["MEPatientNo"],
                    emrNo = "HS-0001",
                    documentName = "benh an dien tu",
                    documentNo = "benh an dien tu_01012018_100988",
                    documentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                    query = _requestParamPool.GetActionParam(action.MEEmrActionSendParams),
                    data = GetJsonSampleObject(updateParams)
                };
                string response = "";
                string msg = "";
                if (action.MEEmrActionDataType == EmrActionDataTypes.Xml.ToString())
                {
                    msg = JsonConvert.SerializeObject(new { root = message }, Newtonsoft.Json.Formatting.Indented);
                    msg = PrintXML(JsonConvert.DeserializeXmlNode(msg));

                    response = JsonConvert.SerializeObject(new { root = data }, Newtonsoft.Json.Formatting.Indented);
                    response = PrintXML(JsonConvert.DeserializeXmlNode(response));
                }
                else
                {
                    msg = JsonConvert.SerializeObject(message, Newtonsoft.Json.Formatting.Indented);
                    response = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
                }

                strBuilder.AppendLine("(1) SEND TO CHANNEL: " + this._sendToChannel);
                strBuilder.AppendLine("(2) MESSAGE: " + action.MEEmrActionNo);
                strBuilder.AppendLine("(3) PARAMS: ");
                strBuilder.AppendLine(msg);
                strBuilder.AppendLine("");
                strBuilder.AppendLine("(4) BACK TO CHANNEL: " + this._receiveChannel);
                strBuilder.AppendLine("(5) MESSAGE: " + action.MEEmrActionNo);
                strBuilder.AppendLine("(6) RESPONSE: ");
                strBuilder.AppendLine(response);
            }
            else if (action.MEEmrActionType == EmrActionTypes.Replace.ToString())
            {

            }
            return strBuilder.ToString();
        }
        private object GetJsonSampleObject(List<MEEmrActionParamsInfo> updateParams)
        {
            var data = new Dictionary<string, object>();
            foreach (var item in updateParams)
            {
                var param = _paramsController.GetObjectByID(item.FK_MEParamID) as MEParamsInfo;
                var v = GetParamSample(param);
                data.Add(v.Key, v.Value);
            }
            return data;
        }
        private KeyValuePair<string, object> GetParamSample(MEParamsInfo param)
        {
            var meParamChildren = _paramRelationsController.GetAllByParentID(param.MEParamID);
            if (param.MEParamType == EmrParamTypes.Single.ToString())
            {
                if (meParamChildren.Count > 0)
                {
                    return new KeyValuePair<string, object>(param.MEParamNo, GetJsonSampleObject(meParamChildren));
                }
                else
                {
                    var v = string.IsNullOrEmpty(param.MEParamValue) ? param.MEParamCaption : param.MEParamValue;
                    return new KeyValuePair<string, object>(param.MEParamNo, v);
                }
            }
            // list param
            else
            {
                if (meParamChildren.Count > 0)
                {
                    return new KeyValuePair<string, object>(param.MEParamNo, GetJsonSampleListObject(meParamChildren));
                }
                else
                {
                    var v = string.IsNullOrEmpty(param.MEParamValue) ? param.MEParamCaption : param.MEParamValue;
                    string[] list = new string[3];
                    for (int i = 0; i < 3; i++)
                    {
                        list[i] = string.Format("<{0}{1}>", v, i + 1);
                    }
                    return new KeyValuePair<string, object>(param.MEParamNo, list);
                }
            }
        }
        private object GetJsonSampleListObject(List<MEParamRelationsInfo> childrens)
        {
            var data = new Dictionary<string, object>();
            foreach (var c in childrens)
            {
                var param = (MEParamsInfo)_paramsController.GetObjectByID(c.FK_MEParamChildID);
                var v = GetParamSample(param);
                data.Add(v.Key, v.Value);
            }
            object[] list = new object[3];
            for (int i = 0; i < 3; i++)
            {
                list[i] = data;
            }
            return list;
        }

        private object GetJsonSampleObject(List<MEParamRelationsInfo> childrens)
        {
            var data = new Dictionary<string, object>();
            foreach (var c in childrens)
            {
                var param = (MEParamsInfo)_paramsController.GetObjectByID(c.FK_MEParamChildID);
                var v = GetParamSample(param);
                data.Add(v.Key, v.Value);
            }
            return data;

        }
        #endregion

        #region Action relation
        internal void DeleteActionFromRelationList()
        {
            _entity.MEEmrActionRelationsList.RemoveSelectedRowObjectFromList();
        }

        #endregion
        #region Action Param
        internal DataSet GetEmrActionParamSourcePaths(int templateID)
        {
            return _templateParamsController.GetAllTemplateParamByTemplateID(templateID);
        }
        #endregion
        public static String PrintXML(XmlDocument document)
        {
            String Result = "";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);

            try
            {
                writer.Formatting = System.Xml.Formatting.Indented;

                // Write the XML into a formatting XmlTextWriter
                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                // Have to rewind the MemoryStream in order to read
                // its contents.
                mStream.Position = 0;

                // Read MemoryStream contents into a StreamReader.
                StreamReader sReader = new StreamReader(mStream);

                // Extract the text from the StreamReader.
                String FormattedXML = sReader.ReadToEnd();

                Result = FormattedXML;
            }
            catch (XmlException)
            {
            }

            mStream.Close();
            writer.Close();

            return Result;
        }
    }
}
