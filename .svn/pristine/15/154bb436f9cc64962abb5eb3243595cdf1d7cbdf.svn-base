using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace BOSLib
{
    public class ScreenCollection : DictionaryBase
    {
        public BOSScreen this[String key]
        {
            get
            {
                return (BOSScreen)Dictionary[key];
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

        public void Add(String key, BOSScreen scr)
        {
            Dictionary.Add(key, scr);
        }

        public void Remove(String key)
        {
            Dictionary.Remove(key);
        }
    }
}
