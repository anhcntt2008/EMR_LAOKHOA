using Newtonsoft.Json;

namespace Clas.Business.CHBase
{
    public class ApiResult
    {
        [JsonProperty("successfull")]
        public bool Successfull { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("errorDesc")]
        public string ErrorDesc { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }
}