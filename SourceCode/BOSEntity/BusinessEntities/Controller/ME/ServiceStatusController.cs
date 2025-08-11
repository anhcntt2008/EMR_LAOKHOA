using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOSLib;
using System.Data;

namespace BOSERP
{
    public class ServiceStatusController : BaseBusinessController
    {
        public ServiceStatusController()
        {
            dal = new DALBaseProvider(string.Empty, typeof(ServiceStatusInfo));
        }
        public List<ServiceStatusInfo> GetListLabInsertToLabServer(int patientVisitID, int patientID)
        {
            List<ServiceStatusInfo> result = new List<ServiceStatusInfo>();
            ServiceStatusController objServiceStatusController = new ServiceStatusController();
            DataSet ds = dal.GetDataSet("MEVisitLabs_GetListLabInsertToLabServer", patientVisitID, patientID);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ServiceStatusInfo objServiceStatusInfo = (ServiceStatusInfo)objServiceStatusController.GetObjectFromDataRow(row);
                    result.Add(objServiceStatusInfo);

                }
            }
            return result;
        }
    }
}
