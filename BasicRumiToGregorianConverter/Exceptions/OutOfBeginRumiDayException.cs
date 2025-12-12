namespace BasicRumiToGregorianConverter.Exceptions
{
    /// <summary>
    /// The exception that is thrown when an operation encounters a date that is outside the valid range for the
    /// beginning of a Rumi day.
    /// </summary>
    /// <remarks>This exception typically indicates that a provided date or time value does not correspond to
    /// a valid "begin Rumi day" boundary as defined by the application's calendar logic.</remarks>
    public class OutOfBeginRumiDayException : ApplicationException
    {
        public OutOfBeginRumiDayException()
        {
        }

        public OutOfBeginRumiDayException(string? message) : base(message)
        {
        }

        public OutOfBeginRumiDayException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
