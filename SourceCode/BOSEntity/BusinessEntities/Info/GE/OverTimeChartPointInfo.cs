using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOSLib;

namespace BOSERP
{
    public class OverTimeChartPointInfo : BusinessObject
    {
        public DateTime DocumentDate { get; set; }

        public double TotalAmount { get; set; }

        public double TotalQty { get; set; }
    }
}
