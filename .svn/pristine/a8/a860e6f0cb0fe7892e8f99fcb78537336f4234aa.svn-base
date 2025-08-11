using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSCommon;
using BOSComponent;
using BOSLib;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace BOSERP
{
    public partial class CustomerPaymentCurrencyGridControl : BOSGridControl
    {
        /// <summary>
        /// Gets or sets the currency id of the current document
        /// </summary>
        public int DocumentCurrencyID { get; set; }

        /// <summary>
        /// Gets or sets the total amount needs to be paid
        /// </summary>
        public double PaymentAmount { get; set; }

        public override void InitializeControl()
        {
            base.InitializeControl();

            Enter += new EventHandler(CustomerPaymentCurrencyGridControl_Enter);
        }

        /// <summary>
        /// Init data source for the grid control
        /// </summary>        
        /// <param name="paymentCurrencys">Data source</param>
        public void InitGridControlDataSource(IBOSList<ARCustomerPaymentCurrencysInfo> paymentCurrencys)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = paymentCurrencys;
            DataSource = bds;

            foreach (ARCustomerPaymentCurrencysInfo objCustomerPaymentCurrencysInfo in paymentCurrencys)
            {
                if (objCustomerPaymentCurrencysInfo.FK_GECurrencyID == DocumentCurrencyID)
                {
                    if (objCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeRate == 0)
                    {
                        objCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeRate = 1;
                    }
                }

                if (string.IsNullOrEmpty(objCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeWay))
                {
                    objCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeWay = string.Format("{0}{1}", objCustomerPaymentCurrencysInfo.FK_GECurrencyID, DocumentCurrencyID);
                }
            }
            RefreshDataSource();

            DocumentCurrencyID = DocumentCurrencyID;
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();

            GridColumn column = gridView.Columns["FK_GECurrencyID"];
            if (column != null)
            {
                column.AppearanceCell.BackColor = Color.WhiteSmoke;
            }

            column = gridView.Columns["ARCustomerPaymentCurrencyAmount"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["ARCustomerPaymentCurrencyExchangeRate"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }            
            return gridView;
        }

        /// <summary>
        /// Init exchange way column. This column contains exchange
        /// ways in displayed text
        /// </summary>
        public void InitExchangeWayColumn()
        {
            GECurrenciesController objCurrencysController = new GECurrenciesController();
            GECurrenciesInfo objDocumentCurrencysInfo = null;
            if (DocumentCurrencyID > 0)
            {
                objDocumentCurrencysInfo = (GECurrenciesInfo)objCurrencysController.GetObjectByID(DocumentCurrencyID);
            }
            else
            {
                objDocumentCurrencysInfo = (GECurrenciesInfo)objCurrencysController.GetObjectByID(BOSApp.CurrentCompanyInfo.FK_GESaleCurrencyID);
            }
            if (objDocumentCurrencysInfo != null)
            {
                GridView gridView = (GridView)MainView;
                GridColumn column = gridView.Columns["ARCustomerPaymentCurrencyExchangeWay"];
                if (column != null)
                {
                    List<GECurrenciesInfo> currencys = objCurrencysController.GetAllCurrencys();
                    List<ExchangeWay> exchangeWays = new List<ExchangeWay>();
                    foreach (GECurrenciesInfo objCurrencysInfo in currencys)
                    {
                        string displayedText = string.Format("{0} --> {1}", objCurrencysInfo.GECurrencyName, objDocumentCurrencysInfo.GECurrencyName);
                        exchangeWays.Add(new ExchangeWay(string.Format("{0}{1}", objCurrencysInfo.GECurrencyID, objDocumentCurrencysInfo.GECurrencyID), displayedText));
                        if (objCurrencysInfo.GECurrencyID != DocumentCurrencyID)
                        {
                            displayedText = string.Format("{0} --> {1}", objDocumentCurrencysInfo.GECurrencyName, objCurrencysInfo.GECurrencyName);
                            exchangeWays.Add(new ExchangeWay(string.Format("{0}{1}", objDocumentCurrencysInfo.GECurrencyID, objCurrencysInfo.GECurrencyID), displayedText));
                        }
                    }

                    RepositoryItemBOSLookupEdit rep = new RepositoryItemBOSLookupEdit();
                    rep.ValueMember = "Value";
                    rep.DisplayMember = "DisplayedText";
                    rep.Columns.Add(new LookUpColumnInfo("DisplayedText"));
                    rep.DataSource = exchangeWays;
                    rep.ShowHeader = false;
                    rep.TextEditStyle = TextEditStyles.Standard;
                    column.OptionsColumn.AllowEdit = true;
                    column.ColumnEdit = rep;
                }
            }
        }

        protected override void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.GridView_CellValueChanged(sender, e);

            GridView gridView = (GridView)sender;
            if (gridView.FocusedRowHandle >= 0)
            {
                ARCustomerPaymentCurrencysInfo objCustomerPaymentCurrencysInfo = (ARCustomerPaymentCurrencysInfo)gridView.GetRow(gridView.FocusedRowHandle);
                if (objCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeWay == string.Format("{0}{1}",
                                                                                                                objCustomerPaymentCurrencysInfo.FK_GECurrencyID,
                                                                                                                DocumentCurrencyID))
                {
                    objCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeAmount = objCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyAmount *
                                                                                            objCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeRate;
                }
                else
                {
                    if (objCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeWay == string.Format("{0}{1}",
                                                                                                                DocumentCurrencyID,
                                                                                                                objCustomerPaymentCurrencysInfo.FK_GECurrencyID))
                    {
                        objCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeAmount = objCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyAmount /
                                                                                                objCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeRate;
                    }
                }

                if (e.Column.FieldName == "ARCustomerPaymentCurrencyExchangeRate")
                {
                    ProposeRemainingAmount();
                }
            }
        }

        protected override void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            base.GridView_FocusedRowChanged(sender, e);

            ProposeRemainingAmount();
        }

        private void CustomerPaymentCurrencyGridControl_Enter(object sender, EventArgs e)
        {
            ProposeRemainingAmount();
        }

        /// <summary>
        /// Propose the remaining amount
        /// </summary>
        private void ProposeRemainingAmount()
        {
            GridView gridView = (GridView)MainView;
            if (gridView.FocusedRowHandle >= 0)
            {
                List<ARCustomerPaymentCurrencysInfo> paymentCurrencys = (List<ARCustomerPaymentCurrencysInfo>)((BindingSource)DataSource).DataSource;
                ARCustomerPaymentCurrencysInfo objCurrentCustomerPaymentCurrencysInfo = (ARCustomerPaymentCurrencysInfo)gridView.GetRow(gridView.FocusedRowHandle);
                double paymentAmount = 0;
                foreach (ARCustomerPaymentCurrencysInfo objCustomerPaymentCurrencysInfo in paymentCurrencys)
                {
                    if (objCustomerPaymentCurrencysInfo.FK_GECurrencyID != objCurrentCustomerPaymentCurrencysInfo.FK_GECurrencyID)
                    {
                        paymentAmount += objCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeAmount;
                    }
                }

                if (paymentAmount < PaymentAmount)
                {
                    double dueAmount = PaymentAmount - paymentAmount;
                    if (objCurrentCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeRate > 0 && objCurrentCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyAmount == 0)
                    {
                        if (objCurrentCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeWay == string.Format("{0}{1}",
                                                                                                                    objCurrentCustomerPaymentCurrencysInfo.FK_GECurrencyID,
                                                                                                                    DocumentCurrencyID))
                        {

                            objCurrentCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyAmount = dueAmount / objCurrentCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeRate;
                            objCurrentCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeAmount = objCurrentCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyAmount *
                                                                                                                objCurrentCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeRate;
                        }
                        else
                        {
                            if (objCurrentCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeWay == string.Format("{0}{1}",
                                                                                                                    DocumentCurrencyID,
                                                                                                                    objCurrentCustomerPaymentCurrencysInfo.FK_GECurrencyID))                                                                                                                    
                            {
                                objCurrentCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyAmount = dueAmount * objCurrentCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeRate;
                                objCurrentCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeAmount = objCurrentCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyAmount /
                                                                                                                        objCurrentCustomerPaymentCurrencysInfo.ARCustomerPaymentCurrencyExchangeRate;
                            }
                        }
                        RefreshDataSource();
                    }                    
                }
            }
        }
    }
}
