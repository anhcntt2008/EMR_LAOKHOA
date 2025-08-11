using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using BOSLib;


namespace BOSERP
{
    #region MESymptoms
    //-----------------------------------------------------------
    //UtHV
    //01172017
    //Symptoms: Danh muc trieu chung
    //-----------------------------------------------------------

    public class MESymptomsController : BaseBusinessController
    {
        public MESymptomsController()
        {
            dal = new DALBaseProvider("MESymptoms", typeof(MESymptomsInfo));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<MESymptomsInfo> GetAllSymptom()
        {
            DataSet ds = dal.GetAllObject();
            IList<MESymptomsInfo> result = new List<MESymptomsInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    MESymptomsInfo objSymptomsInfo = (MESymptomsInfo)GetObjectFromDataRow(row);
                    result.Add(objSymptomsInfo);
                }
            }
            return result;
        }
    }
    #endregion
}