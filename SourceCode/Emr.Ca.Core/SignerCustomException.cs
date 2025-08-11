using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Ca.Core
{
    public class SignerCustomException : Exception
    {
        public int Code { get; set; }

        public SignerCustomException(int code, string message) : base(message)
        {
            this.Code = code;
        }
    }
}
