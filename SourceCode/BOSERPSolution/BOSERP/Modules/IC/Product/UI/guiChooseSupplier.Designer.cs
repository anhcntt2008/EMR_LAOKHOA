namespace BOSERP.Modules.Product
{
    partial class guiChooseSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiChooseSupplier));
            this.fld_dgcICProductSuppliers = new BOSERP.Modules.Product.ProductSuppliersGridControl();
            this.fld_btnOK = new BOSComponent.BOSButton(this.components);
            this.fld_btnCancel = new BOSComponent.BOSButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcICProductSuppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_dgcICProductSuppliers
            // 
            this.fld_dgcICProductSuppliers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcICProductSuppliers.BOSComment = null;
            this.fld_dgcICProductSuppliers.BOSDataMember = null;
            this.fld_dgcICProductSuppliers.BOSDataSource = "ICProductSuppliers";
            this.fld_dgcICProductSuppliers.BOSDescription = null;
            this.fld_dgcICProductSuppliers.BOSError = null;
            this.fld_dgcICProductSuppliers.BOSFieldGroup = null;
            this.fld_dgcICProductSuppliers.BOSFieldRelation = null;
            this.fld_dgcICProductSuppliers.BOSGridType = null;
            this.fld_dgcICProductSuppliers.BOSPrivilege = null;
            this.fld_dgcICProductSuppliers.BOSPropertyName = null;
            this.fld_dgcICProductSuppliers.Location = new System.Drawing.Point(2, 2);
            this.fld_dgcICProductSuppliers.Name = "fld_dgcICProductSuppliers";
            this.fld_dgcICProductSuppliers.Screen = null;
            this.fld_dgcICProductSuppliers.Size = new System.Drawing.Size(664, 426);
            this.fld_dgcICProductSuppliers.TabIndex = 0;
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
            this.fld_btnOK.Location = new System.Drawing.Point(501, 434);
            this.fld_btnOK.Name = "fld_btnOK";
            this.fld_btnOK.Screen = null;
            this.fld_btnOK.Size = new System.Drawing.Size(75, 27);
            this.fld_btnOK.TabIndex = 1;
            this.fld_btnOK.Text = "Đồng ý";
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
            this.fld_btnCancel.Location = new System.Drawing.Point(582, 434);
            this.fld_btnCancel.Name = "fld_btnCancel";
            this.fld_btnCancel.Screen = null;
            this.fld_btnCancel.Size = new System.Drawing.Size(75, 27);
            this.fld_btnCancel.TabIndex = 2;
            this.fld_btnCancel.Text = "Hủy";
            this.fld_btnCancel.Click += new System.EventHandler(this.fld_btnCancel_Click);
            // 
            // guiChooseSupplier
            // 
            this.AcceptButton = this.fld_btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 473);
            this.ControlBox = true;
            this.Controls.Add(this.fld_dgcICProductSuppliers);
            this.Controls.Add(this.fld_btnCancel);
            this.Controls.Add(this.fld_btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiChooseSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhà cung cấp";
            this.Load += new System.EventHandler(this.guiChooseSupplier_Load);
            this.Controls.SetChildIndex(this.fld_btnOK, 0);
            this.Controls.SetChildIndex(this.fld_btnCancel, 0);
            this.Controls.SetChildIndex(this.fld_dgcICProductSuppliers, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcICProductSuppliers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ProductSuppliersGridControl fld_dgcICProductSuppliers;
        private BOSComponent.BOSButton fld_btnOK;
        private BOSComponent.BOSButton fld_btnCancel;
    }
}