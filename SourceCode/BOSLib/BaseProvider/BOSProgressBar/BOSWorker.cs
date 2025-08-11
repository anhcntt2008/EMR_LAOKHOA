using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eMASLib
{
    public partial class eMASWorker : Form
    {
        private static DateTime Begin = DateTime.Now;
        private TimeSpan span = TimeSpan.Zero;

        public string WorkerTime
        {
            get
            {
                return this.eMASWorkerLabelTime.Text;
            }
            set
            {
                this.eMASWorkerLabelTime.Text = value;
            }
        }
        public string WorkerText
        {
            get
            {
                return this.eMASWorkerLabelText.Text;
            }
            set
            {
                this.eMASWorkerLabelText.Text = value;
            }
        }
  
        public eMASWorker()
        {
            InitializeComponent();
            // nur in aufrufenden Modulen1
            //eMASBackgroundWorker.DoWork +=
            //    new DoWorkEventHandler(backgroundWorker1_DoWork);

            this.eMASProgressBar.Properties.Minimum = 0;
            this.eMASProgressBar.Properties.Maximum = 100;

            eMASBackgroundWorker.WorkerReportsProgress = true;
            eMASBackgroundWorker.WorkerSupportsCancellation = true;

            eMASBackgroundWorker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(eMASBackgroundWorker_RunWorkerCompleted);
            eMASBackgroundWorker.ProgressChanged +=
                new ProgressChangedEventHandler(eMASBackgroundWorker_ProgressChanged);
            eMASWorker.Begin = DateTime.Now;
        }

        public void Start()
        {
            this.Start(null); 
        }

        public void Start(object workerArg)
        {
            this.WorkerText = "I am working ...";
            eMASBackgroundWorker.RunWorkerAsync(workerArg);
            this.Show();
        }

        private void eMASBackgroundWorker_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            if (this.eMASProgressBar.Position > this.eMASProgressBar.Properties.Maximum-1)
            {
                this.eMASProgressBar.Position = this.eMASProgressBar.Properties.Minimum;
            }
            this.eMASProgressBar.Position += e.ProgressPercentage;
            this.WorkerText = e.UserState.ToString();
            span = DateTime.Now - Begin;
            this.WorkerTime = string.Format("I am working ... {0,4:N} sec", span.TotalSeconds); 
        }


        private void eMASBackgroundWorker_RunWorkerCompleted(
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

        private void eMASWorkerStopButton_Click(object sender, EventArgs e)
        {
            eMASBackgroundWorker.CancelAsync();
        }

    }
}