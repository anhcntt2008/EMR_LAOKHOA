using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BOSERP.Modules.METemplate;
using DevExpress.XtraGrid.Views.Grid;
using Localization;

namespace BOSERP.Modules.METemplate.UI
{
    public partial class DMMETE102 : BOSERPScreen
    {
        public DMMETE102()
        {
            InitializeComponent();
        }

        private void btnEditChartSeries_Click(object sender, EventArgs e)
        {
            if ((((METemplateModule)Module).CurrentModuleEntity as METemplateEntities).METemplateParamList.Count == 0)
            {
                MessageBox.Show("Mẫu không có thẻ dữ liệu. Thực hiện lưu mẫu trước khi thực hiện thao tác này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ((METemplateModule)Module).InvalidateChartSeries();
            MessageBox.Show("Thực hiện cấu hình và bấm 'Lưu Series'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveChartSeries_Click(object sender, EventArgs e)
        {
            ((METemplateModule)Module).SaveChartSeries();
            MessageBox.Show("Đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnConfigChart_Click(object sender, EventArgs e)
        {
            ((METemplateModule)Module).ConfigChart();
        }

        private void btnClearConfig_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa cấu hình biểu đồ đang chọn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                ((METemplateModule)Module).ClearConfigChart();
        }
    }
}