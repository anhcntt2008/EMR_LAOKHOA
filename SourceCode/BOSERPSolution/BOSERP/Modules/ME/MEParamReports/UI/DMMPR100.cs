using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using System.Linq;
using Localization;

namespace BOSERP.Modules.MEParamReports.UI
{
	/// <summary>
	/// Summary description for DMMP100
	/// </summary>
	public partial class DMMPR100 : BOSERPScreen
	{

		public DMMPR100()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}
        private void DMMPR100_Load(object sender, EventArgs e)
        {

        }
        private void fld_lkeFK_MEEmrTypeIDRelation_EditValueChanged(object sender, EventArgs e)
        {
            var lke = (BOSComponent.BOSLookupEdit)sender;
            #region Params
            var paramsList = new List<MEParamsInfo>();
            paramsList.Insert(0, new MEParamsInfo
            {
                MEParamNo = string.Empty
            });
            fld_lkeMEParamReportMap.Properties.DataSource = paramsList;
            fld_lkeMEParamReportMap2.Properties.DataSource = paramsList;
            fld_lkeMEParamReportMap3.Properties.DataSource = paramsList;
            #endregion

            var templateList = new List<METemplatesInfo>();
            templateList.Insert(0, new METemplatesInfo
            {
                METemplateID = 0
            });
            if ((lke.EditValue != null && (int)lke.EditValue <= 0) || (lke.EditValue != null && string.IsNullOrEmpty(lke.EditValue.ToString())))
            {
                fld_lkeFK_METemplateIDRelation.Properties.DataSource = templateList;
                fld_lkeFK_METemplateIDRelation2.Properties.DataSource = templateList;
                fld_lkeFK_METemplateIDRelation3.Properties.DataSource = templateList;
                fld_lkeMEParamReportMap.EditValue = string.Empty;
                fld_lkeMEParamReportMap2.EditValue = string.Empty;
                fld_lkeMEParamReportMap3.EditValue = string.Empty;
                return;
            }
            ((MEParamReportsModule)Module).ChangeEmrTypeRelation((int)lke.EditValue);
            //fld_lkeFK_METemplateIDRelation.EditValue = string.Empty;
            //fld_lkeFK_METemplateIDRelation2.EditValue = string.Empty;
            //fld_lkeFK_METemplateIDRelation3.EditValue = string.Empty;
            //fld_lkeMEParamReportMap.EditValue = string.Empty;
            //fld_lkeMEParamReportMap2.EditValue = string.Empty;
            //fld_lkeMEParamReportMap3.EditValue = string.Empty;
        }
        private void fld_lkeFK_METemplateIDRelation_EditValueChanged(object sender, EventArgs e)
        {
            var lke = (BOSComponent.BOSLookupEdit)sender;
            var paramsList = new List<MEParamsInfo>();
            paramsList.Insert(0, new MEParamsInfo
            {
                MEParamNo = string.Empty
            });
            if (string.IsNullOrEmpty(lke.EditValue.ToString()) || (lke.EditValue != null && (int)lke.EditValue <= 0))
            {
                fld_lkeMEParamReportMap.Properties.DataSource = paramsList;
                return;
            }
            ((MEParamReportsModule)Module).ChangeTemplateRelation((int)lke.EditValue, "fld_lkeMEParamReportMap");
        }
        private void fld_lkeFK_METemplateIDRelation2_EditValueChanged(object sender, EventArgs e)
        {
            var lke = (BOSComponent.BOSLookupEdit)sender;
            var paramsList = new List<MEParamsInfo>();
            paramsList.Insert(0, new MEParamsInfo
            {
                MEParamNo = string.Empty
            });
            if (string.IsNullOrEmpty(lke.EditValue.ToString()) || (lke.EditValue != null && (int)lke.EditValue <= 0))
            {
                fld_lkeMEParamReportMap2.Properties.DataSource = paramsList;
                return;
            }
            ((MEParamReportsModule)Module).ChangeTemplateRelation((int)lke.EditValue, "fld_lkeMEParamReportMap2");
        }
        private void fld_lkeFK_METemplateIDRelation3_EditValueChanged(object sender, EventArgs e)
        {
            var lke = (BOSComponent.BOSLookupEdit)sender;
            var paramsList = new List<MEParamsInfo>();
            paramsList.Insert(0, new MEParamsInfo
            {
                MEParamNo = string.Empty
            });
            if (string.IsNullOrEmpty(lke.EditValue.ToString()) || (lke.EditValue != null && (int)lke.EditValue <= 0))
            {
                fld_lkeMEParamReportMap3.Properties.DataSource = paramsList;
                return;
            }
            ((MEParamReportsModule)Module).ChangeTemplateRelation((int)lke.EditValue, "fld_lkeMEParamReportMap3");
        }
        private void fld_btnUpdateRelation_Click(object sender, EventArgs e)
        {
            var typeId = fld_lkeFK_MEEmrTypeIDRelation.EditValue != null ? (int)fld_lkeFK_MEEmrTypeIDRelation.EditValue : 0;
            var templateId = fld_lkeFK_METemplateIDRelation.EditValue != null ? (int)fld_lkeFK_METemplateIDRelation.EditValue : 0;
            var paramMap = fld_lkeMEParamReportMap.EditValue != null ? (string)fld_lkeMEParamReportMap.EditValue : string.Empty;
            var templateId2 = fld_lkeFK_METemplateIDRelation2.EditValue != null ? (int)fld_lkeFK_METemplateIDRelation2.EditValue : 0;
            var paramMap2 = fld_lkeMEParamReportMap2.EditValue != null ? (string)fld_lkeMEParamReportMap2.EditValue : string.Empty;
            var templateId3 = fld_lkeFK_METemplateIDRelation3.EditValue != null ? (int)fld_lkeFK_METemplateIDRelation3.EditValue : 0;
            var paramMap3 = fld_lkeMEParamReportMap3.EditValue != null ? (string)fld_lkeMEParamReportMap3.EditValue : string.Empty;
            var encode = fld_lkeMEParamReportRelationEncode.EditValue != null ? (string)fld_lkeMEParamReportRelationEncode.EditValue : string.Empty;
            var encode2 = string.Empty;
            var encode3 = string.Empty;
            var filter = fld_txtMEParamReportMapFilter.EditValue != null ? (string)fld_txtMEParamReportMapFilter.EditValue : string.Empty;
            var filter2 = string.Empty;
            var filter3 = string.Empty;
            if (typeId <= 0)
            {
                MessageBox.Show("Vui lòng gán giá trị Loại bệnh án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (templateId <= 0)
            {
                MessageBox.Show("Vui lòng gán giá trị Mẫu bệnh án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(paramMap))
            {
                MessageBox.Show("Vui lòng gán giá trị Thẻ dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if ((templateId2 == 0 && !string.IsNullOrEmpty(paramMap2)) || (templateId2 > 0 && string.IsNullOrEmpty(paramMap2)))
            {
                MessageBox.Show("Mẫu bệnh án 2 và thẻ dữ liệu 2 phải đồng thời có giá trị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if ((templateId3 == 0 && !string.IsNullOrEmpty(paramMap3))||(templateId3 > 0 && string.IsNullOrEmpty(paramMap3)))
            {
                MessageBox.Show("Mẫu bệnh án 3 và thẻ dữ liệu 3 phải đồng thời có giá trị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            // default value
            var xml = fld_chkMEParamReportRelationXML.EditValue != null ? (bool)fld_chkMEParamReportRelationXML.EditValue : true;
            var xmlOrder = fld_txtMEParamReportRelationXMLOrder.EditValue != null ? Convert.ToInt32(fld_txtMEParamReportRelationXMLOrder.EditValue.ToString()) : 1;
            var xmlGroup = 1; 
            var xmlLevel = 1;
            ((MEParamReportsModule)Module).AddEmrTypeToRelation(new MEParamReportRelationsInfo
            {
                FK_MEEmrTypeID = typeId,
                FK_METemplateID = templateId,
                MEParamReportMap = paramMap,
                MEParamReportRelationXML = xml,
                MEParamReportRelationXMLGroup = xmlGroup,
                MEParamReportRelationXMLLevel = xmlLevel,
                MEParamReportRelationXMLOrder = xmlOrder,
                FK_METemplateID2 = templateId2,
                MEParamReportMap2 = paramMap2,
                FK_METemplateID3 = templateId3,
                MEParamReportMap3 = paramMap3,
                MEParamReportRelationEncode = encode,
                MEParamReportRelationEncode2 = encode2,
                MEParamReportRelationEncode3 = encode3,
                MEParamReportMapFilter = filter,
                MEParamReportMapFilter2 = filter2,
                MEParamReportMapFilter3 = filter3,
            });
        }
        private void fld_btnRemoveRelation_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)this.fld_dgcMEParamReportRelations.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var paramReportRelation = gridView.GetRow(gridView.FocusedRowHandle) as MEParamReportRelationsInfo;
            // Load data;
            fld_lkeFK_MEEmrTypeIDRelation.EditValue = paramReportRelation.FK_MEEmrTypeID;
            ((MEParamReportsModule)Module).ChangeEmrTypeRelation(paramReportRelation.FK_MEEmrTypeID);
            fld_lkeFK_METemplateIDRelation.EditValue = paramReportRelation.FK_METemplateID;
            fld_lkeFK_METemplateIDRelation2.EditValue = paramReportRelation.FK_METemplateID2;
            fld_lkeFK_METemplateIDRelation3.EditValue = paramReportRelation.FK_METemplateID3;
            
            ((MEParamReportsModule)Module).ChangeTemplateRelation(paramReportRelation.FK_METemplateID, "fld_lkeMEParamReportMap");
            ((MEParamReportsModule)Module).ChangeTemplateRelation(paramReportRelation.FK_METemplateID2, "fld_lkeMEParamReportMap2");
            ((MEParamReportsModule)Module).ChangeTemplateRelation(paramReportRelation.FK_METemplateID3, "fld_lkeMEParamReportMap3");
            fld_lkeMEParamReportMap.EditValue = paramReportRelation.MEParamReportMap;
            fld_lkeMEParamReportMap2.EditValue = paramReportRelation.MEParamReportMap2;
            fld_lkeMEParamReportMap3.EditValue = paramReportRelation.MEParamReportMap3;

            fld_lkeMEParamReportRelationEncode.EditValue = paramReportRelation.MEParamReportRelationEncode;
            fld_txtMEParamReportMapFilter.EditValue = paramReportRelation.MEParamReportMapFilter;

            fld_chkMEParamReportRelationXML.EditValue = paramReportRelation.MEParamReportRelationXML;
            fld_txtMEParamReportRelationXMLOrder.EditValue = paramReportRelation.MEParamReportRelationXMLOrder;

            ((MEParamReportsModule)Module).RemoveItemFromRelationList(paramReportRelation);
        }
    }
}
