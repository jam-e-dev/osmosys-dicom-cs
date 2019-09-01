using System;
using Osmosys.Data.ValueRepresentations;

namespace Osmosys.Data.Tests
{
    public static class TestData
    {
        public static readonly Random Random = new Random();
        public static DicomTag Tag => new DicomTag(Random.Next(0, 50), Random.Next(0, 50));
        public static string String => $"example {Random.Next(0, 1000)}";

        public static DateTime DateTime => new DateTime(
            Random.Next(2000, 2100),
            Random.Next(1, 12),
            Random.Next(1, 28),
            Random.Next(1, 23),
            Random.Next(1, 59),
            Random.Next(1, 59),
            Random.Next(1, 999));

        public static TimeSpan TimeSpan => new TimeSpan(
            0,
            Random.Next(1, 23),
            Random.Next(1, 59),
            Random.Next(1, 60),
            Random.Next(1, 50));

        public static DateTime[] DateTimes => new[] {DateTime, DateTime};

        public static Range<DateTime> DateTimeRange => new Range<DateTime>(DateTime, DateTime);

        public static Range<DateTime>[] DateTimeRanges => new[] {DateTimeRange, DateTimeRange};
        public static string AgeString => "018M";
        public static string ApplicationEntity = "STORAGE 012";
        public static string ApplicationEntityMulti = "STORAGE 012\\PACS XB";
        public static string[] ApplicationEntityMultiArray = ApplicationEntityMulti.Split("\\");
        public static string CodeString = "RGB";
        public static string CodeStringMulti = "RGB\\HSV";
        public static string[] CodeStringMultiArray = CodeStringMulti.Split("\\");
        public static string DateString => $"{DateTime:yyyyMMdd}";
        public static string DateTimeString => $"{DateTime:yyyyMMddHHmmss}";
        public static string DateTimeRangeString => $"{DateTimeString}-{DateTimeString}";
        public static string DateRangeString => $"{DateString}-{DateString}";

        public static string DateMultiString = "20170321\\20130210";
    }
}