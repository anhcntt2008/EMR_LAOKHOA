using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace BOSERP
{
    public class BaseSearchObjectFactory
    {
        public static BaseSearchObject GetSearchObject(String strModuleName)
        {
            try
            {                
                Type searchObjectType = BOSApp.BOSERPAssembly.GetType("BOSERP.Modules." + strModuleName + "." + strModuleName + "SearchObject");
                return (BaseSearchObject)searchObjectType.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
                
            }
            catch (Exception e)
            {
                MessageBox.Show("BaseSearchObjectFactory.GetSearchObject:" + e.Message);
                return null;
            }
        }
    }
}
