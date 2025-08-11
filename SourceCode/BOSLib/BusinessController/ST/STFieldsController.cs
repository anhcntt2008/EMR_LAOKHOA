using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BOSLib.DataAccess;
using System.Linq;

namespace BOSLib
{
    public class STFieldsController : BaseBusinessController
    {

        #region SP Name
        //Select By ForeignKey Queries
        private readonly string spGetSTFieldsBySTScreenID = "STFields_SelectBySTScreenID";

        /*Remove cause of not use
        private readonly string spGetSTFieldsBySTUserGroupID = "STFields_SelectBySTUserGroupID";*/

        //Select By all foreignkey query
        private readonly string spGetSTFieldsBySTUserGroupIDAndSTScreenID =
                               "STFields_SelectBySTUserGroupIDAndSTScreenID";
        private readonly string spGetActiveSTFieldsBySTUserGroupIDAndSTScreenID = "STFields_SelectActiveSTFieldsBySTUserGroupIDAndSTScreenID";
        //Select Query
        private readonly string spGetSTFieldsBySTFieldNameAndSTScreenID =
                               "STFields_SelectBySTFieldNameAndSTScreenID";
        private readonly string spGetSTFieldBySTFieldNameAndSTScreenIDAndSTUserGroupID =
                               "STFields_SelectBySTFieldNameAndSTScreenIDAndSTUserGroupID";
        private readonly string spGetSTFieldBySTScreenIDAndSTUserGroupIDAndSTFieldType =
                               "STFields_SelectBySTScreenIDAndSTUserGroupIDAndSTFieldType";
        private readonly string spGetSTFieldByModuleNameAndSTUserGroupIDAndSTFieldType =
                               "STFields_SelectBySTModuleNameAndSTUserGroupIDAndSTFieldType";

        private readonly string spGetSTFieldsBySTModuleIDAndSTUserGroupID =
                                "STFields_SelectBySTModuleIDAndSTUserGroupID";

        private readonly string spGetSTFieldBySTModuleIDAndSTUserGroupIDAndSTFieldTag =
                                "STFields_SelectBySTModuleIDAndSTUserGroupIDAndSTFieldTag";

        private readonly string spGetSTFieldBySTModuleIDAndSTUserGroupIDAndSTFieldGroup =
                                "STFields_SelectBySTModuleIDAndSTUserGroupIDAndSTFieldGroup";

        private readonly string spGetSTFieldBySTScreenIDAndSTUserGroupIDAndSTFieldTag =
                                "STFields_SelectBySTScreenIDAndSTUserGroupIDAndSTFieldTag";

        private readonly string spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldDataMember =
                                "STFields_SelectBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldDataMember";

        //private readonly string spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldDataMemberAndSTFieldType =
        //                        "STFields_SelectBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldDataMemberAndSTFieldType";

        private readonly string spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldDataMemberAndSTFieldTag =
                                "STFields_SelectBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldDataMemberAndSTFieldTag";

        private readonly string spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldDataMemberAndSTFieldGroup =
                                "STFields_SelectBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldDataMemberANDSTFieldGroup";

        private readonly string spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldType =
                                "STFields_SelectBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldType";

        private readonly string spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldTypeAndSTFieldTag =
                                "STFields_SelectBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldTypeAndSTFieldTag";

        private readonly string spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldName =
                                "STFields_SelectBySTModuleIDAndSTUserGroupIDAndSTFieldName";



        //Delete by foreignkey Queries
        private readonly string spDeleteSTFieldsBySTScreenID = "STFields_DeleteBySTScreenID";
        private readonly string spDeleteSTFieldsBySTScreenIDAndSTUserGroupID =
                                "STFields_DeleteBySTScreenIDAndSTUserGroupID";



        /*Remove cause of not use
        private readonly string spDeleteSTFieldsBySTUserGroupID = "STFields_DeleteBySTUserGroupID";*/

        #endregion

        public STFieldsController()
        {
            //dal = new STFieldsDAL();
            dal = new DALBaseProvider("STFields", typeof(STFieldsInfo));
        }

        public STFieldsInfo GetField(String strFieldName, int iScreenID)
        {
            return (STFieldsInfo)dal.GetDataObject(spGetSTFieldsBySTFieldNameAndSTScreenID, strFieldName, iScreenID);
        }

