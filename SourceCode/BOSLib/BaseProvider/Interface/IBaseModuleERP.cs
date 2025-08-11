using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BOSLib
{
    public interface IBaseModuleERP : IBaseModule
    {
        #region Control Events
        void Control_Click(object sender, EventArgs e);
        void Control_MouseUp(object sender, MouseEventArgs e);
        void Control_TextChanged(object sender, EventArgs e);
        void Control_Validated(object sender, EventArgs e);
        void Control_EditValueChanged(object sender, EventArgs e);
        void Control_Enter(object sender, EventArgs e);
        void Control_Leave(object sender, EventArgs e);
        void Control_KeyDown(object sender, KeyEventArgs e);
        void Control_KeyUp(object sender, KeyEventArgs e);
        #endregion        

        SortedList GetLookupTableCollection();
        SortedList GetLookupTableUpdatedDateCollection();
        SortedList<string, GELookupTablesInfo> GetLookupTableObjects();
        int GetCurrentUserGroupID();
        DataSet GetLookupTableData(string lookupTableName);
        void GetLookupTableByName(string tableName);
        DataSet InitLookupByTable(string lookupTableName);
        int GetCurrentUserID();
        bool UserIsAdmin();
        ADUserGroupsInfo[] ShowUserGroupSelections();
    }
}