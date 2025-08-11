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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Emr.SignPad
{
    public partial class ImageOptions : Form
    {
        public ImageOptions()
        {
            InitializeComponent();

            // scale fonts if screen resolution is not 96 dpi
            Graphics graphics = this.CreateGraphics();
            if (graphics.DpiX != 96F)
                this.Font = new Font(this.Font.FontFamily, this.Font.Size * 96F / graphics.DpiX, this.Font.Style, this.Font.Unit, this.Font.GdiCharSet, this.Font.GdiVerticalFont);
            graphics.Dispose();

            if (ComboBoxBitmap.SelectedIndex < 0)
                ComboBoxBitmap.SelectedIndex = 0;
            if (ComboBoxTimestamp.SelectedIndex < 0)
                ComboBoxTimestamp.SelectedIndex = 0;
            if (ComboBoxPenWidth.SelectedIndex < 0)
                ComboBoxPenWidth.SelectedIndex = 0;
            if (ComboBoxHorAlign.SelectedIndex < 0)
                ComboBoxHorAlign.SelectedIndex = 1;
            if (ComboBoxVerAlign.SelectedIndex < 0)
                ComboBoxVerAlign.SelectedIndex = 1;
        }
	
	    private void ButtonOK_Click(object sender, EventArgs e)
	    {
	        if (RadioSizeCustom.Checked && ((TextBoxWidth.Text == "") || (TextBoxHeight.Text == "")))
            {
                MessageBox.Show("Please enter valid width and height values!", Application.ProductName);
	            return;
	        }
	        if (RadioResolutionCustom.Checked && (TextBoxResolution.Text == ""))
            {
                MessageBox.Show("Please enter a valid resolution value!", Application.ProductName);
	            return;
	        }
	        this.Visible = false;
	    }
	
	    private void ButtonPenColor_Click(object sender, EventArgs e)
	    {
	        DialogColor.Color = ButtonPenColor.BackColor;
	        if (DialogColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
	            ButtonPenColor.BackColor = DialogColor.Color;
	    }

        private void ComboBoxBitmap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxBitmap.SelectedIndex > 0)
            {
                CheckBoxEraseHotspots.Enabled = true;
                CheckBoxDontCrop.Enabled = false;
                ComboBoxHorAlign.Enabled = false;
                ComboBoxVerAlign.Enabled = false;
            }
            else
            {
                CheckBoxEraseHotspots.Enabled = false;
                CheckBoxDontCrop.Enabled = true;
                if ((CheckBoxDontCrop.Checked == true) && (RadioSizeCustom.Checked = true))
                {
                    ComboBoxHorAlign.Enabled = true;
                    ComboBoxVerAlign.Enabled = true;
                }
            }
        }

        private void CheckBoxDontCrop_CheckedChanged(object sender, EventArgs e)
        {
	        if (CheckBoxDontCrop.Checked && RadioSizeCustom.Checked)
            {
	            ComboBoxHorAlign.Enabled = true;
	            ComboBoxVerAlign.Enabled = true;
            }
	        else
            {
	            ComboBoxHorAlign.Enabled = false;
	            ComboBoxVerAlign.Enabled = false;
	        }
	    }
	
	    private void RadioResolutionCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioResolutionCustom.Checked)
                TextBoxResolution.Enabled = true;
            else
                TextBoxResolution.Enabled = false;
	    }
	
	    private void RadioSizeCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioSizeCustom.Checked)
            {
                TextBoxWidth.Enabled = true;
                TextBoxHeight.Enabled = true;
                if (CheckBoxDontCrop.Checked)
                {
                    ComboBoxHorAlign.Enabled = true;
                    ComboBoxVerAlign.Enabled = true;
                }
            }
            else
            {
                TextBoxWidth.Enabled = false;
                TextBoxHeight.Enabled = false;
            }
	    }
	
	    private void RadioSizeOrg_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioSizeOrg.Checked)
            {
	            ComboBoxHorAlign.Enabled = false;
	            ComboBoxVerAlign.Enabled = false;
            }
        }

        private void ComboBoxPenWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxPenWidth.SelectedIndex == 0)
            {
                CheckBoxVarBrightness.Enabled = false;
                CheckBoxVarWidth.Enabled = false;
            }
            else
            {
                CheckBoxVarBrightness.Enabled = true;
                CheckBoxVarWidth.Enabled = true;
            }
        }

        public int ImageWidth
        {
            get { return int.Parse(TextBoxWidth.Text); }
            set { TextBoxWidth.Text = String.Format("{0}", value); }
        }

        public int ImageHeight
        {
            get { return int.Parse(TextBoxHeight.Text); }
            set { TextBoxHeight.Text = String.Format("{0}", value); }
        }

        public short ImageResolution
        {
            get { return short.Parse(TextBoxResolution.Text); }
        }

        public bool ImageSizeOrg
        {
            get { return RadioSizeOrg.Checked; }
        }

        public bool ImageResolutionOrg
        {
            get { return RadioResolutionOrg.Checked; }
        }

        public int HorizontalAlignment
        {
            get { return ComboBoxHorAlign.SelectedIndex; }
        }

        public int VerticalAlignment
        {
            get { return ComboBoxVerAlign.SelectedIndex; }
        }

        public int Timestamp
        {
            get { return ComboBoxTimestamp.SelectedIndex; }
        }

        public int PenWidth
        {
            get { return ComboBoxPenWidth.SelectedIndex; }
        }

        public bool VariableWidth
        {
            get { return CheckBoxVarWidth.Checked; }
        }

        public bool VariableBrightness
        {
            get { return CheckBoxVarBrightness.Checked; }
        }

        public bool VariableSmoothing
        {
            get { return CheckBoxSmoothing.Checked; }
        }

        public Color PenColor
        {
            get { return ButtonPenColor.BackColor; }
        }

        public bool EraseHotspots
        {
            get { return CheckBoxEraseHotspots.Checked; }
        }

        public bool DontCrop
        {
            get { return CheckBoxDontCrop.Checked; }
        }

        public int Bitmap
        {
            get { return ComboBoxBitmap.SelectedIndex; }
            set { ComboBoxBitmap.SelectedIndex = value; }
        }

        public bool BitmapEnabled
        {
            set { ComboBoxBitmap.Enabled = value; }
        }
    }
}