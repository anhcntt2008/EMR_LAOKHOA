using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BOSLib
{
    public interface IBOSList<T> : IList<T>, ICloneable where T: BusinessObject
    {
        string ItemTableName { get; set; }
        string ParentTableName { get; set; }
        string ItemTableForeignKey { get; set; }
        string Relation { get; set; }
        IList<T> OriginalList {get; set;}
        IList<T> BackupList { get; set; }
        int CurrentIndex { get; }

        void InitBOSList(object entity, string parentTableName, string itemTableName);
        void InitBOSList(object entity, string parentTableName, string itemTableName, string relation);
        void Invalidate(int iObjectID);
        void Invalidate(DataSet ds);
        void Invalidate(IList<T> lst);
        T SaveObjectToList(bool isNew);
        void AddObjectToList();
        void ChangeObjectFromList();
        void RemoveObjectFromList(int iIndex);
        void RemoveSelectedRowObjectFromList();
        bool Exists(string strPropertyName, object objPropertyValue);
        void DeleteAllItemObjects();
        void DeleteItemObjects();
        void SaveItemObjects();
        void SaveItemObjects(bool bDeleteFirst);
        int PosOf(string strPropertyName, object objPropertyValue);
        int GetParentObjectID();
        void Duplicate();
        int GetFrequence(string strPropertyName, object objPropertyValue);
    }
}
