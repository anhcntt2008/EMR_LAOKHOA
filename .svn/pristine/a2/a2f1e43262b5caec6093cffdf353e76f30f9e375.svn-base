using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BOSLib
{
    public partial class guiProgressBar : Form
    {
        public guiProgressBar()
        {
            InitializeComponent();
        }

        public guiProgressBar(String desc)
        {
            InitializeComponent();
            fld_lblDescription.Text = desc;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          ((Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2) - 100);
        }

        public void Show(String desc)
        {
            if (!this.IsDisposed)
            {
                if (this.InvokeRequired)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        fld_lblDescription.Text = desc;
                        this.Show();
                    }));
                }
                else
                {
                    fld_lblDescription.Text = desc;
                    this.Show();
                }
            }
        }
    }
}