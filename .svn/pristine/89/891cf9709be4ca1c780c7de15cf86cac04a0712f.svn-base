using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace BOSLib
{
    public class ADModuleFieldsToUsersController : BaseBusinessController
    {
        public ADModuleFieldsToUsersController()
        {
            dal = new DALBaseProvider("ADModuleFieldsToUsers", typeof(ADModuleFieldsToUsersInfo));
        }

        public DataSet GetFieldsByUserIDAndModuleIDAndScreenNumber(int iUserID, int iModuleID, String strScreenNumber)
        {
            DbCommand cmd = SqlDatabaseHelper.GetStoredProcedure("ADModuleFieldsToUsers_SelectByUserIDAndModuleIDAndScreenNumber");
            SqlDatabaseHelper.AddInParameter(cmd, "ADUserID", SqlDbType.Int, iUserID);
            SqlDatabaseHelper.AddInParameter(cmd, "STModuleID", SqlDbType.Int, iModuleID);
            SqlDatabaseHelper.AddInParameter(cmd, "ADModuleFieldsToUserScreenNumber", SqlDbType.VarChar, strScreenNumber);
            return SqlDatabaseHelper.RunStoredProcedure(cmd);
        }
    }
}
