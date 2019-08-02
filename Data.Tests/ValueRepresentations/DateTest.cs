using System;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class DateTest
    {
        [Fact]
        public void CanGetString()
        {
            var dateA = new DateTime(2001, 09, 30);
            var dateB = new DateTime(2002, 09, 29);
            var tag = new DicomTag(1, 2);
            var date = new Date(tag, new[] {dateA, dateB});
            
            var stringVal = date.GetString(1);
            
            Assert.Equal("20020929", stringVal);
        }

        [Fact]
        public void ThrowsOnInvalidStringRead()
        {
            var dateA = new DateTime(2001, 09, 30);
            var tag = new DicomTag(1, 2);
            var date = new Date(tag, dateA);

            Assert.Throws<ArgumentException>(() => date.GetString(1));
        }

        [Fact]
        public void CanGetStrings()
        {
            var dateA = new DateTime(2001, 09, 30);
            var dateB = new DateTime(2002, 09, 29);
            var tag = new DicomTag(1, 2);
            var date = new Date(tag, new[] {dateA, dateB});
            
            var values = date.GetStrings();
            
            Assert.Equal("20010930", values[0]);
            Assert.Equal("20020929", values[1]);
        }

        [Fact]
        public void CanGetDate()
        {
            var dateA = new DateTime(2001, 09, 30);
            var dateB = new DateTime(2002, 09, 29);
            var tag = new DicomTag(2, 1);
            var date = new Date(tag, new[] {dateA, dateB});

            var value = date.GetDate(1);

            Assert.Equal(dateB, value);
        }

        [Fact]
        public void ThrowsOnInvalidDateRead()
        {
            var dateA = new DateTime(2001, 09, 30);
            var tag = new DicomTag(2, 1);
            var date = new Date(tag, dateA);

            Assert.Throws<ArgumentException>(() => date.GetDate(1));
        }

        [Fact]
        public void CanGetDates()
        {
            var dates = new[] {new DateTime(2001, 09, 30)};
            var tag = new DicomTag(2, 1);
            var date = new Date(tag, dates);

            var values = date.GetDates();

            Assert.Equal(dates, values);
        }

        [Fact]
        public void CanUpdateDate()
        {
            var tag = new DicomTag(2, 1);
            var date = new Date(tag, null);
            var expected = DateTime.Now.Date;
            date.Update(expected);
            var actual = date.GetDate(0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanUpdateDates()
        {
            var tag = new DicomTag(2, 1);
            var expected = new[] {DateTime.Now, DateTime.Now.AddDays(1)};
            var date = new Date(tag, null);
            date.Update(expected);
            var actual = date.GetDates();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReplacesNullWithEmptyArray()
        {
            var tag = new DicomTag(2, 1);
            var date = new Date(tag, null);
            date.Update(null as string);
            var actual = date.GetDates();
            Assert.Empty(actual);
        }


        [Fact]
        public void CanUpdateString()
        {
            var dateString = "20190321";
            var expected = new DateTime(2019, 03, 21);
            var tag = new DicomTag(2, 1);
            var date = new Date(tag, null);
            date.Update(dateString);
            var actual = date.GetDate(0);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void CanUpdateStrings()
        {
            var dateStrings = new[]
            {
                "20191003",
                "20180228"
            };

            var tag = new DicomTag(2, 1);
            var date = new Date(tag, null);
            date.Update(dateStrings);
            var dates = date.GetDates();
            
            Assert.Equal(new DateTime(2019, 10, 03), dates[0]);
            Assert.Equal(new DateTime(2018, 02, 28), dates[1]);
        }
    }
}