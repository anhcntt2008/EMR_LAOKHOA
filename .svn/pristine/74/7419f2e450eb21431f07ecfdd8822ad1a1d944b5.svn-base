using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOSCommon;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;

namespace BOSERP.Modules.SellStaff
{
    public partial class guiImportSignature : BOSERPScreen
    {
        public string SelectedField { get; private set; }
        public string SelectedFolder { get; internal set; }

        public guiImportSignature()
        {
            InitializeComponent();
        }

        private void guiImportSignature_Load(object sender, EventArgs e)
        {
        }

        private void fld_btnChoose_Click(object sender, EventArgs e)
        {
            if (xtraFolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = xtraFolderBrowserDialog1.SelectedPath;
            }
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolder.Text)) return;
            var empCtrl = new HREmployeesController();
            DirectoryInfo d = new DirectoryInfo(txtFolder.Text);
            FileInfo[] Files = d.GetFiles();
            foreach (FileInfo file in Files)
            {
                if (file.Name.ToLower().EndsWith(".jpg") || file.Name.ToLower().EndsWith(".png"))
                {
                    var no = file.Name.Substring(0, file.Name.Length - 4);
                    var emp = empCtrl.GetObjectByNo(no);
                    if (emp == null)
                    {
                        MessageBox.Show($"Không tồn tại nhân viên với mã nhân viên {no}. Không có chữ ký nào được import.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            SelectedField = "HREmployeeNo";
            SelectedFolder = txtFolder.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnImportByIDNo_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolder.Text)) return;
            var empCtrl = new HREmployeesController();
            DirectoryInfo d = new DirectoryInfo(txtFolder.Text);
            FileInfo[] Files = d.GetFiles();
            foreach (FileInfo file in Files)
            {
                if (file.Name.ToLower().EndsWith(".jpg") || file.Name.ToLower().EndsWith(".png"))
                {
                    var no = file.Name.Substring(0, file.Name.Length - 4);
                    var emp = empCtrl.GetEmployeeByCardNumber(no);
                    if (emp == null)
                    {
                        MessageBox.Show($"Không tồn tại nhân viên với số thẻ ID {no}. Không có chữ ký nào được import.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            SelectedField = "HREmployeeCardNumber";
            SelectedFolder = txtFolder.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
