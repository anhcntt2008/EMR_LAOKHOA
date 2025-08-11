using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BOSLib;
using BOSCommon;

namespace BOSERP.Modules.CompanyConstant
{
    public class CompanyConstantEntities : ERPModuleEntities
    {
        #region Constants
        #endregion

        #region Variables        
        /// <summary>
        /// A variable to store the company info
        /// </summary>
        private CSCompanysInfo Company;
        #endregion

        #region Public Properties
        public BOSList<GENumberingInfo> GENumberingsList { get; set; }

        public BOSList<ARPriceLevelsInfo> ARPriceLevelsList { get; set; }

        public BOSList<GEVATsInfo> GEVATsList { get; set; }

        public BOSList<ICMeasureUnitsInfo> ICMeasureUnitsList { get; set; }

        public BOSList<HRTimeSheetParamsInfo> HRTimeSheetParamList { get; set; }

        public BOSList<HRWorkingShiftsInfo> HRWorkingShiftList { get; set; }

        public BOSList<MEHospitalRanksInfo> MEHospitalRankList { get; set; }

        public BOSList<HROTFactorsInfo> HROTFactorList { get; set; }

        public BOSList<HRTimesheetConfigsInfo> HRTimesheetConfigList { get; set; }
        public BOSList<HRTimesheetGroupsInfo> HRTimesheetGroupList { get; set; }
        public BOSList<HRTimesheetEmployeeLatesInfo> HRTimesheetEmployeeLateList { get; set; }

        /// <summary>
        /// Gets or sets the company bank list
        /// </summary>
        public BOSList<CSCompanyBanksInfo> CSCompanyBankList { get; set; }

        /// <summary>
        /// Gets or sets customer type config values
        /// </summary>
        public BOSList<ADConfigValuesInfo> CustomerTypeList { get; set; }

        /// <summary>
        /// Gets or sets customer title type config values
        /// </summary>
        public BOSList<ADConfigValuesInfo> CustomerTitleTypeList { get; set; }

        /// <summary>
        /// Gets or sets product type config values
        /// </summary>
        public BOSList<ADConfigValuesInfo> ProductTypeList { get; set; }
        /// <summary>
        /// Gets or sets product origin config values
        /// </summary>
        public BOSList<ICProductOriginsInfo> ProductOriginList { get; set; }
        /// <summary>
        /// Gets or sets product status config values
        /// </summary>
        public BOSList<ADConfigValuesInfo> ProductStatusList { get; set; }

        /// <summary>
        /// Gets or sets the list of available payment methods
        /// </summary>
        public BOSList<ADConfigValuesInfo> PaymentMethodList { get; set; }

        /// <summary>
        /// Gets or sets the list of receipt voucher types
        /// </summary>
        public BOSList<ADConfigValuesInfo> ReceiptVoucherTypeList { get; set; }

        /// <summary>
        /// Gets or sets the list of payment voucher types
        /// </summary>
        public BOSList<ADConfigValuesInfo> PaymentVoucherTypeList { get; set; }

        public BOSList<ADConfigValuesInfo> EmployeeSalaryTypeList { get; set; }

        public BOSList<ADMatchCodesInfo> MedicationRouteList { get; set; }
        public BOSList<ADMatchCodesInfo> MedicationFrequenceList { get; set; }

        public BOSList<ADConfigValuesInfo> ConfigValuesList { get; set; }
        public BOSList<ADSystemConfigsInfo> CaConfigsList { get; set; }
        public BOSList<ADConfigValuesInfo> ReportDataCourceConfigValuesList { get; set; }
        public BOSList<ADConfigValuesInfo> ReportTypeConfigValuesList { get; set; }

        public BOSList<ADSystemConfigsInfo> SystemConfigsList { get; set; }

        public BOSList<MEEmrDocumentsInfo> MEEmrDocumentsList { get; set; }
        #endregion

