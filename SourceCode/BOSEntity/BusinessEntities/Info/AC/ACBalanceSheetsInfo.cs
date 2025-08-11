using System;
using System.Text;
using System.Collections.Generic;
using BOSLib;

namespace BOSERP
{
    public class ACBalanceSheetsInfo : BusinessObject
    {
        public String ACCreditAccountNo { get; set; }
        public String ACDebitAccountNo { get; set; }
        public String GECurrencyNo { get; set; }        
        
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo111EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo111StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo112EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo112StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo121EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo121StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo122EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo122StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo123EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo123StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo129EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo129StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo131EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo131StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo132EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo132StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo133EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo133StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo134EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo134StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo135EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo135StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo136EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo136StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo137EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo137StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo139EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo139StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo141EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo141StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo149EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo149StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo151EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo151StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo152EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo152StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo153EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo153StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo154EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo154StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo155EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo155StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo158EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo158StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo211EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo211StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo212EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo212StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo213EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo213StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo218EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo218StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo219EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo219StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo221EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo221StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo222EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo222StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo223EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo223StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo224EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo224StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo225EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo225StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo226EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo226StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo227EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo227StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo228EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo228StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo229EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo229StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo230EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo231EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo232EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo230StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo231StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo232StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo241EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo241StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo242EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo242StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo251EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo251StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo252EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo252StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo258EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo258StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo259EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo259StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo261EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo261StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo262EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo262StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo268EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo268StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo311EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo311StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo312EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo312StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo313EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo313StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo314EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo314StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo315EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo315StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo316EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo316StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo317EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo317StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo318EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo318StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo319EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo319StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo320EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo320StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo323EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo323StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo331EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo331StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo332EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo332StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo333EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo333StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo334EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo334StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo335EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo335StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo336EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo336StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo337EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo337StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo338EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo338StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo339EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo339StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo411EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo411StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo412EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo412StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo413EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo413StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo414EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo414StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo415EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo415StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo416EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo416StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo417EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo417StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo418EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo418StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo419EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo419StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo420EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo420StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo421EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo421StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo422EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo422StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo431EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo431StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo432EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo432StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo433EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo433StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo001EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo001StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo002EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo002StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo003EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo003StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo004EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo004StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo007EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo007StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo008EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo008StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo100StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo100EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo110StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo110EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo120StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo120EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo130StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo130EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo140StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo140EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo150StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo150EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo200StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo200EndYearBalance { get; set; }        

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo210StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo210EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo220StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo220EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo240StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo240EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo250StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo250EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo260StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo260EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo270StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo270EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo300StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo300EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo310StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo310EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo330StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo330EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo400StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo400EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo410StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo410EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo430StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo430EndYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo440StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo440EndYearBalance { get; set; }

        #region Report 1
        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo11EndYearBalance { get; set; }
        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo11StartYearBalance { get; set; }

        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo12EndYearBalance { get; set; }
        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo12StartYearBalance { get; set; }

        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo13EndYearBalance { get; set; }
        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo13StartYearBalance { get; set; }

        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo21EndYearBalance { get; set; }
        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo21StartYearBalance { get; set; }

        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo31EndYearBalance { get; set; }
        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo31StartYearBalance { get; set; }

        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo32EndYearBalance { get; set; }
        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo32StartYearBalance { get; set; }

        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo41EndYearBalance { get; set; }
        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo41StartYearBalance { get; set; }

       // [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo42EndYearBalance { get; set; }
        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo42StartYearBalance { get; set; }

        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo43EndYearBalance { get; set; }
       // [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo43StartYearBalance { get; set; }


        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo44EndYearBalance { get; set; }
        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double ACNo44StartYearBalance { get; set; }

       // [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo51EndYearBalance { get; set; }
        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo51StartYearBalance { get; set; }

        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo52EndYearBalance { get; set; }
        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo52StartYearBalance { get; set; }

        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo53EndYearBalance { get; set; }
        //[FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double ACNo53StartYearBalance { get; set; }

        #endregion

        #region  Report 2
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC10EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC10StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC11EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC11StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC12EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC12StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC13EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC13StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC14EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC14StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC15EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC15StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC16EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC16StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC17EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC17StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC18EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC18StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC20EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC20StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC21EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC21StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC22EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC22StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC23EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC23StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC24EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC24StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC25EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC25StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC30EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC30StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC31EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC31StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC32EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC32StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC33EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC33StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC34EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC34StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC35EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC35StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC36EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC36StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC37EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC37StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC38EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC38StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC39EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC39StartYearBalance { get; set; }


        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC40EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC40StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC41EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC41StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC42EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC42StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC43EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC43StartYearBalance { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC44EndYearBalance { get; set; }
        [FormatGroup(FormatGroupAttribute.cstFormatGroupPercent)]
        public double AC44StartYearBalance { get; set; }

        #endregion

    }
}
