using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using BOSCommon;
using BOSLib;

namespace BOSERP.Modules.MEPatient
{
    public class MEPatientEntities : ERPModuleEntities
    {
        private MEPatientsController _patientsController;
        #region Declare Constant
        #endregion
        
        #region Declare all entities variables
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets patient relatives list
        /// </summary>
        public BOSList<MEPatientRelativesInfo> MEPatientRelativeList { get; set; }

        public BOSList<MEPatientVisitsInfo> MEPatientVisitList { get; set; }

        public BOSList<MEPatientsInfo> MEPatientList { get; set; }

        public BOSList<ARInvoiceItemsInfo> ARInvoiceItemList { get; set; }

        public BOSList<MEPatientAppointmentsInfo> MEPatientAppointmentsList { get; set; }

        public BOSList<MEPatientInssInfo> MEPatientInssList { get; set; }

        /// <summary>
        /// Gets or sets the visit list of an employee
        /// </summary>
        public BOSList<MEPatientVisitsInfo> EmployeeVisitList { get; set; }

        /// <summary>
        /// Gets or sets the list of updated appointments, is used to update the associated visits
        /// </summary>
        public BOSList<MEPatientAppointmentsInfo> UpdatedAppointments { get; set; }

        /// <summary>
        /// Gets or sets the list of deleted appointments, is used to delete the associated visits
        /// </summary>
        public BOSList<MEPatientAppointmentsInfo> DeletedAppointments { get; set; }


        /// <summary>
        /// Gets or sets the visit order item list of an employee
        /// </summary>
        public BOSList<MEVisitOrderItemsInfo> MEVisitOrderItemList { get; set; }
        #endregion

