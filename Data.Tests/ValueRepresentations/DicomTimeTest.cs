using System;
using System.Linq;
using Osmosys.Data.Extensions;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class DicomTimeTest
    {
        [Fact]
        public void CanReadTime()
        {
            var expected = TestData.TimeSpan;
            var time = new DicomTime(TestData.Tag, expected);
            var actual = time.GetTime();
            Assert.Equal(expected, actual.Min);
        }

        [Fact]
        public void CanReadTimes()
        {
            var expected = new[] {TestData.TimeSpan, TestData.TimeSpan};
            var time = new DicomTime(TestData.Tag, expected);
            var actual = time.GetTimes();
            Assert.Equal(expected.Select(x => new Range<TimeSpan>(x)), actual);
        }

        [Fact]
        public void CanReadString()
        {
            var timeSpan = TestData.TimeSpan;
            var time = new DicomTime(TestData.Tag, timeSpan);
            var actual = time.GetString();
            Assert.Equal(timeSpan.ToDicomString(), actual);
        }

        [Fact]
        public void CanReadStrings()
        {
            var expected = new[] {TestData.TimeSpan, TestData.TimeSpan};
            var time = new DicomTime(TestData.Tag, expected);
            var actual = time.GetStrings();
            Assert.Equal(expected.Select(x => x.ToDicomString()), actual);
        }
        
        [Fact]
        public void ThrowsOnInvalidTimeRead()
        {
            var expected = TestData.TimeSpan;
            var time = new DicomTime(TestData.Tag, expected);
            Assert.Throws<ArgumentException>(() => time.GetTime(1));
            Assert.Throws<ArgumentException>(() => time.GetTime(-1));
        }

        [Fact]
        public void ReplacesNullWithEmptyArray()
        {
            var time = new DicomTime(TestData.Tag, null as Range<TimeSpan>);
            var actual = time.GetTimes();
            Assert.Empty(actual);
        }
    }
}