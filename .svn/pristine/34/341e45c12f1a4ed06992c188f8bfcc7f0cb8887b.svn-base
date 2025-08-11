using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Collections;


namespace BOSLib
{
    public class BaseBusinessController
    {
        protected DALBaseProvider dal;

        #region Constructor
        public BaseBusinessController()
        {
            dal = new DALBaseProvider();
        }

        public BaseBusinessController(String strTableName, Type objType)
        {
            dal = new DALBaseProvider(strTableName, objType);
        }

        public BaseBusinessController(Type objType)
        {
            string strTableName = objType.Name.Substring(0, objType.Name.Length - 4);
            dal = new DALBaseProvider(strTableName, objType);
        }
        #endregion

        #region Utility Functions
        //public int GetNextID()
        //{
        //    return dal.GetMaxID() + 1;
        //}

        #endregion

        #region Functions for Create,Update,Delete
        public virtual int CreateObject(BusinessObject obj)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            DateTime createdDate = dbUtil.GetCurrentServerDate();
            dbUtil.SetPropertyValue(obj, "AACreatedDate", createdDate);
            dbUtil.SetPropertyValue(obj, "AAUpdatedDate", createdDate); // XuanTM
            int id = dal.GetNextID();
            int tryTimes = 1;
            dal.SetValueToPrimaryColumn(obj, id);
            // avoid loop indefinitely
            while (tryTimes <= 100)
            {
                try
                {
                    return dal.CreateObject(obj);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    //2627 violation of PRIMARY KEY constraint
                    if (ex.Number == 2627 && tryTimes < 100)
                    {
                        id = dal.GetNextID(id);
                        dal.SetValueToPrimaryColumn(obj, id);
                        tryTimes++;
                    }
                    else throw;
                }
            }
            // TODO testing carefully
            return 0;
        }

        public virtual int CreateObject(BusinessObject obj, int iObjectID)
        {
            if (IsExist(iObjectID))
                return -1;

            dal.SetValueToPrimaryColumn(obj, iObjectID);
            return dal.CreateObject(obj);
        }

        public virtual int CreateObject(BusinessObject obj, DbTransaction transaction)
        {
            dal.SetValueToPrimaryColumn(obj, dal.GetNextID());
            return dal.CreateObject(obj, transaction);
        }

