using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace BOSLib
{
    public class ControlCollection : DictionaryBase
    {
        public Control this[String key]
        {
            get
            {
                return (Control)Dictionary[key];
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

        public void Add(String key, Control ctrl)
        {
            Dictionary.Add(key, ctrl);            
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