        public void DeleteFieldsByScreenID(int iScreenID)
        {
            dal.GetDataSet(spDeleteSTFieldsBySTScreenID, iScreenID);
        }


        public bool IsExist(String strFieldName, int iScreenID)
        {
            STFieldsInfo objSTFieldsInfo = new STFieldsInfo();
            objSTFieldsInfo = GetField(strFieldName, iScreenID);
            if (objSTFieldsInfo != null)
                return true;
            return false;
        }

        public DataSet GetFieldByScreenIDAndUserGroupID(int iScreenID, int iUserGroupID)
        {
            return (DataSet)dal.GetDataSet(spGetSTFieldsBySTUserGroupIDAndSTScreenID, iScreenID, iUserGroupID);
        }

        public DataSet GetActiveFieldsByScreenIDAndUserGroupID(int iScreenID, int iUserGroupID)
        {
            return (DataSet)dal.GetDataSet(spGetActiveSTFieldsBySTUserGroupIDAndSTScreenID, iScreenID, iUserGroupID);
        }

        public STFieldsInfo GetFieldByFieldNameAndScreenIDAndUserGroupID
                                         (String strFieldName, int iScreenID, int iUserGroupID)
        {

            return (STFieldsInfo)dal.GetDataObject(spGetSTFieldBySTFieldNameAndSTScreenIDAndSTUserGroupID,
                                                   iScreenID, iUserGroupID, strFieldName);
        }

        public DataSet GetFieldByScreenIDAndUserGroupIDAndFieldType(int iScreenID, int iUserGroupID, String strFieldType)
        {
            return (DataSet)dal.GetDataSet(spGetSTFieldBySTScreenIDAndSTUserGroupIDAndSTFieldType,
                                            iScreenID, iUserGroupID, strFieldType);
        }

        public DataSet GetFieldBySTModuleIDAndSTUserGroupID(int iSTModuleID, int iSTUserGroupID)
        {
            return (DataSet)dal.GetDataSet(spGetSTFieldsBySTModuleIDAndSTUserGroupID, iSTModuleID, iSTUserGroupID);
        }

        public DataSet GetFieldByModuleIDAndUserGroupIDAndFieldTag(int iModuleID, int iUserGroupID, String strFieldTag)
        {
            return (DataSet)dal.GetDataSet(spGetSTFieldBySTModuleIDAndSTUserGroupIDAndSTFieldTag, iModuleID, iUserGroupID, strFieldTag);
        }

        public DataSet GetFieldByModuleIDAndUserGroupIDAndFieldGroup(int iModuleID, int iUserGroupID, String strFieldGroup)
        {
            return (DataSet)dal.GetDataSet(spGetSTFieldBySTModuleIDAndSTUserGroupIDAndSTFieldGroup, iModuleID, iUserGroupID, strFieldGroup);
        }

        public DataSet GetFieldByScreenIDAndUserGroupIDAndFieldTag(int iModuleID, int iUserGroupID, String strFieldTag)
        {
            return (DataSet)dal.GetDataSet(spGetSTFieldBySTScreenIDAndSTUserGroupIDAndSTFieldTag, iModuleID, iUserGroupID, strFieldTag);
        }

        public DataSet GetFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldDataMember(
                        int iSTModuleID, int iSTUserGroupID, String strSTFieldDataSource, String strSTFieldDataMember)
        {
            return (DataSet)dal.GetDataSet(spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldDataMember,
                                            iSTModuleID, iSTUserGroupID, strSTFieldDataSource, strSTFieldDataMember);
        }

        public STFieldsInfo GetFirstFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldDataMember(
                                int iSTModuleID, int iSTUserGroupID, String strSTFieldDataSource, String strSTFieldDataMember)
        {
            return (STFieldsInfo)dal.GetDataObject(spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldDataMember,
                                                    iSTModuleID, iSTUserGroupID, strSTFieldDataSource, strSTFieldDataMember);
        }

        public DataSet GetFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldDataMemberAndFieldTag(
                                int iSTModuleID, int iSTUserGroupID, String strSTFieldDataSource,
                                String strSTFieldDataMember, String strSTFieldTag)
        {
            return (DataSet)dal.GetDataSet(spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldDataMemberAndSTFieldTag,
                                            iSTModuleID, iSTUserGroupID, strSTFieldDataSource,
                                            strSTFieldDataMember, strSTFieldTag);
        }

