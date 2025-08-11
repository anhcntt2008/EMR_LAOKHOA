using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region GridResultColumnDisplayController
    /// <summary>
    /// This object represents the properties and methods of a GridResultColumnDisplay.
    /// </summary>
    public class STGridResultColumnDisplaysController : BaseBusinessController
    {
        #region SP Name
        private readonly string spGetSTGridResultColumnDisplaysBySTModuleName = "STGridResultColumnDisplays_SelectBySTModuleName";
        private readonly string spDeleteSTGridResultColumnDisplaysBySTModuleName = "STGridResultColumnDipslays_DeleteBySTModuleName";
        #endregion
        public STGridResultColumnDisplaysController()
        {
            dal = new DALBaseProvider("STGridResultColumnDisplays", typeof(STGridResultColumnDisplaysInfo));
        }

        public DataSet GetGridResultColumnDisplaysByModuleName(String strModuleName)
        {
            return (DataSet)dal.GetDataSet(spGetSTGridResultColumnDisplaysBySTModuleName, strModuleName);
        }
        public void DeleteGridResultColumnDisplayByModuleName(String strModuleName)
        {
            dal.GetDataSet(spDeleteSTGridResultColumnDisplaysBySTModuleName, strModuleName);
        }

    }
    #endregion
}
