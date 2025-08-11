using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libzkfpcsharp;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using Sample;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Emr.FingerPrint
{
    public class ReaderHandlerZK
    {
        IntPtr mDevHandle = IntPtr.Zero;
        public IntPtr mDBHandle = IntPtr.Zero;
        IntPtr FormHandle = IntPtr.Zero;
        bool bIsTimeToDie = false;
        public bool IsRegister = false;
        public bool bIdentify = true;
        public byte[] FPBuffer;
        public int RegisterCount = 0;

        public byte[][] RegTmps = new byte[3][];
        public byte[] RegTmp = new byte[2048];
        public byte[] CapTmp = new byte[2048];

        public int cbCapTmp = 2048;
        public int cbRegTmp = 0;
        public int iFid = 1;

        public int mfpWidth = 0;
        public int mfpHeight = 0;
        private int mfpDpi = 0;
        const int MESSAGE_CAPTURED_OK = 0x0400 + 6;
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        public ReaderHandlerZK()
        {
            
        }

        public int GetDeviceCount()
        {
            zkfp2.Terminate();
            int ret = zkfperrdef.ZKFP_ERR_OK;
            ret = zkfp2.Init();
            if (ret == zkfperrdef.ZKFP_ERR_OK)
            {
                int nCount = zkfp2.GetDeviceCount() - 1;
                if (nCount > 0)
                {
                    return nCount;
                }
                else
                {
                    zkfp2.Terminate();
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public bool OpenDevice(int index)
        {
            if (IntPtr.Zero == (mDevHandle = zkfp2.OpenDevice(index)))
            {
                MessageBox.Show("Form đăng kí vân tay đã được mở. Vui lòng kiểm tra lại!");
                return false;
            }
            if (IntPtr.Zero == (mDBHandle = zkfp2.DBInit()))
            {
                MessageBox.Show("Init DB fail");
                zkfp2.CloseDevice(mDevHandle);
                mDevHandle = IntPtr.Zero;
                return false;
            }
            else
            {
                RegisterCount = 0;
                cbRegTmp = 0;
                iFid = 1;
                for (int i = 0; i < 3; i++)
                {
                    RegTmps[i] = new byte[2048];
                }
                byte[] paramValue = new byte[4];
                int size = 4;
                zkfp2.GetParameters(mDevHandle, 1, paramValue, ref size);
                zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

                size = 4;
                zkfp2.GetParameters(mDevHandle, 2, paramValue, ref size);
                zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

                FPBuffer = new byte[mfpWidth * mfpHeight];

                size = 4;
                zkfp2.GetParameters(mDevHandle, 3, paramValue, ref size);
                zkfp2.ByteArray2Int(paramValue, ref mfpDpi);

                Thread captureThread = new Thread(new ThreadStart(DoCapture));
                captureThread.IsBackground = true;
                captureThread.Start();
                bIsTimeToDie = false;
                return true;
            }
        }

        public void CloseDevice()
        {
            bIsTimeToDie = true;
            RegisterCount = 0;
            Thread.Sleep(1000);
            zkfp2.CloseDevice(mDevHandle);
        }
        public void Terminate()
        {
            zkfp2.Terminate();
            cbRegTmp = 0;
        }
        public void Enroll()
        {
            if (!IsRegister)
            {
                IsRegister = true;
                RegisterCount = 0;
                cbRegTmp = 0;
            }
        }

        private void DoCapture()
        {
            try
            {
                while (!bIsTimeToDie)
                {
                    cbCapTmp = 2048;
                    int ret = zkfp2.AcquireFingerprint(mDevHandle, FPBuffer, CapTmp, ref cbCapTmp);
                    if (ret == zkfp.ZKFP_ERR_OK)
                    {
                        FormHandle = GetForegroundWindow();
                        SendMessage(FormHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                    }
                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public int DBMatch(byte[] blob1, byte[] blob2)
        {
            return zkfp2.DBMatch(mDBHandle, blob1, blob2);
        }
        public int DBClear()
        {
            return zkfp2.DBClear(mDBHandle);
        }
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
