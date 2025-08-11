using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOSLib;
using Localization;

namespace BOSERP
{
    public partial class guiConfirmWithLongInfo : Form
    {
        public string Value;
        public string _message;

        public guiConfirmWithLongInfo(string message, string content, string title = "Xác nhận")
        {
            InitializeComponent();
            this._message = message;
            this.txtString.Text = content;
            this.Text = title;
            DialogResult = DialogResult.Cancel;
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void fld_btnOk_Click(object sender, EventArgs e)
        {
            this.Ok();
        }
        void Ok()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        private void gui_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            txtMsg.Text = this._message;
            btnOk.Focus();
        }
    }
}