
namespace BasicRumiToGregorianConverter.Exceptions
{
    /// <summary>
    /// Represents errors that occur when a violation of the Rumi 125 Law is detected within the application.
    /// </summary>
    /// <remarks>This exception is intended to signal specific business logic violations related to the Rumi
    /// 125 Law.  Catch this exception to handle such violations distinctly from other application errors.</remarks>
    public class Rumi125LawException : ApplicationException
    {
        public Rumi125LawException()
        {
        }

        public Rumi125LawException(string? message) : base(message)
        {
        }

        public Rumi125LawException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
