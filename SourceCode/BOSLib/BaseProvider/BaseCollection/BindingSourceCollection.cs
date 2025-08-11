using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace BOSLib
{
    public class BindingSourceCollection:DictionaryBase
    {
        public BindingSource this[String key]
        {
            get
            {
                return (BindingSource)Dictionary[key];
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

        public void Add(String key, BindingSource bds)
        {
            Dictionary.Add(key, bds);
            Dictionary[Dictionary.Count - 1] = Dictionary[key];
        }

        public void Remove(String key)
        {
            Dictionary.Remove(key);
        }       
    }
}
