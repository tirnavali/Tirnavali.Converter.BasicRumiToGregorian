
namespace BasicRumiToGregorianConverter.Exceptions
{
    /// <summary>
    /// The exception that is thrown when an operation attempts to advance beyond the last valid day in the Rumi
    /// calendar.
    /// </summary>
    /// <remarks>This exception is intended to signal that a date operation has exceeded the supported range
    /// of the Rumi calendar system.  Catch this exception to handle scenarios where date calculations must not surpass
    /// the final day defined by the Rumi calendar.</remarks>
    public class LastRumiDayException : ApplicationException
    {
        public LastRumiDayException(string? message) : base(message)
        {
        }
        public LastRumiDayException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
