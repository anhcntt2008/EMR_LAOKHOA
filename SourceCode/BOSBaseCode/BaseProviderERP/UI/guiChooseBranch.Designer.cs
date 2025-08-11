namespace BOSERP
{
    partial class guiChooseBranch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiChooseBranch));
            this.fld_chkIsDefault = new BOSComponent.BOSCheckEdit(this.components);
            this.fld_btnChoose = new BOSComponent.BOSButton(this.components);
            this.fld_btnCancel = new BOSComponent.BOSButton(this.components);
            this.fld_dgcBranchs = new BOSERP.BranchGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkIsDefault.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcBranchs)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_chkIsDefault
            // 
            this.fld_chkIsDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fld_chkIsDefault.BOSComment = null;
            this.fld_chkIsDefault.BOSDataMember = null;
            this.fld_chkIsDefault.BOSDataSource = null;
            this.fld_chkIsDefault.BOSDescription = null;
            this.fld_chkIsDefault.BOSError = null;
            this.fld_chkIsDefault.BOSFieldGroup = null;
            this.fld_chkIsDefault.BOSFieldRelation = null;
            this.fld_chkIsDefault.BOSPrivilege = null;
            this.fld_chkIsDefault.BOSPropertyName = null;
            this.fld_chkIsDefault.Location = new System.Drawing.Point(12, 437);
            this.fld_chkIsDefault.Name = "fld_chkIsDefault";
            this.fld_chkIsDefault.Properties.Caption = "Chọn mặc định cho những lần sau";
            this.fld_chkIsDefault.Screen = null;
            this.fld_chkIsDefault.Size = new System.Drawing.Size(213, 19);
            this.fld_chkIsDefault.TabIndex = 1;
            // 
            // fld_btnChoose
            // 
            this.fld_btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_btnChoose.BOSComment = null;
            this.fld_btnChoose.BOSDataMember = null;
            this.fld_btnChoose.BOSDataSource = null;
            this.fld_btnChoose.BOSDescription = null;
            this.fld_btnChoose.BOSError = null;
            this.fld_btnChoose.BOSFieldGroup = null;
            this.fld_btnChoose.BOSFieldRelation = null;
            this.fld_btnChoose.BOSPrivilege = null;
            this.fld_btnChoose.BOSPropertyName = null;
            this.fld_btnChoose.Location = new System.Drawing.Point(515, 429);
            this.fld_btnChoose.Name = "fld_btnChoose";
            this.fld_btnChoose.Screen = null;
            this.fld_btnChoose.Size = new System.Drawing.Size(75, 27);
            this.fld_btnChoose.TabIndex = 2;
            this.fld_btnChoose.Text = "Chọn";
            this.fld_btnChoose.Click += new System.EventHandler(this.fld_btnChoose_Click);
            // 
            // fld_btnCancel
            // 
            this.fld_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_btnCancel.BOSComment = null;
            this.fld_btnCancel.BOSDataMember = null;
            this.fld_btnCancel.BOSDataSource = null;
            this.fld_btnCancel.BOSDescription = null;
            this.fld_btnCancel.BOSError = null;
            this.fld_btnCancel.BOSFieldGroup = null;
            this.fld_btnCancel.BOSFieldRelation = null;
            this.fld_btnCancel.BOSPrivilege = null;
            this.fld_btnCancel.BOSPropertyName = null;
            this.fld_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fld_btnCancel.Location = new System.Drawing.Point(596, 429);
            this.fld_btnCancel.Name = "fld_btnCancel";
            this.fld_btnCancel.Screen = null;
            this.fld_btnCancel.Size = new System.Drawing.Size(75, 27);
            this.fld_btnCancel.TabIndex = 2;
            this.fld_btnCancel.Text = "Hủy";
            this.fld_btnCancel.Click += new System.EventHandler(this.fld_btnCancel_Click);
            // 
            // fld_dgcBranchs
            // 
            this.fld_dgcBranchs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcBranchs.BOSComment = null;
            this.fld_dgcBranchs.BOSDataMember = null;
            this.fld_dgcBranchs.BOSDataSource = "BRBranchs";
            this.fld_dgcBranchs.BOSDescription = null;
            this.fld_dgcBranchs.BOSError = null;
            this.fld_dgcBranchs.BOSFieldGroup = null;
            this.fld_dgcBranchs.BOSFieldRelation = null;
            this.fld_dgcBranchs.BOSGridType = null;
            this.fld_dgcBranchs.BOSPrivilege = null;
            this.fld_dgcBranchs.BOSPropertyName = null;
            this.fld_dgcBranchs.Location = new System.Drawing.Point(0, 1);
            this.fld_dgcBranchs.MenuManager = this.screenToolbar;
            this.fld_dgcBranchs.Name = "fld_dgcBranchs";
            this.fld_dgcBranchs.Screen = null;
            this.fld_dgcBranchs.Size = new System.Drawing.Size(683, 410);
            this.fld_dgcBranchs.TabIndex = 6;
            // 
            // guiChooseBranch
            // 
            this.AcceptButton = this.fld_btnChoose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.fld_btnCancel;
            this.ClientSize = new System.Drawing.Size(683, 468);
            this.ControlBox = true;
            this.Controls.Add(this.fld_dgcBranchs);
            this.Controls.Add(this.fld_btnCancel);
            this.Controls.Add(this.fld_btnChoose);
            this.Controls.Add(this.fld_chkIsDefault);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiChooseBranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn chi nhánh";
            this.Load += new System.EventHandler(this.guiChooseBranch_Load);
            this.Controls.SetChildIndex(this.fld_chkIsDefault, 0);
            this.Controls.SetChildIndex(this.fld_btnChoose, 0);
            this.Controls.SetChildIndex(this.fld_btnCancel, 0);
            this.Controls.SetChildIndex(this.fld_dgcBranchs, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkIsDefault.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcBranchs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BOSComponent.BOSCheckEdit fld_chkIsDefault;
        private BOSComponent.BOSButton fld_btnChoose;
        private BOSComponent.BOSButton fld_btnCancel;
        private BranchGridControl fld_dgcBranchs;
    }
}