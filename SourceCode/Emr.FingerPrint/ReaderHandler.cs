using DPUruNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emr.FingerPrint
{
    public class ReaderHandler
    {
        private bool _reset;
        private Reader _currentReader;

        public Reader CurrentReader { get => _currentReader; set => _currentReader = value; }
        public Dictionary<int, Fmd> Fmds
        {
            get { return fmds; }
            set { fmds = value; }
        }

        public bool Reset { get => _reset; set => _reset = value; }

        private Dictionary<int, Fmd> fmds = new Dictionary<int, Fmd>();

        public ReaderHandler()
        {
        }
        public Reader GetFirst()
        {
            return ReaderCollection.GetReaders().FirstOrDefault();
        }
        public void SetReader(Reader currentReader)
        {
            _currentReader = currentReader;
        }
        public bool OpenReader()
        {
            using (Tracer tracer = new Tracer("ReaderHandler::OpenReader"))
            {
                _reset = false;
                Constants.ResultCode result = Constants.ResultCode.DP_DEVICE_FAILURE;
                result = _currentReader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);
                if (result != Constants.ResultCode.DP_SUCCESS)
                {
                    MessageBox.Show("Error:  " + result);
                    _reset = true;
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        /// Hookup capture handler and start capture.
        /// </summary>
        /// <param name="OnCaptured">Delegate to hookup as handler of the On_Captured event</param>
        /// <returns>Returns true if successful; false if unsuccessful</returns>
        public bool StartCaptureAsync(Reader.CaptureCallback OnCaptured)
        {
            using (Tracer tracer = new Tracer("ReaderHandler::StartCaptureAsync"))
            {
                // Activate capture handler
                _currentReader.On_Captured += new Reader.CaptureCallback(OnCaptured);

                // Call capture
                if (!CaptureFingerAsync())
                {
                    return false;
                }

                return true;
            }
        }
        /// <summary>
        /// Function to capture a finger. Always get status first and calibrate or wait if necessary.  Always check status and capture errors.
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public bool CaptureFingerAsync()
        {
            using (Tracer tracer = new Tracer("ReaderHandler::CaptureFingerAsync"))
            {
                try
                {
                    GetStatus();

                    Constants.ResultCode captureResult = _currentReader.CaptureAsync(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, _currentReader.Capabilities.Resolutions[0]);
                    if (captureResult != Constants.ResultCode.DP_SUCCESS)
                    {
                        _reset = true;
                        throw new Exception("" + captureResult);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:  " + ex.Message);
                    return false;
                }
            }
        }
        /// <summary>
        /// Check the device status before starting capture.
        /// </summary>
        /// <returns></returns>
        public void GetStatus()
        {
            using (Tracer tracer = new Tracer("ReaderHandler::GetStatus"))
            {
                Constants.ResultCode result = _currentReader.GetStatus();

                if ((result != Constants.ResultCode.DP_SUCCESS))
                {
                    _reset = true;
                    throw new Exception("" + result);
                }

                if ((_currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY))
                {
                    Thread.Sleep(50);
                }
                else if ((_currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION))
                {
                    _currentReader.Calibrate();
                }
                else if ((_currentReader.Status.Status != Constants.ReaderStatuses.DP_STATUS_READY))
                {
                    throw new Exception("Reader Status - " + _currentReader.Status.Status);
                }
            }
        }
        /// <summary>
        /// Check quality of the resulting capture.
        /// </summary>
        public bool CheckCaptureResult(CaptureResult captureResult)
        {
            using (Tracer tracer = new Tracer("ReaderHandler::CheckCaptureResult"))
            {
                if (captureResult.Data == null || captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                    {
                        _reset = true;
                        throw new Exception(captureResult.ResultCode.ToString());
                    }

                    // Send message if quality shows fake finger
                    if ((captureResult.Quality != Constants.CaptureQuality.DP_QUALITY_CANCELED))
                    {
                        throw new Exception("Quality - " + captureResult.Quality);
                    }
                    return false;
                }

                return true;
            }
        }
        /// <summary>
        /// Cancel the capture and then close the reader.
        /// </summary>
        /// <param name="OnCaptured">Delegate to unhook as handler of the On_Captured event </param>
        public void CancelCaptureAndCloseReader(Reader.CaptureCallback OnCaptured)
        {
            using (Tracer tracer = new Tracer("ReaderHandler::CancelCaptureAndCloseReader"))
            {
                if (_currentReader != null)
                {
                    _currentReader.CancelCapture();
                    // Dispose of reader handle and unhook reader events.
                    _currentReader.Dispose();
                    if (_reset)
                    {
                        _currentReader = null;
                    }
                }
            }
        }
        /// <summary>
        /// Create a bitmap from raw data in row/column format.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public Bitmap CreateBitmap(byte[] bytes, int width, int height, string contentHash)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);
            if (!string.IsNullOrEmpty(contentHash))
            {
                RectangleF rect;
                var font = 10;
                if (height < 500)
                {
                    rect = new RectangleF(125, 110, 700, 30);
                    font = 10;
                }
                else
                {
                    rect = new RectangleF(150, 130, 700, 30);
                    font = 13;
                }
                Graphics g = Graphics.FromImage(bmp);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.RotateTransform(44, MatrixOrder.Append);
                g.DrawString(contentHash, new Font("Tahoma", font), Brushes.Blue, rect);
                g.Flush();
            }
            return bmp;
        }

    }
}
