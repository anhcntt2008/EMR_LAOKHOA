using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Emr.Pluggable.Interface
{
    public interface ICalcPlugin : IPluginBase
    {
        JToken Calculate(string actionNo, string group, Dictionary<string, object> requestParams, JToken documentData);
    }
}
