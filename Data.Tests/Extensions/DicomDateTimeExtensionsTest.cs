using System;
using Osmosys.Data.Extensions;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.Extensions
{
    public class DicomDateTimeExtensionsTest
    {
        [Fact]
        public void CanConvertDateToString()
        {
            var date = new DateTime(2017, 4, 21);
            var actual = date.ToDicomDateString();
            Assert.Equal("20170421", actual);
        }

        [Fact]
        public void CanConvertDateRangeToString()
        {
            var dateA = new DateTime(2017, 4, 20);
            var dateB = new DateTime(2017, 10, 3);
            var range = new Range<DateTime>(dateA, dateB);
            var actual = range.ToDicomDateString();
            Assert.Equal("20170420-20171003", actual);
        }
    }
}