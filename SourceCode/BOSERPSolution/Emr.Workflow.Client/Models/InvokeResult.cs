using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Workflow.Client.Models
{
    public class InvokeResult : Dictionary<string, object>
    {
        public string Message => GetStrValue("_Message");
        public string ErrorCode => GetStrValue("_ErrorCode");
        public bool IsPersistent => GetBoolValue("_IsPersistent");
        private string GetStrValue(string key)
        {
            if (this.TryGetValue(key, out object value))
                return value?.ToString();
            return null;
        }
        private bool GetBoolValue(string key)
        {
            if (this.TryGetValue(key, out object value))
                return (bool)value;
            return true;
        }
    }
}
