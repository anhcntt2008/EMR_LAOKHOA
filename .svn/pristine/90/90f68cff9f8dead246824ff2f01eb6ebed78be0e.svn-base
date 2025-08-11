using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Localization;
using DevExpress.XtraGrid.Views.Grid;

namespace BOSERP
{
    public partial class guiChooseBranch : BOSERPScreen
    {
        #region Variable
        /// <summary>
        /// A variable to store branch list binded to the grid control
        /// </summary>
        private List<BRBranchsInfo> Branches;

        /// <summary>
        /// A variable to store previous selected branch id
        /// </summary>
        private int SelectedBranchID = 0;        
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the selected branch
        /// </summary>
        public BRBranchsInfo SelectedBranch { get; set; }

        /// <summary>
        /// Gets or sets a value indicates the selected branch is set as default
        /// </summary>
        public bool IsDefaultBranch { get; set; }
        #endregion

        public guiChooseBranch()
        {
            InitializeComponent();
            Branches = new List<BRBranchsInfo>();
        }

        public guiChooseBranch(int selectedBranchID)
        {
            InitializeComponent();

            Branches = new List<BRBranchsInfo>();
            SelectedBranchID = selectedBranchID;
        }

        public override void InitializeControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                InitializeControl(ctrl);
                if (ctrl.Controls.Count > 0)
                {
                    InitializeControls(ctrl.Controls);
                }
            }
        }

        private void guiChooseBranch_Load(object sender, EventArgs e)
        {
            InitializeControls(Controls);

            BRBranchsController objBranchsController = new BRBranchsController();
            DataSet ds = objBranchsController.GetAllObjects();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    BRBranchsInfo objBranchsInfo = (BRBranchsInfo)objBranchsController.GetObjectFromDataRow(row);
                    Branches.Add(objBranchsInfo);
                }
            }
            fld_dgcBranchs.DataSource = Branches;
            
            if (SelectedBranchID > 0)
            {
                BRBranchsInfo objBranchsInfo = Branches.Where(b => b.BRBranchID == SelectedBranchID).FirstOrDefault();
                if (objBranchsInfo != null)
                {
                    objBranchsInfo.Selected = true;
                    fld_dgcBranchs.RefreshDataSource();
                }
                IsDefaultBranch = true;
            }

            fld_chkIsDefault.Checked = IsDefaultBranch;

            GridView gridView = (GridView)fld_dgcBranchs.MainView;
            gridView.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(GridView_CellValueChanging);
        }

        private void fld_btnChoose_Click(object sender, EventArgs e)
        {
            SelectedBranch = Branches.Where(b => b.Selected == true).FirstOrDefault();
            IsDefaultBranch = fld_chkIsDefault.Checked;
            if (SelectedBranch == null)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseBranchMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void GridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Selected")
            {
                if (e.Value != null)
                {
                    bool isSelected = Convert.ToBoolean(e.Value);
                    if (isSelected)
                    {
                        foreach (BRBranchsInfo objBranchsInfo in Branches)
                        {
                            objBranchsInfo.Selected = false;
                        }

                        GridView gridView = (GridView)fld_dgcBranchs.MainView;
                        BRBranchsInfo objSelectedBranchsInfo = (BRBranchsInfo)gridView.GetRow(e.RowHandle);
                        objSelectedBranchsInfo.Selected = true;
                        fld_dgcBranchs.RefreshDataSource();
                    }
                }
            }
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
