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
using BOSLib;

namespace BOSERP.Modules.MEEmr
{
    public class CustomRichEditCommandFactoryService : IRichEditCommandFactoryService
    {
        readonly IRichEditCommandFactoryService service;
        readonly RichEditControl control;

        public MEEmrModule Module { get; private set; }

        public CustomRichEditCommandFactoryService(MEEmrModule module, RichEditControl control, IRichEditCommandFactoryService service)
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
            else if (id == RichEditCommandId.Print)
            {
                return new CustomPrintDocumentCommand(Module, control);
            }
            else if (id == RichEditCommandId.PrintPreview)
            {
                return new CustomPrintPreviewtDocumentCommand(Module, control);
            }
            else if (id == RichEditCommandId.QuickPrint)
            {
                return new CustomQuickPrintDocumentCommand(Module, control);
            }
            //else if (id == RichEditCommandId.InsertSymbol)
            //{
            //    return new CustomInsertSymbolCommand(Module, control);
            //}
            //else if (id == RichEditCommandId.ChangeFontForeColor)
            //{
            //    return new CustomChangeFontForeColorDocumentCommand(Module, control);
            //}
            return service.CreateCommand(id);
        }
    }
    //public class CustomInsertSymbolCommand : InsertSymbolCommand
    //{
    //    private RichEditControl control;
    //    private MEEmrModule module;

    //    public CustomInsertSymbolCommand(MEEmrModule module, RichEditControl control) : base(control)
    //    {
    //        this.module = module;
    //        this.control = control;
    //    }
    //}
    public class CustomSaveDocumentCommand : SaveDocumentCommand
    {
        public MEEmrModule Module { get; private set; }
        public CustomSaveDocumentCommand(MEEmrModule module, IRichEditControl richEdit) : base(richEdit)
        {

            this.Module = module;
        }

        protected override void ExecuteCore()
        {
            BOSProgressBar.Start("Đang lưu và upload tập tin");
            try
            {
                if (Module.IsEmrReadOnly()) return;
                if (Module.IsForceRevokePermission()) return;
                if (Module.SaveFileDocument())
                {
                    base.ExecuteCore();
                    if (!DocumentServer.Modified)
                    {
                        if (!Module.SaveEmrDocumentInfoAndUploadFileSafe()) return;
                    }
                }
            }
            catch (Exception)
            {
                BOSProgressBar.Close();
                throw;
            }
            finally
            {
                BOSProgressBar.Close();
            }
        }
    }
    public class CustomPrintDocumentCommand : PrintCommand
    {
        public MEEmrModule Module { get; private set; }
        public CustomPrintDocumentCommand(MEEmrModule module, IRichEditControl control) : base(control)
        {
            this.Module = module;
        }
        protected override void ExecuteCore()
        {
            this.Module.ShowPrintDialog();
        }
    }
    public class CustomPrintPreviewtDocumentCommand : PrintPreviewCommand
    {
        public MEEmrModule Module { get; private set; }
        public CustomPrintPreviewtDocumentCommand(MEEmrModule module, IRichEditControl control) : base(control)
        {
            this.Module = module;
        }
        protected override void ExecuteCore()
        {
            this.Module.ShowPreviewPrintDialog();

        }
    }
    public class CustomQuickPrintDocumentCommand : PrintPreviewCommand
    {
        public MEEmrModule Module { get; private set; }
        public CustomQuickPrintDocumentCommand(MEEmrModule module, IRichEditControl control) : base(control)
        {
            this.Module = module;
        }
        protected override void ExecuteCore()
        {
            this.Module.QuickPrintDocument();

        }
    }
    public class CustomChangeFontForeColorDocumentCommand : ChangeFontColorCommand
    {
        public CustomChangeFontForeColorDocumentCommand(MEEmrModule module, IRichEditControl control) : base(control)
        {
            this.Module = module;
        }
        public MEEmrModule Module { get; private set; }
        protected override void NotifyBeginCommandExecution(ICommandUIState state)
        {
            base.NotifyBeginCommandExecution(state);
            this.UpdateUIState(state);
            if (!state.Enabled && this.CheckIsContentEditable()) state.Enabled = true;
            state.EditValue = Color.Red;
            this.ForceExecute(state);
        }
    }
}
