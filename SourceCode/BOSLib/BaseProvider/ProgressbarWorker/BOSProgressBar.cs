using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;

namespace BOSLib
{
    public enum ProgressStatus { InProgress = 1, Complete = 2 };

    public class ProgressEventArgs : EventArgs
    {
        private ProgressStatus _status;

        public ProgressStatus Status
        {
            get
            {
                return _status;
            }
        }

        public ProgressEventArgs(ProgressStatus status)
        {
            _status = status;
        }
    }

    public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);

    public static class BOSProgressBar
    {
        public static string BOSText = "";

        public static bool _isBusy = false;
        public static object BOSProgressBarLock = new object();

        public static void Start(string startString)
        {
            if (_isBusy) return;

            Cursor.Current = Cursors.WaitCursor;
            BOSText = startString + "...";
            var gui = GetProgressBar();
            if (gui != null)
            {
                gui.Show(startString + "...");
            }
            else
            {
                _isBusy = true;
                var thread = new Thread(new ThreadStart(BOSProgressBar.ShowForm));
                //thread.IsBackground = true;
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            //Application.DoEvents();
        }
        static private void ShowForm()
        {
            var gui = new guiProgressBar(BOSText);
            if (_isBusy)
                Application.Run(gui);
            _isBusy = false;
        }
        public static void SetText(string strText)
        {
            var gui = GetProgressBar();
            if (gui != null)
            {
                gui.Show(strText + "...");
            }
        }
        public static guiProgressBar GetProgressBar()
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Form f = Application.OpenForms[i];
                if (f.Name == "guiProgressBar")
                {
                    return f as guiProgressBar;
                }
            }
            return null;
        }
        public static bool IsShowing()
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Form f = Application.OpenForms[i];
                if (f.Name == "guiProgressBar")
                {
                    return true;
                }
            }
            return false;
        }
        delegate void CloseMethod(Form form);
        static private void CloseForm(Form form)
        {
            if (!form.IsDisposed)
            {
                if (form.InvokeRequired)
                {
                    CloseMethod method = new CloseMethod(CloseForm);
                    form.Invoke(method, new object[] { form });
                }
                else
                {
                    form.Close();
                }
            }
        }

        public static void Close()
        {
            Cursor.Current = Cursors.Default;
            var gui = GetProgressBar();
            if (gui != null)
            {
                lock (BOSProgressBarLock)
                {
                    CloseForm(gui);
                }
            }
            else
            {
                System.Threading.Timer waitTimer = null;
                waitTimer = new System.Threading.Timer((obj) =>
                {
                    gui = GetProgressBar();
                    if (gui != null)
                    {
                        lock (BOSProgressBarLock)
                        {
                            CloseForm(gui);
                        }
                    }
                    waitTimer.Dispose();
                }, null, 500, System.Threading.Timeout.Infinite);
            }
            _isBusy = false;
        }
    }
}
