using System;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class DicomApplicationEntityTest
    {
        [Fact]
        public void CanNotReadDate()
        {
            var tag = new DicomTag(1, 2);
            var value = string.Empty;
            var ae = new DicomApplicationEntity(tag, value);

            Assert.Throws<InvalidCastException>(() => ae.GetDate(0));
            Assert.Throws<InvalidCastException>(() => ae.GetDates());
        }
    }
}