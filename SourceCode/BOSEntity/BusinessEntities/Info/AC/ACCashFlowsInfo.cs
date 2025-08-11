using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOSLib;

namespace BOSERP
{
    public class ACCashFlowsInfo : BusinessObject
    {
        public String ACCreditAccountNo { get; set; }
        public String ACDebitAccountNo { get; set; }
        public String GECurrencyNo { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC01EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC02EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC03EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC04EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC05EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC06EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC07EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC20EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC21EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC22EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC23EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC24EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC25EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC26EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC27EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC30EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC31EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC32EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC33EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC34EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC35EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC36EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC40EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC50EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC60EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC61EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC70EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC01StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC02StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC03StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC04StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC05StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC06StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC07StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC20StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC21StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC22StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC23StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC24StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC25StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC26StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC27StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC30StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC31StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC32StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC33StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC34StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC35StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC36StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC40StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC50StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC60StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC61StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double AC70StartPeriodAmount { get; set; }

    }
}
