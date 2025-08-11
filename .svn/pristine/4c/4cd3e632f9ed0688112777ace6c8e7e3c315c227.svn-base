using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOSERP.Modules.Product;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace BOSERP
{
    public partial class guiMeasureUnit : BOSERPScreen
    {
        public guiMeasureUnit()
        {
            InitializeComponent();
        }

        public guiMeasureUnit(ICProductsInfo productObject, BOSList<ICProductUnitsInfo> lstICProductUnits)
        {
            InitializeComponent();
        }

        private void guiMeasureUnit_Load(object sender, EventArgs e)
        {
            ProductEntities entity = (ProductEntities)((ProductModule)Module).CurrentModuleEntity;
            fld_dgcICProductUnits.Screen = this;
            fld_dgcICProductUnits.InitializeControl();
            entity.ICProductUnitsList.InitBOSListGridControl(fld_dgcICProductUnits);

            BindingSource bds = new BindingSource();
            bds.DataSource = entity.ICProductUnitsList;
            fld_dgcICProductUnits.DataSource = bds;

            GridView gridView = (GridView)fld_dgcICProductUnits.MainView;
            gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(GridView_CellValueChanged);
            gridView.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(GridView_ValidatingEditor);
            gridView.KeyUp += new KeyEventHandler(GridView_KeyUp);
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            foreach (GridColumn column in gridView.Columns)
            {
                column.OptionsColumn.AllowEdit = true;
            }
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Update regular price when the factor is changed.
        /// </summary>
        private void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "ICProductUnitFactor")
            {
                ProductEntities entity = (ProductEntities)((ProductModule)Module).CurrentModuleEntity;
                ICProductsInfo objProductsInfo = (ICProductsInfo)entity.MainObject;
                GridView gridView = (GridView)sender;
                ICProductUnitsInfo objProductUnitsInfo = (ICProductUnitsInfo)gridView.GetRow(e.RowHandle);
                objProductUnitsInfo.ICProductUnitPrice = objProductsInfo.ICProductPrice01 * objProductUnitsInfo.ICProductUnitFactor;
            }
        }

        private void GridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            ProductEntities entity = (ProductEntities)((ProductModule)Module).CurrentModuleEntity;
            GridView gridView = (GridView)sender;
            if (gridView.FocusedRowHandle >= 0)
            {
                ICProductUnitsInfo objProductUnitsInfo = (ICProductUnitsInfo)gridView.GetRow(gridView.FocusedRowHandle);
                if (objProductUnitsInfo.ICProductUnitIsBasic)
                {
                    e.ErrorText = "Basic unit can not be changed.";
                    e.Valid = false;
                }

                if (entity.ICProductUnitsList.Exists("FK_ICMeasureUnitID", e.Value))
                {
                    e.ErrorText = "This unit already exists.";
                    e.Valid = false;
                }
            }
        }

        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ((ProductModule)Module).DeleteSelectedUnit();
            }
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
