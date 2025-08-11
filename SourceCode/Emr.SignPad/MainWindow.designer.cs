// Copyright 2000-2020, signotec GmbH, Ratingen, Germany, All Rights Reserved
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
// Version: 8.5.0.0
// Date:    2020-04-17

namespace Emr.SignPad
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.GroupBoxSignature = new System.Windows.Forms.GroupBox();
            this.GroupBoxSignData = new System.Windows.Forms.GroupBox();
            this.ButtonShowSignData = new System.Windows.Forms.Button();
            this.ComboBoxSignData = new System.Windows.Forms.ComboBox();
            this.GroupBoxImage = new System.Windows.Forms.GroupBox();
            this.CheckBoxImageOptions = new System.Windows.Forms.CheckBox();
            this.ButtonShowSignature = new System.Windows.Forms.Button();
            this.ButtonSaveSignature = new System.Windows.Forms.Button();
            this.ComboBoxFileFormat = new System.Windows.Forms.ComboBox();
            this.GroupBoxDisplayImage = new System.Windows.Forms.GroupBox();
            this.CheckBoxCurrentTarget = new System.Windows.Forms.CheckBox();
            this.CheckBoxWholeBuffer = new System.Windows.Forms.CheckBox();
            this.CheckBoxEraseHotspots = new System.Windows.Forms.CheckBox();
            this.ButtonShowDisplayImage = new System.Windows.Forms.Button();
            this.ComboBoxDisplayFileFormat = new System.Windows.Forms.ComboBox();
            this.ButtonSaveDisplayImage = new System.Windows.Forms.Button();
            this.GroupBoxSensor = new System.Windows.Forms.GroupBox();
            this.GroupBoxScrolling = new System.Windows.Forms.GroupBox();
            this.CheckBoxPenScrolling = new System.Windows.Forms.CheckBox();
            this.ButtonSetScrollArea = new System.Windows.Forms.Button();
            this.GroupBoxHotSpots = new System.Windows.Forms.GroupBox();
            this.ComboBoxHotspotMode = new System.Windows.Forms.ComboBox();
            this.ComboBoxHotspotId = new System.Windows.Forms.ComboBox();
            this.ButtonSetHotSpot = new System.Windows.Forms.Button();
            this.ComboBoxHotspotType = new System.Windows.Forms.ComboBox();
            this.GroupBoxSignWindow = new System.Windows.Forms.GroupBox();
            this.ButtonClearSignWin = new System.Windows.Forms.Button();
            this.ButtonSetSignWin = new System.Windows.Forms.Button();
            this.TextBoxSensorX = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxSensorY = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxSensorHeight = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxSensorWidth = new System.Windows.Forms.MaskedTextBox();
            this.ComboBoxSampleRate = new System.Windows.Forms.ComboBox();
            this.LabelSensorX = new System.Windows.Forms.Label();
            this.LabelSensorHeight = new System.Windows.Forms.Label();
            this.LabelSensorY = new System.Windows.Forms.Label();
            this.LabelSensorWidth = new System.Windows.Forms.Label();
            this.GroupBoxLedColor = new System.Windows.Forms.GroupBox();
            this.CheckBoxLedDef = new System.Windows.Forms.CheckBox();
            this.CheckBoxLedY = new System.Windows.Forms.CheckBox();
            this.CheckBoxLedG = new System.Windows.Forms.CheckBox();
            this.ButtonOpenSeparateWindow = new System.Windows.Forms.Button();
            this.GroupBoxWindow = new System.Windows.Forms.GroupBox();
            this.ButtonPenColor = new System.Windows.Forms.Button();
            this.ButtonRectColor = new System.Windows.Forms.Button();
            this.ButtonBackColor = new System.Windows.Forms.Button();
            this.ComboBoxMirror = new System.Windows.Forms.ComboBox();
            this.LabelRectangle = new System.Windows.Forms.Label();
            this.ComboBoxPenWidthControl = new System.Windows.Forms.ComboBox();
            this.LabelBackColor = new System.Windows.Forms.Label();
            this.LabelPenColor = new System.Windows.Forms.Label();
            this.ButtonSettings = new System.Windows.Forms.Button();
            this.ButtonClearDisplay = new System.Windows.Forms.Button();
            this.DialogSave = new System.Windows.Forms.SaveFileDialog();
            this.GroupBoxDrawing = new System.Windows.Forms.GroupBox();
            this.ButtonStByTimeoutMax = new System.Windows.Forms.Button();
            this.CheckBoxStByTimeout = new System.Windows.Forms.CheckBox();
            this.TextBoxStByTimeout = new System.Windows.Forms.MaskedTextBox();
            this.LabelStByTimeout = new System.Windows.Forms.Label();
            this.CheckBoxFixedFontSize = new System.Windows.Forms.CheckBox();
            this.LabelPageCount = new System.Windows.Forms.Label();
            this.CheckBoxBufferPage = new System.Windows.Forms.CheckBox();
            this.ComboBoxPDF = new System.Windows.Forms.ComboBox();
            this.TextBoxScale = new System.Windows.Forms.MaskedTextBox();
            this.LabelScale = new System.Windows.Forms.Label();
            this.LabelCropping = new System.Windows.Forms.Label();
            this.TextBoxSelectHeight = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxSelectWidth = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxSelectY = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxSelectX = new System.Windows.Forms.MaskedTextBox();
            this.LabelSelectX = new System.Windows.Forms.Label();
            this.LabelSelectY = new System.Windows.Forms.Label();
            this.LabelSelectWidth = new System.Windows.Forms.Label();
            this.LabelSelectHeight = new System.Windows.Forms.Label();
            this.ComboBoxUnit = new System.Windows.Forms.ComboBox();
            this.ComboBoxPage = new System.Windows.Forms.ComboBox();
            this.LabelSize = new System.Windows.Forms.Label();
            this.TextBoxScrollX = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxScrollY = new System.Windows.Forms.MaskedTextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.LabelTargetSize = new System.Windows.Forms.Label();
            this.ComboBoxTextAlign = new System.Windows.Forms.ComboBox();
            this.ButtonFontColor = new System.Windows.Forms.Button();
            this.ComboBoxTextRect = new System.Windows.Forms.ComboBox();
            this.CheckBoxItalic = new System.Windows.Forms.CheckBox();
            this.ComboBoxFontList = new System.Windows.Forms.ComboBox();
            this.CheckBoxBold = new System.Windows.Forms.CheckBox();
            this.CheckBoxUnderline = new System.Windows.Forms.CheckBox();
            this.TextBoxFontSize = new System.Windows.Forms.MaskedTextBox();
            this.LabelFontColor = new System.Windows.Forms.Label();
            this.LabelFontSize = new System.Windows.Forms.Label();
            this.TextBoxDrawHeight = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxDrawWidth = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxDrawY = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxDrawX = new System.Windows.Forms.MaskedTextBox();
            this.LabelDrawX = new System.Windows.Forms.Label();
            this.LabelDrawY = new System.Windows.Forms.Label();
            this.LabelDrawWidth = new System.Windows.Forms.Label();
            this.LabelDrawHeight = new System.Windows.Forms.Label();
            this.LabelTarget = new System.Windows.Forms.Label();
            this.ComboBoxTarget = new System.Windows.Forms.ComboBox();
            this.LabelSource = new System.Windows.Forms.Label();
            this.TextBoxText = new System.Windows.Forms.TextBox();
            this.ComboBoxSource = new System.Windows.Forms.ComboBox();
            this.ComboBoxImage = new System.Windows.Forms.ComboBox();
            this.ButtonDraw = new System.Windows.Forms.Button();
            this.ButtonDevCount = new System.Windows.Forms.Button();
            this.ButtonStartCancel = new System.Windows.Forms.Button();
            this.ButtonOpenClose = new System.Windows.Forms.Button();
            this.ListOfDevices = new System.Windows.Forms.ListBox();
            this.LabelCapturedPoints = new System.Windows.Forms.Label();
            this.LabelDisplay = new System.Windows.Forms.Label();
            this.LabelFirmware = new System.Windows.Forms.Label();
            this.LabelType = new System.Windows.Forms.Label();
            this.LabelSerial = new System.Windows.Forms.Label();
            this.ButtonConfirm = new System.Windows.Forms.Button();
            this.ButtonRetry = new System.Windows.Forms.Button();
            this.GroupBoxMain = new System.Windows.Forms.GroupBox();
            this.LabelSearchConfig = new System.Windows.Forms.Label();
            this.ButtonSearchConfig = new System.Windows.Forms.Button();
            this.LabelPort = new System.Windows.Forms.Label();
            this.DialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.DialogColor = new System.Windows.Forms.ColorDialog();
            this.GroupBoxTimeouts = new System.Windows.Forms.GroupBox();
            this.ButtonTimeoutStartStop = new System.Windows.Forms.Button();
            this.ComboBoxTimeout = new System.Windows.Forms.ComboBox();
            this.TextBoxTimeoutBefore = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxTimeoutAfter = new System.Windows.Forms.MaskedTextBox();
            this.LabelAfterAction = new System.Windows.Forms.Label();
            this.LabelTimeBefore = new System.Windows.Forms.Label();
            this.GroupBoxDisplay = new System.Windows.Forms.GroupBox();
            this.ComboBoxRotation = new System.Windows.Forms.ComboBox();
            this.LabelRotation = new System.Windows.Forms.Label();
            this.ComboBoxBacklight = new System.Windows.Forms.ComboBox();
            this.LabelBacklight = new System.Windows.Forms.Label();
            this.ComboBoxDisplayPenWidth = new System.Windows.Forms.ComboBox();
            this.ButtonDisplayPenColor = new System.Windows.Forms.Button();
            this.LabelDisplayPenColor = new System.Windows.Forms.Label();
            this.LabelScrollPos = new System.Windows.Forms.Label();
            this.LabelScrollSpeed = new System.Windows.Forms.Label();
            this.TextBoxScrollSpeed = new System.Windows.Forms.MaskedTextBox();
            this.ButtonRSA = new System.Windows.Forms.Button();
            this.ImageLed = new System.Windows.Forms.PictureBox();
            this.ImageLcd = new System.Windows.Forms.PictureBox();
            this.ImagePad = new System.Windows.Forms.PictureBox();
            this.stPadLibControl1 = new signotec.STPadLibNet.STPadLibControl();
            this.ButtonAdjustment = new System.Windows.Forms.Button();
            this.GroupBoxPadService = new System.Windows.Forms.GroupBox();
            this.CheckBoxNFCPerm = new System.Windows.Forms.CheckBox();
            this.CheckBoxNFC = new System.Windows.Forms.CheckBox();
            this.ButtonService = new System.Windows.Forms.Button();
            this.LabelSignatureData = new System.Windows.Forms.Label();
            this.buttonKeypadDemo = new System.Windows.Forms.Button();
            this.textBoxKeypadEntries = new System.Windows.Forms.TextBox();
            this.GroupBoxKeypadDemo = new System.Windows.Forms.GroupBox();
            this.GroupBoxSignature.SuspendLayout();
            this.GroupBoxSignData.SuspendLayout();
            this.GroupBoxImage.SuspendLayout();
            this.GroupBoxDisplayImage.SuspendLayout();
            this.GroupBoxSensor.SuspendLayout();
            this.GroupBoxScrolling.SuspendLayout();
            this.GroupBoxHotSpots.SuspendLayout();
            this.GroupBoxSignWindow.SuspendLayout();
            this.GroupBoxLedColor.SuspendLayout();
            this.GroupBoxWindow.SuspendLayout();
            this.GroupBoxDrawing.SuspendLayout();
            this.GroupBoxMain.SuspendLayout();
            this.GroupBoxTimeouts.SuspendLayout();
            this.GroupBoxDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageLed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageLcd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePad)).BeginInit();
            this.GroupBoxPadService.SuspendLayout();
            this.GroupBoxKeypadDemo.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxSignature
            // 
            this.GroupBoxSignature.Controls.Add(this.GroupBoxSignData);
            this.GroupBoxSignature.Controls.Add(this.GroupBoxImage);
            this.GroupBoxSignature.Enabled = false;
            this.GroupBoxSignature.Location = new System.Drawing.Point(532, 398);
            this.GroupBoxSignature.Name = "GroupBoxSignature";
            this.GroupBoxSignature.Size = new System.Drawing.Size(142, 206);
            this.GroupBoxSignature.TabIndex = 38;
            this.GroupBoxSignature.TabStop = false;
            this.GroupBoxSignature.Text = "Displayed Signature";
            // 
            // GroupBoxSignData
            // 
            this.GroupBoxSignData.Controls.Add(this.ButtonShowSignData);
            this.GroupBoxSignData.Controls.Add(this.ComboBoxSignData);
            this.GroupBoxSignData.Location = new System.Drawing.Point(6, 124);
            this.GroupBoxSignData.Name = "GroupBoxSignData";
            this.GroupBoxSignData.Size = new System.Drawing.Size(130, 73);
            this.GroupBoxSignData.TabIndex = 38;
            this.GroupBoxSignData.TabStop = false;
            this.GroupBoxSignData.Text = "SignData";
            // 
            // ButtonShowSignData
            // 
            this.ButtonShowSignData.Location = new System.Drawing.Point(27, 45);
            this.ButtonShowSignData.Name = "ButtonShowSignData";
            this.ButtonShowSignData.Size = new System.Drawing.Size(71, 22);
            this.ButtonShowSignData.TabIndex = 35;
            this.ButtonShowSignData.Text = "Show";
            this.ButtonShowSignData.UseVisualStyleBackColor = true;
            this.ButtonShowSignData.Click += new System.EventHandler(this.ButtonShowSignData_Click);
            // 
            // ComboBoxSignData
            // 
            this.ComboBoxSignData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSignData.FormattingEnabled = true;
            this.ComboBoxSignData.Items.AddRange(new object[] {
            "Default",
            "Incl. Time",
            "Debug"});
            this.ComboBoxSignData.Location = new System.Drawing.Point(6, 19);
            this.ComboBoxSignData.Name = "ComboBoxSignData";
            this.ComboBoxSignData.Size = new System.Drawing.Size(114, 21);
            this.ComboBoxSignData.TabIndex = 34;
            // 
            // GroupBoxImage
            // 
            this.GroupBoxImage.Controls.Add(this.CheckBoxImageOptions);
            this.GroupBoxImage.Controls.Add(this.ButtonShowSignature);
            this.GroupBoxImage.Controls.Add(this.ButtonSaveSignature);
            this.GroupBoxImage.Controls.Add(this.ComboBoxFileFormat);
            this.GroupBoxImage.Location = new System.Drawing.Point(6, 18);
            this.GroupBoxImage.Name = "GroupBoxImage";
            this.GroupBoxImage.Size = new System.Drawing.Size(130, 100);
            this.GroupBoxImage.TabIndex = 37;
            this.GroupBoxImage.TabStop = false;
            this.GroupBoxImage.Text = "Signature Image";
            // 
            // CheckBoxImageOptions
            // 
            this.CheckBoxImageOptions.AutoSize = true;
            this.CheckBoxImageOptions.Location = new System.Drawing.Point(6, 51);
            this.CheckBoxImageOptions.Name = "CheckBoxImageOptions";
            this.CheckBoxImageOptions.Size = new System.Drawing.Size(114, 17);
            this.CheckBoxImageOptions.TabIndex = 71;
            this.CheckBoxImageOptions.Text = "Advanced Options";
            this.CheckBoxImageOptions.UseVisualStyleBackColor = true;
            // 
            // ButtonShowSignature
            // 
            this.ButtonShowSignature.Location = new System.Drawing.Point(68, 74);
            this.ButtonShowSignature.Name = "ButtonShowSignature";
            this.ButtonShowSignature.Size = new System.Drawing.Size(59, 21);
            this.ButtonShowSignature.TabIndex = 38;
            this.ButtonShowSignature.Text = "Show";
            this.ButtonShowSignature.UseVisualStyleBackColor = true;
            this.ButtonShowSignature.Click += new System.EventHandler(this.ButtonShowSignature_Click);
            // 
            // ButtonSaveSignature
            // 
            this.ButtonSaveSignature.Location = new System.Drawing.Point(6, 74);
            this.ButtonSaveSignature.Name = "ButtonSaveSignature";
            this.ButtonSaveSignature.Size = new System.Drawing.Size(59, 21);
            this.ButtonSaveSignature.TabIndex = 37;
            this.ButtonSaveSignature.Text = "Save File";
            this.ButtonSaveSignature.UseVisualStyleBackColor = true;
            this.ButtonSaveSignature.Click += new System.EventHandler(this.ButtonSaveSignature_Click);
            // 
            // ComboBoxFileFormat
            // 
            this.ComboBoxFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFileFormat.FormattingEnabled = true;
            this.ComboBoxFileFormat.Items.AddRange(new object[] {
            "TIFF",
            "PNG",
            "PNG Alpha",
            "BMP",
            "JPEG",
            "GIF"});
            this.ComboBoxFileFormat.Location = new System.Drawing.Point(6, 19);
            this.ComboBoxFileFormat.Name = "ComboBoxFileFormat";
            this.ComboBoxFileFormat.Size = new System.Drawing.Size(114, 21);
            this.ComboBoxFileFormat.TabIndex = 17;
            // 
            // GroupBoxDisplayImage
            // 
            this.GroupBoxDisplayImage.Controls.Add(this.CheckBoxCurrentTarget);
            this.GroupBoxDisplayImage.Controls.Add(this.CheckBoxWholeBuffer);
            this.GroupBoxDisplayImage.Controls.Add(this.CheckBoxEraseHotspots);
            this.GroupBoxDisplayImage.Controls.Add(this.ButtonShowDisplayImage);
            this.GroupBoxDisplayImage.Controls.Add(this.ComboBoxDisplayFileFormat);
            this.GroupBoxDisplayImage.Controls.Add(this.ButtonSaveDisplayImage);
            this.GroupBoxDisplayImage.Enabled = false;
            this.GroupBoxDisplayImage.Location = new System.Drawing.Point(532, 273);
            this.GroupBoxDisplayImage.Name = "GroupBoxDisplayImage";
            this.GroupBoxDisplayImage.Size = new System.Drawing.Size(142, 119);
            this.GroupBoxDisplayImage.TabIndex = 30;
            this.GroupBoxDisplayImage.TabStop = false;
            this.GroupBoxDisplayImage.Text = "Displayed Image";
            // 
            // CheckBoxCurrentTarget
            // 
            this.CheckBoxCurrentTarget.AutoSize = true;
            this.CheckBoxCurrentTarget.Location = new System.Drawing.Point(6, 75);
            this.CheckBoxCurrentTarget.Name = "CheckBoxCurrentTarget";
            this.CheckBoxCurrentTarget.Size = new System.Drawing.Size(116, 17);
            this.CheckBoxCurrentTarget.TabIndex = 78;
            this.CheckBoxCurrentTarget.Text = "Use Current Target";
            this.CheckBoxCurrentTarget.UseVisualStyleBackColor = true;
            // 
            // CheckBoxWholeBuffer
            // 
            this.CheckBoxWholeBuffer.AutoSize = true;
            this.CheckBoxWholeBuffer.Location = new System.Drawing.Point(6, 58);
            this.CheckBoxWholeBuffer.Name = "CheckBoxWholeBuffer";
            this.CheckBoxWholeBuffer.Size = new System.Drawing.Size(133, 17);
            this.CheckBoxWholeBuffer.TabIndex = 77;
            this.CheckBoxWholeBuffer.Text = "Whole Buffer Contents";
            this.CheckBoxWholeBuffer.UseVisualStyleBackColor = true;
            // 
            // CheckBoxEraseHotspots
            // 
            this.CheckBoxEraseHotspots.AutoSize = true;
            this.CheckBoxEraseHotspots.Location = new System.Drawing.Point(6, 41);
            this.CheckBoxEraseHotspots.Name = "CheckBoxEraseHotspots";
            this.CheckBoxEraseHotspots.Size = new System.Drawing.Size(123, 17);
            this.CheckBoxEraseHotspots.TabIndex = 76;
            this.CheckBoxEraseHotspots.Text = "Erase Hotspot Areas";
            this.CheckBoxEraseHotspots.UseVisualStyleBackColor = true;
            // 
            // ButtonShowDisplayImage
            // 
            this.ButtonShowDisplayImage.Location = new System.Drawing.Point(71, 92);
            this.ButtonShowDisplayImage.Name = "ButtonShowDisplayImage";
            this.ButtonShowDisplayImage.Size = new System.Drawing.Size(59, 22);
            this.ButtonShowDisplayImage.TabIndex = 38;
            this.ButtonShowDisplayImage.Text = "Show";
            this.ButtonShowDisplayImage.UseVisualStyleBackColor = true;
            this.ButtonShowDisplayImage.Click += new System.EventHandler(this.ButtonShowDisplayImage_Click);
            // 
            // ComboBoxDisplayFileFormat
            // 
            this.ComboBoxDisplayFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxDisplayFileFormat.FormattingEnabled = true;
            this.ComboBoxDisplayFileFormat.Items.AddRange(new object[] {
            "TIFF",
            "PNG",
            "BMP",
            "JPEG",
            "GIF"});
            this.ComboBoxDisplayFileFormat.Location = new System.Drawing.Point(6, 17);
            this.ComboBoxDisplayFileFormat.Name = "ComboBoxDisplayFileFormat";
            this.ComboBoxDisplayFileFormat.Size = new System.Drawing.Size(123, 21);
            this.ComboBoxDisplayFileFormat.TabIndex = 17;
            // 
            // ButtonSaveDisplayImage
            // 
            this.ButtonSaveDisplayImage.Location = new System.Drawing.Point(6, 92);
            this.ButtonSaveDisplayImage.Name = "ButtonSaveDisplayImage";
            this.ButtonSaveDisplayImage.Size = new System.Drawing.Size(59, 22);
            this.ButtonSaveDisplayImage.TabIndex = 37;
            this.ButtonSaveDisplayImage.Text = "Save File";
            this.ButtonSaveDisplayImage.UseVisualStyleBackColor = true;
            this.ButtonSaveDisplayImage.Click += new System.EventHandler(this.ButtonSaveDisplayImage_Click);
            // 
            // GroupBoxSensor
            // 
            this.GroupBoxSensor.Controls.Add(this.GroupBoxScrolling);
            this.GroupBoxSensor.Controls.Add(this.GroupBoxHotSpots);
            this.GroupBoxSensor.Controls.Add(this.GroupBoxSignWindow);
            this.GroupBoxSensor.Controls.Add(this.TextBoxSensorX);
            this.GroupBoxSensor.Controls.Add(this.TextBoxSensorY);
            this.GroupBoxSensor.Controls.Add(this.TextBoxSensorHeight);
            this.GroupBoxSensor.Controls.Add(this.TextBoxSensorWidth);
            this.GroupBoxSensor.Controls.Add(this.ComboBoxSampleRate);
            this.GroupBoxSensor.Controls.Add(this.LabelSensorX);
            this.GroupBoxSensor.Controls.Add(this.LabelSensorHeight);
            this.GroupBoxSensor.Controls.Add(this.LabelSensorY);
            this.GroupBoxSensor.Controls.Add(this.LabelSensorWidth);
            this.GroupBoxSensor.Enabled = false;
            this.GroupBoxSensor.Location = new System.Drawing.Point(697, 315);
            this.GroupBoxSensor.Name = "GroupBoxSensor";
            this.GroupBoxSensor.Size = new System.Drawing.Size(151, 289);
            this.GroupBoxSensor.TabIndex = 33;
            this.GroupBoxSensor.TabStop = false;
            this.GroupBoxSensor.Text = "Configure Sensor";
            // 
            // GroupBoxScrolling
            // 
            this.GroupBoxScrolling.Controls.Add(this.CheckBoxPenScrolling);
            this.GroupBoxScrolling.Controls.Add(this.ButtonSetScrollArea);
            this.GroupBoxScrolling.Location = new System.Drawing.Point(6, 152);
            this.GroupBoxScrolling.Name = "GroupBoxScrolling";
            this.GroupBoxScrolling.Size = new System.Drawing.Size(139, 50);
            this.GroupBoxScrolling.TabIndex = 39;
            this.GroupBoxScrolling.TabStop = false;
            this.GroupBoxScrolling.Text = "Scrolling";
            // 
            // CheckBoxPenScrolling
            // 
            this.CheckBoxPenScrolling.AutoSize = true;
            this.CheckBoxPenScrolling.Location = new System.Drawing.Point(70, 23);
            this.CheckBoxPenScrolling.Name = "CheckBoxPenScrolling";
            this.CheckBoxPenScrolling.Size = new System.Drawing.Size(67, 17);
            this.CheckBoxPenScrolling.TabIndex = 30;
            this.CheckBoxPenScrolling.Text = "Pen Scr.";
            this.CheckBoxPenScrolling.UseVisualStyleBackColor = true;
            this.CheckBoxPenScrolling.CheckedChanged += new System.EventHandler(this.CheckBoxPenScrolling_CheckedChanged);
            // 
            // ButtonSetScrollArea
            // 
            this.ButtonSetScrollArea.Location = new System.Drawing.Point(6, 19);
            this.ButtonSetScrollArea.Name = "ButtonSetScrollArea";
            this.ButtonSetScrollArea.Size = new System.Drawing.Size(58, 23);
            this.ButtonSetScrollArea.TabIndex = 29;
            this.ButtonSetScrollArea.Text = "Set Area";
            this.ButtonSetScrollArea.UseVisualStyleBackColor = true;
            this.ButtonSetScrollArea.Click += new System.EventHandler(this.ButtonSetScrollArea_Click);
            // 
            // GroupBoxHotSpots
            // 
            this.GroupBoxHotSpots.Controls.Add(this.ComboBoxHotspotMode);
            this.GroupBoxHotSpots.Controls.Add(this.ComboBoxHotspotId);
            this.GroupBoxHotSpots.Controls.Add(this.ButtonSetHotSpot);
            this.GroupBoxHotSpots.Controls.Add(this.ComboBoxHotspotType);
            this.GroupBoxHotSpots.Location = new System.Drawing.Point(6, 207);
            this.GroupBoxHotSpots.Name = "GroupBoxHotSpots";
            this.GroupBoxHotSpots.Size = new System.Drawing.Size(139, 75);
            this.GroupBoxHotSpots.TabIndex = 39;
            this.GroupBoxHotSpots.TabStop = false;
            this.GroupBoxHotSpots.Text = "Hot Spots";
            // 
            // ComboBoxHotspotMode
            // 
            this.ComboBoxHotspotMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxHotspotMode.FormattingEnabled = true;
            this.ComboBoxHotspotMode.Items.AddRange(new object[] {
            "Inactive",
            "Active",
            "Invert off"});
            this.ComboBoxHotspotMode.Location = new System.Drawing.Point(64, 48);
            this.ComboBoxHotspotMode.Name = "ComboBoxHotspotMode";
            this.ComboBoxHotspotMode.Size = new System.Drawing.Size(71, 21);
            this.ComboBoxHotspotMode.TabIndex = 41;
            this.ComboBoxHotspotMode.SelectedIndexChanged += new System.EventHandler(this.ComboBoxHotspotMode_SelectedIndexChanged);
            // 
            // ComboBoxHotspotId
            // 
            this.ComboBoxHotspotId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxHotspotId.FormattingEnabled = true;
            this.ComboBoxHotspotId.Location = new System.Drawing.Point(6, 48);
            this.ComboBoxHotspotId.Name = "ComboBoxHotspotId";
            this.ComboBoxHotspotId.Size = new System.Drawing.Size(54, 21);
            this.ComboBoxHotspotId.TabIndex = 40;
            this.ComboBoxHotspotId.SelectedIndexChanged += new System.EventHandler(this.ComboBoxHotspotId_SelectedIndexChanged);
            // 
            // ButtonSetHotSpot
            // 
            this.ButtonSetHotSpot.Location = new System.Drawing.Point(92, 19);
            this.ButtonSetHotSpot.Name = "ButtonSetHotSpot";
            this.ButtonSetHotSpot.Size = new System.Drawing.Size(43, 23);
            this.ButtonSetHotSpot.TabIndex = 39;
            this.ButtonSetHotSpot.Text = "Add";
            this.ButtonSetHotSpot.UseVisualStyleBackColor = true;
            this.ButtonSetHotSpot.Click += new System.EventHandler(this.ButtonSetHotSpot_Click);
            // 
            // ComboBoxHotspotType
            // 
            this.ComboBoxHotspotType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxHotspotType.FormattingEnabled = true;
            this.ComboBoxHotspotType.Items.AddRange(new object[] {
            "Standard",
            "Scroll Down",
            "Scroll Up",
            "Clear All"});
            this.ComboBoxHotspotType.Location = new System.Drawing.Point(6, 21);
            this.ComboBoxHotspotType.Name = "ComboBoxHotspotType";
            this.ComboBoxHotspotType.Size = new System.Drawing.Size(80, 21);
            this.ComboBoxHotspotType.TabIndex = 38;
            this.ComboBoxHotspotType.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxHotspotType_SelectionChangeCommitted);
            // 
            // GroupBoxSignWindow
            // 
            this.GroupBoxSignWindow.Controls.Add(this.ButtonClearSignWin);
            this.GroupBoxSignWindow.Controls.Add(this.ButtonSetSignWin);
            this.GroupBoxSignWindow.Location = new System.Drawing.Point(6, 99);
            this.GroupBoxSignWindow.Name = "GroupBoxSignWindow";
            this.GroupBoxSignWindow.Size = new System.Drawing.Size(139, 50);
            this.GroupBoxSignWindow.TabIndex = 38;
            this.GroupBoxSignWindow.TabStop = false;
            this.GroupBoxSignWindow.Text = "Signature Window";
            // 
            // ButtonClearSignWin
            // 
            this.ButtonClearSignWin.Location = new System.Drawing.Point(73, 19);
            this.ButtonClearSignWin.Name = "ButtonClearSignWin";
            this.ButtonClearSignWin.Size = new System.Drawing.Size(60, 23);
            this.ButtonClearSignWin.TabIndex = 32;
            this.ButtonClearSignWin.Text = "Clear";
            this.ButtonClearSignWin.UseVisualStyleBackColor = true;
            this.ButtonClearSignWin.Click += new System.EventHandler(this.ButtonClearSignWin_Click);
            // 
            // ButtonSetSignWin
            // 
            this.ButtonSetSignWin.Location = new System.Drawing.Point(6, 19);
            this.ButtonSetSignWin.Name = "ButtonSetSignWin";
            this.ButtonSetSignWin.Size = new System.Drawing.Size(60, 23);
            this.ButtonSetSignWin.TabIndex = 29;
            this.ButtonSetSignWin.Text = "Set";
            this.ButtonSetSignWin.UseVisualStyleBackColor = true;
            this.ButtonSetSignWin.Click += new System.EventHandler(this.ButtonSetSignWin_Click);
            // 
            // TextBoxSensorX
            // 
            this.TextBoxSensorX.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSensorX.HidePromptOnLeave = true;
            this.TextBoxSensorX.Location = new System.Drawing.Point(23, 46);
            this.TextBoxSensorX.Mask = "#0000";
            this.TextBoxSensorX.Name = "TextBoxSensorX";
            this.TextBoxSensorX.PromptChar = ' ';
            this.TextBoxSensorX.Size = new System.Drawing.Size(43, 20);
            this.TextBoxSensorX.TabIndex = 17;
            this.TextBoxSensorX.Text = "0";
            this.TextBoxSensorX.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSensorX.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // TextBoxSensorY
            // 
            this.TextBoxSensorY.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSensorY.HidePromptOnLeave = true;
            this.TextBoxSensorY.Location = new System.Drawing.Point(92, 46);
            this.TextBoxSensorY.Mask = "#0000";
            this.TextBoxSensorY.Name = "TextBoxSensorY";
            this.TextBoxSensorY.PromptChar = ' ';
            this.TextBoxSensorY.Size = new System.Drawing.Size(43, 20);
            this.TextBoxSensorY.TabIndex = 22;
            this.TextBoxSensorY.Text = "0";
            this.TextBoxSensorY.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSensorY.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // TextBoxSensorHeight
            // 
            this.TextBoxSensorHeight.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSensorHeight.HidePromptOnLeave = true;
            this.TextBoxSensorHeight.Location = new System.Drawing.Point(92, 72);
            this.TextBoxSensorHeight.Mask = "#0000";
            this.TextBoxSensorHeight.Name = "TextBoxSensorHeight";
            this.TextBoxSensorHeight.PromptChar = ' ';
            this.TextBoxSensorHeight.Size = new System.Drawing.Size(43, 20);
            this.TextBoxSensorHeight.TabIndex = 26;
            this.TextBoxSensorHeight.Text = "160";
            this.TextBoxSensorHeight.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSensorHeight.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // TextBoxSensorWidth
            // 
            this.TextBoxSensorWidth.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSensorWidth.HidePromptOnLeave = true;
            this.TextBoxSensorWidth.Location = new System.Drawing.Point(23, 72);
            this.TextBoxSensorWidth.Mask = "#0000";
            this.TextBoxSensorWidth.Name = "TextBoxSensorWidth";
            this.TextBoxSensorWidth.PromptChar = ' ';
            this.TextBoxSensorWidth.Size = new System.Drawing.Size(43, 20);
            this.TextBoxSensorWidth.TabIndex = 24;
            this.TextBoxSensorWidth.Text = "320";
            this.TextBoxSensorWidth.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSensorWidth.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // ComboBoxSampleRate
            // 
            this.ComboBoxSampleRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSampleRate.FormattingEnabled = true;
            this.ComboBoxSampleRate.Items.AddRange(new object[] {
            "125 Hz",
            "250 Hz",
            "500 Hz",
            "280 Hz"});
            this.ComboBoxSampleRate.Location = new System.Drawing.Point(5, 19);
            this.ComboBoxSampleRate.Name = "ComboBoxSampleRate";
            this.ComboBoxSampleRate.Size = new System.Drawing.Size(139, 21);
            this.ComboBoxSampleRate.TabIndex = 0;
            this.ComboBoxSampleRate.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSampleRate_SelectedIndexChanged);
            // 
            // LabelSensorX
            // 
            this.LabelSensorX.AutoSize = true;
            this.LabelSensorX.Location = new System.Drawing.Point(6, 49);
            this.LabelSensorX.Name = "LabelSensorX";
            this.LabelSensorX.Size = new System.Drawing.Size(17, 13);
            this.LabelSensorX.TabIndex = 21;
            this.LabelSensorX.Text = "X:";
            // 
            // LabelSensorHeight
            // 
            this.LabelSensorHeight.AutoSize = true;
            this.LabelSensorHeight.Location = new System.Drawing.Point(73, 75);
            this.LabelSensorHeight.Name = "LabelSensorHeight";
            this.LabelSensorHeight.Size = new System.Drawing.Size(18, 13);
            this.LabelSensorHeight.TabIndex = 27;
            this.LabelSensorHeight.Text = "H:";
            // 
            // LabelSensorY
            // 
            this.LabelSensorY.AutoSize = true;
            this.LabelSensorY.Location = new System.Drawing.Point(73, 49);
            this.LabelSensorY.Name = "LabelSensorY";
            this.LabelSensorY.Size = new System.Drawing.Size(17, 13);
            this.LabelSensorY.TabIndex = 23;
            this.LabelSensorY.Text = "Y:";
            // 
            // LabelSensorWidth
            // 
            this.LabelSensorWidth.AutoSize = true;
            this.LabelSensorWidth.Location = new System.Drawing.Point(6, 75);
            this.LabelSensorWidth.Name = "LabelSensorWidth";
            this.LabelSensorWidth.Size = new System.Drawing.Size(21, 13);
            this.LabelSensorWidth.TabIndex = 25;
            this.LabelSensorWidth.Text = "W:";
            // 
            // GroupBoxLedColor
            // 
            this.GroupBoxLedColor.Controls.Add(this.CheckBoxLedDef);
            this.GroupBoxLedColor.Controls.Add(this.CheckBoxLedY);
            this.GroupBoxLedColor.Controls.Add(this.CheckBoxLedG);
            this.GroupBoxLedColor.Location = new System.Drawing.Point(863, 14);
            this.GroupBoxLedColor.Name = "GroupBoxLedColor";
            this.GroupBoxLedColor.Size = new System.Drawing.Size(249, 44);
            this.GroupBoxLedColor.TabIndex = 32;
            this.GroupBoxLedColor.TabStop = false;
            this.GroupBoxLedColor.Text = "LED Color";
            // 
            // CheckBoxLedDef
            // 
            this.CheckBoxLedDef.AutoSize = true;
            this.CheckBoxLedDef.Checked = true;
            this.CheckBoxLedDef.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxLedDef.Location = new System.Drawing.Point(8, 19);
            this.CheckBoxLedDef.Name = "CheckBoxLedDef";
            this.CheckBoxLedDef.Size = new System.Drawing.Size(82, 17);
            this.CheckBoxLedDef.TabIndex = 9;
            this.CheckBoxLedDef.Text = "Use Default";
            this.CheckBoxLedDef.UseVisualStyleBackColor = true;
            this.CheckBoxLedDef.Click += new System.EventHandler(this.CheckBoxLedDef_Click);
            // 
            // CheckBoxLedY
            // 
            this.CheckBoxLedY.AutoSize = true;
            this.CheckBoxLedY.Checked = true;
            this.CheckBoxLedY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxLedY.Enabled = false;
            this.CheckBoxLedY.Location = new System.Drawing.Point(120, 19);
            this.CheckBoxLedY.Name = "CheckBoxLedY";
            this.CheckBoxLedY.Size = new System.Drawing.Size(57, 17);
            this.CheckBoxLedY.TabIndex = 7;
            this.CheckBoxLedY.Text = "Yellow";
            this.CheckBoxLedY.UseVisualStyleBackColor = true;
            this.CheckBoxLedY.CheckedChanged += new System.EventHandler(this.CheckBoxLedY_CheckedChanged);
            this.CheckBoxLedY.Click += new System.EventHandler(this.CheckBoxLedY_Click);
            // 
            // CheckBoxLedG
            // 
            this.CheckBoxLedG.AutoSize = true;
            this.CheckBoxLedG.Enabled = false;
            this.CheckBoxLedG.Location = new System.Drawing.Point(177, 19);
            this.CheckBoxLedG.Name = "CheckBoxLedG";
            this.CheckBoxLedG.Size = new System.Drawing.Size(55, 17);
            this.CheckBoxLedG.TabIndex = 8;
            this.CheckBoxLedG.Text = "Green";
            this.CheckBoxLedG.UseVisualStyleBackColor = true;
            this.CheckBoxLedG.CheckedChanged += new System.EventHandler(this.CheckBoxLedG_CheckedChanged);
            this.CheckBoxLedG.Click += new System.EventHandler(this.CheckBoxLedG_Click);
            // 
            // ButtonOpenSeparateWindow
            // 
            this.ButtonOpenSeparateWindow.Location = new System.Drawing.Point(8, 145);
            this.ButtonOpenSeparateWindow.Name = "ButtonOpenSeparateWindow";
            this.ButtonOpenSeparateWindow.Size = new System.Drawing.Size(137, 23);
            this.ButtonOpenSeparateWindow.TabIndex = 93;
            this.ButtonOpenSeparateWindow.Text = "Open Separate Window";
            this.ButtonOpenSeparateWindow.Click += new System.EventHandler(this.ButtonOpenSeparateWindow_Click);
            // 
            // GroupBoxWindow
            // 
            this.GroupBoxWindow.Controls.Add(this.ButtonPenColor);
            this.GroupBoxWindow.Controls.Add(this.ButtonOpenSeparateWindow);
            this.GroupBoxWindow.Controls.Add(this.ButtonRectColor);
            this.GroupBoxWindow.Controls.Add(this.ButtonBackColor);
            this.GroupBoxWindow.Controls.Add(this.ComboBoxMirror);
            this.GroupBoxWindow.Controls.Add(this.LabelRectangle);
            this.GroupBoxWindow.Controls.Add(this.ComboBoxPenWidthControl);
            this.GroupBoxWindow.Controls.Add(this.LabelBackColor);
            this.GroupBoxWindow.Controls.Add(this.LabelPenColor);
            this.GroupBoxWindow.Location = new System.Drawing.Point(697, 13);
            this.GroupBoxWindow.Name = "GroupBoxWindow";
            this.GroupBoxWindow.Size = new System.Drawing.Size(151, 175);
            this.GroupBoxWindow.TabIndex = 27;
            this.GroupBoxWindow.TabStop = false;
            this.GroupBoxWindow.Text = "Configure Capture Window";
            // 
            // ButtonPenColor
            // 
            this.ButtonPenColor.BackColor = System.Drawing.Color.Blue;
            this.ButtonPenColor.Location = new System.Drawing.Point(69, 68);
            this.ButtonPenColor.Name = "ButtonPenColor";
            this.ButtonPenColor.Size = new System.Drawing.Size(23, 23);
            this.ButtonPenColor.TabIndex = 92;
            this.ButtonPenColor.UseVisualStyleBackColor = false;
            this.ButtonPenColor.Click += new System.EventHandler(this.ButtonPenColor_Click);
            // 
            // ButtonRectColor
            // 
            this.ButtonRectColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.ButtonRectColor.Location = new System.Drawing.Point(69, 42);
            this.ButtonRectColor.Name = "ButtonRectColor";
            this.ButtonRectColor.Size = new System.Drawing.Size(23, 23);
            this.ButtonRectColor.TabIndex = 91;
            this.ButtonRectColor.UseVisualStyleBackColor = false;
            this.ButtonRectColor.Click += new System.EventHandler(this.ButtonRectColor_Click);
            // 
            // ButtonBackColor
            // 
            this.ButtonBackColor.BackColor = System.Drawing.Color.White;
            this.ButtonBackColor.Location = new System.Drawing.Point(69, 16);
            this.ButtonBackColor.Name = "ButtonBackColor";
            this.ButtonBackColor.Size = new System.Drawing.Size(23, 23);
            this.ButtonBackColor.TabIndex = 90;
            this.ButtonBackColor.UseVisualStyleBackColor = false;
            this.ButtonBackColor.Click += new System.EventHandler(this.ButtonBackColor_Click);
            // 
            // ComboBoxMirror
            // 
            this.ComboBoxMirror.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxMirror.FormattingEnabled = true;
            this.ComboBoxMirror.Items.AddRange(new object[] {
            "Empty Mode",
            "Signature Mode",
            "Display Mode",
            "Zoom Mode",
            "Interactive Mode"});
            this.ComboBoxMirror.Location = new System.Drawing.Point(9, 94);
            this.ComboBoxMirror.Name = "ComboBoxMirror";
            this.ComboBoxMirror.Size = new System.Drawing.Size(135, 21);
            this.ComboBoxMirror.TabIndex = 29;
            this.ComboBoxMirror.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMirror_SelectedIndexChanged);
            // 
            // LabelRectangle
            // 
            this.LabelRectangle.AutoSize = true;
            this.LabelRectangle.Location = new System.Drawing.Point(6, 47);
            this.LabelRectangle.Name = "LabelRectangle";
            this.LabelRectangle.Size = new System.Drawing.Size(60, 13);
            this.LabelRectangle.TabIndex = 28;
            this.LabelRectangle.Text = "Rect Color:";
            // 
            // ComboBoxPenWidthControl
            // 
            this.ComboBoxPenWidthControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxPenWidthControl.FormattingEnabled = true;
            this.ComboBoxPenWidthControl.Items.AddRange(new object[] {
            "Variable Pressure",
            "1 px fix Pressure",
            "2 px fix Pressure",
            "3 px fix Pressure",
            "4 px fix Pressure",
            "5 px fix Pressure",
            "1 px var Pressure",
            "2 px var Pressure",
            "3 px var Pressure",
            "4 px var Pressure",
            "5 px var Pressure"});
            this.ComboBoxPenWidthControl.Location = new System.Drawing.Point(9, 120);
            this.ComboBoxPenWidthControl.Name = "ComboBoxPenWidthControl";
            this.ComboBoxPenWidthControl.Size = new System.Drawing.Size(135, 21);
            this.ComboBoxPenWidthControl.TabIndex = 22;
            this.ComboBoxPenWidthControl.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPenWidthControl_SelectedIndexChanged);
            // 
            // LabelBackColor
            // 
            this.LabelBackColor.AutoSize = true;
            this.LabelBackColor.Location = new System.Drawing.Point(6, 21);
            this.LabelBackColor.Name = "LabelBackColor";
            this.LabelBackColor.Size = new System.Drawing.Size(62, 13);
            this.LabelBackColor.TabIndex = 25;
            this.LabelBackColor.Text = "Back Color:";
            // 
            // LabelPenColor
            // 
            this.LabelPenColor.AutoSize = true;
            this.LabelPenColor.Location = new System.Drawing.Point(6, 73);
            this.LabelPenColor.Name = "LabelPenColor";
            this.LabelPenColor.Size = new System.Drawing.Size(56, 13);
            this.LabelPenColor.TabIndex = 23;
            this.LabelPenColor.Text = "Pen Color:";
            // 
            // ButtonSettings
            // 
            this.ButtonSettings.Location = new System.Drawing.Point(562, 9);
            this.ButtonSettings.Name = "ButtonSettings";
            this.ButtonSettings.Size = new System.Drawing.Size(112, 49);
            this.ButtonSettings.TabIndex = 26;
            this.ButtonSettings.Text = "Advanced Settings";
            this.ButtonSettings.UseVisualStyleBackColor = true;
            this.ButtonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // ButtonClearDisplay
            // 
            this.ButtonClearDisplay.Enabled = false;
            this.ButtonClearDisplay.Location = new System.Drawing.Point(152, 47);
            this.ButtonClearDisplay.Name = "ButtonClearDisplay";
            this.ButtonClearDisplay.Size = new System.Drawing.Size(100, 23);
            this.ButtonClearDisplay.TabIndex = 35;
            this.ButtonClearDisplay.Text = "Clear Display";
            this.ButtonClearDisplay.UseVisualStyleBackColor = true;
            this.ButtonClearDisplay.Click += new System.EventHandler(this.ButtonClearDisplay_Click);
            // 
            // DialogSave
            // 
            this.DialogSave.FileName = " ";
            this.DialogSave.Filter = "\"Bitmap (*.BMP)|*.bmp|GI Format (*.GIF)|*.gif|JPEG Format (*.JPG)|*.jpg|PNG Forma" +
    "t (*.PNG)|*.png|TIF Format (*.TIF)|*.tif\"";
            this.DialogSave.FilterIndex = 5;
            this.DialogSave.Title = "Save";
            // 
            // GroupBoxDrawing
            // 
            this.GroupBoxDrawing.Controls.Add(this.ButtonStByTimeoutMax);
            this.GroupBoxDrawing.Controls.Add(this.CheckBoxStByTimeout);
            this.GroupBoxDrawing.Controls.Add(this.TextBoxStByTimeout);
            this.GroupBoxDrawing.Controls.Add(this.LabelStByTimeout);
            this.GroupBoxDrawing.Controls.Add(this.CheckBoxFixedFontSize);
            this.GroupBoxDrawing.Controls.Add(this.LabelPageCount);
            this.GroupBoxDrawing.Controls.Add(this.CheckBoxBufferPage);
            this.GroupBoxDrawing.Controls.Add(this.ComboBoxPDF);
            this.GroupBoxDrawing.Controls.Add(this.TextBoxScale);
            this.GroupBoxDrawing.Controls.Add(this.LabelScale);
            this.GroupBoxDrawing.Controls.Add(this.LabelCropping);
            this.GroupBoxDrawing.Controls.Add(this.TextBoxSelectHeight);
            this.GroupBoxDrawing.Controls.Add(this.TextBoxSelectWidth);
            this.GroupBoxDrawing.Controls.Add(this.TextBoxSelectY);
            this.GroupBoxDrawing.Controls.Add(this.TextBoxSelectX);
            this.GroupBoxDrawing.Controls.Add(this.LabelSelectX);
            this.GroupBoxDrawing.Controls.Add(this.LabelSelectY);
            this.GroupBoxDrawing.Controls.Add(this.LabelSelectWidth);
            this.GroupBoxDrawing.Controls.Add(this.LabelSelectHeight);
            this.GroupBoxDrawing.Controls.Add(this.ComboBoxUnit);
            this.GroupBoxDrawing.Controls.Add(this.ComboBoxPage);
            this.GroupBoxDrawing.Controls.Add(this.LabelSize);
            this.GroupBoxDrawing.Controls.Add(this.TextBoxScrollX);
            this.GroupBoxDrawing.Controls.Add(this.label2);
            this.GroupBoxDrawing.Controls.Add(this.TextBoxScrollY);
            this.GroupBoxDrawing.Controls.Add(this.Label1);
            this.GroupBoxDrawing.Controls.Add(this.LabelTargetSize);
            this.GroupBoxDrawing.Controls.Add(this.ComboBoxTextAlign);
            this.GroupBoxDrawing.Controls.Add(this.ButtonFontColor);
            this.GroupBoxDrawing.Controls.Add(this.ComboBoxTextRect);
            this.GroupBoxDrawing.Controls.Add(this.CheckBoxItalic);
            this.GroupBoxDrawing.Controls.Add(this.ComboBoxFontList);
            this.GroupBoxDrawing.Controls.Add(this.CheckBoxBold);
            this.GroupBoxDrawing.Controls.Add(this.CheckBoxUnderline);
            this.GroupBoxDrawing.Controls.Add(this.TextBoxFontSize);
            this.GroupBoxDrawing.Controls.Add(this.LabelFontColor);
            this.GroupBoxDrawing.Controls.Add(this.LabelFontSize);
            this.GroupBoxDrawing.Controls.Add(this.TextBoxDrawHeight);
            this.GroupBoxDrawing.Controls.Add(this.TextBoxDrawWidth);
            this.GroupBoxDrawing.Controls.Add(this.TextBoxDrawY);
            this.GroupBoxDrawing.Controls.Add(this.TextBoxDrawX);
            this.GroupBoxDrawing.Controls.Add(this.LabelDrawX);
            this.GroupBoxDrawing.Controls.Add(this.LabelDrawY);
            this.GroupBoxDrawing.Controls.Add(this.LabelDrawWidth);
            this.GroupBoxDrawing.Controls.Add(this.LabelDrawHeight);
            this.GroupBoxDrawing.Controls.Add(this.LabelTarget);
            this.GroupBoxDrawing.Controls.Add(this.ComboBoxTarget);
            this.GroupBoxDrawing.Controls.Add(this.LabelSource);
            this.GroupBoxDrawing.Controls.Add(this.TextBoxText);
            this.GroupBoxDrawing.Controls.Add(this.ComboBoxSource);
            this.GroupBoxDrawing.Controls.Add(this.ComboBoxImage);
            this.GroupBoxDrawing.Controls.Add(this.ButtonDraw);
            this.GroupBoxDrawing.Enabled = false;
            this.GroupBoxDrawing.Location = new System.Drawing.Point(863, 121);
            this.GroupBoxDrawing.Name = "GroupBoxDrawing";
            this.GroupBoxDrawing.Size = new System.Drawing.Size(249, 483);
            this.GroupBoxDrawing.TabIndex = 10;
            this.GroupBoxDrawing.TabStop = false;
            this.GroupBoxDrawing.Text = "Drawing";
            // 
            // ButtonStByTimeoutMax
            // 
            this.ButtonStByTimeoutMax.Location = new System.Drawing.Point(208, 453);
            this.ButtonStByTimeoutMax.Name = "ButtonStByTimeoutMax";
            this.ButtonStByTimeoutMax.Size = new System.Drawing.Size(35, 23);
            this.ButtonStByTimeoutMax.TabIndex = 144;
            this.ButtonStByTimeoutMax.Text = "Max";
            this.ButtonStByTimeoutMax.UseVisualStyleBackColor = true;
            this.ButtonStByTimeoutMax.Click += new System.EventHandler(this.ButtonStByTimeoutMax_Click);
            // 
            // CheckBoxStByTimeout
            // 
            this.CheckBoxStByTimeout.AutoSize = true;
            this.CheckBoxStByTimeout.Location = new System.Drawing.Point(6, 458);
            this.CheckBoxStByTimeout.Name = "CheckBoxStByTimeout";
            this.CheckBoxStByTimeout.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxStByTimeout.TabIndex = 143;
            this.CheckBoxStByTimeout.UseVisualStyleBackColor = true;
            this.CheckBoxStByTimeout.CheckedChanged += new System.EventHandler(this.CheckBoxStByTimeout_CheckedChanged);
            // 
            // TextBoxStByTimeout
            // 
            this.TextBoxStByTimeout.Location = new System.Drawing.Point(161, 455);
            this.TextBoxStByTimeout.Mask = "000000";
            this.TextBoxStByTimeout.Name = "TextBoxStByTimeout";
            this.TextBoxStByTimeout.PromptChar = ' ';
            this.TextBoxStByTimeout.Size = new System.Drawing.Size(44, 20);
            this.TextBoxStByTimeout.TabIndex = 142;
            this.TextBoxStByTimeout.Text = "0";
            // 
            // LabelStByTimeout
            // 
            this.LabelStByTimeout.AutoSize = true;
            this.LabelStByTimeout.Location = new System.Drawing.Point(19, 458);
            this.LabelStByTimeout.Name = "LabelStByTimeout";
            this.LabelStByTimeout.Size = new System.Drawing.Size(144, 13);
            this.LabelStByTimeout.TabIndex = 141;
            this.LabelStByTimeout.Text = "Standby Image Timeout (ms):";
            // 
            // CheckBoxFixedFontSize
            // 
            this.CheckBoxFixedFontSize.AutoSize = true;
            this.CheckBoxFixedFontSize.Enabled = false;
            this.CheckBoxFixedFontSize.Location = new System.Drawing.Point(204, 217);
            this.CheckBoxFixedFontSize.Name = "CheckBoxFixedFontSize";
            this.CheckBoxFixedFontSize.Size = new System.Drawing.Size(39, 17);
            this.CheckBoxFixedFontSize.TabIndex = 140;
            this.CheckBoxFixedFontSize.Text = "Fix";
            this.CheckBoxFixedFontSize.UseVisualStyleBackColor = true;
            // 
            // LabelPageCount
            // 
            this.LabelPageCount.AutoSize = true;
            this.LabelPageCount.Location = new System.Drawing.Point(117, 103);
            this.LabelPageCount.Name = "LabelPageCount";
            this.LabelPageCount.Size = new System.Drawing.Size(22, 13);
            this.LabelPageCount.TabIndex = 139;
            this.LabelPageCount.Text = "of -";
            // 
            // CheckBoxBufferPage
            // 
            this.CheckBoxBufferPage.AutoSize = true;
            this.CheckBoxBufferPage.Location = new System.Drawing.Point(116, 190);
            this.CheckBoxBufferPage.Name = "CheckBoxBufferPage";
            this.CheckBoxBufferPage.Size = new System.Drawing.Size(127, 17);
            this.CheckBoxBufferPage.TabIndex = 138;
            this.CheckBoxBufferPage.Text = "Buffer rendered Page";
            this.CheckBoxBufferPage.UseVisualStyleBackColor = true;
            // 
            // ComboBoxPDF
            // 
            this.ComboBoxPDF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxPDF.Enabled = false;
            this.ComboBoxPDF.FormattingEnabled = true;
            this.ComboBoxPDF.Items.AddRange(new object[] {
            "Use PDF from File",
            "Use PDF from URL"});
            this.ComboBoxPDF.Location = new System.Drawing.Point(6, 73);
            this.ComboBoxPDF.Name = "ComboBoxPDF";
            this.ComboBoxPDF.Size = new System.Drawing.Size(237, 21);
            this.ComboBoxPDF.TabIndex = 137;
            this.ComboBoxPDF.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxPDF_SelectionChangeCommitted);
            // 
            // TextBoxScale
            // 
            this.TextBoxScale.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxScale.HidePromptOnLeave = true;
            this.TextBoxScale.Location = new System.Drawing.Point(40, 188);
            this.TextBoxScale.Mask = "000";
            this.TextBoxScale.Name = "TextBoxScale";
            this.TextBoxScale.PromptChar = ' ';
            this.TextBoxScale.Size = new System.Drawing.Size(27, 20);
            this.TextBoxScale.TabIndex = 133;
            this.TextBoxScale.Text = "100";
            this.TextBoxScale.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxScale.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // LabelScale
            // 
            this.LabelScale.AutoSize = true;
            this.LabelScale.Location = new System.Drawing.Point(4, 191);
            this.LabelScale.Name = "LabelScale";
            this.LabelScale.Size = new System.Drawing.Size(78, 13);
            this.LabelScale.TabIndex = 134;
            this.LabelScale.Text = "Scale:           %";
            // 
            // LabelCropping
            // 
            this.LabelCropping.AutoSize = true;
            this.LabelCropping.Location = new System.Drawing.Point(6, 144);
            this.LabelCropping.Name = "LabelCropping";
            this.LabelCropping.Size = new System.Drawing.Size(88, 13);
            this.LabelCropping.TabIndex = 131;
            this.LabelCropping.Text = "Cropping (Pixels):";
            // 
            // TextBoxSelectHeight
            // 
            this.TextBoxSelectHeight.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSelectHeight.HidePromptOnLeave = true;
            this.TextBoxSelectHeight.Location = new System.Drawing.Point(203, 162);
            this.TextBoxSelectHeight.Mask = "#0000";
            this.TextBoxSelectHeight.Name = "TextBoxSelectHeight";
            this.TextBoxSelectHeight.PromptChar = ' ';
            this.TextBoxSelectHeight.Size = new System.Drawing.Size(40, 20);
            this.TextBoxSelectHeight.TabIndex = 128;
            this.TextBoxSelectHeight.Text = "160";
            this.TextBoxSelectHeight.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSelectHeight.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // TextBoxSelectWidth
            // 
            this.TextBoxSelectWidth.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSelectWidth.HidePromptOnLeave = true;
            this.TextBoxSelectWidth.Location = new System.Drawing.Point(141, 162);
            this.TextBoxSelectWidth.Mask = "#0000";
            this.TextBoxSelectWidth.Name = "TextBoxSelectWidth";
            this.TextBoxSelectWidth.PromptChar = ' ';
            this.TextBoxSelectWidth.Size = new System.Drawing.Size(40, 20);
            this.TextBoxSelectWidth.TabIndex = 126;
            this.TextBoxSelectWidth.Text = "320";
            this.TextBoxSelectWidth.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSelectWidth.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // TextBoxSelectY
            // 
            this.TextBoxSelectY.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSelectY.HidePromptOnLeave = true;
            this.TextBoxSelectY.Location = new System.Drawing.Point(78, 162);
            this.TextBoxSelectY.Mask = "#0000";
            this.TextBoxSelectY.Name = "TextBoxSelectY";
            this.TextBoxSelectY.PromptChar = ' ';
            this.TextBoxSelectY.Size = new System.Drawing.Size(40, 20);
            this.TextBoxSelectY.TabIndex = 124;
            this.TextBoxSelectY.Text = "0";
            this.TextBoxSelectY.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSelectY.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // TextBoxSelectX
            // 
            this.TextBoxSelectX.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSelectX.HidePromptOnLeave = true;
            this.TextBoxSelectX.Location = new System.Drawing.Point(22, 162);
            this.TextBoxSelectX.Mask = "#0000";
            this.TextBoxSelectX.Name = "TextBoxSelectX";
            this.TextBoxSelectX.PromptChar = ' ';
            this.TextBoxSelectX.Size = new System.Drawing.Size(40, 20);
            this.TextBoxSelectX.TabIndex = 122;
            this.TextBoxSelectX.Text = "0";
            this.TextBoxSelectX.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxSelectX.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // LabelSelectX
            // 
            this.LabelSelectX.AutoSize = true;
            this.LabelSelectX.Location = new System.Drawing.Point(6, 165);
            this.LabelSelectX.Name = "LabelSelectX";
            this.LabelSelectX.Size = new System.Drawing.Size(17, 13);
            this.LabelSelectX.TabIndex = 123;
            this.LabelSelectX.Text = "X:";
            // 
            // LabelSelectY
            // 
            this.LabelSelectY.AutoSize = true;
            this.LabelSelectY.Location = new System.Drawing.Point(63, 165);
            this.LabelSelectY.Name = "LabelSelectY";
            this.LabelSelectY.Size = new System.Drawing.Size(17, 13);
            this.LabelSelectY.TabIndex = 125;
            this.LabelSelectY.Text = "Y:";
            // 
            // LabelSelectWidth
            // 
            this.LabelSelectWidth.AutoSize = true;
            this.LabelSelectWidth.Location = new System.Drawing.Point(122, 165);
            this.LabelSelectWidth.Name = "LabelSelectWidth";
            this.LabelSelectWidth.Size = new System.Drawing.Size(21, 13);
            this.LabelSelectWidth.TabIndex = 127;
            this.LabelSelectWidth.Text = "W:";
            // 
            // LabelSelectHeight
            // 
            this.LabelSelectHeight.AutoSize = true;
            this.LabelSelectHeight.Location = new System.Drawing.Point(187, 165);
            this.LabelSelectHeight.Name = "LabelSelectHeight";
            this.LabelSelectHeight.Size = new System.Drawing.Size(18, 13);
            this.LabelSelectHeight.TabIndex = 129;
            this.LabelSelectHeight.Text = "H:";
            // 
            // ComboBoxUnit
            // 
            this.ComboBoxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxUnit.FormattingEnabled = true;
            this.ComboBoxUnit.Items.AddRange(new object[] {
            "Pixels",
            "Millimetres",
            "Inches"});
            this.ComboBoxUnit.Location = new System.Drawing.Point(170, 124);
            this.ComboBoxUnit.Name = "ComboBoxUnit";
            this.ComboBoxUnit.Size = new System.Drawing.Size(73, 21);
            this.ComboBoxUnit.TabIndex = 121;
            this.ComboBoxUnit.SelectedIndexChanged += new System.EventHandler(this.ComboBoxUnit_SelectedIndexChanged);
            // 
            // ComboBoxPage
            // 
            this.ComboBoxPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxPage.FormattingEnabled = true;
            this.ComboBoxPage.Items.AddRange(new object[] {
            "Page 1"});
            this.ComboBoxPage.Location = new System.Drawing.Point(6, 100);
            this.ComboBoxPage.Name = "ComboBoxPage";
            this.ComboBoxPage.Size = new System.Drawing.Size(105, 21);
            this.ComboBoxPage.TabIndex = 120;
            this.ComboBoxPage.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPage_SelectedIndexChanged);
            // 
            // LabelSize
            // 
            this.LabelSize.Location = new System.Drawing.Point(6, 127);
            this.LabelSize.Name = "LabelSize";
            this.LabelSize.Size = new System.Drawing.Size(158, 15);
            this.LabelSize.TabIndex = 118;
            this.LabelSize.Text = "-";
            // 
            // TextBoxScrollX
            // 
            this.TextBoxScrollX.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxScrollX.Enabled = false;
            this.TextBoxScrollX.HidePromptOnLeave = true;
            this.TextBoxScrollX.Location = new System.Drawing.Point(74, 429);
            this.TextBoxScrollX.Mask = "0000";
            this.TextBoxScrollX.Name = "TextBoxScrollX";
            this.TextBoxScrollX.PromptChar = ' ';
            this.TextBoxScrollX.Size = new System.Drawing.Size(40, 20);
            this.TextBoxScrollX.TabIndex = 117;
            this.TextBoxScrollX.Text = "0";
            this.TextBoxScrollX.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxScrollX.TextChanged += new System.EventHandler(this.TextBoxScroll_TextChanged);
            this.TextBoxScrollX.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 432);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 116;
            this.label2.Text = "Scroll Pos Y:";
            // 
            // TextBoxScrollY
            // 
            this.TextBoxScrollY.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxScrollY.Enabled = false;
            this.TextBoxScrollY.HidePromptOnLeave = true;
            this.TextBoxScrollY.Location = new System.Drawing.Point(199, 429);
            this.TextBoxScrollY.Mask = "0000";
            this.TextBoxScrollY.Name = "TextBoxScrollY";
            this.TextBoxScrollY.PromptChar = ' ';
            this.TextBoxScrollY.Size = new System.Drawing.Size(40, 20);
            this.TextBoxScrollY.TabIndex = 115;
            this.TextBoxScrollY.Text = "0";
            this.TextBoxScrollY.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxScrollY.TextChanged += new System.EventHandler(this.TextBoxScroll_TextChanged);
            this.TextBoxScrollY.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 432);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(67, 13);
            this.Label1.TabIndex = 114;
            this.Label1.Text = "Scroll Pos X:";
            // 
            // LabelTargetSize
            // 
            this.LabelTargetSize.AutoSize = true;
            this.LabelTargetSize.Location = new System.Drawing.Point(6, 405);
            this.LabelTargetSize.Name = "LabelTargetSize";
            this.LabelTargetSize.Size = new System.Drawing.Size(70, 13);
            this.LabelTargetSize.TabIndex = 113;
            this.LabelTargetSize.Text = "Target Size: -";
            // 
            // ComboBoxTextAlign
            // 
            this.ComboBoxTextAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxTextAlign.FormattingEnabled = true;
            this.ComboBoxTextAlign.Items.AddRange(new object[] {
            "Left",
            "Center",
            "Right"});
            this.ComboBoxTextAlign.Location = new System.Drawing.Point(132, 242);
            this.ComboBoxTextAlign.Name = "ComboBoxTextAlign";
            this.ComboBoxTextAlign.Size = new System.Drawing.Size(55, 21);
            this.ComboBoxTextAlign.TabIndex = 1;
            // 
            // ButtonFontColor
            // 
            this.ButtonFontColor.BackColor = System.Drawing.Color.Black;
            this.ButtonFontColor.Location = new System.Drawing.Point(220, 238);
            this.ButtonFontColor.Name = "ButtonFontColor";
            this.ButtonFontColor.Size = new System.Drawing.Size(23, 25);
            this.ButtonFontColor.TabIndex = 43;
            this.ButtonFontColor.UseVisualStyleBackColor = false;
            this.ButtonFontColor.Click += new System.EventHandler(this.ButtonFontColor_Click);
            // 
            // ComboBoxTextRect
            // 
            this.ComboBoxTextRect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxTextRect.FormattingEnabled = true;
            this.ComboBoxTextRect.Items.AddRange(new object[] {
            "Single Line",
            "Set in Rect",
            "Set in Rect (don\'t wrap)",
            "Center vertically"});
            this.ComboBoxTextRect.Location = new System.Drawing.Point(6, 242);
            this.ComboBoxTextRect.Name = "ComboBoxTextRect";
            this.ComboBoxTextRect.Size = new System.Drawing.Size(120, 21);
            this.ComboBoxTextRect.TabIndex = 0;
            this.ComboBoxTextRect.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTextRect_SelectedIndexChanged);
            // 
            // CheckBoxItalic
            // 
            this.CheckBoxItalic.AutoSize = true;
            this.CheckBoxItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxItalic.Location = new System.Drawing.Point(209, 320);
            this.CheckBoxItalic.Name = "CheckBoxItalic";
            this.CheckBoxItalic.Size = new System.Drawing.Size(29, 17);
            this.CheckBoxItalic.TabIndex = 11;
            this.CheckBoxItalic.Text = "I";
            this.CheckBoxItalic.UseVisualStyleBackColor = true;
            this.CheckBoxItalic.CheckedChanged += new System.EventHandler(this.CheckBoxItalic_CheckedChanged);
            // 
            // ComboBoxFontList
            // 
            this.ComboBoxFontList.FormattingEnabled = true;
            this.ComboBoxFontList.Location = new System.Drawing.Point(6, 215);
            this.ComboBoxFontList.Name = "ComboBoxFontList";
            this.ComboBoxFontList.Size = new System.Drawing.Size(137, 21);
            this.ComboBoxFontList.TabIndex = 2;
            this.ComboBoxFontList.Text = "Arial";
            this.ComboBoxFontList.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFontList_SelectedIndexChanged);
            // 
            // CheckBoxBold
            // 
            this.CheckBoxBold.AutoSize = true;
            this.CheckBoxBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxBold.Location = new System.Drawing.Point(209, 274);
            this.CheckBoxBold.Name = "CheckBoxBold";
            this.CheckBoxBold.Size = new System.Drawing.Size(34, 17);
            this.CheckBoxBold.TabIndex = 9;
            this.CheckBoxBold.Text = "B";
            this.CheckBoxBold.UseVisualStyleBackColor = true;
            this.CheckBoxBold.CheckedChanged += new System.EventHandler(this.CheckBoxBold_CheckedChanged);
            // 
            // CheckBoxUnderline
            // 
            this.CheckBoxUnderline.AutoSize = true;
            this.CheckBoxUnderline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxUnderline.Location = new System.Drawing.Point(209, 297);
            this.CheckBoxUnderline.Name = "CheckBoxUnderline";
            this.CheckBoxUnderline.Size = new System.Drawing.Size(34, 17);
            this.CheckBoxUnderline.TabIndex = 10;
            this.CheckBoxUnderline.Text = "U";
            this.CheckBoxUnderline.UseVisualStyleBackColor = true;
            this.CheckBoxUnderline.CheckedChanged += new System.EventHandler(this.CheckBoxUnderline_CheckedChanged);
            // 
            // TextBoxFontSize
            // 
            this.TextBoxFontSize.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxFontSize.HidePromptOnLeave = true;
            this.TextBoxFontSize.Location = new System.Drawing.Point(174, 215);
            this.TextBoxFontSize.Mask = "000";
            this.TextBoxFontSize.Name = "TextBoxFontSize";
            this.TextBoxFontSize.PromptChar = ' ';
            this.TextBoxFontSize.Size = new System.Drawing.Size(25, 20);
            this.TextBoxFontSize.TabIndex = 13;
            this.TextBoxFontSize.Text = "20";
            this.TextBoxFontSize.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxFontSize.Enter += new System.EventHandler(this.TextBox_Enter);
            this.TextBoxFontSize.Leave += new System.EventHandler(this.TextBoxFontSize_Leave);
            // 
            // LabelFontColor
            // 
            this.LabelFontColor.Location = new System.Drawing.Point(187, 245);
            this.LabelFontColor.Name = "LabelFontColor";
            this.LabelFontColor.Size = new System.Drawing.Size(38, 15);
            this.LabelFontColor.TabIndex = 40;
            this.LabelFontColor.Text = "Color:";
            // 
            // LabelFontSize
            // 
            this.LabelFontSize.AutoSize = true;
            this.LabelFontSize.Location = new System.Drawing.Point(147, 218);
            this.LabelFontSize.Name = "LabelFontSize";
            this.LabelFontSize.Size = new System.Drawing.Size(30, 13);
            this.LabelFontSize.TabIndex = 14;
            this.LabelFontSize.Text = "Size:";
            // 
            // TextBoxDrawHeight
            // 
            this.TextBoxDrawHeight.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxDrawHeight.Enabled = false;
            this.TextBoxDrawHeight.HidePromptOnLeave = true;
            this.TextBoxDrawHeight.Location = new System.Drawing.Point(203, 346);
            this.TextBoxDrawHeight.Mask = "#0000";
            this.TextBoxDrawHeight.Name = "TextBoxDrawHeight";
            this.TextBoxDrawHeight.PromptChar = ' ';
            this.TextBoxDrawHeight.Size = new System.Drawing.Size(40, 20);
            this.TextBoxDrawHeight.TabIndex = 39;
            this.TextBoxDrawHeight.Text = "160";
            this.TextBoxDrawHeight.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxDrawHeight.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // TextBoxDrawWidth
            // 
            this.TextBoxDrawWidth.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxDrawWidth.Enabled = false;
            this.TextBoxDrawWidth.HidePromptOnLeave = true;
            this.TextBoxDrawWidth.Location = new System.Drawing.Point(141, 346);
            this.TextBoxDrawWidth.Mask = "#0000";
            this.TextBoxDrawWidth.Name = "TextBoxDrawWidth";
            this.TextBoxDrawWidth.PromptChar = ' ';
            this.TextBoxDrawWidth.Size = new System.Drawing.Size(40, 20);
            this.TextBoxDrawWidth.TabIndex = 37;
            this.TextBoxDrawWidth.Text = "320";
            this.TextBoxDrawWidth.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxDrawWidth.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // TextBoxDrawY
            // 
            this.TextBoxDrawY.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxDrawY.HidePromptOnLeave = true;
            this.TextBoxDrawY.Location = new System.Drawing.Point(78, 346);
            this.TextBoxDrawY.Mask = "#0000";
            this.TextBoxDrawY.Name = "TextBoxDrawY";
            this.TextBoxDrawY.PromptChar = ' ';
            this.TextBoxDrawY.Size = new System.Drawing.Size(40, 20);
            this.TextBoxDrawY.TabIndex = 35;
            this.TextBoxDrawY.Text = "0";
            this.TextBoxDrawY.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxDrawY.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // TextBoxDrawX
            // 
            this.TextBoxDrawX.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxDrawX.HidePromptOnLeave = true;
            this.TextBoxDrawX.Location = new System.Drawing.Point(22, 346);
            this.TextBoxDrawX.Mask = "#0000";
            this.TextBoxDrawX.Name = "TextBoxDrawX";
            this.TextBoxDrawX.PromptChar = ' ';
            this.TextBoxDrawX.Size = new System.Drawing.Size(40, 20);
            this.TextBoxDrawX.TabIndex = 33;
            this.TextBoxDrawX.Text = "0";
            this.TextBoxDrawX.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxDrawX.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // LabelDrawX
            // 
            this.LabelDrawX.AutoSize = true;
            this.LabelDrawX.Location = new System.Drawing.Point(6, 349);
            this.LabelDrawX.Name = "LabelDrawX";
            this.LabelDrawX.Size = new System.Drawing.Size(17, 13);
            this.LabelDrawX.TabIndex = 34;
            this.LabelDrawX.Text = "X:";
            // 
            // LabelDrawY
            // 
            this.LabelDrawY.AutoSize = true;
            this.LabelDrawY.Location = new System.Drawing.Point(63, 349);
            this.LabelDrawY.Name = "LabelDrawY";
            this.LabelDrawY.Size = new System.Drawing.Size(17, 13);
            this.LabelDrawY.TabIndex = 36;
            this.LabelDrawY.Text = "Y:";
            // 
            // LabelDrawWidth
            // 
            this.LabelDrawWidth.AutoSize = true;
            this.LabelDrawWidth.Location = new System.Drawing.Point(122, 349);
            this.LabelDrawWidth.Name = "LabelDrawWidth";
            this.LabelDrawWidth.Size = new System.Drawing.Size(21, 13);
            this.LabelDrawWidth.TabIndex = 38;
            this.LabelDrawWidth.Text = "W:";
            // 
            // LabelDrawHeight
            // 
            this.LabelDrawHeight.AutoSize = true;
            this.LabelDrawHeight.Location = new System.Drawing.Point(187, 349);
            this.LabelDrawHeight.Name = "LabelDrawHeight";
            this.LabelDrawHeight.Size = new System.Drawing.Size(18, 13);
            this.LabelDrawHeight.TabIndex = 40;
            this.LabelDrawHeight.Text = "H:";
            // 
            // LabelTarget
            // 
            this.LabelTarget.AutoSize = true;
            this.LabelTarget.Location = new System.Drawing.Point(6, 377);
            this.LabelTarget.Name = "LabelTarget";
            this.LabelTarget.Size = new System.Drawing.Size(41, 13);
            this.LabelTarget.TabIndex = 96;
            this.LabelTarget.Text = "Target:";
            // 
            // ComboBoxTarget
            // 
            this.ComboBoxTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxTarget.FormattingEnabled = true;
            this.ComboBoxTarget.Items.AddRange(new object[] {
            "Display (Foregr. Buffer)",
            "Background Buffer",
            "Overlay Buffer",
            "Standby Image",
            "New perm. Store (standard)",
            "New perm. Store (large)"});
            this.ComboBoxTarget.Location = new System.Drawing.Point(48, 374);
            this.ComboBoxTarget.Name = "ComboBoxTarget";
            this.ComboBoxTarget.Size = new System.Drawing.Size(139, 21);
            this.ComboBoxTarget.TabIndex = 95;
            this.ComboBoxTarget.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxTarget_SelectionChangeCommitted);
            // 
            // LabelSource
            // 
            this.LabelSource.AutoSize = true;
            this.LabelSource.Location = new System.Drawing.Point(6, 22);
            this.LabelSource.Name = "LabelSource";
            this.LabelSource.Size = new System.Drawing.Size(44, 13);
            this.LabelSource.TabIndex = 94;
            this.LabelSource.Text = "Source:";
            // 
            // TextBoxText
            // 
            this.TextBoxText.Location = new System.Drawing.Point(6, 269);
            this.TextBoxText.Multiline = true;
            this.TextBoxText.Name = "TextBoxText";
            this.TextBoxText.Size = new System.Drawing.Size(196, 70);
            this.TextBoxText.TabIndex = 3;
            this.TextBoxText.Text = "Text";
            // 
            // ComboBoxSource
            // 
            this.ComboBoxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSource.FormattingEnabled = true;
            this.ComboBoxSource.Items.AddRange(new object[] {
            "Text",
            "Image",
            "PDF",
            "Erase",
            "Foreground Buffer",
            "Background Buffer",
            "Overlay Buffer"});
            this.ComboBoxSource.Location = new System.Drawing.Point(56, 19);
            this.ComboBoxSource.Name = "ComboBoxSource";
            this.ComboBoxSource.Size = new System.Drawing.Size(187, 21);
            this.ComboBoxSource.TabIndex = 54;
            this.ComboBoxSource.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSource_SelectedIndexChanged);
            // 
            // ComboBoxImage
            // 
            this.ComboBoxImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxImage.Enabled = false;
            this.ComboBoxImage.FormattingEnabled = true;
            this.ComboBoxImage.Items.AddRange(new object[] {
            "Use Example 1",
            "Use Example 2",
            "Use Example 3",
            "Use Example 4",
            "Use signotec Logo",
            "Use Image from File",
            "Use Image from URL"});
            this.ComboBoxImage.Location = new System.Drawing.Point(6, 46);
            this.ComboBoxImage.Name = "ComboBoxImage";
            this.ComboBoxImage.Size = new System.Drawing.Size(237, 21);
            this.ComboBoxImage.TabIndex = 53;
            this.ComboBoxImage.SelectedIndexChanged += new System.EventHandler(this.ComboBoxImage_SelectedIndexChanged);
            // 
            // ButtonDraw
            // 
            this.ButtonDraw.Location = new System.Drawing.Point(194, 373);
            this.ButtonDraw.Name = "ButtonDraw";
            this.ButtonDraw.Size = new System.Drawing.Size(49, 25);
            this.ButtonDraw.TabIndex = 48;
            this.ButtonDraw.Text = "Draw";
            this.ButtonDraw.UseVisualStyleBackColor = true;
            this.ButtonDraw.Click += new System.EventHandler(this.ButtonDraw_Click);
            // 
            // ButtonDevCount
            // 
            this.ButtonDevCount.Location = new System.Drawing.Point(131, 98);
            this.ButtonDevCount.Name = "ButtonDevCount";
            this.ButtonDevCount.Size = new System.Drawing.Size(121, 23);
            this.ButtonDevCount.TabIndex = 1;
            this.ButtonDevCount.Text = "Tìm thiết bị";
            this.ButtonDevCount.UseVisualStyleBackColor = true;
            this.ButtonDevCount.Click += new System.EventHandler(this.ButtonDevCount_Click);
            // 
            // ButtonStartCancel
            // 
            this.ButtonStartCancel.Enabled = false;
            this.ButtonStartCancel.Location = new System.Drawing.Point(12, 155);
            this.ButtonStartCancel.Name = "ButtonStartCancel";
            this.ButtonStartCancel.Size = new System.Drawing.Size(121, 23);
            this.ButtonStartCancel.TabIndex = 2;
            this.ButtonStartCancel.Text = "Start";
            this.ButtonStartCancel.UseVisualStyleBackColor = true;
            this.ButtonStartCancel.Click += new System.EventHandler(this.ButtonStartCancel_Click);
            // 
            // ButtonOpenClose
            // 
            this.ButtonOpenClose.Enabled = false;
            this.ButtonOpenClose.Location = new System.Drawing.Point(262, 98);
            this.ButtonOpenClose.Name = "ButtonOpenClose";
            this.ButtonOpenClose.Size = new System.Drawing.Size(121, 23);
            this.ButtonOpenClose.TabIndex = 6;
            this.ButtonOpenClose.Text = "Mở";
            this.ButtonOpenClose.UseVisualStyleBackColor = true;
            this.ButtonOpenClose.Click += new System.EventHandler(this.ButtonOpenClose_Click);
            // 
            // ListOfDevices
            // 
            this.ListOfDevices.Enabled = false;
            this.ListOfDevices.FormattingEnabled = true;
            this.ListOfDevices.Items.AddRange(new object[] {
            "No Devices",
            "detected"});
            this.ListOfDevices.Location = new System.Drawing.Point(133, 19);
            this.ListOfDevices.Name = "ListOfDevices";
            this.ListOfDevices.Size = new System.Drawing.Size(69, 69);
            this.ListOfDevices.TabIndex = 2;
            this.ListOfDevices.SelectedIndexChanged += new System.EventHandler(this.ListOfDevices_SelectedIndexChanged);
            // 
            // LabelCapturedPoints
            // 
            this.LabelCapturedPoints.AutoSize = true;
            this.LabelCapturedPoints.BackColor = System.Drawing.Color.Transparent;
            this.LabelCapturedPoints.Location = new System.Drawing.Point(264, 445);
            this.LabelCapturedPoints.Name = "LabelCapturedPoints";
            this.LabelCapturedPoints.Size = new System.Drawing.Size(0, 13);
            this.LabelCapturedPoints.TabIndex = 39;
            this.LabelCapturedPoints.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LabelDisplay
            // 
            this.LabelDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LabelDisplay.AutoSize = true;
            this.LabelDisplay.Location = new System.Drawing.Point(208, 76);
            this.LabelDisplay.Name = "LabelDisplay";
            this.LabelDisplay.Size = new System.Drawing.Size(50, 13);
            this.LabelDisplay.TabIndex = 41;
            this.LabelDisplay.Text = "Display: -";
            this.LabelDisplay.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // LabelFirmware
            // 
            this.LabelFirmware.AutoSize = true;
            this.LabelFirmware.Location = new System.Drawing.Point(307, 19);
            this.LabelFirmware.Name = "LabelFirmware";
            this.LabelFirmware.Size = new System.Drawing.Size(58, 13);
            this.LabelFirmware.TabIndex = 40;
            this.LabelFirmware.Text = "Firmware: -";
            // 
            // LabelType
            // 
            this.LabelType.AutoSize = true;
            this.LabelType.Location = new System.Drawing.Point(208, 19);
            this.LabelType.Name = "LabelType";
            this.LabelType.Size = new System.Drawing.Size(40, 13);
            this.LabelType.TabIndex = 3;
            this.LabelType.Text = "Type: -";
            // 
            // LabelSerial
            // 
            this.LabelSerial.AutoSize = true;
            this.LabelSerial.Location = new System.Drawing.Point(208, 57);
            this.LabelSerial.Name = "LabelSerial";
            this.LabelSerial.Size = new System.Drawing.Size(42, 13);
            this.LabelSerial.TabIndex = 4;
            this.LabelSerial.Text = "Serial: -";
            // 
            // ButtonConfirm
            // 
            this.ButtonConfirm.Enabled = false;
            this.ButtonConfirm.Location = new System.Drawing.Point(405, 155);
            this.ButtonConfirm.Name = "ButtonConfirm";
            this.ButtonConfirm.Size = new System.Drawing.Size(121, 23);
            this.ButtonConfirm.TabIndex = 44;
            this.ButtonConfirm.Text = "Xác nhận";
            this.ButtonConfirm.UseVisualStyleBackColor = true;
            this.ButtonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // ButtonRetry
            // 
            this.ButtonRetry.Enabled = false;
            this.ButtonRetry.Location = new System.Drawing.Point(143, 155);
            this.ButtonRetry.Name = "ButtonRetry";
            this.ButtonRetry.Size = new System.Drawing.Size(121, 23);
            this.ButtonRetry.TabIndex = 43;
            this.ButtonRetry.Text = "Retry";
            this.ButtonRetry.UseVisualStyleBackColor = true;
            this.ButtonRetry.Click += new System.EventHandler(this.ButtonRetry_Click);
            // 
            // GroupBoxMain
            // 
            this.GroupBoxMain.BackColor = System.Drawing.SystemColors.Control;
            this.GroupBoxMain.Controls.Add(this.LabelSearchConfig);
            this.GroupBoxMain.Controls.Add(this.ButtonSearchConfig);
            this.GroupBoxMain.Controls.Add(this.LabelFirmware);
            this.GroupBoxMain.Controls.Add(this.LabelType);
            this.GroupBoxMain.Controls.Add(this.LabelPort);
            this.GroupBoxMain.Controls.Add(this.ButtonDevCount);
            this.GroupBoxMain.Controls.Add(this.ListOfDevices);
            this.GroupBoxMain.Controls.Add(this.LabelSerial);
            this.GroupBoxMain.Controls.Add(this.ButtonOpenClose);
            this.GroupBoxMain.Controls.Add(this.LabelDisplay);
            this.GroupBoxMain.Location = new System.Drawing.Point(12, 7);
            this.GroupBoxMain.Name = "GroupBoxMain";
            this.GroupBoxMain.Size = new System.Drawing.Size(393, 129);
            this.GroupBoxMain.TabIndex = 46;
            this.GroupBoxMain.TabStop = false;
            this.GroupBoxMain.Text = "STPadLibNet Version: -";
            // 
            // LabelSearchConfig
            // 
            this.LabelSearchConfig.Location = new System.Drawing.Point(7, 19);
            this.LabelSearchConfig.Name = "LabelSearchConfig";
            this.LabelSearchConfig.Size = new System.Drawing.Size(114, 69);
            this.LabelSearchConfig.TabIndex = 45;
            this.LabelSearchConfig.Text = "\"Get Devices\" searches for:\n- USB Devices";
            // 
            // ButtonSearchConfig
            // 
            this.ButtonSearchConfig.Location = new System.Drawing.Point(7, 98);
            this.ButtonSearchConfig.Name = "ButtonSearchConfig";
            this.ButtonSearchConfig.Size = new System.Drawing.Size(114, 23);
            this.ButtonSearchConfig.TabIndex = 44;
            this.ButtonSearchConfig.Text = "Configure Search";
            this.ButtonSearchConfig.UseVisualStyleBackColor = true;
            this.ButtonSearchConfig.Click += new System.EventHandler(this.ButtonSearchConfig_Click);
            // 
            // LabelPort
            // 
            this.LabelPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelPort.AutoSize = true;
            this.LabelPort.Location = new System.Drawing.Point(208, 38);
            this.LabelPort.Name = "LabelPort";
            this.LabelPort.Size = new System.Drawing.Size(35, 13);
            this.LabelPort.TabIndex = 42;
            this.LabelPort.Text = "Port: -";
            this.LabelPort.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DialogOpen
            // 
            this.DialogOpen.DefaultExt = "bmp";
            this.DialogOpen.Filter = "All supported files|*.bmp;*.gif;*.jpg;*.png;*.tif|BMP files (*.BMP)|*.bmp|GIF fil" +
    "es (*.GIF)|*.gif|JPEG files (*.JPG)|*.jpg|PNG files (*.PNG)|*.png|TIFF files (*." +
    "TIF)|*.tif";
            this.DialogOpen.Title = "Open";
            // 
            // ButtonStop
            // 
            this.ButtonStop.Enabled = false;
            this.ButtonStop.Location = new System.Drawing.Point(274, 155);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(121, 23);
            this.ButtonStop.TabIndex = 62;
            this.ButtonStop.Text = "Dừng";
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // DialogColor
            // 
            this.DialogColor.FullOpen = true;
            // 
            // GroupBoxTimeouts
            // 
            this.GroupBoxTimeouts.Controls.Add(this.ButtonTimeoutStartStop);
            this.GroupBoxTimeouts.Controls.Add(this.ComboBoxTimeout);
            this.GroupBoxTimeouts.Controls.Add(this.TextBoxTimeoutBefore);
            this.GroupBoxTimeouts.Controls.Add(this.TextBoxTimeoutAfter);
            this.GroupBoxTimeouts.Controls.Add(this.LabelAfterAction);
            this.GroupBoxTimeouts.Controls.Add(this.LabelTimeBefore);
            this.GroupBoxTimeouts.Enabled = false;
            this.GroupBoxTimeouts.Location = new System.Drawing.Point(697, 190);
            this.GroupBoxTimeouts.Name = "GroupBoxTimeouts";
            this.GroupBoxTimeouts.Size = new System.Drawing.Size(151, 123);
            this.GroupBoxTimeouts.TabIndex = 65;
            this.GroupBoxTimeouts.TabStop = false;
            this.GroupBoxTimeouts.Text = "Configure Timeouts";
            // 
            // ButtonTimeoutStartStop
            // 
            this.ButtonTimeoutStartStop.Location = new System.Drawing.Point(17, 94);
            this.ButtonTimeoutStartStop.Name = "ButtonTimeoutStartStop";
            this.ButtonTimeoutStartStop.Size = new System.Drawing.Size(124, 23);
            this.ButtonTimeoutStartStop.TabIndex = 44;
            this.ButtonTimeoutStartStop.Text = "Stop";
            this.ButtonTimeoutStartStop.Click += new System.EventHandler(this.ButtonTimeoutStartStop_Click);
            // 
            // ComboBoxTimeout
            // 
            this.ComboBoxTimeout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxTimeout.FormattingEnabled = true;
            this.ComboBoxTimeout.Items.AddRange(new object[] {
            "Call Timer Event",
            "Call Cancel / Confirm",
            "Call Cancel"});
            this.ComboBoxTimeout.Location = new System.Drawing.Point(16, 68);
            this.ComboBoxTimeout.Name = "ComboBoxTimeout";
            this.ComboBoxTimeout.Size = new System.Drawing.Size(126, 21);
            this.ComboBoxTimeout.TabIndex = 43;
            // 
            // TextBoxTimeoutBefore
            // 
            this.TextBoxTimeoutBefore.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxTimeoutBefore.HidePromptOnLeave = true;
            this.TextBoxTimeoutBefore.Location = new System.Drawing.Point(98, 16);
            this.TextBoxTimeoutBefore.Mask = "#0000";
            this.TextBoxTimeoutBefore.Name = "TextBoxTimeoutBefore";
            this.TextBoxTimeoutBefore.PromptChar = ' ';
            this.TextBoxTimeoutBefore.Size = new System.Drawing.Size(35, 20);
            this.TextBoxTimeoutBefore.TabIndex = 72;
            this.TextBoxTimeoutBefore.Text = "10000";
            this.TextBoxTimeoutBefore.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxTimeoutBefore.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // TextBoxTimeoutAfter
            // 
            this.TextBoxTimeoutAfter.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxTimeoutAfter.Location = new System.Drawing.Point(98, 42);
            this.TextBoxTimeoutAfter.Mask = "#0000";
            this.TextBoxTimeoutAfter.Name = "TextBoxTimeoutAfter";
            this.TextBoxTimeoutAfter.PromptChar = ' ';
            this.TextBoxTimeoutAfter.Size = new System.Drawing.Size(35, 20);
            this.TextBoxTimeoutAfter.TabIndex = 73;
            this.TextBoxTimeoutAfter.Text = "1000";
            this.TextBoxTimeoutAfter.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxTimeoutAfter.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // LabelAfterAction
            // 
            this.LabelAfterAction.AutoSize = true;
            this.LabelAfterAction.Location = new System.Drawing.Point(15, 49);
            this.LabelAfterAction.Name = "LabelAfterAction";
            this.LabelAfterAction.Size = new System.Drawing.Size(65, 13);
            this.LabelAfterAction.TabIndex = 77;
            this.LabelAfterAction.Text = "After Action:";
            // 
            // LabelTimeBefore
            // 
            this.LabelTimeBefore.AutoSize = true;
            this.LabelTimeBefore.Location = new System.Drawing.Point(15, 23);
            this.LabelTimeBefore.Name = "LabelTimeBefore";
            this.LabelTimeBefore.Size = new System.Drawing.Size(74, 13);
            this.LabelTimeBefore.TabIndex = 79;
            this.LabelTimeBefore.Text = "Before Action:";
            // 
            // GroupBoxDisplay
            // 
            this.GroupBoxDisplay.Controls.Add(this.ComboBoxRotation);
            this.GroupBoxDisplay.Controls.Add(this.LabelRotation);
            this.GroupBoxDisplay.Controls.Add(this.ComboBoxBacklight);
            this.GroupBoxDisplay.Controls.Add(this.LabelBacklight);
            this.GroupBoxDisplay.Controls.Add(this.ComboBoxDisplayPenWidth);
            this.GroupBoxDisplay.Controls.Add(this.ButtonDisplayPenColor);
            this.GroupBoxDisplay.Controls.Add(this.LabelDisplayPenColor);
            this.GroupBoxDisplay.Controls.Add(this.ButtonClearDisplay);
            this.GroupBoxDisplay.Enabled = false;
            this.GroupBoxDisplay.Location = new System.Drawing.Point(411, 58);
            this.GroupBoxDisplay.Name = "GroupBoxDisplay";
            this.GroupBoxDisplay.Size = new System.Drawing.Size(263, 78);
            this.GroupBoxDisplay.TabIndex = 66;
            this.GroupBoxDisplay.TabStop = false;
            this.GroupBoxDisplay.Text = "Configure Display";
            // 
            // ComboBoxRotation
            // 
            this.ComboBoxRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxRotation.FormattingEnabled = true;
            this.ComboBoxRotation.Items.AddRange(new object[] {
            "0 °",
            "180 °"});
            this.ComboBoxRotation.Location = new System.Drawing.Point(57, 48);
            this.ComboBoxRotation.Name = "ComboBoxRotation";
            this.ComboBoxRotation.Size = new System.Drawing.Size(72, 21);
            this.ComboBoxRotation.TabIndex = 101;
            this.ComboBoxRotation.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRotation_SelectedIndexChanged);
            // 
            // LabelRotation
            // 
            this.LabelRotation.AutoSize = true;
            this.LabelRotation.Location = new System.Drawing.Point(4, 51);
            this.LabelRotation.Name = "LabelRotation";
            this.LabelRotation.Size = new System.Drawing.Size(50, 13);
            this.LabelRotation.TabIndex = 102;
            this.LabelRotation.Text = "Rotation:";
            // 
            // ComboBoxBacklight
            // 
            this.ComboBoxBacklight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxBacklight.FormattingEnabled = true;
            this.ComboBoxBacklight.Items.AddRange(new object[] {
            "Off",
            "On",
            "Medium",
            "Maximum"});
            this.ComboBoxBacklight.Location = new System.Drawing.Point(180, 20);
            this.ComboBoxBacklight.Name = "ComboBoxBacklight";
            this.ComboBoxBacklight.Size = new System.Drawing.Size(72, 21);
            this.ComboBoxBacklight.TabIndex = 99;
            this.ComboBoxBacklight.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBacklight_SelectedIndexChanged);
            // 
            // LabelBacklight
            // 
            this.LabelBacklight.AutoSize = true;
            this.LabelBacklight.Location = new System.Drawing.Point(127, 23);
            this.LabelBacklight.Name = "LabelBacklight";
            this.LabelBacklight.Size = new System.Drawing.Size(54, 13);
            this.LabelBacklight.TabIndex = 100;
            this.LabelBacklight.Text = "Backlight:";
            // 
            // ComboBoxDisplayPenWidth
            // 
            this.ComboBoxDisplayPenWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxDisplayPenWidth.FormattingEnabled = true;
            this.ComboBoxDisplayPenWidth.Items.AddRange(new object[] {
            "1 px",
            "2 px",
            "3 px"});
            this.ComboBoxDisplayPenWidth.Location = new System.Drawing.Point(61, 21);
            this.ComboBoxDisplayPenWidth.Name = "ComboBoxDisplayPenWidth";
            this.ComboBoxDisplayPenWidth.Size = new System.Drawing.Size(46, 21);
            this.ComboBoxDisplayPenWidth.TabIndex = 96;
            this.ComboBoxDisplayPenWidth.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDisplayPenWidth_SelectedIndexChanged);
            // 
            // ButtonDisplayPenColor
            // 
            this.ButtonDisplayPenColor.BackColor = System.Drawing.Color.Blue;
            this.ButtonDisplayPenColor.Location = new System.Drawing.Point(34, 20);
            this.ButtonDisplayPenColor.Name = "ButtonDisplayPenColor";
            this.ButtonDisplayPenColor.Size = new System.Drawing.Size(23, 23);
            this.ButtonDisplayPenColor.TabIndex = 94;
            this.ButtonDisplayPenColor.UseVisualStyleBackColor = false;
            this.ButtonDisplayPenColor.Click += new System.EventHandler(this.ButtonDisplayPenColor_Click);
            // 
            // LabelDisplayPenColor
            // 
            this.LabelDisplayPenColor.AutoSize = true;
            this.LabelDisplayPenColor.Location = new System.Drawing.Point(4, 24);
            this.LabelDisplayPenColor.Name = "LabelDisplayPenColor";
            this.LabelDisplayPenColor.Size = new System.Drawing.Size(29, 13);
            this.LabelDisplayPenColor.TabIndex = 93;
            this.LabelDisplayPenColor.Text = "Pen:";
            // 
            // LabelScrollPos
            // 
            this.LabelScrollPos.Location = new System.Drawing.Point(411, 9);
            this.LabelScrollPos.Name = "LabelScrollPos";
            this.LabelScrollPos.Size = new System.Drawing.Size(149, 21);
            this.LabelScrollPos.TabIndex = 67;
            this.LabelScrollPos.Text = "Scroll Position: 0 / 0";
            // 
            // LabelScrollSpeed
            // 
            this.LabelScrollSpeed.AutoSize = true;
            this.LabelScrollSpeed.Location = new System.Drawing.Point(411, 34);
            this.LabelScrollSpeed.Name = "LabelScrollSpeed";
            this.LabelScrollSpeed.Size = new System.Drawing.Size(70, 13);
            this.LabelScrollSpeed.TabIndex = 68;
            this.LabelScrollSpeed.Text = "Scroll Speed:";
            // 
            // TextBoxScrollSpeed
            // 
            this.TextBoxScrollSpeed.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxScrollSpeed.HidePromptOnLeave = true;
            this.TextBoxScrollSpeed.Location = new System.Drawing.Point(479, 31);
            this.TextBoxScrollSpeed.Mask = "#000";
            this.TextBoxScrollSpeed.Name = "TextBoxScrollSpeed";
            this.TextBoxScrollSpeed.PromptChar = ' ';
            this.TextBoxScrollSpeed.Size = new System.Drawing.Size(39, 20);
            this.TextBoxScrollSpeed.TabIndex = 69;
            this.TextBoxScrollSpeed.Text = "100";
            this.TextBoxScrollSpeed.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxScrollSpeed.TextChanged += new System.EventHandler(this.TextBoxScrollSpeed_TextChanged);
            this.TextBoxScrollSpeed.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // ButtonRSA
            // 
            this.ButtonRSA.Location = new System.Drawing.Point(532, 144);
            this.ButtonRSA.Name = "ButtonRSA";
            this.ButtonRSA.Size = new System.Drawing.Size(142, 51);
            this.ButtonRSA.TabIndex = 70;
            this.ButtonRSA.Text = "RSA Options";
            this.ButtonRSA.UseVisualStyleBackColor = true;
            this.ButtonRSA.Click += new System.EventHandler(this.ButtonRSA_Click);
            // 
            // ImageLed
            // 
            this.ImageLed.Image = global::Emr.SignPad.Properties.Resources.LED_Yellow;
            this.ImageLed.InitialImage = null;
            this.ImageLed.Location = new System.Drawing.Point(115, 487);
            this.ImageLed.Name = "ImageLed";
            this.ImageLed.Size = new System.Drawing.Size(10, 10);
            this.ImageLed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ImageLed.TabIndex = 22;
            this.ImageLed.TabStop = false;
            this.ImageLed.Visible = false;
            // 
            // ImageLcd
            // 
            this.ImageLcd.BackColor = System.Drawing.Color.White;
            this.ImageLcd.Location = new System.Drawing.Point(110, 275);
            this.ImageLcd.Name = "ImageLcd";
            this.ImageLcd.Size = new System.Drawing.Size(320, 160);
            this.ImageLcd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageLcd.TabIndex = 19;
            this.ImageLcd.TabStop = false;
            this.ImageLcd.Visible = false;
            // 
            // ImagePad
            // 
            this.ImagePad.Location = new System.Drawing.Point(12, 188);
            this.ImagePad.Name = "ImagePad";
            this.ImagePad.Size = new System.Drawing.Size(514, 416);
            this.ImagePad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagePad.TabIndex = 18;
            this.ImagePad.TabStop = false;
            // 
            // stPadLibControl1
            // 
            this.stPadLibControl1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.stPadLibControl1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.stPadLibControl1.ControlAppName = "signoPAD-API Demo";
            this.stPadLibControl1.ControlBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.stPadLibControl1.ControlMirrorDisplay = signotec.STPadLibNet.MirrorMode.Everything;
            this.stPadLibControl1.ControlPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.stPadLibControl1.ControlPenWidth = 0;
            this.stPadLibControl1.ControlRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.stPadLibControl1.DeviceLedDefaultFlag = true;
            this.stPadLibControl1.DisplayRotation = 0;
            this.stPadLibControl1.DisplayScrollSpeed = 100;
            this.stPadLibControl1.Location = new System.Drawing.Point(110, 275);
            this.stPadLibControl1.Name = "stPadLibControl1";
            this.stPadLibControl1.Size = new System.Drawing.Size(320, 160);
            this.stPadLibControl1.TabIndex = 75;
            this.stPadLibControl1.Visible = false;
            // 
            // ButtonAdjustment
            // 
            this.ButtonAdjustment.Location = new System.Drawing.Point(68, 19);
            this.ButtonAdjustment.Name = "ButtonAdjustment";
            this.ButtonAdjustment.Size = new System.Drawing.Size(73, 23);
            this.ButtonAdjustment.TabIndex = 0;
            this.ButtonAdjustment.Text = "Adjustment";
            this.ButtonAdjustment.Click += new System.EventHandler(this.ButtonAdjustment_Click);
            // 
            // GroupBoxPadService
            // 
            this.GroupBoxPadService.Controls.Add(this.CheckBoxNFCPerm);
            this.GroupBoxPadService.Controls.Add(this.CheckBoxNFC);
            this.GroupBoxPadService.Controls.Add(this.ButtonAdjustment);
            this.GroupBoxPadService.Controls.Add(this.ButtonService);
            this.GroupBoxPadService.Enabled = false;
            this.GroupBoxPadService.Location = new System.Drawing.Point(863, 64);
            this.GroupBoxPadService.Name = "GroupBoxPadService";
            this.GroupBoxPadService.Size = new System.Drawing.Size(249, 50);
            this.GroupBoxPadService.TabIndex = 74;
            this.GroupBoxPadService.TabStop = false;
            this.GroupBoxPadService.Text = "Pad Service";
            // 
            // CheckBoxNFCPerm
            // 
            this.CheckBoxNFCPerm.AutoSize = true;
            this.CheckBoxNFCPerm.Enabled = false;
            this.CheckBoxNFCPerm.Location = new System.Drawing.Point(171, 31);
            this.CheckBoxNFCPerm.Name = "CheckBoxNFCPerm";
            this.CheckBoxNFCPerm.Size = new System.Drawing.Size(71, 17);
            this.CheckBoxNFCPerm.TabIndex = 75;
            this.CheckBoxNFCPerm.Text = "Set perm.";
            this.CheckBoxNFCPerm.UseVisualStyleBackColor = true;
            // 
            // CheckBoxNFC
            // 
            this.CheckBoxNFC.AutoSize = true;
            this.CheckBoxNFC.Enabled = false;
            this.CheckBoxNFC.Location = new System.Drawing.Point(152, 13);
            this.CheckBoxNFC.Name = "CheckBoxNFC";
            this.CheckBoxNFC.Size = new System.Drawing.Size(85, 17);
            this.CheckBoxNFC.TabIndex = 74;
            this.CheckBoxNFC.Text = "NFC Reader";
            this.CheckBoxNFC.UseVisualStyleBackColor = true;
            this.CheckBoxNFC.Click += new System.EventHandler(this.CheckBoxNFC_Click);
            // 
            // ButtonService
            // 
            this.ButtonService.Location = new System.Drawing.Point(7, 19);
            this.ButtonService.Name = "ButtonService";
            this.ButtonService.Size = new System.Drawing.Size(55, 23);
            this.ButtonService.TabIndex = 73;
            this.ButtonService.Text = "Service";
            this.ButtonService.UseVisualStyleBackColor = true;
            this.ButtonService.Click += new System.EventHandler(this.ButtonService_Click);
            // 
            // LabelSignatureData
            // 
            this.LabelSignatureData.BackColor = System.Drawing.Color.White;
            this.LabelSignatureData.Location = new System.Drawing.Point(110, 275);
            this.LabelSignatureData.Name = "LabelSignatureData";
            this.LabelSignatureData.Size = new System.Drawing.Size(320, 160);
            this.LabelSignatureData.TabIndex = 76;
            this.LabelSignatureData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelSignatureData.Visible = false;
            // 
            // buttonKeypadDemo
            // 
            this.buttonKeypadDemo.Location = new System.Drawing.Point(12, 37);
            this.buttonKeypadDemo.Name = "buttonKeypadDemo";
            this.buttonKeypadDemo.Size = new System.Drawing.Size(121, 23);
            this.buttonKeypadDemo.TabIndex = 77;
            this.buttonKeypadDemo.Text = "Start Keypad-Demo";
            this.buttonKeypadDemo.UseVisualStyleBackColor = true;
            this.buttonKeypadDemo.Click += new System.EventHandler(this.ButtonKeypadDemo_Click);
            // 
            // textBoxKeypadEntries
            // 
            this.textBoxKeypadEntries.Enabled = false;
            this.textBoxKeypadEntries.Location = new System.Drawing.Point(12, 13);
            this.textBoxKeypadEntries.Name = "textBoxKeypadEntries";
            this.textBoxKeypadEntries.Size = new System.Drawing.Size(121, 20);
            this.textBoxKeypadEntries.TabIndex = 79;
            this.textBoxKeypadEntries.Text = "Keypad - Entries";
            this.textBoxKeypadEntries.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GroupBoxKeypadDemo
            // 
            this.GroupBoxKeypadDemo.Controls.Add(this.textBoxKeypadEntries);
            this.GroupBoxKeypadDemo.Controls.Add(this.buttonKeypadDemo);
            this.GroupBoxKeypadDemo.Location = new System.Drawing.Point(532, 201);
            this.GroupBoxKeypadDemo.Name = "GroupBoxKeypadDemo";
            this.GroupBoxKeypadDemo.Size = new System.Drawing.Size(142, 66);
            this.GroupBoxKeypadDemo.TabIndex = 80;
            this.GroupBoxKeypadDemo.TabStop = false;
            this.GroupBoxKeypadDemo.Text = "Secured Keypad";
            // 
            // MainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(687, 626);
            this.Controls.Add(this.GroupBoxKeypadDemo);
            this.Controls.Add(this.LabelSignatureData);
            this.Controls.Add(this.ButtonRSA);
            this.Controls.Add(this.GroupBoxPadService);
            this.Controls.Add(this.TextBoxScrollSpeed);
            this.Controls.Add(this.LabelScrollSpeed);
            this.Controls.Add(this.LabelScrollPos);
            this.Controls.Add(this.GroupBoxDisplay);
            this.Controls.Add(this.GroupBoxTimeouts);
            this.Controls.Add(this.ButtonStop);
            this.Controls.Add(this.ButtonRetry);
            this.Controls.Add(this.ButtonConfirm);
            this.Controls.Add(this.GroupBoxSignature);
            this.Controls.Add(this.GroupBoxDisplayImage);
            this.Controls.Add(this.ButtonSettings);
            this.Controls.Add(this.GroupBoxSensor);
            this.Controls.Add(this.GroupBoxLedColor);
            this.Controls.Add(this.GroupBoxWindow);
            this.Controls.Add(this.GroupBoxDrawing);
            this.Controls.Add(this.ButtonStartCancel);
            this.Controls.Add(this.ImageLed);
            this.Controls.Add(this.LabelCapturedPoints);
            this.Controls.Add(this.GroupBoxMain);
            this.Controls.Add(this.stPadLibControl1);
            this.Controls.Add(this.ImageLcd);
            this.Controls.Add(this.ImagePad);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Ký điện tử";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.GroupBoxSignature.ResumeLayout(false);
            this.GroupBoxSignData.ResumeLayout(false);
            this.GroupBoxImage.ResumeLayout(false);
            this.GroupBoxImage.PerformLayout();
            this.GroupBoxDisplayImage.ResumeLayout(false);
            this.GroupBoxDisplayImage.PerformLayout();
            this.GroupBoxSensor.ResumeLayout(false);
            this.GroupBoxSensor.PerformLayout();
            this.GroupBoxScrolling.ResumeLayout(false);
            this.GroupBoxScrolling.PerformLayout();
            this.GroupBoxHotSpots.ResumeLayout(false);
            this.GroupBoxSignWindow.ResumeLayout(false);
            this.GroupBoxLedColor.ResumeLayout(false);
            this.GroupBoxLedColor.PerformLayout();
            this.GroupBoxWindow.ResumeLayout(false);
            this.GroupBoxWindow.PerformLayout();
            this.GroupBoxDrawing.ResumeLayout(false);
            this.GroupBoxDrawing.PerformLayout();
            this.GroupBoxMain.ResumeLayout(false);
            this.GroupBoxMain.PerformLayout();
            this.GroupBoxTimeouts.ResumeLayout(false);
            this.GroupBoxTimeouts.PerformLayout();
            this.GroupBoxDisplay.ResumeLayout(false);
            this.GroupBoxDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageLed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageLcd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePad)).EndInit();
            this.GroupBoxPadService.ResumeLayout(false);
            this.GroupBoxPadService.PerformLayout();
            this.GroupBoxKeypadDemo.ResumeLayout(false);
            this.GroupBoxKeypadDemo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private signotec.STPadLibNet.STPadLibControl stPadLibControl1;
        private System.Windows.Forms.Button ButtonDevCount;
        private System.Windows.Forms.ListBox ListOfDevices;
        private System.Windows.Forms.Label LabelType;
        private System.Windows.Forms.Label LabelSerial;
        private System.Windows.Forms.Button ButtonOpenClose;
        private System.Windows.Forms.CheckBox CheckBoxLedY;
        private System.Windows.Forms.CheckBox CheckBoxLedG;
        private System.Windows.Forms.CheckBox CheckBoxLedDef;
        private System.Windows.Forms.Button ButtonStartCancel;
        private System.Windows.Forms.SaveFileDialog DialogSave;
        private System.Windows.Forms.ComboBox ComboBoxFileFormat;
        private System.Windows.Forms.PictureBox ImagePad;
        private System.Windows.Forms.PictureBox ImageLcd;
        private System.Windows.Forms.PictureBox ImageLed;
        private System.Windows.Forms.Label LabelPenColor;
        private System.Windows.Forms.Label LabelBackColor;
	    private System.Windows.Forms.Button ButtonBackColor;
        private System.Windows.Forms.Button ButtonSettings;
        private System.Windows.Forms.GroupBox GroupBoxWindow;
        private System.Windows.Forms.TextBox TextBoxText;
        private System.Windows.Forms.ComboBox ComboBoxFontList;
        private System.Windows.Forms.ComboBox ComboBoxTextAlign;
        private System.Windows.Forms.ComboBox ComboBoxTextRect;
        private System.Windows.Forms.CheckBox CheckBoxItalic;
        private System.Windows.Forms.CheckBox CheckBoxUnderline;
        private System.Windows.Forms.CheckBox CheckBoxBold;
        private System.Windows.Forms.MaskedTextBox TextBoxFontSize;
        private System.Windows.Forms.MaskedTextBox TextBoxSensorX;
        private System.Windows.Forms.GroupBox GroupBoxDisplayImage;
        private System.Windows.Forms.Label LabelSensorX;
        private System.Windows.Forms.Label LabelSensorHeight;
        private System.Windows.Forms.MaskedTextBox TextBoxSensorHeight;
        private System.Windows.Forms.Label LabelSensorWidth;
        private System.Windows.Forms.MaskedTextBox TextBoxSensorWidth;
        private System.Windows.Forms.Label LabelSensorY;
        private System.Windows.Forms.MaskedTextBox TextBoxSensorY;
        private System.Windows.Forms.GroupBox GroupBoxLedColor;
        private System.Windows.Forms.ComboBox ComboBoxSampleRate;
        private System.Windows.Forms.GroupBox GroupBoxSensor;
        private System.Windows.Forms.MaskedTextBox TextBoxDrawX;
        private System.Windows.Forms.Label LabelDrawX;
        private System.Windows.Forms.Label LabelDrawHeight;
        private System.Windows.Forms.MaskedTextBox TextBoxDrawY;
        private System.Windows.Forms.MaskedTextBox TextBoxDrawHeight;
        private System.Windows.Forms.Label LabelDrawY;
        private System.Windows.Forms.MaskedTextBox TextBoxDrawWidth;
        private System.Windows.Forms.Label LabelDrawWidth;
        private System.Windows.Forms.ComboBox ComboBoxSignData;
        private System.Windows.Forms.Label LabelFontSize;
        private System.Windows.Forms.Button ButtonClearDisplay;
        private System.Windows.Forms.GroupBox GroupBoxSignature;
        private System.Windows.Forms.GroupBox GroupBoxSignData;
        private System.Windows.Forms.GroupBox GroupBoxImage;
        private System.Windows.Forms.Label LabelCapturedPoints;
        private System.Windows.Forms.Button ButtonOpenSeparateWindow;
        private System.Windows.Forms.ComboBox ComboBoxPenWidthControl;
        private System.Windows.Forms.Label LabelFirmware;
        private System.Windows.Forms.Label LabelDisplay;
	    private System.Windows.Forms.Button ButtonRectColor;
        private System.Windows.Forms.Label LabelRectangle;
        private System.Windows.Forms.Button ButtonShowSignData;
        private System.Windows.Forms.Button ButtonSaveSignature;
        private System.Windows.Forms.ComboBox ComboBoxMirror;
        private System.Windows.Forms.Button ButtonShowSignature;
        private System.Windows.Forms.Button ButtonRetry;
        private System.Windows.Forms.Button ButtonConfirm;
        private System.Windows.Forms.GroupBox GroupBoxMain;
        private System.Windows.Forms.Label LabelPort;
        private System.Windows.Forms.OpenFileDialog DialogOpen;
        private System.Windows.Forms.Button ButtonStop;
        private System.Windows.Forms.ColorDialog DialogColor;
        private System.Windows.Forms.Button ButtonFontColor;
        private System.Windows.Forms.Label LabelFontColor;
	    private System.Windows.Forms.Button ButtonPenColor;
	    private System.Windows.Forms.Button ButtonDraw;
	    private System.Windows.Forms.ComboBox ComboBoxSource;
	    private System.Windows.Forms.ComboBox ComboBoxImage;
	    private System.Windows.Forms.GroupBox GroupBoxDrawing;
	    private System.Windows.Forms.CheckBox CheckBoxImageOptions;
        private System.Windows.Forms.GroupBox GroupBoxTimeouts;
	    private System.Windows.Forms.Button ButtonTimeoutStartStop;
	    private System.Windows.Forms.ComboBox ComboBoxTimeout;
	    private System.Windows.Forms.MaskedTextBox TextBoxTimeoutBefore;
	    private System.Windows.Forms.MaskedTextBox TextBoxTimeoutAfter;
	    private System.Windows.Forms.Label LabelTimeBefore;
        private System.Windows.Forms.Label LabelAfterAction;
        private System.Windows.Forms.GroupBox GroupBoxDisplay;
        private System.Windows.Forms.ComboBox ComboBoxDisplayPenWidth;
	    private System.Windows.Forms.Button ButtonDisplayPenColor;
	    private System.Windows.Forms.Label LabelDisplayPenColor;
	    private System.Windows.Forms.Label LabelTarget;
	    private System.Windows.Forms.ComboBox ComboBoxTarget;
	    private System.Windows.Forms.Label LabelSource;
        private System.Windows.Forms.CheckBox CheckBoxEraseHotspots;
	    private System.Windows.Forms.Button ButtonShowDisplayImage;
	    private System.Windows.Forms.ComboBox ComboBoxDisplayFileFormat;
	    private System.Windows.Forms.Button ButtonSaveDisplayImage;
	    private System.Windows.Forms.Label LabelScrollPos;
	    private System.Windows.Forms.Label LabelScrollSpeed;
        private System.Windows.Forms.MaskedTextBox TextBoxScrollSpeed;
	    private System.Windows.Forms.MaskedTextBox TextBoxScrollY;
	    private System.Windows.Forms.Label Label1;
	    private System.Windows.Forms.Label LabelTargetSize;
        private System.Windows.Forms.CheckBox CheckBoxWholeBuffer;
        private System.Windows.Forms.ComboBox ComboBoxBacklight;
        private System.Windows.Forms.Label LabelBacklight;
        private System.Windows.Forms.Button ButtonSearchConfig;
        private System.Windows.Forms.Label LabelSearchConfig;
        private System.Windows.Forms.Button ButtonRSA;
        private System.Windows.Forms.GroupBox GroupBoxHotSpots;
        private System.Windows.Forms.ComboBox ComboBoxHotspotMode;
        private System.Windows.Forms.ComboBox ComboBoxHotspotId;
        private System.Windows.Forms.Button ButtonSetHotSpot;
        private System.Windows.Forms.ComboBox ComboBoxHotspotType;
        private System.Windows.Forms.GroupBox GroupBoxSignWindow;
        private System.Windows.Forms.Button ButtonClearSignWin;
        private System.Windows.Forms.Button ButtonSetSignWin;
        private System.Windows.Forms.ComboBox ComboBoxRotation;
        private System.Windows.Forms.Label LabelRotation;
        private System.Windows.Forms.Button ButtonAdjustment;
        private System.Windows.Forms.GroupBox GroupBoxPadService;
        private System.Windows.Forms.Button ButtonService;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox TextBoxScrollX;
        private System.Windows.Forms.ComboBox ComboBoxPDF;
        private System.Windows.Forms.MaskedTextBox TextBoxScale;
        private System.Windows.Forms.Label LabelScale;
        private System.Windows.Forms.Label LabelCropping;
        private System.Windows.Forms.MaskedTextBox TextBoxSelectHeight;
        private System.Windows.Forms.MaskedTextBox TextBoxSelectWidth;
        private System.Windows.Forms.MaskedTextBox TextBoxSelectY;
        private System.Windows.Forms.MaskedTextBox TextBoxSelectX;
        private System.Windows.Forms.Label LabelSelectX;
        private System.Windows.Forms.Label LabelSelectY;
        private System.Windows.Forms.Label LabelSelectWidth;
        private System.Windows.Forms.Label LabelSelectHeight;
        private System.Windows.Forms.ComboBox ComboBoxUnit;
        private System.Windows.Forms.ComboBox ComboBoxPage;
        private System.Windows.Forms.Label LabelSize;
        private System.Windows.Forms.CheckBox CheckBoxBufferPage;
        private System.Windows.Forms.Label LabelPageCount;
        private System.Windows.Forms.GroupBox GroupBoxScrolling;
        private System.Windows.Forms.CheckBox CheckBoxPenScrolling;
        private System.Windows.Forms.Button ButtonSetScrollArea;
        private System.Windows.Forms.CheckBox CheckBoxCurrentTarget;
        private System.Windows.Forms.CheckBox CheckBoxFixedFontSize;
        private System.Windows.Forms.Label LabelSignatureData;
        private System.Windows.Forms.CheckBox CheckBoxNFC;
        private System.Windows.Forms.CheckBox CheckBoxNFCPerm;
        private System.Windows.Forms.Button buttonKeypadDemo;
        private System.Windows.Forms.TextBox textBoxKeypadEntries;
        private System.Windows.Forms.GroupBox GroupBoxKeypadDemo;
        private System.Windows.Forms.MaskedTextBox TextBoxStByTimeout;
        private System.Windows.Forms.Label LabelStByTimeout;
        private System.Windows.Forms.CheckBox CheckBoxStByTimeout;
        private System.Windows.Forms.Button ButtonStByTimeoutMax;
    }
}

