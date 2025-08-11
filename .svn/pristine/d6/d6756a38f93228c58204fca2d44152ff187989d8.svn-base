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
    /// Summary description for guiUpdatePatientNo
    /// </summary>
    public partial class guiUpdatePatientNo : BOSERPScreen
    {
        private readonly string _patientNoCurrent;
        public string _patientNoNew;
        public string _patientRemarkNew;
        private MEEmrsController _emrCtrl;
        private MEPatientsController _patientCtrl;
        public guiUpdatePatientNo(string patientNoCurrent)
        {
            InitializeComponent();
            _emrCtrl = new MEEmrsController();
            _patientCtrl = new MEPatientsController();
            _patientNoCurrent = patientNoCurrent;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.guiUpdatePatientNo_Ok_KeyDown);
        }
        
        private void guiUpdatePatientNo_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            guiUpdatePatientNo_lblMEPatientNoCurrent.Text = _patientNoCurrent;
            guiUpdatePatientNo_fld_txtMEPatientNo.Text = _patientNoCurrent;
        }

        private void guiUpdatePatientNo_btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        private void guiUpdatePatientNo_Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                Ok();
            }
        }

        private void guiUpdatePatientNo_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void Ok()
        {
            _patientNoNew = guiUpdatePatientNo_fld_txtMEPatientNo.Text.Trim();
            _patientRemarkNew = guiUpdatePatientNo_rtbRemark.Text.Trim();
            if (string.IsNullOrEmpty(_patientNoNew))
            {
                MessageBox.Show($"Vui lòng nhập mã bệnh nhân mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (_patientNoNew == _patientNoCurrent)
            {
                MessageBox.Show($"Mã bệnh nhân mới trùng với mã bệnh nhân hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (_patientCtrl.IsExistNo(_patientNoNew))
            {
                MessageBox.Show($"Mã bệnh nhân đã tồn tại. Vui lòng nhập mã bệnh nhân khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (string.IsNullOrEmpty(_patientRemarkNew))
            {
                MessageBox.Show($"Vui lòng nhập lý do đổi mã", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
