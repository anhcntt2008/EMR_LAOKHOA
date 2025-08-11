using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clas.Emr.Model
{
    public class ServiceCreatePatientExtRequest : ServiceBaseWebRequest
    {
        public object Patient { get; set; }
    }
    public class ServiceCreatePatientExtResponse : ServiceBaseWebResponse
    {
        public Guid PatientIdCreated { get; set; }
        public Guid? ExistingPatientId { get; set; }
    }
    public class ServiceBaseWebRequest
    {
        public string TenantKey { get; set; }
        public string UserNamePatientPortal { get; set; }
        public string PasswordEncStr { get; set; }
    }
    public class ServiceBaseWebResponse
    {
        public bool Success { get; set; }
        public string ErrorCode { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
