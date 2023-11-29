using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMart.Application.Models.Responses;
public class ErrorResponse : BaseResponse
{
    public List<string> Errors { get; set; }
    public string Details { get; set; }

    public ErrorResponse(int statusCode, string message = null, string details = null, List<string> errors = null) : base(statusCode, message)
    {
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        Details = details;
        Errors = errors;
    }

    private string GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "Bad Request",
            401 => "Access Denied, Authorization Required",
            404 => "Resource Not Found",
            500 => "Internal Server Error",
            _ => "Something went wrong!",
        };
    }
}