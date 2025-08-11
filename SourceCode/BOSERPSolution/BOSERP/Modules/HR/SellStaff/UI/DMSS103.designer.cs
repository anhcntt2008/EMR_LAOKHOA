using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.SellStaff.UI
{
	/// <summary>
	/// Summary description for DMSS103
	/// </summary>
	partial class DMSS103
	{
		private GEHistoryDetailsGridControl fld_dgcGEHistoryDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvGEHistoryDetails;
        private BOSComponent.BOSTabControl fld_tabTabControl;


		/// <summary>
		/// Clean up any resources being used
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
				if (components != null)
					components.Dispose();
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMSS103));
            this.fld_dgcGEHistoryDetails = new BOSERP.Modules.SellStaff.GEHistoryDetailsGridControl();
            this.fld_dgvGEHistoryDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_tabHistory = new BOSComponent.BOSTabControl(this.components);
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcHRAllowances = new BOSERP.Modules.SellStaff.HRAllowancesGridControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_tapEvaluation = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcHREmployeeEvaluations = new BOSERP.Modules.SellStaff.HREmployeeEvaluationsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcHRRewards = new BOSERP.Modules.SellStaff.HRRewardsGridControl();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcHRDisciplines = new BOSERP.Modules.SellStaff.HRDisciplinesGridControl();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcHRAdvanceRequestItems = new BOSERP.Modules.SellStaff.AdvanceRequestItemsGridControl();
            this.xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcARDeliverys = new BOSERP.Modules.SellStaff.ARDeliverysGridControl();
            this.xtraTabPage7 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_grpGroupControl15 = new BOSComponent.BOSLine(this.components);
            this.bosLabel8 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtNormalLeaveDayRemains = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtOTLeaveDayRemains = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtBirthLeaveDayRemains = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtSickLeaveDayRemains = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtAnnualLeaveDayRemains = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel7 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel6 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtNormalLeaveDayOffs = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtOTLeaveDayOffs = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtBirthLeaveDayOffs = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtSickLeaveDayOffs = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtAnnualLeaveDayOffs = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtNormalLeaveDays = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtOTLeaveDays = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtBirthLeaveDays = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtSickLeaveDays = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtAnnualLeaveDays = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel5 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel4 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel3 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_dgcHRLeaveDays = new BOSERP.Modules.SellStaff.HRLeaveDaysGridControl();
            this.fld_dteTo = new BOSComponent.BOSDateEdit(this.components);
            this.fld_dteFrom = new BOSComponent.BOSDateEdit(this.components);
            this.fld_btnShow = new BOSComponent.BOSButton(this.components);
            this.fld_lblLabel62 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel61 = new BOSComponent.BOSLabel(this.components);
            this.bosPanel1 = new BOSComponent.BOSPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcGEHistoryDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvGEHistoryDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_tabHistory)).BeginInit();
            this.fld_tabHistory.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRAllowances)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            this.fld_tapEvaluation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeEvaluations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRRewards)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRDisciplines)).BeginInit();
            this.xtraTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRAdvanceRequestItems)).BeginInit();
            this.xtraTabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcARDeliverys)).BeginInit();
            this.xtraTabPage7.SuspendLayout();
            this.fld_grpGroupControl15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtNormalLeaveDayRemains.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtOTLeaveDayRemains.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtBirthLeaveDayRemains.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtSickLeaveDayRemains.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtAnnualLeaveDayRemains.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtNormalLeaveDayOffs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtOTLeaveDayOffs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtBirthLeaveDayOffs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtSickLeaveDayOffs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtAnnualLeaveDayOffs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtNormalLeaveDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtOTLeaveDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtBirthLeaveDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtSickLeaveDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtAnnualLeaveDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRLeaveDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteFrom.Properties)).BeginInit();
            this.bosPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fld_dgcGEHistoryDetails
            // 
            this.fld_dgcGEHistoryDetails.AllowDrop = true;
            this.fld_dgcGEHistoryDetails.BOSComment = global::Localization.ReportLocalizedResources.String1;
            this.fld_dgcGEHistoryDetails.BOSDataMember = global::Localization.ReportLocalizedResources.String1;
            this.fld_dgcGEHistoryDetails.BOSDataSource = "GEHistoryDetails";
            this.fld_dgcGEHistoryDetails.BOSDescription = null;
            this.fld_dgcGEHistoryDetails.BOSError = null;
            this.fld_dgcGEHistoryDetails.BOSFieldGroup = global::Localization.ReportLocalizedResources.String1;
            this.fld_dgcGEHistoryDetails.BOSFieldRelation = global::Localization.ReportLocalizedResources.String1;
            this.fld_dgcGEHistoryDetails.BOSGridType = null;
            this.fld_dgcGEHistoryDetails.BOSPrivilege = global::Localization.ReportLocalizedResources.String1;
            this.fld_dgcGEHistoryDetails.BOSPropertyName = global::Localization.ReportLocalizedResources.String1;
            resources.ApplyResources(this.fld_dgcGEHistoryDetails, "fld_dgcGEHistoryDetails");
            this.fld_dgcGEHistoryDetails.MainView = this.fld_dgvGEHistoryDetails;
            this.fld_dgcGEHistoryDetails.Name = "fld_dgcGEHistoryDetails";
            this.fld_dgcGEHistoryDetails.PrintReport = false;
            this.fld_dgcGEHistoryDetails.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dgcGEHistoryDetails, ((bool)(resources.GetObject("fld_dgcGEHistoryDetails.ShowHelp"))));
            this.fld_dgcGEHistoryDetails.Tag = "DC";
            this.fld_dgcGEHistoryDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvGEHistoryDetails});
            // 
            // fld_dgvGEHistoryDetails
            // 
            this.fld_dgvGEHistoryDetails.GridControl = this.fld_dgcGEHistoryDetails;
            this.fld_dgvGEHistoryDetails.Name = "fld_dgvGEHistoryDetails";
            this.fld_dgvGEHistoryDetails.PaintStyleName = "Office2003";
            // 
            // fld_tabHistory
            // 
            resources.ApplyResources(this.fld_tabHistory, "fld_tabHistory");
            this.fld_tabHistory.BOSComment = null;
            this.fld_tabHistory.BOSDataMember = null;
            this.fld_tabHistory.BOSDataSource = null;
            this.fld_tabHistory.BOSDescription = null;
            this.fld_tabHistory.BOSError = null;
            this.fld_tabHistory.BOSFieldGroup = null;
            this.fld_tabHistory.BOSFieldRelation = null;
            this.fld_tabHistory.BOSPrivilege = null;
            this.fld_tabHistory.BOSPropertyName = null;
            this.fld_tabHistory.Name = "fld_tabHistory";
            this.fld_tabHistory.Screen = null;
            this.fld_tabHistory.SelectedTabPage = this.xtraTabPage4;
            this.ScreenHelper.SetShowHelp(this.fld_tabHistory, ((bool)(resources.GetObject("fld_tabHistory.ShowHelp"))));
            this.fld_tabHistory.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.fld_tapEvaluation,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4,
            this.xtraTabPage5,
            this.xtraTabPage6,
            this.xtraTabPage7});
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.fld_dgcHRAllowances);
            this.xtraTabPage4.Name = "xtraTabPage4";
            resources.ApplyResources(this.xtraTabPage4, "xtraTabPage4");
            // 
            // fld_dgcHRAllowances
            // 
            this.fld_dgcHRAllowances.BOSComment = null;
            this.fld_dgcHRAllowances.BOSDataMember = null;
            this.fld_dgcHRAllowances.BOSDataSource = "HRAllowances";
            this.fld_dgcHRAllowances.BOSDescription = null;
            this.fld_dgcHRAllowances.BOSError = null;
            this.fld_dgcHRAllowances.BOSFieldGroup = null;
            this.fld_dgcHRAllowances.BOSFieldRelation = null;
            this.fld_dgcHRAllowances.BOSGridType = null;
            this.fld_dgcHRAllowances.BOSPrivilege = null;
            this.fld_dgcHRAllowances.BOSPropertyName = null;
            resources.ApplyResources(this.fld_dgcHRAllowances, "fld_dgcHRAllowances");
            this.fld_dgcHRAllowances.MenuManager = this.screenToolbar;
            this.fld_dgcHRAllowances.Name = "fld_dgcHRAllowances";
            this.fld_dgcHRAllowances.PrintReport = false;
            this.fld_dgcHRAllowances.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dgcHRAllowances, ((bool)(resources.GetObject("fld_dgcHRAllowances.ShowHelp"))));
            this.fld_dgcHRAllowances.Tag = "DC";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.fld_dgcGEHistoryDetails);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.ScreenHelper.SetShowHelp(this.xtraTabPage1, ((bool)(resources.GetObject("xtraTabPage1.ShowHelp"))));
            resources.ApplyResources(this.xtraTabPage1, "xtraTabPage1");
            // 
            // fld_tapEvaluation
            // 
            this.fld_tapEvaluation.Controls.Add(this.fld_dgcHREmployeeEvaluations);
            this.fld_tapEvaluation.Name = "fld_tapEvaluation";
            this.ScreenHelper.SetShowHelp(this.fld_tapEvaluation, ((bool)(resources.GetObject("fld_tapEvaluation.ShowHelp"))));
            resources.ApplyResources(this.fld_tapEvaluation, "fld_tapEvaluation");
            // 
            // fld_dgcHREmployeeEvaluations
            // 
            this.fld_dgcHREmployeeEvaluations.AllowDrop = true;
            this.fld_dgcHREmployeeEvaluations.BOSComment = global::Localization.ReportLocalizedResources.String1;
            this.fld_dgcHREmployeeEvaluations.BOSDataMember = global::Localization.ReportLocalizedResources.String1;
            this.fld_dgcHREmployeeEvaluations.BOSDataSource = "HREmployeeEvaluations";
            this.fld_dgcHREmployeeEvaluations.BOSDescription = null;
            this.fld_dgcHREmployeeEvaluations.BOSError = null;
            this.fld_dgcHREmployeeEvaluations.BOSFieldGroup = global::Localization.ReportLocalizedResources.String1;
            this.fld_dgcHREmployeeEvaluations.BOSFieldRelation = global::Localization.ReportLocalizedResources.String1;
            this.fld_dgcHREmployeeEvaluations.BOSGridType = null;
            this.fld_dgcHREmployeeEvaluations.BOSPrivilege = global::Localization.ReportLocalizedResources.String1;
            this.fld_dgcHREmployeeEvaluations.BOSPropertyName = global::Localization.ReportLocalizedResources.String1;
            resources.ApplyResources(this.fld_dgcHREmployeeEvaluations, "fld_dgcHREmployeeEvaluations");
            this.fld_dgcHREmployeeEvaluations.MainView = this.gridView1;
            this.fld_dgcHREmployeeEvaluations.Name = "fld_dgcHREmployeeEvaluations";
            this.fld_dgcHREmployeeEvaluations.PrintReport = false;
            this.fld_dgcHREmployeeEvaluations.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dgcHREmployeeEvaluations, ((bool)(resources.GetObject("fld_dgcHREmployeeEvaluations.ShowHelp"))));
            this.fld_dgcHREmployeeEvaluations.Tag = "DC";
            this.fld_dgcHREmployeeEvaluations.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcHREmployeeEvaluations;
            this.gridView1.Name = "gridView1";
            this.gridView1.PaintStyleName = "Office2003";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.fld_dgcHRRewards);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.ScreenHelper.SetShowHelp(this.xtraTabPage2, ((bool)(resources.GetObject("xtraTabPage2.ShowHelp"))));
            resources.ApplyResources(this.xtraTabPage2, "xtraTabPage2");
            // 
            // fld_dgcHRRewards
            // 
            this.fld_dgcHRRewards.BOSComment = null;
            this.fld_dgcHRRewards.BOSDataMember = null;
            this.fld_dgcHRRewards.BOSDataSource = "HRRewards";
            this.fld_dgcHRRewards.BOSDescription = null;
            this.fld_dgcHRRewards.BOSError = null;
            this.fld_dgcHRRewards.BOSFieldGroup = null;
            this.fld_dgcHRRewards.BOSFieldRelation = null;
            this.fld_dgcHRRewards.BOSGridType = null;
            this.fld_dgcHRRewards.BOSPrivilege = null;
            this.fld_dgcHRRewards.BOSPropertyName = null;
            resources.ApplyResources(this.fld_dgcHRRewards, "fld_dgcHRRewards");
            this.fld_dgcHRRewards.MenuManager = this.screenToolbar;
            this.fld_dgcHRRewards.Name = "fld_dgcHRRewards";
            this.fld_dgcHRRewards.PrintReport = false;
            this.fld_dgcHRRewards.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dgcHRRewards, ((bool)(resources.GetObject("fld_dgcHRRewards.ShowHelp"))));
            this.fld_dgcHRRewards.Tag = "DC";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.fld_dgcHRDisciplines);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.ScreenHelper.SetShowHelp(this.xtraTabPage3, ((bool)(resources.GetObject("xtraTabPage3.ShowHelp"))));
            resources.ApplyResources(this.xtraTabPage3, "xtraTabPage3");
            // 
            // fld_dgcHRDisciplines
            // 
            this.fld_dgcHRDisciplines.BOSComment = null;
            this.fld_dgcHRDisciplines.BOSDataMember = null;
            this.fld_dgcHRDisciplines.BOSDataSource = "HRDisciplines";
            this.fld_dgcHRDisciplines.BOSDescription = null;
            this.fld_dgcHRDisciplines.BOSError = null;
            this.fld_dgcHRDisciplines.BOSFieldGroup = null;
            this.fld_dgcHRDisciplines.BOSFieldRelation = null;
            this.fld_dgcHRDisciplines.BOSGridType = null;
            this.fld_dgcHRDisciplines.BOSPrivilege = null;
            this.fld_dgcHRDisciplines.BOSPropertyName = null;
            resources.ApplyResources(this.fld_dgcHRDisciplines, "fld_dgcHRDisciplines");
            this.fld_dgcHRDisciplines.MenuManager = this.screenToolbar;
            this.fld_dgcHRDisciplines.Name = "fld_dgcHRDisciplines";
            this.fld_dgcHRDisciplines.PrintReport = false;
            this.fld_dgcHRDisciplines.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dgcHRDisciplines, ((bool)(resources.GetObject("fld_dgcHRDisciplines.ShowHelp"))));
            this.fld_dgcHRDisciplines.Tag = "DC";
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.fld_dgcHRAdvanceRequestItems);
            this.xtraTabPage5.Name = "xtraTabPage5";
            resources.ApplyResources(this.xtraTabPage5, "xtraTabPage5");
            // 
            // fld_dgcHRAdvanceRequestItems
            // 
            this.fld_dgcHRAdvanceRequestItems.BOSComment = null;
            this.fld_dgcHRAdvanceRequestItems.BOSDataMember = null;
            this.fld_dgcHRAdvanceRequestItems.BOSDataSource = "HRAdvanceRequestItems";
            this.fld_dgcHRAdvanceRequestItems.BOSDescription = null;
            this.fld_dgcHRAdvanceRequestItems.BOSError = null;
            this.fld_dgcHRAdvanceRequestItems.BOSFieldGroup = null;
            this.fld_dgcHRAdvanceRequestItems.BOSFieldRelation = null;
            this.fld_dgcHRAdvanceRequestItems.BOSGridType = null;
            this.fld_dgcHRAdvanceRequestItems.BOSPrivilege = null;
            this.fld_dgcHRAdvanceRequestItems.BOSPropertyName = null;
            resources.ApplyResources(this.fld_dgcHRAdvanceRequestItems, "fld_dgcHRAdvanceRequestItems");
            this.fld_dgcHRAdvanceRequestItems.MenuManager = this.screenToolbar;
            this.fld_dgcHRAdvanceRequestItems.Name = "fld_dgcHRAdvanceRequestItems";
            this.fld_dgcHRAdvanceRequestItems.PrintReport = false;
            this.fld_dgcHRAdvanceRequestItems.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dgcHRAdvanceRequestItems, ((bool)(resources.GetObject("fld_dgcHRAdvanceRequestItems.ShowHelp"))));
            this.fld_dgcHRAdvanceRequestItems.Tag = "DC";
            // 
            // xtraTabPage6
            // 
            this.xtraTabPage6.Controls.Add(this.fld_dgcARDeliverys);
            this.xtraTabPage6.Name = "xtraTabPage6";
            resources.ApplyResources(this.xtraTabPage6, "xtraTabPage6");
            // 
            // fld_dgcARDeliverys
            // 
            this.fld_dgcARDeliverys.BOSComment = null;
            this.fld_dgcARDeliverys.BOSDataMember = null;
            this.fld_dgcARDeliverys.BOSDataSource = "ARDeliverys";
            this.fld_dgcARDeliverys.BOSDescription = null;
            this.fld_dgcARDeliverys.BOSError = null;
            this.fld_dgcARDeliverys.BOSFieldGroup = null;
            this.fld_dgcARDeliverys.BOSFieldRelation = null;
            this.fld_dgcARDeliverys.BOSGridType = null;
            this.fld_dgcARDeliverys.BOSPrivilege = null;
            this.fld_dgcARDeliverys.BOSPropertyName = null;
            resources.ApplyResources(this.fld_dgcARDeliverys, "fld_dgcARDeliverys");
            this.fld_dgcARDeliverys.MenuManager = this.screenToolbar;
            this.fld_dgcARDeliverys.Name = "fld_dgcARDeliverys";
            this.fld_dgcARDeliverys.PrintReport = false;
            this.fld_dgcARDeliverys.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dgcARDeliverys, ((bool)(resources.GetObject("fld_dgcARDeliverys.ShowHelp"))));
            this.fld_dgcARDeliverys.Tag = "DC";
            // 
            // xtraTabPage7
            // 
            this.xtraTabPage7.Controls.Add(this.fld_grpGroupControl15);
            this.xtraTabPage7.Controls.Add(this.fld_dgcHRLeaveDays);
            this.xtraTabPage7.Name = "xtraTabPage7";
            resources.ApplyResources(this.xtraTabPage7, "xtraTabPage7");
            // 
            // fld_grpGroupControl15
            // 
            this.fld_grpGroupControl15.BOSComment = null;
            this.fld_grpGroupControl15.BOSDataMember = null;
            this.fld_grpGroupControl15.BOSDataSource = null;
            this.fld_grpGroupControl15.BOSDescription = null;
            this.fld_grpGroupControl15.BOSError = null;
            this.fld_grpGroupControl15.BOSFieldGroup = null;
            this.fld_grpGroupControl15.BOSFieldRelation = null;
            this.fld_grpGroupControl15.BOSPrivilege = null;
            this.fld_grpGroupControl15.BOSPropertyName = null;
            this.fld_grpGroupControl15.Controls.Add(this.bosLabel8);
            this.fld_grpGroupControl15.Controls.Add(this.fld_txtNormalLeaveDayRemains);
            this.fld_grpGroupControl15.Controls.Add(this.fld_txtOTLeaveDayRemains);
            this.fld_grpGroupControl15.Controls.Add(this.fld_txtBirthLeaveDayRemains);
            this.fld_grpGroupControl15.Controls.Add(this.fld_txtSickLeaveDayRemains);
            this.fld_grpGroupControl15.Controls.Add(this.fld_txtAnnualLeaveDayRemains);
            this.fld_grpGroupControl15.Controls.Add(this.bosLabel7);
            this.fld_grpGroupControl15.Controls.Add(this.bosLabel6);
            this.fld_grpGroupControl15.Controls.Add(this.fld_txtNormalLeaveDayOffs);
            this.fld_grpGroupControl15.Controls.Add(this.fld_txtOTLeaveDayOffs);
            this.fld_grpGroupControl15.Controls.Add(this.fld_txtBirthLeaveDayOffs);
            this.fld_grpGroupControl15.Controls.Add(this.fld_txtSickLeaveDayOffs);
            this.fld_grpGroupControl15.Controls.Add(this.fld_txtAnnualLeaveDayOffs);
            this.fld_grpGroupControl15.Controls.Add(this.fld_txtNormalLeaveDays);
            this.fld_grpGroupControl15.Controls.Add(this.fld_txtOTLeaveDays);
            this.fld_grpGroupControl15.Controls.Add(this.fld_txtBirthLeaveDays);
            this.fld_grpGroupControl15.Controls.Add(this.fld_txtSickLeaveDays);
            this.fld_grpGroupControl15.Controls.Add(this.fld_txtAnnualLeaveDays);
            this.fld_grpGroupControl15.Controls.Add(this.bosLabel5);
            this.fld_grpGroupControl15.Controls.Add(this.bosLabel4);
            this.fld_grpGroupControl15.Controls.Add(this.bosLabel3);
            this.fld_grpGroupControl15.Controls.Add(this.bosLabel2);
            this.fld_grpGroupControl15.Controls.Add(this.bosLabel1);
            resources.ApplyResources(this.fld_grpGroupControl15, "fld_grpGroupControl15");
            this.fld_grpGroupControl15.Name = "fld_grpGroupControl15";
            this.fld_grpGroupControl15.Screen = null;
            this.fld_grpGroupControl15.TabStop = false;
            // 
            // bosLabel8
            // 
            this.bosLabel8.BOSComment = null;
            this.bosLabel8.BOSDataMember = null;
            this.bosLabel8.BOSDataSource = null;
            this.bosLabel8.BOSDescription = null;
            this.bosLabel8.BOSError = null;
            this.bosLabel8.BOSFieldGroup = null;
            this.bosLabel8.BOSFieldRelation = null;
            this.bosLabel8.BOSPrivilege = null;
            this.bosLabel8.BOSPropertyName = null;
            resources.ApplyResources(this.bosLabel8, "bosLabel8");
            this.bosLabel8.Name = "bosLabel8";
            this.bosLabel8.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel8, ((bool)(resources.GetObject("bosLabel8.ShowHelp"))));
            // 
            // fld_txtNormalLeaveDayRemains
            // 
            this.fld_txtNormalLeaveDayRemains.BOSComment = null;
            this.fld_txtNormalLeaveDayRemains.BOSDataMember = null;
            this.fld_txtNormalLeaveDayRemains.BOSDataSource = null;
            this.fld_txtNormalLeaveDayRemains.BOSDescription = null;
            this.fld_txtNormalLeaveDayRemains.BOSError = null;
            this.fld_txtNormalLeaveDayRemains.BOSFieldGroup = null;
            this.fld_txtNormalLeaveDayRemains.BOSFieldRelation = null;
            this.fld_txtNormalLeaveDayRemains.BOSPrivilege = null;
            this.fld_txtNormalLeaveDayRemains.BOSPropertyName = null;
            resources.ApplyResources(this.fld_txtNormalLeaveDayRemains, "fld_txtNormalLeaveDayRemains");
            this.fld_txtNormalLeaveDayRemains.MenuManager = this.screenToolbar;
            this.fld_txtNormalLeaveDayRemains.Name = "fld_txtNormalLeaveDayRemains";
            this.fld_txtNormalLeaveDayRemains.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtNormalLeaveDayRemains, ((bool)(resources.GetObject("fld_txtNormalLeaveDayRemains.ShowHelp"))));
            // 
            // fld_txtOTLeaveDayRemains
            // 
            this.fld_txtOTLeaveDayRemains.BOSComment = null;
            this.fld_txtOTLeaveDayRemains.BOSDataMember = null;
            this.fld_txtOTLeaveDayRemains.BOSDataSource = null;
            this.fld_txtOTLeaveDayRemains.BOSDescription = null;
            this.fld_txtOTLeaveDayRemains.BOSError = null;
            this.fld_txtOTLeaveDayRemains.BOSFieldGroup = null;
            this.fld_txtOTLeaveDayRemains.BOSFieldRelation = null;
            this.fld_txtOTLeaveDayRemains.BOSPrivilege = null;
            this.fld_txtOTLeaveDayRemains.BOSPropertyName = null;
            resources.ApplyResources(this.fld_txtOTLeaveDayRemains, "fld_txtOTLeaveDayRemains");
            this.fld_txtOTLeaveDayRemains.MenuManager = this.screenToolbar;
            this.fld_txtOTLeaveDayRemains.Name = "fld_txtOTLeaveDayRemains";
            this.fld_txtOTLeaveDayRemains.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtOTLeaveDayRemains, ((bool)(resources.GetObject("fld_txtOTLeaveDayRemains.ShowHelp"))));
            // 
            // fld_txtBirthLeaveDayRemains
            // 
            this.fld_txtBirthLeaveDayRemains.BOSComment = null;
            this.fld_txtBirthLeaveDayRemains.BOSDataMember = null;
            this.fld_txtBirthLeaveDayRemains.BOSDataSource = null;
            this.fld_txtBirthLeaveDayRemains.BOSDescription = null;
            this.fld_txtBirthLeaveDayRemains.BOSError = null;
            this.fld_txtBirthLeaveDayRemains.BOSFieldGroup = null;
            this.fld_txtBirthLeaveDayRemains.BOSFieldRelation = null;
            this.fld_txtBirthLeaveDayRemains.BOSPrivilege = null;
            this.fld_txtBirthLeaveDayRemains.BOSPropertyName = null;
            resources.ApplyResources(this.fld_txtBirthLeaveDayRemains, "fld_txtBirthLeaveDayRemains");
            this.fld_txtBirthLeaveDayRemains.MenuManager = this.screenToolbar;
            this.fld_txtBirthLeaveDayRemains.Name = "fld_txtBirthLeaveDayRemains";
            this.fld_txtBirthLeaveDayRemains.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtBirthLeaveDayRemains, ((bool)(resources.GetObject("fld_txtBirthLeaveDayRemains.ShowHelp"))));
            // 
            // fld_txtSickLeaveDayRemains
            // 
            this.fld_txtSickLeaveDayRemains.BOSComment = null;
            this.fld_txtSickLeaveDayRemains.BOSDataMember = null;
            this.fld_txtSickLeaveDayRemains.BOSDataSource = null;
            this.fld_txtSickLeaveDayRemains.BOSDescription = null;
            this.fld_txtSickLeaveDayRemains.BOSError = null;
            this.fld_txtSickLeaveDayRemains.BOSFieldGroup = null;
            this.fld_txtSickLeaveDayRemains.BOSFieldRelation = null;
            this.fld_txtSickLeaveDayRemains.BOSPrivilege = null;
            this.fld_txtSickLeaveDayRemains.BOSPropertyName = null;
            resources.ApplyResources(this.fld_txtSickLeaveDayRemains, "fld_txtSickLeaveDayRemains");
            this.fld_txtSickLeaveDayRemains.MenuManager = this.screenToolbar;
            this.fld_txtSickLeaveDayRemains.Name = "fld_txtSickLeaveDayRemains";
            this.fld_txtSickLeaveDayRemains.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtSickLeaveDayRemains, ((bool)(resources.GetObject("fld_txtSickLeaveDayRemains.ShowHelp"))));
            // 
            // fld_txtAnnualLeaveDayRemains
            // 
            this.fld_txtAnnualLeaveDayRemains.BOSComment = null;
            this.fld_txtAnnualLeaveDayRemains.BOSDataMember = null;
            this.fld_txtAnnualLeaveDayRemains.BOSDataSource = null;
            this.fld_txtAnnualLeaveDayRemains.BOSDescription = null;
            this.fld_txtAnnualLeaveDayRemains.BOSError = null;
            this.fld_txtAnnualLeaveDayRemains.BOSFieldGroup = null;
            this.fld_txtAnnualLeaveDayRemains.BOSFieldRelation = null;
            this.fld_txtAnnualLeaveDayRemains.BOSPrivilege = null;
            this.fld_txtAnnualLeaveDayRemains.BOSPropertyName = null;
            resources.ApplyResources(this.fld_txtAnnualLeaveDayRemains, "fld_txtAnnualLeaveDayRemains");
            this.fld_txtAnnualLeaveDayRemains.MenuManager = this.screenToolbar;
            this.fld_txtAnnualLeaveDayRemains.Name = "fld_txtAnnualLeaveDayRemains";
            this.fld_txtAnnualLeaveDayRemains.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtAnnualLeaveDayRemains, ((bool)(resources.GetObject("fld_txtAnnualLeaveDayRemains.ShowHelp"))));
            // 
            // bosLabel7
            // 
            this.bosLabel7.BOSComment = null;
            this.bosLabel7.BOSDataMember = null;
            this.bosLabel7.BOSDataSource = null;
            this.bosLabel7.BOSDescription = null;
            this.bosLabel7.BOSError = null;
            this.bosLabel7.BOSFieldGroup = null;
            this.bosLabel7.BOSFieldRelation = null;
            this.bosLabel7.BOSPrivilege = null;
            this.bosLabel7.BOSPropertyName = null;
            resources.ApplyResources(this.bosLabel7, "bosLabel7");
            this.bosLabel7.Name = "bosLabel7";
            this.bosLabel7.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel7, ((bool)(resources.GetObject("bosLabel7.ShowHelp"))));
            // 
            // bosLabel6
            // 
            this.bosLabel6.BOSComment = null;
            this.bosLabel6.BOSDataMember = null;
            this.bosLabel6.BOSDataSource = null;
            this.bosLabel6.BOSDescription = null;
            this.bosLabel6.BOSError = null;
            this.bosLabel6.BOSFieldGroup = null;
            this.bosLabel6.BOSFieldRelation = null;
            this.bosLabel6.BOSPrivilege = null;
            this.bosLabel6.BOSPropertyName = null;
            resources.ApplyResources(this.bosLabel6, "bosLabel6");
            this.bosLabel6.Name = "bosLabel6";
            this.bosLabel6.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel6, ((bool)(resources.GetObject("bosLabel6.ShowHelp"))));
            // 
            // fld_txtNormalLeaveDayOffs
            // 
            this.fld_txtNormalLeaveDayOffs.BOSComment = null;
            this.fld_txtNormalLeaveDayOffs.BOSDataMember = null;
            this.fld_txtNormalLeaveDayOffs.BOSDataSource = null;
            this.fld_txtNormalLeaveDayOffs.BOSDescription = null;
            this.fld_txtNormalLeaveDayOffs.BOSError = null;
            this.fld_txtNormalLeaveDayOffs.BOSFieldGroup = null;
            this.fld_txtNormalLeaveDayOffs.BOSFieldRelation = null;
            this.fld_txtNormalLeaveDayOffs.BOSPrivilege = null;
            this.fld_txtNormalLeaveDayOffs.BOSPropertyName = null;
            resources.ApplyResources(this.fld_txtNormalLeaveDayOffs, "fld_txtNormalLeaveDayOffs");
            this.fld_txtNormalLeaveDayOffs.MenuManager = this.screenToolbar;
            this.fld_txtNormalLeaveDayOffs.Name = "fld_txtNormalLeaveDayOffs";
            this.fld_txtNormalLeaveDayOffs.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtNormalLeaveDayOffs, ((bool)(resources.GetObject("fld_txtNormalLeaveDayOffs.ShowHelp"))));
            // 
            // fld_txtOTLeaveDayOffs
            // 
            this.fld_txtOTLeaveDayOffs.BOSComment = null;
            this.fld_txtOTLeaveDayOffs.BOSDataMember = null;
            this.fld_txtOTLeaveDayOffs.BOSDataSource = null;
            this.fld_txtOTLeaveDayOffs.BOSDescription = null;
            this.fld_txtOTLeaveDayOffs.BOSError = null;
            this.fld_txtOTLeaveDayOffs.BOSFieldGroup = null;
            this.fld_txtOTLeaveDayOffs.BOSFieldRelation = null;
            this.fld_txtOTLeaveDayOffs.BOSPrivilege = null;
            this.fld_txtOTLeaveDayOffs.BOSPropertyName = null;
            resources.ApplyResources(this.fld_txtOTLeaveDayOffs, "fld_txtOTLeaveDayOffs");
            this.fld_txtOTLeaveDayOffs.MenuManager = this.screenToolbar;
            this.fld_txtOTLeaveDayOffs.Name = "fld_txtOTLeaveDayOffs";
            this.fld_txtOTLeaveDayOffs.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtOTLeaveDayOffs, ((bool)(resources.GetObject("fld_txtOTLeaveDayOffs.ShowHelp"))));
            // 
            // fld_txtBirthLeaveDayOffs
            // 
            this.fld_txtBirthLeaveDayOffs.BOSComment = null;
            this.fld_txtBirthLeaveDayOffs.BOSDataMember = null;
            this.fld_txtBirthLeaveDayOffs.BOSDataSource = null;
            this.fld_txtBirthLeaveDayOffs.BOSDescription = null;
            this.fld_txtBirthLeaveDayOffs.BOSError = null;
            this.fld_txtBirthLeaveDayOffs.BOSFieldGroup = null;
            this.fld_txtBirthLeaveDayOffs.BOSFieldRelation = null;
            this.fld_txtBirthLeaveDayOffs.BOSPrivilege = null;
            this.fld_txtBirthLeaveDayOffs.BOSPropertyName = null;
            resources.ApplyResources(this.fld_txtBirthLeaveDayOffs, "fld_txtBirthLeaveDayOffs");
            this.fld_txtBirthLeaveDayOffs.MenuManager = this.screenToolbar;
            this.fld_txtBirthLeaveDayOffs.Name = "fld_txtBirthLeaveDayOffs";
            this.fld_txtBirthLeaveDayOffs.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtBirthLeaveDayOffs, ((bool)(resources.GetObject("fld_txtBirthLeaveDayOffs.ShowHelp"))));
            // 
            // fld_txtSickLeaveDayOffs
            // 
            this.fld_txtSickLeaveDayOffs.BOSComment = null;
            this.fld_txtSickLeaveDayOffs.BOSDataMember = null;
            this.fld_txtSickLeaveDayOffs.BOSDataSource = null;
            this.fld_txtSickLeaveDayOffs.BOSDescription = null;
            this.fld_txtSickLeaveDayOffs.BOSError = null;
            this.fld_txtSickLeaveDayOffs.BOSFieldGroup = null;
            this.fld_txtSickLeaveDayOffs.BOSFieldRelation = null;
            this.fld_txtSickLeaveDayOffs.BOSPrivilege = null;
            this.fld_txtSickLeaveDayOffs.BOSPropertyName = null;
            resources.ApplyResources(this.fld_txtSickLeaveDayOffs, "fld_txtSickLeaveDayOffs");
            this.fld_txtSickLeaveDayOffs.MenuManager = this.screenToolbar;
            this.fld_txtSickLeaveDayOffs.Name = "fld_txtSickLeaveDayOffs";
            this.fld_txtSickLeaveDayOffs.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtSickLeaveDayOffs, ((bool)(resources.GetObject("fld_txtSickLeaveDayOffs.ShowHelp"))));
            // 
            // fld_txtAnnualLeaveDayOffs
            // 
            this.fld_txtAnnualLeaveDayOffs.BOSComment = null;
            this.fld_txtAnnualLeaveDayOffs.BOSDataMember = null;
            this.fld_txtAnnualLeaveDayOffs.BOSDataSource = null;
            this.fld_txtAnnualLeaveDayOffs.BOSDescription = null;
            this.fld_txtAnnualLeaveDayOffs.BOSError = null;
            this.fld_txtAnnualLeaveDayOffs.BOSFieldGroup = null;
            this.fld_txtAnnualLeaveDayOffs.BOSFieldRelation = null;
            this.fld_txtAnnualLeaveDayOffs.BOSPrivilege = null;
            this.fld_txtAnnualLeaveDayOffs.BOSPropertyName = null;
            resources.ApplyResources(this.fld_txtAnnualLeaveDayOffs, "fld_txtAnnualLeaveDayOffs");
            this.fld_txtAnnualLeaveDayOffs.MenuManager = this.screenToolbar;
            this.fld_txtAnnualLeaveDayOffs.Name = "fld_txtAnnualLeaveDayOffs";
            this.fld_txtAnnualLeaveDayOffs.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtAnnualLeaveDayOffs, ((bool)(resources.GetObject("fld_txtAnnualLeaveDayOffs.ShowHelp"))));
            // 
            // fld_txtNormalLeaveDays
            // 
            this.fld_txtNormalLeaveDays.BOSComment = null;
            this.fld_txtNormalLeaveDays.BOSDataMember = null;
            this.fld_txtNormalLeaveDays.BOSDataSource = null;
            this.fld_txtNormalLeaveDays.BOSDescription = null;
            this.fld_txtNormalLeaveDays.BOSError = null;
            this.fld_txtNormalLeaveDays.BOSFieldGroup = null;
            this.fld_txtNormalLeaveDays.BOSFieldRelation = null;
            this.fld_txtNormalLeaveDays.BOSPrivilege = null;
            this.fld_txtNormalLeaveDays.BOSPropertyName = null;
            resources.ApplyResources(this.fld_txtNormalLeaveDays, "fld_txtNormalLeaveDays");
            this.fld_txtNormalLeaveDays.MenuManager = this.screenToolbar;
            this.fld_txtNormalLeaveDays.Name = "fld_txtNormalLeaveDays";
            this.fld_txtNormalLeaveDays.Screen = null;
            // 
            // fld_txtOTLeaveDays
            // 
            this.fld_txtOTLeaveDays.BOSComment = null;
            this.fld_txtOTLeaveDays.BOSDataMember = null;
            this.fld_txtOTLeaveDays.BOSDataSource = null;
            this.fld_txtOTLeaveDays.BOSDescription = null;
            this.fld_txtOTLeaveDays.BOSError = null;
            this.fld_txtOTLeaveDays.BOSFieldGroup = null;
            this.fld_txtOTLeaveDays.BOSFieldRelation = null;
            this.fld_txtOTLeaveDays.BOSPrivilege = null;
            this.fld_txtOTLeaveDays.BOSPropertyName = null;
            resources.ApplyResources(this.fld_txtOTLeaveDays, "fld_txtOTLeaveDays");
            this.fld_txtOTLeaveDays.MenuManager = this.screenToolbar;
            this.fld_txtOTLeaveDays.Name = "fld_txtOTLeaveDays";
            this.fld_txtOTLeaveDays.Screen = null;
            // 
            // fld_txtBirthLeaveDays
            // 
            this.fld_txtBirthLeaveDays.BOSComment = null;
            this.fld_txtBirthLeaveDays.BOSDataMember = null;
            this.fld_txtBirthLeaveDays.BOSDataSource = null;
            this.fld_txtBirthLeaveDays.BOSDescription = null;
            this.fld_txtBirthLeaveDays.BOSError = null;
            this.fld_txtBirthLeaveDays.BOSFieldGroup = null;
            this.fld_txtBirthLeaveDays.BOSFieldRelation = null;
            this.fld_txtBirthLeaveDays.BOSPrivilege = null;
            this.fld_txtBirthLeaveDays.BOSPropertyName = null;
            resources.ApplyResources(this.fld_txtBirthLeaveDays, "fld_txtBirthLeaveDays");
            this.fld_txtBirthLeaveDays.MenuManager = this.screenToolbar;
            this.fld_txtBirthLeaveDays.Name = "fld_txtBirthLeaveDays";
            this.fld_txtBirthLeaveDays.Screen = null;
            // 
            // fld_txtSickLeaveDays
            // 
            this.fld_txtSickLeaveDays.BOSComment = null;
            this.fld_txtSickLeaveDays.BOSDataMember = null;
            this.fld_txtSickLeaveDays.BOSDataSource = null;
            this.fld_txtSickLeaveDays.BOSDescription = null;
            this.fld_txtSickLeaveDays.BOSError = null;
            this.fld_txtSickLeaveDays.BOSFieldGroup = null;
            this.fld_txtSickLeaveDays.BOSFieldRelation = null;
            this.fld_txtSickLeaveDays.BOSPrivilege = null;
            this.fld_txtSickLeaveDays.BOSPropertyName = null;
            resources.ApplyResources(this.fld_txtSickLeaveDays, "fld_txtSickLeaveDays");
            this.fld_txtSickLeaveDays.MenuManager = this.screenToolbar;
            this.fld_txtSickLeaveDays.Name = "fld_txtSickLeaveDays";
            this.fld_txtSickLeaveDays.Screen = null;
            // 
            // fld_txtAnnualLeaveDays
            // 
            this.fld_txtAnnualLeaveDays.BOSComment = null;
            this.fld_txtAnnualLeaveDays.BOSDataMember = null;
            this.fld_txtAnnualLeaveDays.BOSDataSource = null;
            this.fld_txtAnnualLeaveDays.BOSDescription = null;
            this.fld_txtAnnualLeaveDays.BOSError = null;
            this.fld_txtAnnualLeaveDays.BOSFieldGroup = null;
            this.fld_txtAnnualLeaveDays.BOSFieldRelation = null;
            this.fld_txtAnnualLeaveDays.BOSPrivilege = null;
            this.fld_txtAnnualLeaveDays.BOSPropertyName = null;
            resources.ApplyResources(this.fld_txtAnnualLeaveDays, "fld_txtAnnualLeaveDays");
            this.fld_txtAnnualLeaveDays.MenuManager = this.screenToolbar;
            this.fld_txtAnnualLeaveDays.Name = "fld_txtAnnualLeaveDays";
            this.fld_txtAnnualLeaveDays.Screen = null;
            // 
            // bosLabel5
            // 
            this.bosLabel5.BOSComment = null;
            this.bosLabel5.BOSDataMember = null;
            this.bosLabel5.BOSDataSource = null;
            this.bosLabel5.BOSDescription = null;
            this.bosLabel5.BOSError = null;
            this.bosLabel5.BOSFieldGroup = null;
            this.bosLabel5.BOSFieldRelation = null;
            this.bosLabel5.BOSPrivilege = null;
            this.bosLabel5.BOSPropertyName = null;
            resources.ApplyResources(this.bosLabel5, "bosLabel5");
            this.bosLabel5.Name = "bosLabel5";
            this.bosLabel5.Screen = null;
            // 
            // bosLabel4
            // 
            this.bosLabel4.BOSComment = null;
            this.bosLabel4.BOSDataMember = null;
            this.bosLabel4.BOSDataSource = null;
            this.bosLabel4.BOSDescription = null;
            this.bosLabel4.BOSError = null;
            this.bosLabel4.BOSFieldGroup = null;
            this.bosLabel4.BOSFieldRelation = null;
            this.bosLabel4.BOSPrivilege = null;
            this.bosLabel4.BOSPropertyName = null;
            resources.ApplyResources(this.bosLabel4, "bosLabel4");
            this.bosLabel4.Name = "bosLabel4";
            this.bosLabel4.Screen = null;
            // 
            // bosLabel3
            // 
            this.bosLabel3.BOSComment = null;
            this.bosLabel3.BOSDataMember = null;
            this.bosLabel3.BOSDataSource = null;
            this.bosLabel3.BOSDescription = null;
            this.bosLabel3.BOSError = null;
            this.bosLabel3.BOSFieldGroup = null;
            this.bosLabel3.BOSFieldRelation = null;
            this.bosLabel3.BOSPrivilege = null;
            this.bosLabel3.BOSPropertyName = null;
            resources.ApplyResources(this.bosLabel3, "bosLabel3");
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            // 
            // bosLabel2
            // 
            this.bosLabel2.BOSComment = null;
            this.bosLabel2.BOSDataMember = null;
            this.bosLabel2.BOSDataSource = null;
            this.bosLabel2.BOSDescription = null;
            this.bosLabel2.BOSError = null;
            this.bosLabel2.BOSFieldGroup = null;
            this.bosLabel2.BOSFieldRelation = null;
            this.bosLabel2.BOSPrivilege = null;
            this.bosLabel2.BOSPropertyName = null;
            resources.ApplyResources(this.bosLabel2, "bosLabel2");
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            // 
            // bosLabel1
            // 
            this.bosLabel1.BOSComment = null;
            this.bosLabel1.BOSDataMember = null;
            this.bosLabel1.BOSDataSource = null;
            this.bosLabel1.BOSDescription = null;
            this.bosLabel1.BOSError = null;
            this.bosLabel1.BOSFieldGroup = null;
            this.bosLabel1.BOSFieldRelation = null;
            this.bosLabel1.BOSPrivilege = null;
            this.bosLabel1.BOSPropertyName = null;
            resources.ApplyResources(this.bosLabel1, "bosLabel1");
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            // 
            // fld_dgcHRLeaveDays
            // 
            resources.ApplyResources(this.fld_dgcHRLeaveDays, "fld_dgcHRLeaveDays");
            this.fld_dgcHRLeaveDays.BOSComment = null;
            this.fld_dgcHRLeaveDays.BOSDataMember = null;
            this.fld_dgcHRLeaveDays.BOSDataSource = "HRLeaveDays";
            this.fld_dgcHRLeaveDays.BOSDescription = null;
            this.fld_dgcHRLeaveDays.BOSError = null;
            this.fld_dgcHRLeaveDays.BOSFieldGroup = null;
            this.fld_dgcHRLeaveDays.BOSFieldRelation = null;
            this.fld_dgcHRLeaveDays.BOSGridType = null;
            this.fld_dgcHRLeaveDays.BOSPrivilege = null;
            this.fld_dgcHRLeaveDays.BOSPropertyName = null;
            this.fld_dgcHRLeaveDays.MenuManager = this.screenToolbar;
            this.fld_dgcHRLeaveDays.Name = "fld_dgcHRLeaveDays";
            this.fld_dgcHRLeaveDays.PrintReport = false;
            this.fld_dgcHRLeaveDays.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dgcHRLeaveDays, ((bool)(resources.GetObject("fld_dgcHRLeaveDays.ShowHelp"))));
            this.fld_dgcHRLeaveDays.Tag = "DC";
            // 
            // fld_dteTo
            // 
            this.fld_dteTo.BOSComment = global::Localization.ReportLocalizedResources.String1;
            this.fld_dteTo.BOSDataMember = "DateEdit";
            this.fld_dteTo.BOSDataSource = global::Localization.ReportLocalizedResources.String1;
            this.fld_dteTo.BOSDescription = null;
            this.fld_dteTo.BOSError = null;
            this.fld_dteTo.BOSFieldGroup = global::Localization.ReportLocalizedResources.String1;
            this.fld_dteTo.BOSFieldRelation = global::Localization.ReportLocalizedResources.String1;
            this.fld_dteTo.BOSPrivilege = global::Localization.ReportLocalizedResources.String1;
            this.fld_dteTo.BOSPropertyName = "EditValue";
            this.fld_dteTo.EditValue = null;
            resources.ApplyResources(this.fld_dteTo, "fld_dteTo");
            this.fld_dteTo.Name = "fld_dteTo";
            this.fld_dteTo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteTo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteTo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteTo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("fld_dteTo.Properties.Buttons"))))});
            this.fld_dteTo.Properties.DisplayFormat.FormatString = "MM/dd/yyyy";
            this.fld_dteTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteTo.Properties.EditFormat.FormatString = "MM/dd/yyyy";
            this.fld_dteTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fld_dteTo.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dteTo, ((bool)(resources.GetObject("fld_dteTo.ShowHelp"))));
            this.fld_dteTo.Tag = "DC";
            // 
            // fld_dteFrom
            // 
            this.fld_dteFrom.BOSComment = global::Localization.ReportLocalizedResources.String1;
            this.fld_dteFrom.BOSDataMember = "DateEdit";
            this.fld_dteFrom.BOSDataSource = global::Localization.ReportLocalizedResources.String1;
            this.fld_dteFrom.BOSDescription = null;
            this.fld_dteFrom.BOSError = null;
            this.fld_dteFrom.BOSFieldGroup = global::Localization.ReportLocalizedResources.String1;
            this.fld_dteFrom.BOSFieldRelation = global::Localization.ReportLocalizedResources.String1;
            this.fld_dteFrom.BOSPrivilege = global::Localization.ReportLocalizedResources.String1;
            this.fld_dteFrom.BOSPropertyName = "EditValue";
            this.fld_dteFrom.EditValue = null;
            resources.ApplyResources(this.fld_dteFrom, "fld_dteFrom");
            this.fld_dteFrom.Name = "fld_dteFrom";
            this.fld_dteFrom.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteFrom.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteFrom.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteFrom.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("fld_dteFrom.Properties.Buttons"))))});
            this.fld_dteFrom.Properties.DisplayFormat.FormatString = "MM/dd/yyyy";
            this.fld_dteFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteFrom.Properties.EditFormat.FormatString = "MM/dd/yyyy";
            this.fld_dteFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fld_dteFrom.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dteFrom, ((bool)(resources.GetObject("fld_dteFrom.ShowHelp"))));
            this.fld_dteFrom.Tag = "DC";
            // 
            // fld_btnShow
            // 
            this.fld_btnShow.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_btnShow.Appearance.Options.UseForeColor = true;
            this.fld_btnShow.BOSComment = global::Localization.ReportLocalizedResources.String1;
            this.fld_btnShow.BOSDataMember = global::Localization.ReportLocalizedResources.String1;
            this.fld_btnShow.BOSDataSource = global::Localization.ReportLocalizedResources.String1;
            this.fld_btnShow.BOSDescription = null;
            this.fld_btnShow.BOSError = null;
            this.fld_btnShow.BOSFieldGroup = global::Localization.ReportLocalizedResources.String1;
            this.fld_btnShow.BOSFieldRelation = global::Localization.ReportLocalizedResources.String1;
            this.fld_btnShow.BOSPrivilege = global::Localization.ReportLocalizedResources.String1;
            this.fld_btnShow.BOSPropertyName = global::Localization.ReportLocalizedResources.String1;
            resources.ApplyResources(this.fld_btnShow, "fld_btnShow");
            this.fld_btnShow.Name = "fld_btnShow";
            this.fld_btnShow.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_btnShow, ((bool)(resources.GetObject("fld_btnShow.ShowHelp"))));
            this.fld_btnShow.Tag = global::Localization.ReportLocalizedResources.String1;
            this.fld_btnShow.Click += new System.EventHandler(this.fld_btnShow_Click);
            // 
            // fld_lblLabel62
            // 
            this.fld_lblLabel62.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel62.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel62.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel62.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel62.BOSComment = global::Localization.ReportLocalizedResources.String1;
            this.fld_lblLabel62.BOSDataMember = global::Localization.ReportLocalizedResources.String1;
            this.fld_lblLabel62.BOSDataSource = global::Localization.ReportLocalizedResources.String1;
            this.fld_lblLabel62.BOSDescription = null;
            this.fld_lblLabel62.BOSError = null;
            this.fld_lblLabel62.BOSFieldGroup = global::Localization.ReportLocalizedResources.String1;
            this.fld_lblLabel62.BOSFieldRelation = global::Localization.ReportLocalizedResources.String1;
            this.fld_lblLabel62.BOSPrivilege = global::Localization.ReportLocalizedResources.String1;
            this.fld_lblLabel62.BOSPropertyName = global::Localization.ReportLocalizedResources.String1;
            resources.ApplyResources(this.fld_lblLabel62, "fld_lblLabel62");
            this.fld_lblLabel62.Name = "fld_lblLabel62";
            this.fld_lblLabel62.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lblLabel62, ((bool)(resources.GetObject("fld_lblLabel62.ShowHelp"))));
            this.fld_lblLabel62.Tag = global::Localization.ReportLocalizedResources.String1;
            // 
            // fld_lblLabel61
            // 
            this.fld_lblLabel61.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel61.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel61.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel61.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel61.BOSComment = global::Localization.ReportLocalizedResources.String1;
            this.fld_lblLabel61.BOSDataMember = global::Localization.ReportLocalizedResources.String1;
            this.fld_lblLabel61.BOSDataSource = global::Localization.ReportLocalizedResources.String1;
            this.fld_lblLabel61.BOSDescription = null;
            this.fld_lblLabel61.BOSError = null;
            this.fld_lblLabel61.BOSFieldGroup = global::Localization.ReportLocalizedResources.String1;
            this.fld_lblLabel61.BOSFieldRelation = global::Localization.ReportLocalizedResources.String1;
            this.fld_lblLabel61.BOSPrivilege = global::Localization.ReportLocalizedResources.String1;
            this.fld_lblLabel61.BOSPropertyName = global::Localization.ReportLocalizedResources.String1;
            resources.ApplyResources(this.fld_lblLabel61, "fld_lblLabel61");
            this.fld_lblLabel61.Name = "fld_lblLabel61";
            this.fld_lblLabel61.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lblLabel61, ((bool)(resources.GetObject("fld_lblLabel61.ShowHelp"))));
            this.fld_lblLabel61.Tag = global::Localization.ReportLocalizedResources.String1;
            // 
            // bosPanel1
            // 
            this.bosPanel1.BOSComment = null;
            this.bosPanel1.BOSDataMember = null;
            this.bosPanel1.BOSDataSource = null;
            this.bosPanel1.BOSDescription = null;
            this.bosPanel1.BOSError = null;
            this.bosPanel1.BOSFieldGroup = null;
            this.bosPanel1.BOSFieldRelation = null;
            this.bosPanel1.BOSPrivilege = null;
            this.bosPanel1.BOSPropertyName = null;
            this.bosPanel1.Controls.Add(this.fld_dteFrom);
            this.bosPanel1.Controls.Add(this.fld_lblLabel61);
            this.bosPanel1.Controls.Add(this.fld_lblLabel62);
            this.bosPanel1.Controls.Add(this.fld_tabHistory);
            this.bosPanel1.Controls.Add(this.fld_dteTo);
            this.bosPanel1.Controls.Add(this.fld_btnShow);
            resources.ApplyResources(this.bosPanel1, "bosPanel1");
            this.bosPanel1.Name = "bosPanel1";
            this.bosPanel1.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosPanel1, ((bool)(resources.GetObject("bosPanel1.ShowHelp"))));
            // 
            // DMSS103
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.bosPanel1);
            this.Name = "DMSS103";
            this.ScreenHelper.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.Controls.SetChildIndex(this.bosPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcGEHistoryDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvGEHistoryDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_tabHistory)).EndInit();
            this.fld_tabHistory.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRAllowances)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            this.fld_tapEvaluation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeEvaluations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRRewards)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRDisciplines)).EndInit();
            this.xtraTabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRAdvanceRequestItems)).EndInit();
            this.xtraTabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcARDeliverys)).EndInit();
            this.xtraTabPage7.ResumeLayout(false);
            this.fld_grpGroupControl15.ResumeLayout(false);
            this.fld_grpGroupControl15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtNormalLeaveDayRemains.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtOTLeaveDayRemains.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtBirthLeaveDayRemains.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtSickLeaveDayRemains.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtAnnualLeaveDayRemains.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtNormalLeaveDayOffs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtOTLeaveDayOffs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtBirthLeaveDayOffs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtSickLeaveDayOffs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtAnnualLeaveDayOffs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtNormalLeaveDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtOTLeaveDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtBirthLeaveDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtSickLeaveDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtAnnualLeaveDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRLeaveDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteFrom.Properties)).EndInit();
            this.bosPanel1.ResumeLayout(false);
            this.bosPanel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private IContainer components;
        private BOSComponent.BOSTabControl fld_tabHistory;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private BOSComponent.BOSDateEdit fld_dteTo;
        private BOSComponent.BOSDateEdit fld_dteFrom;
        private BOSComponent.BOSButton fld_btnShow;
        private BOSComponent.BOSLabel fld_lblLabel62;
        private BOSComponent.BOSLabel fld_lblLabel61;
        private DevExpress.XtraTab.XtraTabPage fld_tapEvaluation;
        private HREmployeeEvaluationsGridControl fld_dgcHREmployeeEvaluations;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private BOSComponent.BOSPanel bosPanel1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private HRRewardsGridControl fld_dgcHRRewards;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private HRDisciplinesGridControl fld_dgcHRDisciplines;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private HRAllowancesGridControl fld_dgcHRAllowances;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private AdvanceRequestItemsGridControl fld_dgcHRAdvanceRequestItems;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage6;
        private ARDeliverysGridControl fld_dgcARDeliverys;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage7;
        private HRLeaveDaysGridControl fld_dgcHRLeaveDays;
        private BOSComponent.BOSLine fld_grpGroupControl15;
        private BOSComponent.BOSTextBox fld_txtNormalLeaveDays;
        private BOSComponent.BOSTextBox fld_txtOTLeaveDays;
        private BOSComponent.BOSTextBox fld_txtBirthLeaveDays;
        private BOSComponent.BOSTextBox fld_txtSickLeaveDays;
        private BOSComponent.BOSTextBox fld_txtAnnualLeaveDays;
        private BOSComponent.BOSLabel bosLabel5;
        private BOSComponent.BOSLabel bosLabel4;
        private BOSComponent.BOSLabel bosLabel3;
        private BOSComponent.BOSLabel bosLabel2;
        private BOSComponent.BOSLabel bosLabel1;
        private BOSComponent.BOSTextBox fld_txtNormalLeaveDayOffs;
        private BOSComponent.BOSTextBox fld_txtOTLeaveDayOffs;
        private BOSComponent.BOSTextBox fld_txtBirthLeaveDayOffs;
        private BOSComponent.BOSTextBox fld_txtSickLeaveDayOffs;
        private BOSComponent.BOSTextBox fld_txtAnnualLeaveDayOffs;
        private BOSComponent.BOSLabel bosLabel7;
        private BOSComponent.BOSLabel bosLabel6;
        private BOSComponent.BOSLabel bosLabel8;
        private BOSComponent.BOSTextBox fld_txtNormalLeaveDayRemains;
        private BOSComponent.BOSTextBox fld_txtOTLeaveDayRemains;
        private BOSComponent.BOSTextBox fld_txtBirthLeaveDayRemains;
        private BOSComponent.BOSTextBox fld_txtSickLeaveDayRemains;
        private BOSComponent.BOSTextBox fld_txtAnnualLeaveDayRemains;
	}
}
