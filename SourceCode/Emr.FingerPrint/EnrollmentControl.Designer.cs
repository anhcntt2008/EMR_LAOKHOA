using DPCtlUruNet;

//! @cond
namespace Emr.FingerPrint
{
    partial class EnrollmentControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnrollmentControl));
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbFingerprint = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDeleteAllFingerPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtMessage.Location = new System.Drawing.Point(491, 3);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(276, 173);
            this.txtMessage.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(667, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "ĐẶT LẠI";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(667, 322);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 39);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "LƯU";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbFingerprint
            // 
            this.pbFingerprint.Location = new System.Drawing.Point(491, 181);
            this.pbFingerprint.Name = "pbFingerprint";
            this.pbFingerprint.Size = new System.Drawing.Size(128, 180);
            this.pbFingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFingerprint.TabIndex = 0;
            this.pbFingerprint.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(667, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "ĐÓNG";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDeleteAllFingerPrint
            // 
            this.btnDeleteAllFingerPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAllFingerPrint.Location = new System.Drawing.Point(667, 260);
            this.btnDeleteAllFingerPrint.Name = "btnDeleteAllFingerPrint";
            this.btnDeleteAllFingerPrint.Size = new System.Drawing.Size(100, 26);
            this.btnDeleteAllFingerPrint.TabIndex = 5;
            this.btnDeleteAllFingerPrint.Text = "XÓA CÀI ĐẶT CŨ";
            this.btnDeleteAllFingerPrint.Click += new System.EventHandler(this.btnDeleteAllFingerPrint_Click);
            // 
            // EnrollmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(774, 365);
            this.Controls.Add(this.btnDeleteAllFingerPrint);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbFingerprint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(790, 404);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(790, 404);
            this.Name = "EnrollmentControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký dấu vân tay";
            this.Closed += new System.EventHandler(this.frmEnrollment_Closed);
            this.Load += new System.EventHandler(this.EnrollmentControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbFingerprint;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDeleteAllFingerPrint;
    }
}
//! @endcond