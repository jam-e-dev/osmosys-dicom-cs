using System;

namespace Osmosys.Data.ValueRepresentations
{
    public abstract class DicomElement
    {
        private const string DateError = "Date type not supported.";
        private const string StringError = "String type not supported.";

        public DicomTag Tag { get; }

        protected DicomElement(DicomTag tag)
        {
            Tag = tag ?? throw new ArgumentNullException(nameof(tag));
        }

        public virtual string GetString(int index) => throw new InvalidCastException(StringError);

        public virtual string[] GetStrings() => throw new InvalidCastException(StringError);

        public virtual DateTime GetDate(int index) => throw new InvalidCastException(DateError);

        public virtual DateTime[] GetDates() => throw new InvalidCastException(DateError);

        public virtual void Update(string value) => throw new InvalidCastException(StringError);

        public virtual void Update(string[] values) => throw new InvalidCastException(StringError);

        public virtual void Update(DateTime date) => throw new InvalidCastException(DateError);
        public virtual void Update(DateTime[] dates) => throw new InvalidCastException(DateError);
    }
}