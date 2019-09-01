using System;
using System.Collections.Generic;
using System.Linq;
using Osmosys.Data.ValueRepresentations;

namespace Osmosys.Data.Extensions
{
    public static class DicomTimeStringExtensions
    {
        public static IEnumerable<Range<TimeSpan>> ToTimeRanges(this IEnumerable<string> timeStrings)
        {
            return timeStrings.Select(x => x.ToTimeRange());
        }

        public static IEnumerable<Range<TimeSpan>> ToTimeRanges(this string timeString)
        {
            return timeString.Split('\\').Select(x => x.ToTimeRange());
        }

        public static Range<TimeSpan> ToTimeRange(this string timeString)
        {
            var rangeComponents = timeString.Split('-');
            var length = rangeComponents.Length;

            switch (length)
            {
                case 1:
                    var time = rangeComponents[0].ToTime();
                    return new Range<TimeSpan>(time);
                case 2:
                    var timeA = rangeComponents[0].ToTime();
                    var timeB = rangeComponents[1].ToTime();
                    return new Range<TimeSpan>(timeA, timeB);
                default:
                    throw new ArgumentException($"Invalid time range format: {timeString}");
            }
        }

        public static TimeSpan ToTime(this string timeString)
        {
            timeString = timeString.Trim();
            var length = timeString.Length;

            if (length == 2)
            {
                return new TimeSpan(GetHours(timeString), 0, 0);
            }
            
            if (length == 4)
            {
                return new TimeSpan(GetHours(timeString), GetMinutes(timeString), 0);
            }
            
            if (length == 6)
            {
                return new TimeSpan(GetHours(timeString), GetMinutes(timeString), GetSeconds(timeString));
            }
            
            if (length == 13 && timeString[6] == '.')
            {
                var timeWithoutTicks = new TimeSpan(GetHours(timeString), GetMinutes(timeString), GetSeconds(timeString));
                return timeWithoutTicks.Add(new TimeSpan(GetMicroSeconds(timeString) * 10));
            }
            
            throw new ArgumentException($"Invalid time format: {timeString}");
        }

        private static int GetHours(string timeString)
        {
            var hourString = timeString.Substring(0, 2);
            var hours = int.Parse(hourString);

            if (hours >= 0 && hours < 24)
            {
                return hours;
            }
            
            throw new ArgumentException($"Invalid hours format: {hourString}");
        }

        private static int GetMinutes(string timeString)
        {
            var minString = timeString.Substring(2, 2);
            var mins = int.Parse(minString);

            if (mins >= 0 && mins < 60)
            {
                return mins;
            }
            
            throw new ArgumentException($"Invalid minutes format: {minString}");
        }

        private static int GetSeconds(string timeString)
        {
            var secString = timeString.Substring(4, 2);
            var sec = int.Parse(secString);

            if (sec >= 0 && sec <= 60)
            {
                return sec;
            }
            
            throw new ArgumentException($"Invalid seconds format: {secString}");
        }

        private static int GetMicroSeconds(string timeString)
        {
            var microSecString = timeString.Substring(7, 6);
            var microSec = int.Parse(microSecString);

            if (microSec > 0 && microSec < 1000000)
            {
                return microSec;
            }
            
            throw new ArgumentException($"Invalid microseconds format: {microSecString}");
        }
    }
}