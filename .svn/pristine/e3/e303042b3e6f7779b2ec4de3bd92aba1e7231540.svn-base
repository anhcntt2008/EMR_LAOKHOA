using BOSComponent;
using BOSLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSERP.Modules.ME.METemplate
{
    public class MEServiceLookupEdit : BOSLookupEdit
    {
        protected override void InitObjectDataToLookupEdit()
        {
            //InitObjectDataFromLookupTable("ICProduct");
            string strLookupTable = "ICProducts";
            if (LookupTables[strLookupTable] != null)
            {
                DataTable table = ((DataSet)LookupTables[strLookupTable]).Tables[0].Copy();
                table = FilterServiceIsActive(table);
                InitObjectDataFromLookupTable(table, strLookupTable);

            }
            else
            {
                ((IBaseModuleERP)Screen.Module).GetLookupTableByName(strLookupTable);
                if (LookupTables[strLookupTable] != null)
                {
                    DataTable table = ((DataSet)LookupTables[strLookupTable]).Tables[0].Copy();
                    table = FilterServiceIsActive(table);
                    InitObjectDataFromLookupTable(table, strLookupTable);

                }
            }
        }
        /// <summary>
        /// UtHV 27032017
        /// Loc cac dich vu tu ICProduct
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private DataTable FilterServiceIsActive(DataTable table)
        {
            DataTable service = table.Clone();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = table.Rows[i];
                // chi lay cac service dang active
                if (dr["ICProductType"].ToString() == "Service" && dr["ICProductActiveCheck"].ToString() == "True")
                    service.Rows.Add(dr.ItemArray);
            }
            return service;
        }
    }
}
