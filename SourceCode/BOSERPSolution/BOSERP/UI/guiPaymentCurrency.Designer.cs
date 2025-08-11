namespace BOSERP
{
    partial class guiPaymentCurrency
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
            this.fld_dgcCustomerPaymentCurrency = new BOSERP.CustomerPaymentCurrencyGridControl();
            this.fld_btnOK = new BOSComponent.BOSButton(this.components);
            this.fld_btnCancel = new BOSComponent.BOSButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcCustomerPaymentCurrency)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_dgcCustomerPaymentCurrency
            // 
            this.fld_dgcCustomerPaymentCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcCustomerPaymentCurrency.BOSComment = null;
            this.fld_dgcCustomerPaymentCurrency.BOSDataMember = null;
            this.fld_dgcCustomerPaymentCurrency.BOSDataSource = "ARCustomerPaymentCurrencys";
            this.fld_dgcCustomerPaymentCurrency.BOSDescription = null;
            this.fld_dgcCustomerPaymentCurrency.BOSError = null;
            this.fld_dgcCustomerPaymentCurrency.BOSFieldGroup = null;
            this.fld_dgcCustomerPaymentCurrency.BOSFieldRelation = null;
            this.fld_dgcCustomerPaymentCurrency.BOSGridType = null;
            this.fld_dgcCustomerPaymentCurrency.BOSPrivilege = null;
            this.fld_dgcCustomerPaymentCurrency.BOSPropertyName = null;
            this.fld_dgcCustomerPaymentCurrency.DocumentCurrencyID = 0;
            this.fld_dgcCustomerPaymentCurrency.Location = new System.Drawing.Point(1, 2);
            this.fld_dgcCustomerPaymentCurrency.Name = "fld_dgcCustomerPaymentCurrency";
            this.fld_dgcCustomerPaymentCurrency.PaymentAmount = 0;
            this.fld_dgcCustomerPaymentCurrency.Screen = null;
            this.fld_dgcCustomerPaymentCurrency.Size = new System.Drawing.Size(621, 326);
            this.fld_dgcCustomerPaymentCurrency.TabIndex = 0;
            // 
            // fld_btnOK
            // 
            this.fld_btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_btnOK.BOSComment = null;
            this.fld_btnOK.BOSDataMember = null;
            this.fld_btnOK.BOSDataSource = null;
            this.fld_btnOK.BOSDescription = null;
            this.fld_btnOK.BOSError = null;
            this.fld_btnOK.BOSFieldGroup = null;
            this.fld_btnOK.BOSFieldRelation = null;
            this.fld_btnOK.BOSPrivilege = null;
            this.fld_btnOK.BOSPropertyName = null;
            this.fld_btnOK.Location = new System.Drawing.Point(456, 344);
            this.fld_btnOK.Name = "fld_btnOK";
            this.fld_btnOK.Screen = null;
            this.fld_btnOK.Size = new System.Drawing.Size(75, 27);
            this.fld_btnOK.TabIndex = 1;
            this.fld_btnOK.Text = "OK";
            this.fld_btnOK.Click += new System.EventHandler(this.fld_btnOK_Click);
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
            this.fld_btnCancel.Location = new System.Drawing.Point(537, 344);
            this.fld_btnCancel.Name = "fld_btnCancel";
            this.fld_btnCancel.Screen = null;
            this.fld_btnCancel.Size = new System.Drawing.Size(75, 27);
            this.fld_btnCancel.TabIndex = 1;
            this.fld_btnCancel.Text = "Hủy";
            this.fld_btnCancel.Click += new System.EventHandler(this.fld_btnCancel_Click);
            // 
            // guiPaymentCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.fld_btnCancel;
            this.ClientSize = new System.Drawing.Size(624, 383);
            this.ControlBox = true;
            this.Controls.Add(this.fld_btnCancel);
            this.Controls.Add(this.fld_btnOK);
            this.Controls.Add(this.fld_dgcCustomerPaymentCurrency);
            this.Name = "guiPaymentCurrency";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán theo tiền tệ";
            this.Load += new System.EventHandler(this.guiPaymentCurrency_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.guiPaymentCurrency_FormClosed);
            this.Controls.SetChildIndex(this.fld_dgcCustomerPaymentCurrency, 0);
            this.Controls.SetChildIndex(this.fld_btnOK, 0);
            this.Controls.SetChildIndex(this.fld_btnCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcCustomerPaymentCurrency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomerPaymentCurrencyGridControl fld_dgcCustomerPaymentCurrency;
        private BOSComponent.BOSButton fld_btnOK;
        private BOSComponent.BOSButton fld_btnCancel;
    }
}