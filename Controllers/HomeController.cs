using Microsoft.AspNetCore.Mvc;

namespace CarSeller.Controllers;

[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Get()
    {
        return Ok();
    }
}
