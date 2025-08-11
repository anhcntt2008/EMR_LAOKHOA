using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;



namespace BOSLib
{
    #region STStoredProceduresController

    public class STStoredProceduresController : BaseBusinessController
    {
        #region Query Declaration

        /*Remove cause of not use
        private readonly string spGetSTStoredProceduresByName = "STStoredProcedures_SelectByName";*/
         
        private readonly string spGetSTStoredProceduresBySTTableName = "STStoredProcedures_SelectBySTTableName";
        private readonly string cmdGetSTStoredProceduresByStatusAndPrevStatus =
            "SELECT * FROM [dbo].[STStoredProcedures] WHERE " +
            "([STStoredProcedureStatus] LIKE @STStoredProcedureStatus+'%')" +
            "AND([STStoredProcedurePreviousStatus] LIKE @STStoredProcedurePreviousStatus+'%')";

        private readonly string cmdSearchSTStoredProcedures =
            "SELECT * FROM [dbo].[STStoredProcedures] WHERE " +
            "([STStoredProcedureName] LIKE @STStoredProcedureName+'%')" +
            "AND ([STTableName] LIKE @STTableName +'%')" +
            "AND ([STStoredProcedureMatchCode1] LIKE @STStoredProcedureMatchCode1+'%')" +
            "AND ([STStoredProcedureMatchCode2] LIKE @STStoredProcedureMatchCode2+'%')" +
            "AND ([STStoredProcedureMatchCode3] LIKE @STStoredProcedureMatchCode3+'%')" +
            "AND ([STStoredProcedureMatchCode4] LIKE @STStoredProcedureMatchCode4+'%')" +
            "AND ([STStoredProcedureStatus] LIKE @STStoredProcedureStatus+'%')" +
            "AND ([STStoredProcedurePreviousStatus] LIKE @STStoredProcedurePreviousStatus+'%')" +
            "AND ([STStoredProcedureText] LIKE '%'+@STStoredProcedureText+'%')";

        #endregion

        public STStoredProceduresController()
        {
            //dal = new STStoredProceduresDAL();
            dal = new DALBaseProvider("STStoredProcedures", typeof(STStoredProceduresInfo));
        }
        
        public DataSet GetSTStoredProceduresBySTTableName(String strSTTableName)
        {
            return (DataSet)dal.GetDataSet(spGetSTStoredProceduresBySTTableName, strSTTableName);
        }

        public DataSet GetSTStoredProceduresByStatusAndPrevStatus(String strStatus, String strPrevStatus)
        {
            DbCommand cmd = SqlDatabaseHelper.GetQuery(cmdGetSTStoredProceduresByStatusAndPrevStatus);
            SqlDatabaseHelper.AddInParameter(cmd, "STStoredProcedureStatus", SqlDbType.NVarChar, strStatus);
            SqlDatabaseHelper.AddInParameter(cmd, "STStoredProcedurePreviousStatus", SqlDbType.NVarChar, strPrevStatus);
            return SqlDatabaseHelper.RunQuery(cmd);
        }

        public DataSet SearchSTStoredProcedures(STStoredProceduresInfo objSTStoredProcedureInfo)
        {
            DbCommand cmd = SqlDatabaseHelper.GetQuery(cmdSearchSTStoredProcedures);
            SqlDatabaseHelper.AddParameterForObject(objSTStoredProcedureInfo, dal, cmd);
            return SqlDatabaseHelper.RunQuery(cmd);
        }

    }
    #endregion
}
