using System;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class DicomTimeTest
    {
        [Fact]
        public void CanReadTime()
        {
            var expected = DateTime.Now.TimeOfDay;
            var tag = new DicomTag(1, 2);
            var time = new DicomTime(tag, expected);
            var actual = time.GetTime(0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThrowsOnInvalidTimeRead()
        {
            var expected = DateTime.Now.TimeOfDay;
            var tag = new DicomTag(1, 2);
            var time = new DicomTime(tag, expected);
            Assert.Throws<ArgumentException>(() => time.GetTime(1));
        }

        [Fact]
        public void CanReadTimes()
        {
            var expected = new[] {DateTime.Now.TimeOfDay};
            var tag = new DicomTag(1, 2);
            var time = new DicomTime(tag, expected);
            var actual = time.GetTimes();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanUpdateTime()
        {
            var tag = new DicomTag(1, 2);
            var time = new DicomTime(tag, null);
            var expected = DateTime.Now.TimeOfDay;
            time.Update(expected);
            var actual = time.GetTime(0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanUpdateTimes()
        {
            var tag = new DicomTag(1, 2);
            var time = new DicomTime(tag, null);
            var expected = new[] {DateTime.Now.TimeOfDay, DateTime.Now.AddHours(1).TimeOfDay};
            time.Update(expected);
            var actual = time.GetTimes();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReplacesNullWithEmptyArray()
        {
            var tag = new DicomTag(1, 2);
            var time = new DicomTime(tag, DateTime.Now.TimeOfDay);
            time.Update(null as TimeSpan[]);
            var actual = time.GetTimes();
            Assert.Empty(actual);
        }
    }
}