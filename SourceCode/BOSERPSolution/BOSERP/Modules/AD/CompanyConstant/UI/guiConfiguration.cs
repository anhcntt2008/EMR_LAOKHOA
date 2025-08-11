using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using BOSLib;
using Localization;

namespace BOSERP.Modules.CompanyConstant.UI
{
    public partial class guiConfiguration : BOSERPScreen
    {
        private String CurrentSection;
        private ADConfigValuesController _objADConfigValueControl;
        private readonly Crypto _cryp;

        public guiConfiguration()
        {
            InitializeComponent();
            _objADConfigValueControl = new ADConfigValuesController();
            _cryp = new Crypto();
        }

        private void fld_trlSections_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            CurrentSection = e.Node.Tag.ToString();
            var entity = (CompanyConstantEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            switch (e.Node.Tag.ToString())
            {
                case "CompanyProfile":
                    DMCS100 guiCompanyProfile = new DMCS100();
                    guiCompanyProfile.ScreenNumber = "DMCS100";
                    guiCompanyProfile.Module = Module;
                    LoadScreen(guiCompanyProfile);
                    break;
                case "Customer":
                    DMCS101 guiCustomer = new DMCS101();
                    guiCustomer.ScreenNumber = "DMCS101";
                    guiCustomer.Module = Module;
                    LoadScreen(guiCustomer);
                    break;
                case "Product":
                    DMCS102 guiProduct = new DMCS102();
                    guiProduct.ScreenNumber = "DMCS102";
                    guiProduct.Module = Module;
                    LoadScreen(guiProduct);
                    break;
                case "Sale":
                    //DMCS103 guiSale = new DMCS103();
                    //guiSale.ScreenNumber = "DMCS103";
                    //guiSale.Module = Module;
                    //LoadScreen(guiSale);
                    break;
                case "HumanResource":
                    DMCS105 guiStaff = new DMCS105();
                    guiStaff.ScreenNumber = "DMCS105";
                    guiStaff.Module = Module;
                    LoadScreen(guiStaff);
                    break;
                case "Accounting":
                    DMCS104 guiAccounting = new DMCS104();
                    guiAccounting.ScreenNumber = "DMCS104";
                    guiAccounting.Module = Module;
                    LoadScreen(guiAccounting);
                    break;
                case "Stock":
                    DMCS107 guiStock = new DMCS107();
                    guiStock.ScreenNumber = "DMCS107";
                    guiStock.Module = Module;
                    LoadScreen(guiStock);
                    entity.UpdateMainObjectBindingSource();
                    break;
                case "Emr":
                    DMCS108 guiEmr = new DMCS108();
                    guiEmr.ScreenNumber = "DMCS108";
                    guiEmr.Module = Module;
                    LoadScreen(guiEmr);
                    DataSet ds = _objADConfigValueControl.GetADConfigValuesByGroups("'ApiOfHis'");
                    if (ds.Tables.Count > 0)
                    {
                        entity.ConfigValuesList.Invalidate(ds);
                    }
                    entity.UpdateMainObjectBindingSource();
                    break;
                case "Report":
                    DMCS109 guiReportConfig = new DMCS109
                    {
                        ScreenNumber = "DMCS109",
                        Module = Module
                    };
                    LoadScreen(guiReportConfig);
                    //ReportDataSource
                    var configs = _objADConfigValueControl.GetListBusinessObjects<ADConfigValuesInfo>(_objADConfigValueControl.GetADConfigValuesByGroups($"'{BOSCommon.Report.ReportDataSource}'"));
                    if (configs.Count > 0)
                    {
                        foreach (var item in configs)
                        {
                            item.ADConfigKeyDesc = _cryp.Decrypt(item.ADConfigKeyDesc);
                        }
                        entity.ReportDataCourceConfigValuesList.Invalidate(configs);
                    }
                    //ReportType
                    var types = _objADConfigValueControl.GetListBusinessObjects<ADConfigValuesInfo>(_objADConfigValueControl.GetADConfigValuesByGroups($"'{BOSCommon.Report.ReportType}'"));
                    if (types.Count > 0)
                    {
                        entity.ReportTypeConfigValuesList.Invalidate(types);
                    }
                    entity.UpdateMainObjectBindingSource();
                    break;
                case "CaConfig":
                    var gui = new DMCS110CA
                    {
                        ScreenNumber = "DMCS110CA",
                        Module = Module
                    };
                    LoadScreen(gui);
                    var company = entity.ModuleObjects[BOSCommon.TableName.CSCompanysTableName] as CSCompanysInfo;
                    (this.Module as CompanyConstantModule).LoadCaConfigByProvider(company.CSCompanyCaProvider);
                    entity.UpdateMainObjectBindingSource();
                    break;
                case "SystemConfig":
                    var guiSys = new DMCS111ST
                    {
                        ScreenNumber = "DMCS111ST",
                        Module = Module
                    };
                    LoadScreen(guiSys);
                    (this.Module as CompanyConstantModule).LoadSystemConfigs();
                    break;

            }

            ((CompanyConstantEntities)((BaseModuleERP)Module).CurrentModuleEntity).InitGridControlInBOSList();
        }
        private void LoadScreen(BOSERPScreen screen)
        {
            fld_pnlScreenContainer.Controls.Clear();
            screen.AddCustomControls(Module.Screens);
            screen.CustomizeControls(screen.Controls);
            screen.InitializeControls(screen.Controls);
            for (int i = 0; i < screen.Controls.Count; i++)
            {
                fld_pnlScreenContainer.Controls.Add(screen.Controls[i]);
                i--;
            }
        }

        private void fld_btnSave_Click(object sender, EventArgs e)
        {
            bool isSuccess = true;
            CompanyConstantModule module = (CompanyConstantModule)Module;
            switch (CurrentSection)
            {
                case "CompanyProfile":
                    isSuccess = module.SaveCompanyConfig();
                    break;
                case "Customer":
                    isSuccess = module.SaveCustomerConfig();
                    break;
                case "Product":
                    isSuccess = module.SaveProductConfig();
                    break;
                case "Sale":
                    isSuccess = module.SaveSaleConfig();
                    break;
                case "HumanResource":
                    isSuccess = module.SaveStaffConfig();
                    break;
                case "Accounting":
                    isSuccess = module.SaveAccountingConfig();
                    break;
                case "Report":
                    isSuccess = module.SaveReportConfig();
                    isSuccess = module.SaveReportType();
                    break;
                case "Stock":
                    isSuccess = module.SaveCompanyProfile();
                    break;
                case "Emr":
                    isSuccess = module.SaveCompanyProfile();
                    isSuccess = module.SaveDictionaryResult();
                    break;
                case "CaConfig":
                    isSuccess = module.SaveCompanyProfile();
                    isSuccess = module.SaveCaConfigs();
                    break;
                case "SystemConfig":
                    isSuccess = module.SaveSystemConfigs();
                    break;
            }
            if (isSuccess)
            {
                MessageBox.Show(CompanyConstantLocalizedResources.SaveSuccessfullyMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
