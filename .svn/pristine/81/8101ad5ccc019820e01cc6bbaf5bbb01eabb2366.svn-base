using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    public class BOSTreeListObject : BusinessObject
    {
        #region Variables
        protected BOSTreeListObject _parent;
        protected IBOSTreeList _subList;
        #endregion

        #region Public properties
        public BOSTreeListObject Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        public IBOSTreeList SubList
        {
            get
            {
                return _subList;
            }
            set
            {
                _subList = value;
            }
        }        
        #endregion

        public bool HasChildren()
        {
            if (SubList != null && SubList.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool HasSelectedChildren()
        {
            foreach (BOSTreeListObject obj in this.SubList)
            {
                if (obj.HasChildren() == false && obj.Selected)
                    return true;
                else
                {
                    bool result = obj.HasSelectedChildren();
                    if (result)
                        return true;
                }
            }
            return false;
        }
    }
}
