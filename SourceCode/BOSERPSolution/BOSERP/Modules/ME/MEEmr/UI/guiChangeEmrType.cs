using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.MEEmr;
using DevExpress.XtraGrid.Views.Grid;
using Clas.Emr.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using BOSCommon;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using System.Drawing.Drawing2D;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using BOSComponent;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiChangeEmrType : BOSERPScreen
    {
        private readonly int _emrID;
        private readonly MEEmrTypeTemplatesController _emrTypeTemplatesCtrl;
        private readonly METemplateIndexsController _emrTemplateIndexsCtrl;

        public List<MEEmrDocumentsInfo> LastDocuments { get; private set; }
        public List<MEEmrTypeTemplatesInfo> MappingList { get; private set; }
        public int FK_MEEmrTypeID { get; private set; }
        public IOrderedEnumerable<METemplateIndexsInfo> TemplateIndexs { get; private set; }

        public guiChangeEmrType(int emrID)
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            _emrID = emrID;
            _emrTypeTemplatesCtrl = new MEEmrTypeTemplatesController();
            _emrTemplateIndexsCtrl = new METemplateIndexsController();
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                Ok();
            }
        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            var grid = this.grcDocumentGroupMapping.MainView as GridView;
            grid.OptionsBehavior.Editable = true;
            grid.OptionsView.ShowGroupPanel = false;
            grid.OptionsView.ShowIndicator = true;
            grid.OptionsView.ColumnAutoWidth = false;
            grid.OptionsView.ShowDetailButtons = false;
            grid.OptionsNavigation.EnterMoveNextColumn = true;
            grid.OptionsSelection.EnableAppearanceFocusedCell = false;
            grid.OptionsNavigation.UseTabKey = false;

            var column = new GridColumn
            {
                Caption = "Thứ tự gáy cũ",
                FieldName = "MEEmrTypeTemplateOrder",
                VisibleIndex = 0,
                Width = 100,
                SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            };
            column.OptionsColumn.AllowEdit = false;
            grid.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "Gáy bệnh án cũ",
                FieldName = "MEEmrTypeTemplateGroup",
                VisibleIndex = 0,
                Width = 350
            };
            column.OptionsColumn.AllowEdit = false;
            grid.Columns.Add(column);

            var repoSelectNewIndex = new RepositoryItemBOSLookupEdit
            {
                TextEditStyle = TextEditStyles.Standard,
                SearchMode = SearchMode.AutoFilter,
                NullText = string.Empty,
                BestFitMode = BestFitMode.BestFitResizePopup,
                ValueMember = "METemplateIndexID",
                DisplayMember = "METemplateIndexName",
                Tag = "MEEmrTypeTemplateGroups"
            };
            var colName = new LookUpColumnInfo
            {
                Caption = "Thứ tự",
                FieldName = "METemplateIndexOrder",
                Width = 80
            };
            repoSelectNewIndex.Columns.Add(colName);
            colName = new LookUpColumnInfo
            {
                Caption = "Gáy",
                FieldName = repoSelectNewIndex.DisplayMember,
                Width = 350
            };
            repoSelectNewIndex.Columns.Add(colName);

            column = new GridColumn
            {
                Caption = "Gáy bệnh án mới",
                FieldName = "MEEmrTypeTemplateGroupNewID",
                VisibleIndex = 1,
                Width = 350,
                ColumnEdit = repoSelectNewIndex
            };
            column.OptionsColumn.AllowEdit = true;
            grid.Columns.Add(column);

            var documents = (new MEEmrDocumentsController()).GetByEmrId(_emrID);
            MappingList = new List<MEEmrTypeTemplatesInfo>();
            foreach (var item in documents)
            {
                if (!MappingList.Any(t => t.MEEmrTypeTemplateGroup == item.MEEmrDocumentGroup))
                {
                    MappingList.Add(new MEEmrTypeTemplatesInfo()
                    {
                        MEEmrTypeTemplateOrder = item.MEEmrDocumentOrder,
                        MEEmrTypeTemplateGroup = item.MEEmrDocumentGroup,
                        FK_METemplateID = item.FK_METemplateID
                    });
                }
            }
            this.grcDocumentGroupMapping.DataSource = MappingList;
            this.grcDocumentGroupMapping.RefreshDataSource();
            this.grcDocumentGroupMapping.Refresh();
            //grid.BestFitColumns();

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void fld_lkeFK_MEEmrTypeID_ChangeEmr_EditValueChanged(object sender, EventArgs e)
        {
            int type = 0;
            if (int.TryParse(fld_lkeFK_MEEmrTypeID_ChangeEmr.EditValue.ToString(), out type))
            {
                TemplateIndexs = _emrTemplateIndexsCtrl.GetByEmrType(type).OrderBy(t => t.METemplateIndexOrder);
                var grid = this.grcDocumentGroupMapping.MainView as GridView;
                var colEdit = grid.Columns["MEEmrTypeTemplateGroupNewID"].ColumnEdit as RepositoryItemBOSLookupEdit;
                if (colEdit != null)
                {
                    colEdit.DataSource = TemplateIndexs;
                }
                FK_MEEmrTypeID = type;

                //auto map by template
                var typeTemplates = _emrTypeTemplatesCtrl.GetAllByEmrTypeID(type);
                foreach (var group in MappingList)
                {
                    var typeTempl = typeTemplates.Where(t => t.FK_METemplateID == group.FK_METemplateID).FirstOrDefault();
                    if (typeTempl == null) continue;
                    var templIndexs = TemplateIndexs.Where(t => t.METemplateIndexID == typeTempl.FK_METemplateIndexID).FirstOrDefault();
                    if (templIndexs == null) continue;
                    group.MEEmrTypeTemplateGroupNewID = templIndexs.METemplateIndexID;
                }
                grcDocumentGroupMapping.RefreshDataSource();
            }
            else
            {
                TemplateIndexs = null;
                FK_MEEmrTypeID = 0;
            }
        }

        public void Ok()
        {
            LastDocuments = (new MEEmrDocumentsController()).GetByEmrId(_emrID);
            var empCtrl = new HREmployeesController();
            var templateCtrl = new METemplatesController();
            if (FK_MEEmrTypeID <= 0)
            {
                MessageBox.Show($"Vui lòng chọn loại bệnh án mới và" +
                           $" ánh xạ toàn bộ gáy qua loại bệnh án mới", "Chọn loại bệnh án mới", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            foreach (var map in MappingList)
            {
                if (map.MEEmrTypeTemplateGroupNewID == 0)
                {
                    MessageBox.Show($"Dòng {map.MEEmrTypeTemplateOrder}. {map.MEEmrTypeTemplateGroup} chưa được ánh xạ. " +
                        $"Vui lòng ánh xạ toàn bộ gáy qua loại bệnh án mới", "Chưa ánh xạ hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            //ensure not any user edits currently on this emr
            foreach (var document in LastDocuments)
            {
                if (document.FK_EditingUserID > 0
                    && document.FK_EditingUserID != BOSApp.CurrentUsersInfo.FK_HREmployeeID)
                {
                    var emp = empCtrl.GetObjectByID(document.FK_EditingUserID) as HREmployeesInfo;
                    var template = templateCtrl.GetObjectByID(document.FK_METemplateID) as METemplatesInfo;
                    MessageBox.Show($"Tờ bệnh án {document.MEEmrDocumentSubOrder}. {template.METemplateName} đang được sửa bởi {emp.HREmployeeName} tại máy {document.MEEmrDocumentHoldMachineIp}." +
                        "\nKhông thể đổi loại bệnh án khi có người khác đang sửa trên bệnh án này.",
                        "Tờ bệnh án đang được sửa bởi người khác", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
