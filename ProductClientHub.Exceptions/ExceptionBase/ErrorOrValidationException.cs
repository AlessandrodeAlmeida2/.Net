using ProductClientHub.Exceptions.ExeptionBase;
using System.Net;

namespace ProductClientHub.Exceptions.ExceptionBase
{
    public class ErrorOrValidationException : ProductClientHubException
    {
        private readonly List<string> _errors;

        public ErrorOrValidationException(List<string> errorMessage) : base(string.Empty)
        {
            _errors = errorMessage;
        }

        public override List<string> GetErrors()
        {
            return _errors;
        }

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
    }
}
