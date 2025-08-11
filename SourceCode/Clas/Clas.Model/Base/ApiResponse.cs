using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Clas.Model.Base
{
    public class ApiResponse
    {
        [JsonProperty(PropertyName = "successful")]
        public bool IsSuccessful { get; set; }

        [JsonProperty(PropertyName = "errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty(PropertyName = "errorDesc")]
        public string ErrorDescription { get; set; }

        [JsonProperty(PropertyName = "data")]
        public JObject Data { get; set; }
    }
}
