using System;
using System.Net;

namespace Challenge1.Exceptions
{
    public abstract class BaseException : Exception
    {
        public abstract HttpStatusCode Status();
        public abstract string Body();
    }
}
