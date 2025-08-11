using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Emr
{
    public static class Common
    {
        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        public static bool IsUnicode(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            if (string.IsNullOrWhiteSpace(input)) return false;
            var asciiBytesCount = Encoding.ASCII.GetByteCount(input);
            var unicodBytesCount = Encoding.UTF8.GetByteCount(input);
            if (asciiBytesCount != unicodBytesCount)
            {
                return true;
            }
            return false;
        }
        public static bool IsContainsCapitalChars(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            if (string.IsNullOrWhiteSpace(input)) return false;
            var regex = new Regex("[A-Z]");
            if (regex.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        public static bool IsContainsSpecialChars(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            if (string.IsNullOrWhiteSpace(input)) return false;
            var regexItem = new Regex("^[a-zA-Z_]*$");
            if (!regexItem.IsMatch(input))
            {
                return true;
            }
            return false;
        }
    }
    public static class SanitizedFileName
    {
        // https://msdn.microsoft.com/en-us/library/aa365247.aspx#naming_conventions
        // http://stackoverflow.com/questions/146134/how-to-remove-illegal-characters-from-path-and-filenames
        private static readonly Regex removeInvalidChars = new Regex($"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]",
            RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public static string Sanitize(string fileName, string replacement = "_")
        {
            if (string.IsNullOrEmpty(fileName)) return fileName;
            return removeInvalidChars.Replace(fileName, replacement);
        }

        public static string TrimNonAscii(this string value)
        {
            string pattern = "[^ -~]+";
            Regex reg_exp = new Regex(pattern);
            return reg_exp.Replace(value, "");
        }
        public static string ReplaceNonAscii(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return Encoding.ASCII.GetString(
                 Encoding.Convert(
                     Encoding.UTF8,
                     Encoding.GetEncoding(
                         Encoding.ASCII.EncodingName,
                         new EncoderReplacementFallback(string.Empty),
                         new DecoderExceptionFallback()
                         ),
                     Encoding.UTF8.GetBytes(value)
                 )
             );
        }
    }

    public static class Vietnamese
    {
        private static readonly string[] VietnameseSigns = new string[]
        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"
        };

        public static string RemoveSign4VietnameseString(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }

        public static string RemoveSpecialCharacters(string str, string replaceKey)
        {
            return Regex.Replace(str, "[^0-9a-zA-Z]+", replaceKey);
        }

        public static string AliasConvert(string text, string replaceKey)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            text = text.Trim().ToLower();
            if (text.EndsWith("?") || text.EndsWith("!"))
            {
                text = text.Substring(0, text.Length - 1);
            }
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            text = regex.Replace(text, " ");
            text = RemoveSign4VietnameseString(text);
            text = RemoveSpecialCharacters(text, replaceKey);
            text = text.TrimEnd(char.Parse(replaceKey));
            return text;
        }
    }

    public static class XConvert
    {
        public static string Age(DateTime birthDate)
        {
            // Thông tư 18/2018/TT-BYT
            // Đối với trẻ dưới 72 tháng tuổi ghi số tháng tuổi, cân nặng.
            DateTime dateTimeToday = DateTime.UtcNow;
            //DateTime birthDate = new DateTime(1956, 8, 27);
            TimeSpan difference = dateTimeToday.Subtract(birthDate);
            var firstDay = new DateTime(1, 1, 1);
            // Console.WriteLine($"Age in seconds: {Math.Round(difference.TotalSeconds)}");
            // Console.WriteLine($"Age in minutes: {Math.Round(difference.TotalMinutes)}");
            // Console.WriteLine($"Age in hours: {Math.Round(difference.TotalHours)}");
            // Console.WriteLine($"Age in days: {Math.Round(difference.TotalDays)}");
            // Console.WriteLine($"Age in weeks: {System.Math.Ceiling(difference.TotalDays / 7)}");
            int totalYears = (firstDay + difference).Year - 1;
            // Console.WriteLine($"Age in years: {totalYears}");
            int totalMonths = (totalYears * 12) + (firstDay + difference).Month - 1;
            // Console.WriteLine($"Age in months: {totalMonths}");
            int runningMonths = totalMonths - (totalYears * 12);
            // Console.WriteLine($"Age in {runningMonths}");
            // int runningDays = (dateTimeToday - birthDate.AddMonths((totalYears * 12) + runningMonths)).Days;
            // Console.WriteLine($"Age in {runningDays}");
            // Console.WriteLine($"Age is {totalYears} years, {runningMonths} months, {runningDays} days");
            if (totalMonths <= 72)
            {
                return $" - Tuổi: {totalMonths} tháng";
            }
            return $" - Tuổi: {totalYears}";
        }
    }
}
