using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;

namespace BOSERP.Modules.MEDocumentManage.UI
{
    /// <summary>
    /// Summary description for DMMEDocument101
    /// </summary>
    partial class DMDOCMAN99
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMDOCMAN99));
            this.panelControl1 = new BOSComponent.BOSPanel(this.components);
            this.txtLogs = new BOSComponent.BOSMemoEdit(this.components);
            this.btnClearLogs = new BOSComponent.BOSButton(this.components);
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogs.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BOSComment = null;
            this.panelControl1.BOSDataMember = null;
            this.panelControl1.BOSDataSource = null;
            this.panelControl1.BOSDescription = null;
            this.panelControl1.BOSError = null;
            this.panelControl1.BOSFieldGroup = null;
            this.panelControl1.BOSFieldRelation = null;
            this.panelControl1.BOSPrivilege = null;
            this.panelControl1.BOSPropertyName = null;
            this.panelControl1.Controls.Add(this.btnClearLogs);
            this.panelControl1.Controls.Add(this.txtLogs);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Screen = null;
            this.panelControl1.Size = new System.Drawing.Size(826, 530);
            this.panelControl1.TabIndex = 0;
            // 
            // txtLogs
            // 
            this.txtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogs.BOSComment = null;
            this.txtLogs.BOSDataMember = null;
            this.txtLogs.BOSDataSource = null;
            this.txtLogs.BOSDescription = null;
            this.txtLogs.BOSError = null;
            this.txtLogs.BOSFieldGroup = null;
            this.txtLogs.BOSFieldRelation = null;
            this.txtLogs.BOSPrivilege = null;
            this.txtLogs.BOSPropertyName = null;
            this.txtLogs.Location = new System.Drawing.Point(6, 37);
            this.txtLogs.MenuManager = this.screenToolbar;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.txtLogs.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtLogs.Properties.Appearance.Options.UseBackColor = true;
            this.txtLogs.Properties.Appearance.Options.UseForeColor = true;
            this.txtLogs.Screen = null;
            this.txtLogs.Size = new System.Drawing.Size(820, 490);
            this.txtLogs.TabIndex = 0;
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.BOSComment = null;
            this.btnClearLogs.BOSDataMember = null;
            this.btnClearLogs.BOSDataSource = null;
            this.btnClearLogs.BOSDescription = null;
            this.btnClearLogs.BOSError = null;
            this.btnClearLogs.BOSFieldGroup = null;
            this.btnClearLogs.BOSFieldRelation = null;
            this.btnClearLogs.BOSPrivilege = null;
            this.btnClearLogs.BOSPropertyName = null;
            this.btnClearLogs.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bosButton1.ImageOptions.Image")));
            this.btnClearLogs.Location = new System.Drawing.Point(6, 5);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Screen = null;
            this.btnClearLogs.Size = new System.Drawing.Size(73, 28);
            this.btnClearLogs.TabIndex = 1;
            this.btnClearLogs.Text = "Làm mới";
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // DMDOCMAN99
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(826, 530);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMDOCMAN99";
            this.Text = "Thông tin";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLogs.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private BOSPanel panelControl1;
        private BOSMemoEdit txtLogs;
        private BOSButton btnClearLogs;
    }
}