        #region Constructor
        public CompanyConstantEntities()
            : base()
        {
            CSCompanysController objCompanysController = new CSCompanysController();
            Company = (CSCompanysInfo)objCompanysController.GetFirstObject();
            if (Company == null)
            {
                Company = new CSCompanysInfo();
            }

            GENumberingsList = new BOSList<GENumberingInfo>();
            ARPriceLevelsList = new BOSList<ARPriceLevelsInfo>();
            GEVATsList = new BOSList<GEVATsInfo>();
            ICMeasureUnitsList = new BOSList<ICMeasureUnitsInfo>();
            HRTimeSheetParamList = new BOSList<HRTimeSheetParamsInfo>();
            HRWorkingShiftList = new BOSList<HRWorkingShiftsInfo>();
            MEHospitalRankList = new BOSList<MEHospitalRanksInfo>();
            HROTFactorList = new BOSList<HROTFactorsInfo>();
            CSCompanyBankList = new BOSList<CSCompanyBanksInfo>();

            CustomerTypeList = new BOSList<ADConfigValuesInfo>();
            CustomerTitleTypeList = new BOSList<ADConfigValuesInfo>();
            ProductTypeList = new BOSList<ADConfigValuesInfo>();
            ProductOriginList = new BOSList<ICProductOriginsInfo>();
            ProductStatusList = new BOSList<ADConfigValuesInfo>();
            PaymentMethodList = new BOSList<ADConfigValuesInfo>();
            ReceiptVoucherTypeList = new BOSList<ADConfigValuesInfo>();
            PaymentVoucherTypeList = new BOSList<ADConfigValuesInfo>();
            EmployeeSalaryTypeList = new BOSList<ADConfigValuesInfo>();
            HRTimesheetGroupList = new BOSList<HRTimesheetGroupsInfo>();
            HRTimesheetConfigList = new BOSList<HRTimesheetConfigsInfo>();
            HRTimesheetEmployeeLateList = new BOSList<HRTimesheetEmployeeLatesInfo>();
            MedicationFrequenceList = new BOSList<ADMatchCodesInfo>();
            MedicationRouteList = new BOSList<ADMatchCodesInfo>();

            ConfigValuesList = new BOSList<ADConfigValuesInfo>();
            ReportDataCourceConfigValuesList = new BOSList<ADConfigValuesInfo>();
            ReportTypeConfigValuesList = new BOSList<ADConfigValuesInfo>();

            CaConfigsList = new BOSList<ADSystemConfigsInfo>();
            SystemConfigsList = new BOSList<ADSystemConfigsInfo>();
        }
        #endregion

        public override void InitModuleEntity()
        {
            base.InitModuleEntity();

            UpdateModuleObjectBindingSource(TableName.CSCompanysTableName);
            InitDataToModuleObjectList();
        }

