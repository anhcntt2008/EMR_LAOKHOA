using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;


namespace BOSLib
{
    public class GETempUtility
    {
        private const String GETempTable = "GETemps";
        public static void ChangeTableGETemp(String strColumnName, String strDbType, object objValue)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            //If Column is already exist,update value
            if (dbUtil.ColumnIsExist(GETempTable, strColumnName))
            {

                UpdateColumnValueToGETempTable(strColumnName, objValue);
            }
            //If Column is not exist,create column and add value
            else
            {
                AddColumnToGETempTable(strColumnName, strDbType);
                UpdateColumnValueToGETempTable(strColumnName, objValue);
            }

        }

        public static object GetColumnValueFromGETempTable(String strColumnName)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            String strPrimaryColumn = dbUtil.GetTablePrimaryColumn(GETempTable);
            if (dbUtil.ColumnIsExist(GETempTable, strColumnName))
            {
                String strGetColumnQuery = String.Format("SELECT {0} FROM {1} WHERE {2}=1", strColumnName, GETempTable, strPrimaryColumn);
                DataSet ds = dbUtil.ExecuteQuery(strGetColumnQuery);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0].Rows[0][strColumnName];
                    }
                }
            }
            return null;
        }

        private static void UpdateColumnValueToGETempTable(String strColumnName, object objValue)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            String strUpdateQuery = String.Format("UPDATE [GETemps] SET [{0}]='{1}' WHERE [GETempID]=1", strColumnName, objValue);
            dbUtil.ExecuteQuery(strUpdateQuery);
        }

        private static void AddColumnToGETempTable(String strColumnName, String strDbType)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            String strAddColumnQuery = String.Format("ALTER TABLE GETemps ADD {0} {1} NULL", strColumnName, strDbType);
            dbUtil.ExecuteQuery(strAddColumnQuery);
        }
       

    }
}
