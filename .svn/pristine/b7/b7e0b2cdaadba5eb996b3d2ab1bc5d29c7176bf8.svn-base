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

namespace BOSERP.Modules.MEEmrType.UI
{
    public partial class guiUpdateEmrsTemplate : BOSERPScreen
    {
        private readonly int _typeID;
        private MEEmrDocumentsController _documentCtrl;
        private METemplateIndexsController _templateIndexsCtrl;
        private MEEmrTypeTemplatesController _typeTemplateCtrl;
        public int METemplateIndexOrder { get; private set; }
        public string METemplateIndexName { get; private set; }

        public List<METemplateIndexsInfo> MappingList { get; private set; }

        public guiUpdateEmrsTemplate(int typeID)
        {
            InitializeComponent();
            _typeID = typeID;
            KeyDown += new KeyEventHandler(Ok_KeyDown);
            _documentCtrl = new MEEmrDocumentsController();
            _templateIndexsCtrl = new METemplateIndexsController();
            _typeTemplateCtrl = new MEEmrTypeTemplatesController();
        }
        private void UpdateTemplate_Load(object sender, EventArgs e)
        {
            var newTemplateIndexs = _templateIndexsCtrl.GetListBusinessObjects<METemplateIndexsInfo>(_templateIndexsCtrl.GetAllDataByForeignColumn("FK_MEEmrTypeID", _typeID));
            this.KeyPreview = true;
            var grid = this.grcTemplateIndexGroupMapping.MainView as GridView;
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
                FieldName = "METemplateIndexOrder",
                VisibleIndex = 0,
                Width = 100,
                SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            };
            column.OptionsColumn.AllowEdit = false;
            grid.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "Gáy bệnh án cũ",
                FieldName = "METemplateIndexName",
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
                Tag = "METemplateIndexGroups",
                DataSource = newTemplateIndexs
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
                Caption = "Gáy mới",
                FieldName = "METemplateIndexIDNew",
                VisibleIndex = 1,
                Width = 350,
                ColumnEdit = repoSelectNewIndex
            };
            column.OptionsColumn.AllowEdit = true;
            grid.Columns.Add(column);

            var documents = _documentCtrl.GetAllDistinctByType(_typeID);
            MappingList = new List<METemplateIndexsInfo>();
            foreach (var document in documents)
            {
                if (!MappingList.Any(t => t.METemplateIndexName == document.MEEmrDocumentGroup))
                {
                    var templateIndex = new METemplateIndexsInfo()
                    {
                        METemplateIndexOrder = document.MEEmrDocumentOrder,
                        METemplateIndexName = document.MEEmrDocumentGroup
                    };
                    var typeTemplate = _typeTemplateCtrl.GetObjectByTypeAndTemplateIndex(_typeID, document.FK_METemplateID);
                    if (typeTemplate != null)
                    {
                        templateIndex.METemplateIndexID = typeTemplate.FK_METemplateIndexID;
                    }
                    MappingList.Add(templateIndex);
                }
            }

            this.grcTemplateIndexGroupMapping.DataSource = MappingList;
            //auto map by template
            foreach (var group in MappingList)
            {
                if (group.METemplateIndexID == 0) continue;
                var templIndexs = newTemplateIndexs.Where(t => t.METemplateIndexID == group.METemplateIndexID).FirstOrDefault();
                if (templIndexs == null) continue;
                group.METemplateIndexIDNew = templIndexs.METemplateIndexID;
            }

            this.grcTemplateIndexGroupMapping.RefreshDataSource();
            this.grcTemplateIndexGroupMapping.Refresh();
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                Ok();
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        public void Ok()
        {
            foreach (var map in MappingList)
            {
                if (map.METemplateIndexIDNew == 0)
                {
                    MessageBox.Show($"Dòng {map.METemplateIndexOrder}. {map.METemplateIndexName} chưa được ánh xạ. " +
                        $"Vui lòng ánh xạ toàn bộ qua gáy mới", "Chưa ánh xạ hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
