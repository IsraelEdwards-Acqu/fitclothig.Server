using Microsoft.AspNetCore.Mvc;

namespace FITClothing.API.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("API Working");
    }
}