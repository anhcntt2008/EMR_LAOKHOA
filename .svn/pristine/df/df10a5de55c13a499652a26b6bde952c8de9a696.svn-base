using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data;
namespace BOSLib
{
    public class LookupTableCollection : DictionaryBase
    {
        public DataTable this[String key]
        {
            get
            {
                return (DataTable)Dictionary[key];
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
                return Dictionary.Keys;
            }
        }

        public ICollection Values
        {
            get
            {
                return Dictionary.Values;
            }
        }

        public void Add(String key, DataTable tbl)
        {
            Dictionary.Add(key, tbl);
        }

        public void Remove(String key)
        {
            Dictionary.Remove(key);
        }

        public bool Contains(String key)
        {
            if (this[key] != null)
                return true;
            return false;
        }
    }
}
