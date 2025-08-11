using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.MEEmr;
using DevExpress.XtraGrid.Views.Grid;
using Clas.Emr.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using BOSCommon;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using System.Drawing.Drawing2D;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using BOSComponent;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for guiUpdateEmrNo
    /// </summary>
    public partial class guiUpdateEmrNo : BOSERPScreen
    {
        private readonly string _emrNoCurrent;
        public string _emrNoNew;
        private MEEmrsController _emrCtrl;
        public guiUpdateEmrNo(string emrNoCurrent)
        {
            InitializeComponent();
            _emrCtrl = new MEEmrsController();
            _emrNoCurrent = emrNoCurrent;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.guiUpdateEmrNo_Ok_KeyDown);
        }
        
        private void guiUpdateEmrNo_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            guiUpdateEmrNo_lblMEEmrNoCurrent.Text = _emrNoCurrent;
            guiUpdateEmrNo_fld_txtMEEmrNo.Text = _emrNoCurrent;
        }

        private void guiUpdateEmrNo_btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        private void guiUpdateEmrNo_Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                Ok();
            }
        }

        private void guiUpdateEmrNo_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void Ok()
        {
            _emrNoNew = guiUpdateEmrNo_fld_txtMEEmrNo.Text.Trim();
            if (string.IsNullOrEmpty(_emrNoNew))
            {
                MessageBox.Show($"Vui lòng nhập mã bệnh án mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (_emrNoNew == _emrNoCurrent)
            {
                MessageBox.Show($"Mã bệnh án mới trùng với mã bệnh án hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (_emrCtrl.IsExistNo(_emrNoNew))
            {
                MessageBox.Show($"Mã bệnh án đã tồn tại. Vui lòng nhập mã bệnh án khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
