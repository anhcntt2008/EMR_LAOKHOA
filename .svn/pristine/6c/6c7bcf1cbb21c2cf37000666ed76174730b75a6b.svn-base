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
    
    public partial class guiAddDistrict : BOSERPScreen//Form
    {
        private int CountryPrevSelectedIndex = 0;
        private int StateProvincePrevSelectedIndex = 0;
        public guiAddDistrict()
        {
            InitializeComponent();
        }

        public guiAddDistrict(String lblname, String lblcode, String txtname, String txtcode)
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
                MessageBox.Show(SellStaffLocalizedResource.DisctrictNameRequiredMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            GetCity();
            fld_txtCode.Focus();
        }
        private void GetCountry()
        {
            fld_cmbCountry.Properties.Items.Clear();
            GECountrysController objGECountrysController = new GECountrysController();
            DataSet ds = objGECountrysController.GetAllObjects();
            if (ds.Tables.Count > 0)
            {

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    GECountrysInfo objGECountrysInfo = (GECountrysInfo)objGECountrysController.GetObjectFromDataRow(row);
                    fld_cmbCountry.Properties.Items.Add(objGECountrysInfo.GECountryName);
                }
            }
            CountryPrevSelectedIndex = 0;
            
        }
         private void GetCity()
        {
            fld_cmbStateProvince.Properties.Items.Clear();
            GEStateProvincesController objGEStateProvincesController = new GEStateProvincesController();
            GECountrysController objGECountrysController = new GECountrysController();
            DataSet ds;
             if (fld_cmbCountry.SelectedIndex >= 0)
            {
                int newGECountrysInfoID;
                newGECountrysInfoID = objGECountrysController.GetObjectIDByName(fld_cmbCountry.Text);
                ds = objGEStateProvincesController.GetAllDataByForeignColumn("FK_GECountryID", newGECountrysInfoID);
                 //ds = objGEStateProvincesController.GetAllDataByForeignColumn
            }
            else {
                ds = objGEStateProvincesController.GetAllObjects();
            }
             if (ds.Tables.Count > 0)
            {

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    GEStateProvincesInfo objGEStateProvincesInfo = (GEStateProvincesInfo)objGEStateProvincesController.GetObjectFromDataRow(row);
                    fld_cmbStateProvince.Properties.Items.Add(objGEStateProvincesInfo.GEStateProvinceName);
                }
            }
             StateProvincePrevSelectedIndex = 0;
            
        }

         private void fld_cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
         {
             GetCity();
         }
        
    }
}