using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Localization;

namespace BOSERP
{
    public partial class guiEditPrice : Form
    {
        public BOSList<ICProductPricesInfo> ICProductPricesList = new BOSList<ICProductPricesInfo>();
        public int ProductID;

        public guiEditPrice()
        {
            InitializeComponent();
        }

        public guiEditPrice(int productID, BOSList<ICProductPricesInfo> listICProductPricesInfo)
        {
            InitializeComponent();

            this.ProductID = productID;
            this.ICProductPricesList = listICProductPricesInfo;
        }

        /// <summary>
        /// Load Edit Price form.
        /// </summary>
        private void guiEditPrice_Load(object sender, EventArgs e)
        {
            int xLable = 20;
            int xTextbox = 150;
            int y = 30;

            //paint label and textbox 
            ARPriceLevelsController objPriceLevelsController = new ARPriceLevelsController();
            foreach (ICProductPricesInfo objProductPricesInfo in ICProductPricesList)
            {
                if (objProductPricesInfo.FK_ARPriceLevelID > 1)
                {
                    ARPriceLevelsInfo objPriceLevelsInfo = (ARPriceLevelsInfo)objPriceLevelsController.GetObjectByID(objProductPricesInfo.FK_ARPriceLevelID);
                    if (objPriceLevelsInfo != null)
                    {
                        DevExpress.XtraEditors.LabelControl label = new DevExpress.XtraEditors.LabelControl();
                        label.Location = new Point(xLable, y);
                        label.Text = objPriceLevelsInfo.ARPriceLevelName;
                        this.fld_pnlEditPrice.Controls.Add(label);

                        DevExpress.XtraEditors.TextEdit textBox = new DevExpress.XtraEditors.TextEdit();
                        textBox.Properties.Mask.EditMask = "n2";
                        textBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textBox.Properties.Mask.UseMaskAsDisplayFormat = true;
                        textBox.Location = new Point(xTextbox, y - 3);
                        textBox.Name = objPriceLevelsInfo.ARPriceLevelID.ToString();
                        textBox.Text = objProductPricesInfo.ICProductPriceMarkDown.ToString();
                        this.fld_pnlEditPrice.Controls.Add(textBox);

                        label = new DevExpress.XtraEditors.LabelControl();
                        label.Text = "%";
                        label.Location = new Point(xTextbox + 100, y);
                        this.fld_pnlEditPrice.Controls.Add(label);

                        y = y + 30;
                    }
                }
            }
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            //save all of edition of user into ICProductPricesList
            foreach (Control ctr in fld_pnlEditPrice.Controls)
            {
                if(ctr.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
                {
                    DevExpress.XtraEditors.TextEdit textBox = (DevExpress.XtraEditors.TextEdit)ctr;
                    double markDown = Convert.ToDouble(textBox.Text);
                    if (markDown < 0 || markDown > 100)
                    {
                        MessageBox.Show("Markdown must be between 0 and 100", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    foreach (ICProductPricesInfo objProductPricesInfo in ICProductPricesList)
                    {
                        if (objProductPricesInfo.FK_ARPriceLevelID == Convert.ToInt32(textBox.Name))
                            objProductPricesInfo.ICProductPriceMarkDown = Convert.ToDouble(textBox.Text);
                    }                
                }             
            }
            this.Close();
        }         
    }
}
