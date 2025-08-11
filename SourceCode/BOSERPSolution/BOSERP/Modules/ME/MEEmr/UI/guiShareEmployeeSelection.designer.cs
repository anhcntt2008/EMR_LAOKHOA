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
    partial class guiShareEmployeeSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiShareEmployeeSelection));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.fld_dgcEmployeeSelections = new BOSERP.Modules.MEEmr.EmployeeSelectionGridControl();
            this.fld_dgvMEEmrTransferHistories = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bosLabel3 = new BOSComponent.BOSLabel();
            this.fld_lkeEmrShareHistoryModeEmployee = new BOSComponent.BOSLookupEdit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcEmployeeSelections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrTransferHistories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeEmrShareHistoryModeEmployee.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(684, 541);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 23);
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
            // fld_dgcEmployeeSelections
            // 
            this.fld_dgcEmployeeSelections.AllowDrop = true;
            this.fld_dgcEmployeeSelections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcEmployeeSelections.BOSComment = "";
            this.fld_dgcEmployeeSelections.BOSDataMember = "";
            this.fld_dgcEmployeeSelections.BOSDataSource = "HREmployees";
            this.fld_dgcEmployeeSelections.BOSDescription = null;
            this.fld_dgcEmployeeSelections.BOSError = null;
            this.fld_dgcEmployeeSelections.BOSFieldGroup = "";
            this.fld_dgcEmployeeSelections.BOSFieldRelation = "";
            this.fld_dgcEmployeeSelections.BOSGridType = null;
            this.fld_dgcEmployeeSelections.BOSPrivilege = "";
            this.fld_dgcEmployeeSelections.BOSPropertyName = "";
            this.fld_dgcEmployeeSelections.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcEmployeeSelections.Location = new System.Drawing.Point(3, 1);
            this.fld_dgcEmployeeSelections.MainView = this.fld_dgvMEEmrTransferHistories;
            this.fld_dgcEmployeeSelections.Name = "fld_dgcEmployeeSelections";
            this.fld_dgcEmployeeSelections.PrintReport = false;
            this.fld_dgcEmployeeSelections.Screen = null;
            this.fld_dgcEmployeeSelections.Size = new System.Drawing.Size(852, 534);
            this.fld_dgcEmployeeSelections.TabIndex = 12;
            this.fld_dgcEmployeeSelections.Tag = "DC";
            this.fld_dgcEmployeeSelections.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrTransferHistories});
            // 
            // fld_dgvMEEmrTransferHistories
            // 
            this.fld_dgvMEEmrTransferHistories.GridControl = this.fld_dgcEmployeeSelections;
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
            this.bosLabel3.TabIndex = 1000000033;
            this.bosLabel3.Tag = "SI";
            this.bosLabel3.Text = "Chế độ chia sẻ";
            // 
            // fld_lkeEmrShareHistoryModeEmployee
            // 
            this.fld_lkeEmrShareHistoryModeEmployee.BOSAllowAddNew = false;
            this.fld_lkeEmrShareHistoryModeEmployee.BOSAllowDummy = false;
            this.fld_lkeEmrShareHistoryModeEmployee.BOSComment = "";
            this.fld_lkeEmrShareHistoryModeEmployee.BOSDataMember = "MEEmrShareHistoryMode";
            this.fld_lkeEmrShareHistoryModeEmployee.BOSDataSource = "MEEmrShareHistories";
            this.fld_lkeEmrShareHistoryModeEmployee.BOSDescription = null;
            this.fld_lkeEmrShareHistoryModeEmployee.BOSDummyText = null;
            this.fld_lkeEmrShareHistoryModeEmployee.BOSError = null;
            this.fld_lkeEmrShareHistoryModeEmployee.BOSFieldGroup = "";
            this.fld_lkeEmrShareHistoryModeEmployee.BOSFieldParent = "";
            this.fld_lkeEmrShareHistoryModeEmployee.BOSFieldRelation = "";
            this.fld_lkeEmrShareHistoryModeEmployee.BOSPrivilege = "";
            this.fld_lkeEmrShareHistoryModeEmployee.BOSPropertyName = "EditValue";
            this.fld_lkeEmrShareHistoryModeEmployee.BOSSelectType = "";
            this.fld_lkeEmrShareHistoryModeEmployee.BOSSelectTypeValue = "";
            this.fld_lkeEmrShareHistoryModeEmployee.CurrentDisplayText = null;
            this.fld_lkeEmrShareHistoryModeEmployee.Location = new System.Drawing.Point(82, 543);
            this.fld_lkeEmrShareHistoryModeEmployee.Name = "fld_lkeEmrShareHistoryModeEmployee";
            this.fld_lkeEmrShareHistoryModeEmployee.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeEmrShareHistoryModeEmployee.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeEmrShareHistoryModeEmployee.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeEmrShareHistoryModeEmployee.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeEmrShareHistoryModeEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeEmrShareHistoryModeEmployee.Properties.DisplayMember = "MEEmrShareHistoryMode";
            this.fld_lkeEmrShareHistoryModeEmployee.Properties.NullText = "";
            this.fld_lkeEmrShareHistoryModeEmployee.Properties.PopupWidth = 40;
            this.fld_lkeEmrShareHistoryModeEmployee.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeEmrShareHistoryModeEmployee.Properties.ValueMember = "MEEmrShareHistoryMode";
            this.fld_lkeEmrShareHistoryModeEmployee.Screen = null;
            this.fld_lkeEmrShareHistoryModeEmployee.Size = new System.Drawing.Size(153, 20);
            this.fld_lkeEmrShareHistoryModeEmployee.TabIndex = 1000000034;
            this.fld_lkeEmrShareHistoryModeEmployee.Tag = "DC";
            // 
            // guiShareEmployeeSelection
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(857, 569);
            this.ControlBox = true;
            this.Controls.Add(this.fld_lkeEmrShareHistoryModeEmployee);
            this.Controls.Add(this.bosLabel3);
            this.Controls.Add(this.fld_dgcEmployeeSelections);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiShareEmployeeSelection";
            this.Text = "Chọn nhân viên cần chia sẻ";
            this.Load += new System.EventHandler(this.Form_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DSMEEMR106_KeyPress);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DSMEEMR106_PreviewKeyDown);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.fld_dgcEmployeeSelections, 0);
            this.Controls.SetChildIndex(this.bosLabel3, 0);
            this.Controls.SetChildIndex(this.fld_lkeEmrShareHistoryModeEmployee, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcEmployeeSelections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrTransferHistories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeEmrShareHistoryModeEmployee.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private EmployeeSelectionGridControl fld_dgcEmployeeSelections;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrTransferHistories;
        private BOSComponent.BOSLabel bosLabel3;
        private BOSComponent.BOSLookupEdit fld_lkeEmrShareHistoryModeEmployee;
    }
}
