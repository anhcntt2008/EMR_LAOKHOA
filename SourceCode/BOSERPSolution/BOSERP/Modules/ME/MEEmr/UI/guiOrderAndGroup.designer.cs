using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    partial class guiOrderAndGroup
    {


        /// <summary>
        /// Clean up any resources being used
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                if (components != null)
                    components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiOrderAndGroup));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.grcData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnGroup = new DevExpress.XtraEditors.SimpleButton();
            this.dragDropEvents1 = new DevExpress.Utils.DragDrop.DragDropEvents(this.components);
            this.btnUnGroup = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtGroup = new DevExpress.XtraEditors.TextEdit();
            this.cbbFormatType = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbFormatType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnOk.Location = new System.Drawing.Point(734, 600);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Hoàn tất";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(812, 600);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grcData
            // 
            this.grcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grcData.Location = new System.Drawing.Point(2, 2);
            this.grcData.MainView = this.gridView1;
            this.grcData.MenuManager = this.screenToolbar;
            this.grcData.Name = "grcData";
            this.grcData.Size = new System.Drawing.Size(885, 592);
            this.grcData.TabIndex = 9;
            this.grcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grcData;
            this.gridView1.Name = "gridView1";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(325, 606);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(227, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Check chọn và Gom nhóm; Kéo thả để sắp xếp.";
            // 
            // btnGroup
            // 
            this.btnGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGroup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGroup.ImageOptions.Image")));
            this.btnGroup.Location = new System.Drawing.Point(156, 601);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(79, 23);
            this.btnGroup.TabIndex = 11;
            this.btnGroup.Text = "Gom nhóm";
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // btnUnGroup
            // 
            this.btnUnGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnGroup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUnGroup.ImageOptions.Image")));
            this.btnUnGroup.Location = new System.Drawing.Point(241, 601);
            this.btnUnGroup.Name = "btnUnGroup";
            this.btnUnGroup.Size = new System.Drawing.Size(77, 23);
            this.btnUnGroup.TabIndex = 12;
            this.btnUnGroup.Text = "Xóa nhóm";
            this.btnUnGroup.Click += new System.EventHandler(this.btnUnGroup_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 606);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 13);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Nhóm:";
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(50, 602);
            this.txtGroup.MenuManager = this.screenToolbar;
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(100, 20);
            this.txtGroup.TabIndex = 14;
            // 
            // galleryDropDown1
            // 
            // 
            // cbbFormatType
            // 
            this.cbbFormatType.EditValue = "Chèn ngoặc kép";
            this.cbbFormatType.Location = new System.Drawing.Point(573, 602);
            this.cbbFormatType.MenuManager = this.screenToolbar;
            this.cbbFormatType.Name = "cbbFormatType";
            this.cbbFormatType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbFormatType.Properties.Items.AddRange(new object[] {
            "Chèn ngoặc kép",
            "Chèn tên nhóm"});
            this.cbbFormatType.Size = new System.Drawing.Size(155, 20);
            this.cbbFormatType.TabIndex = 15;
            // 
            // guiOrderAndGroup
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(890, 627);
            this.ControlBox = true;
            this.Controls.Add(this.cbbFormatType);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnUnGroup);
            this.Controls.Add(this.btnGroup);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.grcData);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiOrderAndGroup";
            this.Text = "Sắp xếp và nhóm dữ liệu";
            this.Load += new System.EventHandler(this.DSMEEMR100_Load);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.grcData, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.btnGroup, 0);
            this.Controls.SetChildIndex(this.btnUnGroup, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.txtGroup, 0);
            this.Controls.SetChildIndex(this.cbbFormatType, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbFormatType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraGrid.GridControl grcData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGroup;
        private DevExpress.Utils.DragDrop.DragDropEvents dragDropEvents1;
        private DevExpress.XtraEditors.SimpleButton btnUnGroup;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtGroup;
        private ComboBoxEdit cbbFormatType;
    }
}
