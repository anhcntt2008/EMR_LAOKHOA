using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace BOSERP
{
    public class ERPModuleEntitiesFactory
    {
        public static ERPModuleEntities GetModuleEntities(String strModuleName)
        {
            try
            {
                Type moduleEntitiesType = BOSApp.EmrAssembly.GetType("BOSERP.Modules." + strModuleName + "." + strModuleName + "Entities");
                return (ERPModuleEntities)moduleEntitiesType.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
