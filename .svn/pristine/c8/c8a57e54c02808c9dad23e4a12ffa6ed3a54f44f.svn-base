using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;
using Localization;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using BOSCommon;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BOSERP.Modules.SellStaff.UI
{
	/// <summary>
	/// Summary description for DMST100
	/// </summary>
	public partial class DMST100 : BOSERPScreen
	{
		public DMST100()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
        }
    
        private void fld_lkeFK_HRLevelID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            BOSLookupEdit lke = (BOSLookupEdit)sender;
            if (e.Value != null && lke.OldEditValue != e.Value)
            {
                ((SellStaffModule)Module).ChangeLevel(Convert.ToInt32(e.Value));
            }
        }
        
        private void fld_lkeFK_GENativeStateProvinceID_EditValueChanged(object sender, EventArgs e)
        {
            if (fld_lkeFK_GENativeStateProvinceID.EditValue != null && fld_lkeFK_GENativeStateProvinceID.EditValue.ToString() == "-1")
            {
                int result = ((SellStaffModule)Module).CreateNewSateProvinceList();
                fld_lkeFK_GENativeStateProvinceID.Properties.DataSource = ((SellStaffModule)Module).ProvinceList;
                if (result >= 0)
                    fld_lkeFK_GENativeStateProvinceID.EditValue = result;
                else
                    fld_lkeFK_GENativeStateProvinceID.EditValue = ((SellStaffModule)Module).PreNativeStateProvinceSelected;
            }
        }

        private void fld_lkeFK_GENativeStateProvinceID_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
        }

        private void fld_lkeFK_GEIDCardStateProvinceID_EditValueChanged(object sender, EventArgs e)
        {
            if (fld_lkeFK_GEIDCardStateProvinceID.EditValue != null && fld_lkeFK_GEIDCardStateProvinceID.EditValue.ToString() == "-1")
            {
        int result = ((SellStaffModule)Module).CreateNewSateProvinceList();
                fld_lkeFK_GEIDCardStateProvinceID.Properties.DataSource = ((SellStaffModule)Module).ProvinceList;
                if (result >= 0)
                    fld_lkeFK_GEIDCardStateProvinceID.EditValue = result;
                else
                    fld_lkeFK_GEIDCardStateProvinceID.EditValue = ((SellStaffModule)Module).PreIDCardStateProvinceSelected;
            }
        }

        private void fld_lkeFK_GEIDCardStateProvinceID_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (fld_lkeFK_GEIDCardStateProvinceID.EditValue != null)
                ((SellStaffModule)Module).PreIDCardStateProvinceSelected = int.Parse(fld_lkeFK_GEIDCardStateProvinceID.EditValue.ToString());
        }

        private void fld_lkeFK_GENationalityID_EditValueChanged(object sender, EventArgs e)
        {
            if (fld_lkeFK_GENationalityID.EditValue != null && fld_lkeFK_GENationalityID.EditValue.ToString() == "-1")
            {

                guiAddNationality guiAddNationality = new guiAddNationality();
                if (guiAddNationality.ShowDialog() == DialogResult.OK)
                {
                    GENationalitysController objGENationalitysController = new GENationalitysController();
                    GENationalitysInfo newGENationalitysInfo = new GENationalitysInfo();
                    newGENationalitysInfo = (GENationalitysInfo)objGENationalitysController.GetObjectByName(guiAddNationality.fld_txtAttributeName.Text);
                    if (newGENationalitysInfo != null && newGENationalitysInfo.GENationalityName != "")
                    {
                        MessageBox.Show(SellStaffLocalizedResource.NationalityNameMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        newGENationalitysInfo = (GENationalitysInfo)objGENationalitysController.GetObjectByCode(guiAddNationality.fld_txtAttributeCode.Text);
                        if (newGENationalitysInfo != null && newGENationalitysInfo.GENationalityCode != "")
                        {
                            MessageBox.Show(SellStaffLocalizedResource.NationalityCodeMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            newGENationalitysInfo = new GENationalitysInfo();
                            newGENationalitysInfo.GENationalityCode = guiAddNationality.fld_txtAttributeCode.Text;
                            newGENationalitysInfo.GENationalityName = guiAddNationality.fld_txtAttributeName.Text;
                            objGENationalitysController.CreateObject(newGENationalitysInfo);
                            ((SellStaffModule)Module).RefeshNatinalityList(guiAddNationality.fld_txtAttributeName.Text);
                        }

                    }
                }
                else
                {
                    fld_lkeFK_GENationalityID.EditValue = ((SellStaffModule)Module).PreNationalitySelected;
                }
            }
        }

        private void fld_lkeFK_GENationalityID_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (fld_lkeFK_GENationalityID.EditValue != null)
                ((SellStaffModule)Module).PreNationalitySelected = int.Parse(fld_lkeFK_GENationalityID.EditValue.ToString());
   
        }

        private void fld_lkeFK_GEReligionID_EditValueChanged(object sender, EventArgs e)
        {
            if (fld_lkeFK_GEReligionID.EditValue != null && fld_lkeFK_GEReligionID.EditValue.ToString() == "-1")
            {

                guiAddReligion guiAddReligion = new guiAddReligion();
                if (guiAddReligion.ShowDialog() == DialogResult.OK)
                {
                    GEReligionsController objGEReligionsController = new GEReligionsController();
                    GEReligionsInfo newGEReligionsInfo = new GEReligionsInfo();
                    newGEReligionsInfo = (GEReligionsInfo)objGEReligionsController.GetObjectByName(guiAddReligion.fld_txtAttributeName.Text);
                    if (newGEReligionsInfo != null && newGEReligionsInfo.GEReligionName != "")
                    {
                        MessageBox.Show(SellStaffLocalizedResource.ReligionNameMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        newGEReligionsInfo = new GEReligionsInfo();
                        newGEReligionsInfo.GEReligionName = guiAddReligion.fld_txtAttributeName.Text;
                        objGEReligionsController.CreateObject(newGEReligionsInfo);
                        ((SellStaffModule)Module).RefeshReligionList(guiAddReligion.fld_txtAttributeName.Text);
                    }
                }
                else
                {
                    fld_lkeFK_GEReligionID.EditValue = ((SellStaffModule)Module).PreReligionSelected;
                }
            }
        }

        private void fld_lkeFK_GEReligionID_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (fld_lkeFK_GEReligionID.EditValue != null)
                ((SellStaffModule)Module).PreReligionSelected = int.Parse(fld_lkeFK_GEReligionID.EditValue.ToString());
        }

        private void fld_lkeFK_HRDepartmentID_Validated(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).InvalidateDepartmentRoom(Convert.ToInt32(fld_lkeFK_HRDepartmentID.EditValue.ToString()));
        }

        private void fld_lkeHREmployeeStateID_EditValueChanged(object sender, EventArgs e)
        {
            if (fld_lkeHREmployeeStateID.EditValue != null && fld_lkeHREmployeeStateID.EditValue.ToString() == "-2")
            {
                HREmployeeStatesController objHREmployeeStatesController = new HREmployeeStatesController();
                DataSet ds = objHREmployeeStatesController.GetAllObjects();
                guiAddEmployeeState guiAddEmployeeState = new guiAddEmployeeState(ds);
                if (guiAddEmployeeState.ShowDialog() == DialogResult.OK)
                {
                    HREmployeeStatesInfo newHREmployeeStatesInfo = new HREmployeeStatesInfo();
                    if (guiAddEmployeeState._hrEmployeeStateID == 0)
                    {
                        newHREmployeeStatesInfo = new HREmployeeStatesInfo();
                        newHREmployeeStatesInfo.HREmployeeStateCode = guiAddEmployeeState.fld_txtAttributeCode.Text;
                        newHREmployeeStatesInfo.HREmployeeStateName = guiAddEmployeeState.fld_txtAttributeName.Text;
                        objHREmployeeStatesController.CreateObject(newHREmployeeStatesInfo);
                        ((SellStaffModule)Module).RefeshHREmployeeStateList(guiAddEmployeeState.fld_txtAttributeName.Text);
                    }
                    else
                    {
                        newHREmployeeStatesInfo = new HREmployeeStatesInfo();
                        newHREmployeeStatesInfo.HREmployeeStateID = guiAddEmployeeState._hrEmployeeStateID;
                        newHREmployeeStatesInfo.HREmployeeStateCode = guiAddEmployeeState.fld_txtAttributeCode.Text;
                        newHREmployeeStatesInfo.HREmployeeStateName = guiAddEmployeeState.fld_txtAttributeName.Text;
                        objHREmployeeStatesController.UpdateObject(newHREmployeeStatesInfo);
                        ((SellStaffModule)Module).RefeshHREmployeeStateList(guiAddEmployeeState.fld_txtAttributeName.Text);
                    }
                }
                else
                {
                    fld_lkeHREmployeeStateID.EditValue = ((SellStaffModule)Module).PreEmployeeStateSelected;
                }
            }
        }

        private void fld_lkeHREmployeeStateID_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (fld_lkeHREmployeeStateID.EditValue != null)
                ((SellStaffModule)Module).PreEmployeeStateSelected = int.Parse(fld_lkeHREmployeeStateID.EditValue.ToString());
        }

        private void fld_btnAddDepartment_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)this.fld_dgcHRDepartments.MainView;
            List<int> hrDepartmentIDList = new List<int>();
            if (gridView.GetSelectedRows().Count() == 0)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (int rowidx in gridView.GetSelectedRows())
            {
                HRDepartmentsInfo hrDepartmentsInfo = new HRDepartmentsInfo();
                hrDepartmentsInfo = gridView.GetRow(rowidx) as HRDepartmentsInfo;
                hrDepartmentIDList.Add(hrDepartmentsInfo.HRDepartmentID);
                ((SellStaffModule)Module).AddDepartmentToEmployee(hrDepartmentsInfo);
            }
            foreach (int id in hrDepartmentIDList)
            {
                ((SellStaffModule)Module).RemoveDepartmentList(id);
            }
            gridView.ClearSelection();
            ((SellStaffModule)Module).RefreshDataSource_GridControl();
        }

        private void fld_btnRemoveDepartment_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)this.fld_dgcHREmpWorkingDepts.MainView;
            List<int> fk_HRDepartmentIDList = new List<int>();
            if (gridView.GetSelectedRows().Count() == 0)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (int rowidx in gridView.GetSelectedRows())
            {
                HREmpWorkingDeptsInfo hrDepartmentsInfo = new HREmpWorkingDeptsInfo();
                hrDepartmentsInfo = gridView.GetRow(rowidx) as HREmpWorkingDeptsInfo;
                fk_HRDepartmentIDList.Add(hrDepartmentsInfo.FK_HRDepartmentID);
            }
            foreach (int id in fk_HRDepartmentIDList)
            {
                ((SellStaffModule)Module).RemoveDepartmentFromEmployee(id);
            }
            gridView.ClearSelection();
            ((SellStaffModule)Module).RefreshDataSource_GridControl();
            ((SellStaffModule)Module).InvalidateDepartmentList();
        }

        private void fld_dgcHRDepartments_DoubleClick(object sender, EventArgs e)
        {
            GridView gridView = (GridView)this.fld_dgcHRDepartments.MainView;
            Point pt = gridView.GridControl.PointToClient(Control.MousePosition);
            if (DoRowDoubleClick(gridView, pt))
            {
                ((SellStaffModule)Module).ValidateState();
                int rowidx = gridView.FocusedRowHandle;
                if (rowidx > -1)
                {
                    HRDepartmentsInfo hrDepartmentsInfo = new HRDepartmentsInfo();
                    hrDepartmentsInfo = gridView.GetRow(rowidx) as HRDepartmentsInfo;
                    ((SellStaffModule)Module).AddDepartmentToEmployee(hrDepartmentsInfo);
                    ((SellStaffModule)Module).RemoveDepartmentList(hrDepartmentsInfo.HRDepartmentID);
                    gridView.ClearSelection();
                    ((SellStaffModule)Module).RefreshDataSource_GridControl();
                }
            }
        }
        private static bool DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                return true;
            }
            return false;
        }
    }

}
