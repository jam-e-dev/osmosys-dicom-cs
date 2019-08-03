using System;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class DicomMultiStringElementTest
    {
        [Fact]
        public void StoresTag()
        {
            var values = Array.Empty<string>();
            var tag = new DicomTag(1, 2);
            var ae = new DicomMultiStringElement(tag, values);
            
            Assert.Equal(tag, ae.Tag);
        }
        [Fact]
        public void ThrowsOnMissingTag()
        {
            var values = Array.Empty<string>();

            Assert.Throws<ArgumentNullException>(() => new DicomMultiStringElement(null, values));
        }

        [Fact]
        public void CanReadString()
        {
            var tag = new DicomTag(1, 2);
            var ae = new DicomMultiStringElement(tag, "Example");
            
            var value = ae.GetString(0);
            
            Assert.Equal("Example", value);
        }

        [Fact]
        public void ThrowsOnInvalidStringRead()
        {
            var tag = new DicomTag(1, 2);
            var values = new[] {"Example"};
            var ae = new DicomMultiStringElement(tag, values);

            Assert.Throws<ArgumentException>(() => ae.GetString(1));
            Assert.Throws<ArgumentException>(() => ae.GetString(-1));
        }

        [Fact]
        public void CanReadStrings()
        {
            var tag = new DicomTag(1, 2);
            var values = new[] {"Example"};
            var ae = new DicomMultiStringElement(tag, values);
            
            Assert.Equal(values, ae.GetStrings());
        }

        [Fact]
        public void ReplacesNullWithEmptyArray()
        {
            var tag = new DicomTag(1, 2);
            var ae = new DicomMultiStringElement(tag, null as string[]);
            
            Assert.Empty(ae.GetStrings());
        }
    }
}