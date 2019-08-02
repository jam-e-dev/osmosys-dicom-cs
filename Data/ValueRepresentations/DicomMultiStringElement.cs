using System;

namespace Osmosys.Data.ValueRepresentations
{
    public class DicomMultiStringElement : DicomElement
    {
        private string[] _values;

        /// <summary>
        /// Initialises using the specified tag and value.
        /// Throws ArgumentNullException if the tag is null.
        /// </summary>
        public DicomMultiStringElement(DicomTag tag, string value) : base(tag)
        {
            _values = value == null ? new string[] {} : new[] {value};
        }

        /// <summary>
        /// Initialises using the specified tag and values.
        /// Throws ArgumentNullException if the tag is null.
        /// </summary>
        public DicomMultiStringElement(DicomTag tag, string[] values) : base(tag)
        {
            _values = values ?? Array.Empty<string>();
        }

        /// <summary>
        /// Update the value with the specified string.
        /// </summary>
        public override void Update(string value)
        {
            _values = value == null ? Array.Empty<string>() : new[] {value};
        }

        /// <summary>
        /// Update the value with the specified strings.
        /// </summary>
        public override void Update(string[] values)
        {
            _values = values ?? Array.Empty<string>();
        }

        /// <summary>
        /// Returns the specified string.
        /// Throws ArgumentException if the string does not exist or the index is negative.
        /// </summary>
        public override string GetString(int index)
        {
            if (index < 0 || index >= _values.Length)
            {
                throw new ArgumentException($"Value {index} does not exists.");
            }

            return _values[index];
        }

        /// <summary>
        /// Returns the string values of the AE.
        /// </summary>
        /// <returns></returns>
        public override string[] GetStrings()
        {
            return _values;
        }
    }
}