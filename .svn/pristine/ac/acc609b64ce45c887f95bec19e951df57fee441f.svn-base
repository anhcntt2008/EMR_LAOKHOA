using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BOSLib
{
    public class BOSUndoUnit
    {
        public const String Changed = "Changed";
        public const String Deleted = "Deleted";
        public const String Added = "Added";
        //private String _controlName;
        //private String _controlPropertyName;
        //public object _controlPropertyValue;

        public object _undoUnitObject;
        private String _undoUnitName;
        private String _undoUnitPropertyName;
        private String _undoUnitStatus;

        //public BOSUndoUnit(String strControlName, String strControlPropertyName, object objControlPropertyValue)
        //{
        //    _controlName = strControlName;
        //    _controlPropertyName = strControlPropertyName;
        //    _controlPropertyValue = objControlPropertyValue;
        //}

        public BOSUndoUnit(String strUndoUnitName,String strUndoUnitPropertyName, String strUndoUnitStatus, object objUndoUnitObject)
        {
            _undoUnitName = strUndoUnitName;
            _undoUnitPropertyName = strUndoUnitPropertyName;
            _undoUnitStatus = strUndoUnitStatus;
            _undoUnitObject = objUndoUnitObject;
        }

        public String UndoUnitName
        {
            get { return _undoUnitName; }
            set
            {
                _undoUnitName = value;
            }
        }

        public String UndoUnitPropertyName
        {
            get
            {
                return _undoUnitPropertyName;
            }
            set
            {
                _undoUnitPropertyName = value;
            }
        }

        public String UndoUnitStatus
        {
            get
            {
                return _undoUnitStatus;
            }
            set
            {
                _undoUnitStatus = value;
            }
        }

        public object UndoUnitObject
        {
            get { return _undoUnitObject; }
            set
            {
                _undoUnitObject = value;
            }
        }       
    }

    
}
