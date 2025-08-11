using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace BOSERP.Modules.Product
{
    public partial class guiChooseSupplier : BOSERPScreen
    {
        public guiChooseSupplier()
        {
            InitializeComponent();
        }

        private void guiChooseSupplier_Load(object sender, EventArgs e)
        {
            fld_dgcICProductSuppliers.Screen = this;
            fld_dgcICProductSuppliers.InitializeControl();
            //Bind grid control to their list
            ProductEntities entity = (ProductEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.ICProductSuppliersList.InitBOSListGridControl(fld_dgcICProductSuppliers);
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
