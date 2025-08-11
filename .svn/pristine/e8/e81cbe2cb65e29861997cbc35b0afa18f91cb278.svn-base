using System;
using System.Data;
using System.Collections;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Emr;

namespace BOSLib
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class ADUsersController : BaseBusinessController
    {

        #region SP Name        

        //Select By ForeignKey Stored Procedure
        private readonly string spGetADUsersByADUserGroupID = "ADUsers_SelectByADUserGroupID";

        /*Remove cause of not use
        private readonly string spGetADUsersByADContactID = "ADUsers_SelectByADContactID";*/

        //Select By all foreignkey Stored Procedure

        /*Remove cause of not use
        private readonly string spGetADUsersByADUserGroupIDAndADContactID = "ADUsers_SelectByADUserGroupIDAndADContactID";

        //Delete by foreignkey Stored Procedure
        private readonly string spDeleteADUsersByADUserGroupID = "ADUsers_DeleteByADUserGroupID";
        private readonly string spDeleteADUsersByADContactID = "ADUsers_DeleteByADContactID";*/

        #endregion

        public ADUsersController()
        {
            dal = new DALBaseProvider("ADUsers", typeof(ADUsersInfo));
        }
        public int CreateUser(ADUsersInfo objADUsersInfo)
        {
            byte[] passwordBytes = SHA1Managed.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes(objADUsersInfo.ADPassword));
            objADUsersInfo.ADPassword = Convert.ToBase64String(passwordBytes);
            objADUsersInfo.ADUserID = dal.GetNextID();
            return dal.CreateObject(objADUsersInfo);
        }

        public int UpdateUser(ADUsersInfo objADUsersInfo, bool bChange)
        {
            ADUsersController objUsersController = new ADUsersController();
            ADUsersInfo existingUser = (ADUsersInfo)objUsersController.GetObjectByID(objADUsersInfo.ADUserID);

            if (!string.IsNullOrEmpty(objADUsersInfo.ADPassword))
            {
                byte[] passwordBytes = SHA1Managed.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes(objADUsersInfo.ADPassword));
                if (bChange)
                {
                    objADUsersInfo.ADPassword = Convert.ToBase64String(passwordBytes);
                }
            }
            else
            {
                if (existingUser != null)
                {
                    objADUsersInfo.ADPassword = existingUser.ADPassword;
                }
            }

            if (!string.IsNullOrEmpty(objADUsersInfo.ADUserCaPasscode))
            {
                objADUsersInfo.ADUserCaPasscode = Cryptographier.Encrypt(objADUsersInfo.ADUserCaPasscode);
            }
            else
            {
                if (existingUser != null)
                {
                    objADUsersInfo.ADUserCaPasscode = existingUser.ADUserCaPasscode;
                }
            }
            return dal.UpdateObject(objADUsersInfo);
        }

        public int GetUserGroupOfUser(int iADUserID)
        {
            var objAdUsersInfo = (ADUsersInfo)GetObjectByID(iADUserID);
            return objAdUsersInfo.ADUserGroupID;
        }

        public int GetUserGroupOfUser(String strUserName, int branchId)
        {
            var listAll = GetListBusinessObjects().Cast<ADUsersInfo>();
            var listUser = listAll.Where(x => x.ADUserName == strUserName).ToList();
            if (listUser.Count == 0)
                return 0;
            return listUser.FirstOrDefault(x => x.ADUserBranchId == branchId)?.ADUserGroupID ??
                   listUser.First().ADUserGroupID;
            //            ADUsersInfo objADUsersInfo = new ADUsersInfo();
            //            objADUsersInfo = (ADUsersInfo)GetObjectByName(strUserName);
            //            if (objADUsersInfo != null)
            //                return objADUsersInfo.ADUserGroupID;
            //            return 0;
        }

        public DataSet GetAllUserByUserGroupID(int iADUserGroupID)
        {
            return (DataSet)dal.GetDataSet(spGetADUsersByADUserGroupID, iADUserGroupID);
        }

        public void CheckChangedPassword(string userName, string password)
        {
            var q = $"SELECT * FROM ADUsers WHERE ADUserName='{userName}'";
            var ds = dal.GetDataSet(q);
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) return;
            var passwordBytes = SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(password));
            var newPassword = Convert.ToBase64String(passwordBytes);
            var row = (ADUsersInfo)GetObjectFromDataRow(ds.Tables[0].Rows[0]);
            if (row.ADPassword == newPassword) return;
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                var u = (ADUsersInfo)GetObjectFromDataRow(dataRow);
                u.ADPassword = newPassword;
                dal.UpdateObject(u);
            }

        }

        public DataSet GetAllUserNotUserSystem(string userNames)
        {
            String query = String.Format("select * from ADUsers where AAStatus = 'Alive' and ADUserName not in ({0})", userNames);
            return dal.GetDataSet(query);
        }
    }
}
