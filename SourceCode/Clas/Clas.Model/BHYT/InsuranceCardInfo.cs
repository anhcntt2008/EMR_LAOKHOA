using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clas.Model.BHYT
{
    public class InsuranceCardInfo
    {
        public string Address { get; set; }
        public DateTime DoB { get; set; }
        public DateTime FromDate { get; set; }
        public string Gender { get; set; }
        public string HospitalCode { get; set; }
        public int Level { get; set; }
        public string No { get; set; }
        public string PatientName { get; set; }
        public DateTime ToDate { get; set; }
    }
}
