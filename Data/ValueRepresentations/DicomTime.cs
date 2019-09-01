using System;
using System.Collections.Generic;
using System.Linq;
using Osmosys.Data.Extensions;

namespace Osmosys.Data.ValueRepresentations
{
    public class DicomTime : DicomMultiValueElement<Range<TimeSpan>>
    {
        public DicomTime(DicomTag tag, string times) : base(tag, times?.ToTimeRanges().ToArray())
        {
        }

        public DicomTime(DicomTag tag, IEnumerable<string> times) : base(tag, times?.ToTimeRanges().ToArray())
        {
            
        }
        
        public DicomTime(DicomTag tag, TimeSpan time) : base(tag, new Range<TimeSpan>(time))
        {
        }

        public DicomTime(DicomTag tag, IEnumerable<TimeSpan> times) : base(tag, times?.Select(x => new Range<TimeSpan>(x)).ToArray())
        {
        }

        public DicomTime(DicomTag tag, Range<TimeSpan> value) : base(tag, value == null ? null : new[] {value})
        {
        }

        public DicomTime(DicomTag tag, Range<TimeSpan>[] values) : base(tag, values)
        {
        }

        public override Range<TimeSpan> GetTime(int index = 0) => GetValue(index);

        public override IEnumerable<Range<TimeSpan>> GetTimes() => Values;

        public override string GetString(int index = 0) => GetValue(index).ToDicomString();

        public override IEnumerable<string> GetStrings() => Values.Select(x => x.ToDicomString());
    }
}