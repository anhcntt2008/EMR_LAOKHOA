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

namespace Emr.SignPad
{
	partial class PadServiceMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PadServiceMessageBox));
            this.buttonPadServiceMessageBoxOk = new System.Windows.Forms.Button();
            this.PictureBoxInformationIcon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxInformationIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
           // 
            // buttonPadServiceMessageBoxOk
            // 
            this.buttonPadServiceMessageBoxOk.Location = new System.Drawing.Point(468, 16);
            this.buttonPadServiceMessageBoxOk.Name = "buttonPadServiceMessageBoxOk";
            this.buttonPadServiceMessageBoxOk.Size = new System.Drawing.Size(80, 27);
            this.buttonPadServiceMessageBoxOk.TabIndex = 0;
            this.buttonPadServiceMessageBoxOk.Text = "OK";
            this.buttonPadServiceMessageBoxOk.UseVisualStyleBackColor = true;
            this.buttonPadServiceMessageBoxOk.Click += new System.EventHandler(this.ButtonPadServiceMessageBoxOk_Click);
            // 
            // PictureBoxInformationIcon
            // 
            this.PictureBoxInformationIcon.Image = ((System.Drawing.Image)(resources.GetObject("PictureBoxInformationIcon.Image")));
            this.PictureBoxInformationIcon.Location = new System.Drawing.Point(26, 27);
            this.PictureBoxInformationIcon.Name = "PictureBoxInformationIcon";
            this.PictureBoxInformationIcon.Size = new System.Drawing.Size(36, 36);
            this.PictureBoxInformationIcon.TabIndex = 1;
            this.PictureBoxInformationIcon.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 78);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.buttonPadServiceMessageBoxOk);
            this.panel1.Location = new System.Drawing.Point(0, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 54);
            this.panel1.TabIndex = 3;
            // 
            // PadServiceMessageBox
            // 
            this.AcceptButton = this.buttonPadServiceMessageBoxOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(559, 182);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PictureBoxInformationIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PadServiceMessageBox";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pad Service";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxInformationIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button buttonPadServiceMessageBoxOk;
        private System.Windows.Forms.PictureBox PictureBoxInformationIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
	}
}