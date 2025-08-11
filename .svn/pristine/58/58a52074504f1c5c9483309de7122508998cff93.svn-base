using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Localization;
using DevExpress.XtraGrid.Views.Base;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BOSLib;

namespace BOSERP.Modules.MEEmr
{
    public partial class MEEmrDocumentsForNotificationGridControl : BOSGridControl
    {
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            //string sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
            GridColumn columnDate = gridView.Columns["MEEmrDocumentCreatedDate"];
            if (columnDate != null)
            {
                columnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                //columnDate.DisplayFormat.FormatString = $"{sysUIFormat} HH:mm";
                columnDate.DisplayFormat.FormatString = $"dd/MM/yyyy HH:mm";
                columnDate.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            }
            return gridView;
        }
    }
}
