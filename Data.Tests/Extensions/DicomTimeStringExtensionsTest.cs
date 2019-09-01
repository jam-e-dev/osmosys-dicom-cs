using System;
using Osmosys.Data.Extensions;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.Extensions
{
    public class DicomTimeStringExtensionsTest
    {
        [Fact]
        public void CanConvertStringToTime()
        {
            var stringA = "020304.005000";
            var actualA = stringA.ToTime();
            var expectedA = new TimeSpan(0, 2, 3, 4, 5);
            Assert.Equal(expectedA, actualA);
            
            var stringB = "020304";
            var actualB = stringB.ToTime();
            var expectedB = new TimeSpan(0, 2, 3, 4, 0);
            Assert.Equal(expectedB, actualB);
            
            var stringC = "0203";
            var actualC = stringC.ToTime();
            var expectedC = new TimeSpan(2, 3, 0);
            Assert.Equal(expectedC, actualC);

            var stringD = "02";
            var actualD = stringD.ToTime();
            var expectedD = new TimeSpan(2, 0, 0);
            Assert.Equal(expectedD, actualD);
        }

        [Fact]
        public void CanConvertStringToTimeRange()
        {
            var stringA = "020304-030405";
            var actualA = stringA.ToTimeRange();
            var expectedA = new Range<TimeSpan>(new TimeSpan(2, 3, 4), new TimeSpan(3, 4, 5));
            Assert.Equal(expectedA, actualA);
            
            var stringB = "020304";
            var actualB = stringB.ToTimeRange();
            var expectedB = new Range<TimeSpan>(new TimeSpan(2, 3, 4));
            Assert.Equal(expectedB, actualB);
        }

        [Fact]
        public void CanConvertMultiTimeStringToTimeRanges()
        {
            var timeString = "020304\\030405";
            var actual = timeString.ToTimeRanges();
            var expected = new[]
            {
                new Range<TimeSpan>(new TimeSpan(2, 3, 4)),
                new Range<TimeSpan>(new TimeSpan(3, 4, 5))
            };
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanConvertStringsToTimeRanges()
        {
            var timeStrings = new[] {"020304", "030405"};
            var actual = timeStrings.ToTimeRanges();
            var expected = new[]
            {
                new Range<TimeSpan>(new TimeSpan(2, 3, 4)),
                new Range<TimeSpan>(new TimeSpan(3, 4, 5))
            };

            Assert.Equal(expected, actual);
        }
    }
}