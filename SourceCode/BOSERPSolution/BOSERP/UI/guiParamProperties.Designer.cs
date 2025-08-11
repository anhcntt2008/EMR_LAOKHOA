using BOSComponent;

namespace BOSERP
{
	partial class guiParamProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiParamProperties));
            this.fld_grdParamProperties = new BOSComponent.BOSGridControl(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdParamProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_grdParamProperties
            // 
            this.fld_grdParamProperties.BOSComment = null;
            this.fld_grdParamProperties.BOSDataMember = null;
            this.fld_grdParamProperties.BOSDataSource = null;
            this.fld_grdParamProperties.BOSDescription = null;
            this.fld_grdParamProperties.BOSError = null;
            this.fld_grdParamProperties.BOSFieldGroup = null;
            this.fld_grdParamProperties.BOSFieldRelation = null;
            this.fld_grdParamProperties.BOSGridType = null;
            this.fld_grdParamProperties.BOSPrivilege = null;
            this.fld_grdParamProperties.BOSPropertyName = null;
            this.fld_grdParamProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_grdParamProperties.Location = new System.Drawing.Point(0, 0);
            this.fld_grdParamProperties.MainView = this.gridView1;
            this.fld_grdParamProperties.MenuManager = this.screenToolbar;
            this.fld_grdParamProperties.Name = "fld_grdParamProperties";
            this.fld_grdParamProperties.PrintReport = false;
            this.fld_grdParamProperties.Screen = null;
            this.fld_grdParamProperties.Size = new System.Drawing.Size(884, 561);
            this.fld_grdParamProperties.TabIndex = 7;
            this.fld_grdParamProperties.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_grdParamProperties;
            this.gridView1.Name = "gridView1";
            // 
            // guiParamProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.ControlBox = true;
            this.Controls.Add(this.fld_grdParamProperties);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiParamProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin thẻ";
            this.Load += new System.EventHandler(this.guiKeyWordValue_Load);
            this.Controls.SetChildIndex(this.fld_grdParamProperties, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdParamProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private BOSGridControl fld_grdParamProperties;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}