        public STFieldsInfo GetFirstFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldDataMemberAndFieldTag(
                                int iSTModuleID, int iSTUserGroupID, String strSTFieldDataSource,
                                String strSTFieldDataMember, String strSTFieldTag)
        {
            return (STFieldsInfo)dal.GetDataObject(spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldDataMemberAndSTFieldTag,
                                                    iSTModuleID, iSTUserGroupID, strSTFieldDataSource,
                                                    strSTFieldDataMember, strSTFieldTag);
        }

        public DataSet GetFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldDataMemberAndFieldGroup(
                                int iSTModuleID, int iSTUserGroupID, String strSTFieldDataSource,
                                String strSTFieldDataMember, String strSTFieldGroup)
        {
            return (DataSet)dal.GetDataSet(spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldDataMemberAndSTFieldGroup,
                                            iSTModuleID, iSTUserGroupID, strSTFieldDataSource, strSTFieldDataMember, strSTFieldGroup);
        }

        public STFieldsInfo GetFirstFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldDataMemberAndFieldGroup(
                                int iSTModuleID, int iSTUserGroupID, String strSTFieldDataSource,
                                String strSTFieldDataMember, String strSTFieldGroup)
        {
            return (STFieldsInfo)dal.GetDataObject(spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldDataMemberAndSTFieldGroup,
                                                    iSTModuleID, iSTUserGroupID, strSTFieldDataSource, strSTFieldDataMember,
                                                    strSTFieldGroup);
        }

        public DataSet GetFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldType(
                        int iSTModuleID, int iSTUserGroupID, String strSTFieldDataSource, String strSTFieldType)
        {
            return (DataSet)dal.GetDataSet(spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldType,
                                            iSTModuleID, iSTUserGroupID, strSTFieldDataSource, strSTFieldType);
        }

        public DataSet GetFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldTypeAndFieldTag(
                        int iSTModuleID, int iSTUserGroupID, String strSTFieldDataSource,
                        String strSTFieldType, String strSTFieldTag)
        {
            return (DataSet)dal.GetDataSet(spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldTypeAndSTFieldTag,
                                            iSTModuleID, iSTUserGroupID, strSTFieldDataSource, strSTFieldType, strSTFieldTag);
        }

        public STFieldsInfo GetFirstFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldTypeAndFieldTag(
                int iSTModuleID, int iSTUserGroupID, String strSTFieldDataSource,
                String strSTFieldType, String strSTFieldTag)
        {
            return (STFieldsInfo)dal.GetDataObject(spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldDataSourceAndSTFieldTypeAndSTFieldTag,
                                            iSTModuleID, iSTUserGroupID, strSTFieldDataSource, strSTFieldType, strSTFieldTag);
        }

        public STFieldsInfo GetFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldTypeAndFieldTagAndLikeFieldDataMember(
                        int iSTModuleID, int iSTUserGroupID, String strSTFieldDataSource,
                        String strSTFieldType, String strSTFieldTag, String strLikeSTFieldName)
        {
            DataSet ds = GetFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldTypeAndFieldTag(
                        iSTModuleID, iSTUserGroupID, strSTFieldDataSource,
                        strSTFieldType, strSTFieldTag);
            //STFieldsController objSTFieldsController = new STFieldsController();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                STFieldsInfo objSTFieldsInfo =
                    (STFieldsInfo)this.GetObjectFromDataRow(row);

                if (objSTFieldsInfo.STFieldName.Contains(strLikeSTFieldName))
                {
                    return objSTFieldsInfo;
                }
            }

            return null;
        }

        public DataSet GetFieldByModuleNameAndUserGroupIDAndFieldType(String strModuleName, int iUserGroupID, String strFieldType)
        {
            return (DataSet)dal.GetDataSet(spGetSTFieldByModuleNameAndSTUserGroupIDAndSTFieldType,
                                            strModuleName, iUserGroupID, strFieldType);
        }

        public STFieldsInfo GetFieldBySTModuleIDAndSTUserGroupIDAndSTFieldName(
                                int iSTModuleID, int iSTUserGroupID, String strSTFieldName)
        {
            return (STFieldsInfo)dal.GetDataObject(spGetSTFieldsBySTModuleIDAndSTUserGroupIDAndSTFieldName,
                                                    iSTModuleID, iSTUserGroupID, strSTFieldName);
        }

