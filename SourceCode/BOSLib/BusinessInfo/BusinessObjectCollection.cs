using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;

namespace BOSLib
{
    public class BusinessObjectCollection:DictionaryBase
    {
        public BusinessObject this[String key]
        {
            get
            {
                return (BusinessObject)Dictionary[key];
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

        public void Add(String key, BusinessObject obj)
        {
            Dictionary.Add(key, obj);                        
        }

        public void Remove(String key)
        {
            Dictionary.Remove(key);
        }     
    }
}
