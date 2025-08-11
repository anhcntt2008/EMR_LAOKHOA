using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using BOSLib;

namespace BOSERP
{
    public class ACCashFlowsController : BaseBusinessController
    {
        public ACCashFlowsController()
        {
            dal = new DALBaseProvider("ACCashFlows", typeof(ACCashFlowsInfo));
        }
    }
}
