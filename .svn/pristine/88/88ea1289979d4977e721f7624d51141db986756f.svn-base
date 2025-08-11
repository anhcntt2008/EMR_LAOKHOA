using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSERP.Modules.ME.MEEmr
{
    class FieldLayoutVisitor : DevExpress.XtraRichEdit.API.Layout.LayoutVisitor
    {
        protected override void VisitRow(DevExpress.XtraRichEdit.API.Layout.LayoutRow row)
        {
            if (row.GetParentByType<DevExpress.XtraRichEdit.API.Layout.LayoutPageArea>() != null)
                System.Diagnostics.Debug.WriteLine("This row is located at X: {0}, Y: {1}, related range starts at {2}",
                    row.Bounds.X, row.Bounds.Y, row.Range.Start);
            // Call the base VisitRow method to walk down the tree to the child elements of the Row.
            // If you don't need them, comment out the next line. 
            base.VisitRow(row);
        }

        protected override void VisitPage(DevExpress.XtraRichEdit.API.Layout.LayoutPage page)
        {
            System.Diagnostics.Debug.WriteLine("Visiting page {0}", page.Index + 1);
            base.VisitPage(page);
        }

    }
}
