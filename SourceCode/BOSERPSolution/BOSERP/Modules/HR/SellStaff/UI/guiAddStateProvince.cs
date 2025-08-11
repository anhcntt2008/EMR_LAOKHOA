using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Localization;

namespace BOSERP.Modules.SellStaff
{

    public partial class guiAddStateProvince : BOSERPScreen
    {
        //private int PrevSelectedIndex = 0;
        public guiAddStateProvince()
        {
            InitializeComponent();
        }

        public guiAddStateProvince( String lblname, String lblcode,String txtname, String txtcode)
        {
            InitializeComponent();
            fld_txtName.Text = lblcode;
            fld_txtCode.Text = lblname;           
            fld_lblCode.Text = txtcode;
            fld_lblName.Text = txtname;
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fld_txtCode.Text))
            {
                MessageBox.Show(SellStaffLocalizedResource.StateProvinceNameRequiredMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void guiAttributeInput_Load(object sender, EventArgs e)
        {
            GetCountry();
            fld_txtCode.Focus();
        }
        private void GetCountry()
        {
            fld_cmbCountry.Properties.Items.Clear();
            //fld_cmbCountry.Properties.Items.Add(SellStaffLocalizedResource.AddNew);
            GECountrysController objGECountrysController = new GECountrysController();
            DataSet ds = objGECountrysController.GetAllObjects();
            //List<GECountrysInfo> GECountryList = new List<GECountrysInfo>();
            if (ds.Tables.Count > 0)
            {

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    GECountrysInfo objGECountrysInfo = (GECountrysInfo)objGECountrysController.GetObjectFromDataRow(row);
                    //GECountryList.Add(objGECountrysInfo);
                    fld_cmbCountry.Properties.Items.Add(objGECountrysInfo.GECountryName);
                }
            }
            //PrevSelectedIndex = 0;
            
        }

        
    }
}