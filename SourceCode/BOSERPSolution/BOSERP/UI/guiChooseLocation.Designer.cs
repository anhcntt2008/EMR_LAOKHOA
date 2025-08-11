namespace BOSERP
{
    partial class guiChooseLocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiChooseLocation));
            this.fld_trlGELocations = new BOSERP.GELocationsTreeListControl();
            this.fld_btnOK = new BOSComponent.BOSButton(this.components);
            this.fld_btnCancel = new BOSComponent.BOSButton(this.components);
            this.fld_lkeGELocationID = new BOSComponent.BOSLookupEdit(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_trlGELocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeGELocationID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_trlGELocations
            // 
            this.fld_trlGELocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_trlGELocations.BOSComment = null;
            this.fld_trlGELocations.BOSDataMember = null;
            this.fld_trlGELocations.BOSDataSource = "GELocations";
            this.fld_trlGELocations.BOSDescription = null;
            this.fld_trlGELocations.BOSDisplayOption = true;
            this.fld_trlGELocations.BOSDisplayRoot = false;
            this.fld_trlGELocations.BOSError = null;
            this.fld_trlGELocations.BOSFieldGroup = null;
            this.fld_trlGELocations.BOSFieldRelation = null;
            this.fld_trlGELocations.BOSPrivilege = null;
            this.fld_trlGELocations.BOSPropertyName = null;
            this.fld_trlGELocations.Location = new System.Drawing.Point(2, 23);
            this.fld_trlGELocations.Name = "fld_trlGELocations";
            this.fld_trlGELocations.OptionsView.ShowColumns = false;
            this.fld_trlGELocations.Screen = null;
            this.fld_trlGELocations.Size = new System.Drawing.Size(492, 393);
            this.fld_trlGELocations.TabIndex = 6;
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
            this.fld_btnOK.Location = new System.Drawing.Point(328, 432);
            this.fld_btnOK.Name = "fld_btnOK";
            this.fld_btnOK.Screen = null;
            this.fld_btnOK.Size = new System.Drawing.Size(75, 27);
            this.fld_btnOK.TabIndex = 7;
            this.fld_btnOK.Text = "Chọn";
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
            this.fld_btnCancel.Location = new System.Drawing.Point(409, 432);
            this.fld_btnCancel.Name = "fld_btnCancel";
            this.fld_btnCancel.Screen = null;
            this.fld_btnCancel.Size = new System.Drawing.Size(75, 27);
            this.fld_btnCancel.TabIndex = 7;
            this.fld_btnCancel.Text = "Hủy";
            this.fld_btnCancel.Click += new System.EventHandler(this.fld_btnCancel_Click);
            // 
            // fld_lkeGELocationID
            // 
            this.fld_lkeGELocationID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_lkeGELocationID.BOSAllowAddNew = false;
            this.fld_lkeGELocationID.BOSAllowDummy = false;
            this.fld_lkeGELocationID.BOSComment = null;
            this.fld_lkeGELocationID.BOSDataMember = "GELocationID";
            this.fld_lkeGELocationID.BOSDataSource = "GELocations";
            this.fld_lkeGELocationID.BOSDescription = null;
            this.fld_lkeGELocationID.BOSError = null;
            this.fld_lkeGELocationID.BOSFieldGroup = null;
            this.fld_lkeGELocationID.BOSFieldParent = null;
            this.fld_lkeGELocationID.BOSFieldRelation = null;
            this.fld_lkeGELocationID.BOSPrivilege = null;
            this.fld_lkeGELocationID.BOSPropertyName = null;
            this.fld_lkeGELocationID.BOSSelectType = null;
            this.fld_lkeGELocationID.BOSSelectTypeValue = null;
            this.fld_lkeGELocationID.CurrentDisplayText = null;
            this.fld_lkeGELocationID.Location = new System.Drawing.Point(2, 1);
            this.fld_lkeGELocationID.MenuManager = this.screenToolbar;
            this.fld_lkeGELocationID.Name = "fld_lkeGELocationID";
            this.fld_lkeGELocationID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeGELocationID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GELocationName", "Tên khu vực")});
            this.fld_lkeGELocationID.Properties.DisplayMember = "GELocationName";
            this.fld_lkeGELocationID.Properties.NullText = "";
            this.fld_lkeGELocationID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeGELocationID.Properties.ValueMember = "GELocationID";
            this.fld_lkeGELocationID.Screen = null;
            this.fld_lkeGELocationID.Size = new System.Drawing.Size(492, 20);
            this.fld_lkeGELocationID.TabIndex = 8;
            this.fld_lkeGELocationID.Tag = "";
            this.fld_lkeGELocationID.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.fld_lkeGELocationID_CloseUp);
            // 
            // guiChooseLocation
            // 
            this.AcceptButton = this.fld_btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.fld_btnCancel;
            this.ClientSize = new System.Drawing.Size(496, 467);
            this.ControlBox = true;
            this.Controls.Add(this.fld_lkeGELocationID);
            this.Controls.Add(this.fld_btnCancel);
            this.Controls.Add(this.fld_btnOK);
            this.Controls.Add(this.fld_trlGELocations);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiChooseLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn địa chỉ";
            this.Load += new System.EventHandler(this.guiChooseLocation_Load);
            this.Controls.SetChildIndex(this.fld_trlGELocations, 0);
            this.Controls.SetChildIndex(this.fld_btnOK, 0);
            this.Controls.SetChildIndex(this.fld_btnCancel, 0);
            this.Controls.SetChildIndex(this.fld_lkeGELocationID, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_trlGELocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeGELocationID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GELocationsTreeListControl fld_trlGELocations;
        private BOSComponent.BOSButton fld_btnOK;
        private BOSComponent.BOSButton fld_btnCancel;
        private BOSComponent.BOSLookupEdit fld_lkeGELocationID;
    }
}