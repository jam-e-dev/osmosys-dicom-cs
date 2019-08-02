using System;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class ApplicationEntityTest
    {
        [Fact]
        public void StoresTag()
        {
            var values = Array.Empty<string>();
            var tag = new DicomTag(1, 2);
            var ae = new ApplicationEntity(tag, values);
            
            Assert.Equal(tag, ae.Tag);
        }
        [Fact]
        public void ThrowsOnMissingTag()
        {
            var values = Array.Empty<string>();

            Assert.Throws<ArgumentNullException>(() => new ApplicationEntity(null, values));
        }

        [Fact]
        public void CanReadString()
        {
            var tag = new DicomTag(1, 2);
            var ae = new ApplicationEntity(tag, "Example");
            
            var value = ae.GetString(0);
            
            Assert.Equal("Example", value);
        }

        [Fact]
        public void ThrowsOnInvalidStringRead()
        {
            var tag = new DicomTag(1, 2);
            var values = new[] {"Example"};
            var ae = new ApplicationEntity(tag, values);

            Assert.Throws<ArgumentException>(() => ae.GetString(1));
            Assert.Throws<ArgumentException>(() => ae.GetString(-1));
        }

        [Fact]
        public void CanReadStrings()
        {
            var tag = new DicomTag(1, 2);
            var values = new[] {"Example"};
            var ae = new ApplicationEntity(tag, values);
            
            Assert.Equal(values, ae.GetStrings());
        }

        [Fact]
        public void CanUpdateString()
        {
            var tag = new DicomTag(1, 2);
            var values = new[] {"Example"};
            var ae = new ApplicationEntity(tag, values);
            
            ae.Update("Another");
            
            Assert.Equal("Another", ae.GetString(0));
        }

        [Fact]
        public void CanUpdateStrings()
        {
            var tag = new DicomTag(1, 2);
            var values = new[] {"Example"};
            var newValues = new[] {"Another"};
            var ae = new ApplicationEntity(tag, values);
            
            ae.Update(newValues);
            
            Assert.Equal("Another", ae.GetString(0));
        }
        
        [Fact]
        public void ReplacesNullWithEmptyArray()
        {
            var tag = new DicomTag(1, 2);
            var ae = new ApplicationEntity(tag, null as string[]);
            
            Assert.Empty(ae.GetStrings());
        }
    }
}