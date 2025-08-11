using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;


namespace eMASLib
{
    /// <summary>
    /// Summary description for eMASProgressbar.
    /// </summary>
// te3st
    public class guieMASProgressbar : DevExpress.XtraEditors.XtraForm
    {
        private string _eMASText;
        private IContainer components;
        public System.Windows.Forms.Timer eMASTimer;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private ProgressBarControl eMASProgressBarControl;


        public guieMASProgressbar() : this("")
        {
           
        }
        public guieMASProgressbar(string strInitString)
        {
          
            InitializeComponent();
            _eMASText = strInitString;
            this.Text = _eMASText;
        }

        public string eMASText
        {
            set
            {
                _eMASText = value;
            }
            get
            {
                return _eMASText;
            }
        }

        public void eMASTimerStart()
        {
            this.eMASTimer.Start();
            this.eMASTimer.Interval =70;
            
            this.eMASProgressBarControl.Properties.Maximum = 100;
            this.eMASProgressBarControl.Properties.Minimum = 0;
            this.eMASProgressBarControl.Position = this.eMASProgressBarControl.Properties.Minimum;
         
        }

          
        private void eMASTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!eMASProgressBar.eMASText.Equals(_eMASText))
                {
                    _eMASText = eMASProgressBar.eMASText;
                    this.Text = _eMASText;
                }
            }
            catch (System.Exception )
            {
                return;
            }           

           this.eMASProgressBarControl.Position++;            

            if (this.eMASProgressBarControl.Position >
                     this.eMASProgressBarControl.Properties.Maximum - 2)
            {
                this.eMASProgressBarControl.Position =
                    this.eMASProgressBarControl.Properties.Minimum;
            }

            if (this.eMASTimer.Interval <= 2 )
            {
                this.eMASTimer.Interval = 100;
                return;
            }

            if (this.eMASTimer.Interval < 60 & this.eMASTimer.Interval > 30)
            {
                this.eMASTimer.Interval = 30;
                return;
            }
            if (this.eMASTimer.Interval >= 2 & this.eMASTimer.Interval <=30)
            {               
                this.eMASProgressBarControl.Position += 2;                
            }

            this.eMASTimer.Interval -= (this.eMASTimer.Interval / 4);

        }
         
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guieMASProgressbar));
            this.eMASTimer = new System.Windows.Forms.Timer(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.eMASProgressBarControl = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.eMASProgressBarControl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // eMASTimer
            // 
            this.eMASTimer.Enabled = true;
            this.eMASTimer.Interval = 100000;
            this.eMASTimer.Tick += new System.EventHandler(this.eMASTimer_Tick);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "iMaginary";
            // 
            // eMASProgressBarControl
            // 
            this.eMASProgressBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eMASProgressBarControl.Location = new System.Drawing.Point(0, 0);
            this.eMASProgressBarControl.Name = "eMASProgressBarControl";
            this.eMASProgressBarControl.Properties.LookAndFeel.SkinName = "iMaginary";
            this.eMASProgressBarControl.Size = new System.Drawing.Size(221, 21);
            this.eMASProgressBarControl.TabIndex = 4;
            // 
            // guieMASProgressbar
            // 
            this.ClientSize = new System.Drawing.Size(221, 21);
            this.ControlBox = false;
            this.Controls.Add(this.eMASProgressBarControl);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "iMaginary";
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "guieMASProgressbar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Waiting .....";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.guieMASProgressbar_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.eMASProgressBarControl.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

       

        private void guieMASProgressbar_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

         
    }
}

