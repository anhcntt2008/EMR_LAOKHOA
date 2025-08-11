using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Localization;

namespace BOSERP.UI.Paint
{
    public partial class SaveDialog : BOSERPScreen
    {
        private guiPaint PaintForm;
        /// <summary>
        /// Gets or sets save click value
        /// </summary>
        public bool SaveClick { get; set; }
        
        public SaveDialog()
        {
            InitializeComponent();
            SaveClick = false;
        }

        private void fld_btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PaintForm.canvas1.DrawShape.Saved)
                {
                    PaintForm.MenuSaveAs_Click(null, null);
                }
                else
                {
                    PaintForm.MenuSave_Click(null, null);
                }
            }
            catch { }
            if (SaveClick)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void fld_btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SaveDialog_Load(object sender, EventArgs e)
        {
            PaintForm = (guiPaint)this.Owner;
            if (PaintForm.Text.Equals("Untitled - Paint"))
            {
                fld_lblNoTitle.Text = CommonLocalizedResources.NewImageMessage;
            }
            else
            {
                this.Size = new Size(354, 150);
                panel1.Size = new Size(348, 78);
                fld_lblNoTitle.Location = new Point(label1.Location.X, label1.Location.Y + 20);
                if (PaintForm.saveFileDialog1.FileName != string.Empty)
                    fld_lblNoTitle.Text = string.Format("{0}?", PaintForm.saveFileDialog1.FileName);
                else fld_lblNoTitle.Text = CommonLocalizedResources.NewImageMessage;
            }
        }
    }
}
