using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    partial class guiShareDepartmentSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiShareDepartmentSelection));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.fld_dgcDepartmentSelections = new BOSERP.Modules.MEEmr.DepartmentSelectionGridControl();
            this.fld_dgvMEEmrTransferHistories = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bosLabel3 = new BOSComponent.BOSLabel();
            this.fld_lkeEmrShareHistoryModeDepartment = new BOSComponent.BOSLookupEdit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcDepartmentSelections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrTransferHistories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeEmrShareHistoryModeDepartment.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(690, 541);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK (Alt+O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(780, 541);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fld_dgcDepartmentSelections
            // 
            this.fld_dgcDepartmentSelections.AllowDrop = true;
            this.fld_dgcDepartmentSelections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcDepartmentSelections.BOSComment = "";
            this.fld_dgcDepartmentSelections.BOSDataMember = "";
            this.fld_dgcDepartmentSelections.BOSDataSource = "HRDepartments";
            this.fld_dgcDepartmentSelections.BOSDescription = null;
            this.fld_dgcDepartmentSelections.BOSError = null;
            this.fld_dgcDepartmentSelections.BOSFieldGroup = "";
            this.fld_dgcDepartmentSelections.BOSFieldRelation = "";
            this.fld_dgcDepartmentSelections.BOSGridType = null;
            this.fld_dgcDepartmentSelections.BOSPrivilege = "";
            this.fld_dgcDepartmentSelections.BOSPropertyName = "";
            this.fld_dgcDepartmentSelections.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcDepartmentSelections.Location = new System.Drawing.Point(3, 1);
            this.fld_dgcDepartmentSelections.MainView = this.fld_dgvMEEmrTransferHistories;
            this.fld_dgcDepartmentSelections.Name = "fld_dgcDepartmentSelections";
            this.fld_dgcDepartmentSelections.PrintReport = false;
            this.fld_dgcDepartmentSelections.Screen = null;
            this.fld_dgcDepartmentSelections.Size = new System.Drawing.Size(852, 534);
            this.fld_dgcDepartmentSelections.TabIndex = 12;
            this.fld_dgcDepartmentSelections.Tag = "DC";
            this.fld_dgcDepartmentSelections.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrTransferHistories});
            // 
            // fld_dgvMEEmrTransferHistories
            // 
            this.fld_dgvMEEmrTransferHistories.GridControl = this.fld_dgcDepartmentSelections;
            this.fld_dgvMEEmrTransferHistories.Name = "fld_dgvMEEmrTransferHistories";
            this.fld_dgvMEEmrTransferHistories.PaintStyleName = "Office2003";
            // 
            // bosLabel3
            // 
            this.bosLabel3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel3.Appearance.Options.UseBackColor = true;
            this.bosLabel3.Appearance.Options.UseForeColor = true;
            this.bosLabel3.BOSComment = "";
            this.bosLabel3.BOSDataMember = "";
            this.bosLabel3.BOSDataSource = "";
            this.bosLabel3.BOSDescription = null;
            this.bosLabel3.BOSError = null;
            this.bosLabel3.BOSFieldGroup = "";
            this.bosLabel3.BOSFieldRelation = "";
            this.bosLabel3.BOSPrivilege = "";
            this.bosLabel3.BOSPropertyName = "";
            this.bosLabel3.Location = new System.Drawing.Point(6, 546);
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            this.bosLabel3.Size = new System.Drawing.Size(70, 13);
            this.bosLabel3.TabIndex = 1000000035;
            this.bosLabel3.Tag = "SI";
            this.bosLabel3.Text = "Chế độ chia sẻ";
            // 
            // fld_lkeEmrShareHistoryModeDepartment
            // 
            this.fld_lkeEmrShareHistoryModeDepartment.BOSAllowAddNew = false;
            this.fld_lkeEmrShareHistoryModeDepartment.BOSAllowDummy = false;
            this.fld_lkeEmrShareHistoryModeDepartment.BOSComment = "";
            this.fld_lkeEmrShareHistoryModeDepartment.BOSDataMember = "MEEmrShareHistoryMode";
            this.fld_lkeEmrShareHistoryModeDepartment.BOSDataSource = "MEEmrShareHistories";
            this.fld_lkeEmrShareHistoryModeDepartment.BOSDescription = null;
            this.fld_lkeEmrShareHistoryModeDepartment.BOSDummyText = null;
            this.fld_lkeEmrShareHistoryModeDepartment.BOSError = null;
            this.fld_lkeEmrShareHistoryModeDepartment.BOSFieldGroup = "";
            this.fld_lkeEmrShareHistoryModeDepartment.BOSFieldParent = "";
            this.fld_lkeEmrShareHistoryModeDepartment.BOSFieldRelation = "";
            this.fld_lkeEmrShareHistoryModeDepartment.BOSPrivilege = "";
            this.fld_lkeEmrShareHistoryModeDepartment.BOSPropertyName = "EditValue";
            this.fld_lkeEmrShareHistoryModeDepartment.BOSSelectType = "";
            this.fld_lkeEmrShareHistoryModeDepartment.BOSSelectTypeValue = "";
            this.fld_lkeEmrShareHistoryModeDepartment.CurrentDisplayText = null;
            this.fld_lkeEmrShareHistoryModeDepartment.Location = new System.Drawing.Point(82, 543);
            this.fld_lkeEmrShareHistoryModeDepartment.Name = "fld_lkeEmrShareHistoryModeDepartment";
            this.fld_lkeEmrShareHistoryModeDepartment.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeEmrShareHistoryModeDepartment.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeEmrShareHistoryModeDepartment.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeEmrShareHistoryModeDepartment.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeEmrShareHistoryModeDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeEmrShareHistoryModeDepartment.Properties.DisplayMember = "MEEmrShareHistoryMode";
            this.fld_lkeEmrShareHistoryModeDepartment.Properties.NullText = "";
            this.fld_lkeEmrShareHistoryModeDepartment.Properties.PopupWidth = 40;
            this.fld_lkeEmrShareHistoryModeDepartment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeEmrShareHistoryModeDepartment.Properties.ValueMember = "MEEmrShareHistoryMode";
            this.fld_lkeEmrShareHistoryModeDepartment.Screen = null;
            this.fld_lkeEmrShareHistoryModeDepartment.Size = new System.Drawing.Size(153, 20);
            this.fld_lkeEmrShareHistoryModeDepartment.TabIndex = 1000000036;
            this.fld_lkeEmrShareHistoryModeDepartment.Tag = "DC";
            // 
            // guiShareDepartmentSelection
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(857, 569);
            this.ControlBox = true;
            this.Controls.Add(this.fld_lkeEmrShareHistoryModeDepartment);
            this.Controls.Add(this.bosLabel3);
            this.Controls.Add(this.fld_dgcDepartmentSelections);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiShareDepartmentSelection";
            this.Text = "Chọn khoa phòng cần chia sẻ";
            this.Load += new System.EventHandler(this.Form_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DSMEEMR106_KeyPress);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DSMEEMR106_PreviewKeyDown);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.fld_dgcDepartmentSelections, 0);
            this.Controls.SetChildIndex(this.bosLabel3, 0);
            this.Controls.SetChildIndex(this.fld_lkeEmrShareHistoryModeDepartment, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcDepartmentSelections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrTransferHistories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeEmrShareHistoryModeDepartment.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DepartmentSelectionGridControl fld_dgcDepartmentSelections;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrTransferHistories;
        private BOSComponent.BOSLabel bosLabel3;
        private BOSComponent.BOSLookupEdit fld_lkeEmrShareHistoryModeDepartment;
    }
}
