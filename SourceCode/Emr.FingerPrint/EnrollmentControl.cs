using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DPUruNet;

namespace Emr.FingerPrint
{
    public partial class EnrollmentControl : Form
    {
        /// <summary>
        /// Holds the main form with many functions common to all of SDK actions.
        /// </summary>
        private ReaderHandler _readerHandler;

        private DPCtlUruNet.EnrollmentControl _enrollmentControl;

        public Dictionary<int, Fmd> Fmds { get; private set; }

        public EnrollmentControl()
        {
            InitializeComponent();
            _readerHandler = new ReaderHandler();
            var reader = _readerHandler.GetFirst();
            _readerHandler.SetReader(reader);
        }

        /// <summary>
        /// Initialize the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void EnrollmentControl_Load(object sender, EventArgs e)
        {
            if (_enrollmentControl != null)
            {
                _enrollmentControl.Reader = _readerHandler.CurrentReader;
            }
            else
            {
                _enrollmentControl = new DPCtlUruNet.EnrollmentControl(_readerHandler.CurrentReader, Constants.CapturePriority.DP_PRIORITY_COOPERATIVE)
                {
                    BackColor = System.Drawing.SystemColors.Window,
                    Location = new System.Drawing.Point(3, 3),
                    Name = "ctlEnrollmentControl",
                    Size = new System.Drawing.Size(482, 346),
                    TabIndex = 0
                };
                _enrollmentControl.OnCancel += new DPCtlUruNet.EnrollmentControl.CancelEnrollment(this.enrollment_OnCancel);
                _enrollmentControl.OnCaptured += new DPCtlUruNet.EnrollmentControl.FingerprintCaptured(this.enrollment_OnCaptured);
                _enrollmentControl.OnDelete += new DPCtlUruNet.EnrollmentControl.DeleteEnrollment(this.enrollment_OnDelete);
                _enrollmentControl.OnEnroll += new DPCtlUruNet.EnrollmentControl.FinishEnrollment(this.enrollment_OnEnroll);
                _enrollmentControl.OnStartEnroll += new DPCtlUruNet.EnrollmentControl.StartEnrollment(this.enrollment_OnStartEnroll);
                _enrollmentControl.CultureInfo = "vi-VN";
            }

            this.Controls.Add(_enrollmentControl);
        }

        #region Enrollment Control Events
        private void enrollment_OnCancel(DPCtlUruNet.EnrollmentControl enrollmentControl, Constants.ResultCode result, int fingerPosition)
        {
            if (enrollmentControl.Reader != null)
            {
                SendMessage("OnCancel:  " + enrollmentControl.Reader.Description.Name + ", finger " + fingerPosition);
            }
            else
            {
                SendMessage("OnCancel:  No Reader Connected, finger " + fingerPosition);
            }

            btnCancel.Enabled = false;
        }
        private void enrollment_OnCaptured(DPCtlUruNet.EnrollmentControl enrollmentControl, CaptureResult captureResult, int fingerPosition)
        {
            if (enrollmentControl.Reader != null)
            {
                SendMessage("OnCaptured:  " + enrollmentControl.Reader.Description.Name + ", finger " + fingerPosition + ", quality " + captureResult.Quality.ToString());
            }
            else
            {
                SendMessage("OnCaptured:  No Reader Connected, finger " + fingerPosition);
            }

            if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
            {
                if (_readerHandler.CurrentReader != null)
                {
                    _readerHandler.CurrentReader.Dispose();
                    _readerHandler.CurrentReader = null;
                }

                // Disconnect reader from enrollment control
                _enrollmentControl.Reader = null;

                MessageBox.Show("Error:  " + captureResult.ResultCode);
                btnCancel.Enabled = false;
            }
            else
            {
                if (captureResult.Data != null)
                {
                    foreach (Fid.Fiv fiv in captureResult.Data.Views)
                    {
                        pbFingerprint.Image = _readerHandler.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height, string.Empty);
                    }
                }
            }
        }
        private void enrollment_OnDelete(DPCtlUruNet.EnrollmentControl enrollmentControl, Constants.ResultCode result, int fingerPosition)
        {
            if (enrollmentControl.Reader != null)
            {
                SendMessage("OnDelete:  " + enrollmentControl.Reader.Description.Name + ", finger " + fingerPosition);
                SendMessage("Enrolled Finger Mask: " + _enrollmentControl.EnrolledFingerMask);
                SendMessage("Disabled Finger Mask: " + _enrollmentControl.DisabledFingerMask);
            }
            else
            {
                SendMessage("OnDelete:  No Reader Connected, finger " + fingerPosition);
            }

            _readerHandler.Fmds.Remove(fingerPosition);

            if (_readerHandler.Fmds.Count == 0)
            {
                btnClose.Enabled = false;
            }
        }
        private void enrollment_OnEnroll(DPCtlUruNet.EnrollmentControl enrollmentControl, DataResult<Fmd> result, int fingerPosition)
        {
            if (enrollmentControl.Reader != null)
            {
                SendMessage("OnEnroll:  " + enrollmentControl.Reader.Description.Name + ", finger " + fingerPosition);
                SendMessage("Enrolled Finger Mask: " + _enrollmentControl.EnrolledFingerMask);
                SendMessage("Disabled Finger Mask: " + _enrollmentControl.DisabledFingerMask);
            }
            else
            {
                SendMessage("OnEnroll:  No Reader Connected, finger " + fingerPosition);
            }

            if (result != null && result.Data != null)
            {
                _readerHandler.Fmds.Add(fingerPosition, result.Data);
                File.WriteAllText("finger" + fingerPosition, Fmd.SerializeXml(result.Data));
            }

            btnCancel.Enabled = false;

            btnClose.Enabled = true;
        }
        private void enrollment_OnStartEnroll(DPCtlUruNet.EnrollmentControl enrollmentControl, Constants.ResultCode result, int fingerPosition)
        {
            if (enrollmentControl.Reader != null)
            {
                SendMessage("OnStartEnroll:  " + enrollmentControl.Reader.Description.Name + ", finger " + fingerPosition);
            }
            else
            {
                SendMessage("OnStartEnroll:  No Reader Connected, finger " + fingerPosition);
            }

            btnCancel.Enabled = true;
        }
        #endregion

        /// <summary>
        /// Cancel enrollment when window is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show("Bạn muốn các thao tác vừa đăng ký?", "Hủy thao tác đăng ký?", buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                _enrollmentControl.Cancel();
            }
        }

        /// <summary>
        /// Close window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Fmds = _readerHandler.Fmds;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Cancel enrollment when window is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void frmEnrollment_Closed(object sender, EventArgs e)
        {
            _enrollmentControl.Cancel();
        }

        private void SendMessage(string message)
        {
            txtMessage.Text += message + "\r\n\r\n";
            txtMessage.SelectionStart = txtMessage.TextLength;
            txtMessage.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fmds.Clear();
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnDeleteAllFingerPrint_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show("Bạn muốn xóa toàn bộ các vân tay đã đăng ký trước đây?", "Xóa toàn bộ dấu vân tay?", buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                _enrollmentControl.Cancel();
                this.DialogResult = DialogResult.Ignore;
                Close();
            }
        }
    }
}
