using System;
using Osmosys.Data.ValueRepresentations;

namespace Osmosys.Data.Extensions
{
    public static class DicomTimeSpanExtensions
    {
        public static string ToDicomString(this TimeSpan time)
        {
            var timeWithoutTicks = new TimeSpan(time.Hours, time.Minutes, time.Seconds);
            var tickTime = time.Subtract(timeWithoutTicks);
            var microSeconds = (int) (tickTime.Ticks / 10);

            if (microSeconds > 0)
            {
                return $"{time:hhmmss}.{microSeconds:D6}";
            }

            if (time.Seconds > 0)
            {
                return $"{time:hhmmss}";
            }

            if (time.Minutes > 0)
            {
                return $"{time:hhmm}";
            }

            return $"{time:hh}";
        }

        public static string ToDicomString(this Range<TimeSpan> range)
        {
            if (range.IsRange)
            {
                return $"{range.Min.ToDicomString()}-{range.Max.ToDicomString()}";
            }

            return $"{range.Min.ToDicomString()}";
        }
    }
}