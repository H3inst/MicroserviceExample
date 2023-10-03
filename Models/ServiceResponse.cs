namespace MicroserviceExample.Models;

public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;

    public static ServiceResponse<T> ThrowSuccessResponse(T data, string message = "")
    {
        return new ServiceResponse<T>
        {
            Data = data,
            Message = message,
            Success = true
        };
    }

    public static ServiceResponse<T> ThrowExceptionResponse(string message)
    {
        return new ServiceResponse<T>
        {
            Data = default,
            Success = false,
            Message = message
        };
    }
}