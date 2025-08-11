using System;
using System.Globalization;
using CHBase.SDK;

namespace Clas.CHBase
{
    internal class Utilities
    {
        public static string XmlFromDateTime(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH:mm:ss.FFFZ", CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     Get value from Health vault
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="typeId">TypeId for HealthRecordItem</param>
        /// <param name="accessor">Reference to HealthRecordAccessor</param>
        /// <returns>Object of generics</returns>
        public static T GetHealthRecordItemValue<T>(Guid typeId,
            HealthRecordAccessor accessor) where T : class
        {
            HealthRecordSearcher searcher = new HealthRecordSearcher(accessor);
            searcher.Filters.Add(new HealthRecordFilter(typeId));
            HealthRecordItemCollection items = searcher.GetMatchingItems()[0];
            if (items != null && items.Count > 0)
            {
                return items[0] as T;
            }
            return null;
        }
    }
}