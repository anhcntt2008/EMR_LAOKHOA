
namespace Emr.FingerPrint
{
    partial class CaptureZKTeco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureZKTeco));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtAltSign = new DevExpress.XtraEditors.TextEdit();
            this.chkAltSign = new DevExpress.XtraEditors.CheckEdit();
            this.fld_dgcSignerName = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSignerName = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.lblPlaceFinger = new System.Windows.Forms.Label();
            this.pbFingerprint = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAltSign.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAltSign.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcSignerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSignerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtAltSign);
            this.groupControl1.Controls.Add(this.chkAltSign);
            this.groupControl1.Controls.Add(this.fld_dgcSignerName);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtSignerName);
            this.groupControl1.Location = new System.Drawing.Point(283, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(412, 360);
            this.groupControl1.TabIndex = 18;
            this.groupControl1.Text = "Bệnh án liên kết";
            // 
            // txtAltSign
            // 
            this.txtAltSign.Location = new System.Drawing.Point(5, 335);
            this.txtAltSign.Name = "txtAltSign";
            this.txtAltSign.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtAltSign.Properties.Appearance.Options.UseFont = true;
            this.txtAltSign.Properties.ReadOnly = true;
            this.txtAltSign.Size = new System.Drawing.Size(88, 20);
            this.txtAltSign.TabIndex = 14;
            // 
            // chkAltSign
            // 
            this.chkAltSign.Location = new System.Drawing.Point(4, 313);
            this.chkAltSign.Name = "chkAltSign";
            this.chkAltSign.Properties.Caption = "Ký thay";
            this.chkAltSign.Size = new System.Drawing.Size(75, 19);
            this.chkAltSign.TabIndex = 13;
            this.chkAltSign.CheckedChanged += new System.EventHandler(this.chkAltSign_CheckedChanged);
            // 
            // fld_dgcSignerName
            // 
            this.fld_dgcSignerName.Location = new System.Drawing.Point(5, 23);
            this.fld_dgcSignerName.MainView = this.gridView2;
            this.fld_dgcSignerName.Name = "fld_dgcSignerName";
            this.fld_dgcSignerName.Size = new System.Drawing.Size(402, 287);
            this.fld_dgcSignerName.TabIndex = 8;
            this.fld_dgcSignerName.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.fld_dgcSignerName;
            this.gridView2.Name = "gridView2";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(99, 316);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Họ tên người ký";
            // 
            // txtSignerName
            // 
            this.txtSignerName.Location = new System.Drawing.Point(99, 335);
            this.txtSignerName.Name = "txtSignerName";
            this.txtSignerName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtSignerName.Properties.Appearance.Options.UseFont = true;
            this.txtSignerName.Size = new System.Drawing.Size(308, 20);
            this.txtSignerName.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(532, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "HỦY";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(603, 370);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "XÁC NHẬN";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblPlaceFinger
            // 
            this.lblPlaceFinger.ForeColor = System.Drawing.Color.Gray;
            this.lblPlaceFinger.Location = new System.Drawing.Point(-1, 374);
            this.lblPlaceFinger.Name = "lblPlaceFinger";
            this.lblPlaceFinger.Size = new System.Drawing.Size(374, 19);
            this.lblPlaceFinger.TabIndex = 14;
            this.lblPlaceFinger.Text = "Đặt ngón tay lên đầu đọc, Họ tên người ký có thể chọn hoặc nhập thủ công";
            // 
            // pbFingerprint
            // 
            this.pbFingerprint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFingerprint.Image = ((System.Drawing.Image)(resources.GetObject("pbFingerprint.Image")));
            this.pbFingerprint.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbFingerprint.InitialImage")));
            this.pbFingerprint.Location = new System.Drawing.Point(2, 1);
            this.pbFingerprint.Name = "pbFingerprint";
            this.pbFingerprint.Size = new System.Drawing.Size(275, 360);
            this.pbFingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFingerprint.TabIndex = 15;
            this.pbFingerprint.TabStop = false;
            // 
            // CaptureZKTeco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 397);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblPlaceFinger);
            this.Controls.Add(this.pbFingerprint);
            this.Name = "CaptureZKTeco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quét vân tay";
            this.Closed += new System.EventHandler(this.btnClosed_Click);
            this.Load += new System.EventHandler(this.CaptureZKTeco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAltSign.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAltSign.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcSignerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSignerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtAltSign;
        private DevExpress.XtraEditors.CheckEdit chkAltSign;
        private DevExpress.XtraGrid.GridControl fld_dgcSignerName;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSignerName;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        internal System.Windows.Forms.Label lblPlaceFinger;
        internal System.Windows.Forms.PictureBox pbFingerprint;
    }
}