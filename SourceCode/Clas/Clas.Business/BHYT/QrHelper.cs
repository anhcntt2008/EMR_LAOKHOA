using Clas.Model.BHYT;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clas.Business.BHYT
{
    public class QrHelper
    {
        public InsuranceCardInfo QrParse(string code)
        {
            var card = new InsuranceCardInfo();
            string[] infos = code.Split('|');
            if (infos.Length < 14)
            {
                return null;
            }
            card.No = infos[0];
            card.PatientName = FromHex(infos[1]);
            string[] dob = infos[2].Split('/');
            //card.DoB = new DateTime(int.Parse(dob[2]), int.Parse(dob[1]), int.Parse(dob[0]), 0, 0, 0);
            card.DoB = dob.Length == 1 ? DateTime.ParseExact("01/01/" + dob[0], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact(infos[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            card.Gender = infos[3] == "1" ? "Male" : "Female";
            card.Address = FromHex(infos[4].Trim());
            card.HospitalCode = infos[5].Replace(" ", "").Replace("-", "");
            //string[] from = infos[6].Split('/');
            //card.FromDate = new DateTime(int.Parse(from[2]), int.Parse(from[1]), int.Parse(from[0]), 0, 0, 0);
            card.FromDate = DateTime.ParseExact(infos[6], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //string[] to = infos[7].Split('/');
            //card.ToDate = new DateTime(int.Parse(to[2]), int.Parse(to[1]), int.Parse(to[0]), 0, 0, 0);
            card.ToDate = DateTime.ParseExact(infos[7], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            card.Level = int.Parse(infos[11]);
            return card;

        }

        private string FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            string s = Encoding.UTF8.GetString(raw);
            return s;
        }
    }
}
