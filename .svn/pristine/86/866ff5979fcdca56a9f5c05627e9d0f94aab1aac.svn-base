using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOSComponent;
using System.Windows.Forms;
using BOSERP.Modules.METemplate;
using DevExpress.XtraGrid.Views.Grid;
using BOSCommon;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using Localization;

namespace BOSERP.Modules.MENotification
{
    public partial class MEEmrActionsGridControl : BOSGridControl
    {
        #region Public Properties
        #endregion

        public override void InitGridControlDataSource()
        {
            METemplateEntities entity = (METemplateEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEEmrActionList;
            this.DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridview = base.InitializeGridView();
            gridview.OptionsView.ShowAutoFilterRow = true;
            return gridview;
        }

    }
}
