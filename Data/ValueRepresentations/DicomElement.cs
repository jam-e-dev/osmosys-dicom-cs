using System;
using System.Collections.Generic;

namespace Osmosys.Data.ValueRepresentations
{
    public abstract class DicomElement
    {
        private const string DateError = "Date type not supported.";
        private const string StringError = "String type not supported.";
        private const string TimeError = "Time type not supported.";
        private const string IntError = "Int type not supported.";
        private const string FloatError = "Float type not supported.";
        private const string DoubleError = "Double type not supported.";

        public DicomTag Tag { get; }

        protected DicomElement(DicomTag tag)
        {
            Tag = tag ?? throw new ArgumentNullException(nameof(tag));
        }

        public virtual string GetString(int index = 0) => throw new InvalidCastException(StringError);

        public virtual IEnumerable<string> GetStrings() => throw new InvalidCastException(StringError);

        public virtual Range<DateTime> GetDate(int index = 0) => throw new InvalidCastException(DateError);

        public virtual IEnumerable<Range<DateTime>> GetDates() => throw new InvalidCastException(DateError);

        public virtual Range<TimeSpan> GetTime(int index = 0) => throw new InvalidCastException(TimeError);
        
        public virtual IEnumerable<Range<TimeSpan>> GetTimes() => throw new InvalidCastException(TimeError);
        
        public virtual int GetInt(int index = 0) => throw new InvalidCastException(IntError);
        
        public virtual IEnumerable<int> GetInts() => throw new InvalidCastException(IntError);
        
        public virtual float GetFloat(int index = 0) => throw new InvalidCastException(FloatError);
        
        public virtual IEnumerable<float> GetFloats() => throw new InvalidCastException(FloatError);
        
        public virtual double GetDouble(int index = 0) => throw new InvalidCastException(DoubleError);
        
        public virtual IEnumerable<double> GetDoubles() => throw new InvalidCastException(DoubleError);
    }
}