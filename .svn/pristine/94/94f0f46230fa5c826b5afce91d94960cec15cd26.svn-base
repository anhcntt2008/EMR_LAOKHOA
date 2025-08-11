// Copyright 2000-2021, signotec GmbH, Ratingen, Germany, All Rights Reserved
// signotec GmbH
// Am Gierath 20b
// 40885 Ratingen
// Tel: +49 (2102) 5 35 75-10
// Fax: +49 (2102) 5 35 75-39
// E-Mail: <info@signotec.de>
//
//-----------------------------------------------------------------------------
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
//
//   * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//   * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//   * Neither the name of the signotec GmbH nor the names of its contributors
//     may be used to endorse or promote products derived from this software
//     without specific prior written permission.
//
// THIS SOFTWARE ONLY DEMONSTRATES HOW TO IMPLEMENT SIGNOTEC SOFTWARE COMPONENTS
// AND IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY
// EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
// IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
// OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
// OF THE POSSIBILITY OF SUCH DAMAGE.
//-----------------------------------------------------------------------------
//
// Version: 8.5.2.3
// Date:    2021-06-15

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using BOSLib;
using signotec.STPadLibNet;

namespace Emr.SignPad
{
    public partial class MainWindow : Form
    {

        private enum ProcessState
        {
            Start = 0,
            Terms,
            Capturing,
            Stopped
        };

        private STPadLib _stPad = new STPadLib();
        private SignPad[] _signPads = null;
        private DisplayTarget _storeIdSigning = DisplayTarget.NewStandardStore;
        private DisplayTarget _storeIdOverlay = DisplayTarget.NewStandardStore;
        private int _buttonCancelId = -1;
        private int _buttonRetryId = -1;
        private int _buttonConfirmId = -1;
        private string _disclaimer { get; set; } = "With my signature, I certify that I'm excited about the signotec LCD Signature Pad and the signotec Pad Capture Control. This demo application has blown me away and I can't wait to integrate all these great features in my own application.";
        private const string _csText = "What you see is what you sign!\nThe hash of this image has been computed inside of the pad and will be digitally signed after capturing. The display content cannot be changed until the signature has been confirmed.";
        private bool _buttonScrolling = false;
        private ProcessState _processState = ProcessState.Start;
        private RSAOptions _rsaOptions = new RSAOptions();
        private ImageOptions _imageOptions = null;
        private SearchConfig _searchConfig = null;
        private CaptureWindow _captureWindow = null;
        private PadServiceMessageBox _padServiceMessageBox = null;
        private const int _keypadHotspotIndex_Clicked = -1;
        private const int _keypadHotspotIndex_CacheFull = -2;
        private const string _keypadTextboxText_Default = "Keypad - Entries";
        private const string _keypadTextboxText_Unavailable = "Keypad not supported";
        private const string _keypadButtonText_Default = "Start Keypad-Demo";
        private const string _keypadButtonText_ModeActive = "Get Keypad-Entries";
        private string _keypadWarningWindow_CacheFull;
        private bool _keypadModeActive = false;
        private int _keypadTextPosX;
        private int _keypadTextPosY;
        private int _keypadTextWidth;
        private int _keypadTextHeight;
        private string _lastButtonState = "Active";
        private SecureString _decCertPassword = new SecureString();

        //-----------------------------------------------------------------------------
        private readonly List<SignerNameDto> _listName;
        private readonly SignerNameDto _defaultSigner;
        private readonly string _contentHash;
        public int _width { get; private set; }
        public int _heigth { get; private set; }
        public string SelectedName { get; private set; }
        public Image Signature { get; private set; }
        public SignerNameDto SelectedSigner { get; private set; }
        public MainWindow(STPadLib stPad, string contentHash, List<SignerNameDto> listName, SignerNameDto defaultSigner, bool alternativeSign, int width, int height, string termsMessage)
        {
            InitializeComponent();
            _stPad = stPad;
            _contentHash = contentHash;
            _width = width;
            _heigth = height;
            _listName = listName;
            _defaultSigner = defaultSigner;
            _disclaimer = termsMessage;
            //chkAltSign.Enabled = alternativeSign;

            // scale fonts if screen resolution is not 96 dpi
            Graphics graphics = this.CreateGraphics();
            if (graphics.DpiX != 96F)
                this.Font = new Font(this.Font.FontFamily, this.Font.Size * 96F / graphics.DpiX, this.Font.Style, this.Font.Unit, this.Font.GdiCharSet, this.Font.GdiVerticalFont);
            graphics.Dispose();

            // get list of installed fonts
            FontFamily[] fonts = FontFamily.Families;
            foreach (FontFamily font in fonts)
                ComboBoxFontList.Items.Add(font.Name);

            // set default indices for combo boxes
            ComboBoxFontList.SelectedIndex = ComboBoxFontList.Items.IndexOf("Arial");
            ComboBoxPenWidthControl.SelectedIndex = 0;
            ComboBoxMirror.SelectedIndex = (int)MirrorMode.EverythingActiveHotSpots;
            ComboBoxTimeout.SelectedIndex = (int)TimerOption.CallEvent;
            ComboBoxDisplayPenWidth.SelectedIndex = 1;
            ComboBoxBacklight.SelectedIndex = (int)BacklightMode.On;
            ComboBoxRotation.SelectedIndex = 0;
            ComboBoxTextAlign.SelectedIndex = (int)TextAlignment.Left;
            ComboBoxTextRect.SelectedIndex = 0;
            ComboBoxSource.SelectedIndex = 0;
            ComboBoxTarget.SelectedIndex = (int)DisplayTarget.ForegroundBuffer;
            ComboBoxImage.SelectedIndex = 0;
            ComboBoxPDF.SelectedIndex = 0;
            ComboBoxUnit.SelectedIndex = 0;
            ComboBoxSampleRate.SelectedIndex = (int)SampleRate.Hz250;
            ComboBoxDisplayFileFormat.SelectedIndex = 0;
            ComboBoxFileFormat.SelectedIndex = 0;
            ComboBoxSignData.SelectedIndex = 0;
            ComboBoxHotspotType.SelectedIndex = 0;

            // register events
            _stPad.DeviceDisconnected += new DeviceDisconnectedEventHandler(STPad_DeviceDisconnected);
            _stPad.SensorHotSpotPressed += new SensorHotSpotPressedEventHandler(STPad_SensorHotSpotPressed);
            _stPad.SensorTimeoutOccured += new SensorTimeoutOccuredEventHandler(STPad_SensorTimeoutOccured);
            _stPad.DisplayScrollPosChanged += new DisplayScrollPosChangedEventHandler(STPad_DisplayScrollPosChanged);
            _stPad.SignatureDataReceived += new SignatureDataReceivedEventHandler(STPad_SignatureDataReceived);

            // set app name
            _stPad.ControlAppName = "Ký điện tử";
            stPadLibControl1.ControlSetSTPadLib(_stPad);

            // get control version
            GroupBoxMain.Text = String.Format("Ký điện tử phiên bản: {0}", _stPad.ControlVersion);

            // get connected devices and open first one if any
            GetDevices();
            if (_signPads != null)
            {
                OpenDevice();
                StartCancel();
            }
        }

        //------------------------------------------------------------------------------------
        #region "Devices"

        private void ButtonDevCount_Click(object sender, EventArgs e)
        {
            GetDevices();
        }

        private void GetDevices()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // get number of connected devices
                int deviceCount = _stPad.DeviceGetCount();

                // erase all entries
                ListOfDevices.Items.Clear();

                // build list
                if (deviceCount <= 0)
                {   // no devices detected
                    _signPads = null;
                    ListOfDevices.Items.Add("No Devices");
                    ListOfDevices.Items.Add("detected");
                    ListOfDevices.Enabled = false;
                    ButtonOpenClose.Text = "Open";
                    ButtonOpenClose.Enabled = false;
                    ButtonClearDisplay.Enabled = false;
                    ButtonStartCancel.Enabled = false;
                    ButtonRetry.Enabled = false;
                    ButtonStop.Enabled = false;
                    ButtonConfirm.Enabled = false;
                    ButtonSettings.Enabled = true;
                    ImagePad.Image = Emr.SignPad.Properties.Resources.Welcome;
                    ImagePad.Visible = true;
                    ImageLed.Visible = false;
                    ImageLcd.Visible = false;
                    stPadLibControl1.Visible = false;
                    LabelType.Text = "Type: -";
                    LabelPort.Text = "Port: -";
                    LabelFirmware.Text = "Firmware: -";
                    LabelSerial.Text = "Serial: -";
                    LabelDisplay.Text = "Display: -";
                }
                else
                {   // build device list
                    _signPads = new SignPad[deviceCount];
                    for (int i = 0; i < deviceCount; i++)
                    {
                        _signPads[i] = new SignPad(_stPad, i);
                        ListOfDevices.Items.Add(String.Format("Device {0}", i + 1));
                    }
                    ListOfDevices.Enabled = true;

                    // select first element of list
                    if (deviceCount > 0)
                        ListOfDevices.SetSelected(0, true);
                }
                GroupBoxSignature.Enabled = false;
                GroupBoxSignData.Enabled = false;
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            this.Cursor = Cursors.Default;
        }

