using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace eMASLib
{
    public class eMASProgressBar
    {
        static Thread eMASProgressThread ;
        static public guieMASProgressbar _guieMASProgressBar = null;
        static public string eMASText = "";

        static public void Start(string startString)
        {
            if (eMASProgressThread != null)
                return;
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            eMASText = startString;
            eMASProgressThread = new Thread(new ParameterizedThreadStart(ShoweMASProgress));
            eMASProgressThread.Name = "eMASProgressThread";
            eMASProgressThread.Priority = ThreadPriority.Normal;                        
            eMASProgressThread.Start(startString);
        }

        static public void Start()
        {
            eMASProgressBar.Start("");
        }

        static void ShoweMASProgress(object obj)
        {
            if (_guieMASProgressBar == null)
            {
                _guieMASProgressBar = new guieMASProgressbar(obj.ToString());
                _guieMASProgressBar.eMASTimerStart();
                Application.Run(_guieMASProgressBar);
            }
            else
            {
                _guieMASProgressBar.Activate();
                _guieMASProgressBar.Show();
            }

        }

        public static void SeteMASText(string strText)
        {
            eMASProgressBar.eMASText = strText;
        }

        public static void Close()
        {
            // abort thread => all actions and windows stop
            eMASProgressThread.Abort();
            eMASProgressThread.Join();
            eMASProgressThread = null;
            _guieMASProgressBar = null;

        }

 
     }
}
