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
// Version: 8.5.1.0
// Date:    2020-11-12

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Emr.SignPad
{
    public partial class SignView : Form
    {
        private string _timestamp = null;
        private string _serial = null;
        private string _key = null;
        private string _firmware = null;
        private string _hash1 = null;
        private string _hash2 = null;

        // remember default values (set on init) to be able to reuse the window
        private int windowWidthDefault = int.MaxValue;
        private int WindowHeightDefaultNoExtra = int.MaxValue;
        private int WindowHeightDefaultExtra = int.MaxValue;
        private int groupBoxExtraWidthDefault = int.MaxValue;
        private int groupBoxExtraHeightDefault = int.MaxValue;
        private int labelHash1WidthDefault = int.MaxValue;
        private int labelHash1HeightDefault = int.MaxValue;
        private int labelHash2WidthDefault = int.MaxValue;
        private int labelHash2HeightDefault = int.MaxValue;
        private int LabelHash2Ydefault = int.MaxValue;

        public SignView()
        {
            InitializeComponent();
            SetDefaultWindowParameters();
        }

        public new void ShowDialog()
        {
            bool extraDataPresent = false;
            if (_timestamp != null)
            {
                extraDataPresent = true;
                LabelTimestamp.Text = "Timestamp: " + _timestamp;
            }
            if (_serial != null)
            {
                extraDataPresent = true;
                LabelSerial.Text = "Pad Serial: " + _serial;
            }
            if (_key != null)
            {
                extraDataPresent = true;
                LabelKey.Text = "Signing Key: " + _key;
            }
            if (_firmware != null)
            {
                extraDataPresent = true;
                LabelFirmware.Text = "Pad Firmware: " + _firmware;
            }
            // the hashstringsize in pixels will be determined, to ensure the window is wide enough
            int maxWidthLabel = 0;
            // also, maybe an extra line has to be added, which affects positions of windows and following labels
            int extraHeightOffset = 0;
            if (_hash1 != null)
            {
                extraDataPresent = true;

                string hashTextFormatted = "";
                int offsetHeight = ProcessHashText(ref hashTextFormatted, ref maxWidthLabel, _hash1, LabelHash1);
                LabelHash1.Text = "Hash 1:\n" + hashTextFormatted;

                if (offsetHeight != 0)
                {
                    LabelHash1.Height = labelHash1HeightDefault + offsetHeight;
                    extraHeightOffset += offsetHeight;
                }
            }
            if (_hash2 != null)
            {
                extraDataPresent = true;

                // ensure label height always fits
                LabelHash2.Location = new Point(LabelHash2.Location.X, (LabelHash2Ydefault + extraHeightOffset));

                string hashTextFormatted = "";
                int offsetHeight = ProcessHashText(ref hashTextFormatted, ref maxWidthLabel, _hash2, LabelHash2);
                LabelHash2.Text = "Hash 2:\n" + hashTextFormatted;

                if (offsetHeight != 0)
                {
                    LabelHash2.Height = labelHash2HeightDefault + offsetHeight;
                    extraHeightOffset += offsetHeight;
                }
            }

            // align height if necessary, else set defaults 
            Height = getWindowHeight(extraDataPresent) + extraHeightOffset;
            GroupBoxExtraData.Height = groupBoxExtraHeightDefault + extraHeightOffset;
            if (extraHeightOffset == 0) // else labelheight has been set separately while processing content
            {  
                LabelHash1.Height = labelHash1HeightDefault;
                LabelHash2.Height = labelHash2HeightDefault;
            }

            // calculate width offset if necessary
            int minLabelHashWidthDefault = Math.Min(labelHash1WidthDefault, labelHash2WidthDefault);
            int offsetWidth = 0;
            if (maxWidthLabel > minLabelHashWidthDefault)
                offsetWidth = maxWidthLabel - minLabelHashWidthDefault;

            // apply offset width, else set defaults 
            LabelHash1.Width = labelHash1WidthDefault + offsetWidth;
            LabelHash2.Width = labelHash2WidthDefault + offsetWidth;
            GroupBoxExtraData.Width = groupBoxExtraWidthDefault + offsetWidth;
            Width = windowWidthDefault + offsetWidth;

            base.ShowDialog();
        }

        private int ProcessHashText(ref string hashTextFormatted, ref int maxWidthLabel, string hashText, Label hashLabel)
        {
            // This method determins whether we need an extra line for the hash, and calculates the size in pixels of the 
            // hash text to compare with the window width. 
            // It also processes the text (adds newline if necessary) and returns the required additional horizontal offset.
            int offsetHeight = 0;
            int maxStringWidth = 0;

            if (hashText.Length <= 96)
            {   // SHA1 or SHA256, no extra line needed. Processes just width
                maxStringWidth = TextRenderer.MeasureText(Graphics.FromHwnd(Handle), hashText, hashLabel.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.TextBoxControl).Width;

                hashTextFormatted = hashText;
            }
            else
            {   // SHA512
                offsetHeight = 10;
                string hashLine1data = hashText.Substring(0, 95);
                string hashLine2data = hashText.Substring(96);
                int hashLine1size = TextRenderer.MeasureText(Graphics.FromHwnd(Handle), hashLine1data, hashLabel.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.TextBoxControl).Width;
                int hashLine2size = TextRenderer.MeasureText(Graphics.FromHwnd(Handle), hashLine2data, hashLabel.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.TextBoxControl).Width;
                if (hashLine1size >= hashLine2size)
                    maxStringWidth = hashLine1size;
                else
                    maxStringWidth = hashLine2size;

                hashTextFormatted = hashLine1data + "\n" + hashLine2data;
            }

            if (maxStringWidth > maxWidthLabel)
                maxWidthLabel = maxStringWidth;

            return offsetHeight;
        }

        public byte[] SignData
        {
            set { axSignDraw1.SignData = value; }
        }

        public string Timestamp
        {
            set { _timestamp = value; }
        }

        public string Serial
        {
            set { _serial = value; }
        }

        public string Firmware
        {
            set { _firmware = value; }
        }

        public string Key
        {
            set { _key = value; }
        }

        public string Hash1
        {
            get { return _hash1; }
            set { _hash1 = value; }
        }

        public string Hash2
        {
            get { return _hash2; }
            set { _hash2 = value; }
        }

        public void SetDrawingMode(int mode)
        {
            axSignDraw1.SetDrawingMode(mode);
        }

        private void SetDefaultWindowParameters()
        {
            // remember all default values which could be adjusted dynamically 
            windowWidthDefault = Width;
            WindowHeightDefaultNoExtra = 296;   // if no extra data are provided: smaller window
            WindowHeightDefaultExtra = 442;
            groupBoxExtraWidthDefault = GroupBoxExtraData.Width;
            groupBoxExtraHeightDefault = GroupBoxExtraData.Height;
            labelHash1WidthDefault = LabelHash1.Width;
            labelHash1HeightDefault = LabelHash1.Height;
            labelHash2WidthDefault = LabelHash2.Width;
            labelHash2HeightDefault = LabelHash2.Height;
            LabelHash2Ydefault = LabelHash2.Location.Y;
        }

        private int getWindowHeight(bool withExtraData)
        {
            if (withExtraData)
                return WindowHeightDefaultExtra;
            else
                return WindowHeightDefaultNoExtra;
        }
    }
}