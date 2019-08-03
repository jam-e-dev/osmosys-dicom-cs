using System;

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

        public virtual string GetString(int index) => throw new InvalidCastException(StringError);

        public virtual string[] GetStrings() => throw new InvalidCastException(StringError);

        public virtual DateTime GetDate(int index) => throw new InvalidCastException(DateError);

        public virtual DateTime[] GetDates() => throw new InvalidCastException(DateError);

        public virtual TimeSpan GetTime(int index) => throw new InvalidCastException(TimeError);
        
        public virtual TimeSpan[] GetTimes() => throw new InvalidCastException(TimeError);
        
        public virtual int GetInt(int index) => throw new InvalidCastException();
        
        public virtual int[] GetInts() => throw new InvalidCastException();
        
        public virtual float GetFloat(int index) => throw new InvalidCastException();
        
        public virtual float[] GetFloats() => throw new InvalidCastException();
        
        public virtual double GetDouble(int index) => throw new InvalidCastException();
        
        public virtual double[] GetDoubles() => throw new InvalidCastException();
    }
}