using System;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class DicomDateTimeTest
    {
        [Fact]
        public void CanGetDate()
        {
            var dateA = new DateTime(2001, 09, 30);
            var dateB = new DateTime(2002, 09, 29);
            var tag = new DicomTag(2, 1);
            var date = new DicomDateTime(tag, new[] {dateA, dateB});

            var value = date.GetDate(1);

            Assert.Equal(dateB, value);
        }

        [Fact]
        public void ThrowsOnInvalidDateRead()
        {
            var dateA = new DateTime(2001, 09, 30);
            var tag = new DicomTag(2, 1);
            var date = new DicomDateTime(tag, dateA);

            Assert.Throws<ArgumentException>(() => date.GetDate(1));
        }

        [Fact]
        public void CanGetDates()
        {
            var dates = new[] {new DateTime(2001, 09, 30)};
            var tag = new DicomTag(2, 1);
            var date = new DicomDateTime(tag, dates);

            var values = date.GetDates();

            Assert.Equal(dates, values);
        }

        [Fact]
        public void ReplacesNullWithEmptyArray()
        {
            var tag = new DicomTag(2, 1);
            var date = new DicomDateTime(tag, null);
            var actual = date.GetDates();
            Assert.Empty(actual);
        }


        [Fact]
        public void ThrowsOnStringRead()
        {
            var expected = new DateTime(2019, 03, 21);
            var tag = new DicomTag(2, 1);
            var date = new DicomDateTime(tag, expected);

            Assert.Throws<InvalidCastException>(() => date.GetString(0));
            Assert.Throws<InvalidCastException>(() => date.GetStrings());
        }
    }
}