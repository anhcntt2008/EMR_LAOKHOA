using System;
using System.Text;
using System.Collections.Generic;
using BOSLib;

namespace BOSERP
{
    public class ACIncomeStatementsInfo : BusinessObject
    {
        public String ACCreditAccountNo { get; set; }
        public String ACDebitAccountNo { get; set; }
        public String GECurrencyNo { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo01StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo01EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo02StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo02EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo10StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo10EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo11StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo11EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo20StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo20EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo21StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo21EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo22StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo22EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo23StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo23EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo24StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo24EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo25StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo25EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo31StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo31EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo30StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo30EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo32StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo32EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo40StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo40EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo50StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo50EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo51StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo51EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo52StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo52EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo60StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo60EndPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo70StartPeriodAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo70EndPeriodAmount { get; set; }
    }
}
