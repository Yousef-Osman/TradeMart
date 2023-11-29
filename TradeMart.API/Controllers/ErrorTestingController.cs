using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TradeMart.Application.Models.Responses;
using TradeMart.Domian.Entities;
using TradeMart.Infrastructure.Data;

namespace TradeMart.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ErrorTestingController : ControllerBase
{
    private readonly AppDbContext _context;

    public ErrorTestingController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("NotFound/{id}")]
    public IActionResult GetNotFound(int id)
    {
        return NotFound(new ErrorResponse(statusCode: (int)HttpStatusCode.NotFound));
    }

    [HttpGet("BadRequest")]
    public IActionResult GetBadRequest()
    {
        return BadRequest(new ErrorResponse(statusCode: (int)HttpStatusCode.BadRequest));
    }

    [HttpGet("ValidationRequest")]
    public IActionResult GetBadRequestId(int id, int num)
    {
        return Ok("ValidationRequest works");
    }

    [HttpGet("InternalError")]
    public IActionResult GetInternalError()
    {
        Product product = _context.Products.Find(110);
        var str = product.ToString();

        return Ok(str);
    }

    [Authorize]
    [HttpGet("AuthTest")]
    public IActionResult AuthTest()
    {
        return Ok("auth works");
    }
}
