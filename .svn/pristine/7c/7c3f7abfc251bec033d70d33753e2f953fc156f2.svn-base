using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BOSERP.UI.Paint
{
    public partial class guiResizeImage : BOSERPScreen
    {
        public guiResizeImage()
        {
            InitializeComponent();
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Tag = string.Format("{0}_{1}_{2}", fld_rdgResizeType.EditValue, 
                                                   fld_txtResizeH.Text.Trim(), 
                                                   fld_txtResizeV.Text.Trim());
            Close();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void guiResizeImage_Load(object sender, EventArgs e)
        {
            fld_txtResizeH.Text = Tag.ToString().Split('_')[0];
            fld_txtResizeV.Text = Tag.ToString().Split('_')[1];
        }
    }
}
