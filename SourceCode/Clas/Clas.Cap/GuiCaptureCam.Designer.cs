namespace Clas.Cap
{
    partial class guiCaptureCam
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
            this.devicesCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.takePictureBtn = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gdcImages = new DevExpress.XtraGrid.GridControl();
            this.grvImages = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gdcImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvImages)).BeginInit();
            this.SuspendLayout();
            // 
            // devicesCombo
            // 
            this.devicesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devicesCombo.FormattingEnabled = true;
            this.devicesCombo.Location = new System.Drawing.Point(12, 31);
            this.devicesCombo.Name = "devicesCombo";
            this.devicesCombo.Size = new System.Drawing.Size(553, 21);
            this.devicesCombo.TabIndex = 0;
            this.devicesCombo.SelectedIndexChanged += new System.EventHandler(this.devicesCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn Camera";
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.Location = new System.Drawing.Point(12, 59);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(553, 392);
            this.videoSourcePlayer.TabIndex = 2;
            this.videoSourcePlayer.Text = "videoSourcePlayer1";
            this.videoSourcePlayer.VideoSource = null;
            // 
            // takePictureBtn
            // 
            this.takePictureBtn.Location = new System.Drawing.Point(224, 457);
            this.takePictureBtn.Name = "takePictureBtn";
            this.takePictureBtn.Size = new System.Drawing.Size(123, 34);
            this.takePictureBtn.TabIndex = 4;
            this.takePictureBtn.Text = "Chụp";
            this.takePictureBtn.UseVisualStyleBackColor = true;
            this.takePictureBtn.Click += new System.EventHandler(this.takePictureBtn_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(850, 457);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 34);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(928, 457);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 34);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gdcImages
            // 
            this.gdcImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdcImages.Location = new System.Drawing.Point(571, 31);
            this.gdcImages.MainView = this.grvImages;
            this.gdcImages.Name = "gdcImages";
            this.gdcImages.Size = new System.Drawing.Size(428, 420);
            this.gdcImages.TabIndex = 7;
            this.gdcImages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvImages});
            // 
            // grvImages
            // 
            this.grvImages.GridControl = this.gdcImages;
            this.grvImages.Name = "grvImages";
            // 
            // guiCaptureCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 496);
            this.Controls.Add(this.gdcImages);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.takePictureBtn);
            this.Controls.Add(this.videoSourcePlayer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.devicesCombo);
            this.Name = "guiCaptureCam";
            this.Text = "Chụp hình";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gdcImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvImages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox devicesCombo;
        private System.Windows.Forms.Label label1;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.Button takePictureBtn;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraGrid.GridControl gdcImages;
        private DevExpress.XtraGrid.Views.Grid.GridView grvImages;
    }
}

