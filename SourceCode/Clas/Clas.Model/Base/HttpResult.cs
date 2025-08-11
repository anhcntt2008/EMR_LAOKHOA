using System;
using System.Collections.Generic;
using System.Text;

namespace Clas.Model.Base
{
    public class HttpResult
    {
        public bool successful { get; set; }
        public int errorCode { get; set; }
        public string errorDesc { get; set; }
    }
}
