using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clas.Model.DrugInfo
{
    public class DrugCheckRequest
    {
        public DateTime date { get; set; }
        public string doctor_name { get; set; }
        public string nurse_name { get; set; }
        public string owner_id { get; set; }
        public string code { get; set; }
        public List<Drug> drugs { get; set; }
        public List<string> diseases { get; set; }
        public DrugInfoPatient patient { get; set; }
    }

    public class DrugCheckResult
    {
        public List<object> warnings { get; set; }
        public List<object> errors { get; set; }
        public string url { get; set; }
        public long receivedTs { get; set; }
        public long processedTs { get; set; }
        public DrugCheckResultModel result { get; set; }
    }

    public class DrugCheckResultModel
    {
        public List<DrugInteractions> drug_interactions { get; set; }
        public List<Contraindication> contraindications { get; set; }
        public List<AlcoholInteraction> alcohol_interaction { get; set; }
        public List<Warning> warnings { get; set; }
        public List<Pregnancy> pregnancy { get; set; }
        public List<Allergy> allergy { get; set; }
        public List<IndicationByDisease> indication_by_disease { get; set; }
        public List<Tobacco> tobacco { get; set; }
    }

    public class DrugInteractions
    {
        public string a { get; set; }
        public string a_name { get; set; }
        public string b { get; set; }
        public string b_name { get; set; }
        public int? severity { get; set; }
        public string summary { get; set; }
        public override string ToString()
        {
            return string.Format("{0} tương tác với {1}. {2}",
                                 a_name, b_name, this.SeverityName);
        }
        public string SeverityName
        {
            get
            {
                if (!severity.HasValue)
                {
                    return "Chưa rõ";
                }
                else switch (severity)
                    {
                        case 1:
                            return "Nhẹ";
                        case 2:
                            return "Vừa phải";
                        case 3:
                            return "Nghiêm Trọng";
                        case 4:
                            return "Chống chỉ định";
                        default:
                            return "Chưa xác định";
                    }
            }
        }
    }

    public class Contraindication
    {
        public string drug { get; set; }
        public string drug_name { get; set; }
        public string reactor { get; set; }
        public string reason { get; set; }
        public string explanation { get; set; }
        public override string ToString()
        {
            return string.Format("{0}: {1}", drug_name, this.Reason);
        }

        public string Reason
        {
            get
            {
                if (reason.CompareTo("max_age") == 0)
                {
                    return string.Format("không dùng cho người dưới {0} tuổi", explanation);
                }
                if (reason.CompareTo("min_age") == 0)
                {
                    return string.Format("không dùng cho người trên {0} tuổi", explanation);
                }

                return string.Format("Chống chỉ định {0} {1}", reason, explanation);
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class AlcoholInteraction
    {
        public string drug { get; set; }
        public string drug_name { get; set; }
        public int severity { get; set; }
        public string summary { get; set; }
        public override string ToString()
        {
            return string.Format("{0}.Mức độ: {1}. {2}", drug_name, severity, summary);
        }
    }

    public class Warning
    {
        public string drug { get; set; }
        public Warning1 warning { get; set; }
        public bool isWarning { get; set; }
        public string drug_name { get; set; }
        public string WarningText
        {
            get
            {
                return this.ToString();
            }
        }
        public override string ToString()
        {
            if (warning == null)
            {
                return string.Format("{0}: {1}", drug_name, isWarning ? "Cảnh báo" : "");
            }
            else
                return string.Format("{0}: {1}. {2}", drug_name, "Cảnh báo phụ nữ cho con bú", warning.breast_feeding);
        }
    }

    public class Warning1
    {
        public string breast_feeding { get; set; }
    }
    /// <summary>
    /// Canh bao phu nu mang thai
    /// </summary>
    public class Pregnancy
    {
        public string risk_factor { get; set; }
        public string drug { get; set; }
        public string drug_name { get; set; }
        public string warning { get; set; }
        public override string ToString()
        {
            return string.Format("{0}. Yếu tố nguy cơ: {1}. {2}", drug_name, risk_factor, warning);
        }
    }
    /// <summary>
    /// Dị ứng
    /// </summary>
    public class Allergy
    {
        public string name { get; set; }
        public string registered_number { get; set; }
        public override string ToString()
        {
            return string.Format("{0}: {1}", name, registered_number);
        }
    }
    /// <summary>
    /// chỉ định theo bệnh nền
    /// </summary>
    public class IndicationByDisease
    {
        public string drug { get; set; }
        public string drug_name { get; set; }
        public string reactor { get; set; }
        public string reason { get; set; }
        public string explanation { get; set; }
        public string type { get; set; }
        public override string ToString()
        {
            return string.Format("{0}: {1}. {2}. {3}. {4}", drug_name, reactor, reason, explanation, TypeName);
        }
        public string TypeName
        {
            get
            {
                switch (type)
                {
                    case "C":
                        return "Chống chỉ định";
                    case "I":
                        return "Chỉ định";
                    case "D":
                        return "Gây ra bệnh";
                    default:
                        return "";
                }
            }
        }
    }
    /// <summary>
    /// Tương tác với thuốc lá 
    /// </summary>
    public class Tobacco
    {
        public string drug { get; set; }
        public string drug_name { get; set; }
        public string mechanism { get; set; }
        public string effect { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}. {2}", drug_name, mechanism, effect);
        }
    }

}
