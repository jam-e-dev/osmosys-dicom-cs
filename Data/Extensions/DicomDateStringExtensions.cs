using System;
using System.Collections.Generic;
using System.Linq;
using Osmosys.Data.ValueRepresentations;

namespace Osmosys.Data.Extensions
{
    public static class DicomDateStringExtensions
    {
        public static IEnumerable<Range<DateTime>> ToDateRanges(this IEnumerable<string> dateStrings)
        {
            return dateStrings.Select(x => x.ToDateRange());
        }

        public static IEnumerable<Range<DateTime>> ToDateRanges(this string dateString)
        {
            return dateString.Split('\\').Select(x => x.ToDateRange());
        }

        public static Range<DateTime> ToDateRange(this string dateString)
        {
            var rangeComponents = dateString.Split('-');
            var length = rangeComponents.Length;

            switch (length)
            {
                case 1:
                    var date = rangeComponents[0].ToDate();
                    return new Range<DateTime>(date);
                case 2:
                    var dateA = rangeComponents[0].ToDate();
                    var dateB = rangeComponents[1].ToDate();
                    return new Range<DateTime>(dateA, dateB);
                default:
                    throw new ArgumentException($"Invalid date range format: {dateString}");
            }
        }

        public static DateTime ToDate(this string dateString)
        {
            dateString = dateString.Trim();
            var length = dateString.Length;

            if (length == 8)
            {
                return new DateTime(dateString.GetYear(), dateString.GetMonth(), dateString.GetDay());
            }
            
            throw new ArgumentException($"Invalid date format: {dateString}");
        }

        private static int GetYear(this string dateString)
        {
            var yearString = dateString.Substring(0, 4);
            var year = int.Parse(yearString);

            if (year > 0)
            {
                return year;
            }
            
            throw new ArgumentException($"Invalid year format: {yearString}");
        }

        private static int GetMonth(this string dateString)
        {
            var monthString = dateString.Substring(4, 2);
            var month = int.Parse(monthString);

            if (month > 0 && month <= 12)
            {
                return month;
            }
            
            throw new ArgumentException($"Invalid month format: {month}");
        }

        private static int GetDay(this string dateString)
        {
            var dayString = dateString.Substring(6, 2);
            var day = int.Parse(dayString);

            if (day > 0)
            {
                return day;
            }
            
            throw new ArgumentException($"Invalid day format: {day}");
        }
    }
}