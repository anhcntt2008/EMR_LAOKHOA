using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOSLib;

namespace BOSERP
{
    public class OwingDetailsInfo : BusinessObject
    {
        public int FK_GECurrencyID { get; set; }

        public string GECurrencyName { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPriceByCurrency)]
        public double DueAmount { get; set; }
    }
}
