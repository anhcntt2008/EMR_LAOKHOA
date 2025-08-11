using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace BOSERP
{
    public class BaseModuleFactory
    {
        public static BaseModuleERP GetModule(String strModuleName)
        {
            try
            {
                Type moduleType = Assembly.LoadFrom(Application.StartupPath + "\\BOSERP.exe").GetType("BOSERP.Modules." + strModuleName + "." + strModuleName + "Module");
                return (BaseModuleERP)moduleType.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("There is an error while processing your request. Please contact BOS for the support.", "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show(ex.ToString(), "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
