using System;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace BOSERP.Modules.MEEmrAction.UI
{
    public partial class guiMEEmrActionSelection : BOSERPScreen
    {
        private readonly MEEmrTemplateActionsController _emrTemplateActionsCtrl;
        private readonly METemplatesController _templateCtrl;
        public int SelectedActionID { get; private set; }
        public int SelectedEmrID { get; private set; }
        private int _templateID;
        private string _templateName;

        public guiMEEmrActionSelection(int TemplateID)
        {
            InitializeComponent();
            _emrTemplateActionsCtrl = new MEEmrTemplateActionsController();
            _templateCtrl = new METemplatesController();
            _templateID = TemplateID;
        }

        private void guiSelectEmrRelation_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.InitializeControls(this.Controls);
            LoadMEEmrActions();
            LoadMETemplate();
            this.Text = "Danh sách thẻ chức năng của mẫu " + _templateName;
        }

        private void LoadMETemplate()
        {
            var ds = _templateCtrl.GetObjectByID(_templateID);
            _templateName = (ds as METemplatesInfo).METemplateName;
        }

        private void LoadMEEmrActions()
        {
            var ds = _emrTemplateActionsCtrl.GetAllDataByForeignColumn("FK_METemplateID", _templateID);
            fld_dgcMEEmrTemplateActions.DataSource = ds.Tables[0];
            fld_dgcMEEmrTemplateActions.RefreshDataSource();
        }

        private void guiSelectEmrRelation_btnOk_Click(object sender, EventArgs e)
        {
            var grid = (fld_dgcMEEmrTemplateActions.MainView as GridView);
            if (grid.FocusedRowHandle >= 0)
            {
                var row = grid.GetDataRow(grid.FocusedRowHandle) as DataRow;
                if (row == null)
                {
                    MessageBox.Show("Vui lòng kiểm tra dữ liệu trên lưới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.SelectedActionID = 0;
                DialogResult = DialogResult.OK;
                this.SelectedActionID = Convert.ToInt32(row["FK_MEEmrActionID"].ToString());
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 dòng?", "Chọn thẻ chức năng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void guiSelectEmrRelation_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
