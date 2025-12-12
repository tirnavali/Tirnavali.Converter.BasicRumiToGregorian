using BasicRumiToGregorianConverter.Exceptions;

namespace Tirnavali.BasicRumiToGregorianConverter.Application
{
    public static class Converter
    {
        private readonly static Dictionary<int, int> DaysOfMonth = new Dictionary<int, int>
        {
            { 1, 31 },
            { 2, 30 },
            { 3, 31 },
            { 4, 30 },
            { 5, 31 },
            { 6, 31 },
            { 7, 30 },
            { 8, 31 },
            { 9, 30 },
            { 10, 31 },
            { 11, 31 },
            { 12, 28 },
        };


        private static CalendarModel AdjustYearAndMonth(int year, int month)
        {
            if (month == 11 || month == 12)
            {
                year = year + 585;
                month = month - 10;
            }
            else if (month <= 10)
            {
                year = year + 584;
                month = month + 2;
            }
            else
            {
                year = year + 585;
                month = month + 2;
                month = month % 12;
            }
            return new CalendarModel(year, month, 0);
        }

        private static CalendarModel CalculateDateBetween1332_1256(int year, int month, int day)
        {
            int increaseAmount = 12; // rumi takvime 1900 yillari oncesi 12 gun ekleniyor
            if (year >= 1316 && year <= 1332)
            { // 13 day artis
                increaseAmount = 13;
            }

            if (day <= 17 && month < 12)
            {
                day = day + increaseAmount;
            }

            else if (day <= 15 && month == 12)
            {
                day = day + increaseAmount;
            }

            else if ((day == 30 || day == 31) && month == 12)
            {
                throw new ApplicationException("Böyle bir tarih yok!");
            }

            else if (day > 15 && month == 12)
            {
                day = day + increaseAmount;
                if (year % 4 != 3)
                {
                    day = day % DaysOfMonth[month];
                    //month = month + 1;
                }
                else
                {
                    day = day % (DaysOfMonth[month] + 1);
                }
                month = month + 1;
            }

            else if (day > 17 && day <= DaysOfMonth[month])
            {//18
                day = day + increaseAmount;
                if (DaysOfMonth[month] == 30)
                {
                    day = day % DaysOfMonth[month];
                    month = month + 1;
                }

                if (DaysOfMonth[month] == 31)
                {
                    if (day > 31)
                    {
                        day = day % DaysOfMonth[month];
                        month = month + 1;
                    }
                }
            }

            return new CalendarModel(year, month, day);
        }

        public static DateOnly ConvertToGregorian(int year, int month, int day)
        {

            //month += 1;

            if (year > 1341)
            {
                throw new LastRumiDayException("Böyle bir rumî tarih yok");
            }

            if (year == 1341 && month == 12 && day > 26)
            {
                throw new LastRumiDayException("26 Birincikanun 1341 tarihi TBMM kanun no:698'ya göre en son resmi rumi gün 26.12.1341'dir.");
            }

            if (year >= 1334 && year < 1342)
            {
                year = year + 584;
                return new DateOnly(year, month, day);
            }

            if (year == 1333 && month > 10)
            {
                throw new Rumi125LawException("Böyle bir rumî tarih yok");
            }

            if (year == 1333 && month < 11)
            {
                month = month + 2;
                year = year + 584;
                return new DateOnly(year, month, day);
            }

            if (year <= 1255)
            {
                throw new OutOfBeginRumiDayException("Böyle bir rumî tarih yok.");
            }

            if (year == 1332 && month == 12 && day > 15)
            {
                throw new Rumi125LawException("Böyle bir rumî tarih yok. Bakınız, TBMM Kanun no: 125");
            }


            if (year >= 1256 && year <= 1332)
            { // 13 day artis
                var result = CalculateDateBetween1332_1256(year, month, day);
                day = result.Day;
                var adjustedYearAndMonth = AdjustYearAndMonth(result.Year, result.Month);
                year = adjustedYearAndMonth.Year;
                month = adjustedYearAndMonth.Month;
            }
            return new DateOnly(year, month, day);
        }
    }
}
