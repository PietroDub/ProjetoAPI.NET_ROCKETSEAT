using System.Net;

namespace ProductClientHub.Exceptions.ExceptionsBase
{
    public class ErroOnValidationException : ProductClientException
    {
        private readonly List<string> _Errors;
        public ErroOnValidationException(List<string> errorsMessages) : base(string.Empty)
        {
            _Errors = errorsMessages;
        }

        public override List<string> GetErrors()
        {
            return _Errors;
        }

        public override HttpStatusCode GetHttpStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}
