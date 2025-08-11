using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BOSCommon;
using System.Windows.Forms;
using Localization;

namespace BOSERP.Modules.Location
{
    public class LocationModule : BaseModuleERP
    {
        public LocationModule()
		{
			Name = "Location";
			CurrentModuleEntity = new LocationEntities();
			CurrentModuleEntity.Module = this;
			InitializeModule();
        }

        /// <summary>
        /// Add location to the location list
        /// </summary>
        public void AddLocation()
        {
            LocationEntities entity = (LocationEntities)CurrentModuleEntity;
            GELocationsInfo objLocationsInfo = (GELocationsInfo)entity.ModuleObjects[TableName.GELocationsTableName];
            int locationParentID = objLocationsInfo.GELocationID;
            entity.SetDefaultModuleObject(TableName.GELocationsTableName);            

            guiAddLocation addLocationForm = new guiAddLocation();
            addLocationForm.Module = this;
            if (addLocationForm.ShowDialog() == DialogResult.OK)
            {
                objLocationsInfo = (GELocationsInfo)entity.ModuleObjects[TableName.GELocationsTableName];
                objLocationsInfo.GELocationParentID = locationParentID;
                // Save the current location to database
                objLocationsInfo.GELocationID = entity.SaveLocation(objLocationsInfo);
                if (entity.LocationTreeList.CurrentObject.SubList == null)
                    entity.LocationTreeList.CurrentObject.SubList = new BOSTreeList();
                entity.LocationTreeList.CurrentObject.SubList.Add(objLocationsInfo);
                entity.LocationTreeList.TreeListControl.RefreshDataSource();
            }
        }       

        /// <summary>
        /// Edit location item from location tree list control
        /// </summary>
        public void EditLocation()
        {
            LocationEntities entity = (LocationEntities)CurrentModuleEntity;
            GELocationsInfo objLocationsInfo = (GELocationsInfo)entity.ModuleObjects[TableName.GELocationsTableName];
            guiAddLocation addLocationForm = new guiAddLocation();
            addLocationForm.Module = this;
            if (addLocationForm.ShowDialog() == DialogResult.OK)
            {
                entity.LocationTreeList.ChangeObjectFromList();
                entity.SaveLocation(objLocationsInfo);
            }
        }

        public void DeleteSelectedLocation()
        {
            if (MessageBox.Show(LocationLocalizedResources.ConfirmDeleteLocation, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LocationEntities entity = (LocationEntities)CurrentModuleEntity;
                GELocationsInfo objLocationsInfo = (GELocationsInfo)entity.ModuleObjects[TableName.GELocationsTableName];
                entity.LocationTreeList.RemoveSelectedRowObjectFromList();
                entity.DeleteSelectedItemFromLocationList(objLocationsInfo);
            }
        }

        /// <summary>
        /// Check whether the inputed location info is valid or not
        /// </summary>
        /// <returns>True if the location info is valid, otherwise false</returns>
        public bool CheckForValidLocation()
        {
            LocationEntities entity = (LocationEntities)CurrentModuleEntity;
            GELocationsInfo objLocationsInfo = (GELocationsInfo)entity.ModuleObjects[TableName.GELocationsTableName];
            if (string.IsNullOrEmpty(objLocationsInfo.GELocationName))
            {
                MessageBox.Show(LocationLocalizedResources.LocationNameIsNullErrorMessage, CommonLocalizedResources.MessageBoxDefaultCaption,
                                                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
