using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOSLib;

namespace BOSERP
{
    public class EmployeeSaleDetailController : BaseBusinessController
    {
        public EmployeeSaleDetailController()
        {
            dal = new DALBaseProvider("EmployeeSaleDetail", typeof(EmployeeSaleDetailInfo));
        }
    }
}
