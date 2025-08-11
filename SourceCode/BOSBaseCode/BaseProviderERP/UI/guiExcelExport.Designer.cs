namespace BOSERP
{
    partial class guiExcelExport
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiExcelExport));
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.fld_txtFile = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_chkOpenFile = new DevExpress.XtraEditors.CheckEdit();
            this.fld_dgcData = new DevExpress.XtraGrid.GridControl();
            this.fld_dgvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_prgProgressBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.fld_btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.bosLine1 = new BOSComponent.BOSLine(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkOpenFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_prgProgressBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(328, 193);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(84, 27);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.bntExport_Click);
            // 
            // fld_txtFile
            // 
            this.fld_txtFile.Location = new System.Drawing.Point(12, 34);
            this.fld_txtFile.Name = "fld_txtFile";
            this.fld_txtFile.Properties.ReadOnly = true;
            this.fld_txtFile.Size = new System.Drawing.Size(400, 20);
            this.fld_txtFile.TabIndex = 12;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(428, 31);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Save as";
            // 
            // fld_chkOpenFile
            // 
            this.fld_chkOpenFile.Location = new System.Drawing.Point(10, 146);
            this.fld_chkOpenFile.MenuManager = this.screenToolbar;
            this.fld_chkOpenFile.Name = "fld_chkOpenFile";
            this.fld_chkOpenFile.Properties.Caption = "Open file after completing";
            this.fld_chkOpenFile.Size = new System.Drawing.Size(160, 19);
            this.fld_chkOpenFile.TabIndex = 15;
            // 
            // fld_dgcData
            // 
            this.fld_dgcData.Location = new System.Drawing.Point(12, 184);
            this.fld_dgcData.MainView = this.fld_dgvData;
            this.fld_dgcData.MenuManager = this.screenToolbar;
            this.fld_dgcData.Name = "fld_dgcData";
            this.fld_dgcData.Size = new System.Drawing.Size(179, 51);
            this.fld_dgcData.TabIndex = 16;
            this.fld_dgcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvData});
            this.fld_dgcData.Visible = false;
            // 
            // fld_dgvData
            // 
            this.fld_dgvData.GridControl = this.fld_dgcData;
            this.fld_dgvData.Name = "fld_dgvData";
            // 
            // fld_prgProgressBar
            // 
            this.fld_prgProgressBar.Location = new System.Drawing.Point(12, 101);
            this.fld_prgProgressBar.Name = "fld_prgProgressBar";
            this.fld_prgProgressBar.Size = new System.Drawing.Size(400, 20);
            this.fld_prgProgressBar.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 82);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Progress";
            // 
            // fld_btnCancel
            // 
            this.fld_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fld_btnCancel.Location = new System.Drawing.Point(427, 193);
            this.fld_btnCancel.Name = "fld_btnCancel";
            this.fld_btnCancel.Size = new System.Drawing.Size(84, 27);
            this.fld_btnCancel.TabIndex = 4;
            this.fld_btnCancel.Text = "Cancel";
            this.fld_btnCancel.Click += new System.EventHandler(this.fld_btnCancel_Click);
            // 
            // bosLine1
            // 
            this.bosLine1.BOSComment = null;
            this.bosLine1.BOSDataMember = null;
            this.bosLine1.BOSDataSource = null;
            this.bosLine1.BOSDescription = null;
            this.bosLine1.BOSError = null;
            this.bosLine1.BOSFieldGroup = null;
            this.bosLine1.BOSFieldRelation = null;
            this.bosLine1.BOSPrivilege = null;
            this.bosLine1.BOSPropertyName = null;
            this.bosLine1.Location = new System.Drawing.Point(3, 177);
            this.bosLine1.Name = "bosLine1";
            this.bosLine1.Screen = null;
            this.bosLine1.Size = new System.Drawing.Size(508, 10);
            this.bosLine1.TabIndex = 17;
            this.bosLine1.TabStop = false;
            // 
            // guiExcelExport
            // 
            this.AcceptButton = this.btnExport;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.fld_btnCancel;
            this.ClientSize = new System.Drawing.Size(514, 226);
            this.ControlBox = true;
            this.Controls.Add(this.bosLine1);
            this.Controls.Add(this.fld_dgcData);
            this.Controls.Add(this.fld_chkOpenFile);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.fld_txtFile);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.fld_btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.fld_prgProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "guiExcelExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export";
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkOpenFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_prgProgressBar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.TextEdit fld_txtFile;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit fld_chkOpenFile;
        private DevExpress.XtraGrid.GridControl fld_dgcData;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvData;
        private DevExpress.XtraEditors.ProgressBarControl fld_prgProgressBar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton fld_btnCancel;
        private BOSComponent.BOSLine bosLine1;
    }
}