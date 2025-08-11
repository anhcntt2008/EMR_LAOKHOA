using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSCommon;
using BOSLib;
using DPUruNet;
using Emr.FingerPrint;
using Localization;

namespace BOSERP
{
    public partial class guiSign : Form
    {
        //public string Password;
        public string _msg;
        private bool _fingerPrintEnable;
        private readonly ReaderHandler _handler;
        private readonly ReaderHandlerZK _handlerZK;
        private const int DPFJ_PROBABILITY_ONE = 0x7fffffff;
        private bool _useZKTeco = Convert.ToBoolean(BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.FINGER_PRINT_USE_ZKTeco));
        const int MESSAGE_CAPTURED_OK = 0x0400 + 6;

        public guiSign(string msg = "Xác nhận thực hiện thao tác bằng mật khẩu", ReaderHandlerZK handlerZK = null)
        {
            InitializeComponent();
            this._msg = msg;
            if (!_useZKTeco)
                _handler = new Emr.FingerPrint.ReaderHandler();
            else
                _handlerZK = handlerZK;
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void fld_btnSign_Click(object sender, EventArgs e)
        {
            if (BOSApp.IsAuthenticated(BOSApp.CurrentUser, fld_txtPassword.Text))
            {
                DialogResult = DialogResult.OK;
                //this.Password = fld_txtPassword.Text;
                Close();
            }
            else
            {
                MessageBox.Show(BaseLocalizedResources.InvalidAuthenticationMessage, "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void guiSign_Load(object sender, EventArgs e)
        {
            fld_txtMEPatientNo.Text = BOSApp.CurrentUser;
            txtMsg.Text = this._msg;
            if (!_useZKTeco)
            {
                SetReader();
                _handler.Fmds = BOSApp.UserFingerprintFmds;
            }
            else
            {
                SetReaderZKTeco();
            }
        }

        private void SetReader()
        {
            try
            {
                var reader = _handler.GetFirst();
                if (reader != null)
                {
                    _handler.SetReader(reader);
                    if (!_handler.OpenReader())
                    {
                        this._fingerPrintEnable = false;
                    }
                    if (!_handler.StartCaptureAsync(this.OnCaptured))
                    {
                        this._fingerPrintEnable = false;
                    }
                    _fingerPrintEnable = true;
                }
                else
                {
                    this._fingerPrintEnable = false;
                }
            }
            catch (Exception)
            {
                /*do nothing*/
                this._fingerPrintEnable = false;
            }
        }

        private void SetReaderZKTeco()
        {
            try
            {
                if (_handlerZK.GetDeviceCount() > 0)
                {
                    if (!_handlerZK.OpenDevice(0))
                    {
                        this._fingerPrintEnable = false;
                    }
                    _fingerPrintEnable = true;
                }
                else
                {
                    this._fingerPrintEnable = false;
                }
            }
            catch (Exception)
            {
                /*do nothing*/
                this._fingerPrintEnable = false;
            }
        }

        private void btnFingerprintRecord_Click(object sender, EventArgs e)
        {
            if (!_useZKTeco)
            {
                try
                {
                    if (_handler.GetFirst() == null)
                    {
                        MessageBox.Show("Vui lòng gắn thiết bị đọc vân tay vào cổng USB.", "KHÔNG TÌM THẤY THIẾT BỊ ĐỌC VÂN TAY", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chức năng không khả dụng. Vui lòng gắn thiết bị và cài đặt SDK. \n" + ex.Message, "CHỨC NĂNG KHÔNG KHẢ DỤNG", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (string.IsNullOrEmpty(fld_txtPassword.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu trước khi đăng ký vân tay", "NHẬP MẬT KHẨU", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!BOSApp.IsAuthenticated(BOSApp.CurrentUser, fld_txtPassword.Text))
                {
                    MessageBox.Show("Mật khẩu không đúng!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                _handler.CancelCaptureAndCloseReader(this.OnCaptured);

                using (var cap = new EnrollmentControl())
                {
                    var result = cap.ShowDialog();
                    var controller = new ADUserFingerprintsController();
                    if (result == DialogResult.OK)
                    {
                        foreach (var item in cap.Fmds)
                        {
                            var xml = Fmd.SerializeXml(item.Value);
                            var finger = BOSApp.UserFingerprints.Where(f => f.ADUserFingerprintIndex == item.Key).FirstOrDefault();
                            if (finger != null)
                            {
                                finger.ADUserFingerprintXml = xml;
                                controller.UpdateObject(finger);
                            }
                            else
                            {
                                controller.CreateObject(new ADUserFingerprintsInfo()
                                {
                                    FK_ADUserID = BOSApp.CurrentUsersInfo.ADUserID,
                                    ADUserFingerprintIndex = item.Key,
                                    ADUserFingerprintXml = xml
                                });
                            }
                        }
                        BOSApp.LoadUserFingerprints(BOSApp.CurrentUsersInfo.ADUserID);
                        _handler.Fmds = BOSApp.UserFingerprintFmds;
                    }
                    else if (result == DialogResult.Ignore)
                    {
                        controller.DeleteUserFingerprintsByUser(BOSApp.CurrentUsersInfo.ADUserID);
                    }
                }
                SetReader();
            }
            else
            {
                try
                {
                    if (_handlerZK.GetDeviceCount() == 0)
                    {
                        MessageBox.Show("Vui lòng gắn thiết bị đọc vân tay vào cổng USB.", "KHÔNG TÌM THẤY THIẾT BỊ ĐỌC VÂN TAY", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chức năng không khả dụng. Vui lòng gắn thiết bị và cài đặt SDK. \n" + ex.Message, "CHỨC NĂNG KHÔNG KHẢ DỤNG", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (string.IsNullOrEmpty(fld_txtPassword.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu trước khi đăng ký vân tay", "NHẬP MẬT KHẨU", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!BOSApp.IsAuthenticated(BOSApp.CurrentUser, fld_txtPassword.Text))
                {
                    MessageBox.Show("Mật khẩu không đúng!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                using (var cap = new EnrollmentZKTecoControl(_handlerZK))
                {
                    var result = cap.ShowDialog();
                    var controller = new ADUserFingerprintsZKTecoController();
                    if (result == DialogResult.OK)
                    {
                        foreach (var item in cap.ADUserFingerprints)
                        {
                            var finger = BOSApp.UserFingerprintsZKTeco.Where(f => f.ADUserFingerprintIndex == item.Key).FirstOrDefault();
                            if (finger != null)
                            {
                                finger.ADUserFingerprintByte = item.Value;
                                controller.UpdateObject(finger);
                            }
                            else
                            {
                                controller.CreateObject(new ADUserFingerprintsZKTecoInfo()
                                {
                                    FK_ADUserID = BOSApp.CurrentUsersInfo.ADUserID,
                                    ADUserFingerprintByte = item.Value,
                                    ADUserFingerprintIndex = item.Key
                                });
                            }
                        }
                        BOSApp.LoadUserFingerprintsZKTeco(BOSApp.CurrentUsersInfo.ADUserID);
                    }
                    else if (result == DialogResult.Ignore)
                    {
                        controller.DeleteUserFingerprintsByUser(BOSApp.CurrentUsersInfo.ADUserID);
                        BOSApp.LoadUserFingerprintsZKTeco(BOSApp.CurrentUsersInfo.ADUserID);
                    }
                    SetReaderZKTeco();
                }
            }
        }

        private void OnCaptured(CaptureResult captureResult)
        {
            try
            {
                if (_handler.Fmds.Count == 0)
                {
                    SendMessage(Action.SendMessage, "Chưa đăng ký vân tay. Bấm vào button hình vân tay để đăng ký.");
                    return;
                }
                if (!_handler.CheckCaptureResult(captureResult)) return;
                DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);
                if (resultConversion.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    if (resultConversion.ResultCode != Constants.ResultCode.DP_TOO_SMALL_AREA)
                    {
                        _handler.Reset = true;
                    }
                    throw new Exception(resultConversion.ResultCode.ToString());
                }

                // See the SDK documentation for an explanation on threshold scores.
                int thresholdScore = DPFJ_PROBABILITY_ONE * 1 / 100000;

                IdentifyResult identifyResult = Comparison.Identify(resultConversion.Data, 0, _handler.Fmds.Values, thresholdScore, 2);
                if (identifyResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _handler.Reset = true;
                    SendMessage(Action.SendMessage, "Không nhận dạng được vân tay. Thử lại với vân tay khác.");
                }
                if (identifyResult.Indexes.Length > 0)
                {
                    SendMessage(Action.Validated, identifyResult.ResultCode);
                    return;
                }
                SendMessage(Action.SendMessage, "Không nhận dạng được vân tay. Thử lại với vân tay khác.");
            }
            catch (Exception)
            {
                SendMessage(Action.SendMessage, "Có lỗi khi xác thực vân tay");
            }
        }
        private void guiSign_Closed(object sender, EventArgs e)
        {
            try
            {
                if (_fingerPrintEnable)
                    if (!_useZKTeco)
                        _handler.CancelCaptureAndCloseReader(this.OnCaptured);
                    else
                    {
                        _handlerZK.DBClear();
                        _handlerZK.CloseDevice();
                        _handlerZK.Terminate();
                    }
            }
            catch (Exception)
            {
                /*do nothing*/
            }
        }
        #region SendMessage
        private enum Action
        {
            Validated,
            SendMessage
        }
        private delegate void SendMessageCallback(Action action, object payload);
        private void SendMessage(Action action, object payload)
        {
            try
            {
                if (this.txtMsg.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { action, payload });
                }
                else
                {
                    Console.Beep();
                    switch (action)
                    {
                        case Action.SendMessage:
                            txtMsg.Text = payload.ToString();
                            break;
                        case Action.Validated:
                            DialogResult = DialogResult.OK;
                            //this.Password = fld_txtPassword.Text;
                            Close();
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion
        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    {
                        try
                        {
                            bool bFingerprintMatch = true;
                            if (BOSApp.UserFingerprintsZKTeco.Count == 0)
                            {
                                SendMessage(Action.SendMessage, "Chưa đăng ký vân tay. Bấm vào button hình vân tay để đăng ký.");
                                return;
                            }
                            foreach (var item in BOSApp.UserFingerprintsZKTeco)
                            {
                                if (_handlerZK.DBMatch(item.ADUserFingerprintByte, _handlerZK.CapTmp) <= 0)
                                {
                                    bFingerprintMatch = false;
                                }
                                else
                                {
                                    bFingerprintMatch = true;
                                    break;
                                }
                            }
                            if (bFingerprintMatch)
                            {
                                SendMessage(Action.Validated, "OK");
                                return;
                            }
                            else
                            {
                                SendMessage(Action.SendMessage, "Dấu vân tay không trùng khớp!");
                                return;
                            }
                        }
                        catch
                        {

                        }
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }
    }
}