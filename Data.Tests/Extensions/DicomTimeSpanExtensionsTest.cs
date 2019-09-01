using System;
using Osmosys.Data.Extensions;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.Extensions
{
    public class DicomTimeSpanExtensionsTest
    {
        [Fact]
        public void CanConvertRangeToString()
        {
            var time = new TimeSpan(0, 23, 10, 21, 30);
            var singleValue = new Range<TimeSpan>(time);
            Assert.Equal("231021.030000", singleValue.ToDicomString());

            var timeB = new TimeSpan(0, 23, 12, 23, 10);
            var range = new Range<TimeSpan>(time, timeB);
            Assert.Equal("231021.030000-231223.010000", range.ToDicomString());
        }

        [Fact]
        public void CanConvertTimeToString()
        {
            var timeA = new TimeSpan(0, 1, 2, 4, 5);
            var actualA = timeA.ToDicomString();
            var expectedA = "010204.005000"; 
            Assert.Equal(expectedA, actualA);
            
            var timeB = new TimeSpan(0, 1, 2, 4, 0);
            var actualB = timeB.ToDicomString();
            var expectedB = "010204";
            Assert.Equal(expectedB, actualB);

            var timeC = new TimeSpan(0, 1, 2, 0, 0);
            var actualC = timeC.ToDicomString();
            var expectedC = "0102";
            Assert.Equal(expectedC, actualC);

            var timeD = new TimeSpan(0, 1, 0, 0, 0);
            var actualD = timeD.ToDicomString();
            var expectedD = "01";
            Assert.Equal(expectedD, actualD);

            var timeE = new TimeSpan(0);
            var actualE = timeE.ToDicomString();
            var expectedE = "00";
            Assert.Equal(expectedE, actualE);
        }
    }
}