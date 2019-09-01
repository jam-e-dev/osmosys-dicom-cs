using System;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class DicomAgeStringTest
    {
        [Fact]
        public void CanReadString()
        {
            var age = new DicomAgeString(TestData.Tag, TestData.AgeString);
            var actual = age.GetString();
            Assert.Equal(TestData.AgeString, actual);
        }

        [Fact]
        public void CanReplaceNullInput()
        {
            var age = new DicomAgeString(TestData.Tag, null);
            var actual = age.GetString();
            Assert.Equal(string.Empty, actual);
        }

        [Fact]
        public void CannotReadInvalidString()
        {
            var age = new DicomAgeString(TestData.Tag, TestData.AgeString);
            Assert.Throws<ArgumentException>(() => age.GetString(1));
            Assert.Throws<ArgumentException>(() => age.GetString(-1));
        }

        [Fact]
        public void CanReadStrings()
        {
            var age = new DicomAgeString(TestData.Tag, TestData.AgeString);
            var actual = age.GetStrings();
            Assert.Equal(new[]{TestData.AgeString}, actual);
        }
        
        [Fact]
        public void CannotReadDates()
        {
            var age = new DicomAgeString(TestData.Tag, TestData.AgeString);
            Assert.Throws<InvalidCastException>(() => age.GetDate());
            Assert.Throws<InvalidCastException>(() => age.GetDates());
        }

        [Fact]
        public void CannotReadTimes()
        {
            var age = new DicomAgeString(TestData.Tag, TestData.AgeString);
            Assert.Throws<InvalidCastException>(() => age.GetTime());
            Assert.Throws<InvalidCastException>(() => age.GetTimes());
        }
        
        [Fact]
        public void CannotReadInts()
        {
            var age = new DicomAgeString(TestData.Tag, TestData.AgeString);
            Assert.Throws<InvalidCastException>(() => age.GetInt());
            Assert.Throws<InvalidCastException>(() => age.GetInts());
        }
        
        [Fact]
        public void CannotReadFloats()
        {
            var age = new DicomAgeString(TestData.Tag, TestData.AgeString);
            Assert.Throws<InvalidCastException>(() => age.GetFloat());
            Assert.Throws<InvalidCastException>(() => age.GetFloats());
        }
        
        [Fact]
        public void CannotReadDoubles()
        {
            var age = new DicomAgeString(TestData.Tag, TestData.AgeString);
            Assert.Throws<InvalidCastException>(() => age.GetDouble());
            Assert.Throws<InvalidCastException>(() => age.GetDoubles());
        }
    }
}