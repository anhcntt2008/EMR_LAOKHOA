using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BOSComponent;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using Localization;
using DevExpress.XtraTreeList.Columns;
using System.Data;
using BOSCommon;
using System.Drawing;
using BOSLib;

namespace BOSERP
{
    public partial class GELocationsTreeListControl : BOSTreeListControl
    {
        public override void InitializeControl()
        {
            base.InitializeControl();
            this.ExpandAll();
        }        

        public override void InitTreeListColumns(string strTableName)
        {
            base.InitTreeListColumns(strTableName);

            TreeListColumn column = Columns["GELocationName"];
            column.VisibleIndex = 1;
            column.OptionsColumn.AllowEdit = false;

            column = Columns["Selected"];
            column.Caption = CommonLocalizedResources.Selected;
            column.VisibleIndex = 2;
            column.OptionsColumn.AllowEdit = true;
        }
    }
}
