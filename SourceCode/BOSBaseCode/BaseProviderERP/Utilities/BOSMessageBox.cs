using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using eMASLib;

namespace eMASERP
{
    public class eMASMessageBox
    {        
        public static DialogResult Show(String messageNo, params object[] values)
        {
            eMASMessage mess = new eMASMessage();
            //get Message from database --> strMessage.
            
            return mess.ShowMessage(messageNo, values);
        }
    }
}