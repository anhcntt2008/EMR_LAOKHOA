using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOSCommon;
using System.Data;

namespace BOSERP.Modules.Location
{
    public class LocationEntities : ERPModuleEntities
    {
        #region Properties
        /// <summary>
        /// Gets or sets location tree list
        /// </summary>
        public BOSTreeList LocationTreeList { get; set; }
        #endregion

        public LocationEntities()
            : base()
        {
            LocationTreeList = new BOSTreeList();
        }

        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.GELocationsTableName, new GELocationsInfo());
        }

        public override void InitModuleObjectList()
        {
            LocationTreeList.InitBOSList(this,
                                    String.Empty,
                                    TableName.GELocationsTableName,
                                    BOSTreeList.cstRelationNone);
        }

        public override void InitGridControlInBOSList()
        {
            LocationTreeList.InitBOSTreeListControl();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                LocationTreeList.SetDefaultListAndRefreshTreeListControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        /// <summary>
        /// Save location
        /// </summary>
        /// <param name="objLocationsInfo"></param>
        /// <returns></returns>
        public int SaveLocation(GELocationsInfo objLocationsInfo)
        {
            GELocationsController objLocationsController = new GELocationsController();
            int locationID = 0;
            if (objLocationsInfo.GELocationID == 0)
                locationID = objLocationsController.CreateObject(objLocationsInfo);
            else
                    locationID = objLocationsController.UpdateObject(objLocationsInfo);
            return locationID;
        }

        /// <summary>
        /// Delete selected item from location list
        /// </summary>
        /// <param name="objLocationsInfo"></param>
        public void DeleteSelectedItemFromLocationList(GELocationsInfo objLocationsInfo)
        {
            GELocationsController objLocationsController = new GELocationsController();
            objLocationsController.DeleteObject(objLocationsInfo.GELocationID);
        }
    }
}
