using System;
using System.Collections.Generic;
using System.Text;
using BOSCommon;
using Clas.Model.Doctor24x7;

namespace BOSERP.Modules.Common
{
    public class CommonEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables

        #endregion
        #region Public Properties
        public BOSList<MEPatientsInfo> MEPatientList { get; set; }
        public BOSList<MEPatientAppointmentsInfo> MEPatientAppointmentsList { get; set; }

        public List<Checkup> CheckupBs24x7 { get; set; }

        #endregion

        #region Constructor
        public CommonEntities()
            : base()
        {
            MEPatientList = new BOSList<MEPatientsInfo>();
            MEPatientAppointmentsList = new BOSList<MEPatientAppointmentsInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new MEPatientVisitsInfo();
        }

        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.MEPatientsTableName, new MEPatientsInfo());
            ModuleObjects.Add(TableName.MEPatientAppointmentsTableName, new MEPatientAppointmentsInfo());
        }

        public override void InitModuleObjectList()
        {
            MEPatientList.InitBOSList(
                                       this,
                                       string.Empty,
                                       TableName.MEPatientsTableName,
                                       BOSList<MEPatientsInfo>.cstRelationNone);
            MEPatientAppointmentsList.InitBOSList(
                                           this,
                                           TableName.MEPatientsTableName,
                                           TableName.MEPatientAppointmentsTableName,
                                           BOSList<MEPatientAppointmentsInfo>.cstRelationForeign);
            MEPatientAppointmentsList.ItemTableForeignKey = "FK_MEPatientID";
        }

        public override void InitGridControlInBOSList()
        {

        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {

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

        }
        #endregion

        #region Save Module Objects functions
        public override void SaveModuleObjects()
        {

        }
        #endregion
    }
}
