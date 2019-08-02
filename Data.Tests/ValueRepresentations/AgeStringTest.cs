using System;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class AgeStringTest
    {
        [Fact]
        public void CanNotReadDate()
        {
            var tag = new DicomTag(1, 2);
            var value = string.Empty;
            var age = new AgeString(tag, value);

            Assert.Throws<InvalidCastException>(() => age.GetDate(0));
            Assert.Throws<InvalidCastException>(() => age.GetDates());
        }
    }
}