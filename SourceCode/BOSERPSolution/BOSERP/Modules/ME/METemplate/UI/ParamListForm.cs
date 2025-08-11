using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace BOSERP.Modules.METemplate.UI
{
    public partial class ParamListForm : Form
    {
        public ParamListForm()
        {
            InitializeComponent();
            var col = this.treeList1.Columns.Add();
            col.Visible = true;
            col.Width = 200;
            col.FieldName = col.Name = "Tên thẻ";

            var col2= this.treeList1.Columns.Add();
            col2.Visible = true;
            col2.Width = 200;
            col2.FieldName = col2.Name = "Tiêu đề thẻ";

            var col3 = this.treeList1.Columns.Add();
            col3.Visible = true;
            col3.FieldName = col3.Name = "Loại thẻ";

            var col4 = this.treeList1.Columns.Add();
            col4.Visible = true;
            col4.Width = 200;
            col4.FieldName = col4.Name = "Mã thẻ";

            var col5 = this.treeList1.Columns.Add();
            col5.Visible = true;
            col5.FieldName = col5.Name = "Giá trị mặc định";

            var col6 = this.treeList1.Columns.Add();
            col6.Visible = true;
            col6.FieldName = col6.Name = "Giá trị nhỏ nhất";

            var col7 = this.treeList1.Columns.Add();
            col7.Visible = true;
            col7.FieldName = col6.Name = "Giá trị lớn nhất";

            var col8 = this.treeList1.Columns.Add();
            col8.Visible = true;
            col8.FieldName = col6.Name = "Đơn vị";

            var col9 = this.treeList1.Columns.Add();
            col9.Visible = true;
            col9.FieldName = col6.Name = "Định dạng dữ liệu";

            var col10 = this.treeList1.Columns.Add();
            col10.Visible = true;
            col10.FieldName = col6.Name = "Định dạng";

            var col11 = this.treeList1.Columns.Add();
            col11.Visible = true;
            col11.FieldName = col6.Name = "Loại control";

            var col12 = this.treeList1.Columns.Add();
            col12.Visible = true;
            col12.FieldName = col6.Name = "Không in ra";
        }

        public TreeList GetTreeList()
        {
            return this.treeList1;
        }

        private void ParamListForm_Load(object sender, EventArgs e)
        {

        }
    }
}
