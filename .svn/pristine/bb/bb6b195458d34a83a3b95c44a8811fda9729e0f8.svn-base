using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  System.Globalization;
using BOSLib;
using BOSCommon;

namespace BOSERP.Utilities
{
    public class ConvertAmountToWord
    {
        private static string ReadGroup3(string group3)
        {
            string[] readDigit = new string[10] { " Không", " Một", " Hai", " Ba", " Bốn", " Năm", " Sáu", " Bảy", " Tám", " Chín" };
            string temp = String.Empty;
            if (group3 == "000") return String.Empty;
            try
            {
                temp = readDigit[int.Parse(group3[0].ToString())] + " Trăm";
                if (group3[1].ToString() == "0")
                    if (group3[2].ToString() == "0") return temp;
                    else
                    {
                        temp += " Lẻ" + readDigit[int.Parse(group3[2].ToString())];
                        return temp;
                    }

                else
                    temp += readDigit[int.Parse(group3[1].ToString())] + " Mươi";

                if (group3[2].ToString() == "5") temp += " Lăm";
                else if (group3[2].ToString() != "0") temp += readDigit[int.Parse(group3[2].ToString())];
            }
            catch { }
            return temp;
        }

        private static string ReadAmount(string amount)
        {
            if (Convert.ToDouble(amount) > 0)
            {
                string temp = String.Empty;
                while (amount.Length < 12)
                {
                    amount = "0" + amount;
                }
                string g1 = amount.Substring(0, 3);
                string g2 = amount.Substring(3, 3);
                string g3 = amount.Substring(6, 3);
                string g4 = amount.Substring(9, 3);

                if (g1 != "000")
                {
                    temp = ReadGroup3(g1);
                    temp += " Tỷ";
                }
                if (g2 != "000")
                {
                    temp += ReadGroup3(g2);
                    temp += " Triệu";
                }
                if (g3 != "000")
                {
                    temp += ReadGroup3(g3);
                    temp += " Ngàn";
                }

                temp = temp + ReadGroup3(g4);

                temp = temp.Replace("Một Mươi", "Mười");
                temp = temp.Trim();
                if (temp.IndexOf("Không Trăm") == 0)
                    temp = temp.Remove(0, 10);
                temp = temp.Trim();
                if (temp.IndexOf("Lẻ") == 0)
                    temp = temp.Remove(0, 2);
                temp = temp.Trim();
                temp = temp.Replace("Mươi Một", "Mươi Mốt");
                temp = temp.Trim();
                if (!string.IsNullOrEmpty(temp))
                {
                    return temp.Substring(0, 1).ToUpper() + temp.Substring(1).ToLower();                    
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Get displayed text by currency of an amount
        /// </summary>
        /// <param name="amount">Given amount</param>
        /// <param name="currencyID">Currency id</param>
        /// <returns>Displayed text of the amount</returns>
        public static string ReadAmount(string amount, int currencyID)
        {                           
            amount = Math.Round(Convert.ToDouble(amount), 2).ToString();
            GECurrenciesController objCurrencyController = new GECurrenciesController();
            GECurrenciesInfo currency = (GECurrenciesInfo)objCurrencyController.GetObjectByID(currencyID);
            if (currency != null)
            {
                if (currency.GECurrencyID == BOSApp.CurrentCompanyInfo.FK_GESaleCurrencyID)
                {
                    amount = Math.Round(Convert.ToDouble(amount), 0).ToString();
                }
            }
            
            string[] parts = amount.Split(new string[] {NumberFormatInfo.CurrentInfo.NumberDecimalSeparator}, StringSplitOptions.RemoveEmptyEntries);            
            string amountWord = string.Empty;
            if (parts.Length > 0)
            {
                amountWord += ReadAmount(parts[0]);                
            }
            if (parts.Length > 1)
            {
                string word = ReadAmount(parts[1]).ToLower();
                if (NumberFormatInfo.CurrentInfo.NumberDecimalSeparator == ".")
                {
                    amountWord += string.Format(" chấm {0}", word);
                }
                else if (NumberFormatInfo.CurrentInfo.NumberDecimalSeparator == ",")
                {
                    amountWord += string.Format(" phẩy {0}", word);
                }
            }

            if (!string.IsNullOrEmpty(amountWord) && currency != null)
            {
                amountWord += string.Format(" {0}", currency.GECurrencyDesc);
            }
            return amountWord;
        }
    }
}
