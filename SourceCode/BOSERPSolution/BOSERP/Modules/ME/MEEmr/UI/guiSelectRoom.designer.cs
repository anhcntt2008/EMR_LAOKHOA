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
    partial class guiSelectRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiSelectRoom));
            DevExpress.XtraEditors.TableLayout.ItemTemplateBase itemTemplateBase1 = new DevExpress.XtraEditors.TableLayout.ItemTemplateBase();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition3 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement1 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lbcRoomList = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.lbcRoomList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(221, 564);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 31);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK (Alt+O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(315, 564);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbcRoomList
            // 
            this.lbcRoomList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbcRoomList.ItemHeight = 48;
            this.lbcRoomList.Location = new System.Drawing.Point(12, 12);
            this.lbcRoomList.Name = "lbcRoomList";
            this.lbcRoomList.Size = new System.Drawing.Size(379, 546);
            this.lbcRoomList.TabIndex = 9;
            tableColumnDefinition1.Length.Value = 14D;
            tableColumnDefinition2.Length.Value = 441D;
            tableColumnDefinition3.Length.Value = 17D;
            itemTemplateBase1.Columns.Add(tableColumnDefinition1);
            itemTemplateBase1.Columns.Add(tableColumnDefinition2);
            itemTemplateBase1.Columns.Add(tableColumnDefinition3);
            templatedItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            templatedItemElement1.Appearance.Normal.Options.UseFont = true;
            templatedItemElement1.ColumnIndex = 1;
            templatedItemElement1.FieldName = "DisplayMember";
            templatedItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement1.RowIndex = 1;
            templatedItemElement1.Text = "DisplayMember";
            templatedItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            itemTemplateBase1.Elements.Add(templatedItemElement1);
            itemTemplateBase1.Name = "template1";
            tableRowDefinition1.Length.Value = 13D;
            tableRowDefinition2.Length.Value = 18D;
            tableRowDefinition3.Length.Value = 13D;
            itemTemplateBase1.Rows.Add(tableRowDefinition1);
            itemTemplateBase1.Rows.Add(tableRowDefinition2);
            itemTemplateBase1.Rows.Add(tableRowDefinition3);
            this.lbcRoomList.Templates.Add(itemTemplateBase1);
            this.lbcRoomList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbcRoomList_MouseDoubleClick);
            // 
            // guiSelectRoom
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(403, 600);
            this.ControlBox = true;
            this.Controls.Add(this.lbcRoomList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiSelectRoom";
            this.Text = "Chọn phòng";
            this.Load += new System.EventHandler(this.Form_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DSMEEMR106_KeyPress);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DSMEEMR106_PreviewKeyDown);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lbcRoomList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lbcRoomList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.ListBoxControl lbcRoomList;
    }
}
