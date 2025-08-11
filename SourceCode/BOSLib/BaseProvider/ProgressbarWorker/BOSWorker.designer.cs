namespace BOSLib
{
    partial class BOSWorker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BOSWorker));
            this.BOSWorkerStopButton = new DevExpress.XtraEditors.SimpleButton();
            this.BOSProgressBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.BOSWorkerLabelTime = new System.Windows.Forms.Label();
            this.BOSBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.BOSWorkerLabelText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BOSProgressBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BOSWorkerStopButton
            // 
            this.BOSWorkerStopButton.Location = new System.Drawing.Point(189, 36);
            this.BOSWorkerStopButton.Name = "BOSWorkerStopButton";
            this.BOSWorkerStopButton.Size = new System.Drawing.Size(48, 23);
            this.BOSWorkerStopButton.TabIndex = 0;
            this.BOSWorkerStopButton.Text = "Stop";
            this.BOSWorkerStopButton.Click += new System.EventHandler(this.BOSWorkerStopButton_Click);
            // 
            // BOSProgressBar
            // 
            this.BOSProgressBar.Location = new System.Drawing.Point(12, 10);
            this.BOSProgressBar.Name = "BOSProgressBar";
            this.BOSProgressBar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BOSProgressBar.Properties.Appearance.Options.UseFont = true;
            this.BOSProgressBar.Size = new System.Drawing.Size(225, 20);
            this.BOSProgressBar.TabIndex = 1;
            // 
            // BOSWorkerLabelTime
            // 
            this.BOSWorkerLabelTime.AutoSize = true;
            this.BOSWorkerLabelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BOSWorkerLabelTime.Location = new System.Drawing.Point(12, 40);
            this.BOSWorkerLabelTime.Name = "BOSWorkerLabelTime";
            this.BOSWorkerLabelTime.Size = new System.Drawing.Size(39, 16);
            this.BOSWorkerLabelTime.TabIndex = 2;
            this.BOSWorkerLabelTime.Text = "-         ";
            // 
            // BOSWorkerLabelText
            // 
            this.BOSWorkerLabelText.AutoSize = true;
            this.BOSWorkerLabelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BOSWorkerLabelText.Location = new System.Drawing.Point(12, 68);
            this.BOSWorkerLabelText.Name = "BOSWorkerLabelText";
            this.BOSWorkerLabelText.Size = new System.Drawing.Size(39, 16);
            this.BOSWorkerLabelText.TabIndex = 2;
            this.BOSWorkerLabelText.Text = "-         ";
            // 
            // BOSWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 89);
            this.Controls.Add(this.BOSWorkerLabelText);
            this.Controls.Add(this.BOSWorkerLabelTime);
            this.Controls.Add(this.BOSProgressBar);
            this.Controls.Add(this.BOSWorkerStopButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BOSWorker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress...";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.BOSProgressBar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BOSWorkerStopButton;
        public DevExpress.XtraEditors.ProgressBarControl BOSProgressBar;
        private System.Windows.Forms.Label BOSWorkerLabelTime;
        public System.ComponentModel.BackgroundWorker BOSBackgroundWorker;
        private System.Windows.Forms.Label BOSWorkerLabelText;
       
    }
}