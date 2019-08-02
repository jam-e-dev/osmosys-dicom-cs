using Xunit;

namespace Osmosys.Data.Tests
{
    public class DicomTagTest
    {
        [Fact]
        public void IsComparedByValue()
        {
            var tagA = new DicomTag(1, 2);
            var tagB = new DicomTag(1, 2);
            var tagC = new DicomTag(2, 3);
            
            Assert.True(tagA == tagB);
            Assert.True(tagA != tagC);
        }
    }
}