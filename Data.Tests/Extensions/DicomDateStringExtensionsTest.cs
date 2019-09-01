using System;
using System.Linq;
using Osmosys.Data.Extensions;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.Extensions
{
    public class DicomDateStringExtensionsTest
    {
        [Fact]
        public void CanConvertDateStringsToRanges()
        {
            var dates = new[]
            {
                "20190810",
                "20180201-20190203"
            };

            var actual = dates.ToDateRanges().ToArray();

            Assert.Equal(2, actual.Length);

            var expectedA = new Range<DateTime>(new DateTime(2019, 08, 10));
            var expectedB = new Range<DateTime>(new DateTime(2018, 2, 1), new DateTime(2019, 2, 3));
            
            Assert.Equal(expectedA, actual[0]);
            Assert.Equal(expectedB, actual[1]);
        }

        [Fact]
        public void CanConvertMultiDateStringToRanges()
        {
            var date = "20190810\\20180201-20190203";
            
            var actual = date.ToDateRanges().ToArray();
            
            Assert.Equal(2, actual.Length);
            
            var expectedA = new Range<DateTime>(new DateTime(2019, 08, 10));
            var expectedB = new Range<DateTime>(new DateTime(2018, 2, 1), new DateTime(2019, 2, 3));
            
            Assert.Equal(expectedA, actual[0]);
            Assert.Equal(expectedB, actual[1]);
        }

        [Fact]
        public void CanConvertDateStringToRange()
        {
            var dateRange = "20180201-20190203";
            var date = "20180201";

            var actualRange = dateRange.ToDateRange();
            var actualDate = date.ToDateRange();
            
            var expectedA = new DateTime(2018, 2, 1);
            var expectedB = new DateTime(2019, 02, 03);
            var expectedRange = new Range<DateTime>(expectedA, expectedB);
            var expectedDate = new Range<DateTime>(expectedA);

            Assert.Equal(expectedRange, actualRange);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void CanConvertDateStringToDate()
        {
            var date = "20190203";

            var actual = date.ToDate();
            
            Assert.Equal(new DateTime(2019, 2, 3), actual);
        }
    }
}