        public virtual int UpdateObject(BusinessObject obj)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            DateTime updatedDate = dbUtil.GetCurrentServerDate();
            dbUtil.SetPropertyValue(obj, "AAUpdatedDate", updatedDate);
            return dal.UpdateObject(obj);
        }

        public virtual int UpdateObject(BusinessObject obj, DbTransaction transaction)
        {
            return dal.UpdateObject(obj, transaction);
        }

        public virtual void DeleteObject(int iObjectID)
        {
            dal.DeleteObject(iObjectID);
        }

        public virtual void DeleteObject(int iObjectID, DbTransaction transaction)
        {
            dal.DeleteObject(iObjectID, transaction);
        }

        public void DeleteAllObjects()
        {
            dal.DeleteAllObjects();
        }

        public virtual void DeleteByForeignColumn(String strForeignColumn, object objForeignColumnValue)
        {
            dal.DeleteByForeignColumn(strForeignColumn, objForeignColumnValue);
        }


        #endregion

        #region Functions for Get Object

        public virtual object GetTemplateObject()
        {
            return dal.GetTemplateObject();
        }
        public virtual object GetObjectByID(int iObjectID)
        {
            return dal.GetObjectById(iObjectID);
        }

        public virtual DataSet GetDataSetByID(int iObjectID)
        {
            return dal.GetDataSetByID(iObjectID);
        }

        public virtual object GetDeletedObjectByID(int iObjectID)
        {
            return dal.GetDeletedObjectByID(iObjectID);
        }

        public virtual String GetObjectNameByID(int iObjectID)
        {
            return dal.GetObjectNameByID(iObjectID);
        }

        public virtual String GetObjectNoByID(int iObjectID)
        {
            return dal.GetObjectNoByID(iObjectID);
        }

        public virtual object GetObjectByName(String strObjectName)
        {
            return dal.GetObjectByName(strObjectName);
        }

        public virtual object GetObjectByNo(String strObjectNo)
        {
            return dal.GetObjectByNo(strObjectNo);
        }

        public virtual object GetObjectByAANumberInt(int iAANumberInt)
        {
            return dal.GetObjectByAANumberInt(iAANumberInt);
        }

        public virtual int GetObjectIDByName(String strObjectName)
        {
            return dal.GetObjectIDByName(strObjectName);
        }

        public virtual int GetObjectIDByNo(String strObjectNo)
        {
            return dal.GetObjectIDByNo(strObjectNo);
        }

        public virtual DataSet GetAllObjects()
        {
            return dal.GetAllObject();
        }

        public virtual DataSet GetAllProfileObjects()
        {
            return dal.GetAllProfileObjects();
        }

        public virtual DataSet GetAllAliveObjects()
        {
            return dal.GetAllAliveObjects();
        }

        public virtual DataSet GetObjectsForDataLookup(String[] arrColumns, int iMaxResults)
        {
            String strQuery = String.Format("Select TOP({0}) ", iMaxResults);
            foreach (String strColumn in arrColumns)
            {
                strQuery += String.Format("[{0}],", strColumn);
            }
            strQuery = strQuery.Remove(strQuery.Length - 1, 1);
            strQuery += String.Format(" FROM [{0}] WHERE [AAStatus]='Alive'", dal.TableName);
            DbCommand cmd = SqlDatabaseHelper.GetQuery(strQuery);
            return (DataSet)SqlDatabaseHelper.RunQuery(cmd);
        }

        public virtual DataSet GetObjectsByIDForDataLookup(String[] arrColumns, int iObjectID)
        {
            String strQuery = "Select ";
            String strPrimaryColumn = new BOSDbUtil().GetTablePrimaryColumn(dal.TableName);

            foreach (String strColumn in arrColumns)
            {
                strQuery += String.Format("[{0}],", strColumn);
            }
            strQuery = strQuery.Remove(strQuery.Length - 1, 1);
            strQuery += String.Format(" FROM [{0}] WHERE [{1}]={2} AND [AAStatus]='Alive'", dal.TableName, strPrimaryColumn, iObjectID);
            DbCommand cmd = SqlDatabaseHelper.GetQuery(strQuery);
            return (DataSet)SqlDatabaseHelper.RunQuery(cmd);
        }

        public virtual DataSet GetObjectsForDataLookup(String[] arrColumns, int iMaxResults, String strCondition)
        {
            String strQuery = String.Format("Select TOP({0}) ", iMaxResults);
            foreach (String strColumn in arrColumns)
            {
                strQuery += String.Format("[{0}],", strColumn);
            }
            strQuery = strQuery.Remove(strQuery.Length - 1, 1);
            strQuery += String.Format(" FROM [{0}] WHERE [AAStatus]='Alive'", dal.TableName);
            strQuery += " AND " + strCondition;

            DbCommand cmd = SqlDatabaseHelper.GetQuery(strQuery);
            return (DataSet)SqlDatabaseHelper.RunQuery(cmd);
        }


        /// <summary>
        /// Get Data Set by Query Command
        /// </summary>
        /// <param name="strQuery"></param>
        /// <returns></returns>
        public virtual DataSet GetDataSet(String strQuery)
        {
            return (DataSet)dal.GetDataSet(strQuery);
        }
        public virtual DataSet GetDataSet(string spName, params object[] paramValues)
        {
            return (DataSet)dal.GetDataSet(spName, paramValues);
        }
        /// <summary>
        /// Get an object by a stored procedure and param values
        /// </summary>
        /// <param name="spName">Stored procedure name</param>
        /// <param name="values">Parameter values</param>
        /// <returns>Object</returns>
        public virtual object GetDataObject(string spName, params object[] values)
        {
            return dal.GetDataObject(spName, values);
        }

        /// <summary>
        /// Convert a data set to a list
        /// </summary>
        /// <param name="ds">Given data set</param>
        /// <returns>List contains data</returns>
        public virtual IList GetListFromDataSet(DataSet ds)
        {
            return null;
        }

        public virtual object GetFirstObject()
        {
            return dal.GetFirstObject();
        }

        public virtual int GetFirstObjectID()
        {
            try
            {
                object obj = GetFirstObject();
                if (obj != null)
                    return Convert.ToInt32(dal.GetPrimaryColumnValue(obj));
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public virtual object GetObjectFromDataRow(DataRow row)
        {
            return dal.GetObjectFromDataRow(row);
        }

        public DataRow GetDataRowFromBusinessObject(DataRow row, BusinessObject obj)
        {
            foreach (DataColumn column in row.Table.Columns)
            {
                PropertyInfo property = obj.GetType().GetProperty(column.ColumnName);
                if (property != null)
                {
                    row[column.ColumnName] = property.GetValue(obj, null);
                }
            }

            return row;
        }

        /// <summary>
        /// Get the value of a cell
        /// </summary>
        /// <param name="row">Row contains the cell</param>
        /// <param name="columnName">Name of column containing the cell</param>
        /// <returns>Cell value</returns>
        public object GetRowCellValue(DataRow row, string columnName)
        {
            object value = null;
            if (row[columnName] != DBNull.Value)
            {
                value = row[columnName];
            }
            return value;
        }

        public virtual List<BusinessObject> GetListBusinessObjects()
        {
            List<BusinessObject> businessObjectList = new List<BusinessObject>();
            DataSet ds = GetAllObjects();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    BusinessObject objBusinessObject = (BusinessObject)SqlDatabaseHelper.GetObjectFromDataRow(row, dal.ObjectType);
                    businessObjectList.Add(objBusinessObject);
                }
            }
            return businessObjectList;
        }
        /// <summary>
        /// get list object not get row
        /// uthv
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual List<T> GetListBusinessObjects<T>()
        {
            List<T> businessObjectList = new List<T>();
            DataSet ds = GetAllObjects();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    T objBusinessObject = (T)SqlDatabaseHelper.GetObjectFromDataRow(row, typeof(T));
                    businessObjectList.Add(objBusinessObject);
                }
            }
            return businessObjectList;
        }
        public virtual List<T> GetListBusinessObjects<T>(DataSet ds)
        {
            List<T> businessObjectList = new List<T>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    T objBusinessObject = (T)SqlDatabaseHelper.GetObjectFromDataRow(row, typeof(T));
                    businessObjectList.Add(objBusinessObject);
                }
            }
            return businessObjectList;
        }
        public virtual DataSet GetAllDataByForeignColumn(String strForeignColumnName, object objForeignColumnValue)
        {
            return (DataSet)dal.GetAllDataByForeignColumn(strForeignColumnName, objForeignColumnValue);
        }

        public virtual BusinessObject GetFirstObjectByForeignColumn(String strForeignColumnName, object objForeignColumnValue)
        {
            DataSet ds = GetAllDataByForeignColumn(strForeignColumnName, objForeignColumnValue);
            return (BusinessObject)dal.GetSingleObject(ds.Tables[0]);
        }

        public virtual DataSet GetAllObjectsByObjectParentID(int iObjectParentID)
        {
            return (DataSet)dal.GetAllObjectsByObjectParentID(iObjectParentID);
        }

        public void DeleteAllObjectsByObjectParentID(int iObjectParentID)
        {
            dal.DeleteAllObjectsByObjectParentID(iObjectParentID);
        }

        public virtual bool IsExist(int iObjectID)
        {
            return (GetObjectByID(iObjectID) != null);
        }

        public bool IsExistObjectName(String strObjectName)
        {
            return (GetObjectByName(strObjectName) != null);
        }

        public bool IsExist(String strObjectNo)
        {
            return (GetObjectByNo(strObjectNo) != null);
        }


        public bool IsExistAANumberInt(int iAANumberInt)
        {
            return (GetObjectByAANumberInt(iAANumberInt) != null);
        }

        #endregion

        #region Functions For Get,Delete From Owner
        public virtual DataSet GetAllFromOwner(String strOwnerTable, int iOwnerID, String strSwitcherTable)
        {
            return dal.GetMembersFromOwner(strOwnerTable, iOwnerID, dal.TableName, strSwitcherTable);
        }

        public virtual void DeleteFromOwner(String strOwnerTable, int iOwnerID, String strSwitcherTable)
        {
            dal.DeleteMembersFromOwner(strOwnerTable, iOwnerID, dal.TableName, strSwitcherTable);
        }
        #endregion

        #region Functions for main module:Search,Get New Object In Session,Update Save Status In Session

        public virtual DataSet GetAllNewObjectInSession(String strUserName)
        {
            return dal.GetNewObjectInSession(strUserName);
        }

        public virtual void UpdateObjectSaveStatusInSession(String strUserName)
        {
            dal.UpdateObjectSaveStatusInSession(strUserName);
        }

        public virtual DataSet SearchObject(object objSearch)
        {
            return (DataSet)dal.SearchObject(objSearch);
        }

        public virtual int GetRecordsCount()
        {
            int count = -1;
            String strIDFieldName = dal.TableName.Substring(0, dal.TableName.Length - 1) + "ID";

            String strSQL = String.Format("select count(" + strIDFieldName + ") as count from " + dal.TableName + " where AAStatus = 'Alive' ");
            DbCommand cmd = SqlDatabaseHelper.GetQuery(strSQL);
            DataSet ds = SqlDatabaseHelper.RunQuery(cmd);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }
            return count;
        }
        public BusinessObject GetFirstObjectByStringColumn(String column, string value)
        {
            var ds = (DataSet)dal.GetDataSetByStringColumn(column, value);
            return (BusinessObject)dal.GetSingleObject(ds.Tables[0]);
        }
        public DataSet GetDataSetByStringColumn(String column, string value)
        {
            return (DataSet)dal.GetDataSetByStringColumn(column, value);
        }
        public DataSet GetDataSetByIntColumn(String column, int value)
        {
            return (DataSet)dal.GetDataSetByIntColumn(column, value);
        }

        #endregion
    }
}
