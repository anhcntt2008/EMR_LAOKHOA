using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;

namespace BOSERP.Modules.MEEmrAction.UI
{
    /// <summary>
    /// Summary description for DMEMRAC100
    /// </summary>
    partial class DMEMRAC101
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMEMRAC101));
            this.bosPanel1 = new BOSComponent.BOSPanel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bosLabel7 = new BOSComponent.BOSLabel(this.components);
            this.fld_clp_MEEmrActionBorderLeftColor = new BOSComponent.ClasColorPicker(this.components);
            this.fld_spe_MEEmrActionBorderLeftThickness = new BOSComponent.ClasSpinEdit(this.components);
            this.fld_cbo_MEEmrActionBorderLeftStyle = new BOSComponent.BOSComboBox(this.components);
            this.bosLabel6 = new BOSComponent.BOSLabel(this.components);
            this.fld_clp_MEEmrActionBorderBottomColor = new BOSComponent.ClasColorPicker(this.components);
            this.fld_spe_MEEmrActionBorderBottomThickness = new BOSComponent.ClasSpinEdit(this.components);
            this.fld_cbo_MEEmrActionBorderBottomStyle = new BOSComponent.BOSComboBox(this.components);
            this.bosLabel5 = new BOSComponent.BOSLabel(this.components);
            this.fld_clp_MEEmrActionBorderRightColor = new BOSComponent.ClasColorPicker(this.components);
            this.fld_spe_MEEmrActionBorderRightThickness = new BOSComponent.ClasSpinEdit(this.components);
            this.fld_cbo_MEEmrActionBorderRightStyle = new BOSComponent.BOSComboBox(this.components);
            this.bosLabel4 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel3 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_clp_MEEmrActionBorderTopColor = new BOSComponent.ClasColorPicker(this.components);
            this.fld_spe_MEEmrActionBorderTopThickness = new BOSComponent.ClasSpinEdit(this.components);
            this.fld_cbo_MEEmrActionBorderTopStyle = new BOSComponent.BOSComboBox(this.components);
            this.fld_chkMEEmrActionNewGuid = new BOSComponent.BOSCheckEdit(this.components);
            this.bosPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_clp_MEEmrActionBorderLeftColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_spe_MEEmrActionBorderLeftThickness.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_cbo_MEEmrActionBorderLeftStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_clp_MEEmrActionBorderBottomColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_spe_MEEmrActionBorderBottomThickness.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_cbo_MEEmrActionBorderBottomStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_clp_MEEmrActionBorderRightColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_spe_MEEmrActionBorderRightThickness.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_cbo_MEEmrActionBorderRightStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_clp_MEEmrActionBorderTopColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_spe_MEEmrActionBorderTopThickness.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_cbo_MEEmrActionBorderTopStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkMEEmrActionNewGuid.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bosPanel1
            // 
            this.bosPanel1.BOSComment = null;
            this.bosPanel1.BOSDataMember = null;
            this.bosPanel1.BOSDataSource = null;
            this.bosPanel1.BOSDescription = null;
            this.bosPanel1.BOSError = null;
            this.bosPanel1.BOSFieldGroup = null;
            this.bosPanel1.BOSFieldRelation = null;
            this.bosPanel1.BOSPrivilege = null;
            this.bosPanel1.BOSPropertyName = null;
            this.bosPanel1.Controls.Add(this.groupBox1);
            this.bosPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bosPanel1.Location = new System.Drawing.Point(0, 0);
            this.bosPanel1.Name = "bosPanel1";
            this.bosPanel1.Screen = null;
            this.bosPanel1.Size = new System.Drawing.Size(1003, 569);
            this.bosPanel1.TabIndex = 53;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.fld_chkMEEmrActionNewGuid);
            this.groupBox1.Controls.Add(this.bosLabel7);
            this.groupBox1.Controls.Add(this.fld_clp_MEEmrActionBorderLeftColor);
            this.groupBox1.Controls.Add(this.fld_spe_MEEmrActionBorderLeftThickness);
            this.groupBox1.Controls.Add(this.fld_cbo_MEEmrActionBorderLeftStyle);
            this.groupBox1.Controls.Add(this.bosLabel6);
            this.groupBox1.Controls.Add(this.fld_clp_MEEmrActionBorderBottomColor);
            this.groupBox1.Controls.Add(this.fld_spe_MEEmrActionBorderBottomThickness);
            this.groupBox1.Controls.Add(this.fld_cbo_MEEmrActionBorderBottomStyle);
            this.groupBox1.Controls.Add(this.bosLabel5);
            this.groupBox1.Controls.Add(this.fld_clp_MEEmrActionBorderRightColor);
            this.groupBox1.Controls.Add(this.fld_spe_MEEmrActionBorderRightThickness);
            this.groupBox1.Controls.Add(this.fld_cbo_MEEmrActionBorderRightStyle);
            this.groupBox1.Controls.Add(this.bosLabel4);
            this.groupBox1.Controls.Add(this.bosLabel3);
            this.groupBox1.Controls.Add(this.bosLabel2);
            this.groupBox1.Controls.Add(this.bosLabel1);
            this.groupBox1.Controls.Add(this.fld_clp_MEEmrActionBorderTopColor);
            this.groupBox1.Controls.Add(this.fld_spe_MEEmrActionBorderTopThickness);
            this.groupBox1.Controls.Add(this.fld_cbo_MEEmrActionBorderTopStyle);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(979, 141);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khung viền cho dòng mới";
            // 
            // bosLabel7
            // 
            this.bosLabel7.BOSComment = null;
            this.bosLabel7.BOSDataMember = null;
            this.bosLabel7.BOSDataSource = null;
            this.bosLabel7.BOSDescription = null;
            this.bosLabel7.BOSError = null;
            this.bosLabel7.BOSFieldGroup = null;
            this.bosLabel7.BOSFieldRelation = null;
            this.bosLabel7.BOSPrivilege = null;
            this.bosLabel7.BOSPropertyName = null;
            this.bosLabel7.Location = new System.Drawing.Point(635, 17);
            this.bosLabel7.Name = "bosLabel7";
            this.bosLabel7.Screen = null;
            this.bosLabel7.Size = new System.Drawing.Size(24, 13);
            this.bosLabel7.TabIndex = 18;
            this.bosLabel7.Text = "TRÁI";
            // 
            // fld_clp_MEEmrActionBorderLeftColor
            // 
            this.fld_clp_MEEmrActionBorderLeftColor.BOSComment = null;
            this.fld_clp_MEEmrActionBorderLeftColor.BOSDataMember = "MEEmrActionBorderLeftColor";
            this.fld_clp_MEEmrActionBorderLeftColor.BOSDataSource = "MEEmrActions";
            this.fld_clp_MEEmrActionBorderLeftColor.BOSDescription = null;
            this.fld_clp_MEEmrActionBorderLeftColor.BOSError = null;
            this.fld_clp_MEEmrActionBorderLeftColor.BOSFieldGroup = null;
            this.fld_clp_MEEmrActionBorderLeftColor.BOSFieldRelation = null;
            this.fld_clp_MEEmrActionBorderLeftColor.BOSPrivilege = null;
            this.fld_clp_MEEmrActionBorderLeftColor.BOSPropertyName = "EditValue";
            this.fld_clp_MEEmrActionBorderLeftColor.EditValue = System.Drawing.Color.Empty;
            this.fld_clp_MEEmrActionBorderLeftColor.Location = new System.Drawing.Point(571, 35);
            this.fld_clp_MEEmrActionBorderLeftColor.MenuManager = this.screenToolbar;
            this.fld_clp_MEEmrActionBorderLeftColor.Name = "fld_clp_MEEmrActionBorderLeftColor";
            this.fld_clp_MEEmrActionBorderLeftColor.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.fld_clp_MEEmrActionBorderLeftColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_clp_MEEmrActionBorderLeftColor.Screen = null;
            this.fld_clp_MEEmrActionBorderLeftColor.Size = new System.Drawing.Size(164, 20);
            this.fld_clp_MEEmrActionBorderLeftColor.TabIndex = 15;
            this.fld_clp_MEEmrActionBorderLeftColor.Tag = "DC";
            // 
            // fld_spe_MEEmrActionBorderLeftThickness
            // 
            this.fld_spe_MEEmrActionBorderLeftThickness.BOSComment = null;
            this.fld_spe_MEEmrActionBorderLeftThickness.BOSDataMember = "MEEmrActionBorderLeftThickness";
            this.fld_spe_MEEmrActionBorderLeftThickness.BOSDataSource = "MEEmrActions";
            this.fld_spe_MEEmrActionBorderLeftThickness.BOSDescription = null;
            this.fld_spe_MEEmrActionBorderLeftThickness.BOSError = null;
            this.fld_spe_MEEmrActionBorderLeftThickness.BOSFieldGroup = null;
            this.fld_spe_MEEmrActionBorderLeftThickness.BOSFieldRelation = null;
            this.fld_spe_MEEmrActionBorderLeftThickness.BOSPrivilege = null;
            this.fld_spe_MEEmrActionBorderLeftThickness.BOSPropertyName = "EditValue";
            this.fld_spe_MEEmrActionBorderLeftThickness.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.fld_spe_MEEmrActionBorderLeftThickness.Location = new System.Drawing.Point(571, 87);
            this.fld_spe_MEEmrActionBorderLeftThickness.MenuManager = this.screenToolbar;
            this.fld_spe_MEEmrActionBorderLeftThickness.Name = "fld_spe_MEEmrActionBorderLeftThickness";
            this.fld_spe_MEEmrActionBorderLeftThickness.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_spe_MEEmrActionBorderLeftThickness.Screen = null;
            this.fld_spe_MEEmrActionBorderLeftThickness.Size = new System.Drawing.Size(164, 20);
            this.fld_spe_MEEmrActionBorderLeftThickness.TabIndex = 17;
            this.fld_spe_MEEmrActionBorderLeftThickness.Tag = "DC";
            // 
            // fld_cbo_MEEmrActionBorderLeftStyle
            // 
            this.fld_cbo_MEEmrActionBorderLeftStyle.BOSComment = null;
            this.fld_cbo_MEEmrActionBorderLeftStyle.BOSDataMember = "MEEmrActionBorderLeftStyle";
            this.fld_cbo_MEEmrActionBorderLeftStyle.BOSDataSource = "MEEmrActions";
            this.fld_cbo_MEEmrActionBorderLeftStyle.BOSDescription = null;
            this.fld_cbo_MEEmrActionBorderLeftStyle.BOSError = null;
            this.fld_cbo_MEEmrActionBorderLeftStyle.BOSFieldGroup = null;
            this.fld_cbo_MEEmrActionBorderLeftStyle.BOSFieldRelation = null;
            this.fld_cbo_MEEmrActionBorderLeftStyle.BOSPrivilege = null;
            this.fld_cbo_MEEmrActionBorderLeftStyle.BOSPropertyName = "EditValue";
            this.fld_cbo_MEEmrActionBorderLeftStyle.Location = new System.Drawing.Point(571, 61);
            this.fld_cbo_MEEmrActionBorderLeftStyle.MenuManager = this.screenToolbar;
            this.fld_cbo_MEEmrActionBorderLeftStyle.Name = "fld_cbo_MEEmrActionBorderLeftStyle";
            this.fld_cbo_MEEmrActionBorderLeftStyle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_cbo_MEEmrActionBorderLeftStyle.Screen = null;
            this.fld_cbo_MEEmrActionBorderLeftStyle.Size = new System.Drawing.Size(164, 20);
            this.fld_cbo_MEEmrActionBorderLeftStyle.TabIndex = 16;
            this.fld_cbo_MEEmrActionBorderLeftStyle.Tag = "DC";
            // 
            // bosLabel6
            // 
            this.bosLabel6.BOSComment = null;
            this.bosLabel6.BOSDataMember = null;
            this.bosLabel6.BOSDataSource = null;
            this.bosLabel6.BOSDescription = null;
            this.bosLabel6.BOSError = null;
            this.bosLabel6.BOSFieldGroup = null;
            this.bosLabel6.BOSFieldRelation = null;
            this.bosLabel6.BOSPrivilege = null;
            this.bosLabel6.BOSPropertyName = null;
            this.bosLabel6.Location = new System.Drawing.Point(465, 17);
            this.bosLabel6.Name = "bosLabel6";
            this.bosLabel6.Screen = null;
            this.bosLabel6.Size = new System.Drawing.Size(27, 13);
            this.bosLabel6.TabIndex = 14;
            this.bosLabel6.Text = "DƯỚI";
            // 
            // fld_clp_MEEmrActionBorderBottomColor
            // 
            this.fld_clp_MEEmrActionBorderBottomColor.BOSComment = null;
            this.fld_clp_MEEmrActionBorderBottomColor.BOSDataMember = "MEEmrActionBorderBottomColor";
            this.fld_clp_MEEmrActionBorderBottomColor.BOSDataSource = "MEEmrActions";
            this.fld_clp_MEEmrActionBorderBottomColor.BOSDescription = null;
            this.fld_clp_MEEmrActionBorderBottomColor.BOSError = null;
            this.fld_clp_MEEmrActionBorderBottomColor.BOSFieldGroup = null;
            this.fld_clp_MEEmrActionBorderBottomColor.BOSFieldRelation = null;
            this.fld_clp_MEEmrActionBorderBottomColor.BOSPrivilege = null;
            this.fld_clp_MEEmrActionBorderBottomColor.BOSPropertyName = "EditValue";
            this.fld_clp_MEEmrActionBorderBottomColor.EditValue = System.Drawing.Color.Empty;
            this.fld_clp_MEEmrActionBorderBottomColor.Location = new System.Drawing.Point(401, 35);
            this.fld_clp_MEEmrActionBorderBottomColor.MenuManager = this.screenToolbar;
            this.fld_clp_MEEmrActionBorderBottomColor.Name = "fld_clp_MEEmrActionBorderBottomColor";
            this.fld_clp_MEEmrActionBorderBottomColor.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.fld_clp_MEEmrActionBorderBottomColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_clp_MEEmrActionBorderBottomColor.Screen = null;
            this.fld_clp_MEEmrActionBorderBottomColor.Size = new System.Drawing.Size(164, 20);
            this.fld_clp_MEEmrActionBorderBottomColor.TabIndex = 11;
            this.fld_clp_MEEmrActionBorderBottomColor.Tag = "DC";
            // 
            // fld_spe_MEEmrActionBorderBottomThickness
            // 
            this.fld_spe_MEEmrActionBorderBottomThickness.BOSComment = null;
            this.fld_spe_MEEmrActionBorderBottomThickness.BOSDataMember = "MEEmrActionBorderBottomThickness";
            this.fld_spe_MEEmrActionBorderBottomThickness.BOSDataSource = "MEEmrActions";
            this.fld_spe_MEEmrActionBorderBottomThickness.BOSDescription = null;
            this.fld_spe_MEEmrActionBorderBottomThickness.BOSError = null;
            this.fld_spe_MEEmrActionBorderBottomThickness.BOSFieldGroup = null;
            this.fld_spe_MEEmrActionBorderBottomThickness.BOSFieldRelation = null;
            this.fld_spe_MEEmrActionBorderBottomThickness.BOSPrivilege = null;
            this.fld_spe_MEEmrActionBorderBottomThickness.BOSPropertyName = "EditValue";
            this.fld_spe_MEEmrActionBorderBottomThickness.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.fld_spe_MEEmrActionBorderBottomThickness.Location = new System.Drawing.Point(401, 87);
            this.fld_spe_MEEmrActionBorderBottomThickness.MenuManager = this.screenToolbar;
            this.fld_spe_MEEmrActionBorderBottomThickness.Name = "fld_spe_MEEmrActionBorderBottomThickness";
            this.fld_spe_MEEmrActionBorderBottomThickness.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_spe_MEEmrActionBorderBottomThickness.Screen = null;
            this.fld_spe_MEEmrActionBorderBottomThickness.Size = new System.Drawing.Size(164, 20);
            this.fld_spe_MEEmrActionBorderBottomThickness.TabIndex = 13;
            this.fld_spe_MEEmrActionBorderBottomThickness.Tag = "DC";
            // 
            // fld_cbo_MEEmrActionBorderBottomStyle
            // 
            this.fld_cbo_MEEmrActionBorderBottomStyle.BOSComment = null;
            this.fld_cbo_MEEmrActionBorderBottomStyle.BOSDataMember = "MEEmrActionBorderBottomStyle";
            this.fld_cbo_MEEmrActionBorderBottomStyle.BOSDataSource = "MEEmrActions";
            this.fld_cbo_MEEmrActionBorderBottomStyle.BOSDescription = null;
            this.fld_cbo_MEEmrActionBorderBottomStyle.BOSError = null;
            this.fld_cbo_MEEmrActionBorderBottomStyle.BOSFieldGroup = null;
            this.fld_cbo_MEEmrActionBorderBottomStyle.BOSFieldRelation = null;
            this.fld_cbo_MEEmrActionBorderBottomStyle.BOSPrivilege = null;
            this.fld_cbo_MEEmrActionBorderBottomStyle.BOSPropertyName = "EditValue";
            this.fld_cbo_MEEmrActionBorderBottomStyle.Location = new System.Drawing.Point(401, 61);
            this.fld_cbo_MEEmrActionBorderBottomStyle.MenuManager = this.screenToolbar;
            this.fld_cbo_MEEmrActionBorderBottomStyle.Name = "fld_cbo_MEEmrActionBorderBottomStyle";
            this.fld_cbo_MEEmrActionBorderBottomStyle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_cbo_MEEmrActionBorderBottomStyle.Screen = null;
            this.fld_cbo_MEEmrActionBorderBottomStyle.Size = new System.Drawing.Size(164, 20);
            this.fld_cbo_MEEmrActionBorderBottomStyle.TabIndex = 12;
            this.fld_cbo_MEEmrActionBorderBottomStyle.Tag = "DC";
            // 
            // bosLabel5
            // 
            this.bosLabel5.BOSComment = null;
            this.bosLabel5.BOSDataMember = null;
            this.bosLabel5.BOSDataSource = null;
            this.bosLabel5.BOSDescription = null;
            this.bosLabel5.BOSError = null;
            this.bosLabel5.BOSFieldGroup = null;
            this.bosLabel5.BOSFieldRelation = null;
            this.bosLabel5.BOSPrivilege = null;
            this.bosLabel5.BOSPropertyName = null;
            this.bosLabel5.Location = new System.Drawing.Point(293, 17);
            this.bosLabel5.Name = "bosLabel5";
            this.bosLabel5.Screen = null;
            this.bosLabel5.Size = new System.Drawing.Size(24, 13);
            this.bosLabel5.TabIndex = 10;
            this.bosLabel5.Text = "PHẢI";
            // 
            // fld_clp_MEEmrActionBorderRightColor
            // 
            this.fld_clp_MEEmrActionBorderRightColor.BOSComment = null;
            this.fld_clp_MEEmrActionBorderRightColor.BOSDataMember = "MEEmrActionBorderRightColor";
            this.fld_clp_MEEmrActionBorderRightColor.BOSDataSource = "MEEmrActions";
            this.fld_clp_MEEmrActionBorderRightColor.BOSDescription = null;
            this.fld_clp_MEEmrActionBorderRightColor.BOSError = null;
            this.fld_clp_MEEmrActionBorderRightColor.BOSFieldGroup = null;
            this.fld_clp_MEEmrActionBorderRightColor.BOSFieldRelation = null;
            this.fld_clp_MEEmrActionBorderRightColor.BOSPrivilege = null;
            this.fld_clp_MEEmrActionBorderRightColor.BOSPropertyName = "EditValue";
            this.fld_clp_MEEmrActionBorderRightColor.EditValue = System.Drawing.Color.Empty;
            this.fld_clp_MEEmrActionBorderRightColor.Location = new System.Drawing.Point(229, 35);
            this.fld_clp_MEEmrActionBorderRightColor.MenuManager = this.screenToolbar;
            this.fld_clp_MEEmrActionBorderRightColor.Name = "fld_clp_MEEmrActionBorderRightColor";
            this.fld_clp_MEEmrActionBorderRightColor.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.fld_clp_MEEmrActionBorderRightColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_clp_MEEmrActionBorderRightColor.Screen = null;
            this.fld_clp_MEEmrActionBorderRightColor.Size = new System.Drawing.Size(164, 20);
            this.fld_clp_MEEmrActionBorderRightColor.TabIndex = 7;
            this.fld_clp_MEEmrActionBorderRightColor.Tag = "DC";
            // 
            // fld_spe_MEEmrActionBorderRightThickness
            // 
            this.fld_spe_MEEmrActionBorderRightThickness.BOSComment = null;
            this.fld_spe_MEEmrActionBorderRightThickness.BOSDataMember = "MEEmrActionBorderRightThickness";
            this.fld_spe_MEEmrActionBorderRightThickness.BOSDataSource = "MEEmrActions";
            this.fld_spe_MEEmrActionBorderRightThickness.BOSDescription = null;
            this.fld_spe_MEEmrActionBorderRightThickness.BOSError = null;
            this.fld_spe_MEEmrActionBorderRightThickness.BOSFieldGroup = null;
            this.fld_spe_MEEmrActionBorderRightThickness.BOSFieldRelation = null;
            this.fld_spe_MEEmrActionBorderRightThickness.BOSPrivilege = null;
            this.fld_spe_MEEmrActionBorderRightThickness.BOSPropertyName = "EditValue";
            this.fld_spe_MEEmrActionBorderRightThickness.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.fld_spe_MEEmrActionBorderRightThickness.Location = new System.Drawing.Point(229, 87);
            this.fld_spe_MEEmrActionBorderRightThickness.MenuManager = this.screenToolbar;
            this.fld_spe_MEEmrActionBorderRightThickness.Name = "fld_spe_MEEmrActionBorderRightThickness";
            this.fld_spe_MEEmrActionBorderRightThickness.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_spe_MEEmrActionBorderRightThickness.Screen = null;
            this.fld_spe_MEEmrActionBorderRightThickness.Size = new System.Drawing.Size(164, 20);
            this.fld_spe_MEEmrActionBorderRightThickness.TabIndex = 9;
            this.fld_spe_MEEmrActionBorderRightThickness.Tag = "DC";
            // 
            // fld_cbo_MEEmrActionBorderRightStyle
            // 
            this.fld_cbo_MEEmrActionBorderRightStyle.BOSComment = null;
            this.fld_cbo_MEEmrActionBorderRightStyle.BOSDataMember = "MEEmrActionBorderRightStyle";
            this.fld_cbo_MEEmrActionBorderRightStyle.BOSDataSource = "MEEmrActions";
            this.fld_cbo_MEEmrActionBorderRightStyle.BOSDescription = null;
            this.fld_cbo_MEEmrActionBorderRightStyle.BOSError = null;
            this.fld_cbo_MEEmrActionBorderRightStyle.BOSFieldGroup = null;
            this.fld_cbo_MEEmrActionBorderRightStyle.BOSFieldRelation = null;
            this.fld_cbo_MEEmrActionBorderRightStyle.BOSPrivilege = null;
            this.fld_cbo_MEEmrActionBorderRightStyle.BOSPropertyName = "EditValue";
            this.fld_cbo_MEEmrActionBorderRightStyle.Location = new System.Drawing.Point(229, 61);
            this.fld_cbo_MEEmrActionBorderRightStyle.MenuManager = this.screenToolbar;
            this.fld_cbo_MEEmrActionBorderRightStyle.Name = "fld_cbo_MEEmrActionBorderRightStyle";
            this.fld_cbo_MEEmrActionBorderRightStyle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_cbo_MEEmrActionBorderRightStyle.Screen = null;
            this.fld_cbo_MEEmrActionBorderRightStyle.Size = new System.Drawing.Size(164, 20);
            this.fld_cbo_MEEmrActionBorderRightStyle.TabIndex = 8;
            this.fld_cbo_MEEmrActionBorderRightStyle.Tag = "DC";
            // 
            // bosLabel4
            // 
            this.bosLabel4.BOSComment = null;
            this.bosLabel4.BOSDataMember = null;
            this.bosLabel4.BOSDataSource = null;
            this.bosLabel4.BOSDescription = null;
            this.bosLabel4.BOSError = null;
            this.bosLabel4.BOSFieldGroup = null;
            this.bosLabel4.BOSFieldRelation = null;
            this.bosLabel4.BOSPrivilege = null;
            this.bosLabel4.BOSPropertyName = null;
            this.bosLabel4.Location = new System.Drawing.Point(123, 17);
            this.bosLabel4.Name = "bosLabel4";
            this.bosLabel4.Screen = null;
            this.bosLabel4.Size = new System.Drawing.Size(26, 13);
            this.bosLabel4.TabIndex = 6;
            this.bosLabel4.Text = "TRÊN";
            // 
            // bosLabel3
            // 
            this.bosLabel3.BOSComment = null;
            this.bosLabel3.BOSDataMember = null;
            this.bosLabel3.BOSDataSource = null;
            this.bosLabel3.BOSDescription = null;
            this.bosLabel3.BOSError = null;
            this.bosLabel3.BOSFieldGroup = null;
            this.bosLabel3.BOSFieldRelation = null;
            this.bosLabel3.BOSPrivilege = null;
            this.bosLabel3.BOSPropertyName = null;
            this.bosLabel3.Location = new System.Drawing.Point(9, 91);
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            this.bosLabel3.Size = new System.Drawing.Size(35, 13);
            this.bosLabel3.TabIndex = 5;
            this.bosLabel3.Text = "Độ dày";
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
            this.bosLabel2.Location = new System.Drawing.Point(9, 63);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.bosLabel2.Size = new System.Drawing.Size(42, 13);
            this.bosLabel2.TabIndex = 4;
            this.bosLabel2.Text = "Loại viền";
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
            this.bosLabel1.Location = new System.Drawing.Point(9, 37);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.bosLabel1.Size = new System.Drawing.Size(20, 13);
            this.bosLabel1.TabIndex = 3;
            this.bosLabel1.Text = "Màu";
            // 
            // fld_clp_MEEmrActionBorderTopColor
            // 
            this.fld_clp_MEEmrActionBorderTopColor.BOSComment = null;
            this.fld_clp_MEEmrActionBorderTopColor.BOSDataMember = "MEEmrActionBorderTopColor";
            this.fld_clp_MEEmrActionBorderTopColor.BOSDataSource = "MEEmrActions";
            this.fld_clp_MEEmrActionBorderTopColor.BOSDescription = null;
            this.fld_clp_MEEmrActionBorderTopColor.BOSError = null;
            this.fld_clp_MEEmrActionBorderTopColor.BOSFieldGroup = null;
            this.fld_clp_MEEmrActionBorderTopColor.BOSFieldRelation = null;
            this.fld_clp_MEEmrActionBorderTopColor.BOSPrivilege = null;
            this.fld_clp_MEEmrActionBorderTopColor.BOSPropertyName = "EditValue";
            this.fld_clp_MEEmrActionBorderTopColor.EditValue = System.Drawing.Color.Empty;
            this.fld_clp_MEEmrActionBorderTopColor.Location = new System.Drawing.Point(59, 35);
            this.fld_clp_MEEmrActionBorderTopColor.MenuManager = this.screenToolbar;
            this.fld_clp_MEEmrActionBorderTopColor.Name = "fld_clp_MEEmrActionBorderTopColor";
            this.fld_clp_MEEmrActionBorderTopColor.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.fld_clp_MEEmrActionBorderTopColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_clp_MEEmrActionBorderTopColor.Screen = null;
            this.fld_clp_MEEmrActionBorderTopColor.Size = new System.Drawing.Size(164, 20);
            this.fld_clp_MEEmrActionBorderTopColor.TabIndex = 0;
            this.fld_clp_MEEmrActionBorderTopColor.Tag = "DC";
            // 
            // fld_spe_MEEmrActionBorderTopThickness
            // 
            this.fld_spe_MEEmrActionBorderTopThickness.BOSComment = null;
            this.fld_spe_MEEmrActionBorderTopThickness.BOSDataMember = "MEEmrActionBorderTopThickness";
            this.fld_spe_MEEmrActionBorderTopThickness.BOSDataSource = "MEEmrActions";
            this.fld_spe_MEEmrActionBorderTopThickness.BOSDescription = null;
            this.fld_spe_MEEmrActionBorderTopThickness.BOSError = null;
            this.fld_spe_MEEmrActionBorderTopThickness.BOSFieldGroup = null;
            this.fld_spe_MEEmrActionBorderTopThickness.BOSFieldRelation = null;
            this.fld_spe_MEEmrActionBorderTopThickness.BOSPrivilege = null;
            this.fld_spe_MEEmrActionBorderTopThickness.BOSPropertyName = "EditValue";
            this.fld_spe_MEEmrActionBorderTopThickness.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.fld_spe_MEEmrActionBorderTopThickness.Location = new System.Drawing.Point(59, 87);
            this.fld_spe_MEEmrActionBorderTopThickness.MenuManager = this.screenToolbar;
            this.fld_spe_MEEmrActionBorderTopThickness.Name = "fld_spe_MEEmrActionBorderTopThickness";
            this.fld_spe_MEEmrActionBorderTopThickness.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_spe_MEEmrActionBorderTopThickness.Screen = null;
            this.fld_spe_MEEmrActionBorderTopThickness.Size = new System.Drawing.Size(164, 20);
            this.fld_spe_MEEmrActionBorderTopThickness.TabIndex = 2;
            this.fld_spe_MEEmrActionBorderTopThickness.Tag = "DC";
            // 
            // fld_cbo_MEEmrActionBorderTopStyle
            // 
            this.fld_cbo_MEEmrActionBorderTopStyle.BOSComment = null;
            this.fld_cbo_MEEmrActionBorderTopStyle.BOSDataMember = "MEEmrActionBorderTopStyle";
            this.fld_cbo_MEEmrActionBorderTopStyle.BOSDataSource = "MEEmrActions";
            this.fld_cbo_MEEmrActionBorderTopStyle.BOSDescription = null;
            this.fld_cbo_MEEmrActionBorderTopStyle.BOSError = null;
            this.fld_cbo_MEEmrActionBorderTopStyle.BOSFieldGroup = null;
            this.fld_cbo_MEEmrActionBorderTopStyle.BOSFieldRelation = null;
            this.fld_cbo_MEEmrActionBorderTopStyle.BOSPrivilege = null;
            this.fld_cbo_MEEmrActionBorderTopStyle.BOSPropertyName = "EditValue";
            this.fld_cbo_MEEmrActionBorderTopStyle.Location = new System.Drawing.Point(59, 61);
            this.fld_cbo_MEEmrActionBorderTopStyle.MenuManager = this.screenToolbar;
            this.fld_cbo_MEEmrActionBorderTopStyle.Name = "fld_cbo_MEEmrActionBorderTopStyle";
            this.fld_cbo_MEEmrActionBorderTopStyle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_cbo_MEEmrActionBorderTopStyle.Screen = null;
            this.fld_cbo_MEEmrActionBorderTopStyle.Size = new System.Drawing.Size(164, 20);
            this.fld_cbo_MEEmrActionBorderTopStyle.TabIndex = 1;
            this.fld_cbo_MEEmrActionBorderTopStyle.Tag = "DC";
            // 
            // fld_chkMEEmrActionNewGuid
            // 
            this.fld_chkMEEmrActionNewGuid.BOSComment = null;
            this.fld_chkMEEmrActionNewGuid.BOSDataMember = "MEEmrActionBorderOuterOnly";
            this.fld_chkMEEmrActionNewGuid.BOSDataSource = "MEEmrActions";
            this.fld_chkMEEmrActionNewGuid.BOSDescription = null;
            this.fld_chkMEEmrActionNewGuid.BOSError = null;
            this.fld_chkMEEmrActionNewGuid.BOSFieldGroup = null;
            this.fld_chkMEEmrActionNewGuid.BOSFieldRelation = null;
            this.fld_chkMEEmrActionNewGuid.BOSPrivilege = null;
            this.fld_chkMEEmrActionNewGuid.BOSPropertyName = "Checked";
            this.fld_chkMEEmrActionNewGuid.Location = new System.Drawing.Point(59, 116);
            this.fld_chkMEEmrActionNewGuid.MenuManager = this.screenToolbar;
            this.fld_chkMEEmrActionNewGuid.Name = "fld_chkMEEmrActionNewGuid";
            this.fld_chkMEEmrActionNewGuid.Properties.Caption = "Chỉ bao viền ngoài";
            this.fld_chkMEEmrActionNewGuid.Screen = null;
            this.fld_chkMEEmrActionNewGuid.Size = new System.Drawing.Size(160, 19);
            this.fld_chkMEEmrActionNewGuid.TabIndex = 81;
            this.fld_chkMEEmrActionNewGuid.Tag = "DC";
            // 
            // DMEMRAC101
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(1003, 569);
            this.Controls.Add(this.bosPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMEMRAC101";
            this.Text = "Định dạng";
            this.Controls.SetChildIndex(this.bosPanel1, 0);
            this.bosPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_clp_MEEmrActionBorderLeftColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_spe_MEEmrActionBorderLeftThickness.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_cbo_MEEmrActionBorderLeftStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_clp_MEEmrActionBorderBottomColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_spe_MEEmrActionBorderBottomThickness.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_cbo_MEEmrActionBorderBottomStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_clp_MEEmrActionBorderRightColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_spe_MEEmrActionBorderRightThickness.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_cbo_MEEmrActionBorderRightStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_clp_MEEmrActionBorderTopColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_spe_MEEmrActionBorderTopThickness.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_cbo_MEEmrActionBorderTopStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkMEEmrActionNewGuid.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private IContainer components;
        private BOSComponent.BOSPanel bosPanel1;
        private ClasColorPicker fld_clp_MEEmrActionBorderTopColor;
        private BOSComboBox fld_cbo_MEEmrActionBorderTopStyle;
        private ClasSpinEdit fld_spe_MEEmrActionBorderTopThickness;
        private GroupBox groupBox1;
        private BOSLabel bosLabel7;
        private ClasColorPicker fld_clp_MEEmrActionBorderLeftColor;
        private ClasSpinEdit fld_spe_MEEmrActionBorderLeftThickness;
        private BOSComboBox fld_cbo_MEEmrActionBorderLeftStyle;
        private BOSLabel bosLabel6;
        private ClasColorPicker fld_clp_MEEmrActionBorderBottomColor;
        private ClasSpinEdit fld_spe_MEEmrActionBorderBottomThickness;
        private BOSComboBox fld_cbo_MEEmrActionBorderBottomStyle;
        private BOSLabel bosLabel5;
        private ClasColorPicker fld_clp_MEEmrActionBorderRightColor;
        private ClasSpinEdit fld_spe_MEEmrActionBorderRightThickness;
        private BOSComboBox fld_cbo_MEEmrActionBorderRightStyle;
        private BOSLabel bosLabel4;
        private BOSLabel bosLabel3;
        private BOSLabel bosLabel2;
        private BOSLabel bosLabel1;
        private BOSCheckEdit fld_chkMEEmrActionNewGuid;
    }
}
