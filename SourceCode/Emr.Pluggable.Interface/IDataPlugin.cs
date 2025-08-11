using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Emr.Pluggable.Interface
{
    public interface IDataPlugin : IPluginBase
    {
        JToken GetJToken(string actionNo, string group, Dictionary<string, object> requestParams);
    }
}
