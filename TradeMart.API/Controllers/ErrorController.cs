using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeMart.Application.Models.Responses;

namespace TradeMart.API.Controllers;
[Route("errors/{code}")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    public IActionResult Error(int code)
    {
        return new ObjectResult(new ErrorResponse(statusCode: code));
    }
}
