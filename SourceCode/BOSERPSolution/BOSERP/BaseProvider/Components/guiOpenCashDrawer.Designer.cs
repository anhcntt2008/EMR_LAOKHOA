namespace BOSERP
{
    partial class guiOpenCashDrawer
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
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtPassword = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtDesc = new BOSComponent.BOSMemoEdit(this.components);
            this.btnOK = new BOSComponent.BOSButton(this.components);
            this.btnCancel = new BOSComponent.BOSButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtDesc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bosLabel1
            // 
            this.bosLabel1.BOSComment = null;
            this.bosLabel1.BOSDataMember = null;
            this.bosLabel1.BOSDataSource = null;
            this.bosLabel1.BOSDescription = null;
            this.bosLabel1.BOSError = null;
            this.bosLabel1.BOSFieldGroup = null;
            this.bosLabel1.BOSFieldRelation = null;
            this.bosLabel1.BOSPrivilege = null;
            this.bosLabel1.BOSPropertyName = null;
            this.bosLabel1.Location = new System.Drawing.Point(12, 12);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.bosLabel1.Size = new System.Drawing.Size(76, 13);
            this.bosLabel1.TabIndex = 6;
            this.bosLabel1.Text = "Nhập mật khẩu:";
            // 
            // fld_txtPassword
            // 
            this.fld_txtPassword.BOSComment = null;
            this.fld_txtPassword.BOSDataMember = null;
            this.fld_txtPassword.BOSDataSource = null;
            this.fld_txtPassword.BOSDescription = null;
            this.fld_txtPassword.BOSError = null;
            this.fld_txtPassword.BOSFieldGroup = null;
            this.fld_txtPassword.BOSFieldRelation = null;
            this.fld_txtPassword.BOSPrivilege = null;
            this.fld_txtPassword.BOSPropertyName = null;
            this.fld_txtPassword.EditValue = "";
            this.fld_txtPassword.Location = new System.Drawing.Point(107, 9);
            this.fld_txtPassword.MenuManager = this.screenToolbar;
            this.fld_txtPassword.Name = "fld_txtPassword";
            this.fld_txtPassword.Properties.PasswordChar = '*';
            this.fld_txtPassword.Screen = null;
            this.fld_txtPassword.Size = new System.Drawing.Size(150, 20);
            this.fld_txtPassword.TabIndex = 0;
            // 
            // bosLabel2
            // 
            this.bosLabel2.BOSComment = null;
            this.bosLabel2.BOSDataMember = null;
            this.bosLabel2.BOSDataSource = null;
            this.bosLabel2.BOSDescription = null;
            this.bosLabel2.BOSError = null;
            this.bosLabel2.BOSFieldGroup = null;
            this.bosLabel2.BOSFieldRelation = null;
            this.bosLabel2.BOSPrivilege = null;
            this.bosLabel2.BOSPropertyName = null;
            this.bosLabel2.Location = new System.Drawing.Point(12, 38);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.bosLabel2.Size = new System.Drawing.Size(47, 13);
            this.bosLabel2.TabIndex = 8;
            this.bosLabel2.Text = "Lý do mở:";
            // 
            // fld_txtDesc
            // 
            this.fld_txtDesc.BOSComment = null;
            this.fld_txtDesc.BOSDataMember = null;
            this.fld_txtDesc.BOSDataSource = null;
            this.fld_txtDesc.BOSDescription = null;
            this.fld_txtDesc.BOSError = null;
            this.fld_txtDesc.BOSFieldGroup = null;
            this.fld_txtDesc.BOSFieldRelation = null;
            this.fld_txtDesc.BOSPrivilege = null;
            this.fld_txtDesc.BOSPropertyName = null;
            this.fld_txtDesc.Location = new System.Drawing.Point(107, 35);
            this.fld_txtDesc.MenuManager = this.screenToolbar;
            this.fld_txtDesc.Name = "fld_txtDesc";
            this.fld_txtDesc.Screen = null;
            this.fld_txtDesc.Size = new System.Drawing.Size(245, 70);
            this.fld_txtDesc.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.BOSComment = null;
            this.btnOK.BOSDataMember = null;
            this.btnOK.BOSDataSource = null;
            this.btnOK.BOSDescription = null;
            this.btnOK.BOSError = null;
            this.btnOK.BOSFieldGroup = null;
            this.btnOK.BOSFieldRelation = null;
            this.btnOK.BOSPrivilege = null;
            this.btnOK.BOSPropertyName = null;
            this.btnOK.Location = new System.Drawing.Point(196, 122);
            this.btnOK.Name = "btnOK";
            this.btnOK.Screen = null;
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BOSComment = null;
            this.btnCancel.BOSDataMember = null;
            this.btnCancel.BOSDataSource = null;
            this.btnCancel.BOSDescription = null;
            this.btnCancel.BOSError = null;
            this.btnCancel.BOSFieldGroup = null;
            this.btnCancel.BOSFieldRelation = null;
            this.btnCancel.BOSPrivilege = null;
            this.btnCancel.BOSPropertyName = null;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(277, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Screen = null;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // guiOpenCashDrawer
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(374, 156);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.fld_txtDesc);
            this.Controls.Add(this.bosLabel2);
            this.Controls.Add(this.fld_txtPassword);
            this.Controls.Add(this.bosLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "guiOpenCashDrawer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xác nhận mở kết";
            this.Controls.SetChildIndex(this.bosLabel1, 0);
            this.Controls.SetChildIndex(this.fld_txtPassword, 0);
            this.Controls.SetChildIndex(this.bosLabel2, 0);
            this.Controls.SetChildIndex(this.fld_txtDesc, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtDesc.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BOSComponent.BOSLabel bosLabel1;
        private BOSComponent.BOSTextBox fld_txtPassword;
        private BOSComponent.BOSLabel bosLabel2;
        private BOSComponent.BOSMemoEdit fld_txtDesc;
        private BOSComponent.BOSButton btnOK;
        private BOSComponent.BOSButton btnCancel;
    }
}