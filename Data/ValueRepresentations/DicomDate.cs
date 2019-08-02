using System;

namespace Osmosys.Data.ValueRepresentations
{
    public class DicomDate : DicomElement
    {
        private DateTime[] _values;

        public DicomDate(DicomTag tag, DateTime value) : base(tag)
        {
            _values = new[] {value};
        }

        public DicomDate(DicomTag tag, DateTime[] values) : base(tag)
        {
            _values = values ?? Array.Empty<DateTime>();
        }

        public override void Update(DateTime date)
        {
            _values = new[] {date};
        }

        public override void Update(DateTime[] dates)
        {
            _values = dates ?? Array.Empty<DateTime>();
        }

        public override DateTime GetDate(int index)
        {
            if (index < 0 || index >= _values.Length)
            {
                throw new ArgumentException($"Index {index} does not exist.");
            }

            return _values[index];
        }

        public override DateTime[] GetDates() => _values;
    }
}