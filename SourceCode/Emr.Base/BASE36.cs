using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Base
{
    public class BASE36
    {
        private const string _charList = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly char[] _charArray = _charList.ToCharArray();
        public static string Encode(ulong input)
        {
            StringBuilder _sb = new StringBuilder();
            do
            {
                _sb.Append(_charArray[input % (ulong)_charList.Length]);
                input /= (ulong)_charList.Length;
            } while (input != 0);

            return Reverse(_sb.ToString());
        }
        private static string Reverse(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
