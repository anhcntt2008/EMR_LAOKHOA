using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOSLib;
using System.Data;

namespace BOSERP
{
    public class OverTimeChartPointController : BaseBusinessController
    {
        public OverTimeChartPointController()
        {
            dal = new DALBaseProvider("OverTimeChartPoint", typeof(OverTimeChartPointInfo));
        }

        public override System.Collections.IList GetListFromDataSet(System.Data.DataSet ds)
        {
            List<OverTimeChartPointInfo> points = new List<OverTimeChartPointInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    OverTimeChartPointInfo point = (OverTimeChartPointInfo)GetObjectFromDataRow(row);
                    points.Add(point);
                }
            }
            return points;
        }
    }
}
