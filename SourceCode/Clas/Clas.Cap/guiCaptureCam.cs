/**
 * @Author: Kheir Eddine FARFAR
 * @Author Github: https://github.com/Reddine
 * @Description: Capture Images from WebCam
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.Net;
using System.IO;
using DevExpress.XtraEditors.Controls;

namespace Clas.Cap
{
    public partial class guiCaptureCam : Form
    {
        FilterInfoCollection videoDevices;
        public List<ImageInfo> Images;
        public guiCaptureCam()
        {
            InitializeComponent();

            // show device list
            try
            {
                // enumerate video devices
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                // add all devices to combo
                foreach (FilterInfo device in videoDevices)
                {
                    devicesCombo.Items.Add(device.Name);
                }
                if (videoDevices.Count > 0)
                    devicesCombo.SelectedIndex = 0;
                InitPatternGridCols();
                Images = new List<ImageInfo>();
                gdcImages.DataSource = Images;
                gdcImages.RefreshDataSource();
            }
            catch (ApplicationException)
            {
                devicesCombo.Text = "Không có camera";
                devicesCombo.Enabled = false;
                takePictureBtn.Enabled = false;
            }
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            this.KeyPreview = true;
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                Ok();
            }
        }

        private void takePictureBtn_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;              // Use current time
            string format = "MMM ddd d HH mm yyyy";    // Use this format
            String strFilename = "Capture-" + time.ToString(format) + ".jpg";
            if (videoSourcePlayer.IsRunning)
            {
                Images.Add(new ImageInfo()
                {
                    Name = strFilename,
                    Img = (Image)videoSourcePlayer.GetCurrentVideoFrame().Clone()

                });
                gdcImages.RefreshDataSource();
            }
        }
        private void InitPatternGridCols()
        {
            grvImages.OptionsView.RowAutoHeight = true;
            grvImages.OptionsBehavior.Editable = true;
            grvImages.OptionsView.ShowGroupPanel = false;
            grvImages.OptionsSelection.EnableAppearanceFocusedCell = false;
            grvImages.OptionsSelection.EnableAppearanceFocusedRow = true;

            var col = grvImages.Columns.AddField("Img");
            col.VisibleIndex = 0;
            col.Caption = "Hình";
            var edit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            edit.CustomHeight = 80;
            edit.SizeMode = PictureSizeMode.Zoom;
            col.ColumnEdit = edit;
            col.OptionsColumn.AllowEdit = false;

            col = grvImages.Columns.AddField("Name");
            col.VisibleIndex = 1;
            col.Caption = "Tên";
            col.OptionsColumn.AllowEdit = false;

            this.gdcImages.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gdcImages_KeyUp);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitCam();
        }
        private void ExitCam()
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                videoSourcePlayer.VideoSource.SignalToStop();
                videoSourcePlayer.VideoSource.WaitForStop();
            }
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();
            videoSourcePlayer.Dispose();
            videoSourcePlayer = null;
            videoDevices = null;
        }
        private void devicesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                videoSourcePlayer.VideoSource.SignalToStop();
                videoSourcePlayer.VideoSource.WaitForStop();
            }
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();
            VideoCaptureDevice videoCaptureSource = new VideoCaptureDevice(videoDevices[devicesCombo.SelectedIndex].MonikerString);
            videoSourcePlayer.VideoSource = videoCaptureSource;
            videoSourcePlayer.Start();
        }
        public void Ok()
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //ExitCam();
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void gdcImages_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var img = grvImages.GetFocusedRow() as ImageInfo;
                if (img != null)
                {
                    Images.Remove(img);
                    gdcImages.RefreshDataSource();
                }
            }
        }
    }

    public class ImageInfo
    {
        public string Name { get; set; }
        public Image Img { get; set; }
    }
}
