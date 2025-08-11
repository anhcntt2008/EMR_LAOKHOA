    using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
namespace BOSLib
{
    public class ErrorProviderCollection:DictionaryBase
    {
        public ErrorProvider this[String key]
        {
            get
            {
                return (ErrorProvider)Dictionary[key];
            }
            set
            {
                Dictionary[key] = value;
            }
        }
     
        public ICollection Keys
        {
            get
            {
                return (Dictionary.Keys);
            }
        }

        public ICollection Values
        {
            get
            {
                return (Dictionary.Values);
            }
        }

        public void Add(String key, ErrorProvider epd)
        {
            Dictionary.Add(key, epd);
        }

        public void Remove(String key)
        {
            Dictionary.Remove(key);
        }
    }
}
