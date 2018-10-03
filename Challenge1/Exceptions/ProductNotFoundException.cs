using System.Net;

namespace Challenge1.Exceptions
{
    public class ProductNotFoundException:BaseException
    {
        public string _message;

        public ProductNotFoundException(string message)
        {
            _message = message;
        }

        public override string Body() => _message;

        public override HttpStatusCode Status() => HttpStatusCode.NotFound;
    }
}
