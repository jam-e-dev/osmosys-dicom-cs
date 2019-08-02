using System;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class DicomUniqueIdentifierTest
    {
        [Fact]
        public void CanNotReadDate()
        {
            var tag = new DicomTag(1, 2);
            var value = string.Empty;
            var uid = new DicomUniqueIdentifier(tag, value);

            Assert.Throws<InvalidCastException>(() => uid.GetDate(0));
            Assert.Throws<InvalidCastException>(() => uid.GetDates());
        }
    }
}