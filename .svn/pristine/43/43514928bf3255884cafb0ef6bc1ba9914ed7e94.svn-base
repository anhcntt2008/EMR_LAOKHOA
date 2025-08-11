using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.MEEmr;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class DSMEEMR100 : BOSERPScreen
    {
        private List<METemplatesInfo> _listTemplate;

        public DSMEEMR100(List<METemplatesInfo> listTemplate)
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            _listTemplate = listTemplate.OrderBy(t => t.METemplateName).ToList();
            fld_lkeFK_METemplateID.Properties.DropDownRows = 15;
        }
        /// <summary>
        /// NOT USE
        /// </summary>
        public DSMEEMR100()
        {
            InitializeComponent();
            _listTemplate = new List<METemplatesInfo>();
        }
        private void fld_btn_Ok_Click(object sender, EventArgs e)
        {
            Ok();
        }
        public void Ok()
        {
            MEEmrEntities entity = (MEEmrEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            if (fld_chkAppendToCurrentDocument.Checked)
            {
                if (string.IsNullOrEmpty(fld_txtFileName.Text))
                {
                    MessageBox.Show("Chọn ít nhất 1 file đính kèm", "Chọn file");
                    return;
                }
                entity.MENewEmrDocument = new MEEmrDocumentsInfo()
                {
                    FK_METemplateID = 0,
                    MEEmrDocumentExternalFile = fld_txtFileName.Text
                };
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                var template = fld_lkeFK_METemplateID.GetSelectedDataRow() as METemplatesInfo;
                Ok(template);
            }
        }
        public void Ok(METemplatesInfo template)
        {
            MEEmrEntities entity = (MEEmrEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            if (template == null)
            {
                MessageBox.Show("Chọn ít nhất 1 mẫu bệnh án", "Chọn mẫu");
                return;
            }
            entity.MENewEmrDocument = new MEEmrDocumentsInfo()
            {
                FK_METemplateID = template.METemplateID,
                MEEmrDocumentFile = template.METemplateNo + DateTime.Now.ToString("_ddMMyyyy_HHmmssfff_") + Guid.NewGuid().ToString().Replace('-', '_'),
                MEEmrDocumentNo = template.METemplateNo,
                MEEmrDocumentCode = template.METemplateNo,
                MEEmrDocumentGuid = template.METemplateGuid,
                MEEmrDocumentDesc = fld_medMEEmrDocumentDesc.Text,
                MEEmrDocumentExternalFile = fld_txtFileName.Text,
                FK_HREmployeeCreatedID = BOSApp.CurrentEmployeesInfo.HREmployeeID
            };
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void fld_btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            MEEmrEntities entity = (MEEmrEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.MENewEmrDocument = null;
            fld_lkeFK_METemplateID.Properties.DataSource = _listTemplate;
            this.KeyPreview = true;
            this.fld_grdSelectionTemplate.Screen = this;
            this.fld_grdSelectionTemplate.InitializeControl();
            this.fld_grdSelectionTemplate.DataSource = this._listTemplate;
            this.fld_grdSelectionTemplate.RefreshDataSource();
            this.fld_grdSelectionTemplate.Refresh();
        }

        private void fld_btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.DefaultExt = "docx";
            openFileDialog1.Filter = "Document files (*.DOCX;*.PDF)|*.DOCX;*.PDF|PDF files (*.PDF)|*.PDF";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fld_txtFileName.Text = openFileDialog1.FileName;
                if (openFileDialog1.FileName.EndsWith("pdf") || openFileDialog1.FileName.EndsWith("PDF"))
                {
                    fld_chkAppendToCurrentDocument.Checked = false;
                    fld_chkAppendToCurrentDocument.Enabled = false;
                }
                else
                {
                    fld_chkAppendToCurrentDocument.Enabled = true;
                }
            }
        }

        private void fld_chkAppendToCurrentDocument_CheckedChanged(object sender, EventArgs e)
        {
            if (fld_chkAppendToCurrentDocument.Checked)
                fld_lkeFK_METemplateID.Enabled = false;
            else
                fld_lkeFK_METemplateID.Enabled = true;
        }

        private void DSMEEMR100_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
        }
    }
}
