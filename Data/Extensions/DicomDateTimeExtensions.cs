using System;
using Osmosys.Data.ValueRepresentations;

namespace Osmosys.Data.Extensions
{
    public static class DicomDateTimeExtensions
    {
        public static string ToDicomDateString(this DateTime date)
        {
            return $"{date:yyyyMMdd}";
        }

        public static string ToDicomDateString(this Range<DateTime> range)
        {
            if (range.IsRange)
            {
                return $"{range.Min.ToDicomDateString()}-{range.Max.ToDicomDateString()}";
            }

            return $"{range.Min.ToDicomDateString()}";
        }
    }
}