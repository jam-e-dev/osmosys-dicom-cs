using System;

namespace Osmosys.Data.ValueRepresentations
{
    public class ApplicationEntity
    {
        public DicomTag Tag { get; }
        private string[] _values;

        /// <summary>
        /// Initialises the AE with the specified tag and value.
        /// Throws ArgumentNullException if the tag is null.
        /// </summary>
        public ApplicationEntity(DicomTag tag, string value)
        {
            Tag = tag ?? throw new ArgumentNullException(nameof(tag));

            _values = value == null ? new string[] {} : new[] {value};
        }

        /// <summary>
        /// Initialises the AE with the specified tag and values.
        /// Throws ArgumentNullException if the tag is null.
        /// </summary>
        public ApplicationEntity(DicomTag tag, string[] values)
        {
            Tag = tag ?? throw new ArgumentNullException(nameof(tag));
            _values = values ?? Array.Empty<string>();
        }

        /// <summary>
        /// Update the AE value with the specified string.
        /// </summary>
        public void Update(string value)
        {
            _values = value == null ? Array.Empty<string>() : new[] {value};
        }

        /// <summary>
        /// Update the AE value with the specified strings.
        /// </summary>
        public void Update(string[] values)
        {
            _values = values ?? Array.Empty<string>();
        }

        /// <summary>
        /// Returns the specified string.
        /// Throws ArgumentException if the string does not exist or the index is negative.
        /// </summary>
        public string GetString(int index)
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
        public string[] GetStrings()
        {
            return _values;
        }
    }
}