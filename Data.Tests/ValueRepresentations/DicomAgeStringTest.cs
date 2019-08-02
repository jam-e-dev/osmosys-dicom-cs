using System;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class DicomAgeStringTest
    {
        [Fact]
        public void CanNotReadDate()
        {
            var tag = new DicomTag(1, 2);
            var value = string.Empty;
            var age = new DicomAgeString(tag, value);

            Assert.Throws<InvalidCastException>(() => age.GetDate(0));
            Assert.Throws<InvalidCastException>(() => age.GetDates());
        }
    }
}