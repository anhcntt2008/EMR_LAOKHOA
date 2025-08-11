using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Utils.Commands;
using System.Drawing;

namespace BOSERP.Modules.METemplate
{
    public class CustomRichEditCommandFactoryService : IRichEditCommandFactoryService
    {
        readonly IRichEditCommandFactoryService service;
        readonly RichEditControl control;

        public METemplateModule Module { get; private set; }

        public CustomRichEditCommandFactoryService(METemplateModule module, RichEditControl control, IRichEditCommandFactoryService service)
        {
            DevExpress.Utils.Guard.ArgumentNotNull(control, "control");
            DevExpress.Utils.Guard.ArgumentNotNull(service, "service");
            this.control = control;
            this.service = service;
            this.Module = module;
        }

        public RichEditCommand CreateCommand(RichEditCommandId id)
        {
            if (id == RichEditCommandId.FileSave)
            {
                return new CustomSaveDocumentCommand(Module, control);
            }
            return service.CreateCommand(id);
        }
    }

    public class CustomSaveDocumentCommand : SaveDocumentCommand
    {
        public METemplateModule Module { get; private set; }
        public CustomSaveDocumentCommand(METemplateModule module, IRichEditControl richEdit) : base(richEdit)
        {

            this.Module = module;
        }

        protected override void ExecuteCore()
        {
            BOSLib.BOSProgressBar.Start("Đang lưu và upload tập tin");
            try
            {
                var bk = Module.ServerBackup();
                base.ExecuteCore();
                if (!DocumentServer.Modified)
                {
                    Module.SaveTemplate(true, !bk);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                BOSLib.BOSProgressBar.Close();
            }
        }
    }
}
