// Copyright 2000-2019, signotec GmbH, Ratingen, Germany, All Rights Reserved
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
// Version: 8.4.2.0
// Date:    2019-01-15

namespace Emr.SignPad
{
    partial class ImageOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageOptions));
            this.Frame2 = new System.Windows.Forms.GroupBox();
            this.RadioResolutionOrg = new System.Windows.Forms.RadioButton();
            this.TextBoxResolution = new System.Windows.Forms.MaskedTextBox();
            this.RadioResolutionCustom = new System.Windows.Forms.RadioButton();
            this.Frame1 = new System.Windows.Forms.GroupBox();
            this.RadioSizeOrg = new System.Windows.Forms.RadioButton();
            this.TextBoxWidth = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxHeight = new System.Windows.Forms.MaskedTextBox();
            this.RadioSizeCustom = new System.Windows.Forms.RadioButton();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.DialogColor = new System.Windows.Forms.ColorDialog();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.CheckBoxVarWidth = new System.Windows.Forms.CheckBox();
            this.CheckBoxVarBrightness = new System.Windows.Forms.CheckBox();
            this.ButtonPenColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckBoxSmoothing = new System.Windows.Forms.CheckBox();
            this.ComboBoxPenWidth = new System.Windows.Forms.ComboBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.ComboBoxBitmap = new System.Windows.Forms.ComboBox();
            this.CheckBoxEraseHotspots = new System.Windows.Forms.CheckBox();
            this.ComboBoxTimestamp = new System.Windows.Forms.ComboBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ComboBoxHorAlign = new System.Windows.Forms.ComboBox();
            this.CheckBoxDontCrop = new System.Windows.Forms.CheckBox();
            this.ComboBoxVerAlign = new System.Windows.Forms.ComboBox();
            this.Frame2.SuspendLayout();
            this.Frame1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Frame2
            // 
            this.Frame2.Controls.Add(this.RadioResolutionOrg);
            this.Frame2.Controls.Add(this.TextBoxResolution);
            this.Frame2.Controls.Add(this.RadioResolutionCustom);
            this.Frame2.Location = new System.Drawing.Point(167, 8);
            this.Frame2.Name = "Frame2";
            this.Frame2.Size = new System.Drawing.Size(153, 65);
            this.Frame2.TabIndex = 2;
            this.Frame2.TabStop = false;
            // 
            // RadioResolutionOrg
            // 
            this.RadioResolutionOrg.Location = new System.Drawing.Point(8, 16);
            this.RadioResolutionOrg.Name = "RadioResolutionOrg";
            this.RadioResolutionOrg.Size = new System.Drawing.Size(121, 17);
            this.RadioResolutionOrg.TabIndex = 4;
            this.RadioResolutionOrg.TabStop = true;
            this.RadioResolutionOrg.Text = "Display Resolution";
            this.RadioResolutionOrg.UseVisualStyleBackColor = true;
            // 
            // TextBoxResolution
            // 
            this.TextBoxResolution.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxResolution.Location = new System.Drawing.Point(26, 38);
            this.TextBoxResolution.Mask = "#000";
            this.TextBoxResolution.Name = "TextBoxResolution";
            this.TextBoxResolution.PromptChar = ' ';
            this.TextBoxResolution.Size = new System.Drawing.Size(30, 20);
            this.TextBoxResolution.TabIndex = 5;
            this.TextBoxResolution.Text = "300";
            this.TextBoxResolution.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // RadioResolutionCustom
            // 
            this.RadioResolutionCustom.Checked = true;
            this.RadioResolutionCustom.Location = new System.Drawing.Point(8, 40);
            this.RadioResolutionCustom.Name = "RadioResolutionCustom";
            this.RadioResolutionCustom.Size = new System.Drawing.Size(89, 17);
            this.RadioResolutionCustom.TabIndex = 3;
            this.RadioResolutionCustom.TabStop = true;
            this.RadioResolutionCustom.Text = "           dpi";
            this.RadioResolutionCustom.UseVisualStyleBackColor = true;
            this.RadioResolutionCustom.CheckedChanged += new System.EventHandler(this.RadioResolutionCustom_CheckedChanged);
            // 
            // Frame1
            // 
            this.Frame1.Controls.Add(this.RadioSizeOrg);
            this.Frame1.Controls.Add(this.TextBoxWidth);
            this.Frame1.Controls.Add(this.TextBoxHeight);
            this.Frame1.Controls.Add(this.RadioSizeCustom);
            this.Frame1.Location = new System.Drawing.Point(8, 8);
            this.Frame1.Name = "Frame1";
            this.Frame1.Size = new System.Drawing.Size(153, 65);
            this.Frame1.TabIndex = 12;
            this.Frame1.TabStop = false;
            // 
            // RadioSizeOrg
            // 
            this.RadioSizeOrg.Checked = true;
            this.RadioSizeOrg.Location = new System.Drawing.Point(8, 16);
            this.RadioSizeOrg.Name = "RadioSizeOrg";
            this.RadioSizeOrg.Size = new System.Drawing.Size(89, 17);
            this.RadioSizeOrg.TabIndex = 14;
            this.RadioSizeOrg.TabStop = true;
            this.RadioSizeOrg.Text = "Display Size";
            this.RadioSizeOrg.UseVisualStyleBackColor = true;
            this.RadioSizeOrg.CheckedChanged += new System.EventHandler(this.RadioSizeOrg_CheckedChanged);
            // 
            // TextBoxWidth
            // 
            this.TextBoxWidth.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxWidth.Enabled = false;
            this.TextBoxWidth.Location = new System.Drawing.Point(27, 38);
            this.TextBoxWidth.Mask = "#0000";
            this.TextBoxWidth.Name = "TextBoxWidth";
            this.TextBoxWidth.PromptChar = ' ';
            this.TextBoxWidth.Size = new System.Drawing.Size(37, 20);
            this.TextBoxWidth.TabIndex = 13;
            this.TextBoxWidth.Text = "320";
            this.TextBoxWidth.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // TextBoxHeight
            // 
            this.TextBoxHeight.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TextBoxHeight.Enabled = false;
            this.TextBoxHeight.Location = new System.Drawing.Point(83, 38);
            this.TextBoxHeight.Mask = "#0000";
            this.TextBoxHeight.Name = "TextBoxHeight";
            this.TextBoxHeight.PromptChar = ' ';
            this.TextBoxHeight.Size = new System.Drawing.Size(37, 20);
            this.TextBoxHeight.TabIndex = 15;
            this.TextBoxHeight.Text = "160";
            this.TextBoxHeight.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // RadioSizeCustom
            // 
            this.RadioSizeCustom.Location = new System.Drawing.Point(8, 40);
            this.RadioSizeCustom.Name = "RadioSizeCustom";
            this.RadioSizeCustom.Size = new System.Drawing.Size(127, 17);
            this.RadioSizeCustom.TabIndex = 16;
            this.RadioSizeCustom.TabStop = true;
            this.RadioSizeCustom.Text = "              x                px";
            this.RadioSizeCustom.UseVisualStyleBackColor = true;
            this.RadioSizeCustom.CheckedChanged += new System.EventHandler(this.RadioSizeCustom_CheckedChanged);
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(247, 245);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(73, 25);
            this.ButtonOK.TabIndex = 0;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // DialogColor
            // 
            this.DialogColor.FullOpen = true;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.CheckBoxVarWidth);
            this.GroupBox3.Controls.Add(this.CheckBoxVarBrightness);
            this.GroupBox3.Controls.Add(this.ButtonPenColor);
            this.GroupBox3.Controls.Add(this.label1);
            this.GroupBox3.Controls.Add(this.CheckBoxSmoothing);
            this.GroupBox3.Controls.Add(this.ComboBoxPenWidth);
            this.GroupBox3.Location = new System.Drawing.Point(8, 174);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(312, 65);
            this.GroupBox3.TabIndex = 28;
            this.GroupBox3.TabStop = false;
            // 
            // CheckBoxVarWidth
            // 
            this.CheckBoxVarWidth.AutoSize = true;
            this.CheckBoxVarWidth.Location = new System.Drawing.Point(192, 40);
            this.CheckBoxVarWidth.Name = "CheckBoxVarWidth";
            this.CheckBoxVarWidth.Size = new System.Drawing.Size(95, 17);
            this.CheckBoxVarWidth.TabIndex = 23;
            this.CheckBoxVarWidth.Text = "Variable Width";
            this.CheckBoxVarWidth.UseVisualStyleBackColor = true;
            // 
            // CheckBoxVarBrightness
            // 
            this.CheckBoxVarBrightness.AutoSize = true;
            this.CheckBoxVarBrightness.Location = new System.Drawing.Point(192, 16);
            this.CheckBoxVarBrightness.Name = "CheckBoxVarBrightness";
            this.CheckBoxVarBrightness.Size = new System.Drawing.Size(116, 17);
            this.CheckBoxVarBrightness.TabIndex = 22;
            this.CheckBoxVarBrightness.Text = "Variable Brightness";
            this.CheckBoxVarBrightness.UseVisualStyleBackColor = true;
            // 
            // ButtonPenColor
            // 
            this.ButtonPenColor.BackColor = System.Drawing.Color.Black;
            this.ButtonPenColor.Location = new System.Drawing.Point(45, 14);
            this.ButtonPenColor.Name = "ButtonPenColor";
            this.ButtonPenColor.Size = new System.Drawing.Size(21, 21);
            this.ButtonPenColor.TabIndex = 1;
            this.ButtonPenColor.UseVisualStyleBackColor = false;
            this.ButtonPenColor.Click += new System.EventHandler(this.ButtonPenColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Color:";
            // 
            // CheckBoxSmoothing
            // 
            this.CheckBoxSmoothing.AutoSize = true;
            this.CheckBoxSmoothing.Location = new System.Drawing.Point(79, 16);
            this.CheckBoxSmoothing.Name = "CheckBoxSmoothing";
            this.CheckBoxSmoothing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CheckBoxSmoothing.Size = new System.Drawing.Size(110, 17);
            this.CheckBoxSmoothing.TabIndex = 21;
            this.CheckBoxSmoothing.Text = "Smooth Signature";
            // 
            // ComboBoxPenWidth
            // 
            this.ComboBoxPenWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxPenWidth.Items.AddRange(new object[] {
            "Variable Pen Width",
            "1 px Pen Width",
            "2 px Pen Width",
            "3 px Pen Width",
            "4 px Pen Width",
            "5 px Pen Width",
            "6 px Pen Width",
            "7 px Pen Width",
            "8 px Pen Width",
            "9 px Pen Width",
            "10 px Pen Width"});
            this.ComboBoxPenWidth.Location = new System.Drawing.Point(11, 38);
            this.ComboBoxPenWidth.Name = "ComboBoxPenWidth";
            this.ComboBoxPenWidth.Size = new System.Drawing.Size(175, 21);
            this.ComboBoxPenWidth.TabIndex = 19;
            this.ComboBoxPenWidth.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPenWidth_SelectedIndexChanged);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.ComboBoxBitmap);
            this.GroupBox2.Controls.Add(this.CheckBoxEraseHotspots);
            this.GroupBox2.Controls.Add(this.ComboBoxTimestamp);
            this.GroupBox2.Location = new System.Drawing.Point(8, 79);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(153, 89);
            this.GroupBox2.TabIndex = 27;
            this.GroupBox2.TabStop = false;
            // 
            // ComboBoxBitmap
            // 
            this.ComboBoxBitmap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxBitmap.Items.AddRange(new object[] {
            "Signature only",
            "Incl. Background",
            "Incl. Backgr. & Overlay",
            "Incl. Curr. Background",
            "Incl. Curr. Backgr. & Overl."});
            this.ComboBoxBitmap.Location = new System.Drawing.Point(8, 14);
            this.ComboBoxBitmap.Name = "ComboBoxBitmap";
            this.ComboBoxBitmap.Size = new System.Drawing.Size(137, 21);
            this.ComboBoxBitmap.TabIndex = 22;
            this.ComboBoxBitmap.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBitmap_SelectedIndexChanged);
            // 
            // CheckBoxEraseHotspots
            // 
            this.CheckBoxEraseHotspots.Enabled = false;
            this.CheckBoxEraseHotspots.Location = new System.Drawing.Point(8, 40);
            this.CheckBoxEraseHotspots.Name = "CheckBoxEraseHotspots";
            this.CheckBoxEraseHotspots.Size = new System.Drawing.Size(131, 17);
            this.CheckBoxEraseHotspots.TabIndex = 18;
            this.CheckBoxEraseHotspots.Text = "Erase Hotspot Areas";
            // 
            // ComboBoxTimestamp
            // 
            this.ComboBoxTimestamp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxTimestamp.Items.AddRange(new object[] {
            "No Timestamp",
            "Timestamp rel. to Display",
            "Timestamp rel. to Image"});
            this.ComboBoxTimestamp.Location = new System.Drawing.Point(8, 62);
            this.ComboBoxTimestamp.Name = "ComboBoxTimestamp";
            this.ComboBoxTimestamp.Size = new System.Drawing.Size(137, 21);
            this.ComboBoxTimestamp.TabIndex = 20;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ComboBoxHorAlign);
            this.GroupBox1.Controls.Add(this.CheckBoxDontCrop);
            this.GroupBox1.Controls.Add(this.ComboBoxVerAlign);
            this.GroupBox1.Location = new System.Drawing.Point(167, 79);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(153, 89);
            this.GroupBox1.TabIndex = 26;
            this.GroupBox1.TabStop = false;
            // 
            // ComboBoxHorAlign
            // 
            this.ComboBoxHorAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxHorAlign.Enabled = false;
            this.ComboBoxHorAlign.Items.AddRange(new object[] {
            "Left",
            "Center",
            "Right"});
            this.ComboBoxHorAlign.Location = new System.Drawing.Point(8, 38);
            this.ComboBoxHorAlign.Name = "ComboBoxHorAlign";
            this.ComboBoxHorAlign.Size = new System.Drawing.Size(137, 21);
            this.ComboBoxHorAlign.TabIndex = 10;
            // 
            // CheckBoxDontCrop
            // 
            this.CheckBoxDontCrop.Location = new System.Drawing.Point(8, 16);
            this.CheckBoxDontCrop.Name = "CheckBoxDontCrop";
            this.CheckBoxDontCrop.Size = new System.Drawing.Size(107, 17);
            this.CheckBoxDontCrop.TabIndex = 9;
            this.CheckBoxDontCrop.Text = "Don\'t crop Image";
            this.CheckBoxDontCrop.CheckedChanged += new System.EventHandler(this.CheckBoxDontCrop_CheckedChanged);
            // 
            // ComboBoxVerAlign
            // 
            this.ComboBoxVerAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxVerAlign.Enabled = false;
            this.ComboBoxVerAlign.Items.AddRange(new object[] {
            "Top",
            "Center",
            "Bottom"});
            this.ComboBoxVerAlign.Location = new System.Drawing.Point(8, 62);
            this.ComboBoxVerAlign.Name = "ComboBoxVerAlign";
            this.ComboBoxVerAlign.Size = new System.Drawing.Size(137, 21);
            this.ComboBoxVerAlign.TabIndex = 11;
            // 
            // ImageOptions
            // 
            this.AcceptButton = this.ButtonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(327, 276);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Frame2);
            this.Controls.Add(this.Frame1);
            this.Controls.Add(this.ButtonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Advanced Options";
            this.Frame2.ResumeLayout(false);
            this.Frame2.PerformLayout();
            this.Frame1.ResumeLayout(false);
            this.Frame1.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton RadioResolutionOrg;
        private System.Windows.Forms.MaskedTextBox TextBoxResolution;
        private System.Windows.Forms.RadioButton RadioResolutionCustom;
        private System.Windows.Forms.GroupBox Frame2;
        private System.Windows.Forms.RadioButton RadioSizeOrg;
        private System.Windows.Forms.MaskedTextBox TextBoxWidth;
        private System.Windows.Forms.MaskedTextBox TextBoxHeight;
        private System.Windows.Forms.RadioButton RadioSizeCustom;
        private System.Windows.Forms.GroupBox Frame1;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.ColorDialog DialogColor;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.CheckBox CheckBoxVarWidth;
        private System.Windows.Forms.CheckBox CheckBoxVarBrightness;
        private System.Windows.Forms.Button ButtonPenColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckBoxSmoothing;
        private System.Windows.Forms.ComboBox ComboBoxPenWidth;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.ComboBox ComboBoxBitmap;
        private System.Windows.Forms.CheckBox CheckBoxEraseHotspots;
        private System.Windows.Forms.ComboBox ComboBoxTimestamp;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.ComboBox ComboBoxHorAlign;
        private System.Windows.Forms.CheckBox CheckBoxDontCrop;
        private System.Windows.Forms.ComboBox ComboBoxVerAlign;
    }
}