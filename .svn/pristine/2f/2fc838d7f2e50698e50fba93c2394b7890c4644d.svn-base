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
using System.Drawing.Drawing2D;

namespace Emr.SignPad
{
    public partial class ImageView : Form
    {
        public ImageView()
        {
            InitializeComponent();
        }

        private void ImageView_Load(object sender, EventArgs e)
        {
            Width = BackgroundImage.Width + 2 * SystemInformation.FixedFrameBorderSize.Width;
            Height = BackgroundImage.Height + SystemInformation.CaptionHeight + 2 * SystemInformation.FixedFrameBorderSize.Height;

            if ((40 + Width) > Screen.FromControl(this).WorkingArea.Width)
            {
                BackgroundImage = ResizeImage(BackgroundImage, Screen.FromControl(this).WorkingArea.Width - 40, 0);
                Left = 20;
            }
            if ((40 + Height) > Screen.FromControl(this).WorkingArea.Height)
            {
                BackgroundImage = ResizeImage(BackgroundImage, 0, Screen.FromControl(this).WorkingArea.Height - 40);
                Top = 20;
            }

            Width = BackgroundImage.Width + 2 * SystemInformation.FixedFrameBorderSize.Width;
            Height = BackgroundImage.Height + SystemInformation.CaptionHeight + 2 * SystemInformation.FixedFrameBorderSize.Height;
        }

        private static Image ResizeImage(Image srcImg, int width, int height)
        {
            if ((width <= 0) && (height <= 0))
                return srcImg;

            if (width > 0)
                height = (int)Math.Round((float)srcImg.Height * ((float)width / (float)srcImg.Width));
            else
                width = (int)Math.Round((float)srcImg.Width * ((float)height / (float)srcImg.Height));

            Bitmap resizedImg = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImg))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(srcImg, new Rectangle(0, 0, width, height));
            }
            return resizedImg;
        }
    }
}