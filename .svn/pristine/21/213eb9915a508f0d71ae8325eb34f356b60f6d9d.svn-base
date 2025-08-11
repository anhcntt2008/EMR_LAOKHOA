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
                Type screenType = BOSApp.BOSERPAssembly.GetType(String.Format("BOSERP.Modules.{0}.UI.{1}", strModuleName, strScreenNumber));                
                return (BOSERPScreen)screenType.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
            }
            catch (Exception)
            {
                return new BOSERPScreen();
            }

        }
    }
}
