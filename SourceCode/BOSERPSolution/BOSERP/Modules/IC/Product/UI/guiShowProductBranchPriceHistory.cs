using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSLib;
using BOSComponent;

namespace BOSERP.Modules.Product
{
    public partial class guiShowProductBranchPriceHistory : BOSERPScreen
    {
        /// <summary>
        /// Gets or sets product branch price grid control 
        /// </summary>
        public BOSGridControl ProductBranchPricesGridControl { get; set; }
        public guiShowProductBranchPriceHistory()
        {
            InitializeComponent();
            ProductBranchPricesGridControl = new BOSGridControl();
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

        private void guiShowProductBranchPrice_Load(object sender, EventArgs e)
        {
            InitializeControls(Controls);
            ProductEntities entity = (ProductEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.ProductBranchPriceList.InitBOSListGridControl(fld_dgcICProductBranchPricesHistory);
            ((ProductModule)Module).InvalidateProductBranchPriceHistoryWithCurrency(fld_dgcICProductBranchPricesHistory);
        }
        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
