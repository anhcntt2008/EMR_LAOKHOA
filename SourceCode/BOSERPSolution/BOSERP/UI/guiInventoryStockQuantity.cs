using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSCommon;
using BOSComponent;
using BOSLib;
using DevExpress.XtraGrid.Views.Grid;
using Localization;

namespace BOSERP
{
    public partial class guiInventoryStockQuantity : BOSERPScreen
    {
        public InventoryStockQuantityGridControl InventoryStockQuantityGridControl
        {
            get { return fld_dgcInventoryStocks; }
        }
        public guiInventoryStockQuantity()
        {
            InitializeComponent();
        }

        private void guiInventoryStockQuantity_Load(object sender, EventArgs e)
        {
            fld_dgcInventoryStocks.Screen = this;
            fld_dgcInventoryStocks.InitializeControl();
            (fld_dgcInventoryStocks.MainView as GridView).ExpandAllGroups();

            List<ICInventoryStocksInfo> inventoryStocks = (List<ICInventoryStocksInfo>)fld_dgcInventoryStocks.DataSource;
            double onHandQty = inventoryStocks.Where(i => i.InventoryType == InventoryType.OnHand.ToString())
                                                .Sum(i => i.ICInventoryStockQuantity);
            double saleOrderQty = inventoryStocks.Where(i => i.InventoryType == InventoryType.SaleOrder.ToString())
                                                .Sum(i => i.ICInventoryStockQuantity);
            double availableQty = onHandQty - saleOrderQty;
            double purchaseOrderQty = inventoryStocks.Where(i => i.InventoryType == InventoryType.PurchaseOrder.ToString())
                                                .Sum(i => i.ICInventoryStockQuantity);
            double transitInQty = inventoryStocks.Where(i => i.InventoryType == InventoryType.TransitIn.ToString())
                                                .Sum(i => i.ICInventoryStockQuantity);
            double transitOutQty = inventoryStocks.Where(i => i.InventoryType == InventoryType.TransitOut.ToString())
                                                .Sum(i => i.ICInventoryStockQuantity);
            fld_lblOnHandQty.Text = BOSUtil.GetNumberDisplayFormat(onHandQty, FormatGroupAttribute.cstFormatGroupQty);
            fld_lblSOQty.Text = BOSUtil.GetNumberDisplayFormat(saleOrderQty, FormatGroupAttribute.cstFormatGroupQty);
            fld_lblAvailableQty.Text = BOSUtil.GetNumberDisplayFormat(availableQty, FormatGroupAttribute.cstFormatGroupQty);
            fld_lblPOQty.Text = BOSUtil.GetNumberDisplayFormat(purchaseOrderQty, FormatGroupAttribute.cstFormatGroupQty);
            fld_lblTransitInQty.Text = BOSUtil.GetNumberDisplayFormat(transitInQty, FormatGroupAttribute.cstFormatGroupQty);
            fld_lblTransitOutQty.Text = BOSUtil.GetNumberDisplayFormat(transitOutQty, FormatGroupAttribute.cstFormatGroupQty);

            foreach (ICInventoryStocksInfo inventoryStock in inventoryStocks)
            {
                if (inventoryStock.InventoryType == InventoryType.OnHand.ToString())
                {
                    inventoryStock.InventoryType = ReportLocalizedResources.OnHandQuantity;
                }
                else if (inventoryStock.InventoryType == InventoryType.SaleOrder.ToString())
                {
                    inventoryStock.InventoryType = ReportLocalizedResources.SaleOrderQuantity;
                }
                else if (inventoryStock.InventoryType == InventoryType.PurchaseOrder.ToString())
                {
                    inventoryStock.InventoryType = ReportLocalizedResources.PurchaseOrderQuantity;
                }
                else if (inventoryStock.InventoryType == InventoryType.TransitIn.ToString())
                {
                    inventoryStock.InventoryType = ReportLocalizedResources.TransitInQuantity;
                }
                else if (inventoryStock.InventoryType == InventoryType.TransitOut.ToString())
                {
                    inventoryStock.InventoryType = ReportLocalizedResources.TransitOutQuantity;
                }
            }            
        }

        private void fld_btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }        
    }
}
