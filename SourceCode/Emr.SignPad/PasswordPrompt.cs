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
// Version: 8.4.3.0
// Date:    2019-09-13

using System;
using System.Drawing;
using System.Security;
using System.Windows.Forms;

namespace Emr.SignPad
{
    public partial class PasswordPrompt : Form
    {
        public SecureString PasswordHandover { get; set; }
        public SecureString PasswordHandoverOptional { get; set; }

        public int MaxWrongEntries { get; set; }

        private bool _extended;

        public PasswordPrompt(string labeltext, bool extended = false)
        {
            InitializeComponent();

            labelPasswordWindow.Text = labeltext;
            _extended = extended;
            PasswordHandover = new SecureString();
            MaxWrongEntries = 0;

            // scale fonts if screen resolution is not 96 dpi
            Graphics graphics = this.CreateGraphics();
            if (graphics.DpiX != 96F)
                this.Font = new Font(this.Font.FontFamily, this.Font.Size * 96F / graphics.DpiX, this.Font.Style, this.Font.Unit, this.Font.GdiCharSet, this.Font.GdiVerticalFont);
            graphics.Dispose();

            int extendWin = 125;

            if (!extended)
            {
                this.Height -= extendWin;
                ButtonOK.Top -= extendWin;
                buttonCancel.Top -= extendWin;
                labelOldPassword.Visible = false;
                textBoxPasswordOptional.Visible = false;
                labelInvalidateLeft.Visible = false;
                labelInvalidateRight.Visible = false;
                comboBoxInvalidate.Visible = false;
            }
        }
        
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            foreach (char c in TextBoxPassword.Text)
                PasswordHandover.AppendChar(c);
            if (_extended)
            {
                PasswordHandoverOptional = new SecureString();
                foreach (char c in textBoxPasswordOptional.Text)
                    PasswordHandoverOptional.AppendChar(c);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PasswordPrompt_Load(object sender, EventArgs e)
        {
            TextBoxPassword.Select();
        }

        private void comboBoxInvalidate_TextChanged(object sender, EventArgs e)
        {
            int invValue = 0;
            bool succ = int.TryParse(comboBoxInvalidate.Text, out invValue);
            if (succ)
                MaxWrongEntries = invValue;
            else
            { 
                comboBoxInvalidate.Text = 0.ToString();
                MaxWrongEntries = 0;
            }
        }
    }
}