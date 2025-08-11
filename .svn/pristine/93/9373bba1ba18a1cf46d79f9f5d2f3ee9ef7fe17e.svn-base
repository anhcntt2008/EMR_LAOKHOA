using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BOSComponent;

namespace BOSERP.Modules.Report
{
    public partial class ReportGridControl : BOSGridControl
    {
        protected override void GridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            base.GridView_CustomDrawCell(sender, e);

            if (e.CellValue != null)
            {
                if (e.CellValue is DateTime)
                {
                    if (Convert.ToDateTime(e.CellValue).Date == DateTime.MaxValue.Date)
                    {
                        e.DisplayText = string.Empty;
                    }
                }
                else if (e.CellValue is int)
                {
                    if (Convert.ToInt32(e.CellValue) == 0)
                    {
                        e.DisplayText = string.Empty;
                    }
                }
                else if (e.CellValue is double)
                {
                    if (Convert.ToDouble(e.CellValue) == 0)
                    {
                        e.DisplayText = string.Empty;
                    }
                }
            }
        }
    }
}
