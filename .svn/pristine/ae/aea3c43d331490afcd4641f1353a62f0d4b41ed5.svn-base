using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Clas.Model.Utils
{
    public static class HelioDateTimeExtensions
    {
        public static Dictionary<string, string> TimeZoneNameMapping;

        /// <summary>
        /// return string look like Monday,  27th August 2016
        /// </summary>
        /// <param name="thisDate"></param>
        /// <returns></returns>
        public static string GetDateString(this DateTime thisDate)
        {
            return string.Format("{0}, {1} {2} {3}", thisDate.ToString("dddd"), thisDate.GetFormattedDay(), thisDate.ToString("MMMM"), thisDate.ToString("yyyy"));
        }
        public static string GetFormattedDay(this DateTime thisDate)
        {
            return thisDate.Day.ToString() + ((thisDate.Day % 10 == 1 && thisDate.Day != 11) ? "st"
            : (thisDate.Day % 10 == 2 && thisDate.Day != 12) ? "nd"
            : (thisDate.Day % 10 == 3 && thisDate.Day != 13) ? "rd"
            : "th");
        }

        public static string GetFormattedMonth(this DateTime thisDate)
        {
            var ci = new CultureInfo("en-GB");
            return thisDate.ToString("MMM", ci);
        }

        public static string GetFormattedDayOfWeek(this DateTime thisDate)
        {
            switch (thisDate.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "Sun";
                case DayOfWeek.Monday:
                    return "Mon";
                case DayOfWeek.Tuesday:
                    return "Tue";
                case DayOfWeek.Wednesday:
                    return "Wed";
                case DayOfWeek.Thursday:
                    return "Thu";
                case DayOfWeek.Friday:
                    return "Fri";
                case DayOfWeek.Saturday:
                    return "Sat";
                default:
                    return "";
            }
        }
        /// <summary>
        ///  convert from (long) to (DateTime) and UTC to Local
        /// </summary>
        /// <param name="milisecond"></param>
        /// <returns></returns>
        public static DateTime ToLocalTime(this long milisecond)
        {
            DateTime date = (new DateTime(1970, 1, 1, 0, 0, 0)).AddMilliseconds(milisecond);
            //TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById("");
            //TODO: Check if it is correct on all PC
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            return TimeZoneInfo.ConvertTimeFromUtc(date, localTimeZone);

        }
        /// <summary>
        ///  convert from (long?) to (DateTime) and UTC to Local
        /// </summary>
        /// <param name="milisecond"></param>
        /// <returns></returns>
        public static DateTime ToLocalTime(this Nullable<long> milisecond)
        {

            if (!milisecond.HasValue)
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return ToLocalTime(milisecond.Value);
        }

        public static TimeSpan ToTimeSpanFromMinutes(this int minute)
        {
            return TimeSpan.FromMinutes(minute);
        }
        public static TimeSpan ToTimeSpanFromSecond(this int second)
        {
            return TimeSpan.FromSeconds(second);
        }
        public static TimeSpan ToTimeSpan(this Nullable<int> second)
        {
            if (second.HasValue)
                return TimeSpan.FromSeconds(second.Value);
            return new TimeSpan();
        }

        public static long ToMilisecondsFrom1970(this DateTime date)
        {
            return (long)(date - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        public static DateTime FromUnixTime(long unixTimeMillis)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds(unixTimeMillis);
        }
        public static string ToFamilyDateString(this DateTime date)
        {
            CultureInfo cul = CultureInfo.CurrentCulture;
            var now = DateTime.Now;
            int weekNum = cul.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            int weekNumNow = cul.Calendar.GetWeekOfYear(now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            //if to day
            if (date.DayOfYear == now.DayOfYear && date.Year == now.Year)
            {
                return date.ToString("HH:mm tt");
            }
            // if this week
            else if (weekNum == weekNumNow && date.Year == now.Year)
            {
                return date.ToString("dddd") + date.ToString("HH:mm");
            }
            //if this month
            else if (date.Month == now.Month && date.Year == now.Year)
            {
                return date.ToString("dddd, MM dd") + date.ToString("HH:mm");
            }
            //if this year
            else if (date.Year == now.Year)
            {
                return date.ToString("MMM dd");
            }
            else
            {
                return date.ToString("dd MMM yyyy");
            }
        }
    }
}
