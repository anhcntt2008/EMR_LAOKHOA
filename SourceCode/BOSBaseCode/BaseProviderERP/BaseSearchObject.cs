using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace BOSERP
{
    [Serializable()]
    public class BaseSearchObject
    {
        public static readonly String DefaultString = String.Empty;
        public static readonly int DefaultTopResults = 1000;
        public static readonly DateTime DefaultDate = DateTimePicker.MinimumDateTime;
        protected int _topResults = DefaultTopResults;
        
        public BaseSearchObject()
        {
        }
        public int TopResults
        {
            get
            {
                return _topResults;
            }

            set
            {
                _topResults = value;
            }
        }        
    }
}
