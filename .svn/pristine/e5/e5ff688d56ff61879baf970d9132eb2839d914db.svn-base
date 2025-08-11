using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOSERP;
using libzkfpcsharp;
using Sample;

namespace Emr.FingerPrint
{
    public partial class EnrollmentZKTecoControl : Form
    {
        const int MESSAGE_CAPTURED_OK = 0x0400 + 6;
        const int REGISTER_FINGER_COUNT = 1;
        private ReaderHandlerZK _readerHandlerZK;
        public Dictionary<int, byte[]> ADUserFingerprints { get; set; }
        private int FingerprintIndex;
        public EnrollmentZKTecoControl(ReaderHandlerZK readerHandlerZK)
        {
            InitializeComponent();
            _readerHandlerZK = readerHandlerZK;
            int nCount = _readerHandlerZK.GetDeviceCount();
            _readerHandlerZK.OpenDevice(nCount - 1);
            ADUserFingerprints = new Dictionary<int, byte[]>();
        }
        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    {
                        MemoryStream ms = new MemoryStream();
                        BitmapFormat.GetBitmap(_readerHandlerZK.FPBuffer, _readerHandlerZK.mfpWidth, _readerHandlerZK.mfpHeight, ref ms);
                        Bitmap bmp = new Bitmap(ms);
                        this.pbFingerprint.Image = bmp;
                        this.pbFingerprint.Refresh();

                        if (_readerHandlerZK.IsRegister)
                        {
                            int ret = zkfp.ZKFP_ERR_OK;
                            int fid = 0, score = 0;
                            ret = zkfp2.DBIdentify(_readerHandlerZK.mDBHandle, _readerHandlerZK.CapTmp, ref fid, ref score);
                            if (zkfp.ZKFP_ERR_OK == ret)
                            {
                                txtMessage.AppendText("Vân tay này đã được đăng ký!\r\n\r\n");
                                return;
                            }
                            foreach (var finger in BOSApp.UserFingerprintsZKTeco)
                            {
                                if (_readerHandlerZK.DBMatch(finger.ADUserFingerprintByte, _readerHandlerZK.CapTmp) > 0)
                                {
                                    txtMessage.AppendText("Vân tay này đã được đăng ký!\r\n\r\n");
                                    return;
                                }
                            }    

                            if (_readerHandlerZK.RegisterCount > 0 && _readerHandlerZK.DBMatch(_readerHandlerZK.CapTmp, _readerHandlerZK.RegTmps[_readerHandlerZK.RegisterCount - 1]) <= 0)
                            {
                                txtMessage.AppendText("Vui lòng nhấn ngón tay để đăng ký.\r\n\r\n");
                                return;
                            }

                            Array.Copy(_readerHandlerZK.CapTmp, _readerHandlerZK.RegTmps[_readerHandlerZK.RegisterCount], _readerHandlerZK.cbCapTmp);
                            String strBase64 = zkfp2.BlobToBase64(_readerHandlerZK.CapTmp, _readerHandlerZK.cbCapTmp);
                            byte[] blob = zkfp2.Base64ToBlob(strBase64);
                            _readerHandlerZK.RegisterCount++;
                            if (_readerHandlerZK.RegisterCount >= REGISTER_FINGER_COUNT)
                            {
                                _readerHandlerZK.RegisterCount = 0;
                                if (zkfp.ZKFP_ERR_OK == (ret = zkfp2.DBAdd(_readerHandlerZK.mDBHandle, _readerHandlerZK.iFid, _readerHandlerZK.RegTmp)))
                                {
                                    _readerHandlerZK.iFid++;
                                    if (ADUserFingerprints.ContainsKey(FingerprintIndex))
                                    {
                                        ADUserFingerprints[FingerprintIndex] = _readerHandlerZK.CapTmp;
                                    }
                                    else
                                    {
                                        ADUserFingerprints.Add(FingerprintIndex, _readerHandlerZK.CapTmp);
                                    }
                                    _readerHandlerZK.CapTmp = new byte[2048];
                                    txtMessage.AppendText("Đăng ký thành công vân tay " + FingerprintIndex + "\r\n\r\n");
                                }
                                else
                                {
                                    txtMessage.AppendText("Đăng ký thất bại, error code=" + ret + "\r\n\r\n");
                                }
                                _readerHandlerZK.IsRegister = false;
                                return;
                            }
                        }
                        else
                        {
                            txtMessage.AppendText("Vui lòng chọn vân tay muốn đăng ký!\r\n\r\n");
                        }
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _readerHandlerZK.DBClear();
            _readerHandlerZK.CloseDevice();
            _readerHandlerZK.Terminate();
        }

        private void btnDeleteAllFingerPrint_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show("Bạn muốn xóa các vân tay đã đăng ký trước đây?", "Xóa dấu vân tay?", buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Ignore;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnEnroll1_Click(object sender, EventArgs e)
        {
            string nameBtn = (sender as Control).Name;
            FingerprintIndex = Convert.ToInt32(nameBtn.Substring(9));
            _readerHandlerZK.Enroll();
            txtMessage.AppendText("Vui lòng nhấn ngón tay để đăng ký vân tay " + FingerprintIndex + "\r\n\r\n");
        }
    }
}
