using System;

namespace Osmosys.Data.ValueRepresentations
{
    public class DicomTime : DicomElement
    {
        private TimeSpan[] _values;
        
        public DicomTime(DicomTag tag, TimeSpan time) : base(tag)
        {
            _values = new[] {time};
        }

        public DicomTime(DicomTag tag, TimeSpan[] times) : base(tag)
        {
            _values = times ?? Array.Empty<TimeSpan>();
        }

        public override TimeSpan GetTime(int index)
        {
            if (index < 0 || index >= _values.Length)
            {
                throw new ArgumentException($"Index {index} does not exist.");
            }

            return _values[index];
        }

        public override TimeSpan[] GetTimes()
        {
            return _values;
        }

        public override void Update(TimeSpan time)
        {
            _values = new[] {time};
        }

        public override void Update(TimeSpan[] times)
        {
            _values = times ?? Array.Empty<TimeSpan>();
        }
    }
}