using BOSLib;
using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOSERP.Modules.CompanyConstant.UI
{
    public partial class DMCS108 : BOSERPScreen
    {
        public DMCS108()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chắc chắc thực hiện chức năng này?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            var documentCtrl = new MEEmrDocumentsController();
            var signCtrl = new MEEmrDocumentSignsController();
            var documents = documentCtrl.GetListBusinessObjects<MEEmrDocumentsInfo>(documentCtrl.GetAllObjects());
            var ftpFileMng = new Clas.Business.Ftp.FileTemplateManager();
            BOSProgressBar.Start("Đang cập nhật dữ liệu");

            documents.Reverse();
            for (int i = 0; i < documents.Count; i++)
            {
                var item = documents[i];
                BOSProgressBar.SetText("Đang xử lý document " + i + "/" + documents.Count);
                //ftpFileMng.CopyFile("/Emr/" + item.MEEmrDocumentFile + ".docx", "/Emr/" + item.FK_MEEmrID + "/" + item.MEEmrDocumentFile + ".docx");
                //ftpFileMng.CopyFile("/Emr/" + item.MEEmrDocumentFile + ".pdf", "/Emr/" + item.FK_MEEmrID + "/" + item.MEEmrDocumentFile + ".pdf");

                //var signs = signCtrl.GetListBusinessObjects<MEEmrDocumentSignsInfo>(signCtrl.GetAllDataByForeignColumn("FK_MEEmrDocumentID", item.MEEmrDocumentID));
                //foreach (var s in signs)
                //{
                //    ftpFileMng.CopyFile("/Emr/Partials/" + s.MEEmrDocumentSignFile + ".docx", "/Emr/Partials/" + item.FK_MEEmrID + "/" + item.MEEmrDocumentFile + ".docx");
                //}
            }
            BOSProgressBar.Close();
            MessageBox.Show("Done");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chắc chắc thực hiện chức năng này?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            var emrCtrl = new MEEmrsController();
            var ftpFileMng = new Clas.Business.Ftp.FileTemplateManager();
            BOSProgressBar.Start("Đang cập nhật dữ liệu");

            var emrs = emrCtrl.GetListBusinessObjects<MEEmrsInfo>(emrCtrl.GetAllObjects());
            emrs.Reverse();
            int k = 0;
            foreach (var item in emrs)
            {
                k++;
                BOSProgressBar.SetText("Đang xử lý emr " + k + "/" + emrs.Count);
                ftpFileMng.CreateDirectory("/Emr/" + item.MEEmrID);
                ftpFileMng.CreateDirectory("/Emr/Signed/" + item.MEEmrID);
                ftpFileMng.CreateDirectory("/Emr/Partials/" + item.MEEmrID);
            }
            BOSProgressBar.Close();
            MessageBox.Show("Done");
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chắc chắc thực hiện chức năng này?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            var abbveCtrl = new MEEmrAbbrevsController();
            var alls = abbveCtrl.GetListBusinessObjects<MEEmrAbbrevsInfo>(abbveCtrl.GetAllObjects());
            RichEditDocumentServer server = new RichEditDocumentServer();
            BOSProgressBar.Start("Đang cập nhật dữ liệu");
            foreach (var item in alls)
            {
                if (!item.MEEmrAbbrevRichText && item.MEEmrAbbrevContent.StartsWith("{\\rtf1"))
                {
                    server.RtfText = item.MEEmrAbbrevContent;
                    item.MEEmrAbbrevContent = server.Text;
                }
                abbveCtrl.UpdateObject(item);
            }
            BOSProgressBar.Close();
            MessageBox.Show("Done");
        }
    }
}
