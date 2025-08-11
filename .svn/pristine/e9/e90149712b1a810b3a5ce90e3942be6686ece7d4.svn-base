// Copyright 2000-2015, signotec GmbH, Ratingen, Germany, All Rights Reserved
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
// Version: 8.1.4.4
// Date:    2015-04-16

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using signotec.STPadLibNet;

namespace Emr.SignPad
{
    public partial class CaptureWindow : Form
    {
        private MainWindow _parent = null;

        public CaptureWindow(MainWindow parent, STPadLib stPadLib)
        {
            InitializeComponent();

            _parent = parent;
            stPadLibControl1.ControlSetSTPadLib(stPadLib);
        }

        public void SetControlBackColor(Color color)
        {
            stPadLibControl1.ControlBackColor = color;
        }

        public void SetControlRectColor(Color color)
        {
            stPadLibControl1.ControlRectColor = color;
        }

        public void SetControlPenColor(Color color)
        {
            stPadLibControl1.ControlPenColor = color;
        }

        public void SetControlPenWidth(int width)
        {
            stPadLibControl1.ControlPenWidth = width;
        }

        public void SetControlMirrorDisplay(int value)
        {
            stPadLibControl1.ControlMirrorDisplay = (MirrorMode)value;
        }

        [DesignerSerializationVisibility(0)]
        [Localizable(false)]
        public new Size Size
        {
            get
            {
                Size size = new Size();
                size.Width = base.Width - 2 * SystemInformation.FrameBorderSize.Width;
                size.Height = base.Height - SystemInformation.CaptionHeight + 2 * SystemInformation.FrameBorderSize.Height;
                return size;
            }
            set
            {
                Size size = new Size();
                size.Width = value.Width + 2 * SystemInformation.FrameBorderSize.Width;
                size.Height = value.Height + SystemInformation.CaptionHeight + 2 * SystemInformation.FrameBorderSize.Height;
                base.Size = size;
            }
        }

        private void CaptureWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.CaptureWindowClosed();
            stPadLibControl1.Dispose();
        }
    }
}