using Microsoft.AspNetCore.Mvc;

namespace CarSeller.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("/")]
    public string Get()
    {
        return "API is running.";
    }
}