using System;
using System.Collections.Generic;
using System.Linq;
using Osmosys.Data.Extensions;

namespace Osmosys.Data.ValueRepresentations
{
    public class DicomDate : DicomMultiValueElement<Range<DateTime>>
    {
        public DicomDate(DicomTag tag, DateTime value) : base(tag, new Range<DateTime>(value))
        {
        }

        public DicomDate(DicomTag tag, IEnumerable<DateTime> values) : base(tag, values?.Select(x => new Range<DateTime>(x)).ToArray())
        {
        }

        public DicomDate(DicomTag tag, Range<DateTime> value) : base(tag, value == null ? null : new[] {value})
        {
        }

        public DicomDate(DicomTag tag, Range<DateTime>[] values) : base(tag, values)
        {
        }

        public DicomDate(DicomTag tag, string value) : base(tag,value?.ToDateRanges().ToArray())
        {
        }

        public DicomDate(DicomTag tag, IEnumerable<string> values) : base(tag, values?.ToDateRanges().ToArray())
        {
        }

        public override Range<DateTime> GetDate(int index = 0) => GetValue(index);

        public override IEnumerable<Range<DateTime>> GetDates() => Values;

        public override string GetString(int index = 0) => GetValue(index).ToDicomDateString();

        public override IEnumerable<string> GetStrings() => GetDates().Select(x => x.ToDicomDateString());
    }
}