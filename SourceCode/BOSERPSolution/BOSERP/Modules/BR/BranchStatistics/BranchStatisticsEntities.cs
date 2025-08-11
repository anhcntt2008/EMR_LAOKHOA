using System;
using System.Collections.Generic;
using System.Text;
using BOSCommon;
using BOSLib;

namespace BOSERP.Modules.BranchStatistics
{
    public class BranchStatisticsEntities : ERPModuleEntities
    {
        #region Variables    
        private BOSList<ARSaleOrdersInfo> lstARSaleOrders;
        #endregion

        #region Properties    
        public BOSList<ARSaleOrdersInfo> ARSaleOrdersList
        {
            get
            {
                return lstARSaleOrders;
            }
            set
            {
                lstARSaleOrders = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of owing invoices that will be taken from customer
        /// </summary>
        public BOSList<ARInvoicesInfo> AROwingInvoiceList { get; set; }

        /// <summary>
        /// Gets or sets the list of owing invoices that will be paid to supplier
        /// </summary>
        public BOSList<APInvoiceInsInfo> APOwingInvoiceInList { get; set; }
        #endregion

        #region Constructors
        public BranchStatisticsEntities()
            : base()
        {
            lstARSaleOrders = new BOSList<ARSaleOrdersInfo>();
            AROwingInvoiceList = new BOSList<ARInvoicesInfo>();
            APOwingInvoiceInList = new BOSList<APInvoiceInsInfo>();
        }
        #endregion

        #region Initalize Module list
        public override void InitModuleObjectList()
        {            
            lstARSaleOrders.InitBOSList(this, String.Empty, BOSUtil.GetTableNameFromBusinessObjectType(typeof(ARSaleOrdersInfo)));
            AROwingInvoiceList.InitBOSList(
                                            this,
                                            string.Empty,
                                            TableName.ARInvoicesTableName,
                                            BOSList<ARInvoicesInfo>.cstRelationNone);
            APOwingInvoiceInList.InitBOSList(
                                            this,
                                            string.Empty,
                                            TableName.APInvoiceInsTableName,
                                            BOSList<APInvoiceInsInfo>.cstRelationNone);                                            
        }
        #endregion

        #region Initalize GridControl
        public override void InitGridControlInBOSList()
        {           
            lstARSaleOrders.InitBOSListGridControl("fld_dgcARSaleOrders");
            AROwingInvoiceList.InitBOSListGridControl(BranchStatisticsModule.AROwingInvoicesGridControlName);
            APOwingInvoiceInList.InitBOSListGridControl(BranchStatisticsModule.APOwingInvoiceInsGridControlName);
        }

        public override void SetDefaultModuleObjectsList()
        {            
            lstARSaleOrders.SetDefaultListAndRefreshGridControl();
        }
        #endregion
    }
}
