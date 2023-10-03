namespace MicroserviceExample.Common;

public class AppException : Exception
{
    public int HttpStatusCode { get; private set; }

    public AppException(string message, int httpStatusCode) : base(message)
    {
        HttpStatusCode = httpStatusCode;
    }
}