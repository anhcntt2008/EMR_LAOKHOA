using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSLib;

namespace BOSERP.Modules.Product
{
    public partial class guiEditPurchasePriceByCurrency : BOSERPScreen
    {
        public guiEditPurchasePriceByCurrency()
        {
            InitializeComponent();
        }

        public override void InitializeControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                InitializeControl(ctrl);
                if (ctrl.Controls.Count > 0)
                {
                    InitializeControls(ctrl.Controls);
                }
            }
        }

        private void guiEditPurchasePriceByCurrency_Load(object sender, EventArgs e)
        {
            InitializeControls(Controls);
            ProductEntities entity = (ProductEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.ProductPurchasePriceList.InitBOSListGridControl(fld_dgcEditPurchasePriceByCurrency);
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
