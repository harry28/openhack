using System.Net;

namespace Challenge1.Exceptions
{
    public class RatingException:BaseException
    {
        public string _message;

        public RatingException(string message)
        {
            _message = message;
        }

        public override string Body() => _message;

        public override HttpStatusCode Status() => HttpStatusCode.NotFound;
    }
}
