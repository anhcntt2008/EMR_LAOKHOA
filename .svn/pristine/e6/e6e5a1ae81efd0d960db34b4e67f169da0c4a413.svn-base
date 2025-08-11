using System.Collections.Generic;
using System.Data;
using BOSEntity.BusinessEntities.Info.ME;
using BOSLib;

namespace BOSEntity.BusinessEntities.Controller.ME
{
    public class MEVisitDocumentsController : BaseBusinessController
    {
        public MEVisitDocumentsController()
        {
            dal = new DALBaseProvider("MEVisitDocuments", typeof(MEVisitDocumentsInfo));
        }

        public List<MEVisitDocumentsInfo> ListByVisitId(int visitId)
        {
            var ds = dal.GetAllDataByForeignColumn("FK_MEPatientVisitId", visitId);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var rs = new List<MEVisitDocumentsInfo>();
                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    var row = GetObjectFromDataRow(dataRow) as MEVisitDocumentsInfo;
                    rs.Add(row);
                }
                return rs;
            }
            return null;
        }

        public List<MEVisitDocumentsInfo> ListByPatientId(int patientId)
        {
            var ds = dal.GetAllDataByForeignColumn("FK_MEPatientID", patientId);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var rs = new List<MEVisitDocumentsInfo>();
                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    var row = GetObjectFromDataRow(dataRow) as MEVisitDocumentsInfo;
                    rs.Add(row);
                }
                return rs;
            }
            return null;
        }
    }
}