        #region Init Main Object,Module Objects functions
        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.CSCompanysTableName, Company);
            ModuleObjects.Add(TableName.HRTimeSheetParamsTableName, new HRTimeSheetParamsInfo());
            ModuleObjects.Add(TableName.HRWorkingShiftsTableName, new HRWorkingShiftsInfo());
            ModuleObjects.Add(TableName.ICProductOriginsTableName, new ICProductOriginsInfo());
        }

        public override void InvalidateModuleObjects(int iObjectID)
        {
            HRTimeSheetParamList.Clear();
            HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();
            DataSet ds = objTimeSheetParamsController.GetAllObjects();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                HRTimeSheetParamsInfo objTimeSheetParamsInfo = new HRTimeSheetParamsInfo();
                objTimeSheetParamsInfo = (HRTimeSheetParamsInfo)objTimeSheetParamsController.GetObjectFromDataRow(row);
                objTimeSheetParamsInfo.HRTimeSheetParamValue2 = objTimeSheetParamsInfo.HRTimeSheetParamValue2 * 100;
                HRTimeSheetParamList.Add(objTimeSheetParamsInfo);
            }
        }

        public override void InitModuleObjectList()
        {
            GENumberingsList.InitBOSList(this, String.Empty, BOSUtil.GetTableNameFromBusinessObjectType(typeof(GENumberingInfo)));
            ARPriceLevelsList.InitBOSList(this, String.Empty, BOSUtil.GetTableNameFromBusinessObjectType(typeof(ARPriceLevelsInfo)));
            GEVATsList.InitBOSList(this, String.Empty, BOSUtil.GetTableNameFromBusinessObjectType(typeof(GEVATsInfo)));
            ICMeasureUnitsList.InitBOSList(this, String.Empty, BOSUtil.GetTableNameFromBusinessObjectType(typeof(ICMeasureUnitsInfo)));
            HRTimeSheetParamList.InitBOSList(
                                             this,
                                             String.Empty,
                                             TableName.HRTimeSheetParamsTableName,
                                             BOSList<HRTimeSheetParamsInfo>.cstRelationNone);
            HRWorkingShiftList.InitBOSList(
                                            this,
                                            String.Empty,
                                            TableName.HRWorkingShiftsTableName,
                                            BOSList<HRWorkingShiftsInfo>.cstRelationNone);

            MEHospitalRankList.InitBOSList(
                                            this,
                                            String.Empty,
                                            TableName.MEHospitalRanksTableName,
                                            BOSList<MEHospitalRanksInfo>.cstRelationNone);
            HROTFactorList.InitBOSList(
                                        this,
                                        String.Empty,
                                        TableName.HROTFactorsTableName,
                                        BOSList<HROTFactorsInfo>.cstRelationNone);

            CSCompanyBankList.InitBOSList(this,
                                          String.Empty,
                                          TableName.CSCompanyBanksTable,
                                          BOSList<CSCompanyBanksInfo>.cstRelationNone);

            CustomerTypeList.InitBOSList(this,
                                            String.Empty,
                                            TableName.ADConfigValuesTableName,
                                            BOSList<ADConfigValuesInfo>.cstRelationNone);
            CustomerTitleTypeList.InitBOSList(this,
                                            String.Empty,
                                            TableName.ADConfigValuesTableName,
                                            BOSList<ADConfigValuesInfo>.cstRelationNone);
            ProductTypeList.InitBOSList(this,
                                            String.Empty,
                                            TableName.ADConfigValuesTableName,
                                            BOSList<ADConfigValuesInfo>.cstRelationNone);
            ProductOriginList.InitBOSList(this,
                                            String.Empty,
                                            TableName.ICProductOriginsTableName,
                                            BOSList<ICProductOriginsInfo>.cstRelationNone);
            ProductStatusList.InitBOSList(this,
                                            String.Empty,
                                            TableName.ADConfigValuesTableName,
                                            BOSList<ADConfigValuesInfo>.cstRelationNone);
            PaymentMethodList.InitBOSList(this, string.Empty, TableName.ADConfigValuesTableName,
                                            BOSList<ADConfigValuesInfo>.cstRelationNone);

            EmployeeSalaryTypeList.InitBOSList(this, string.Empty, TableName.ADConfigValuesTableName,
                                            BOSList<ADConfigValuesInfo>.cstRelationNone);

            ReceiptVoucherTypeList.InitBOSList(this, string.Empty, TableName.ADConfigValuesTableName);

            PaymentVoucherTypeList.InitBOSList(this, string.Empty, TableName.ADConfigValuesTableName);

            HRTimesheetConfigList.InitBOSList(this,
                                            String.Empty,
                                            TableName.HRTimesheetConfigsTableName,
                                            BOSList<HRTimesheetConfigsInfo>.cstRelationNone);

            HRTimesheetGroupList.InitBOSList(this,
                                            String.Empty,
                                            TableName.HRTimesheetGroupsTableName,
                                            BOSList<HRTimesheetGroupsInfo>.cstRelationNone);
            HRTimesheetEmployeeLateList.InitBOSList(this,
                                            String.Empty,
                                            TableName.HRTimesheetEmployeeLatesTableName,
                                            BOSList<HRTimesheetEmployeeLatesInfo>.cstRelationNone);
            MedicationRouteList.InitBOSList(this,
                                            String.Empty,
                                            TableName.ADMatchCodesTableName,
                                            BOSList<ADMatchCodesInfo>.cstRelationNone);
            MedicationFrequenceList.InitBOSList(this,
                                            String.Empty,
                                            TableName.ADMatchCodesTableName,
                                            BOSList<ADMatchCodesInfo>.cstRelationNone);

            ConfigValuesList.InitBOSList(this,
                                        String.Empty,
                                        TableName.ADConfigValuesTableName,
                                        BOSList<ADConfigValuesInfo>.cstRelationNone);

            ReportDataCourceConfigValuesList.InitBOSList(this,
                                       String.Empty,
                                       TableName.ADConfigValuesTableName,
                                       BOSList<ADConfigValuesInfo>.cstRelationNone);
            ReportTypeConfigValuesList.InitBOSList(this,
                                      String.Empty,
                                      TableName.ADConfigValuesTableName,
                                      BOSList<ADConfigValuesInfo>.cstRelationNone);

            CaConfigsList.InitBOSList(this,
                                     String.Empty,
                                     TableName.ADSystemConfigsTableName,
                                     BOSList<ADSystemConfigsInfo>.cstRelationNone);

            SystemConfigsList.InitBOSList(this,
                                    String.Empty,
                                    TableName.ADSystemConfigsTableName,
                                    BOSList<ADSystemConfigsInfo>.cstRelationNone);
        }

        public override void InitGridControlInBOSList()
        {
            GENumberingsList.InitBOSListGridControl();
            ARPriceLevelsList.InitBOSListGridControl(CompanyConstantModule.cstPriceLevelGridControl);
            GEVATsList.InitBOSListGridControl(CompanyConstantModule.cstTaxPercentTypeGridControl);
            HRTimeSheetParamList.InitBOSListGridControl();
            HRWorkingShiftList.InitBOSListGridControl();
            MEHospitalRankList.InitBOSListGridControl();
            HROTFactorList.InitBOSListGridControl();
            ICMeasureUnitsList.InitBOSListGridControl();
            CSCompanyBankList.InitBOSListGridControl();

            CustomerTypeList.InitBOSListGridControl(CompanyConstantModule.cstCustomerTypeGridControl);
            CustomerTitleTypeList.InitBOSListGridControl(CompanyConstantModule.cstCustomerTitleTypeGridControl);
            ProductTypeList.InitBOSListGridControl(CompanyConstantModule.cstProductTypeGridControl);
            ProductOriginList.InitBOSListGridControl();
            ProductStatusList.InitBOSListGridControl(CompanyConstantModule.cstProductStatusGridControl);
            ReceiptVoucherTypeList.InitBOSListGridControl(CompanyConstantModule.ReceiptVoucherTypeGridControlName);
            PaymentVoucherTypeList.InitBOSListGridControl(CompanyConstantModule.PaymentVoucherTypeGridControlName);
            EmployeeSalaryTypeList.InitBOSListGridControl(CompanyConstantModule.SalaryTypeGridControlName);
            HRTimesheetGroupList.InitBOSListGridControl();
            HRTimesheetConfigList.InitBOSListGridControl();
            HRTimesheetEmployeeLateList.InitBOSListGridControl();

            MedicationFrequenceList.InitBOSListGridControl(CompanyConstantModule.MedicationFrequenceGridControlName);
            MedicationRouteList.InitBOSListGridControl(CompanyConstantModule.MedicationRouteGridControlName);

            ConfigValuesList.InitBOSListGridControl(CompanyConstantModule.ConfigValuesGridControlName);

            ReportDataCourceConfigValuesList.InitBOSListGridControl(CompanyConstantModule.ReportDataSourceConfigValuesGridControlName);
            ReportTypeConfigValuesList.InitBOSListGridControl(CompanyConstantModule.ReportTypeConfigValuesGridControlName);

            CaConfigsList.InitBOSListGridControl(CompanyConstantModule.CaConfigsGridControlName);

            SystemConfigsList.InitBOSListGridControl("fld_dgcSystemConfigs");
        }
        #endregion

        public void InitDataToModuleObjectList()
        {
            GENumberingController objNumberingController = new GENumberingController();
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], START
            //DataSet ds = objNumberingController.GetAllObjects();
            //GENumberingsList.Invalidate(ds);
            DataSet dsCommonNumbering = objNumberingController.GetNumberingListByBranchID_2(0);
            DataSet ds = objNumberingController.GetNumberingListByBranchID_2(BOSApp.CurrentCompanyInfo.FK_BRBranchID);
            ds.Merge(dsCommonNumbering, true);
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], END
            STModuleDescriptionsController objModuleDescsController = new STModuleDescriptionsController();
            foreach (GENumberingInfo objNumberingsInfo in GENumberingsList)
            {
                STModuleDescriptionsInfo objModuleDescsInfo = objModuleDescsController.GetModuleDescriptionByModuleNameAndLanguageName(objNumberingsInfo.GENumberingName, BOSApp.CurrentLang);
                if (objModuleDescsInfo != null)
                    objNumberingsInfo.GENumberingDesc = objModuleDescsInfo.STModuleDescriptionDescription;
            }

            ARPriceLevelsController objPriceLevelsController = new ARPriceLevelsController();
            ds = objPriceLevelsController.GetAllObjects();
            ARPriceLevelsList.Invalidate(ds);

            GEVATsController objVATsController = new GEVATsController();
            ds = objVATsController.GetAllObjects();
            GEVATsList.Invalidate(ds);

            ICMeasureUnitsController objMeasureUnitsController = new ICMeasureUnitsController();
            ds = objMeasureUnitsController.GetAllObjects();
            ICMeasureUnitsList.Invalidate(ds);
            /*
            HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();
            ds = objTimeSheetParamsController.GetAllObjects();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                HRTimeSheetParamsInfo objTimeSheetParamsInfo = new HRTimeSheetParamsInfo();
                objTimeSheetParamsInfo = (HRTimeSheetParamsInfo)objTimeSheetParamsController.GetObjectFromDataRow(row);
                objTimeSheetParamsInfo.HRTimeSheetParamValue2 = objTimeSheetParamsInfo.HRTimeSheetParamValue2 * 100;
                HRTimeSheetParamList.Add(objTimeSheetParamsInfo);
            }

            HRWorkingShiftsController objWorkingShiftsController = new HRWorkingShiftsController();
            ds = objWorkingShiftsController.GetAllObjects();
            HRWorkingShiftList.Invalidate(ds);

            MEHospitalRanksController objHospitalRanksController = new MEHospitalRanksController();
            ds = objHospitalRanksController.GetAllObjects();
            MEHospitalRankList.Invalidate(ds);

            HROTFactorsController objOTFactorsController = new HROTFactorsController();
            ds = objOTFactorsController.GetAllObjects();
            HROTFactorList.Invalidate(ds);
            */
            ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
            ds = objConfigValuesController.GetADConfigValuesByGroup(ConfigValueGroup.CustomerType.ToString());
            CustomerTypeList.Invalidate(ds);

            ds = objConfigValuesController.GetADConfigValuesByGroup(ConfigValueGroup.CustomerTitleType.ToString());
            CustomerTitleTypeList.Invalidate(ds);

            ds = objConfigValuesController.GetADConfigValuesByGroup(ConfigValueGroup.ProductType.ToString());
            ProductTypeList.Invalidate(ds);

            ICProductOriginsController objProductOriginsController = new ICProductOriginsController();
            ds = objProductOriginsController.GetAllObjects();
            ProductOriginList.Invalidate(ds);

            ds = objConfigValuesController.GetADConfigValuesByGroup(ConfigValueGroup.ProductStatus.ToString());
            ProductStatusList.Invalidate(ds);

            ds = objConfigValuesController.GetADConfigValuesByGroup(ConfigValueGroup.PaymentMethod.ToString());
            PaymentMethodList.Invalidate(ds);

            CSCompanyBanksController objCompanyBanksController = new CSCompanyBanksController();
            ds = objCompanyBanksController.GetAllDataByForeignColumn("FK_CSCompanyID", Company.CSCompanyID);
            CSCompanyBankList.Invalidate(ds);

            ds = objConfigValuesController.GetADConfigValuesByGroup(ConfigValueGroup.ReceiptVoucherType.ToString());
            ReceiptVoucherTypeList.Invalidate(ds);

            ds = objConfigValuesController.GetADConfigValuesByGroup(ConfigValueGroup.PaymentVoucherType.ToString());
            PaymentVoucherTypeList.Invalidate(ds);

            ds = objConfigValuesController.GetADConfigValuesByGroup(ConfigValueGroup.EmployeePayrollFormulaSalaryType.ToString());
            EmployeeSalaryTypeList.Invalidate(ds);
            /*
            HRTimesheetGroupsController objTimesheetGroupsController = new HRTimesheetGroupsController();
            ds = objTimesheetGroupsController.GetAllObjects();
            HRTimesheetGroupList.Invalidate(ds);

            HRTimesheetEmployeeLatesController objTimesheetEmployeeLatesController = new HRTimesheetEmployeeLatesController();
            ds = objTimesheetEmployeeLatesController.GetAllObjects();
            HRTimesheetEmployeeLateList.Invalidate(ds);

            InvalidateStaff();
            */
            ADMatchCodesController matchCodeController = new ADMatchCodesController();
            ds = matchCodeController.GetMatchCodesByColumnName(MatchCodeMedicine.MEMedicationItemMatchCodeFrequence.ToString());
            MedicationFrequenceList.Invalidate(ds);

            ds = matchCodeController.GetMatchCodesByColumnName(MatchCodeMedicine.MEMedicationItemMatchCodeRoute.ToString());
            MedicationRouteList.Invalidate(ds);
        }

        public void InvalidateStaff()
        {
            HRTimesheetConfigsController objTimesheetConfigsController = new HRTimesheetConfigsController();
            List<HRTimesheetConfigsInfo> list = objTimesheetConfigsController.GetTimesheetConfigList();
            HRTimesheetConfigList.Invalidate(list);
        }

        /// <summary>
        /// Save working time config 
        /// </summary>
        /// <param name="daysPerMonth"></param>
        /// <param name="hoursPerDay"></param>
        public void SaveWorkingTimeConfig(string daysPerMonth, string hoursPerDay, string taxableWage)
        {
            ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
            ADConfigValuesInfo objConfigValuesInfo = new ADConfigValuesInfo();
            objConfigValuesInfo = (ADConfigValuesInfo)objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.DaysPerMonth.ToString());
            objConfigValuesInfo.ADConfigKeyValue = daysPerMonth;
            objConfigValuesController.UpdateObject(objConfigValuesInfo);

            objConfigValuesInfo = (ADConfigValuesInfo)objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.HoursPerDay.ToString());
            objConfigValuesInfo.ADConfigKeyValue = hoursPerDay;
            objConfigValuesController.UpdateObject(objConfigValuesInfo);

            objConfigValuesInfo = (ADConfigValuesInfo)objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.TaxableWage.ToString());
            if (objConfigValuesInfo != null)
            {
                objConfigValuesInfo.ADConfigKeyValue = taxableWage;
                objConfigValuesController.UpdateObject(objConfigValuesInfo);
            }
        }
        /// <summary>
        /// Save leave days config
        /// </summary>
        /// <param name="annualLeaveDays"></param>
        /// <param name="sickLeaveDays"></param>
        /// <param name="birthLeaveDays"></param>
        /// <param name="otLeaveDays"></param>
        public void SaveLeaveDaysConfig(string annualLeaveDays, string sickLeaveDays, string birthLeaveDays, string otLeaveDays, string normalLeaveDays)
        {
            ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
            ADConfigValuesInfo objConfigValuesInfo = new ADConfigValuesInfo();
            objConfigValuesInfo = (ADConfigValuesInfo)objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.AnnualLeaveDays.ToString());
            objConfigValuesInfo.ADConfigKeyValue = annualLeaveDays;
            objConfigValuesController.UpdateObject(objConfigValuesInfo);

            objConfigValuesInfo = (ADConfigValuesInfo)objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.SickLeaveDays.ToString());
            objConfigValuesInfo.ADConfigKeyValue = sickLeaveDays;
            objConfigValuesController.UpdateObject(objConfigValuesInfo);

            objConfigValuesInfo = (ADConfigValuesInfo)objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.BirthLeaveDays.ToString());
            objConfigValuesInfo.ADConfigKeyValue = birthLeaveDays;
            objConfigValuesController.UpdateObject(objConfigValuesInfo);

            objConfigValuesInfo = (ADConfigValuesInfo)objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.OTLeaveDays.ToString());
            objConfigValuesInfo.ADConfigKeyValue = otLeaveDays;
            objConfigValuesController.UpdateObject(objConfigValuesInfo);

            objConfigValuesInfo = (ADConfigValuesInfo)objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.NormalLeaveDays.ToString());
            objConfigValuesInfo.ADConfigKeyValue = normalLeaveDays;
            objConfigValuesController.UpdateObject(objConfigValuesInfo);
        }


        /// <summary>
        /// Save company bank list
        /// </summary>
        public void SaveCompanyBankList()
        {
            foreach (CSCompanyBanksInfo objCompanyBanksInfo in CSCompanyBankList)
            {
                objCompanyBanksInfo.FK_CSCompanyID = Company.CSCompanyID;
            }
            CSCompanyBankList.SaveItemObjects();
        }
    }
}
