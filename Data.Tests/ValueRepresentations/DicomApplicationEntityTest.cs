using System;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class DicomApplicationEntityTest
    {
        [Fact]
        public void CanReadString()
        {
            var ae = new DicomApplicationEntity(TestData.Tag, TestData.ApplicationEntityMulti);
            var actual = ae.GetString(1);
            Assert.Equal(TestData.ApplicationEntityMultiArray[1], actual);
            
            ae = new DicomApplicationEntity(TestData.Tag, TestData.ApplicationEntityMultiArray);
            actual = ae.GetString(1);
            Assert.Equal(TestData.ApplicationEntityMultiArray[1], actual);
        }

        [Fact]
        public void CanReplaceNull()
        {
            var ae = new DicomApplicationEntity(TestData.Tag, null as string);
            var actual = ae.GetStrings();
            Assert.Empty(actual);
            
            ae = new DicomApplicationEntity(TestData.Tag, null as string[]);
        }

        [Fact]
        public void CannotReadInvalidString()
        {
            var ae = new DicomApplicationEntity(TestData.Tag, TestData.ApplicationEntity);
            Assert.Throws<ArgumentException>(() => ae.GetString(1));
            Assert.Throws<ArgumentException>(() => ae.GetString(-1));
        }

        [Fact]
        public void CanReadStrings()
        {
            var ae = new DicomApplicationEntity(TestData.Tag, TestData.ApplicationEntityMultiArray);
            var actual = ae.GetStrings();
            Assert.Equal(TestData.ApplicationEntityMultiArray, actual);
        }

        [Fact]
        public void CannotReadDates()
        {
            var ae = new DicomApplicationEntity(TestData.Tag, TestData.ApplicationEntity);
            Assert.Throws<InvalidCastException>(() => ae.GetDate());
            Assert.Throws<InvalidCastException>(() => ae.GetDates());
        }

        [Fact]
        public void CannotReadTimes()
        {
            var ae = new DicomApplicationEntity(TestData.Tag, TestData.ApplicationEntity);
            Assert.Throws<InvalidCastException>(() => ae.GetTime());
            Assert.Throws<InvalidCastException>(() => ae.GetTimes());
        }

        [Fact]
        public void CannotReadInts()
        {
            var ae = new DicomApplicationEntity(TestData.Tag, TestData.ApplicationEntity);
            Assert.Throws<InvalidCastException>(() => ae.GetInt());
            Assert.Throws<InvalidCastException>(() => ae.GetInts());
        }

        [Fact]
        public void CannotReadFloats()
        {
            var ae = new DicomApplicationEntity(TestData.Tag, TestData.ApplicationEntity);
            Assert.Throws<InvalidCastException>(() => ae.GetFloat(0));
            Assert.Throws<InvalidCastException>(() => ae.GetFloats());
        }

        [Fact]
        public void CannotReadDoubles()
        {
            var ae = new DicomApplicationEntity(TestData.Tag, TestData.ApplicationEntity);
            Assert.Throws<InvalidCastException>(() => ae.GetDouble());
            Assert.Throws<InvalidCastException>(() => ae.GetDoubles());
        }
    }
}