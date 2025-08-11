using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace BOSERP.Modules.SellStaff.UI
{
	/// <summary>
	/// Summary description for DMSS109
	/// </summary>
	public partial class DMSS109 : BOSERPScreen
	{
        int PreStateProvinceSelected = 0;
        int PreDisctrictSelected = 0;
        int PreCountrySelected = 0;
		public DMSS109()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}

        private void fld_btnAddContactPerson_Click(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).AddItemToContactPersonList();
        }

        private void fld_btnEditContactPerson_Click(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).ChangeSelectedItemFromContactPersonList();
        }

        private void fld_btnDeleteContactPerson_Click(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).RemoveSelectedItemFromContactPersonList();
        }

        private void fld_lkeFK_GECountryID1_EditValueChanged(object sender, EventArgs e)
        {
            if (fld_lkeFK_GECountryID1.EditValue != null && fld_lkeFK_GECountryID1.EditValue.ToString() == "-1")
            {
                int result = ((SellStaffModule)Module).CreateNewCountryList();
                fld_lkeFK_GECountryID1.Properties.DataSource = ((SellStaffModule)Module).CountryList;
                if (result >= 0)
                    fld_lkeFK_GECountryID1.EditValue = result;
                else
                    fld_lkeFK_GECountryID1.EditValue = PreCountrySelected;

            }
            if (fld_lkeFK_GECountryID1.EditValue != null && string.IsNullOrEmpty(fld_lkeFK_GECountryID1.EditValue.ToString()))
                return;
            List<GEStateProvincesInfo> provincesList = ((SellStaffModule)Module).GetProvinceListByCountry(int.Parse(fld_lkeFK_GECountryID1.EditValue.ToString()));
            if (provincesList != null)
            {
                fld_lkeFK_GEStateProvinceID1.Properties.DataSource = provincesList;
            }
        }

        private void fld_lkeFK_GECountryID1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (fld_lkeFK_GECountryID1.EditValue != null)
                PreCountrySelected = int.Parse(fld_lkeFK_GECountryID1.EditValue.ToString());
        
        }

        private void fld_lkeFK_GEStateProvinceID1_EditValueChanged(object sender, EventArgs e)
        {
            if (fld_lkeFK_GEStateProvinceID1.EditValue != null && fld_lkeFK_GEStateProvinceID1.EditValue.ToString() == "-1")
            {
                int result = ((SellStaffModule)Module).CreateNewSateProvinceList();
                fld_lkeFK_GEStateProvinceID1.Properties.DataSource = ((SellStaffModule)Module).ProvinceList;
                if (result >= 0)
                    fld_lkeFK_GEStateProvinceID1.EditValue = result;
                else
                    fld_lkeFK_GEStateProvinceID1.EditValue = PreStateProvinceSelected;
            }
            if (fld_lkeFK_GEStateProvinceID1.EditValue != null && string.IsNullOrEmpty(fld_lkeFK_GEStateProvinceID1.EditValue.ToString()))
                return;
            List<GEDistrictsInfo> districtsList = ((SellStaffModule)Module).GetDistrictListByStateProvinceID(int.Parse(fld_lkeFK_GEStateProvinceID1.EditValue.ToString()));
            if (districtsList != null)
            {
                fld_lkeFK_GEDistrictID1.Properties.DataSource = districtsList;
            } 
                        
        }

        private void fld_lkeFK_GEStateProvinceID1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (fld_lkeFK_GEStateProvinceID1.EditValue != null)
                PreStateProvinceSelected = int.Parse(fld_lkeFK_GEStateProvinceID1.EditValue.ToString());
        
        }

        private void fld_lkeFK_GEDistrictID1_EditValueChanged(object sender, EventArgs e)
        {
             if (fld_lkeFK_GEDistrictID1.EditValue != null && fld_lkeFK_GEDistrictID1.EditValue.ToString()=="-1")
            {
                int result = ((SellStaffModule)Module).CreateNewDistrictList();
                fld_lkeFK_GEDistrictID1.Properties.DataSource = ((SellStaffModule)Module).GetDistrictListByStateProvinceID(int.Parse(fld_lkeFK_GEStateProvinceID1.EditValue.ToString()));
                if (result >= 0)
                    fld_lkeFK_GEDistrictID1.EditValue = result;
                else
                    fld_lkeFK_GEDistrictID1.EditValue = PreDisctrictSelected;
            }
            
        }

        private void fld_lkeFK_GEDistrictID1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (fld_lkeFK_GEDistrictID1 != null )
               PreDisctrictSelected = int.Parse(fld_lkeFK_GEDistrictID1.EditValue.ToString());
        }

	}
}
