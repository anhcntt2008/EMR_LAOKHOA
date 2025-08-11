using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOSERP
{
    public class ServiceStatusInfo
    {
        public int ServiceID { get; set; }

        public string ServiceName { get; set; }

        public string ServiceDesc { get; set; }

        public string ServiceStatus { get; set; }

        public DateTime ServiceDate { get; set; }

        public string ServiceOrderBy { get; set; }

        public string ServiceReturnTo { get; set; }

        public string ServiceUrgency { get; set; }
        public string ServiceResult { get; set; }
        public string ServicePathological { get; set; }

        public string Barcode { get; set; }
        public string ServiceType  { get; set; }
        public string LabStatus { get; set; }
        public string ParamNo { get; set; }
        public string ParamName { get; set; }
        public ServiceStatusInfo()
        {
            ServiceName = string.Empty;
            ServiceDesc = string.Empty;
            ServiceStatus = string.Empty;
            ServiceOrderBy = string.Empty;
            ServiceReturnTo = string.Empty;
            ServiceResult = string.Empty;
            ServicePathological = string.Empty;
            ServiceDate = DateTime.MaxValue;
            ServiceType = string.Empty;
            LabStatus = string.Empty;
            ParamNo = string.Empty;
            ParamName = string.Empty;
        }
    }
}
