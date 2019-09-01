using System;
using Osmosys.Data.ValueRepresentations;
using Xunit;

namespace Osmosys.Data.Tests.ValueRepresentations
{
    public class DicomDateTest
    {
        [Fact]
        public void CanReadDate()
        {
            var expected = TestData.DateTimes;
            var da = new DicomDate(TestData.Tag, expected);
            var actual = da.GetDate(1);
            Assert.Equal(expected[1], actual.Min);
        }

        [Fact]
        public void CannotReadInvalidDate()
        {
            var expected = TestData.DateTime;
            var da = new DicomDate(TestData.Tag, expected);
            Assert.Throws<ArgumentException>(() => da.GetDate(1));
            Assert.Throws<ArgumentException>(() => da.GetDate(-1));
        }

        [Fact]
        public void CanReadDates()
        {
            var expected = TestData.DateTimeRange;
            var da = new DicomDate(TestData.Tag, expected);
            var actual = da.GetDates();
            Assert.Equal(new[]{expected}, actual);
        }

        [Fact]
        public void CanReadString()
        {
            var expected = new[]{"20191003", "20191104"};
            var da = new DicomDate(TestData.Tag, expected);
            var actual = da.GetString();
            Assert.Equal(expected[0], actual);
        }

        [Fact]
        public void CanReadStrings()
        {
            var expected = new[]{"20191003", "20191104"};
            var da = new DicomDate(TestData.Tag, string.Join("\\", expected));
            var actual = da.GetStrings();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanReadRangeString()
        {
            var expected = new[]{"20190102-20191003", "20190203-20190304"};
            var da = new DicomDate(TestData.Tag, expected);
            var actual = da.GetString();
            Assert.Equal(expected[0], actual);
        }

        [Fact]
        public void CanReadRangeStrings()
        {
            var expected = "20190102-20191003";
            var da = new DicomDate(TestData.Tag, expected);
            var actual = da.GetStrings();
            Assert.Equal(new[] {expected}, actual);
        }

        [Fact]
        public void CanReplaceNull()
        {
            var da = new DicomDate(TestData.Tag, null as DateTime[]);
            Assert.Empty(da.GetStrings());
            
            da = new DicomDate(TestData.Tag, null as Range<DateTime>);
            Assert.Empty(da.GetStrings());
            
            da = new DicomDate(TestData.Tag, null as Range<DateTime>[]);
            Assert.Empty(da.GetStrings());
        }

        [Fact]
        public void CannotReadInts()
        {
            var da = new DicomDate(TestData.Tag, TestData.DateTime);
            Assert.Throws<InvalidCastException>(() => da.GetInt());
            Assert.Throws<InvalidCastException>(() => da.GetInts());
        }

        [Fact]
        public void CannotReadFloats()
        {
            var da = new DicomDate(TestData.Tag, TestData.DateTime);
            Assert.Throws<InvalidCastException>(() => da.GetFloat());
            Assert.Throws<InvalidCastException>(() => da.GetFloats());
        }

        [Fact]
        public void CannotReadDoubles()
        {
            var da = new DicomDate(TestData.Tag, TestData.DateTime);
            Assert.Throws<InvalidCastException>(() => da.GetDouble());
            Assert.Throws<InvalidCastException>(() => da.GetDoubles());
        }
    }
}