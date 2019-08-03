using System;

namespace Osmosys.Data.ValueRepresentations
{
    public class DicomDateTime : DicomElement
    {
        private DateTime[] _values;

        public DicomDateTime(DicomTag tag, DateTime value) : base(tag)
        {
            _values = new[] {value};
        }

        public DicomDateTime(DicomTag tag, DateTime[] values) : base(tag)
        {
            _values = values ?? Array.Empty<DateTime>();
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