using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region ModuleTablesController
    /// <summary>
    /// This object represents the properties and methods of a ModuleTables.
    /// </summary>
    public class STModuleTablesController : BaseBusinessController
    {

        #region SP Name

        //Select By ForeignKey Queries
        private readonly string spGetSTModuleTablesBySTModuleID = "STModuleTables_SelectBySTModuleID";
        private readonly string spGetTablesOfSTModuleTablesBySTModuleID = "STModuleTables_SelectTablesOfSTModuleTablesBySTModuleID";
        private readonly string spGetTablesOfSTModuleTablesBySTModuleIDAndSTModuleTableName =
                               "STModuleTables_SelectTablesOfSTModuleTablesBySTModuleIDAndSTModuleTableName";
        private readonly string spGetTablesOfSTModuleTablesBySTModuleIDAndSTModuleTableLevelIndex =
                               "STModuleTables_SelectTablesOfSTModuleTablesBySTModuleIDAndSTModuleTableLevelIndex";
        private readonly string spGetMaxSTModuleTableLevelIndexOfTablesBySTModuleID =
                               "STModuleTables_SelectMaxSTModuleTableLevelIndexOfTablesBySTModuleID";
        private readonly string spGetViewsOfSTModuleTablesBySTModuleID = "STModuleTables_SelectViewsOfSTModuleTablesBySTModuleID";
        private readonly string spGetViewsOfSTModuleTablesBySTModuleIDAndSTModuleTableName =
                               "STModuleTables_SelectViewsOfSTModuleTablsBySTModuleIDAndSTModuleTableName";
        private readonly string spGetViewsOfSTModuleTablesBySTModuleIDAndSTModuleTableLevelIndex =
                               "STModuleTables_SelectViewsOfSTModuleTablesBySTModuleIDAndSTModuleTableLevelIndex";

        private readonly string spGetMaxSTModuleTableLevelIndexOfViewsBySTModuleID =
                               "STModuleTables_SelectMaxSTModuleTableLevelIndexOfViewsBySTModuleID";
        //Delete by foreignkey Queries

        
        private readonly string spDeleteSTModuleTablesBySTModuleID = "STModuleTables_DeleteBySTModuleID";

        #endregion
        public STModuleTablesController()
        {
            //dal = new STModuleTablesDAL();
            dal = new DALBaseProvider("STModuleTables", typeof(STModuleTablesInfo));
        }

        public DataSet GetModuleTablesByModuleID(int iModuleID)
        {
            return (DataSet)dal.GetDataSet(spGetSTModuleTablesBySTModuleID, iModuleID);
        }

        public DataSet GetTablesOfModuleTablesByModuleID(int iModuleID)
        {
            return (DataSet)dal.GetDataSet(spGetTablesOfSTModuleTablesBySTModuleID,
                                           iModuleID);
        }

        public DataSet GetViewsOfModuleTablesByModuleID(int iModuleID)
        {
            return (DataSet)dal.GetDataSet(spGetViewsOfSTModuleTablesBySTModuleID,
                                           iModuleID);
        }

        public STModuleTablesInfo GetTableOfModuleTablesByModuleIDAndTableName(int iModuleID, String strTableName)
        {
            return (STModuleTablesInfo)dal.GetDataObject(spGetTablesOfSTModuleTablesBySTModuleIDAndSTModuleTableName,
                                                         iModuleID, strTableName);
        }

        public STModuleTablesInfo GetViewOfModuleTablesByModuleIDAndTableName(int iModuleID, String strTableName)
        {
            return (STModuleTablesInfo)dal.GetDataObject(spGetViewsOfSTModuleTablesBySTModuleIDAndSTModuleTableName,
                                                         iModuleID, strTableName);
        }

        public DataSet GetTablesOfSTModuleTablesBySTModuleIDAndSTModuleTableLevelIndex(int iSTModuleID, int iSTModuleTableLevelIndex)
        {
            return (DataSet)dal.GetDataSet(spGetTablesOfSTModuleTablesBySTModuleIDAndSTModuleTableLevelIndex, iSTModuleID, iSTModuleTableLevelIndex);
        }

        public DataSet GetViewsOfSTModuleTablesBySTModuleIDAndSTModuleTableLevelIndex(int iSTModuleID, int iSTModuleTableLevelIndex)
        {
            return (DataSet)dal.GetDataSet(spGetViewsOfSTModuleTablesBySTModuleIDAndSTModuleTableLevelIndex, iSTModuleID, iSTModuleTableLevelIndex);
        }

        public int GetMaxLevelIndexOfTablesBySTModuleID(int iSTModuleID)
        {
            int iMaxTableLevelIndex = 0;
            try
            {
                DataSet ds = dal.GetDataSet(spGetMaxSTModuleTableLevelIndexOfTablesBySTModuleID, iSTModuleID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0][0] != null)
                            iMaxTableLevelIndex = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    }
                }
            }
            catch (Exception)
            {
                iMaxTableLevelIndex = 0;
            }
            return iMaxTableLevelIndex;

        }

        public int GetMaxLevelIndexOfViewsBySTModuleID(int iSTModuleID)
        {
            int iMaxViewLevelIndex = 0;
            try
            {
                DataSet ds = dal.GetDataSet(spGetMaxSTModuleTableLevelIndexOfViewsBySTModuleID, iSTModuleID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0][0] != null)
                            iMaxViewLevelIndex = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    }
                }
            }
            catch (Exception)
            {
                iMaxViewLevelIndex = 0;
            }
            return iMaxViewLevelIndex;
        }
        public void DeleteSTModuleTablesBySTModuleID(int iSTModuleID)
        {
            dal.GetDataSet(spDeleteSTModuleTablesBySTModuleID, iSTModuleID);
        }
    }
    #endregion
}
