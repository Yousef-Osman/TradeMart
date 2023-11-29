namespace TradeMart.Application.Models.Responses;
public class BaseResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }

    public BaseResponse(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message;
    }
}
