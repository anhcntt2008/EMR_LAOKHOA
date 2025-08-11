using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace BOSLib
{
    public class BusinessControllerFactory
    {
        public static BaseBusinessController GetBusinessController(String strBusinessControllerName)
        {
            object controller  = BaseClassFactory.GetClass("BOSERP." + strBusinessControllerName);
            if (controller == null)
                controller = BaseClassFactory.GetClass("BOSLib." + strBusinessControllerName);
            return (BaseBusinessController)controller;            
        }

        public static Type GetBusinessControllerType(String strBusinessControllerName)
        {
            BaseBusinessController objController = GetBusinessController(strBusinessControllerName);
            if (objController != null)
                return objController.GetType();
            return null;
        }        
    }
    
}
