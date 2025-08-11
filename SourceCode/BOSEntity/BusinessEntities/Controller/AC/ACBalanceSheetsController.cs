using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using BOSLib;

namespace BOSERP
{
    public class ACBalanceSheetsController : BaseBusinessController
    {
        public ACBalanceSheetsController()
        {
            dal = new DALBaseProvider("ACBalanceSheets", typeof(ACBalanceSheetsInfo));
        }
    }
}
