using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Container
{
    public class KeyValList<T1, T2> : List<KeyValuePair<T1, T2>>
    {
        public void Add(T1 key, T2 value)
        {
            Add(new KeyValuePair<T1, T2>(key, value));
        }
        public void AddList(KeyValList<T1, T2> list)
        {
            foreach (var item in list)
            {
                Add(item.Key, item.Value);
            }
        }
    }
}
