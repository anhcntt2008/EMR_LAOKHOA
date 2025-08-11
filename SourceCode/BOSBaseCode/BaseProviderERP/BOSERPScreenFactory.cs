using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace BOSERP
{
    public class BOSERPScreenFactory
    {
        public static BOSERPScreen GetScreen(String strScreenNumber, String strModuleName)
        {
            try
            {
                //Assembly a = Assembly.GetExecutingAssembly();
                Type screenType = BOSApp.EmrAssembly.GetType(String.Format("BOSERP.Modules.{0}.UI.{1}", strModuleName, strScreenNumber));                
                return (BOSERPScreen)screenType.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw e;
            }

        }
    }
}
