using System;

namespace Osmosys.Data.ValueRepresentations
{
    public class DicomDate : DicomElement
    {
        private DateTime[] _values;

        public DicomDate(DicomTag tag, DateTime value) : base(tag)
        {
            _values = new[] {value.Date};
        }

        public DicomDate(DicomTag tag, DateTime[] values) : base(tag)
        {
            _values = values ?? Array.Empty<DateTime>();

            RemoveTimeComponents();
        }

        public override void Update(DateTime date)
        {
            _values = new[] {date.Date};
        }

        public override void Update(DateTime[] dates)
        {
            _values = dates ?? Array.Empty<DateTime>();
            RemoveTimeComponents();
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
        
        private void RemoveTimeComponents()
        {
            for (var i = 0; i < _values.Length; i++)
            {
                _values[i] = _values[i].Date;
            }
        }
    }
}