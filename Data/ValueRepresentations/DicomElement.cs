using System;

namespace Osmosys.Data.ValueRepresentations
{
    public abstract class DicomElement
    {
        public DicomTag Tag { get; }
        
        protected DicomElement(DicomTag tag)
        {
            Tag = tag ?? throw new ArgumentNullException(nameof(tag));
        }
        
        public abstract string GetString(int index);

        public abstract string[] GetStrings();

        public virtual DateTime GetDate(int index) => throw new InvalidCastException("Date type not supported.");

        public virtual DateTime[] GetDates() => throw new InvalidCastException("Date type not supported.");
        
        public abstract void Update(string value);

        public abstract void Update(string[] values);

        public virtual void Update(DateTime date) => throw new InvalidCastException("Date type not supported.");
        public virtual void Update(DateTime[] dates) => throw new InvalidCastException("Date type not supported.");
    }
}