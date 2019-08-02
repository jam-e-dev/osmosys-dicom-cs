using System;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class DicomCodeStringTest
    {
        [Fact]
        public void CanNotReadDate()
        {
            var tag = new DicomTag(1, 2);
            var value = string.Empty;
            var cs = new DicomCodeString(tag, value);

            Assert.Throws<InvalidCastException>(() => cs.GetDate(0));
            Assert.Throws<InvalidCastException>(() => cs.GetDates());
        }
    }
}