        public void DeleteSTFieldsBySTScreenIDAndSTUserGroupID(int iSTScreenID, int iSTUserGroupID)
        {
            dal.GetDataSet(spDeleteSTFieldsBySTScreenIDAndSTUserGroupID, iSTScreenID, iSTUserGroupID);
        }

        public virtual DataSet GetFields()
        {
            var strQuery = String.Format("SELECT * FROM STFields");
            return dal.GetDataSet(strQuery);
        }

        public STFieldsInfo GetFieldByFieldNameAndFieldGroup(String fieldName, String fieldGroup)
        {
            if (SystemMemCache.STFields != null)
            {
                var sql = $"STFieldName = '{fieldName}' AND STFieldGroup = '{fieldGroup}'";
                var rows = SystemMemCache.STFields.Select(sql);
                if (rows.Count() > 0)
                    return (STFieldsInfo)GetObjectFromDataRow(rows[0]);
                else
                    return null;
            }
            else
            {
                String query = String.Format("SELECT * FROM STFields WHERE STFieldName = '{0}' AND STFieldGroup = '{1}'", fieldName, fieldGroup);
                DataSet ds = GetDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                    return (STFieldsInfo)GetObjectFromDataRow(ds.Tables[0].Rows[0]);
                else
                    return null;
            }
        }

        public STFieldsInfo GetFieldByFieldNameAndScreenID(String fieldName, int screenID)
        {
            String query = String.Format("SELECT * FROM STFields WHERE STFieldName = '{0}' AND STScreenID = {1}", fieldName, screenID);
            DataSet ds = GetDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
                return (STFieldsInfo)GetObjectFromDataRow(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        public DataSet GetFieldsByScreenIDAndFieldGroup(int screenID, String fieldGroup)
        {
            String query = String.Format("SELECT * FROM STFields WHERE STScreenID = {0} AND STFieldGroup = '{1}'", screenID, fieldGroup);
            return GetDataSet(query);
        }

        public STFieldsInfo GetFieldByFieldNameAndModuleID(String fieldName, int screenID)
        {
            DataSet ds = dal.GetDataSet("STFields_GetFieldByFieldNameAndModuleID", fieldName, screenID);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                STFieldsInfo objFieldsInfo = (STFieldsInfo)GetObjectFromDataRow(ds.Tables[0].Rows[0]);
                return objFieldsInfo;
            }
            return null;
        }

        /// <summary>
        /// Update all fields of a screen on given values
        /// </summary>
        /// <param name="visible">STFieldVisible, pass null to skip it</param>
        /// <returns></returns>
        public void UpdateByScreenID(int screenID, bool visible)
        {
            dal.ExecuteStoredProcedure("STFields_UpdateByScreenID", screenID, visible);
        }

        /// <summary>
        /// Get field list based on some criteria.
        /// Pass null to any parameter that you want to skip
        /// </summary>        
        public DataSet GetFieldList(int? moduleID,
                                    int? screenID,
                                    int? fieldID,
                                    String fieldName,
                                    String fieldType,
                                    String fieldGroup,
                                    String fieldTag,
                                    String fieldDataSource,
                                    String fieldDataMember)

        {
            DataSet ds = dal.GetDataSet("STFields_GetFieldList",
                                        moduleID,
                                        screenID,
                                        fieldID,
                                        fieldName,
                                        fieldType,
                                        fieldGroup,
                                        fieldTag,
                                        fieldDataSource,
                                        fieldDataMember);
            return ds;
        }

        public DataSet GetAllFieldsByModuleID(int moduleID)
        {
            DataSet ds = GetFieldList(moduleID, null, null, null, null, null, null, null, null);
            return ds;
        }

        /// <summary>
        /// Get all fields of a screen
        /// </summary>
        /// <param name="screenID">Screen ID</param>
        /// <returns>List of fields</returns>
        public List<STFieldsInfo> GetAllFieldsByScreenID(int screenID)
        {
            DataSet ds = GetFieldList(null, screenID, null, null, null, null, null, null, null);
            List<STFieldsInfo> result = new List<STFieldsInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    STFieldsInfo objFieldsInfo = (STFieldsInfo)GetObjectFromDataRow(row);
                    result.Add(objFieldsInfo);
                }
            }
            return result;
        }
    }
}
