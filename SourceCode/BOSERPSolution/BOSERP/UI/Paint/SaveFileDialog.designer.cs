namespace BOSERP.UI.Paint
{
    partial class SaveDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.fld_lblNoTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fld_btnSave = new System.Windows.Forms.Button();
            this.fld_btnNo = new System.Windows.Forms.Button();
            this.fld_btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScreenHelper
            // 
            this.ScreenHelper.HelpNamespace = null;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.ScreenHelper.SetHelpKeyword(this.label1, null);
            this.ScreenHelper.SetHelpNavigator(this.label1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label1.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.label1, null);
            this.label1.Name = "label1";
            // 
            // fld_lblNoTitle
            // 
            this.fld_lblNoTitle.AccessibleDescription = null;
            this.fld_lblNoTitle.AccessibleName = null;
            resources.ApplyResources(this.fld_lblNoTitle, "fld_lblNoTitle");
            this.fld_lblNoTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.ScreenHelper.SetHelpKeyword(this.fld_lblNoTitle, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_lblNoTitle, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_lblNoTitle.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_lblNoTitle, null);
            this.fld_lblNoTitle.Name = "fld_lblNoTitle";
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = null;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.fld_lblNoTitle);
            this.panel1.Font = null;
            this.ScreenHelper.SetHelpKeyword(this.panel1, null);
            this.ScreenHelper.SetHelpNavigator(this.panel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("panel1.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.panel1, null);
            this.panel1.Name = "panel1";
            // 
            // fld_btnSave
            // 
            this.fld_btnSave.AccessibleDescription = null;
            this.fld_btnSave.AccessibleName = null;
            resources.ApplyResources(this.fld_btnSave, "fld_btnSave");
            this.fld_btnSave.BackgroundImage = null;
            this.ScreenHelper.SetHelpKeyword(this.fld_btnSave, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_btnSave, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_btnSave.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_btnSave, null);
            this.fld_btnSave.Name = "fld_btnSave";
            this.fld_btnSave.UseVisualStyleBackColor = true;
            this.fld_btnSave.Click += new System.EventHandler(this.fld_btnSave_Click);
            // 
            // fld_btnNo
            // 
            this.fld_btnNo.AccessibleDescription = null;
            this.fld_btnNo.AccessibleName = null;
            resources.ApplyResources(this.fld_btnNo, "fld_btnNo");
            this.fld_btnNo.BackgroundImage = null;
            this.ScreenHelper.SetHelpKeyword(this.fld_btnNo, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_btnNo, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_btnNo.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_btnNo, null);
            this.fld_btnNo.Name = "fld_btnNo";
            this.fld_btnNo.UseVisualStyleBackColor = true;
            this.fld_btnNo.Click += new System.EventHandler(this.fld_btnNo_Click);
            // 
            // fld_btnCancel
            // 
            this.fld_btnCancel.AccessibleDescription = null;
            this.fld_btnCancel.AccessibleName = null;
            resources.ApplyResources(this.fld_btnCancel, "fld_btnCancel");
            this.fld_btnCancel.BackgroundImage = null;
            this.fld_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ScreenHelper.SetHelpKeyword(this.fld_btnCancel, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_btnCancel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_btnCancel.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_btnCancel, null);
            this.fld_btnCancel.Name = "fld_btnCancel";
            this.fld_btnCancel.UseVisualStyleBackColor = true;
            this.fld_btnCancel.Click += new System.EventHandler(this.fld_btnCancel_Click);
            // 
            // SaveDialog
            // 
            this.AcceptButton = this.fld_btnSave;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.fld_btnCancel;
            this.ControlBox = true;
            this.Controls.Add(this.fld_btnCancel);
            this.Controls.Add(this.fld_btnNo);
            this.Controls.Add(this.fld_btnSave);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ScreenHelper.SetHelpKeyword(this, null);
            this.ScreenHelper.SetHelpNavigator(this, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("$this.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this, null);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveDialog";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SaveDialog_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.fld_btnSave, 0);
            this.Controls.SetChildIndex(this.fld_btnNo, 0);
            this.Controls.SetChildIndex(this.fld_btnCancel, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fld_lblNoTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button fld_btnSave;
        private System.Windows.Forms.Button fld_btnNo;
        private System.Windows.Forms.Button fld_btnCancel;
    }
}