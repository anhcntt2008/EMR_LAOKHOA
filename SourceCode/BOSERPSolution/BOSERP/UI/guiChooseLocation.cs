using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BOSLib;
using DevExpress.XtraGrid.Views.Grid;
using BOSCommon;
using Localization;
using DevExpress.XtraTreeList.Nodes;
using BOSComponent;
using BOSLib;

namespace BOSERP
{
    public partial class guiChooseLocation : BOSERPScreen
    {
        /// <summary>
        /// A variable to store ID of the previous selected location
        /// </summary>
        private int LocationID;

        /// <summary>
        /// Gets or sets the tree list binded to the location tree list control
        /// </summary>
        public BOSTreeList LocationTreeList { get; set; }

        public guiChooseLocation()
        {
            InitializeComponent();
            LocationTreeList = new BOSTreeList();
        }

        public guiChooseLocation(int locationID)
        {
            InitializeComponent();
            LocationID = locationID;
            LocationTreeList = new BOSTreeList();            
        }

        private void guiChooseLocation_Load(object sender, EventArgs e)
        {
            InitializeControls(Controls);

            BOSTreeList dataSource = new BOSTreeList();
            dataSource.Add(new GELocationsInfo(LocationLocalizedResources.LocationName));
            GELocationsController objLocationsController = new GELocationsController();
            DataSet ds = objLocationsController.GetAllParentOjects();
            LocationTreeList.InitBOSList(null, string.Empty, TableName.GELocationsTableName);
            LocationTreeList.Invalidate(ds);
            dataSource[0].SubList = LocationTreeList;
            LocationTreeList.TreeListControl = fld_trlGELocations;
            fld_trlGELocations.DataSource = dataSource;
            fld_trlGELocations.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(fld_trlGELocations_CellValueChanging);
            
            CheckPreviousLocation();
            fld_trlGELocations.ExpandAll();
            fld_lkeGELocationID.EditValue = LocationID;
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

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Check the previous selected location
        /// </summary>
        private void CheckPreviousLocation()
        {
            BOSTreeListObject obj = LocationTreeList.GetObjectByPropertyNameAndValue("GELocationID", LocationID);
            if (obj != null)
            {
                obj.Selected = true;
                fld_trlGELocations.RefreshDataSource();
            }
        }

        private void fld_trlGELocations_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Selected")
            {
                BOSTreeListObject currentObject = LocationTreeList.CurrentObject;
                if (currentObject != null && !currentObject.Selected)
                {
                    LocationTreeList.SetValueToList("Selected", false);
                    currentObject.Selected = true;
                    fld_trlGELocations.RefreshDataSource();
                }
            }
        }

        private void fld_lkeGELocationID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            BOSLookupEdit lke = (BOSLookupEdit)sender;
            if (e.Value != null && e.Value != lke.OldEditValue)
            {
                int locationID = Convert.ToInt32(e.Value);
                GELocationsController objLocationsController = new GELocationsController();
                GELocationsInfo objLocationsInfo = (GELocationsInfo)objLocationsController.GetObjectByID(locationID);
                if (objLocationsInfo != null)
                {
                    if (objLocationsInfo.GELocationID != LocationID)
                    {
                        LocationID = objLocationsInfo.GELocationID;
                        fld_lkeGELocationID.EditValue = objLocationsInfo.GELocationID;
                    }

                    LocationTreeList.SetValueToList("Selected", false);
                    objLocationsInfo = (GELocationsInfo)LocationTreeList.GetObjectByPropertyNameAndValue("GELocationID", locationID);
                    if (objLocationsInfo != null)
                    {
                        objLocationsInfo.Selected = true;
                    }
                    fld_trlGELocations.RefreshDataSource();
                }
            }
        }
    }
}
