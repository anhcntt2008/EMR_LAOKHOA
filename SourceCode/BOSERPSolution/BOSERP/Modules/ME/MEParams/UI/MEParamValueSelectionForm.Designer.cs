namespace BOSERP.Modules.ME.MEParams.UI
{
    partial class MEParamValueSelectionForm
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.fld_grdMEParamValues = new BOSComponent.BOSGridControl(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdMEParamValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_grdMEParamValues
            // 
            this.fld_grdMEParamValues.BOSComment = null;
            this.fld_grdMEParamValues.BOSDataMember = null;
            this.fld_grdMEParamValues.BOSDataSource = "MEParamValues";
            this.fld_grdMEParamValues.BOSDescription = null;
            this.fld_grdMEParamValues.BOSError = null;
            this.fld_grdMEParamValues.BOSFieldGroup = null;
            this.fld_grdMEParamValues.BOSFieldRelation = null;
            this.fld_grdMEParamValues.BOSGridType = null;
            this.fld_grdMEParamValues.BOSPrivilege = null;
            this.fld_grdMEParamValues.BOSPropertyName = null;
            this.fld_grdMEParamValues.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.fld_grdMEParamValues.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.fld_grdMEParamValues.Location = new System.Drawing.Point(0, 0);
            this.fld_grdMEParamValues.MainView = this.gridView1;
            this.fld_grdMEParamValues.Name = "fld_grdMEParamValues";
            this.fld_grdMEParamValues.PrintReport = false;
            this.fld_grdMEParamValues.Screen = null;
            this.fld_grdMEParamValues.Size = new System.Drawing.Size(701, 261);
            this.fld_grdMEParamValues.TabIndex = 8;
            this.fld_grdMEParamValues.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_grdMEParamValues.Click += new System.EventHandler(this.fld_grdMEParamValues_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_grdMEParamValues;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            // 
            // MEParamValueSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 261);
            this.Controls.Add(this.fld_grdMEParamValues);
            this.Name = "MEParamValueSelectionForm";
            this.Text = "MEParamValueSelectionForm";
            this.Load += new System.EventHandler(this.MEParamValueSelectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdMEParamValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BOSComponent.BOSGridControl fld_grdMEParamValues;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}