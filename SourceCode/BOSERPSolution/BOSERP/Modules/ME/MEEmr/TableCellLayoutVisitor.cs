using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Layout;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSERP.Modules.ME
{
    public class TableCellLayoutVisitor : LayoutVisitor
    {
        private readonly RichEditControl _richContrl;
        public List<FixedRange> Ranges;
        public TableCellLayoutVisitor(RichEditControl richEditControl)
        {
            _richContrl = richEditControl;
            Ranges = new List<FixedRange>();
        }
        protected override void VisitTableCell(LayoutTableCell cell)
        {
            var rowHeight = cell.Rows.Sum(r => r.Bounds.Height);
            if (cell.Bounds.Height < rowHeight)
            {
                Ranges.Add(cell.Range);
            }
        }
    }
}
