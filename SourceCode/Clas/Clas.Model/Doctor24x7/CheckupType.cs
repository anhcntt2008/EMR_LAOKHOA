using System.Collections.Generic;
using Clas.Model.Base;

namespace Clas.Model.Doctor24x7
{
    public class CheckupType
    {
        public string id { get; set; }
        public NameMap nameMap { get; set; }
        public string name { get; set; }
        public object hospitalId { get; set; }
        public bool status { get; set; }
    }

    public class NameMap
    {
        public string vi { get; set; }
        public string viAscii { get; set; }
        public string en { get; set; }
    }

    public class CheckupTypeData
    {
        public int total { get; set; }
        public List<CheckupType> checkupTypes { get; set; }
    }

    public class CheckupTypeHttpResult : HttpResult
    {
        public CheckupTypeData data { get; set; }
    }
}