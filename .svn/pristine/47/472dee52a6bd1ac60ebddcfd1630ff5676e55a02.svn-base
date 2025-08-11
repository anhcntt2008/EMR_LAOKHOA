// Copyright 2000-2017, signotec GmbH, Ratingen, Germany, All Rights Reserved
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
// Version: 8.4.1.1
// Date:    2017-10-27

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Emr.SignPad
{
    public partial class SearchConfig : Form
    {
        private string _searchList = "";
        private int _count = 0;

        public SearchConfig()
        {
            InitializeComponent();

            // scale fonts if screen resolution is not 96 dpi
            Graphics graphics = this.CreateGraphics();
            if (graphics.DpiX != 96F)
                this.Font = new Font(this.Font.FontFamily, this.Font.Size * 96F / graphics.DpiX, this.Font.Style, this.Font.Unit, this.Font.GdiCharSet, this.Font.GdiVerticalFont);
            graphics.Dispose();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            _searchList = String.Empty;
            _count = 0;

            if (CheckBoxUSB.Checked)
            {
                _searchList = "HID;";
                _count++;
            }
            if (CheckBoxSerial.Checked)
            {
                if (RadioButtonAllCom.Checked)
                {
                    _searchList += "all;";
                    _count += 256;
                }
                else
                {
                    for (int i = 0; i < ListOfComPorts.CheckedIndices.Count; i++)
                    {
                        _searchList += String.Format("{0}", ListOfComPorts.CheckedIndices[i]) + ";";
                        _count++;
                    }
                }
            }
            if (CheckBoxIP1.Checked)
            {
                _searchList += "IP=" + TextBoxIP1.Text + ":" + TextBoxPort1.Text + ";";
                _count++;
            }
            if (CheckBoxIP2.Checked)
            {
                _searchList += "IP=" + TextBoxIP2.Text + ":" + TextBoxPort2.Text + ";";
                _count++;
            }
            if (CheckBoxIP3.Checked)
            {
                _searchList += "IP=" + TextBoxIP3.Text + ":" + TextBoxPort3.Text + ";";
                _count++;
            }
            if (CheckBoxIP4.Checked)
            {
                _searchList += "IP=" + TextBoxIP4.Text + ":" + TextBoxPort4.Text + ";";
                _count++;
            }

            if (_searchList.Equals(String.Empty))
                MessageBox.Show("You must select at least one type to search for!", Application.ProductName);
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void CheckBoxSerial_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonAllCom.Enabled = CheckBoxSerial.Checked;
            RadioButtonSelCom.Enabled = CheckBoxSerial.Checked;
        }

        private void RadioButtonSelCom_CheckedChanged(object sender, EventArgs e)
        {
            ListOfComPorts.Enabled = RadioButtonSelCom.Checked;
        }

        private void CheckBoxIP1_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxIP1.Enabled = CheckBoxIP1.Checked;
            TextBoxPort1.Enabled = CheckBoxIP1.Checked;
        }

        private void CheckBoxIP2_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxIP2.Enabled  = CheckBoxIP2.Checked;
            TextBoxPort2.Enabled  = CheckBoxIP2.Checked;
        }

        private void CheckBoxIP3_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxIP3.Enabled  = CheckBoxIP3.Checked;
            TextBoxPort3.Enabled  = CheckBoxIP3.Checked;
        }

        private void CheckBoxIP4_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxIP4.Enabled  = CheckBoxIP4.Checked;
            TextBoxPort4.Enabled  = CheckBoxIP4.Checked;
        }

        public bool USB
        {
            get { return CheckBoxUSB.Checked; }
        }

        public bool Serial
        {
            get { return CheckBoxSerial.Checked; }
        }

        public bool IP1
        {
            get { return CheckBoxIP1.Checked; }
        }

        public bool IP2
        {
            get { return CheckBoxIP2.Checked; }
        }

        public bool IP3
        {
            get { return CheckBoxIP3.Checked; }
        }

        public bool IP4
        {
            get { return CheckBoxIP4.Checked; }
        }

        public string SearchList
        {
            get { return _searchList; }
        }

        public int Count
        {
            get { return _count; }
        }
    }
}