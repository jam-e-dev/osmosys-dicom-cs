using System;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class DicomDecimalStringTest
    {
        [Fact]
        public void CanReadInt()
        {
            var tag = new DicomTag(1, 2);
            var ds = new DicomDecimalString(tag, 1);
            var actual = ds.GetInt(0);
            Assert.Equal(1, actual);
        }

        [Fact]
        public void ThrowsOnInvalidRead()
        {
            var tag = new DicomTag(1, 2);
            var ds = new DicomDecimalString(tag, null as string);
            Assert.Throws<ArgumentException>(() => ds.GetInt(0));
        }

        [Fact]
        public void CanReadInts()
        {
            var expected = new[] {1, 2};
            var tag = new DicomTag(1, 2);
            var ds = new DicomDecimalString(tag, expected);
            var actual = ds.GetInts();
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void CanReadFloat()
        {
            var tag = new DicomTag(1, 2);
            var ds = new DicomDecimalString(tag, 1.345f);
            var actual = ds.GetFloat(0);
            Assert.Equal(1.345f, actual);
        }

        [Fact]
        public void CanReadFloats()
        {
            var expected = new[] {1.2f, 1.3f};
            var tag = new DicomTag(1, 2);
            var ds = new DicomDecimalString(tag, expected);
            var actual = ds.GetFloats();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanReadDouble()
        {
            var tag = new DicomTag(1, 2);
            var ds = new DicomDecimalString(tag, 1.345);
            var actual = ds.GetDouble(0);
            Assert.Equal(1.345, actual);
        }

        [Fact]
        public void CanReadDoubles()
        {
            var expected = new[] {1.2, 1.3};
            var tag = new DicomTag(1, 2);
            var ds = new DicomDecimalString(tag, expected);
            var actual = ds.GetDoubles();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanReadString()
        {
            var expected = "1";
            var tag = new DicomTag(1, 2);
            var ds = new DicomDecimalString(tag, expected);
            var actual = ds.GetString(0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanReadStrings()
        {
            var expected = new[] {"1", "2"};
            var tag = new DicomTag(1, 2);
            var ds = new DicomDecimalString(tag, expected);
            var actual = ds.GetStrings();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThrowsOnTimeRead()
        {
            var tag = new DicomTag(1, 2);
            var ds = new DicomDecimalString(tag, null as string);
            Assert.Throws<InvalidCastException>(() => ds.GetTime(0));
            Assert.Throws<InvalidCastException>(() => ds.GetTimes());
        }
        
        [Fact]
        public void ThrowsOnDateRead()
        {
            var tag = new DicomTag(1, 2);
            var ds = new DicomDecimalString(tag, null as string);
            Assert.Throws<InvalidCastException>(() => ds.GetDate(0));
            Assert.Throws<InvalidCastException>(() => ds.GetDates());
        }
    }
}