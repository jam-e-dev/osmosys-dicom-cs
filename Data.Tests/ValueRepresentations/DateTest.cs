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
    }
}