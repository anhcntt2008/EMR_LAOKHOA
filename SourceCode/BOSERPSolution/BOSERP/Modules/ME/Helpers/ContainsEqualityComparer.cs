using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BOSERP.Modules.ME.Helpers
{
    public class ContainsEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (x.Equals(y)) return true;
            y += Emr.EmrConsts.DATA_FROM_CONTENT_SEPARATOR;
            var xArr = x.Split(new[] { Emr.EmrConsts.DATA_FROM_CONTENT_SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);
            var yArr = y.Split(new[] { Emr.EmrConsts.DATA_FROM_CONTENT_SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);
            // 1 diff item is new group.
            var result = yArr.Except(xArr);
            if (result.Count() > 0) return false;

            return true;
        }
        // TODO bad performance but it works
        public int GetHashCode(string obj)
        {
            return 0;// obj.GetHashCode();
        }
    }
}
