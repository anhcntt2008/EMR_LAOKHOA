using System;
using System.Collections.Generic;
using System.Text;

namespace BOSERP.Modules.ExpressDesigner
{
    public class ExpressDesignerModule : BaseModuleERP
    {
        public ExpressDesignerModule()
        {
            Name = "ExpressDesigner";
            InitializeModule();
        }

        public override void Show()
        {
            guiStudio guiStudio = new guiStudio();
            guiStudio.Module = this;
            guiStudio.Show();
        }        
    }
}
