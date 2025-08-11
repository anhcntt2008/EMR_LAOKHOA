using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BOSLib
{
    public partial class BOSWorker : Form
    {
        private static DateTime Begin = DateTime.Now;
        private TimeSpan span = TimeSpan.Zero;

        public string WorkerTime
        {
            get
            {
                return this.BOSWorkerLabelTime.Text;
            }
            set
            {
                this.BOSWorkerLabelTime.Text = value;
            }
        }
        public string WorkerText
        {
            get
            {
                return this.BOSWorkerLabelText.Text;
            }
            set
            {
                this.BOSWorkerLabelText.Text = value;
            }
        }
  
        public BOSWorker()
        {
            InitializeComponent();
            // nur in aufrufenden Modulen1
            //BOSBackgroundWorker.DoWork +=
            //    new DoWorkEventHandler(backgroundWorker1_DoWork);

            this.BOSProgressBar.Properties.Minimum = 0;
            this.BOSProgressBar.Properties.Maximum = 100;

            BOSBackgroundWorker.WorkerReportsProgress = true;
            BOSBackgroundWorker.WorkerSupportsCancellation = true;

            BOSBackgroundWorker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(BOSBackgroundWorker_RunWorkerCompleted);
            BOSBackgroundWorker.ProgressChanged +=
                new ProgressChangedEventHandler(BOSBackgroundWorker_ProgressChanged);
            BOSWorker.Begin = DateTime.Now;
        }

        public void Start()
        {
            this.Start(null); 
        }

        public void Start(object workerArg)
        {
            this.WorkerText = "I am working ...";
            BOSBackgroundWorker.RunWorkerAsync(workerArg);
            this.Show();
        }

        private void BOSBackgroundWorker_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            if (this.BOSProgressBar.Position > this.BOSProgressBar.Properties.Maximum-1)
            {
                this.BOSProgressBar.Position = this.BOSProgressBar.Properties.Minimum;
            }
            this.BOSProgressBar.Position += e.ProgressPercentage;
            this.WorkerText = e.UserState.ToString();
            span = DateTime.Now - Begin;
            this.WorkerTime = string.Format("I am working ... {0,4:N} sec", span.TotalSeconds); 
        }


        private void BOSBackgroundWorker_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Cancelled !!") ;
            }
            else
            {
                MessageBox.Show("Finished !!");
            }


        }

        private void BOSWorkerStopButton_Click(object sender, EventArgs e)
        {
            BOSBackgroundWorker.CancelAsync();
        }

    }
}