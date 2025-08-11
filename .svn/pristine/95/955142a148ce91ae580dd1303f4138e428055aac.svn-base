using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Pluggable.Interface
{
    public static class Common
    {
        public static DateTime GetMaxDateFromToken(JToken data, string path)
        {
            var dateTokens = data.SelectToken(path, false);
            if (dateTokens == null) return DateTime.MinValue;
            var date = DateTime.MinValue;
            if (dateTokens.Type != JTokenType.Array)
            {
                if (dateTokens.Type == JTokenType.Date)
                {
                    if ((DateTime)dateTokens > date)
                        date = (DateTime)dateTokens;
                }
                else
                {
                    if (TryParseDate(dateTokens.ToString(), out DateTime value))
                        if (value > date)
                            date = value;
                }
            }
            else
            {
                foreach (var item in dateTokens)
                {
                    if (item.Type == JTokenType.Date)
                    {
                        if ((DateTime)item > date)
                            date = (DateTime)item;
                    }
                    else
                    {
                        if (TryParseDate(item.ToString(), out DateTime value))
                            if (value > date)
                                date = value;
                    }
                }
            }
            return date;
        }
        public static DateTime GetMaxDateFromTokens(JToken data, string path)
        {
            var dateTokens = data.SelectTokens(path, false);
            if (dateTokens == null) return DateTime.MinValue;
            var date = DateTime.MinValue;
            foreach (var item in dateTokens)
            {
                if (item.Type == JTokenType.Date)
                {
                    if ((DateTime)item > date)
                        date = (DateTime)item;
                }
                else
                {
                    if (TryParseDate(item.ToString(), out DateTime value))
                        if (value > date)
                            date = value;
                }
            }
            return date;
        }
        public static int GetMaxIntFromStrArr(string[] strs)
        {
            return strs.Select(str =>
            {
                bool success = int.TryParse(str, out int value);
                return new { value, success };
            }).Where(pair => pair.success).Select(pair => pair.value).Max();
        }
        public static int TinhTuoiThaiInDays(DateTime ngayDuSinh)
        {
            return 280 - (int)(ngayDuSinh - DateTime.Now.Date).TotalDays;
        }
        public static bool TryParseDate(string dateStr, out DateTime date)
        {
            var ok = DateTime.TryParseExact(dateStr, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (ok) return true;
            ok = DateTime.TryParseExact(dateStr, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (ok) return true;
            ok = DateTime.TryParseExact(dateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (ok) return true;
            ok = DateTime.TryParseExact(dateStr, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (ok) return true;
            ok = DateTime.TryParseExact(dateStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (ok) return true;
            ok = DateTime.TryParseExact(dateStr, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (ok) return true;
            ok = DateTime.TryParseExact(dateStr, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (ok) return true;
            return false;
        }
    }
}