        private void ButtonSearchConfig_Click(object sender, EventArgs e)
        {
            if (_searchConfig == null)
                _searchConfig = new SearchConfig();
            _searchConfig.ShowDialog();
            LabelSearchConfig.Text = "\"Get Devices\" searches for:";
            if (_searchConfig.USB)
                LabelSearchConfig.Text += "\n- USB Devices";
            if (_searchConfig.Serial)
                LabelSearchConfig.Text += "\n- Serial Devices";
            if (_searchConfig.IP1 || _searchConfig.IP2 || _searchConfig.IP3 || _searchConfig.IP4)
                LabelSearchConfig.Text += "\n- IP Devices";

            try
            {
                int count = _stPad.DeviceSetComPort(_searchConfig.SearchList);
                if (count != _searchConfig.Count)
                    MessageBox.Show(String.Format("{0} ports have been selected but only {1} ports could be configured!", _searchConfig.Count, count), Application.ProductName);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void ListOfDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListOfDevices.SelectedIndex < 0)
                return;

            LabelType.Text = "Type: " + _signPads[ListOfDevices.SelectedIndex].PadName;
            try
            {
                switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                {
                    case PadModel.Sigma:
                        ImagePad.Image = Emr.SignPad.Properties.Resources.Pad_Sigma;
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Yellow;
                        ImageLed.Location = new Point(115, 487);
                        ImageLcd.Image = Emr.SignPad.Properties.Resources.Logo_Sigma;
                        ImageLcd.Location = new Point(109, 274);
                        ImageLcd.Size = new Size(320, 160);
                        break;
                    case PadModel.Zeta:
                        ImagePad.Image = Emr.SignPad.Properties.Resources.Pad_Zeta;
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Yellow_Gamma;
                        ImageLed.Location = new Point(91, 575);
                        ImageLcd.Image = Emr.SignPad.Properties.Resources.Logo_Zeta;
                        ImageLcd.Location = new Point(107, 287);
                        ImageLcd.Size = new Size(320, 200);
                        break;
                    case PadModel.Omega:
                        ImagePad.Image = Emr.SignPad.Properties.Resources.Pad_Omega;
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Yellow;
                        ImageLed.Location = new Point(111, 561);
                        ImageLcd.Image = Emr.SignPad.Properties.Resources.Logo_Omega;
                        ImageLcd.Location = new Point(97, 265);
                        ImageLcd.Size = new Size(344, 258);
                        break;
                    case PadModel.Gamma:
                        ImagePad.Image = Emr.SignPad.Properties.Resources.Pad_Gamma;
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Yellow_Gamma;
                        ImageLed.Location = new Point(66, 578);
                        ImageLcd.Image = Emr.SignPad.Properties.Resources.Logo_Gamma;
                        ImageLcd.Location = new Point(68, 292);
                        ImageLcd.Size = new Size(398, 239);
                        break;
                    case PadModel.Delta:
                        ImagePad.Image = Emr.SignPad.Properties.Resources.Pad_Delta;
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Yellow_Delta;
                        ImageLed.Location = new Point(467, 240);
                        ImageLcd.Image = Emr.SignPad.Properties.Resources.Logo_Delta;
                        ImageLcd.Location = new Point(46, 257);
                        ImageLcd.Size = new Size(445, 278);
                        break;
                    case PadModel.Alpha:
                        ImagePad.Image = Emr.SignPad.Properties.Resources.Pad_Alpha;
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Yellow;
                        ImageLed.Location = new Point(160, 198);
                        ImageLcd.Image = Emr.SignPad.Properties.Resources.Logo_Alpha;
                        ImageLcd.Location = new Point(160, 220);
                        ImageLcd.Size = new Size(205, 365);
                        break;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
                return;
            }
            stPadLibControl1.Location = ImageLcd.Location;
            stPadLibControl1.Size = ImageLcd.Size;
            LabelSignatureData.Location = stPadLibControl1.Location;
            LabelSignatureData.Size = stPadLibControl1.Size;
            ImagePad.Visible = true;
            ImageLed.Visible = true;
            ImageLcd.Visible = true;
            stPadLibControl1.Visible = false;

            if (_signPads[ListOfDevices.SelectedIndex].HasNFCReader)
            {
                CheckBoxNFC.Enabled = true;
                CheckBoxNFCPerm.Enabled = true;
                GroupBoxPadService.Enabled = true;
                try
                {
                    CheckBoxNFC.Checked = (_stPad.DeviceGetNFCMode(ListOfDevices.SelectedIndex) == NFCMode.On);
                }
                catch (STPadException exc)
                {
                    MessageBox.Show(exc.Message, Application.ProductName);
                    CheckBoxNFC.Checked = false;
                }
            }
            else
            {
                CheckBoxNFC.Enabled = false;
                CheckBoxNFCPerm.Enabled = false;
                GroupBoxPadService.Enabled = false;
                CheckBoxNFC.Checked = false;
            }
            CheckBoxNFCPerm.Checked = false;
            ButtonService.Enabled = false;
            ButtonAdjustment.Enabled = false;

            CheckBoxPenScrolling.Enabled = _signPads[ListOfDevices.SelectedIndex].SupportsPenScrolling;

            string currentSelection = ComboBoxHotspotType.Text;
            ComboBoxHotspotType.Items.Clear();
            List<String> types = new List<string>();
            types.Add("Standard");
            if (_signPads[ListOfDevices.SelectedIndex].SupportsVerticalScrolling)
            {
                types.Add("Scroll Down");
                types.Add("Scroll Up");
            }
            if (_signPads[ListOfDevices.SelectedIndex].SupportsHorizontalScrolling)
            {
                types.Add("Scroll Right");
                types.Add("Scroll Left");
            }
            if (_signPads[ListOfDevices.SelectedIndex].SupportsPenScrolling)
                types.Add("Scrollable");
            if (_signPads[ListOfDevices.SelectedIndex].SupportsKeypad)
                types.Add("Keypad");
            types.Add("Clear All");
            ComboBoxHotspotType.Items.AddRange(types.ToArray());
            if (ComboBoxHotspotType.Items.Contains(currentSelection))
                ComboBoxHotspotType.SelectedIndex = ComboBoxHotspotType.Items.IndexOf(currentSelection);
            else
                ComboBoxHotspotType.SelectedIndex = 0;
            if (ComboBoxHotspotType.Text.Equals("Clear All"))
                ButtonSetHotSpot.Text = "Clear";
            else
                ButtonSetHotSpot.Text = "Add";

            TextBoxFontSize.Text = String.Format("{0}", _signPads[ListOfDevices.SelectedIndex].DefaultFontSize);
            LabelFontColor.Enabled = _signPads[ListOfDevices.SelectedIndex].HasColorDisplay;
            ButtonFontColor.Enabled = _signPads[ListOfDevices.SelectedIndex].HasColorDisplay;
            ButtonDisplayPenColor.Enabled = _signPads[ListOfDevices.SelectedIndex].HasColorDisplay;
            if (_signPads[ListOfDevices.SelectedIndex].HasColorDisplay)
                ButtonDisplayPenColor.BackColor = Color.Blue;
            else
                ButtonDisplayPenColor.BackColor = Color.Black;
            ComboBoxDisplayPenWidth.SelectedIndex = _signPads[ListOfDevices.SelectedIndex].DefaultPenWidth;
            LabelCapturedPoints.Top = ImageLcd.Top + ImageLcd.Height + 3;

            // print serial
            LabelSerial.Text = string.Format("Serial: {0}", _signPads[ListOfDevices.SelectedIndex].Serial);

            // get port number / IP address
            try
            {
                LabelPort.Text = string.Format("Port: {0}", _signPads[ListOfDevices.SelectedIndex].ConnectionName);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            // print firmware version
            LabelFirmware.Text = String.Format("Firmware: {0}", _signPads[ListOfDevices.SelectedIndex].Firmware);

            // enable "Open" button for selected device
            ButtonOpenClose.Enabled = true;
            ButtonOpenClose.Text = String.Format("Open Device {0}", ListOfDevices.SelectedIndex + 1);

            LabelDisplay.Text = "Display: -";

            buttonKeypadDemo.Text = _keypadButtonText_Default;
            if (_signPads[ListOfDevices.SelectedIndex].SupportsKeypad)
                textBoxKeypadEntries.Text = _keypadTextboxText_Default;
            else
                textBoxKeypadEntries.Text = _keypadTextboxText_Unavailable;
        }

        private void ButtonOpenClose_Click(object sender, EventArgs e)
        {
            if (ListOfDevices.SelectedIndex < 0)
                return;

            if (ButtonOpenClose.Text == String.Format("Open Device {0}", ListOfDevices.SelectedIndex + 1))
                OpenDevice();
            else
                CloseDevice();

            ButtonSettings.Enabled = true;
            GroupBoxSignature.Enabled = false;
            GroupBoxSignData.Enabled = false;
            LabelCapturedPoints.Visible = false;
            _processState = ProcessState.Start;
        }

        private void OpenDevice()
        {
            // check if model type is supported
            try
            {
                PadModel model = _signPads[ListOfDevices.SelectedIndex].PadModel;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                // open device
                try
                {
                    _signPads[ListOfDevices.SelectedIndex].DeviceOpen();
                }
                catch (STPadException exc)
                {
                    _signPads[ListOfDevices.SelectedIndex].DeviceClose();
                    MessageBox.Show($"Thiết bị đang mở lại, vì nguyên nhân {exc}", Application.ProductName);
                    OpenDevice();
                    //return;
                }

                _storeIdSigning = DisplayTarget.NewStandardStore;
                _storeIdOverlay = DisplayTarget.NewStandardStore;
                ImageLcd.Visible = false;
                stPadLibControl1.Visible = true;
                ButtonOpenClose.Text = String.Format("Close Device {0}", ListOfDevices.SelectedIndex + 1);
                ButtonSearchConfig.Enabled = false;
                ButtonDevCount.Enabled = false;
                ButtonClearDisplay.Enabled = true;
                ButtonStartCancel.Enabled = true;
                _buttonCancelId = -1;
                ButtonRetry.Enabled = false;
                _buttonRetryId = -1;
                ButtonStop.Enabled = false;
                ButtonConfirm.Enabled = false;
                _buttonConfirmId = -1;
                ListOfDevices.Enabled = false;
                GroupBoxTimeouts.Enabled = true;
                CheckBoxLedG.Enabled = true;
                CheckBoxLedY.Enabled = true;
                GroupBoxSensor.Enabled = true;
                GroupBoxDisplayImage.Enabled = true;
                GroupBoxDisplay.Enabled = true;
                ComboBoxBacklight.Enabled = _signPads[ListOfDevices.SelectedIndex].HasBacklight;
                LabelBacklight.Enabled = _signPads[ListOfDevices.SelectedIndex].HasBacklight;
                GroupBoxPadService.Enabled = true;
                ButtonService.Enabled = _signPads[ListOfDevices.SelectedIndex].SupportsServiceMenu;
                ButtonAdjustment.Enabled = true;
                GroupBoxDrawing.Enabled = true;
                _keypadModeActive = false;
                StandbyImageTimeoutDialog();
                if (ButtonSettings.Text.Equals("Advanced Settings"))
                    GroupBoxKeypadDemo.Enabled = _signPads[ListOfDevices.SelectedIndex].SupportsKeypad;
                buttonKeypadDemo.Text = _keypadButtonText_Default;
                try
                {
                    SetTarget((DisplayTarget)ComboBoxTarget.SelectedIndex);
                }
                catch { }
                if (_stPad.DisplayTargetHeight - _stPad.DisplayHeight > 0)
                {
                    TextBoxScrollX.Enabled = _signPads[ListOfDevices.SelectedIndex].SupportsHorizontalScrolling;
                    TextBoxScrollY.Enabled = _signPads[ListOfDevices.SelectedIndex].SupportsVerticalScrolling;
                    int currentXPos;
                    int currentYPos;
                    try
                    {
                        _stPad.DisplayGetScrollPos(out currentXPos, out currentYPos);
                        TextBoxScrollX.Text = String.Format("{0}", currentXPos);
                        TextBoxScrollY.Text = String.Format("{0}", currentYPos);
                    }
                    catch { }
                }
                _rsaOptions.InitControls(this);

                // set custom settings
                stPadLibControl1.ControlMirrorDisplay = (MirrorMode)ComboBoxMirror.SelectedIndex;
                SetFont();

                // set pen width and color
                if (!DisplayConfigPen())
                {
                    CloseDevice();
                    return;
                }

                // get sample rate
                SampleRate sampleRate = _stPad.SensorGetSampleRateMode();
                ComboBoxSampleRate.SelectedIndex = (int)sampleRate;

                // print display size & resolution
                LabelDisplay.Text = String.Format("Display: {0} x {1} px / {2} ppi", _stPad.DisplayWidth, _stPad.DisplayHeight, Math.Round(_stPad.DisplayResolution));
                LabelTargetSize.Text = String.Format("Target Size: {0} x {1} px", _stPad.DisplayTargetWidth, _stPad.DisplayTargetHeight);

                TextBoxSensorWidth.Text = String.Format("{0}", _stPad.DisplayWidth - Int32.Parse(TextBoxSensorX.Text));
                TextBoxSensorHeight.Text = String.Format("{0}", _stPad.DisplayHeight - Int32.Parse(TextBoxSensorY.Text));
                CheckBoxPenScrolling.Checked = false;
                TextBoxDrawWidth.Text = String.Format("{0}", _stPad.DisplayWidth - Int32.Parse(TextBoxDrawX.Text));
                TextBoxDrawHeight.Text = String.Format("{0}", _stPad.DisplayHeight - Int32.Parse(TextBoxDrawY.Text));
                TextBoxSelectWidth.Text = String.Format("{0}", _stPad.DisplayWidth - Int32.Parse(TextBoxSelectX.Text));
                TextBoxSelectHeight.Text = String.Format("{0}", _stPad.DisplayHeight - Int32.Parse(TextBoxSelectY.Text));

                // update dimensions of loaded PDF (if any)
                GetDimension();

                if (_signPads[ListOfDevices.SelectedIndex].SupportsKeypad32)
                    _keypadWarningWindow_CacheFull = "Keypad Cache is already full ( 32 / 32 ).\n(At least one) entry is lost.";
                else
                    _keypadWarningWindow_CacheFull = "Keypad Cache is already full ( 8 / 8 ).\n(At least one) entry is lost.";
            }
            catch (STPadException exc)
            {
                CloseDevice();
                MessageBox.Show(exc.Message, Application.ProductName);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CloseDevice()
        {
            this.Cursor = Cursors.WaitCursor;

            // cancel signature process
            CancelProcess(true);

            // close device
            try
            {
                _signPads[ListOfDevices.SelectedIndex].DeviceClose();
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            ResetAfterClose();

            try
            {
                ClearHotSpots();
            }
            catch { }

            this.Cursor = Cursors.Default;
        }

        private void ResetAfterClose()
        {
            ButtonOpenClose.Text = String.Format("Open Device {0}", ListOfDevices.SelectedIndex + 1);
            ButtonSearchConfig.Enabled = true;
            ButtonDevCount.Enabled = true;
            ListOfDevices.Enabled = true;
            CheckBoxLedG.Enabled = false;
            CheckBoxLedY.Enabled = false;
            GroupBoxTimeouts.Enabled = false;
            GroupBoxSensor.Enabled = false;
            GroupBoxDisplay.Enabled = false;
            GroupBoxDisplayImage.Enabled = false;
            GroupBoxDrawing.Enabled = false;
            ButtonStartCancel.Text = "Start";
            ButtonStartCancel.Enabled = false;
            ButtonRetry.Enabled = false;
            ButtonStop.Enabled = false;
            ButtonConfirm.Enabled = false;
            ButtonClearDisplay.Enabled = false;
            _rsaOptions.InitControls(this);
            stPadLibControl1.Visible = false;
            ButtonService.Enabled = false;
            ButtonAdjustment.Enabled = false;
            GroupBoxKeypadDemo.Enabled = false;
            _keypadModeActive = false;
            if (_signPads != null)
            {
                GroupBoxPadService.Enabled = _signPads[ListOfDevices.SelectedIndex].HasNFCReader;
                if (_signPads[ListOfDevices.SelectedIndex].SupportsKeypad)
                {
                    textBoxKeypadEntries.Text = _keypadTextboxText_Default;
                    buttonKeypadDemo.Text = _keypadButtonText_Default;
                }
            }
            try
            {
                switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                {
                    case PadModel.Sigma:
                        ImageLcd.Image = Emr.SignPad.Properties.Resources.Logo_Sigma;
                        break;
                    case PadModel.Zeta:
                        ImageLcd.Image = Emr.SignPad.Properties.Resources.Logo_Zeta;
                        break;
                    case PadModel.Omega:
                        ImageLcd.Image = Emr.SignPad.Properties.Resources.Logo_Omega;
                        break;
                    case PadModel.Gamma:
                        ImageLcd.Image = Emr.SignPad.Properties.Resources.Logo_Gamma;
                        break;
                    case PadModel.Delta:
                        ImageLcd.Image = Emr.SignPad.Properties.Resources.Logo_Delta;
                        break;
                    case PadModel.Alpha:
                        ImageLcd.Image = Emr.SignPad.Properties.Resources.Logo_Alpha;
                        break;
                }
            }
            catch { }
            ImageLcd.Visible = true;
            CheckBoxLedY.CheckState = CheckState.Checked;
            CheckBoxLedG.CheckState = CheckState.Unchecked;
            if (ComboBoxSource.SelectedIndex > 6)
                ComboBoxSource.SelectedIndex = 0;
            while (ComboBoxSource.Items.Count > 7)
                ComboBoxSource.Items.RemoveAt(ComboBoxSource.Items.Count - 1);
            if (ComboBoxTarget.SelectedIndex > 5)
                ComboBoxTarget.SelectedIndex = 0;
            while (ComboBoxTarget.Items.Count > 6)
                ComboBoxTarget.Items.RemoveAt(ComboBoxTarget.Items.Count - 1);
            LabelTargetSize.Text = "Target Size: -";
            TextBoxScrollX.Enabled = false;
            TextBoxScrollY.Enabled = false;
        }

        private void ButtonClearDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                // erase LCD
                _stPad.DisplayErase();

                GroupBoxSignature.Enabled = false;
                GroupBoxSignData.Enabled = false;
                ImageLcd.Visible = false;
                stPadLibControl1.Visible = true;
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            try
            {
                // erase LCD
                _stPad.DisplayErase();
            }
            catch { }

            try
            {
                // clear hot spots
                ClearHotSpots();
            }
            catch { }

            GroupBoxSignature.Enabled = false;
            GroupBoxSignData.Enabled = false;

            // resize and set button text
            if (this.Width != 1125)
            {
                this.Width = 1125;
                ButtonSettings.Text = "Default Settings";
                stPadLibControl1.ControlMirrorDisplay = (MirrorMode)ComboBoxMirror.SelectedIndex;
                if ((_signPads != null) && (_signPads[ListOfDevices.SelectedIndex].SupportsKeypad))
                {
                    GroupBoxKeypadDemo.Enabled = false;
                    textBoxKeypadEntries.Text = _keypadTextboxText_Default;
                }
            }
            else
            {
                this.Width = 697;
                ButtonSettings.Text = "Advanced Settings";
                if ((_signPads != null) && (_signPads[ListOfDevices.SelectedIndex].SupportsKeypad))
                {
                    GroupBoxKeypadDemo.Enabled = true;
                    textBoxKeypadEntries.Text = _keypadTextboxText_Default;
                }
            }
        }

        private void TextBoxScrollSpeed_TextChanged(object sender, EventArgs e)
        {
            if ((ListOfDevices.SelectedIndex < 0) || !_signPads[ListOfDevices.SelectedIndex].Open)
                return;

            if (!TextBoxScrollSpeed.Text.Equals(""))
            {
                try
                {
                    _stPad.DisplayScrollSpeed = int.Parse(TextBoxScrollSpeed.Text);
                }
                catch (STPadException exc)
                {
                    MessageBox.Show(exc.Message, Application.ProductName);
                }
            }
        }

        private void ButtonAdjustment_Click(object sender, EventArgs e)
        {
            try
            {
                _stPad.DeviceStartService(1);
                MessageBox.Show("With two steps through the Pad Adjustment!\r\nFirst step: Please click with the pad pen by the cross in the left upper corner on the screen of the pad.\r\nSecond step: Please click with the pen ped by the cross in right lower corner on the screen of the pad.", "Pad Adjustment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void ButtonService_Click(object sender, EventArgs e)
        {
            try
            {
                _stPad.DeviceStartService(0);
                _padServiceMessageBox = new PadServiceMessageBox();
                _padServiceMessageBox.ShowDialog(this);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void CheckBoxNFC_Click(object sender, EventArgs e)
        {
            if (_signPads[ListOfDevices.SelectedIndex].HasNFCReader)
            {
                try
                {
                    NFCMode mode = (NFCMode)((CheckBoxNFC.Checked ? 1 : 0) + (CheckBoxNFCPerm.Checked ? 2 : 0));
                    _stPad.DeviceSetNFCMode(mode, ListOfDevices.SelectedIndex);
                }
                catch (STPadException exc)
                {
                    MessageBox.Show(exc.Message, Application.ProductName);
                    CheckBoxNFC.Checked = !CheckBoxNFC.Checked;
                }
            }
        }

        public SignPad SignPad
        {
            get
            {
                if (ListOfDevices.SelectedIndex < 0)
                    return new SignPad();
                else
                    return _signPads[ListOfDevices.SelectedIndex];
            }
        }

        private void ButtonKeypadDemo_Click(object sender, EventArgs e)
        {
            // secured keypad button demonstration
            if (_keypadModeActive)
            {
                KeypadGetEntries(0);
                KeypadModeEndDefaults();
            }
            else
            {
                KeypadModeStartDefaults();
                try
                {
                    Bitmap[] buttonList = new Bitmap[14];
                    if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Omega)
                    {
                        buttonList[0] = Emr.SignPad.Properties.Resources.Keypad0_color_omega;
                        buttonList[1] = Emr.SignPad.Properties.Resources.Keypad1_color_omega;
                        buttonList[2] = Emr.SignPad.Properties.Resources.Keypad2_color_omega;
                        buttonList[3] = Emr.SignPad.Properties.Resources.Keypad3_color_omega;
                        buttonList[4] = Emr.SignPad.Properties.Resources.Keypad4_color_omega;
                        buttonList[5] = Emr.SignPad.Properties.Resources.Keypad5_color_omega;
                        buttonList[6] = Emr.SignPad.Properties.Resources.Keypad6_color_omega;
                        buttonList[7] = Emr.SignPad.Properties.Resources.Keypad7_color_omega;
                        buttonList[8] = Emr.SignPad.Properties.Resources.Keypad8_color_omega;
                        buttonList[9] = Emr.SignPad.Properties.Resources.Keypad9_color_omega;
                        buttonList[10] = Emr.SignPad.Properties.Resources.KeypadCancel_color_omega;
                        buttonList[11] = Emr.SignPad.Properties.Resources.KeypadRetry_color_omega;
                        buttonList[12] = Emr.SignPad.Properties.Resources.KeypadConfirm_color_omega;
                        buttonList[13] = Emr.SignPad.Properties.Resources.KeypadEntrymask_color_gamma;
                    }
                    else if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Gamma)
                    {

                        buttonList[0] = Emr.SignPad.Properties.Resources.Keypad0_color_omega;
                        buttonList[1] = Emr.SignPad.Properties.Resources.Keypad1_color_omega;
                        buttonList[2] = Emr.SignPad.Properties.Resources.Keypad2_color_omega;
                        buttonList[3] = Emr.SignPad.Properties.Resources.Keypad3_color_omega;
                        buttonList[4] = Emr.SignPad.Properties.Resources.Keypad4_color_omega;
                        buttonList[5] = Emr.SignPad.Properties.Resources.Keypad5_color_omega;
                        buttonList[6] = Emr.SignPad.Properties.Resources.Keypad6_color_omega;
                        buttonList[7] = Emr.SignPad.Properties.Resources.Keypad7_color_omega;
                        buttonList[8] = Emr.SignPad.Properties.Resources.Keypad8_color_omega;
                        buttonList[9] = Emr.SignPad.Properties.Resources.Keypad9_color_omega;
                        buttonList[10] = Emr.SignPad.Properties.Resources.KeypadCancel_color_omega;
                        buttonList[11] = Emr.SignPad.Properties.Resources.KeypadRetry_color_omega;
                        buttonList[12] = Emr.SignPad.Properties.Resources.KeypadConfirm_color_omega;
                        buttonList[13] = Emr.SignPad.Properties.Resources.KeypadEntrymask_color_gamma;
                    }
                    else if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Delta)
                    {
                        buttonList[0] = Emr.SignPad.Properties.Resources.Keypad0_color_omega;
                        buttonList[1] = Emr.SignPad.Properties.Resources.Keypad1_color_omega;
                        buttonList[2] = Emr.SignPad.Properties.Resources.Keypad2_color_omega;
                        buttonList[3] = Emr.SignPad.Properties.Resources.Keypad3_color_omega;
                        buttonList[4] = Emr.SignPad.Properties.Resources.Keypad4_color_omega;
                        buttonList[5] = Emr.SignPad.Properties.Resources.Keypad5_color_omega;
                        buttonList[6] = Emr.SignPad.Properties.Resources.Keypad6_color_omega;
                        buttonList[7] = Emr.SignPad.Properties.Resources.Keypad7_color_omega;
                        buttonList[8] = Emr.SignPad.Properties.Resources.Keypad8_color_omega;
                        buttonList[9] = Emr.SignPad.Properties.Resources.Keypad9_color_omega;
                        buttonList[10] = Emr.SignPad.Properties.Resources.KeypadCancel_color_omega;
                        buttonList[11] = Emr.SignPad.Properties.Resources.KeypadRetry_color_omega;
                        buttonList[12] = Emr.SignPad.Properties.Resources.KeypadConfirm_color_omega;
                        buttonList[13] = Emr.SignPad.Properties.Resources.KeypadEntrymask_color_gamma;
                    }
                    else // sigma and unknown
                    {
                        buttonList[0] = Emr.SignPad.Properties.Resources.Keypad0_bw;
                        buttonList[1] = Emr.SignPad.Properties.Resources.Keypad1_bw;
                        buttonList[2] = Emr.SignPad.Properties.Resources.Keypad2_bw;
                        buttonList[3] = Emr.SignPad.Properties.Resources.Keypad3_bw;
                        buttonList[4] = Emr.SignPad.Properties.Resources.Keypad4_bw;
                        buttonList[5] = Emr.SignPad.Properties.Resources.Keypad5_bw;
                        buttonList[6] = Emr.SignPad.Properties.Resources.Keypad6_bw;
                        buttonList[7] = Emr.SignPad.Properties.Resources.Keypad7_bw;
                        buttonList[8] = Emr.SignPad.Properties.Resources.Keypad8_bw;
                        buttonList[9] = Emr.SignPad.Properties.Resources.Keypad9_bw;
                        buttonList[10] = Emr.SignPad.Properties.Resources.Keypad9_bw;
                        buttonList[11] = Emr.SignPad.Properties.Resources.Keypad9_bw;
                        buttonList[12] = Emr.SignPad.Properties.Resources.Keypad9_bw;
                        buttonList[13] = Emr.SignPad.Properties.Resources.Keypad9_bw;
                    }

                    int buttonHeight = buttonList[0].Height;
                    int buttonWidth = buttonList[0].Width;

                    const double gapHeight = 3;
                    const double gapWidth = 3;
                    double displayHeight = _stPad.DisplayHeight;
                    double displayWidth = _stPad.DisplayWidth;

                    // list of columns (always left of the button)
                    double[] xPos = new double[]
                    {
                        ((displayWidth / 2) - ((1.5 * gapWidth) + (2 * buttonWidth))),
                        ((displayWidth / 2) - ((0.5 * gapWidth) + (1 * buttonWidth))),
                        ((displayWidth / 2) + ((0.5 * gapWidth) + (0 * buttonWidth))),
                        ((displayWidth / 2) + ((1.5 * gapWidth) + (1 * buttonWidth)))
                    };
                    // list of rows (always top of the button)
                    double[] yPos = new double[]
                    {
                        ((displayHeight / 2) - ((2 * gapHeight) + (2.5 * buttonHeight))),
                        ((displayHeight / 2) - ((1 * gapHeight) + (1.5 * buttonHeight))),
                        ((displayHeight / 2) - ((0 * gapHeight) + (0.5 * buttonHeight))),
                        ((displayHeight / 2) + ((1 * gapHeight) + (0.5 * buttonHeight))),
                        ((displayHeight / 2) + ((2 * gapHeight) + (1.5 * buttonHeight)))
                    };

                    /*
                          xPos
                         0 1 2 3
                         _|_|_|_    0
                         _|_|_|_    1   yPos
                         _|_|_|_    2
                          | | |     3
                    */

                    // create bitmaps in the background buffer
                    SetTarget(DisplayTarget.BackgroundBuffer);

                    int buttonId = 0;

                    int pixelsFromLeftSide;
                    int pixelsFromTopSide;

                    // numbers 1 - 9
                    int xPosInArray = 0;
                    int yPosInArray = 1;
                    const int runs = 10;
                    for (int i = 1; i < runs; i++)
                    {
                        pixelsFromLeftSide = (int)(xPos[xPosInArray]);
                        pixelsFromTopSide = (int)(yPos[yPosInArray]);
                        _stPad.DisplaySetImage(pixelsFromLeftSide, pixelsFromTopSide, buttonList[i]);
                        if (++xPosInArray >= xPos.Length - 1)
                        {
                            xPosInArray = 0;
                            yPosInArray++;
                        }
                    }
                    // the 0 is special as it´s position is in the middle of the numblock, with no button left of it
                    pixelsFromLeftSide = (int)xPos[1];
                    pixelsFromTopSide = (int)yPos[4];
                    _stPad.DisplaySetImage(pixelsFromLeftSide, pixelsFromTopSide, buttonList[0]);

                    // text box (entrymask) skin
                    const int tbIndex = 13;
                    _stPad.DisplaySetImage((int)xPos[0], (int)yPos[0], buttonList[tbIndex]);
                    // set text position (*) inside box, text will be centered inside later
                    int tbHeight = buttonList[tbIndex].Height;
                    const int tbSplittingRatio = 6;
                    pixelsFromLeftSide = (int)xPos[0];
                    pixelsFromTopSide = (int)yPos[0];
                    _keypadTextPosX = pixelsFromLeftSide + (tbHeight / tbSplittingRatio);
                    _keypadTextPosY = pixelsFromTopSide + (tbHeight / tbSplittingRatio);
                    _keypadTextHeight = tbHeight - ((tbHeight / tbSplittingRatio) * 2);
                    _keypadTextWidth = buttonList[tbIndex].Width - ((tbHeight / tbSplittingRatio) * 2);

                    // unencrypted control buttons: Confirm, Retry and Abort
                    // standard buttons are also allowed to be created while buffer is set to other then foreground.
                    
                    pixelsFromLeftSide = (int)xPos[3];
                    pixelsFromTopSide = (int)yPos[2];
                    buttonId = _stPad.SensorAddHotSpot(pixelsFromLeftSide, pixelsFromTopSide, buttonWidth, buttonHeight);
                    _buttonCancelId = buttonId;
                    _stPad.DisplaySetImage(pixelsFromLeftSide, pixelsFromTopSide, buttonList[10]);

                    pixelsFromLeftSide = (int)xPos[3];
                    pixelsFromTopSide = (int)yPos[3];
                    buttonId = _stPad.SensorAddHotSpot(pixelsFromLeftSide, pixelsFromTopSide, buttonWidth, buttonHeight);
                    _buttonRetryId = buttonId;
                    _stPad.DisplaySetImage(pixelsFromLeftSide, pixelsFromTopSide, buttonList[11]);

                    pixelsFromLeftSide = (int)xPos[3];
                    pixelsFromTopSide = (int)yPos[4];
                    buttonId = _stPad.SensorAddHotSpot(pixelsFromLeftSide, pixelsFromTopSide, buttonWidth, buttonHeight);
                    _buttonConfirmId = buttonId;
                    _stPad.DisplaySetImage(pixelsFromLeftSide, pixelsFromTopSide, buttonList[12]);
                    
                    // do all drawing operations on the LCD
                    SetTarget(DisplayTarget.ForegroundBuffer);

                    // draw buffered image
                    _stPad.DisplaySetImageFromStore(DisplayTarget.BackgroundBuffer);

                    // create the keypad buttons itself
                    // numbers 1 - 9
                    xPosInArray = 0;
                    yPosInArray = 1;                    
                    for (int i = 1; i < runs; i++)
                    {
                        using (SecureString keyPadName = new SecureString())
                        {
                            keyPadName.AppendChar(Convert.ToString(i)[0]);
                            pixelsFromLeftSide = (int)(xPos[xPosInArray]);
                            pixelsFromTopSide = (int)(yPos[yPosInArray]);
                            _stPad.SensorAddKeypadHotSpot(pixelsFromLeftSide, pixelsFromTopSide, buttonWidth, buttonHeight, keyPadName);
                            if (++xPosInArray >= xPos.Length - 1)
                            {
                                xPosInArray = 0;
                                yPosInArray++;
                            }
                        }
                    }
                    // the 0 is special as it´s position is in the middle of the numblock, with no button left of it
                    pixelsFromLeftSide = (int)xPos[1];
                    pixelsFromTopSide = (int)yPos[4];
                    using (SecureString keyPadName = new SecureString())
                    {
                        keyPadName.AppendChar('0');
                        _stPad.SensorAddKeypadHotSpot(pixelsFromLeftSide, pixelsFromTopSide, buttonWidth, buttonHeight, keyPadName);
                    }                    
                }
                catch (STPadException exc)
                {
                    MessageBox.Show(exc.Message, Application.ProductName);
                }
            }
        }

        private void KeypadGetEntries(int amount)
        {
            SecureString kpString;
            try
            {
                int rc = _stPad.SensorGetKeypadEntries(out kpString, amount);
                if (rc > 0)       // if the string holds minimum one entry
                {
                    string toShow = new System.Net.NetworkCredential(string.Empty, kpString).Password;
                    if (_keypadModeActive)
                        textBoxKeypadEntries.Text = toShow;
                    else
                        MessageBox.Show(toShow, "Keypad pressed: ");
                }
                else if ((rc == 0) && (_keypadModeActive)) // retry in demo shows the 0 entries
                    textBoxKeypadEntries.Text = "";
                if (kpString != null)
                    kpString.Dispose();
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void KeypadClearEntries()
        {
            try
            {
                _stPad.SensorClearKeypadEntries();
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void KeypadModeStartDefaults()
        {
            _keypadModeActive = true;
            try
            {   // erase LCD and clear Hotspots
                _stPad.DisplayErase();
                ClearHotSpots();
                _stPad.SensorClearSignRect();
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
            LabelCapturedPoints.Text = "";
            buttonKeypadDemo.Text = _keypadButtonText_ModeActive;
            textBoxKeypadEntries.Text = _keypadTextboxText_Default;
            ButtonStartCancel.Enabled = false;
            ButtonSettings.Enabled = false;
            ButtonClearDisplay.Enabled = false;
            ButtonRSA.Enabled = false;
        }

        private void KeypadModeEndDefaults()
        {
            try
            {   // erase LCD and clear Hotspots
                _stPad.DisplayErase();
                ClearHotSpots();
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
            buttonKeypadDemo.Text = _keypadButtonText_Default;
            ButtonStartCancel.Enabled = true;
            ButtonSettings.Enabled = true;
            ButtonRSA.Enabled = true;
            ButtonClearDisplay.Enabled = true;
            _keypadModeActive = false;
        }


        #endregion
        //------------------------------------------------------------------------------------
        #region "Control Window"

        private void ButtonBackColor_Click(object sender, EventArgs e)
        {
            DialogColor.Color = ButtonBackColor.BackColor;
            if (DialogColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ButtonBackColor.BackColor = DialogColor.Color;
            stPadLibControl1.ControlBackColor = ButtonBackColor.BackColor;
            if ((_captureWindow != null) && !_captureWindow.IsDisposed)
                _captureWindow.SetControlBackColor(ButtonBackColor.BackColor);
        }

        private void ButtonRectColor_Click(object sender, EventArgs e)
        {
            DialogColor.Color = ButtonRectColor.BackColor;
            if (DialogColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ButtonRectColor.BackColor = DialogColor.Color;
            stPadLibControl1.ControlRectColor = ButtonRectColor.BackColor;
            if ((_captureWindow != null) && !_captureWindow.IsDisposed)
                _captureWindow.SetControlRectColor(ButtonRectColor.BackColor);
        }

        private void ButtonPenColor_Click(object sender, EventArgs e)
        {
            DialogColor.Color = ButtonPenColor.BackColor;
            if (DialogColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ButtonPenColor.BackColor = DialogColor.Color;
            stPadLibControl1.ControlPenColor = ButtonPenColor.BackColor;
            if ((_captureWindow != null) && !_captureWindow.IsDisposed)
                _captureWindow.SetControlPenColor(ButtonPenColor.BackColor);
        }

        private void ComboBoxPenWidthControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int width = 0;
            // set pen width
            switch (ComboBoxPenWidthControl.SelectedIndex)
            {
                case 6:
                    width = -1;
                    break;
                case 7:
                    width = -2;
                    break;
                case 8:
                    width = -3;
                    break;
                case 9:
                    width = -4;
                    break;
                case 10:
                    width = -5;
                    break;
                default:
                    width = ComboBoxPenWidthControl.SelectedIndex;
                    break;
            }
            stPadLibControl1.ControlPenWidth = width;
            if ((_captureWindow != null) && !_captureWindow.IsDisposed)
                _captureWindow.SetControlPenWidth(width);
        }

        private void ComboBoxMirror_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set window content
            stPadLibControl1.ControlMirrorDisplay = (MirrorMode)ComboBoxMirror.SelectedIndex;
            if ((_captureWindow != null) && !_captureWindow.IsDisposed)
                _captureWindow.SetControlMirrorDisplay(ComboBoxMirror.SelectedIndex);
        }


        private void ButtonOpenSeparateWindow_Click(object sender, EventArgs e)
        {
            stPadLibControl1.ControlSetSTPadLib(null);
            _captureWindow = new CaptureWindow(this, _stPad);
            _captureWindow.SetControlBackColor(ButtonBackColor.BackColor);
            _captureWindow.SetControlRectColor(ButtonRectColor.BackColor);
            _captureWindow.SetControlPenColor(ButtonPenColor.BackColor);
            ComboBoxPenWidthControl_SelectedIndexChanged(this, EventArgs.Empty);
            ComboBoxMirror_SelectedIndexChanged(this, EventArgs.Empty);
            _captureWindow.Owner = this;
            try
            {
                _captureWindow.Size = new Size(_stPad.DisplayWidth, _stPad.DisplayHeight);
            }
            catch { }
            _captureWindow.Show();
            LabelSignatureData.Visible = true;
        }

        public void CaptureWindowClosed()
        {
            stPadLibControl1.ControlSetSTPadLib(_stPad);
            LabelSignatureData.Visible = false;
        }

        #endregion
        //------------------------------------------------------------------------------------
        #region "Configure Timeouts"

        private void ButtonTimeoutStartStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (ButtonTimeoutStartStop.Text.Equals("Start"))
                {
                    if ((TextBoxTimeoutBefore.Text.Equals("")) || (TextBoxTimeoutAfter.Text.Equals("")))
                    {
                        MessageBox.Show("Please enter valid timeout values!", Application.ProductName);
                        return;
                    }

                    _stPad.SensorStartTimer(int.Parse(TextBoxTimeoutBefore.Text), int.Parse(TextBoxTimeoutAfter.Text), (TimerOption)ComboBoxTimeout.SelectedIndex);
                    ButtonTimeoutStartStop.Text = "Stop";
                }
                else
                {
                    _stPad.SensorStopTimer();
                    ButtonTimeoutStartStop.Text = "Start";
                }
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        #endregion
        //------------------------------------------------------------------------------------
        #region "LED Color"

        private void CheckBoxLedDef_Click(object sender, EventArgs e)
        {
            // set LED default behaviour
            _stPad.DeviceLedDefaultFlag = CheckBoxLedDef.Checked;
        }

        private void CheckBoxLedY_CheckedChanged(object sender, EventArgs e)
        {
            SetLedInApp();
        }

        private void CheckBoxLedY_Click(object sender, EventArgs e)
        {
            SetLedInDevice();
        }

        private void CheckBoxLedG_CheckedChanged(object sender, EventArgs e)
        {
            SetLedInApp();
        }

        private void CheckBoxLedG_Click(object sender, EventArgs e)
        {
            SetLedInDevice();
        }

        private void SetLedInApp()
        {
            // set LED color in demo app
            switch ((CheckBoxLedY.Checked ? 1 : 0) + (CheckBoxLedG.Checked ? 2 : 0))
            {
                case 0:
                    if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Gamma)
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Off_Gamma;
                    else if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Zeta)
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Off_Gamma;
                    else if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Delta)
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Off_Delta;
                    else
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Off;
                    break;
                case 1:
                    if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Gamma)
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Yellow_Gamma;
                    else if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Zeta)
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Yellow_Gamma;
                    else if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Delta)
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Yellow_Delta;
                    else
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Yellow;
                    break;
                case 2:
                    if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Gamma)
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Green_Gamma;
                    else if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Zeta)
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Green_Gamma;
                    else if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Delta)
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Green_Delta;
                    else
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_Green;
                    break;
                case 3:
                    if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Gamma)
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_YellowGreen_Gamma;
                    else if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Zeta)
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_YellowGreen_Gamma;
                    else if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Delta)
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_YellowGreen_Delta;
                    else
                        ImageLed.Image = Emr.SignPad.Properties.Resources.LED_YellowGreen;
                    break;
            }
        }

        private void SetLedInDevice()
        {
            if ((ListOfDevices.SelectedIndex < 0) || !_signPads[ListOfDevices.SelectedIndex].Open)
                return;

            try
            {
                _stPad.DeviceSetLed(((CheckBoxLedY.Checked ? LedColorFlag.Yellow : LedColorFlag.Off) | (CheckBoxLedG.Checked ? LedColorFlag.Green : LedColorFlag.Off)));
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        #endregion
        //------------------------------------------------------------------------------------
        #region "Configure Sensor"

        private void ButtonSetSignWin_Click(object sender, EventArgs e)
        {
            if ((TextBoxSensorX.Text.Equals("")) || (TextBoxSensorY.Text.Equals("")) || (TextBoxSensorWidth.Text.Equals("")) || (TextBoxSensorHeight.Text.Equals("")))
            {
                MessageBox.Show("Please enter valid X, Y, width, and height values!", Application.ProductName);
                return;
            }

            try
            {
                // set signature window
                _stPad.SensorSetSignRect(int.Parse(TextBoxSensorX.Text), int.Parse(TextBoxSensorY.Text), int.Parse(TextBoxSensorWidth.Text), int.Parse(TextBoxSensorHeight.Text));
                // enable "Clear" button
                ButtonClearSignWin.Enabled = true;
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void ButtonClearSignWin_Click(object sender, EventArgs e)
        {
            try
            {
                // clear signature window
                _stPad.SensorClearSignRect();
                // disable "Clear" button
                ButtonClearSignWin.Enabled = false;
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void ButtonSetScrollArea_Click(object sender, EventArgs e)
        {
            if ((TextBoxSensorX.Text.Equals("")) || (TextBoxSensorY.Text.Equals("")) || (TextBoxSensorWidth.Text.Equals("")) || (TextBoxSensorHeight.Text.Equals("")))
            {
                MessageBox.Show("Please enter valid X, Y, width, and height values!", Application.ProductName);
                return;
            }

            try
            {
                _stPad.SensorSetScrollArea(int.Parse(TextBoxSensorX.Text), int.Parse(TextBoxSensorY.Text), int.Parse(TextBoxSensorWidth.Text), int.Parse(TextBoxSensorHeight.Text));
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void CheckBoxPenScrolling_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _stPad.SensorSetPenScrollingEnabled(CheckBoxPenScrolling.Checked);
            }
            catch (STPadException exc)
            {
                CheckBoxPenScrolling.CheckState = CheckBoxPenScrolling.Checked ? CheckState.Unchecked : CheckState.Checked;
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void ComboBoxHotspotType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ComboBoxHotspotType.Text.Equals("Clear All"))
                ButtonSetHotSpot.Text = "Clear";
            else
                ButtonSetHotSpot.Text = "Add";
        }

        private void ButtonSetHotSpot_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComboBoxHotspotType.Text.Equals("Clear All"))
                    // clear hot spots
                    ClearHotSpots();
                else
                {
                    bool buttonCreated = true;
                    if ((TextBoxSensorX.Text.Equals("")) || (TextBoxSensorY.Text.Equals("")) || (TextBoxSensorWidth.Text.Equals("")) || (TextBoxSensorHeight.Text.Equals("")))
                    {
                        MessageBox.Show("Please enter valid X, Y, width, and height values!", Application.ProductName);
                        return;
                    }
                    // add hot spot
                    int id = 0;
                    int x = int.Parse(TextBoxSensorX.Text);
                    int y = int.Parse(TextBoxSensorY.Text);
                    int width = int.Parse(TextBoxSensorWidth.Text);
                    int height = int.Parse(TextBoxSensorHeight.Text);
                    switch (ComboBoxHotspotType.Text)
                    {
                        case "Standard":
                            id = _stPad.SensorAddHotSpot(x, y, width, height);
                            break;
                        case "Scroll Down":
                            id = _stPad.SensorAddScrollHotSpot(x, y, width, height, ScrollOption.ScrollDown);
                            break;
                        case "Scroll Up":
                            id = _stPad.SensorAddScrollHotSpot(x, y, width, height, ScrollOption.ScrollUp);
                            break;
                        case "Scroll Right":
                            id = _stPad.SensorAddScrollHotSpot(x, y, width, height, ScrollOption.ScrollRight);
                            break;
                        case "Scroll Left":
                            id = _stPad.SensorAddScrollHotSpot(x, y, width, height, ScrollOption.ScrollLeft);
                            break;
                        case "Scrollable":
                            id = _stPad.SensorAddScrollHotSpot(x, y, width, height, ScrollOption.Scrollable);
                            break;
                        case "Keypad":
                            string KeypadName;
                            KeypadNameWindow nameWindow = new KeypadNameWindow();
                            nameWindow.StartPosition = FormStartPosition.CenterParent;
                            if (nameWindow.ShowDialog(this) == DialogResult.OK)
                            {
                                KeypadName = nameWindow.KeypadName;
                                SecureString SecureKeypadName = new System.Net.NetworkCredential("", KeypadName).SecurePassword;
                                id = _stPad.SensorAddKeypadHotSpot(x, y, width, height, SecureKeypadName);
                                SecureKeypadName.Dispose();
                            }
                            else
                                buttonCreated = false;
                            break;
                    }
                    if (buttonCreated)
                    {
                        ComboBoxHotspotId.SelectedIndex = ComboBoxHotspotId.Items.Add(String.Format("#{0}", id + 1));
                        ComboBoxHotspotId.Enabled = true;
                        ComboBoxHotspotMode.SelectedIndex = 1;
                        ComboBoxHotspotMode.Enabled = true;
                    }
                }
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void ClearHotSpots()
        {
            try
            {
                _stPad.SensorClearHotSpots();
                ClearKeypadEntries();
            }
            catch (STPadException exc)
            {
                if (exc.ErrorCode != -22)
                    throw exc;
            }
            _buttonCancelId = -1;
            _buttonRetryId = -1;
            _buttonConfirmId = -1;
            // reset combo boxes
            ComboBoxHotspotId.Items.Clear();
            ComboBoxHotspotId.Enabled = false;
            ComboBoxHotspotMode.SelectedIndex = 1;
            ComboBoxHotspotMode.Enabled = false;
        }

        private void ClearKeypadEntries()
        {
            if (_signPads[ListOfDevices.SelectedIndex].SupportsKeypad)
            {   
                try
                {
                    _stPad.SensorClearKeypadEntries();
                }
                catch (STPadException exc)
                {
                    MessageBox.Show(exc.Message, Application.ProductName);
                }
            }
        }

        private void ComboBoxHotspotId_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetHotspotMode();
        }

        private void ComboBoxHotspotMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetHotspotMode();
        }

        private void SetHotspotMode()
        {
            if ((ComboBoxHotspotId.SelectedIndex < 0) || (ComboBoxHotspotMode.SelectedIndex < 0))
                return;
            try
            {
                _stPad.SensorSetHotspotMode((HotSpotMode)ComboBoxHotspotMode.SelectedIndex, ComboBoxHotspotId.SelectedIndex);
                _lastButtonState = ComboBoxHotspotMode.Text;    // in case of an error on next call, this is the last state of the button, can be recovered within the catch case
            }
            catch (STPadException exc)
            {
                ComboBoxHotspotMode.Text = _lastButtonState;    // changing state was not successful, set old state within drop down list
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void ComboBoxSampleRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListOfDevices.SelectedIndex < 0)
                return;

            try
            {
                // set sample rate
                _stPad.SensorSetSampleRateMode((SampleRate)ComboBoxSampleRate.SelectedIndex);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        #endregion
        //------------------------------------------------------------------------------------
        #region "Configure Display"

        private void ButtonDisplayPenColor_Click(object sender, EventArgs e)
        {
            DialogColor.Color = ButtonDisplayPenColor.BackColor;
            if (DialogColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ButtonDisplayPenColor.BackColor = DialogColor.Color;

            // set color
            DisplayConfigPen();
        }

        private void ComboBoxDisplayPenWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayConfigPen();
        }

        private bool DisplayConfigPen()
        {
            if ((ListOfDevices.SelectedIndex < 0) || !_signPads[ListOfDevices.SelectedIndex].Open)
                return false;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                _stPad.DisplayConfigPen(ComboBoxDisplayPenWidth.SelectedIndex + 1, ButtonDisplayPenColor.BackColor);
            }
            catch (STPadException exc)
            {
                MessageBox.Show("Tính năng không khả dụng khi màn hình ký tên sẳn sàng.", Application.ProductName);
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return true;
        }

        private void ComboBoxBacklight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ListOfDevices.SelectedIndex < 0) || !_signPads[ListOfDevices.SelectedIndex].Open)
                return;

            try
            {
                _stPad.DisplaySetBacklight((BacklightMode)ComboBoxBacklight.SelectedIndex);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void ComboBoxRotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ListOfDevices.SelectedIndex < 0) || !_signPads[ListOfDevices.SelectedIndex].Open)
                return;

            try
            {
                _stPad.DisplayRotation = ComboBoxRotation.SelectedIndex * 180;
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        #endregion
        //------------------------------------------------------------------------------------
        #region "Drawing"

        private void ComboBoxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetImageSource();
        }

        private void SetImageSource()
        {
            switch (ComboBoxSource.SelectedIndex)
            {
                case 0:
                    // Custom Text
                    EnableDrawPosOptions(true);
                    if (ComboBoxTextRect.SelectedIndex == 0)
                        EnableDrawSizeOptions(false);
                    else
                        EnableDrawSizeOptions(true);
                    ComboBoxImage.Enabled = false;
                    EnablePDFOptions(false);
                    EnableTextOptions(true);
                    ButtonDraw.Text = "Draw";
                    break;
                case 1:
                    // Image
                    EnableDrawPosOptions(true);
                    EnableDrawSizeOptions(false);
                    ComboBoxImage.Enabled = true;
                    EnablePDFOptions(false);
                    EnableTextOptions(false);
                    ButtonDraw.Text = "Draw";
                    break;
                case 2:
                    // PDF
                    EnableDrawPosOptions(true);
                    EnableDrawSizeOptions(false);
                    ComboBoxImage.Enabled = false;
                    EnablePDFOptions(true);
                    EnableTextOptions(false);
                    ButtonDraw.Text = "Draw";
                    SelectPDF();
                    break;
                case 3:
                    // Erase
                    EnableDrawPosOptions(true);
                    EnableDrawSizeOptions(true);
                    ComboBoxImage.Enabled = false;
                    EnablePDFOptions(false);
                    EnableTextOptions(false);
                    ButtonDraw.Text = "Erase";
                    break;
                case 6:
                    // Overlay Buffer
                    EnableDrawPosOptions(true);
                    EnableDrawSizeOptions(true);
                    ComboBoxImage.Enabled = false;
                    EnablePDFOptions(false);
                    EnableTextOptions(false);
                    ButtonDraw.Text = "Set";
                    break;
                default:
                    // Buffer or Store
                    EnableDrawPosOptions(false);
                    EnableDrawSizeOptions(false);
                    ComboBoxImage.Enabled = false;
                    EnablePDFOptions(false);
                    EnableTextOptions(false);
                    ButtonDraw.Text = "Copy";
                    break;
            }
        }

        private void ComboBoxTarget_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetImageSource();
            StandbyImageTimeoutDialog();

            if (ComboBoxTarget.SelectedIndex == 3)
            {   // standby image
                LabelTargetSize.Text = String.Format("Target Size: {0} x {1} px", _stPad.DisplayWidth, _stPad.DisplayHeight);
                TextBoxScrollX.Enabled = false;
                TextBoxScrollY.Enabled = false;
                TextBoxScrollX.Text = "0";
                TextBoxScrollY.Text = "0";
                return;
            }

            try
            {
                // get desired target ID
                DisplayTarget target = DisplayTarget.ForegroundBuffer;
                if (ComboBoxTarget.SelectedIndex < 3)
                    // buffer
                    target = (DisplayTarget)ComboBoxTarget.SelectedIndex;
                else if (ComboBoxTarget.SelectedIndex == 4)
                    // new permanent Store
                    target = DisplayTarget.NewStandardStore;
                else if (ComboBoxTarget.SelectedIndex == 5)
                    // new permanent large store
                    target = DisplayTarget.NewLargeStore;
                else
                {    // existing permanent Store
                    String strStoreID = ComboBoxTarget.Items[ComboBoxTarget.SelectedIndex].ToString().Replace("Permanent Store - ID ", "");
                    target = (DisplayTarget)int.Parse(strStoreID);
                }

                // set target
                if ((SetTarget(target) == DisplayTarget.BackgroundBuffer) && (target != DisplayTarget.BackgroundBuffer))
                    MessageBox.Show("The requested Target is not available. The Background Buffer has been set as Target.", Application.ProductName);
            }
            catch (STPadException exc)
            {
                if (exc.ErrorCode == -3)
                {   // target not available (f.e. setting to overlay buffer on pads where it does not exist)
                    MessageBox.Show("The requested Target is not available. The Background Buffer will now be set as Target.", Application.ProductName);
                    SetTarget(DisplayTarget.BackgroundBuffer);
                }
                else
                {
                    if (exc.ErrorCode == -99)   // a keypad button is active and inverting, switching target is not permitted
                        ComboBoxTarget.Text = "Display (Foregr. Buffer)";
                    MessageBox.Show(exc.Message, Application.ProductName);
                }
            }
        }

        private void EnableDrawPosOptions(bool value)
        {
            if (ComboBoxTarget.SelectedIndex == 3)
                // standby image
                value = false;
            LabelDrawX.Enabled = value;
            TextBoxDrawX.Enabled = value;
            LabelDrawY.Enabled = value;
            TextBoxDrawY.Enabled = value;
        }

        private void EnableDrawSizeOptions(bool value)
        {
            if (ComboBoxTarget.SelectedIndex == 3)
                // standby image
                value = false;
            LabelDrawWidth.Enabled = value;
            TextBoxDrawWidth.Enabled = value;
            LabelDrawHeight.Enabled = value;
            TextBoxDrawHeight.Enabled = value;
        }

        private void EnablePDFOptions(bool value)
        {
            ComboBoxPDF.Enabled = value;
            if (ComboBoxPDF.SelectedIndex <= 1)
                value = false;
            ComboBoxPage.Enabled = value;
            ComboBoxUnit.Enabled = value;
            LabelSize.Enabled = value;
            LabelCropping.Enabled = value;
            LabelSelectX.Enabled = value;
            TextBoxSelectX.Enabled = value;
            LabelSelectY.Enabled = value;
            TextBoxSelectY.Enabled = value;
            LabelSelectWidth.Enabled = value;
            TextBoxSelectWidth.Enabled = value;
            LabelSelectHeight.Enabled = value;
            TextBoxSelectHeight.Enabled = value;
            LabelScale.Enabled = value;
            TextBoxScale.Enabled = value;
            CheckBoxBufferPage.Enabled = value;
        }

        private void EnableTextOptions(bool value)
        {
            if (ComboBoxTarget.SelectedIndex == 3)
                // standby image
                value = false;
            ComboBoxFontList.Enabled = value;
            LabelFontSize.Enabled = value;
            TextBoxFontSize.Enabled = value;
            CheckBoxBold.Enabled = value;
            CheckBoxUnderline.Enabled = value;
            CheckBoxItalic.Enabled = value;
            if ((ListOfDevices.SelectedIndex >= 0) && _signPads[ListOfDevices.SelectedIndex].HasColorDisplay)
            {
                LabelFontColor.Enabled = value;
                ButtonFontColor.Enabled = value;
            }
            else
            {
                LabelFontColor.Enabled = false;
                ButtonFontColor.Enabled = false;
            }
            TextBoxText.Enabled = value;
            ComboBoxTextRect.Enabled = value;
            ComboBoxTextAlign.Enabled = value;
        }

        private DisplayTarget SetTarget(DisplayTarget target)
        {
            // return if pad is closed
            if ((ListOfDevices.SelectedIndex < 0) || !_signPads[ListOfDevices.SelectedIndex].Open)
                return DisplayTarget.ForegroundBuffer;

            // set target
            DisplayTarget id = _stPad.DisplaySetTarget(target);

            try
            {
                // update ComboBoxTarget & ComboBoxSource: id holds the effective set target
                if (id >= DisplayTarget.Reserved1)
                {   // one of the stores
                    String strItem = String.Format("Permanent Store - ID {0}", (int)id);
                    if (id != target)
                    {
                        ComboBoxSource.Items.Add(strItem);
                        ComboBoxTarget.SelectedIndex = ComboBoxTarget.Items.Add(strItem);
                    }
                }
                else if (id >= DisplayTarget.ForegroundBuffer)
                    // one of the buffers
                    ComboBoxTarget.SelectedIndex = (int)id;

                LabelTargetSize.Text = String.Format("Target Size: {0} x {1} px", _stPad.DisplayTargetWidth, _stPad.DisplayTargetHeight);
                if (_stPad.DisplayTargetHeight - _stPad.DisplayHeight > 0)
                {
                    TextBoxScrollX.Enabled = _signPads[ListOfDevices.SelectedIndex].SupportsHorizontalScrolling;
                    TextBoxScrollY.Enabled = _signPads[ListOfDevices.SelectedIndex].SupportsVerticalScrolling;
                    int xPos;
                    int yPos;
                    _stPad.DisplayGetScrollPos(out xPos, out yPos);

                    TextBoxScrollX.Text = String.Format("{0}", xPos);
                    TextBoxScrollY.Text = String.Format("{0}", yPos);
                }
                else
                {
                    TextBoxScrollY.Enabled = false;
                    TextBoxScrollX.Enabled = false;
                    TextBoxScrollX.Text = "0";
                    TextBoxScrollY.Text = "0";
                }
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            return id;
        }

        private void ComboBoxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxImage.SelectedIndex > 4)
            {
                if (ComboBoxImage.SelectedIndex == 5)
                {   // from file
                    DialogOpen.Filter = "All supported files|*.bmp;*.gif;*.jpg;*.png;*.tif|BMP files (*.BMP)|*.bmp|GIF files (*.GIF)|*.gif|JPEG files (*.JPG)|*.jpg|PNG files (*.PNG)|*.png|TIFF files (*.TIF)|*.tif";
                    DialogOpen.FileName = "";
                    DialogOpen.ShowDialog();

                    if (!DialogOpen.FileName.Equals(""))
                    {
                        //only add new Combobox item if it doesn't already exist
                        if (!ComboBoxImage.Items.Contains(DialogOpen.FileName))
                            ComboBoxImage.SelectedIndex = ComboBoxImage.Items.Add(DialogOpen.FileName);
                        else //else set focus to the already existing item
                        {
                            int index = ComboBoxImage.FindString(DialogOpen.FileName);
                            ComboBoxImage.SelectedIndex = index;
                        }
                    }
                    else
                        ComboBoxImage.SelectedIndex = 0;
                }
                else if (ComboBoxImage.SelectedIndex == 6)
                {   // from URL
                    URLPrompt urlPrompt = new URLPrompt();
                    urlPrompt.ShowDialog();

                    if (!urlPrompt.URL.Equals(""))
                    {
                        //only add new Combobox item if it doesn't already exist
                        if (!ComboBoxImage.Items.Contains(urlPrompt.URL))
                            ComboBoxImage.SelectedIndex = ComboBoxImage.Items.Add(urlPrompt.URL);
                        else //else set focus to the already existing item
                        {
                            int index = ComboBoxImage.FindString(urlPrompt.URL);
                            ComboBoxImage.SelectedIndex = index;
                        }
                    }
                    else
                        ComboBoxImage.SelectedIndex = 0;
                }
            }
            if (ComboBoxImage.SelectedIndex > 4)
                ComboBoxImage.DropDownStyle = ComboBoxStyle.DropDown;
            else
                ComboBoxImage.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ComboBoxPDF_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectPDF();
        }

        private void SelectPDF()
        {
            string file = null;
            switch (ComboBoxPDF.SelectedIndex)
            {
                case 0:
                    // from file
                    DialogOpen.Filter = "PDF (*.PDF)|*.pdf";
                    DialogOpen.FileName = "";
                    DialogOpen.ShowDialog();
                    if (!DialogOpen.FileName.Equals(""))
                        file = DialogOpen.FileName;
                    break;
                case 1:
                    // from URL
                    URLPrompt urlPrompt = new URLPrompt();
                    urlPrompt.ShowDialog();
                    if (!urlPrompt.URL.Equals(""))
                        file = urlPrompt.URL;
                    break;
                default:
                    file = ComboBoxPDF.SelectedItem.ToString();
                    break;
            }
            if (file != null)
            {
                try
                {
                    _stPad.PDFLoad(file);
                }
                catch (STPadException exc)
                {
                    if (exc.ErrorCode == -81)
                    {
                        PasswordPrompt passwordWindow = new PasswordPrompt("Please enter the password for the PDF file:");
                        passwordWindow.StartPosition = FormStartPosition.CenterParent;
                        try
                        {
                            if (passwordWindow.ShowDialog(this) == DialogResult.OK)
                                _stPad.PDFLoad(file, passwordWindow.PasswordHandover);
                            else
                                return;
                        }
                        catch (STPadException excep)
                        {
                            MessageBox.Show(excep.Message, Application.ProductName);
                            return;
                        }
                        finally
                        {
                            _rsaOptions.SafeDeletePassword(passwordWindow);
                        }
                    }
                    else
                    {
                        MessageBox.Show(exc.Message, Application.ProductName);
                        return;
                    }
                }

                try
                {
                    int count = _stPad.PDFGetPageCount();

                    //only add new Combobox item if it doesn't already exist
                    if (!ComboBoxPDF.Items.Contains(file))
                        ComboBoxPDF.SelectedIndex = ComboBoxPDF.Items.Add(file);
                    else //else set focus to the already existing item
                    {
                        int index = ComboBoxPDF.FindString(file);
                        ComboBoxPDF.SelectedIndex = index;
                    }

                    ButtonDraw.Enabled = true;
                    EnablePDFOptions(true);
                    ComboBoxPage.Items.Clear();
                    for (int i = 1; i <= count; i++)
                        ComboBoxPage.Items.Add("Page " + i);
                    ComboBoxPage.SelectedIndex = 0;
                    LabelPageCount.Text = "of " + count;
                    ComboBoxPDF.DropDownStyle = ComboBoxStyle.DropDown;
                }
                catch (STPadException exc)
                {
                    _stPad.PDFLoad();
                    MessageBox.Show(exc.Message, Application.ProductName);
                }
            }
            else
            {
                ComboBoxPDF.DropDownStyle = ComboBoxStyle.DropDownList;
                ButtonDraw.Enabled = false;
                EnablePDFOptions(false);
                ComboBoxPDF.Enabled = true;
            }
        }

        private void ComboBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDimension();
        }

