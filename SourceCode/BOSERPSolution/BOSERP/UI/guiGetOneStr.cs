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
    public partial class guiGetOneStr : Form
    {
        public string Value;
        public string _msg;

        public guiGetOneStr(string msg = "")
        {
            InitializeComponent();
            this._msg = msg;
        }
        public guiGetOneStr(string msg, string defaultStr)
        {
            InitializeComponent();
            this._msg = msg;
            this.txtString.Text = defaultStr;
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
        private void fld_btnSign_Click(object sender, EventArgs e)
        {
            this.Ok();
        }
        void Ok()
        {
            if (string.IsNullOrWhiteSpace(txtString.Text))
            {
                MessageBox.Show("Không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Value = txtString.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
        private void guiSign_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            txtMsg.Text = this._msg;
            txtString.Focus();
        }

        private void txtString_Enter(object sender, EventArgs e)
        {
            var edit = ((DevExpress.XtraEditors.TextEdit)sender);
            BeginInvoke(new MethodInvoker(() =>
            {
                edit.SelectionStart = 0;
                edit.SelectionLength = edit.Text.Length;
            }));
        }
    }
}