using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using Localization;

namespace BOSERP
{
    public class BaseModuleFactory
    {
        public static BaseModuleERP GetModule(String strModuleName)
        {
            try
            {
                Type moduleType = Assembly.LoadFrom(Application.StartupPath + "\\EMR.exe").GetType("BOSERP.Modules." + strModuleName + "." + strModuleName + "Module");
                return (BaseModuleERP)moduleType.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("There is an error while processing your request. Please contact BOS for the support.", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show(ex.ToString(), CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
