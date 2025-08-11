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
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Linq;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.ViewInfo;
using BOSLib;
using DevExpress.XtraRichEdit;
using System.Configuration;
using Clas.Business.Ftp;
using File = System.IO.File;
using DevExpress.XtraRichEdit.Services;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraPrinting;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiDocumentPreview : BOSERPScreen
    {
        private MEEmrDocumentsInfo _document;
        private string _pw;

        public guiDocumentPreview(MEEmrDocumentsInfo row, string pw)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Escape_KeyDown);
            this._document = row;
            this._pw = pw;
        }

        private void Escape_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void guiDocumentPreview_Load(object sender, EventArgs e)
        {
            BOSProgressBar.Start("Đang tải xuống và mở tập tin");
            try
            {
                richEditControl1.ReadOnly = true;
                (this.Module as MEEmrModule).DownAndLoadDocx(richEditControl1, _document);

                //System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //var ftpFileMng = new FileTemplateManager();
                //var documentPath = configuration.AppSettings.Settings["TemplateServerPath"].Value.ToString();
                //string fileName = string.Format(@"{0}\Emr\{1}.docx", documentPath, _document.MEEmrDocumentFile);
                //ftpFileMng.DownloadFile("/Emr/", _document.MEEmrDocumentFile + ".docx", fileName);

                //if (!File.Exists(fileName))
                //{
                //    MessageBox.Show(("File bệnh án không tồn tại ở địa chỉ. " + fileName), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //using (OfficeOpenXmlCrypto.OfficeCryptoStream stream = OfficeOpenXmlCrypto.OfficeCryptoStream.Open(fileName, _pw))
                //{
                //    richEditControl1.LoadDocument(stream, DocumentFormat.OpenXml);
                //}

            }
            catch (OfficeOpenXmlCrypto.InvalidPasswordException ex)
            {
                MessageBox.Show(("Mật khẩu không hợp lệ. Không mở được tập tin"), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                BOSProgressBar.Close();
            }
            var myCommandFactory = new CustomRichEditPreviewCommandFactoryService(this.Module as MEEmrModule, _document.FK_METemplateID,
                this.richEditControl1, this.richEditControl1.GetService<IRichEditCommandFactoryService>());
            this.richEditControl1.ReplaceService<IRichEditCommandFactoryService>(myCommandFactory);
        }
    }
    public class CustomRichEditPreviewCommandFactoryService : IRichEditCommandFactoryService
    {
        readonly IRichEditCommandFactoryService service;
        readonly RichEditControl control;
        private int _templateId;
        public MEEmrModule Module { get; private set; }

        public CustomRichEditPreviewCommandFactoryService(MEEmrModule module, int templateId, RichEditControl control, IRichEditCommandFactoryService service)
        {
            DevExpress.Utils.Guard.ArgumentNotNull(control, "control");
            DevExpress.Utils.Guard.ArgumentNotNull(service, "service");
            this.control = control;
            this.service = service;
            this.Module = module;
            this._templateId = templateId;
        }

        public RichEditCommand CreateCommand(RichEditCommandId id)
        {
            if (id == RichEditCommandId.Print)
            {
                return new CustomPreviewPrintDocumentCommand(Module, this._templateId, control);
            }
            else if (id == RichEditCommandId.PrintPreview)
            {
                return new CustomPreviewPrintPreviewtDocumentCommand(Module, this._templateId, control);
            }
            else if (id == RichEditCommandId.QuickPrint)
            {
                return new CustomPreviewQuickPrintDocumentCommand(Module, this._templateId, control);
            }
            return service.CreateCommand(id);
        }
    }

    public class CustomPreviewPrintDocumentCommand : PrintCommand
    {
        private RichEditControl _richEdit;
        private int _templateId;
        public MEEmrModule Module { get; private set; }
        public CustomPreviewPrintDocumentCommand(MEEmrModule module, int templateId, RichEditControl control) : base(control)
        {
            this._richEdit = control;
            this.Module = module;
            this._templateId = templateId;
        }
        protected override void ExecuteCore()
        {
            this.Module.RemoveAllForPrint(this._richEdit, this._templateId);
            if (_richEdit != null)
            {
                this.Module.ShowPrintDialog(this._richEdit);
            }
        }
    }
    public class CustomPreviewPrintPreviewtDocumentCommand : PrintPreviewCommand
    {
        private RichEditControl _richEdit;
        private int _templateId;
        public MEEmrModule Module { get; private set; }
        public CustomPreviewPrintPreviewtDocumentCommand(MEEmrModule module, int templateId, RichEditControl control) : base(control)
        {
            this._richEdit = control;
            this.Module = module;
            this._templateId = templateId;
        }
        protected override void ExecuteCore()
        {
            this.Module.RemoveAllForPrint(this._richEdit, this._templateId);
            if (_richEdit != null)
            {
                this.Module.ShowPrintDialog(this._richEdit);
            }
        }
    }
    public class CustomPreviewQuickPrintDocumentCommand : PrintPreviewCommand
    {
        private RichEditControl _richEdit;
        private int _templateId;
        public MEEmrModule Module { get; private set; }
        public CustomPreviewQuickPrintDocumentCommand(MEEmrModule module, int templateId, RichEditControl control) : base(control)
        {
            this._richEdit = control;
            this.Module = module;
            this._templateId = templateId;
        }
        protected override void ExecuteCore()
        {
            this.Module.RemoveAllForPrint(this._richEdit, this._templateId);
            if (_richEdit != null)
            {
                this.Module.ShowPrintDialog(this._richEdit);
            }
        }

    }
}
