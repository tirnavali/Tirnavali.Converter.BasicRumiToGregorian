
using BasicRumiToGregorianConverter.Exceptions;
using Tirnavali.BasicRumiToGregorianConverter.Application;

namespace BasicRumiToGregorianConverterTest
{
    public class ConverterTests
    {
        [Fact]
        public void ConvertValue_ValidInput_ReturnsExpectedOutput()
        {
            var expectedResult = new DateOnly(1907, 01, 13);
            var actualResult = Converter.ConvertToGregorian(1322, 10, 31);

            Assert.Equal(expectedResult, actualResult);

        }

        [Fact]
        public void ValidInput_ReturnsExpectedOutput()
        {
            var expectedResult = new DateOnly(1880, 03, 10);
            var actualResult = Converter.ConvertToGregorian(1295, 12, 27);

            Assert.Equal(expectedResult, actualResult);

        }

        [Fact]
        public void MaximumValidInput_ReturnsExpectedOutput()
        {
            int invalidYear = 1341;
            int month = 12;
            int day = 28;

            Assert.Throws<LastRumiDayException>(() =>
            {
                Converter.ConvertToGregorian(invalidYear, month, day);
            });
        }

        [Fact]
        public void InvalidInput()
        {
            int invalidYear = 1342;
            int month = 1;
            int day = 30;

            Assert.Throws<LastRumiDayException>(() =>
            {
                Converter.ConvertToGregorian(invalidYear, month, day);
            });

        }

        // -------------------------------------------------------------
        // Test Case 1: Standard Conversion (12 days offset)
        // Rumi: 1292-12-17 -> Gregorian: 1877-03-01
        [Fact]
        public void ConvertRumiToGregorian_Case1_StandardOffset()
        {
            var expectedResult = new DateOnly(1877, 03, 01);
            var actualResult = Converter.ConvertToGregorian(1292, 12, 17);

            Assert.Equal(expectedResult, actualResult);
        }

        // -------------------------------------------------------------
        // Test Case 2: Standard Conversion (Leap Year Era)
        // Rumi: 1318-12-28 -> Gregorian: 1903-03-13
        [Fact]
        public void ConvertRumiToGregorian_Case2_LeapYearEra()
        {
            var expectedResult = new DateOnly(1903, 03, 13);
            var actualResult = Converter.ConvertToGregorian(1318, 12, 28);

            Assert.Equal(expectedResult, actualResult);
        }

        // -------------------------------------------------------------
        // Test Case 3: Standard Conversion near Leap Boundary
        // Rumi: 1295-12-27 -> Gregorian: 1880-03-10
        [Fact]
        public void ConvertRumiToGregorian_Case3_NearLeapBoundary1()
        {
            var expectedResult = new DateOnly(1880, 03, 10);
            var actualResult = Converter.ConvertToGregorian(1295, 12, 27);

            Assert.Equal(expectedResult, actualResult);
        }

        // -------------------------------------------------------------
        // Test Case 4: Standard Conversion near Leap Boundary
        // Rumi: 1295-12-28 -> Gregorian: 1880-03-11
        [Fact]
        public void ConvertRumiToGregorian_Case4_NearLeapBoundary2()
        {
            var expectedResult = new DateOnly(1880, 03, 11);
            var actualResult = Converter.ConvertToGregorian(1295, 12, 28);

            Assert.Equal(expectedResult, actualResult);
        }

        // -------------------------------------------------------------
        // Test Case 5: Standard Conversion (Leap Day Check)
        // Rumi: 1295-12-29 -> Gregorian: 1880-03-12 (1880 is a Gregorian Leap Year)
        [Fact]
        public void ConvertRumiToGregorian_Case5_LeapDayCheck()
        {
            var expectedResult = new DateOnly(1880, 03, 12);
            var actualResult = Converter.ConvertToGregorian(1295, 12, 29);

            Assert.Equal(expectedResult, actualResult);
        }

        // -------------------------------------------------------------
        // Test Case 6: Standard Conversion (Non-Leap Year Check)
        // Rumi: 1294-12-28 -> Gregorian: 1879-03-12 
        [Fact]
        public void ConvertRumiToGregorian_Case6_NonLeapCheck()
        {
            var expectedResult = new DateOnly(1879, 03, 12);
            var actualResult = Converter.ConvertToGregorian(1294, 12, 28);

            Assert.Equal(expectedResult, actualResult);
        }

        // -------------------------------------------------------------
        // Test Case 7: Month Transition Check
        // Rumi: 1296-01-01 -> Gregorian: 1880-03-13
        [Fact]
        public void ConvertRumiToGregorian_Case7_MonthTransition()
        {
            var expectedResult = new DateOnly(1880, 03, 13);
            var actualResult = Converter.ConvertToGregorian(1296, 01, 01);

            Assert.Equal(expectedResult, actualResult);
        }

        // -------------------------------------------------------------
        // Test Case 8: Boundary Conversion (13-day offset era)
        // Rumi: 1327-12-29 -> Gregorian: 1912-03-13
        [Fact]
        public void ConvertRumiToGregorian_Case8_Boundary13DayOffset()
        {
            var expectedResult = new DateOnly(1912, 03, 13);
            var actualResult = Converter.ConvertToGregorian(1327, 12, 29);

            Assert.Equal(expectedResult, actualResult);
        }

        // -------------------------------------------------------------
        // Test Case 9: Final Valid Rumi Date (Maximum Date)
        // Rumi: 1341-12-26 -> Gregorian: 1925-12-26
        [Fact]
        public void ConvertRumiToGregorian_Case9_MaximumValidDate()
        {
            var expectedResult = new DateOnly(1925, 12, 26);
            var actualResult = Converter.ConvertToGregorian(1341, 12, 26);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ConvertToGregorian_YearAboveMaximum_ThrowsApplicationException()
        {
            int invalidYear = 1342;
            Assert.Throws<LastRumiDayException>(() =>
            {
                Converter.ConvertToGregorian(invalidYear, 1, 1);
            });
        }

        // Test Case 10: Invalid Input (Before Lower Year Bound)
        // Checks the logic: if (year <= 1255) { throw new OutOfBeginRumiDayException(...) }
        [Fact]
        public void ConvertToGregorian_YearBeforeMinimum_ThrowsOutOfBeginRumiDayException()
        {
            // ARRANGE: Use the last invalid year (1255) and one year before (1254)
            int invalidYear1 = 1255;
            int invalidYear2 = 1254;

            // ACT & ASSERT: Check the lowest valid date (1256) throws the exception

            // Check for year 1255 (should throw)
            Assert.Throws<OutOfBeginRumiDayException>(() =>
            {
                Converter.ConvertToGregorian(invalidYear1, 1, 1);
            });

            // Check for year 1254 (should also throw)
            Assert.Throws<OutOfBeginRumiDayException>(() =>
            {
                Converter.ConvertToGregorian(invalidYear2, 1, 1);
            });
        }
    }
}
