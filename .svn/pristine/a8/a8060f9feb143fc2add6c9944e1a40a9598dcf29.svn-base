using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSCommon;
using BOSLib;
using Localization;

namespace BOSERP
{
    public partial class guiPaymentCurrency : BOSERPScreen
    {
        #region Variables
        /// <summary>
        /// A variable to store the passed-in payment detail
        /// </summary>
        private ARCustomerPaymentDetailsInfo CustomerPaymentDetail;        
        #endregion

        public guiPaymentCurrency()
        {
            InitializeComponent();
        }

        public guiPaymentCurrency(ARCustomerPaymentDetailsInfo objCustomerPaymentDetailsInfo)
        {
            InitializeComponent();

            CustomerPaymentDetail = objCustomerPaymentDetailsInfo;            
        }

        private void guiPaymentCurrency_Load(object sender, EventArgs e)
        {
            InitializeControls(Controls);

            if (CustomerPaymentDetail.PaymentCurrencys == null)
            {
                CustomerPaymentDetail.PaymentCurrencys = new BOSList<ARCustomerPaymentCurrencysInfo>();
                CustomerPaymentDetail.PaymentCurrencys.InitBOSList(((BaseModuleERP)Module).CurrentModuleEntity, string.Empty, TableName.ARCustomerPaymentCurrencysTableName);
                if (CustomerPaymentDetail.ARCustomerPaymentDetailID > 0)
                {
                    ARCustomerPaymentCurrencysController objCustomerPaymentCurrencysController = new ARCustomerPaymentCurrencysController();
                    DataSet ds = objCustomerPaymentCurrencysController.GetAllDataByForeignColumn("FK_ARCustomerPaymentDetailID", CustomerPaymentDetail.ARCustomerPaymentDetailID);
                    (CustomerPaymentDetail.PaymentCurrencys as BOSList<ARCustomerPaymentCurrencysInfo>).Invalidate(ds);
                }
            }

            //Get default currency details of the payment
            if (CustomerPaymentDetail.PaymentCurrencys.Count == 0)
            {
                GECurrenciesController objCurrencyController = new GECurrenciesController();
                DataSet ds = objCurrencyController.GetAllObjects();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    GECurrenciesInfo objCurrencyInfo = (GECurrenciesInfo)objCurrencyController.GetObjectFromDataRow(row);
                    ARCustomerPaymentCurrencysInfo objCustomerPaymentCurrencysInfo = new ARCustomerPaymentCurrencysInfo();
                    objCustomerPaymentCurrencysInfo.FK_GECurrencyID = objCurrencyInfo.GECurrencyID;
                    CustomerPaymentDetail.PaymentCurrencys.Add(objCustomerPaymentCurrencysInfo);
                }
            }

            ERPModuleEntities entity = (ERPModuleEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            BOSDbUtil dbUtil = new BOSDbUtil();
            int currencyID = dbUtil.GetPropertyIntValue(entity.MainObject, "FK_GECurrencyID");
            fld_dgcCustomerPaymentCurrency.DocumentCurrencyID = currencyID;
            fld_dgcCustomerPaymentCurrency.PaymentAmount = CustomerPaymentDetail.ARCustomerPaymentDetailAmount;
            fld_dgcCustomerPaymentCurrency.InitExchangeWayColumn();
            fld_dgcCustomerPaymentCurrency.InitGridControlDataSource(CustomerPaymentDetail.PaymentCurrencys);
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {            
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            int count = CustomerPaymentDetail.PaymentCurrencys.Where(p => p.ARCustomerPaymentCurrencyAmount > 0).Count();
            if (count > 1)
            {
                MessageBox.Show(CommonLocalizedResources.CannotPayWithMultipleCurrencyMessage,
                                CommonLocalizedResources.MessageBoxDefaultCaption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            
            BackupPaymentCurrency();
            DialogResult = DialogResult.OK;
            Close();
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

        /// <summary>
        /// Back up currency details of payments
        /// </summary>
        private void BackupPaymentCurrency()
        {
            CustomerPaymentDetail.PaymentCurrencys.BackupList.Clear();
            foreach (ARCustomerPaymentCurrencysInfo objCustomerPaymentCurrencysInfo in CustomerPaymentDetail.PaymentCurrencys)
            {
                CustomerPaymentDetail.PaymentCurrencys.BackupList.Add((ARCustomerPaymentCurrencysInfo)objCustomerPaymentCurrencysInfo.Clone());
            }
        }

        /// <summary>
        /// Rollback currency details of payments
        /// </summary>
        private void RollbackPaymentCurrency()
        {
            CustomerPaymentDetail.PaymentCurrencys.Clear();
            foreach (ARCustomerPaymentCurrencysInfo objCustomerPaymentCurrencysInfo in CustomerPaymentDetail.PaymentCurrencys.BackupList)
            {
                CustomerPaymentDetail.PaymentCurrencys.Add((ARCustomerPaymentCurrencysInfo)objCustomerPaymentCurrencysInfo.Clone());
            }
        }

        private void guiPaymentCurrency_FormClosed(object sender, FormClosedEventArgs e)
        {
            RollbackPaymentCurrency();            
        }
    }
}
