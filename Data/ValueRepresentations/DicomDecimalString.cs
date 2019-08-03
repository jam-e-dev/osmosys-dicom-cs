using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Osmosys.Data.ValueRepresentations
{
    public class DicomDecimalString : DicomMultiStringElement
    {
        public DicomDecimalString(DicomTag tag, int value) : base(tag, value.ToString(CultureInfo.InvariantCulture))
        {
        }

        public DicomDecimalString(DicomTag tag, IEnumerable<int> values)
            : base(tag, values?.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray())
        {
        }

        public DicomDecimalString(DicomTag tag, float value) : base(tag, value.ToString(CultureInfo.CurrentCulture))
        {
        }

        public DicomDecimalString(DicomTag tag, IEnumerable<float> values)
            : base(tag, values?.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray())
        {
        }

        public DicomDecimalString(DicomTag tag, double value)
            : base(tag, value.ToString(CultureInfo.InvariantCulture))
        {
        }

        public DicomDecimalString(DicomTag tag, IEnumerable<double> values)
            : base(tag, values?.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray())
        {
        }

        public DicomDecimalString(DicomTag tag, string value) : base(tag, value)
        {
        }

        public DicomDecimalString(DicomTag tag, string[] values) : base(tag, values)
        {
        }

        public override int GetInt(int index)
        {
            ValidateIndex(index);

            return (int) double.Parse(Values[index], CultureInfo.InvariantCulture);
        }

        public override int[] GetInts()
        {
            return Values.Select(x => (int) double.Parse(x, CultureInfo.InvariantCulture)).ToArray();
        }

        public override float GetFloat(int index)
        {
            ValidateIndex(index);

            return (float) double.Parse(Values[index], CultureInfo.InvariantCulture);
        }

        public override float[] GetFloats()
        {
            return Values.Select(x => (float) double.Parse(x, CultureInfo.InvariantCulture)).ToArray();
        }

        public override double GetDouble(int index)
        {
            ValidateIndex(index);
            
            return double.Parse(Values[index], CultureInfo.InvariantCulture);
        }

        public override double[] GetDoubles()
        {
            return Values.Select(double.Parse).ToArray();
        }

        public override string GetString(int index)
        {
            ValidateIndex(index);

            return Values[index];
        }

        public override string[] GetStrings()
        {
            return Values;
        }
        
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Values.Length)
            {
                throw new ArgumentException($"Index {index} does not exist.");
            }
        }
    }
}