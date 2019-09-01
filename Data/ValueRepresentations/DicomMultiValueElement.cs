using System;

namespace Osmosys.Data.ValueRepresentations
{
    public abstract class DicomMultiValueElement<T> : DicomElement
    {
        protected T[] Values;

        protected DicomMultiValueElement(DicomTag tag, T value) : base(tag)
        {
            Values = new[] {value};
        }

        protected DicomMultiValueElement(DicomTag tag, T[] values) : base(tag)
        {
            Values = values ?? Array.Empty<T>();
        }

        protected T GetValue(int index)
        {
            ValidateIndex(index);
            return Values[index];
        }

        protected void ValidateIndex(int index)
        {
            if (index < 0 || index >= Values.Length)
            {
                throw new ArgumentException($"Index {index} does not exist.");
            }
        }
    }
}