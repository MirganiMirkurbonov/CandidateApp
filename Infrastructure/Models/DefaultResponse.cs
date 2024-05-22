using Domain.Enumerators;
using Infrastructure.Extensions;

namespace Infrastructure.Models;

public class DefaultResponse<T>
{
    public bool Success { get; set; } = true;

    public string? Error { get; set; }

    public T Result { get; set; }

    public DefaultResponse(T result)
    {
        Success = true;
        Result = result;
    }
    
    public DefaultResponse(string result)
    {
        Success = false;
        Error = result;
    }
    

    public DefaultResponse(ErrorCodeEnum errorCodeEnum)
    {
        // TODO: override httpStatusCode as needed
        Error = errorCodeEnum.Localize();
        Success = false;
    }
    public static implicit operator DefaultResponse<T>(T result) => new(result);
    public static implicit operator DefaultResponse<T>(ErrorCodeEnum error) => new(error);

}