        #region Constructor
        public MEPatientEntities()
            : base()
        {
            MEPatientRelativeList = new BOSList<MEPatientRelativesInfo>();
            MEPatientVisitList = new BOSList<MEPatientVisitsInfo>();
            MEPatientList = new BOSList<MEPatientsInfo>();
            ARInvoiceItemList = new BOSList<ARInvoiceItemsInfo>();
            MEPatientAppointmentsList = new BOSList<MEPatientAppointmentsInfo>();
            MEPatientInssList = new BOSList<MEPatientInssInfo>();
            EmployeeVisitList = new BOSList<MEPatientVisitsInfo>();
            UpdatedAppointments = new BOSList<MEPatientAppointmentsInfo>();
            DeletedAppointments = new BOSList<MEPatientAppointmentsInfo>();
            MEVisitOrderItemList = new BOSList<MEVisitOrderItemsInfo>();
            _patientsController = new MEPatientsController();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new MEPatientsInfo();
            SearchObject = new MEPatientsInfo();
        }

        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.MEPatientRelativesTableName, new MEPatientRelativesInfo());
            ModuleObjects.Add(TableName.MEPatientVisitsTableName, new MEPatientVisitsInfo());
            ModuleObjects.Add(TableName.ARInvoiceItemsTableName, new ARInvoiceItemsInfo());
            ModuleObjects.Add(TableName.MEPatientAppointmentsTableName, new MEPatientAppointmentsInfo());
            ModuleObjects.Add(TableName.MEPatientInssTableName, new MEPatientInssInfo());
            ModuleObjects.Add(TableName.MECHBaseTable, new MECHBasesInfo());
        }

        public override void InitModuleObjectList()
        {
            MEPatientRelativeList.InitBOSList(
                                            this,
                                            TableName.MEPatientsTableName,
                                            TableName.MEPatientRelativesTableName,
                                            BOSList<MEPatientRelativesInfo>.cstRelationForeign);
            MEPatientRelativeList.ItemTableForeignKey = "FK_MEPatientID";

            MEPatientVisitList.InitBOSList(
                                            this,
                                            TableName.MEPatientsTableName,
                                            TableName.MEPatientVisitsTableName,
                                            BOSList<MEPatientVisitsInfo>.cstRelationForeign);
            MEPatientVisitList.ItemTableForeignKey = "FK_MEPatientID";

            MEPatientList.InitBOSList(
                                this,
                                string.Empty,
                                TableName.MEPatientsTableName,
                                BOSList<MEVisitOrderItemsInfo>.cstRelationNone);

            ARInvoiceItemList.InitBOSList(
                                            this,
                                            string.Empty,
                                            TableName.ARInvoiceItemsTableName,
                                            BOSList<ARInvoiceItemsInfo>.cstRelationNone);

            MEPatientAppointmentsList.InitBOSList(
                                           this,
                                           TableName.MEPatientsTableName,
                                           TableName.MEPatientAppointmentsTableName,
                                           BOSList<MEPatientAppointmentsInfo>.cstRelationForeign);
            MEPatientAppointmentsList.ItemTableForeignKey = "FK_MEPatientID";

            MEPatientInssList.InitBOSList(
                                            this,
                                            TableName.MEPatientsTableName,
                                            TableName.MEPatientInssTableName,
                                            BOSList<MEPatientInssInfo>.cstRelationForeign);
            MEPatientInssList.ItemTableForeignKey = "FK_MEPatientID";

            EmployeeVisitList.InitBOSList(
                                            this,
                                            string.Empty,
                                            TableName.MEPatientVisitsTableName,
                                            BOSList<MEPatientVisitsInfo>.cstRelationNone);
            MEVisitOrderItemList.InitBOSList(
                                            this,
                                            string.Empty,
                                            TableName.MEVisitOrderItemsTableName,
                                            BOSList<MEVisitOrderItemsInfo>.cstRelationNone);
        }

        public override void InitGridControlInBOSList()
        {
            MEPatientRelativeList.InitBOSListGridControl();
            MEPatientVisitList.InitBOSListGridControl();
            MEPatientList.InitBOSListGridControl();
            ARInvoiceItemList.InitBOSListGridControl();
            MEPatientInssList.InitBOSListGridControl();
            MEVisitOrderItemList.InitBOSListGridControl();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                MEPatientRelativeList.SetDefaultListAndRefreshGridControl();
                MEPatientVisitList.SetDefaultListAndRefreshGridControl();
                MEPatientList.SetDefaultListAndRefreshGridControl();
                ARInvoiceItemList.SetDefaultListAndRefreshGridControl();
                
                MEPatientInssList.SetDefaultListAndRefreshGridControl();
                MEVisitOrderItemList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        #region Invalidate Module Objects functions
        public override void InvalidateMainObject(int iObjectID)
        {
            base.InvalidateMainObject(iObjectID);
        }

        public override void InvalidateModuleObjects(int iObjectID)
        {
            MEPatientRelativeList.Invalidate(iObjectID);

            MEPatientInssList.Invalidate(iObjectID);

            MEPatientsController objPatientsController = new MEPatientsController();
            DataSet ds;
            //= objPatientsController.GetVisitHistory(iObjectID);

            //MEPatientVisitList.Invalidate(ds);

            //MEVisitOrderItemsController objVisitOrderItemsController = new MEVisitOrderItemsController();
            //ds = objVisitOrderItemsController.GetVisitOrderItemsByPatientID(iObjectID);
            //MEVisitOrderItemList.Invalidate(ds);

            //uthv comment ko dung nua cho emr
            //ds = objPatientsController.GetServiceHistory(iObjectID);
            //ARInvoiceItemList.Invalidate(ds);

            //Get location name
            MEPatientsInfo objPatientsInfo = (MEPatientsInfo)MainObject;
            GELocationsController objLocationsController = new GELocationsController();
            objPatientsInfo.GELocationName = objLocationsController.GetFullLocationNameByID(objPatientsInfo.FK_GELocationID);
            UpdateMainObjectBindingSource();
            SetPropertyChangeEventLock(true);
        }
        #endregion

        #region Save Module Objects functions
        public override int SaveMainObject()
        {
            
            MEPatientsInfo objPatientsInfo = (MEPatientsInfo)MainObject;
            objPatientsInfo.MEPatientContactAddressLine2 = BOSUtil.GenerateFullAddress(MainObject, AddressType.Contact.ToString());
            objPatientsInfo.MEPatientContactAddressLine2 = objPatientsInfo.MEPatientContactAddressLine1 + ", " + objPatientsInfo.GELocationName;

            if (objPatientsInfo.FK_MEOccupationID == -1)
            {
                objPatientsInfo.FK_MEOccupationID = 0;
            }

            if (objPatientsInfo.FK_MEEthnicID == -1)
            {
                objPatientsInfo.FK_MEEthnicID = 0;
            }
            
            //Update the associated customer
            ARCustomersController objCustomersController = new ARCustomersController();
            if (objPatientsInfo.MEPatientID == 0)
            {
                string mainObjectNo = string.Empty;
                int numberingStart = 0;
                mainObjectNo = BOSApp.GetMainObjectNo(ModuleName.MEPatient, "MEPatients",ref numberingStart);
                //mainObjectNo = mainObjectNo + ConfigPatientNo.PatientSuffixNo.ToString();
                objPatientsInfo.MEPatientNo = mainObjectNo;
                ARCustomersInfo objCustomersInfo = new ARCustomersInfo();

                objPatientsInfo.MEPatientContactAddressLine2 = objPatientsInfo.MEPatientContactAddressLine1 + ", " + objPatientsInfo.GELocationName;
                objPatientsInfo.MEPatientContactAddressLine3 = objPatientsInfo.MEPatientContactAddressLine2;

                BOSUtil.CopyObject(objPatientsInfo, objCustomersInfo);
                if (objPatientsInfo.MEPatientNo == MEPatientEntities.cstNewObjectText)
                {
                    objCustomersInfo.ARCustomerNo = GetMainObjectNo();
                }
                objCustomersInfo.AACreatedDate = DateTime.Now;
                objCustomersInfo.AACreatedUser = BOSApp.CurrentUser;
                objCustomersInfo.ARCustomerTypeCombo = CustomerType.Patient.ToString();
                objCustomersInfo.FK_BRBranchID = 1;
                objCustomersInfo.ARCustomerContactBirthday = objPatientsInfo.MEPatientBirthday;
                objCustomersInfo.ARCustomerContactEmail1 = objPatientsInfo.MEPatientContactEmail;
                objCustomersController.CreateObject(objCustomersInfo);
                //objPatientsInfo.MEPatientID = objCustomersInfo.ARCustomerID;

                UpdateObjectNumbering(numberingStart);
            }
            else
            {
                objPatientsInfo.MEPatientContactAddressLine2 = objPatientsInfo.MEPatientContactAddressLine1 + ", " + objPatientsInfo.GELocationName;
                objPatientsInfo.MEPatientContactAddressLine3 = objPatientsInfo.MEPatientContactAddressLine2;
               
                ARCustomersInfo objCustomersInfo = (ARCustomersInfo)objCustomersController.GetObjectByID(objPatientsInfo.MEPatientID);
                if (objCustomersInfo != null)
                {
                    BOSUtil.CopyObject(objPatientsInfo, objCustomersInfo);
                    objCustomersInfo.AAUpdatedDate = DateTime.Now;
                    objCustomersInfo.AAUpdatedUser = BOSApp.CurrentUser;
                    objCustomersInfo.ARCustomerTypeCombo = CustomerType.Patient.ToString();
                    objCustomersInfo.ARCustomerContactBirthday = objPatientsInfo.MEPatientBirthday;
                    objCustomersInfo.ARCustomerContactEmail1 = objPatientsInfo.MEPatientContactEmail;
                    objCustomersController.UpdateObject(objCustomersInfo);
                }
            }

            return base.SaveMainObject();
        }
        public override void SaveModuleObjects()
        {
            MEPatientRelativeList.SaveItemObjects();                        
            MEPatientInssList.SaveItemObjects();

            //Create new visits from new appointments
            MEPatientsInfo objPatientsInfo = (MEPatientsInfo)MainObject;
            MEPatientAppointmentsController objPatientAppointmentsController = new MEPatientAppointmentsController();
            MEPatientVisitsController objPatientVisitsController = new MEPatientVisitsController();
            foreach (MEPatientAppointmentsInfo objPatientAppointmentsInfo in MEPatientAppointmentsList)
            {
                //If the appointment is new, create new associated visit
                if (objPatientAppointmentsInfo.MEPatientAppointmentID == 0)
                {
                    MEPatientVisitsInfo objPatientVisitsInfo = GenerateVisitFromAppointment(objPatientAppointmentsInfo);
                    int numberingStart = 0;
                    objPatientVisitsInfo.MEPatientVisitNo = BOSApp.GetMainObjectNo(ModuleName.MEPatientRegistration, TableName.MEPatientVisitsTableName, ref numberingStart);
                    objPatientVisitsInfo.FK_MEPatientID = objPatientsInfo.MEPatientID;
                    objPatientVisitsController.CreateObject(objPatientVisitsInfo);
                    BOSApp.UpdateObjectNumbering(ModuleName.MEPatientVisit, numberingStart);
                    //Add to visit list of the current patient
                    MEPatientVisitList.Add(objPatientVisitsInfo);
                }
            }
            //Save appointments
            MEPatientAppointmentsList.SaveItemObjects();

            //Update the associated visits of updated appointments if they are still at Reserved status
            foreach (MEPatientAppointmentsInfo objPatientAppointmentsInfo in UpdatedAppointments)
            {

                MEPatientAppointmentsInfo objUpdatedPatientAppointmentsInfo = new MEPatientAppointmentsInfo();
                objUpdatedPatientAppointmentsInfo = (MEPatientAppointmentsInfo)objPatientAppointmentsController.GetObjectByID(objPatientAppointmentsInfo.MEPatientAppointmentID);

                MEPatientVisitsInfo objExistingPatientVisitsInfo = MEPatientVisitList.Where(
                                                            v => v.FK_HREmployeeID == objPatientAppointmentsInfo.FK_HREmployeeID &&
                                                                v.MEPatientVisitCheckInTime.Date == objPatientAppointmentsInfo.MEPatientAppointmentTime.Date &&
                                                                Math.Floor(v.MEPatientVisitCheckInTime.TimeOfDay.TotalMinutes) == Math.Floor(objPatientAppointmentsInfo.MEPatientAppointmentTime.TimeOfDay.TotalMinutes)).FirstOrDefault();
                if (objExistingPatientVisitsInfo != null && objExistingPatientVisitsInfo.MEPatientVisitStatus == PatientVisitStatus.Reserved.ToString() && objUpdatedPatientAppointmentsInfo != null)
                {
                    MEPatientVisitsInfo objPatientVisitsInfo = GenerateVisitFromAppointment(objUpdatedPatientAppointmentsInfo);
                    objPatientVisitsInfo.MEPatientVisitID = objExistingPatientVisitsInfo.MEPatientVisitID;
                    objPatientVisitsInfo.MEPatientVisitNo = objExistingPatientVisitsInfo.MEPatientVisitNo;
                    objPatientVisitsController.UpdateObject(objPatientVisitsInfo);
                }
            }

            //Delete the associated visits of deleted appointments if they are still at Reserved status
            foreach (MEPatientAppointmentsInfo objPatientAppointmentsInfo in DeletedAppointments)
            {
                MEPatientVisitsInfo objExistingPatientVisitsInfo = MEPatientVisitList.Where(
                                                                v => v.FK_HREmployeeID == objPatientAppointmentsInfo.FK_HREmployeeID &&
                                                                    v.MEPatientVisitCheckInTime.Date == objPatientAppointmentsInfo.MEPatientAppointmentTime.Date &&
                                                                    Math.Floor(v.MEPatientVisitCheckInTime.TimeOfDay.TotalMinutes) == Math.Floor(objPatientAppointmentsInfo.MEPatientAppointmentTime.TimeOfDay.TotalMinutes)).FirstOrDefault();
                if (objExistingPatientVisitsInfo != null && objExistingPatientVisitsInfo.MEPatientVisitStatus == PatientVisitStatus.Reserved.ToString())
                {
                    objPatientVisitsController.DeleteObject(objExistingPatientVisitsInfo.MEPatientVisitID);
                    int index = MEPatientVisitList.PosOf("MEPatientVisitID", objExistingPatientVisitsInfo.MEPatientVisitID);
                    if (index >= 0)
                    {
                        MEPatientVisitList.RemoveAt(index);
                    }
                }
            }

            DeletedAppointments.Clear();
            UpdatedAppointments.Clear();
        }

        /// <summary>
        /// Generate a visit from an appointment
        /// </summary>
        /// <returns>Visit object</returns>
        private MEPatientVisitsInfo GenerateVisitFromAppointment(MEPatientAppointmentsInfo objPatientAppointmentsInfo)
        {
            HREmployeesInfo objEmployeesInfo = new HREmployeesInfo();
            HREmployeesController objEmployeesController = new HREmployeesController();
            MEPatientVisitsInfo objPatientVisitsInfo = new MEPatientVisitsInfo();
            objEmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(objPatientAppointmentsInfo.FK_HREmployeeID);
            objPatientVisitsInfo.MEPatientVisitDate = objPatientAppointmentsInfo.MEPatientAppointmentDate;
            objPatientVisitsInfo.MEPatientVisitCheckInTime = objPatientAppointmentsInfo.MEPatientAppointmentTime;
            objPatientVisitsInfo.MEPatientVisitLastWaitingTime = objPatientAppointmentsInfo.MEPatientAppointmentTime;
            objPatientVisitsInfo.FK_HREmployeeID = objPatientAppointmentsInfo.FK_HREmployeeID;
            objPatientVisitsInfo.FK_METimeFrameID = objPatientAppointmentsInfo.FK_METimeFrameID;
            objPatientVisitsInfo.FK_METimeFrameID1 = objPatientAppointmentsInfo.FK_METimeFrameID1;
            objPatientVisitsInfo.FK_HRStartDepartmentID = objEmployeesInfo.FK_HRDepartmentID;
            objPatientVisitsInfo.FK_HRDepartmentID = objEmployeesInfo.FK_HRDepartmentID;
            objPatientVisitsInfo.FK_HRDepartmentRoomID = objEmployeesInfo.FK_HRDepartmentRoomID;
            objPatientVisitsInfo.FK_MESpecialismID = objEmployeesInfo.FK_MESpecialismID;
            objPatientVisitsInfo.MEPatientVisitStatus = PatientVisitStatus.Reserved.ToString();
            objPatientVisitsInfo.MEPatientVisitRemark = objPatientAppointmentsInfo.MEPatientAppointmentReason;
            objPatientVisitsInfo.FK_MEPatientID = objPatientAppointmentsInfo.FK_MEPatientID;
            return objPatientVisitsInfo;
        }
        #endregion        

        public override void DeleteObjectRelations(string strTableName, int iObjectID)
        {
            base.DeleteObjectRelations(strTableName, iObjectID);

            ARCustomersController objCustomersController = new ARCustomersController();
            objCustomersController.DeleteObject(iObjectID);
        }

        public DataSet GetTop500()
        {
            return _patientsController.GetDataSet("SELECT TOP 500 * FROM MEPatients WHERE AAStatus='Alive' ORDER BY MEPatientID DESC");
        }
        
    }
}