        private void ComboBoxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelCropping.Text = "Cropping (" + ComboBoxUnit.Text + "):";
            GetDimension();
        }

        private void GetDimension()
        {
            try
            {
                double width = _stPad.PDFGetWidth(ComboBoxPage.SelectedIndex + 1, (MeasurementUnit)ComboBoxUnit.SelectedIndex);
                double height = _stPad.PDFGetHeight(ComboBoxPage.SelectedIndex + 1, (MeasurementUnit)ComboBoxUnit.SelectedIndex);
                LabelSize.Text = Math.Round(width, 2).ToString() + " x " + Math.Round(height, 2).ToString();
                if (width < Int32.Parse(TextBoxSelectWidth.Text))
                    TextBoxSelectWidth.Text = String.Format("{0}", Math.Floor(width));
                if (height < Int32.Parse(TextBoxSelectHeight.Text))
                    TextBoxSelectHeight.Text = String.Format("{0}", Math.Floor(height));
            }
            catch (STPadException)
            {
                LabelSize.Text = "-";
            }
        }

        private void ComboBoxFontList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFont();
        }

        private void TextBoxFontSize_Leave(object sender, EventArgs e)
        {
            SetFont();
        }

        private void CheckBoxBold_CheckedChanged(object sender, EventArgs e)
        {
            SetFont();
        }

        private void CheckBoxUnderline_CheckedChanged(object sender, EventArgs e)
        {
            SetFont();
        }

        private void CheckBoxItalic_CheckedChanged(object sender, EventArgs e)
        {
            SetFont();
        }

        private void ButtonFontColor_Click(object sender, EventArgs e)
        {
            DialogColor.Color = ButtonFontColor.BackColor;
            if (DialogColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ButtonFontColor.BackColor = DialogColor.Color;

            SetFont();
        }

        private void SetFont()
        {
            if (TextBoxFontSize.Text.Equals(""))
            {
                MessageBox.Show("Please enter a valid font size!", Application.ProductName);
                return;
            }

            if ((ListOfDevices.SelectedIndex < 0) || !_signPads[ListOfDevices.SelectedIndex].Open)
                return;

            try
            {
                // set font
                FontFamily fontFamily = new FontFamily(ComboBoxFontList.SelectedItem.ToString());
                FontStyle fontStyle = FontStyle.Regular;
                if (CheckBoxBold.Checked && fontFamily.IsStyleAvailable(FontStyle.Bold))
                    fontStyle |= FontStyle.Bold;
                if (CheckBoxUnderline.Checked && fontFamily.IsStyleAvailable(FontStyle.Underline))
                    fontStyle |= FontStyle.Underline;
                if (CheckBoxItalic.Checked && fontFamily.IsStyleAvailable(FontStyle.Italic))
                    fontStyle |= FontStyle.Italic;
                Font font = new Font(fontFamily, float.Parse(TextBoxFontSize.Text), fontStyle);
                _stPad.DisplaySetFont(font);
                TextBoxText.Font = new Font(fontFamily, TextBoxText.Font.Size, fontStyle);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            try
            {
                // set font color
                _stPad.DisplaySetFontColor(ButtonFontColor.BackColor);
                TextBoxText.ForeColor = ButtonFontColor.BackColor;
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void ComboBoxTextRect_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enable = (ComboBoxTextRect.SelectedIndex != 0);
            LabelDrawWidth.Enabled = enable;
            TextBoxDrawWidth.Enabled = enable;
            LabelDrawHeight.Enabled = enable;
            TextBoxDrawHeight.Enabled = enable;
            CheckBoxFixedFontSize.Enabled = enable;
        }

        private void ButtonDraw_Click(object sender, EventArgs e)
        {
            if (ComboBoxTarget.SelectedIndex == 3)
            {   // store / erase standby image
                SetStandbyImage();
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                switch (ComboBoxSource.SelectedIndex)
                {
                    case 0:
                        // draw custom text
                        DrawText();
                        break;
                    case 1:
                        // draw image
                        DrawImage();
                        break;
                    case 2:
                        // draw PDF
                        _stPad.PDFSelectRect(ComboBoxPage.SelectedIndex + 1, Double.Parse(TextBoxSelectX.Text), Double.Parse(TextBoxSelectY.Text), Double.Parse(TextBoxSelectWidth.Text), Double.Parse(TextBoxSelectHeight.Text), (MeasurementUnit)ComboBoxUnit.SelectedIndex);
                        _stPad.DisplaySetPDF(Int32.Parse(TextBoxDrawX.Text), Int32.Parse(TextBoxDrawY.Text), ComboBoxPage.SelectedIndex + 1, Double.Parse(TextBoxScale.Text) * 0.01, (CheckBoxBufferPage.Checked ? PdfFlag.Cache : PdfFlag.None));
                        break;
                    case 3:
                        // erase
                        EraseRectangle();
                        break;
                    case 6:
                        // draw overlay rectangle
                        DrawOverlayRectangle();
                        break;
                    default:
                        // copy / move stored image
                        DisplayTarget storeId = DisplayTarget.ForegroundBuffer;
                        if (ComboBoxSource.SelectedIndex < 7)
                            // draw from buffer
                            storeId = (DisplayTarget)(ComboBoxSource.SelectedIndex - 4);
                        else
                        {   // draw from permanent store
                            string strStoreID = ComboBoxSource.Items[ComboBoxSource.SelectedIndex].ToString().Replace("Permanent Store - ID ", "");
                            storeId = (DisplayTarget)int.Parse(strStoreID);
                        }
                        _stPad.DisplaySetImageFromStore(storeId);
                        // get scroll pos of target
                        int xPos;
                        int yPos;
                        _stPad.DisplayGetScrollPos(out xPos, out yPos);
                        TextBoxScrollX.Text = String.Format("{0}", xPos);
                        TextBoxScrollY.Text = String.Format("{0}", yPos);
                        break;
                }
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            this.Cursor = Cursors.Default;
        }

        private void SetStandbyImage()
        {
            String mode = "";
            switch (ComboBoxSource.SelectedIndex)
            {
                case 1:
                    mode = "replace";
                    break;
                case 3:
                    mode = "erase";
                    break;
                default:
                    MessageBox.Show("It's not possible to store a standby image from this source!", Application.ProductName);
                    return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // get configured standby state
                String standbyId;
                int count = _stPad.DisplayGetStandbyId(out standbyId);
                if (count > 0)
                {
                    String standbyType = "Standby Image";
                    if (count > 1)
                        standbyType = String.Format("Slide Show containing {0} images", count);

                    if (MessageBox.Show("Do you want to " + mode + " the currently set " + standbyType + "?\n" +
                                        "(ID: " + standbyId + ")", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return;
                }

                // format timeout if necessary
                if (CheckBoxStByTimeout.Checked == true)
                {
                    if (TextBoxStByTimeout.Text.Contains(" "))
                        TextBoxStByTimeout.Text = TextBoxStByTimeout.Text.Replace(" ", "");
                    if (TextBoxStByTimeout.Text.Equals(""))
                        TextBoxStByTimeout.Text = "0";
                }
                switch (ComboBoxSource.SelectedIndex)
                {
                    case 1:
                        if (ComboBoxImage.SelectedIndex < 5)
                        {    // from resource
                            Bitmap bitmap = GetSelectedImage();
                            if (bitmap != null)
                            {
                                if (CheckBoxStByTimeout.Checked)
                                    _stPad.DisplaySetStandbyImageEx(bitmap, Int32.Parse(TextBoxStByTimeout.Text));
                                else    // no need to call Ex, even if it would be possible using duration 0
                                    _stPad.DisplaySetStandbyImage(bitmap);
                            }
                        }
                        else
                        {    // from file
                            if (CheckBoxStByTimeout.Checked == true)
                                _stPad.DisplaySetStandbyImageFromFileEx(ComboBoxImage.Text, Int32.Parse(TextBoxStByTimeout.Text));
                            else   // no need to call Ex, even if it would be possible using duration 0
                                _stPad.DisplaySetStandbyImageFromFile(ComboBoxImage.Text);
                        }
                        break;
                    case 3:
                        // erase standby image
                        _stPad.DisplaySetStandbyImage(null);
                        break;
                }
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void StandbyImageTimeoutDialog()
        {
            PadModel padModel = _signPads[ListOfDevices.SelectedIndex].PadModel;
            if ((padModel == PadModel.Sigma) || (padModel == PadModel.Alpha) || ((padModel == PadModel.Omega) && !_signPads[ListOfDevices.SelectedIndex].IsFirmware(2, 0)))
            {   // pad type does not support standby image timeout: disabled
                CheckBoxStByTimeout.Enabled = false;
                CheckBoxStByTimeout.Checked = false;
                LabelStByTimeout.Enabled = false;
                TextBoxStByTimeout.Enabled = false;
                ButtonStByTimeoutMax.Enabled = false;
                TextBoxStByTimeout.Text = "";
            }
            else
            {
                LabelStByTimeout.Enabled = true;

                if ((TextBoxStByTimeout.Text.Equals("255000")) || (TextBoxStByTimeout.Text.Equals("300000")))
                    // max value was set, ensure it fits the pad
                    ButtonStByTimeoutMax_Click(null, null);
                else if (TextBoxStByTimeout.Text.Equals(""))
                    TextBoxStByTimeout.Text = "0";

                if (ComboBoxTarget.SelectedIndex == 3)
                {   // standby image was set as target, enable timeout option
                    CheckBoxStByTimeout.Enabled = true;
                    if (CheckBoxStByTimeout.Checked)
                        CheckBoxStByTimeout_CheckedChanged(null,null);

                }
                else
                {
                    CheckBoxStByTimeout.Enabled = false;
                    TextBoxStByTimeout.Enabled = false;
                    ButtonStByTimeoutMax.Enabled = false;
                }
            }
        }

        private void CheckBoxStByTimeout_CheckedChanged(object sender, EventArgs e)
        {
            PadModel padModel = _signPads[ListOfDevices.SelectedIndex].PadModel;
            if (!((padModel == PadModel.Sigma) || (padModel == PadModel.Alpha) || ((padModel == PadModel.Omega) && !_signPads[ListOfDevices.SelectedIndex].IsFirmware(2, 0))))
            {   // if padmodel supports timeout
                if (CheckBoxStByTimeout.Checked)
                {
                    TextBoxStByTimeout.Enabled = true;
                    ButtonStByTimeoutMax.Enabled = true;
                }
                else
                {
                    TextBoxStByTimeout.Enabled = false;
                    ButtonStByTimeoutMax.Enabled = false;
                }
            }
        }

        private void ButtonStByTimeoutMax_Click(object sender, EventArgs e)
        {
            PadModel padModel = _signPads[ListOfDevices.SelectedIndex].PadModel;
            if (!((padModel == PadModel.Sigma) || (padModel == PadModel.Alpha) || ((padModel == PadModel.Omega) && !_signPads[ListOfDevices.SelectedIndex].IsFirmware(2, 0))))
            {   // pad type supports timeout, set matching max value
                if ((padModel == PadModel.Gamma) || (padModel == PadModel.Delta))
                    TextBoxStByTimeout.Text = "255000";
                else
                    TextBoxStByTimeout.Text = "300000";
            }
            else
                TextBoxStByTimeout.Text = "0";
        }

        private void DrawText()
        {
            if ((TextBoxDrawX.Text.Equals("")) || (TextBoxDrawY.Text.Equals("")) || (TextBoxDrawWidth.Text.Equals("")) || (TextBoxDrawHeight.Text.Equals("")))
            {
                MessageBox.Show("Please enter valid X, Y, width, and height values!", Application.ProductName);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            int size = int.Parse(TextBoxFontSize.Text);
            TextFlag options = CheckBoxFixedFontSize.Checked ? TextFlag.NoResize : TextFlag.None;
            try
            {
                switch (ComboBoxTextRect.SelectedIndex)
                {
                    case 0: // set text in single line
                        _stPad.DisplaySetText(int.Parse(TextBoxDrawX.Text), int.Parse(TextBoxDrawY.Text), (TextAlignment)ComboBoxTextAlign.SelectedIndex, TextBoxText.Text);
                        break;
                    case 1: // set text in rect
                        size = _stPad.DisplaySetTextInRect(int.Parse(TextBoxDrawX.Text), int.Parse(TextBoxDrawY.Text), int.Parse(TextBoxDrawWidth.Text), int.Parse(TextBoxDrawHeight.Text), (TextAlignment)ComboBoxTextAlign.SelectedIndex, TextBoxText.Text, options);
                        break;
                    case 2: // set text in rect without automatic wrapping
                        size = _stPad.DisplaySetTextInRect(int.Parse(TextBoxDrawX.Text), int.Parse(TextBoxDrawY.Text), int.Parse(TextBoxDrawWidth.Text), int.Parse(TextBoxDrawHeight.Text), (TextAlignment)(ComboBoxTextAlign.SelectedIndex + 6), TextBoxText.Text, options);
                        break;
                    case 3: // set text in rect vertically centered
                        size = _stPad.DisplaySetTextInRect(int.Parse(TextBoxDrawX.Text), int.Parse(TextBoxDrawY.Text), int.Parse(TextBoxDrawWidth.Text), int.Parse(TextBoxDrawHeight.Text), (TextAlignment)(ComboBoxTextAlign.SelectedIndex + 3), TextBoxText.Text, options);
                        break;
                }
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            this.Cursor = Cursors.Default;

            if (CheckBoxFixedFontSize.Checked)
            {
                if (size > Int32.Parse(TextBoxDrawHeight.Text))
                    // nothing has been drawn because rectangle is too small; set height of rectangle to needed height
                    TextBoxDrawHeight.Text = String.Format("{0}", size);
                else
                {   // everything's fine, set Y coordinate to bottom of the drawn text to draw next text or image below
                    TextBoxDrawY.Text = String.Format("{0}", Int32.Parse(TextBoxDrawY.Text) + size);
                    TextBoxDrawHeight.Text = String.Format("{0}", Int32.Parse(TextBoxDrawHeight.Text) - size);
                }
            }
            else if (size < int.Parse(TextBoxFontSize.Text))
            {   // the text has been drawn with a samller size than desired, use this size for next drawing
                TextBoxFontSize.Text = String.Format("{0}", size);
                SetFont();
            }
        }

        private void DrawImage()
        {
            if ((TextBoxDrawX.Text.Equals("")) || (TextBoxDrawY.Text.Equals("")))
            {
                MessageBox.Show("Please enter valid X and Y values!", Application.ProductName);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            if (ComboBoxImage.SelectedIndex == -1)
                ComboBoxImage.SelectedIndex = ComboBoxImage.Items.Add(ComboBoxImage.Text);

            try
            {
                if (ComboBoxImage.SelectedIndex < 5)
                {   // from resource
                    Bitmap bitmap = GetSelectedImage();
                    if (bitmap != null)
                        _stPad.DisplaySetImage(int.Parse(TextBoxDrawX.Text), int.Parse(TextBoxDrawY.Text), bitmap);
                }
                else
                    // from file
                    _stPad.DisplaySetImageFromFile(int.Parse(TextBoxDrawX.Text), int.Parse(TextBoxDrawY.Text), ComboBoxImage.Text);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            this.Cursor = Cursors.Default;
        }


        private Bitmap GetSelectedImage()
        {
            if (ListOfDevices.SelectedIndex < 0)
                return null;

            switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
            {
                case PadModel.Sigma:
                    switch (ComboBoxImage.SelectedIndex)
                    {
                        case 0:
                            return Emr.SignPad.Properties.Resources.Example1_Sigma;
                        case 1:
                            return Emr.SignPad.Properties.Resources.Example2_BW;
                        case 2:
                            return Emr.SignPad.Properties.Resources.Example3_Sigma;
                        case 3:
                            return Emr.SignPad.Properties.Resources.Example4_Sigma;
                        case 4:
                            return Emr.SignPad.Properties.Resources.Logo_Sigma;
                    }
                    break;
                case PadModel.Zeta:
                    switch (ComboBoxImage.SelectedIndex)
                    {
                        case 0:
                            return Emr.SignPad.Properties.Resources.Example1_Zeta;
                        case 1:
                            return Emr.SignPad.Properties.Resources.Example2_BW;
                        case 2:
                            return Emr.SignPad.Properties.Resources.Example3_Zeta;
                        case 3:
                            return Emr.SignPad.Properties.Resources.Example4_Zeta;
                        case 4:
                            return Emr.SignPad.Properties.Resources.Logo_Zeta;
                    }
                    break;
                case PadModel.Omega:
                    switch (ComboBoxImage.SelectedIndex)
                    {
                        case 0:
                            return Emr.SignPad.Properties.Resources.Example1_Omega;
                        case 1:
                            return Emr.SignPad.Properties.Resources.Example2_RGB_Small;
                        case 2:
                            return Emr.SignPad.Properties.Resources.Example3_Omega;
                        case 3:
                            return Emr.SignPad.Properties.Resources.Example4_Omega;
                        case 4:
                            return Emr.SignPad.Properties.Resources.Logo_Omega;
                    }
                    break;
                case PadModel.Gamma:
                    switch (ComboBoxImage.SelectedIndex)
                    {
                        case 0:
                            return Emr.SignPad.Properties.Resources.Example1_Gamma;
                        case 1:
                            return Emr.SignPad.Properties.Resources.Example2_RGB_Small;
                        case 2:
                            return Emr.SignPad.Properties.Resources.Example3_Gamma;
                        case 3:
                            return Emr.SignPad.Properties.Resources.Example4_Gamma;
                        case 4:
                            return Emr.SignPad.Properties.Resources.Logo_Gamma;
                    }
                    break;
                case PadModel.Delta:
                    switch (ComboBoxImage.SelectedIndex)
                    {
                        case 0:
                            return Emr.SignPad.Properties.Resources.Example1_Delta;
                        case 1:
                            return Emr.SignPad.Properties.Resources.Example2_RGB_Large;
                        case 2:
                            return Emr.SignPad.Properties.Resources.Example3_Delta;
                        case 3:
                            return Emr.SignPad.Properties.Resources.Example4_Delta;
                        case 4:
                            return Emr.SignPad.Properties.Resources.Logo_Delta;
                    }
                    break;
                case PadModel.Alpha:
                    switch (ComboBoxImage.SelectedIndex)
                    {
                        case 0:
                            return Emr.SignPad.Properties.Resources.Example1_Alpha;
                        case 1:
                            return Emr.SignPad.Properties.Resources.Example2_RGB_Large;
                        case 2:
                            return Emr.SignPad.Properties.Resources.Example3_Alpha;
                        case 3:
                            return Emr.SignPad.Properties.Resources.Example4_Alpha;
                        case 4:
                            return Emr.SignPad.Properties.Resources.Logo_Alpha;
                    }
                    break;
            }
            return null;
        }

        private void EraseRectangle()
        {
            if ((TextBoxDrawX.Text.Equals("")) || (TextBoxDrawY.Text.Equals("")) || (TextBoxDrawWidth.Text.Equals("")) || (TextBoxDrawHeight.Text.Equals("")))
            {
                MessageBox.Show("Please enter valid X, Y, width, and height values!", Application.ProductName);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                _stPad.DisplayEraseRect(int.Parse(TextBoxDrawX.Text), int.Parse(TextBoxDrawY.Text), int.Parse(TextBoxDrawWidth.Text), int.Parse(TextBoxDrawHeight.Text));
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            this.Cursor = Cursors.Default;
        }

        private void DrawOverlayRectangle()
        {
            int left = int.Parse(TextBoxDrawX.Text);
            int top = int.Parse(TextBoxDrawY.Text);
            int width = int.Parse(TextBoxDrawWidth.Text);
            int height = int.Parse(TextBoxDrawHeight.Text);
            PadModel model = _signPads[ListOfDevices.SelectedIndex].PadModel;
            if (((model == PadModel.Sigma) || ((model == PadModel.Omega) && !_signPads[ListOfDevices.SelectedIndex].IsFirmware(2, 0)) || (model == PadModel.Alpha)) &&
            ((left % 8 != 0) || (top % 8 != 0) || (width % 8 != 0) || (height % 8 != 0)))
                MessageBox.Show("The coordinates of the overlay rect must be multiples of 8!", Application.ProductName);
            else
            {
                try
                {
                    _stPad.DisplaySetOverlayRect(left, top, width, height);
                }
                catch (STPadException exc)
                {
                    MessageBox.Show(exc.Message, Application.ProductName);
                }
            }
        }

        private void TextBoxScroll_TextChanged(object sender, EventArgs e)
        {
            if ((ListOfDevices.SelectedIndex < 0) || !_signPads[ListOfDevices.SelectedIndex].Open)
                return;

            if (TextBoxScrollX.Text.Equals("") || TextBoxScrollY.Text.Equals(""))
                return;

            if (_buttonScrolling)
                return;

            int currentXPos;
            int currentYPos;
            try
            {
                _stPad.DisplayGetScrollPos(out currentXPos, out currentYPos);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
                return;
            }
            try
            {
                int newXPos = (_signPads[ListOfDevices.SelectedIndex].SupportsHorizontalScrolling ? int.Parse(TextBoxScrollX.Text) : 0);
                int newYPos = (_signPads[ListOfDevices.SelectedIndex].SupportsVerticalScrolling ? int.Parse(TextBoxScrollY.Text) : 0);
                if ((newXPos != currentXPos) || (newYPos != currentYPos))
                    _stPad.DisplaySetScrollPos(newXPos, newYPos);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
                TextBoxScrollX.Text = String.Format("{0}", currentXPos);
                TextBoxScrollY.Text = String.Format("{0}", currentYPos);
            }
        }

        #endregion
        //------------------------------------------------------------------------------------
        #region "Capturing"

        private void ButtonStartCancel_Click(object sender, EventArgs e)
        {
            this.StartCancel();
        }

        private void StartCancel()
        {
            if (ButtonStartCancel.Text.Equals("Start"))
            {
                bool result = false;
                if (ButtonSettings.Text.Equals("Advanced Settings") && _signPads[ListOfDevices.SelectedIndex].HasDisplay)
                {
                    if (_rsaOptions.ComputeHash || (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Alpha))
                        result = StartDefaultCapturing();
                    else
                        result = ShowDisclaimer();
                }
                else
                    result = StartAdvancedCapturing();
                if (result)
                {
                    ButtonStartCancel.Text = "Cancel";
                    ButtonConfirm.Enabled = true;
                    ButtonClearDisplay.Enabled = false;
                    ButtonSettings.Enabled = false;
                    ImageLcd.Visible = false;
                    stPadLibControl1.Visible = true;
                    GroupBoxSignature.Enabled = false;
                    GroupBoxSignData.Enabled = false;
                    ButtonRSA.Enabled = false;
                    GroupBoxPadService.Enabled = false;
                    GroupBoxKeypadDemo.Enabled = false;
                    if (_signPads[ListOfDevices.SelectedIndex].SupportsKeypad)
                        textBoxKeypadEntries.Text = _keypadTextboxText_Default;
                }
            }
            else
                CancelProcess(false);
        }

        private bool ShowDisclaimer()
        {
            // display disclaimer and two buttons "Cancel" and "Confirm"
            this.Cursor = Cursors.WaitCursor;
            LabelCapturedPoints.Text = "";

            try
            {
                // clear all hot spots
                ClearHotSpots();

                // clear signature window
                _stPad.SensorClearSignRect();

                // erase LCD and background buffer
                _stPad.DisplayErase();

                // set font
                if (!ComboBoxFontList.Text.Equals("Arial"))
                    ComboBoxFontList.SelectedIndex = ComboBoxFontList.Items.IndexOf("Arial");
                string fontSize = null;
                switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                {
                    case PadModel.Sigma:
                    case PadModel.Zeta:
                        fontSize = "20";
                        break;
                    case PadModel.Omega:
                        fontSize = "40";
                        break;
                    case PadModel.Gamma:
                        fontSize = "45";
                        break;
                    case PadModel.Delta:
                    case PadModel.Alpha:
                        fontSize = "60";
                        break;
                }
                if (!TextBoxFontSize.Text.Equals(fontSize))
                {
                    TextBoxFontSize.Text = fontSize;
                    TextBoxFontSize_Leave(this, EventArgs.Empty);
                }
                if (CheckBoxBold.Checked == true)
                    CheckBoxBold.Checked = false;
                if (CheckBoxItalic.Checked == true)
                    CheckBoxItalic.Checked = false;
                if (CheckBoxUnderline.Checked == true)
                    CheckBoxUnderline.Checked = false;
                if (ButtonFontColor.BackColor != Color.Black)
                {
                    ButtonFontColor.BackColor = Color.Black;
                    try
                    {
                        _stPad.DisplaySetFontColor(Color.Black);
                    }
                    catch { }
                }

                switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                {
                    case PadModel.Sigma:
                    case PadModel.Zeta: 
                        // do all the following drawing operations in the background buffer
                        SetTarget(DisplayTarget.BackgroundBuffer);

                        // load button bitmaps and set hot spots
                        // "Cancel" button
                        Bitmap button = Emr.SignPad.Properties.Resources.Cancel_BW;
                        int x = 20;
                        int y = _stPad.DisplayHeight - button.Height - 7;
                        _stPad.DisplaySetImage(x, y, button);
                        _buttonCancelId = _stPad.SensorAddHotSpot(x, y, button.Width, button.Height);

                        // "Confirm" button
                        button = Emr.SignPad.Properties.Resources.OK_BW;
                        x = _stPad.DisplayWidth - button.Width - 20;
                        _stPad.DisplaySetImage(x, y, button);
                        _buttonConfirmId = _stPad.SensorAddHotSpot(x, y, button.Width, button.Height);

                        // display disclaimer
                        _stPad.DisplaySetTextInRect(10, 10, _stPad.DisplayWidth - 20, _stPad.DisplayHeight - 60, TextAlignment.Left, _disclaimer);
                        break;
                    case PadModel.Omega:
                    case PadModel.Gamma:
                    case PadModel.Delta:
                        if (_signPads[ListOfDevices.SelectedIndex].FastConnection)
                            // fast connection: do all drawing operations in the overlay buffer
                            _storeIdOverlay = SetTarget(DisplayTarget.OverlayBuffer);
                        else
                            // do all the following drawing operations in the permanent memory
                            _storeIdOverlay = SetTarget(_storeIdOverlay);

                        // load button bitmaps and set hot spots for toolbar
                        // "Cancel" button
                        button = Emr.SignPad.Properties.Resources.Cancel_RGB;
                        switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                        {
                            case PadModel.Omega:
                                x = 24;
                                break;
                            default:
                                x = 45;
                                break;
                        }
                        y = _stPad.DisplayHeight - button.Height - 14;
                        _stPad.DisplaySetImage(x, y, button);
                        _buttonCancelId = _stPad.SensorAddHotSpot(x, y, button.Width, button.Height);

                        // "Confirm" button
                        button = Emr.SignPad.Properties.Resources.OK_RGB;
                        switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                        {
                            case PadModel.Omega:
                                x = 234;
                                break;
                            case PadModel.Gamma:
                                x = 315;
                                break;
                            case PadModel.Delta:
                                x = 555;
                                break;
                        }
                        _stPad.DisplaySetImage(x, y, button);
                        _buttonConfirmId = _stPad.SensorAddHotSpot(x, y, button.Width, button.Height);

                        // Scroll buttons
                        button = Emr.SignPad.Properties.Resources.Scroll_RGB;
                        switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                        {
                            case PadModel.Omega:
                                x = 444;
                                break;
                            case PadModel.Gamma:
                                x = 585;
                                break;
                            case PadModel.Delta:
                                x = 1065;
                                break;
                        }
                        _stPad.DisplaySetImage(x, y, button);
                        _stPad.SensorAddScrollHotSpot(x, y, 66, 66, ScrollOption.ScrollDown);
                        x += 104;
                        _stPad.SensorAddScrollHotSpot(x, y, 66, 66, ScrollOption.ScrollUp);

                        if (!_signPads[ListOfDevices.SelectedIndex].FastConnection)
                        {
                            // do all the following drawing operations in the overlay buffer
                            SetTarget(DisplayTarget.OverlayBuffer);

                            // copy stored image to overlay buffer
                            _stPad.DisplaySetImageFromStore(_storeIdOverlay);
                        }

                        // do all the following drawing operations in the background buffer
                        SetTarget(DisplayTarget.BackgroundBuffer);

                        // draw disclaimer
                        x = 10;
                        y = 10;
                        int size = _stPad.DisplaySetTextInRect(x, y, _stPad.DisplayWidth - 20, _stPad.DisplayHeight - 80, TextAlignment.Left, _disclaimer);

                        // use font size of the disclaimer text
                        if (size != Int32.Parse(fontSize))
                        {
                            TextBoxFontSize.Text = String.Format("{0}", size);
                            SetFont();
                        }

                        // set scroll text
                        y = _stPad.DisplayHeight - 80;
                        _stPad.DisplaySetTextInRect(x, y, _stPad.DisplayWidth - 20, 100, TextAlignment.Left, "Congratulations! If you can read this text you have found the scroll buttons!");
                        if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Delta)
                        {
                            y += _stPad.DisplayHeight;
                            _stPad.DisplaySetTextInRect(x, y, _stPad.DisplayWidth - 20, 200, 0, "Doesn't the Delta have an impressive large image buffer?");
                            const int x2 = 320;
                            while ((y + _stPad.DisplayHeight) < _stPad.DisplayTargetHeight)
                            {
                                y += _stPad.DisplayHeight;
                                _stPad.DisplaySetTextInRect(x, y, _stPad.DisplayWidth - 20, 200, 0, String.Format("You've reached line {0} of {1}!", y, _stPad.DisplayTargetHeight));

                                if ((y + _stPad.DisplayHeight) < _stPad.DisplayTargetHeight)
                                {
                                    y += _stPad.DisplayHeight;
                                    _stPad.DisplaySetTextInRect(x2, y, _stPad.DisplayWidth - 2 * x2, 200, TextAlignment.CenterCenteredVertically, "Click me, I'm a scrollable button!");
                                    _stPad.SensorAddScrollHotSpot(x2, y, _stPad.DisplayWidth - 2 * x2, 200, ScrollOption.Scrollable);
                                }
                            }
                        }

                        // set end text
                        switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                        {
                            case PadModel.Omega:
                                y = _stPad.DisplayTargetHeight - 120;
                                break;
                            case PadModel.Gamma:
                                y = _stPad.DisplayTargetHeight - 140;
                                break;
                            case PadModel.Delta:
                                y = _stPad.DisplayTargetHeight - 160;
                                break;
                        }
                        _stPad.DisplaySetTextInRect(x, y, _stPad.DisplayWidth - 20, 60, TextAlignment.Left, "You have scrolled to the end of this text!");

                        // set overlay rect
                        y = _stPad.DisplayHeight - 80;
                        _stPad.DisplaySetOverlayRect(0, y, _stPad.DisplayWidth, 80);
                        break;
                }

                // do all drawing operations on the LCD
                SetTarget(DisplayTarget.ForegroundBuffer);

                // draw buffered image
                _stPad.DisplaySetImageFromStore(DisplayTarget.BackgroundBuffer);

                // set complete buffer for scrolling
                _stPad.SensorSetScrollArea(0, 0, 0, 0);

                if (_signPads[ListOfDevices.SelectedIndex].SupportsPenScrolling)
                {
                    // enable pen scrolling
                    _stPad.SensorSetPenScrollingEnabled(true);
                    CheckBoxPenScrolling.CheckState = CheckState.Checked;
                }

                ButtonRetry.Enabled = false;
                ButtonStop.Enabled = false;
                _processState = ProcessState.Terms;
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return true;
        }

        private bool StartAdvancedCapturing()
        {
            this.Cursor = Cursors.WaitCursor;
            LabelCapturedPoints.Text = "";

            try
            {
                bool success = true;
                if (_rsaOptions.ComputeHash)
                    // let pad compute hash 1 of selected buffer content
                    success = _rsaOptions.ComputeDisplayHash((DisplayTarget)ComboBoxTarget.SelectedIndex);
                else if (_rsaOptions.SignAfterCapture)
                    // set hash 1
                    success = _rsaOptions.SetHash1();
                if (!success)
                    return false;

                // start capturing
                _stPad.SignatureStart();
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            _rsaOptions.SignData = null;
            ButtonRetry.Enabled = true;
            ButtonStop.Enabled = true;
            GroupBoxScrolling.Enabled = false;
            GroupBoxSignWindow.Enabled = false;
            ComboBoxSampleRate.Enabled = false;
            if (CheckBoxLedDef.CheckState == CheckState.Checked)
            {
                CheckBoxLedY.CheckState = CheckState.Unchecked;
                CheckBoxLedG.CheckState = CheckState.Checked;
            }
            _processState = ProcessState.Capturing;

            return true;
        }

        private void CancelProcess(bool silent)
        {
            this.Cursor = Cursors.WaitCursor;
            LabelCapturedPoints.Text = "";

            try
            {
                if (_stPad.SignatureState)
                    // cancel capturing (this clears the LCD, too)
                    _stPad.SignatureCancel();
                else
                {
                    // disable pen scrolling
                    _stPad.SensorSetPenScrollingEnabled(false);
                    CheckBoxPenScrolling.CheckState = CheckState.Unchecked;

                    // erase LCD
                    _stPad.DisplayErase();
                }

                // clear all hot spots
                ClearHotSpots();
            }
            catch (STPadException exc)
            {
                if (!silent)
                {
                    MessageBox.Show(exc.Message, Application.ProductName);
                    return;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            ButtonStartCancel.Text = "Start";
            ButtonStartCancel.Enabled = true;
            ButtonRetry.Enabled = false;
            ButtonStop.Enabled = false;
            ButtonConfirm.Enabled = false;
            ButtonClearDisplay.Enabled = true;
            ButtonSettings.Enabled = true;
            GroupBoxScrolling.Enabled = true;
            GroupBoxSignWindow.Enabled = true;
            ComboBoxSampleRate.Enabled = true;
            ButtonRSA.Enabled = true;
            GroupBoxPadService.Enabled = true;
            if (_signPads != null)
                GroupBoxKeypadDemo.Enabled = _signPads[ListOfDevices.SelectedIndex].SupportsKeypad;
            if (CheckBoxLedDef.CheckState == CheckState.Checked)
            {
                CheckBoxLedY.CheckState = CheckState.Checked;
                CheckBoxLedG.CheckState = CheckState.Unchecked;
            }
            _processState = ProcessState.Start;
        }

        private void ButtonRetry_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LabelCapturedPoints.Visible = false;
            GroupBoxSignature.Enabled = false;
            GroupBoxSignData.Enabled = false;
            ButtonRSA.Enabled = false;
            if (CheckBoxLedDef.CheckState == CheckState.Checked)
            {
                CheckBoxLedY.CheckState = CheckState.Checked;
                CheckBoxLedG.CheckState = CheckState.Unchecked;
            }
            try
            {
                _stPad.SignatureRetry();
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
            if (CheckBoxLedDef.CheckState == CheckState.Checked)
            {
                CheckBoxLedY.CheckState = CheckState.Unchecked;
                CheckBoxLedG.CheckState = CheckState.Checked;
            }
            ButtonStop.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            // stop capturing
            try
            {
                int count = _stPad.SignatureStop();

                if (CheckBoxLedDef.CheckState == CheckState.Checked)
                {
                    CheckBoxLedY.CheckState = CheckState.Checked;
                    CheckBoxLedG.CheckState = CheckState.Unchecked;
                }

                // check if there are enough points for a valid signature
                CheckForValidSignature(count);

                ButtonStop.Enabled = false;
                ButtonRSA.Enabled = true;
                _processState = ProcessState.Stopped;
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            this.Cursor = Cursors.Default;
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (_processState == ProcessState.Terms)
            {
                // accept disclaimer and start capturing
                StartDefaultCapturing();
            }
            else
            {
                ConfirmCapturing();
                GetSignature();
                if (Signature != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void GetSignature()
        {
            int resolution = 300;
            int width = _width;
            int height = _heigth;
            int penWidth = 0;
            Color penColor = Color.Black;

            SignatureImageFlag options = SignatureImageFlag.None;
            if (!string.IsNullOrEmpty(_contentHash))
            {
                options = SignatureImageFlag.Timestamp;
            }
            try
            {
                Bitmap bitmap = _stPad.SignatureSaveAsStreamEx(resolution, width, height, penWidth, penColor, options);
                Signature = bitmap;
            }
            catch(Exception ex)
            {

            }
        }

        private bool StartDefaultCapturing()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // disable pen scrolling
                _stPad.SensorSetPenScrollingEnabled(false);
                CheckBoxPenScrolling.CheckState = CheckState.Unchecked;

                // erase display
                _stPad.DisplayErase();

                // clear hot spots
                ClearHotSpots();

                if (_signPads[ListOfDevices.SelectedIndex].FastConnection)
                {   // "fast" pad or connection
                    if (_rsaOptions.ComputeHash)
                        // do all drawing operations in the virtual "Display Hash" buffer
                        SetTarget(DisplayTarget.DisplayHashBuffer);
                    else
                        // do all drawing operations in the background buffer
                        SetTarget(DisplayTarget.BackgroundBuffer);
                }
                else
                {   // "slow" pad or connection: do all drawing operations in the permanent memory
                    // make sure that always the second permanent memory is used
                    if (_storeIdOverlay < 0)
                        _storeIdOverlay = SetTarget(_storeIdOverlay);
                    // set permanent memory as target
                    _storeIdSigning = SetTarget(_storeIdSigning);
                }

                // draw the bitmaps
                Bitmap bitmap = null;
                switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                {
                    case PadModel.Sigma:
                        bitmap = Emr.SignPad.Properties.Resources.Capture_Sigma;
                        break;
                    case PadModel.Zeta:
                        bitmap = Emr.SignPad.Properties.Resources.Capture_Zeta;
                        break;
                    case PadModel.Omega:
                        bitmap = Emr.SignPad.Properties.Resources.Capture_Omega;
                        break;
                    case PadModel.Gamma:
                        bitmap = Emr.SignPad.Properties.Resources.Capture_Gamma;
                        break;
                    case PadModel.Delta:
                        bitmap = Emr.SignPad.Properties.Resources.Capture_Delta;
                        break;
                    case PadModel.Alpha:
                        bitmap = Emr.SignPad.Properties.Resources.Capture_Alpha;
                        break;
                }
                _stPad.DisplaySetImage(0, 0, bitmap);

                if (!_signPads[ListOfDevices.SelectedIndex].FastConnection)
                {
                    if (_rsaOptions.ComputeHash)
                        // do all drawing operations in the virtual "Display Hash" buffer
                        SetTarget(DisplayTarget.DisplayHashBuffer);
                    else
                        // do all drawing operations in the background buffer
                        SetTarget(DisplayTarget.BackgroundBuffer);

                    // draw stored image
                    _stPad.DisplaySetImageFromStore(_storeIdSigning);
                }

                if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Alpha)
                    // draw disclaimer
                    _stPad.DisplaySetTextInRect(50, 250, _stPad.DisplayWidth - 100, 300, TextAlignment.Left, _disclaimer);

                int x = 0;
                int y = 0;
                int width = 0;
                int height = 0;
                if (_rsaOptions.ComputeHash)
                {
                    // set font
                    if (!ComboBoxFontList.Text.Equals("Arial"))
                        ComboBoxFontList.SelectedIndex = ComboBoxFontList.Items.IndexOf("Arial");
                    string fontSize = null;
                    switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                    {
                        case PadModel.Sigma:
                        case PadModel.Zeta:
                            fontSize = "20";
                            break;
                        case PadModel.Omega:
                        case PadModel.Gamma:
                            fontSize = "40";
                            break;
                        case PadModel.Delta:
                        case PadModel.Alpha:
                            fontSize = "60";
                            break;
                    }
                    if (!TextBoxFontSize.Text.Equals(fontSize))
                    {
                        TextBoxFontSize.Text = fontSize;
                        TextBoxFontSize_Leave(this, EventArgs.Empty);
                    }

                    // draw explanation
                    x = 50;
                    y = 160;
                    width = _stPad.DisplayWidth - 100;
                    height = 150;
                    switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                    {
                        case PadModel.Sigma:
                        case PadModel.Zeta:
                            x = 13;
                            y = 45;
                            width = _stPad.DisplayWidth - 20;
                            height = 65;
                            break;
                        case PadModel.Delta:
                            y = 160;
                            height = 300;
                            break;
                        case PadModel.Alpha:
                            y = 250;
                            height = 300;
                            break;
                    }
                    _stPad.DisplaySetTextInRect(x, y, width, height, TextAlignment.Left, _csText);

                    // draw timestamp
                    switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                    {
                        case PadModel.Sigma:
                        case PadModel.Zeta:
                            y = _stPad.DisplayHeight - 20;
                            break;
                        default:
                            y = _stPad.DisplayHeight - 90;
                            break;
                    }
                    if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Delta)
                    {
                        TextBoxFontSize.Text = "40";
                        TextBoxFontSize_Leave(this, EventArgs.Empty);
                    }
                    _stPad.DisplaySetText(x, y, TextAlignment.Left, DateTime.Now.ToLocalTime().ToString());
                }

                // do all drawing operations on the  LCD directly
                SetTarget(DisplayTarget.ForegroundBuffer);

                if (_rsaOptions.ComputeHash)
                {   // let pad compute hash 1 of display content
                    if (!_rsaOptions.ComputeDisplayHash(DisplayTarget.DisplayHashBuffer))
                        return false;
                }
                else
                {   // draw buffered image
                    _stPad.DisplaySetImageFromStore(DisplayTarget.BackgroundBuffer);

                    if (_rsaOptions.SignAfterCapture)
                    {   // set hash 1
                        if (!_rsaOptions.SetHash1())
                            return false;
                    }
                }

                // set default signature window
                x = y = width = height = 0;
                switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                {
                    case PadModel.Sigma:
                    case PadModel.Zeta:
                        y = 50;
                        break;
                    case PadModel.Omega:
                    case PadModel.Gamma:
                    case PadModel.Delta:
                        y = 100;
                        break;
                    case PadModel.Alpha:
                        x = 90;
                        y = 600;
                        width = 590;
                        height = 370;
                        break;
                }
                _stPad.SensorSetSignRect(x, y, width, height);

                // add default hotspots
                switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                {
                    case PadModel.Sigma:
                    case PadModel.Zeta:
                        x = 12;
                        y = 9;
                        width = 85;
                        height = 33;
                        break;
                    case PadModel.Omega:
                    case PadModel.Gamma:
                        x = 24;
                        y = 18;
                        width = 170;
                        height = 66;
                        break;
                    case PadModel.Delta:
                        x = 150;
                        y = 18;
                        width = 170;
                        height = 66;
                        break;
                    case PadModel.Alpha:
                        x = 30;
                        y = 30;
                        width = 80;
                        height = 80;
                        break;
                }
                _buttonCancelId = _stPad.SensorAddHotSpot(x, y, width, height);

                switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                {
                    case PadModel.Sigma:
                    case PadModel.Zeta:
                        x = 117;
                        break;
                    case PadModel.Omega:
                        x = 234;
                        break;
                    case PadModel.Gamma:
                        x = 315;
                        break;
                    case PadModel.Delta:
                        x = 555;
                        break;
                    case PadModel.Alpha:
                        x = 344;
                        break;
                }
                _buttonRetryId = _stPad.SensorAddHotSpot(x, y, width, height);

                switch (_signPads[ListOfDevices.SelectedIndex].PadModel)
                {
                    case PadModel.Sigma:
                    case PadModel.Zeta:
                        x = 222;
                        break;
                    case PadModel.Omega:
                        x = 444;
                        break;
                    case PadModel.Gamma:
                        x = 605;
                        break;
                    case PadModel.Delta:
                        x = 960;
                        break;
                    case PadModel.Alpha:
                        x = 658;
                        break;
                }
                _buttonConfirmId = _stPad.SensorAddHotSpot(x, y, width, height);

                // start capturing
                _stPad.SignatureStart();

                _rsaOptions.SignData = null;
                ButtonRetry.Enabled = true;
                ButtonStop.Enabled = true;
                ImageLcd.Visible = false;
                if (CheckBoxLedDef.CheckState == CheckState.Checked)
                {
                    CheckBoxLedY.CheckState = CheckState.Unchecked;
                    CheckBoxLedG.CheckState = CheckState.Checked;
                }
                _processState = ProcessState.Capturing;
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return true;
        }

        private void ConfirmCapturing()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // confirm capturing
                int count = _stPad.SignatureConfirm();

                // check if there are enough points for a valid signature
                CheckForValidSignature(count);

                //var aa = _stPad.SignatureSaveAsStreamEx();
                // clear hot spots
                ClearHotSpots();

                ButtonStartCancel.Text = "Start";
                ButtonRetry.Enabled = false;
                ButtonStop.Enabled = false;
                ButtonConfirm.Enabled = false;
                ButtonClearDisplay.Enabled = true;
                ButtonSettings.Enabled = true;
                GroupBoxScrolling.Enabled = true;
                GroupBoxSignWindow.Enabled = true;
                ComboBoxSampleRate.Enabled = true;
                ButtonRSA.Enabled = true;
                GroupBoxPadService.Enabled = true;
                if (_signPads != null)
                    GroupBoxKeypadDemo.Enabled = _signPads[ListOfDevices.SelectedIndex].SupportsKeypad;
                if (CheckBoxLedDef.CheckState == CheckState.Checked)
                {
                    CheckBoxLedY.CheckState = CheckState.Checked;
                    CheckBoxLedG.CheckState = CheckState.Unchecked;
                }
                _processState = ProcessState.Start;

                // sign data and verify signature
                if (_rsaOptions.SignAfterCapture)
                    _rsaOptions.Sign();

                // get & decrypt SignData
                if (_rsaOptions.UseSignData)
                    this.ShowSignData();
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            this.Cursor = Cursors.Default;
        }

        private void CheckForValidSignature(int pointCount)
        {
            float sampleRate = 500.0f;
            try
            {
                // get sample rate
                switch (_stPad.SensorGetSampleRateMode())
                {
                    case SampleRate.Hz125:
                        sampleRate = 125.0f;
                        break;
                    case SampleRate.Hz250:
                        sampleRate = 250.0f;
                        break;
                    case SampleRate.Hz280:
                        sampleRate = 280.0f;
                        break;
                    case SampleRate.Hz500:
                        sampleRate = 500.0f;
                        break;
                }
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            try
            {
                // check if there are enough points for a valid signature
                if (((float)pointCount / sampleRate) > 0.2f)
                {
                    LabelCapturedPoints.Text = String.Format("{0} points succesfully captured.", pointCount);

                    int left;
                    int top;
                    int right;
                    int bottom;
                    _stPad.SignatureGetBounds(out left, out top, out right, out bottom, 0);
                    LabelCapturedPoints.Text += String.Format("\nThe signature bounds are: {0}, {1}, {2}, {3}.", left, top, right, bottom);
                }
                else
                    LabelCapturedPoints.Text = String.Format("This is not a valid signature!\n({0} points captured.)", pointCount);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            LabelCapturedPoints.Left = stPadLibControl1.Left + stPadLibControl1.Width / 2 - LabelCapturedPoints.Width / 2;
            if (_signPads[ListOfDevices.SelectedIndex].PadModel == PadModel.Alpha)
                LabelCapturedPoints.Top = 570;
            GroupBoxSignature.Enabled = true;
            GroupBoxSignData.Enabled = true;
            LabelCapturedPoints.Visible = true;
        }

        #endregion
        //------------------------------------------------------------------------------------
        #region "Displayed Image"	

        private void ButtonSaveDisplayImage_Click(object sender, EventArgs e)
        {
            DialogSave.FileName = "";
            ImageFormat format;
            // set file format for dialog window
            switch (ComboBoxDisplayFileFormat.SelectedIndex)
            {
                case 0:
                    DialogSave.Filter = "TIFF (*.TIF)|*.tif";
                    format = ImageFormat.Tiff;
                    break;
                case 1:
                    DialogSave.Filter = "PNG (*.PNG)|*.png";
                    format = ImageFormat.Png;
                    break;
                case 2:
                    DialogSave.Filter = "Bitmap (*.BMP)|*.bmp";
                    format = ImageFormat.Bmp;
                    break;
                case 3:
                    DialogSave.Filter = "JPEG (*.JPG)|*.jpg";
                    format = ImageFormat.Jpeg;
                    break;
                case 4:
                    DialogSave.Filter = "GIF (*.GIF)|*.gif";
                    format = ImageFormat.Gif;
                    break;
                default:
                    return;
            }
            DialogSave.ShowDialog();
            if (DialogSave.FileName.Equals(""))
                return;

            this.Cursor = Cursors.WaitCursor;

            // save as file
            DisplayImageFlag options = (DisplayImageFlag)((int)CheckBoxEraseHotspots.CheckState + 2 * (int)CheckBoxWholeBuffer.CheckState + 4 * (int)CheckBoxCurrentTarget.CheckState);
            try
            {
                _stPad.DisplaySaveImageAsFile(DialogSave.FileName, format, options);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            this.Cursor = Cursors.Default;
        }

        private void ButtonShowDisplayImage_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            // get image as bitmap
            DisplayImageFlag options = (DisplayImageFlag)((int)CheckBoxEraseHotspots.CheckState + 2 * (int)CheckBoxWholeBuffer.CheckState + 4 * (int)CheckBoxCurrentTarget.CheckState);
            try
            {
                Bitmap bitmap = _stPad.DisplaySaveImageAsStream(options);

                // show image
                ImageView imageView = new ImageView();
                imageView.BackgroundImage = bitmap;
                imageView.ShowDialog();
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            this.Cursor = Cursors.Default;
        }

        #endregion
        //------------------------------------------------------------------------------------
        #region "Displayed Signature"

        private void ButtonSaveSignature_Click(object sender, EventArgs e)
        {
            // advanced options
            if (CheckBoxImageOptions.Checked)
            {
                if (_imageOptions == null)
                    _imageOptions = new ImageOptions();
                if (_imageOptions.ImageSizeOrg)
                {
                    _imageOptions.ImageWidth = _stPad.DisplayWidth;
                    _imageOptions.ImageHeight = _stPad.DisplayHeight;
                }
                if (ComboBoxFileFormat.SelectedIndex == 2)
                {
                    _imageOptions.Bitmap = 0;
                    _imageOptions.BitmapEnabled = false;
                }
                else
                    _imageOptions.BitmapEnabled = true;
                _imageOptions.ShowDialog();
            }

            DialogSave.FileName = "";
            ImageFormat format;
            SignatureImageFlag options = SignatureImageFlag.None;
            switch (ComboBoxFileFormat.SelectedIndex)
            {
                case 0:
                    DialogSave.Filter = "TIFF (*.TIF)|*.tif";
                    format = ImageFormat.Tiff;
                    break;
                case 1:
                    DialogSave.Filter = "PNG (*.PNG)|*.png";
                    format = ImageFormat.Png;
                    break;
                case 2:
                    DialogSave.Filter = "PNG (*.PNG)|*.png";
                    format = ImageFormat.Png;
                    options |= SignatureImageFlag.TransparentBack;
                    break;
                case 3:
                    DialogSave.Filter = "Bitmap (*.BMP)|*.bmp";
                    format = ImageFormat.Bmp;
                    break;
                case 4:
                    DialogSave.Filter = "JPEG (*.JPG)|*.jpg";
                    format = ImageFormat.Jpeg;
                    break;
                case 5:
                    DialogSave.Filter = "GIF (*.GIF)|*.gif";
                    format = ImageFormat.Gif;
                    break;
                default:
                    return;
            }

            DialogSave.ShowDialog();
            if (DialogSave.FileName.Equals(""))
                return;

            int resolution = 300;
            int width = 0;
            int height = 0;
            int penWidth = 0;
            Color penColor = Color.Black;

            if (CheckBoxImageOptions.Checked)
            {   // set options
                if (_imageOptions.Timestamp == 1)
                    // timestamp relative to display size
                    options |= SignatureImageFlag.Timestamp;
                else if (_imageOptions.Timestamp == 2)
                    // timestamp relative to image size
                    options |= SignatureImageFlag.Timestamp | SignatureImageFlag.TimestampRelToImage;
                if (_imageOptions.Bitmap == 1)
                    // include signing bitmap
                    options |= SignatureImageFlag.BackImage;
                else if (_imageOptions.Bitmap == 2)
                    // include signing bitmap & overlay
                    options |= SignatureImageFlag.BackImage | SignatureImageFlag.OverlayImage;
                else if (_imageOptions.Bitmap == 3)
                    // include current bitmap
                    options |= SignatureImageFlag.BackImage | SignatureImageFlag.CurrentImages;
                else if (_imageOptions.Bitmap == 4)
                    // include current bitmap & overlay
                    options |= SignatureImageFlag.BackImage | SignatureImageFlag.CurrentImages | SignatureImageFlag.OverlayImage;
                if (_imageOptions.EraseHotspots)
                    options |= SignatureImageFlag.ExcludeHotSpots;
                if (_imageOptions.DontCrop)
                    options |= SignatureImageFlag.DontCrop;
                if (_imageOptions.HorizontalAlignment == 0)
                    // left alignment
                    options |= SignatureImageFlag.AlignLeft;
                else if (_imageOptions.HorizontalAlignment == 2)
                    // right alignment
                    options |= SignatureImageFlag.AlignRight;
                if (_imageOptions.VerticalAlignment == 0)
                    // top alignment
                    options |= SignatureImageFlag.AlignTop;
                else if (_imageOptions.VerticalAlignment == 2)
                    // bottom alignment
                    options |= SignatureImageFlag.AlignBottom;
                if (!_imageOptions.VariableSmoothing)
                    // no smoothing
                    options |= SignatureImageFlag.DontSmooth;
                else
                    // smoothing
                    options |= SignatureImageFlag.Smooth;

                // set resolution
                if (_imageOptions.ImageResolutionOrg)
                    resolution = 0;
                else
                    resolution = _imageOptions.ImageResolution;

                // set width & height
                if (_imageOptions.ImageSizeOrg)
                {
                    width = 0;
                    height = 0;
                }
                else
                {
                    width = _imageOptions.ImageWidth;
                    height = _imageOptions.ImageHeight;
                }

                // set pen width
                penWidth = _imageOptions.PenWidth;
                if (_imageOptions.VariableBrightness)
                    penWidth *= -1;
                if (_imageOptions.VariableWidth)
                    options |= SignatureImageFlag.VariablePenWidth;

                // set pen color
                penColor = _imageOptions.PenColor;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                // save as file
                _stPad.SignatureSaveAsFileEx(DialogSave.FileName, resolution, width, height, format, penWidth, penColor, options);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            this.Cursor = Cursors.Default;
        }

        private void ButtonShowSignature_Click(object sender, EventArgs e)
        {
            // advanced options
            if (CheckBoxImageOptions.Checked)
            {
                if (_imageOptions == null)
                    _imageOptions = new ImageOptions();
                if (_imageOptions.ImageSizeOrg)
                {
                    _imageOptions.ImageWidth = _stPad.DisplayWidth;
                    _imageOptions.ImageHeight = _stPad.DisplayHeight;
                }
                if (ComboBoxFileFormat.SelectedIndex == 2)
                {
                    _imageOptions.Bitmap = 0;
                    _imageOptions.BitmapEnabled = false;
                }
                else
                    _imageOptions.BitmapEnabled = true;
                _imageOptions.ShowDialog();
            }

            SignatureImageFlag options = SignatureImageFlag.None;
            if (ComboBoxFileFormat.SelectedIndex == 2)
                options |= SignatureImageFlag.TransparentBack;

            int resolution = 300;
            int width = 0;
            int height = 0;
            int penWidth = 0;
            Color penColor = Color.Black;

            if (CheckBoxImageOptions.Checked)
            {   // set options
                if (_imageOptions.Timestamp == 1)
                    // timestamp relative to display size
                    options |= SignatureImageFlag.Timestamp;
                else if (_imageOptions.Timestamp == 2)
                    // timestamp relative to image size
                    options |= SignatureImageFlag.Timestamp | SignatureImageFlag.TimestampRelToImage;
                if (_imageOptions.Bitmap == 1)
                    // include signing bitmap
                    options |= SignatureImageFlag.BackImage;
                else if (_imageOptions.Bitmap == 2)
                    // include signing bitmap & overlay
                    options |= SignatureImageFlag.BackImage | SignatureImageFlag.OverlayImage;
                else if (_imageOptions.Bitmap == 3)
                    // include current bitmap
                    options |= SignatureImageFlag.BackImage | SignatureImageFlag.CurrentImages;
                else if (_imageOptions.Bitmap == 4)
                    // include current bitmap & overlay
                    options |= SignatureImageFlag.BackImage | SignatureImageFlag.CurrentImages | SignatureImageFlag.OverlayImage;
                if (_imageOptions.EraseHotspots)
                    options |= SignatureImageFlag.ExcludeHotSpots;
                if (_imageOptions.DontCrop)
                    options |= SignatureImageFlag.DontCrop;
                if (_imageOptions.HorizontalAlignment == 0)
                    // left alignment
                    options |= SignatureImageFlag.AlignLeft;
                else if (_imageOptions.HorizontalAlignment == 2)
                    // right alignment
                    options |= SignatureImageFlag.AlignRight;
                if (_imageOptions.VerticalAlignment == 0)
                    // top alignment
                    options |= SignatureImageFlag.AlignTop;
                else if (_imageOptions.VerticalAlignment == 2)
                    // bottom alignment
                    options |= SignatureImageFlag.AlignBottom;
                if (!_imageOptions.VariableSmoothing)
                    // no smoothing
                    options |= SignatureImageFlag.DontSmooth;
                else
                    // smoothing
                    options |= SignatureImageFlag.Smooth;

                // set resolution
                if (_imageOptions.ImageResolutionOrg)
                    resolution = 0;
                else
                    resolution = _imageOptions.ImageResolution;

                // set width & height
                if (_imageOptions.ImageSizeOrg)
                {
                    width = 0;
                    height = 0;
                }
                else
                {
                    width = _imageOptions.ImageWidth;
                    height = _imageOptions.ImageHeight;
                }

                // set pen width
                penWidth = _imageOptions.PenWidth;
                if (_imageOptions.VariableBrightness)
                    penWidth *= -1;
                if (_imageOptions.VariableWidth)
                    options |= SignatureImageFlag.VariablePenWidth;

                // set pen color
                penColor = _imageOptions.PenColor;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                // get image as bitmap
                Bitmap bitmap = _stPad.SignatureSaveAsStreamEx(resolution, width, height, penWidth, penColor, options);

                // display image
                ImageView imageView = new ImageView();
                imageView.BackgroundImage = bitmap;
                imageView.ShowDialog();
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }

            this.Cursor = Cursors.Default;
        }

        private void ButtonShowSignData_Click(object sender, EventArgs e)
        {
            this.ShowSignData();
        }

        private void ShowSignData()
        {
            SignView signView = new SignView();
            try
            {
                byte[] signData = null;
                signView.Timestamp = null;
                signView.Serial = null;
                signView.Key = null;
                signView.Firmware = null;
                signView.Hash1 = null;
                signView.Hash2 = null;

                if (_rsaOptions.UseSignData)
                {   // use RSA SignData
                    if (_rsaOptions.SignData == null)
                        // get SignData
                        _rsaOptions.SignData = _stPad.RSAGetSignData(SignDataGetFlag.None);

                    // decrypt & convert SignData and retrieve all extra data that can't be converted
                    SignDataDecryptFlag extra = SignDataDecryptFlag.All;
                    if (_rsaOptions.DemoCert)
                    {
                        SecureString securePassword = new SecureString();
                        try
                        {
                            securePassword.AppendChar('s');
                            securePassword.AppendChar('i');
                            securePassword.AppendChar('g');
                            securePassword.AppendChar('n');
                            securePassword.AppendChar('o');
                            securePassword.AppendChar('P');
                            securePassword.AppendChar('A');
                            securePassword.AppendChar('D');
                            securePassword.AppendChar('-');
                            securePassword.AppendChar('A');
                            securePassword.AppendChar('P');
                            securePassword.AppendChar('I');
                            //signData = _stPad.RSADecryptSignData(_rsaOptions.SignData, new X509Certificate2(Emr.SignPad.Properties.Resources.PrivateCert, securePassword, X509KeyStorageFlags.Exportable), securePassword, ref extra);
                        }
                        finally
                        {
                            securePassword.Dispose();
                        }
                    }
                    else
                    {
                        bool keepTrying = true;
                        do
                        {
                            try
                            {
                                signData = _stPad.RSADecryptSignData(_rsaOptions.SignData, _rsaOptions.CertPath, _decCertPassword, ref extra);
                                keepTrying = false;
                            }
                            catch (STPadException exc)
                            {
                                if (exc.ErrorCode != -89) // other error then wrong password
                                {
                                    MessageBox.Show(exc.Message, Application.ProductName);
                                    keepTrying = false;
                                }
                                else //  password is invalid, keep trying to get the right password
                                {
                                    _decCertPassword.Clear();
                                    string label = "Please enter decryption certificate password:";
                                    PasswordPrompt passwordWindow = new PasswordPrompt(label);
                                    passwordWindow.StartPosition = FormStartPosition.CenterParent;
                                    if (passwordWindow.ShowDialog(this) == DialogResult.OK)
                                        _decCertPassword = passwordWindow.PasswordHandover.Copy();
                                    else
                                        keepTrying = false;
                                }
                            }
                        } while (keepTrying);
                    }

                    // as we have just decrypted sign data which also decrypts / extracts and deposits all 
                    // extradata internally, a call for them without passing sign data and hash2Algo is sufficient
                    ExtraData extraData = _stPad.RSAExtractExtraData();

                    // timestamp
                    DateTime unset = new DateTime();
                    if (extraData.TimeStamp != unset)
                        signView.Timestamp = extraData.TimeStamp.ToLocalTime().ToString();

                    // serial number
                    if (extraData.SerialNumber != 0)
                        signView.Serial = extraData.SerialNumber.ToString();

                    // key source
                    switch (extraData.KeySource)
                    {
                        case KeySource.Internal:
                            signView.Key = "Key was generated inside of the pad";
                            break;
                        case KeySource.External:
                            signView.Key = "Key was generated outside of the pad";
                            break;
                        case KeySource.Factory:
                            signView.Key = "Key has been created while assembling the pad";
                            break;
                    }

                    // firmware version
                    if (extraData.Firmware != null)
                        signView.Firmware = extraData.Firmware.ToString();

                    // hash 1
                    if (extraData.Hash1 != null)
                    {
                        byte[] hash1 = extraData.Hash1.Data;
                        Int32 stringSize = (Int32)(hash1.Length * 1.5);   // length of array plus spaces
                        System.Text.StringBuilder sb = new System.Text.StringBuilder("", stringSize);
                        foreach (byte btValue in hash1)
                            sb.Append(btValue.ToString("X2") + " ");
                        signView.Hash1 = sb.ToString();
                    }

                    // hash 2
                    if (extraData.Hash2 != null)
                    {
                        byte[] hash2 = extraData.Hash2.Data;
                        Int32 stringSize = (Int32)(hash2.Length * 1.5);   // length of array plus spaces
                        System.Text.StringBuilder sb = new System.Text.StringBuilder("", stringSize);
                        foreach (byte btValue in hash2)
                            sb.Append(btValue.ToString("X2") + " ");
                        signView.Hash2 = sb.ToString();
                    }
                }
                else
                    // use traditional SignData
                    signData = _stPad.SignatureGetSignData();

                if (signData != null)
                {
                    signView.SignData = signData;
                    signView.SetDrawingMode(ComboBoxSignData.SelectedIndex);
                    signView.ShowDialog();
                }
            }
            catch (STPadException exc)
            {
                signView.Dispose();
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        #endregion
        //------------------------------------------------------------------------------------
        #region "RSA"

        private void ButtonRSA_Click(object sender, EventArgs e)
        {
            if (_rsaOptions.ShowDialog(this, _stPad) == DialogResult.Yes)
                this.StartCancel();
        }

        #endregion
        //------------------------------------------------------------------------------------
        #region "Events"

        private void STPad_DeviceDisconnected(object sender, DeviceDisconnectedEventArgs e)
        {
            DeviceDisconnectedEventHandler handler = new DeviceDisconnectedEventHandler(DeviceDisconnected);
            Invoke(handler, new object[] { sender, e });
        }

        private void DeviceDisconnected(object sender, DeviceDisconnectedEventArgs e)
        {
            if (e.index == ListOfDevices.SelectedIndex)
            {
                ResetAfterClose();

                ButtonSettings.Enabled = true;
                GroupBoxSignature.Enabled = false;
                GroupBoxSignData.Enabled = false;
                LabelCapturedPoints.Visible = false;
                _processState = ProcessState.Start;
                if (_padServiceMessageBox != null)
                    _padServiceMessageBox.Close();
                if ((_captureWindow != null) && !_captureWindow.IsDisposed)
                    _captureWindow.Close();

                try
                {
                    ClearHotSpots();
                }
                catch { }

                GetDevices();
            }
            else
            {
                ListOfDevices.Items.Insert(e.index, "(Disconn.)");
                ListOfDevices.Items.RemoveAt(e.index + 1);
            }
        }

        private void STPad_SensorHotSpotPressed(object sender, SensorHotSpotPressedEventArgs e)
        {
            SensorHotSpotPressedEventHandler handler = new SensorHotSpotPressedEventHandler(SensorHotSpotPressed);
            Invoke(handler, new object[] { sender, e });
        }

        private void SensorHotSpotPressed(object sender, SensorHotSpotPressedEventArgs e)
        {
            if ((ButtonSettings.Text.Equals("Advanced Settings")) && (!_keypadModeActive) && (e.hotSpotId > _keypadHotspotIndex_Clicked))
            {   // use default behaviour
                if (e.hotSpotId == _buttonCancelId)
                    ButtonStartCancel_Click(this, System.EventArgs.Empty);
                else if (e.hotSpotId == _buttonRetryId)
                    ButtonRetry_Click(this, System.EventArgs.Empty);
                else if (e.hotSpotId == _buttonConfirmId)
                    ButtonConfirm_Click(this, System.EventArgs.Empty);
                else
                    MessageBox.Show(String.Format("Hot Spot {0} clicked.", e.hotSpotId + 1), Application.ProductName);
            }
            else if (_keypadModeActive)   // Keypad-Demo
            {
                if (e.hotSpotId == _buttonConfirmId)
                {
                    KeypadGetEntries(0);
                    KeypadModeEndDefaults();
                }
                else if (e.hotSpotId == _buttonCancelId)
                {
                    KeypadClearEntries();
                    textBoxKeypadEntries.Text = _keypadTextboxText_Default;
                    KeypadModeEndDefaults();
                }
                else if (e.hotSpotId == _buttonRetryId)
                {
                    if (!(textBoxKeypadEntries.Text.Equals(_keypadTextboxText_Default)))
                    {
                        try
                        {
                            KeypadClearEntries();
                            _stPad.DisplayEraseRect(_keypadTextPosX, _keypadTextPosY, _keypadTextWidth, _keypadTextHeight);
                            textBoxKeypadEntries.Text = _keypadTextboxText_Default;
                        }
                        catch (STPadException exc)
                        {
                            MessageBox.Show(exc.Message, Application.ProductName);
                        }
                    }
                }
                else
                {
                    if (e.hotSpotId == _keypadHotspotIndex_Clicked)
                    {
                        // add *
                        if (textBoxKeypadEntries.Text.Equals(_keypadTextboxText_Default))
                            textBoxKeypadEntries.Text = "*";
                        else
                            textBoxKeypadEntries.Text += "*";
                        try
                        {
                            _stPad.DisplaySetTextInRect(_keypadTextPosX, _keypadTextPosY, _keypadTextWidth, _keypadTextHeight, TextAlignment.Center, textBoxKeypadEntries.Text);
                        }
                        catch (STPadException exc)
                        {
                            MessageBox.Show(exc.Message, Application.ProductName);
                        }
                    }
                    else if (e.hotSpotId == _keypadHotspotIndex_CacheFull)
                        MessageBox.Show(_keypadWarningWindow_CacheFull, "Hint");
                }
            }
            else if (e.hotSpotId == _keypadHotspotIndex_Clicked)   // Keypad-Hotspot pressed (set by hand-button from advanced tab)
                KeypadGetEntries(1);
            else if (e.hotSpotId == _keypadHotspotIndex_CacheFull)  // Keypad-Hotspot pressed (set by hand-button from advanced tab)
                MessageBox.Show(_keypadWarningWindow_CacheFull, "Hint");
            else // custom mode
                MessageBox.Show(String.Format("Hot Spot {0} clicked.", e.hotSpotId + 1), Application.ProductName);
        }

        private void STPad_SensorTimeoutOccured(object sender, SensorTimeoutOccuredEventArgs e)
        {
            SensorTimeoutOccuredEventHandler handler = new SensorTimeoutOccuredEventHandler(SensorTimeoutOccured);
            Invoke(handler, new object[] { sender, e });
        }

        private void SensorTimeoutOccured(object sender, SensorTimeoutOccuredEventArgs e)
        {
            MessageBox.Show(String.Format("Timeout occured! {0} points have been captured.", e.pointsCount), Application.ProductName);
            ButtonTimeoutStartStop.Text = "Start";
        }

        private void STPad_DisplayScrollPosChanged(object sender, DisplayScrollPosChangedEventArgs e)
        {
            DisplayScrollPosChangedEventHandler handler = new DisplayScrollPosChangedEventHandler(DisplayScrollPosChanged);
            Invoke(handler, new object[] { sender, e });
        }

        private void DisplayScrollPosChanged(object sender, DisplayScrollPosChangedEventArgs e)
        {
            LabelScrollPos.Text = String.Format("Scroll Position: {0} / {1}", e.xPos, e.yPos);
            if (ComboBoxTarget.SelectedIndex == 0)
            {
                _buttonScrolling = true;
                TextBoxScrollX.Text = String.Format("{0}", e.xPos);
                TextBoxScrollY.Text = String.Format("{0}", e.yPos);
                _buttonScrolling = false;
            }
        }

        private void STPad_SignatureDataReceived(object sender, SignatureDataReceivedEventArgs e)
        {
            SignatureDataReceivedEventHandler handler = new SignatureDataReceivedEventHandler(SignatureDataReceived);
            Invoke(handler, new object[] { sender, e });
        }

        private void SignatureDataReceived(object sender, SignatureDataReceivedEventArgs e)
        {
            LabelSignatureData.Text = String.Format("x: {0} (Sensor) / {1} (Display)\n" +
                                            "y: {2} (Sensor) / {3} (Display)\n" +
                                            "Pressure: {4}\n" +
                                            "Timestamp: {5}\n\n",
                                            e.xPos, _stPad.SignatureScaleToDisplay(e.xPos),
                                            e.yPos, _stPad.SignatureScaleToDisplay(e.yPos),
                                            e.pressure,
                                            e.timestamp);
        }

        #endregion

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _stPad.Dispose();
            if (_decCertPassword != null)
                _decCertPassword.Dispose();
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            MaskedTextBox enteredTextBox = sender as MaskedTextBox;
            if(enteredTextBox!=null)
                enteredTextBox.BeginInvoke(new MethodInvoker(enteredTextBox.SelectAll));
        }
    }
}
