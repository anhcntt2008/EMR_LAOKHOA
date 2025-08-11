using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace BOSERP.Modules.ImportData
{
    public partial class 
        guiExportProduct : BOSERPScreen
    {
        public guiExportProduct()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Initialize product list
        /// </summary>
        public void InitProductList()
        {
            ICProductsController objProductsController = new ICProductsController();
            DataSet ds = objProductsController.GetProductsForExporting();
            fld_dgcExportedProducts.DataSource = ds.Tables[0];
        }

        private void guiExportProduct_Load(object sender, EventArgs e)
        {
            InitializeControls(Controls);
            InitProductList();
        }

        private void fld_btnExportExcel_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)fld_dgcExportedProducts.MainView;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files | *.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridView.ExportToXls(sfd.FileName);
            }
        }
    }
}
