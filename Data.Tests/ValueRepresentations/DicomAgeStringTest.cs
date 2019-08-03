using System;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class DicomAgeStringTest
    {
        [Fact]
        public void ThrowsOnDateRead()
        {
            var tag = new DicomTag(1, 2);
            var value = string.Empty;
            var age = new DicomAgeString(tag, value);

            Assert.Throws<InvalidCastException>(() => age.GetDate(0));
            Assert.Throws<InvalidCastException>(() => age.GetDates());
        }
        
        [Fact]
        public void ThrowsOnIntRead()
        {
            var tag = new DicomTag(1, 2);
            var age = new DicomAgeString(tag, null as string);
            Assert.Throws<InvalidCastException>(() => age.GetInt(0));
            Assert.Throws<InvalidCastException>(() => age.GetInts());
        }
        
        [Fact]
        public void ThrowsOnFloatRead()
        {
            var tag = new DicomTag(1, 2);
            var age = new DicomAgeString(tag, null as string);
            Assert.Throws<InvalidCastException>(() => age.GetFloat(0));
            Assert.Throws<InvalidCastException>(() => age.GetFloats());
        }
        
        [Fact]
        public void ThrowsOnDoubleRead()
        {
            var tag = new DicomTag(1, 2);
            var age = new DicomAgeString(tag, null as string);
            Assert.Throws<InvalidCastException>(() => age.GetDouble(0));
            Assert.Throws<InvalidCastException>(() => age.GetDoubles());
        }
    }
}