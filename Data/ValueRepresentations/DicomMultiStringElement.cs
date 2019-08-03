using System;

namespace Osmosys.Data.ValueRepresentations
{
    public class DicomMultiStringElement : DicomElement
    {
        protected string[] Values;

        /// <summary>
        /// Initialises using the specified tag and value.
        /// Throws ArgumentNullException if the tag is null.
        /// </summary>
        public DicomMultiStringElement(DicomTag tag, string value) : base(tag)
        {
            Values = value == null ? new string[] {} : new[] {value};
        }

        /// <summary>
        /// Initialises using the specified tag and values.
        /// Throws ArgumentNullException if the tag is null.
        /// </summary>
        public DicomMultiStringElement(DicomTag tag, string[] values) : base(tag)
        {
            this.Values = values ?? Array.Empty<string>();
        }
        
        /// <summary>
        /// Returns the specified string.
        /// Throws ArgumentException if the string does not exist or the index is negative.
        /// </summary>
        public override string GetString(int index)
        {
            if (index < 0 || index >= Values.Length)
            {
                throw new ArgumentException($"Value {index} does not exists.");
            }

            return Values[index];
        }

        /// <summary>
        /// Returns the string values of the AE.
        /// </summary>
        /// <returns></returns>
        public override string[] GetStrings()
        {
            return Values;
        }
    }
}