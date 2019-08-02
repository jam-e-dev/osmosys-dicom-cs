using System;
using System.Globalization;
using System.Linq;

namespace Osmosys.Data.ValueRepresentations
{
    public class Date : Element
    {
        private const string DateFormat = "yyyyMMdd";

        private DateTime[] _values;

        public Date(DicomTag tag, DateTime value) : base(tag)
        {
            _values = new[] {value};
        }

        public Date(DicomTag tag, DateTime[] values) : base(tag)
        {
            _values = values ?? Array.Empty<DateTime>();
        }

        public override string GetString(int index)
        {
            if (index < 0 || index >= _values.Length)
            {
                throw new ArgumentException($"Index {index} does not exist.");
            }

            var date = _values[index];

            return date.ToString(DateFormat);
        }

        public override string[] GetStrings()
        {
            return _values.Select(value => value.ToString(DateFormat)).ToArray();
        }

        public override void Update(DateTime date)
        {
            _values = new[] {date};
        }

        public override void Update(DateTime[] dates)
        {
            _values = dates ?? Array.Empty<DateTime>();
        }
        
        public override void Update(string value)
        {
            if (value == null)
            {
                _values = Array.Empty<DateTime>();
            }
            else
            {
                var date = ParseDate(value);
                _values = new[] {date};   
            }
        }

        public override void Update(string[] values)
        {
            if (values == null)
            {
                _values = Array.Empty<DateTime>();
            }
            else
            {
                var dates = values.Select(ParseDate);
                _values = dates.ToArray();   
            }
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

        private DateTime ParseDate(string value)
        {
            if (DateTime.TryParseExact(value, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out var date))
            {
                return date;
            }

            throw new ArgumentException("Invalid date format.");
        }
    }
}