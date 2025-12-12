namespace BasicRumiToGregorianConverter.Model
{
    public class CalendarModel
    {
        public CalendarModel(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

    }
}
