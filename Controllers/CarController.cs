using CarSeller.Data;
using CarSeller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSeller.Controllers;

[ApiController]
[Route("v1")]
public class CarController : ControllerBase
{
    [HttpGet("cars")]
    public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
    {
        var cars = await context.Cars.ToListAsync();
        return Ok(cars);
    }
    
    [HttpGet("cars/{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromServices] AppDbContext context)
    {
        var car = await context
            .Cars
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if(car  == null)
            return NotFound();
        
        return Ok(car);
    }

    [HttpPost("cars")]
    public async Task<IActionResult> PostAsync([FromBody] Car model, [FromServices] AppDbContext context)
    {
        await context.Cars.AddAsync(model);
        await context.SaveChangesAsync();

        return Created($"v1/cars/{model.Id}", model);
    }
    
    [HttpPut("cars/{id:int}")]
    public async Task<IActionResult> PostAsync([FromRoute] int id, [FromBody] Car model, [FromServices] AppDbContext context)
    {
        var car = await context
            .Cars
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if(car  == null)
            return NotFound();

        car.OwnerId = model.OwnerId;
        car.Name = model.Name;
        car.Brand = model.Brand;
        car.Model = model.Model;
        car.Year = model.Year;
        car.Image = model.Image;
        car.LastUpdateDate = DateTime.Now;
        car.Price = model.Price;
        
        context.Cars.Update(car);
        await context.SaveChangesAsync();

        return Ok(model);
    }
    
    [HttpDelete("cars/{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id, [FromServices] AppDbContext context)
    {
        var car = await context
            .Cars
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if(car  == null)
            return NotFound();
        
        context.Cars.Remove(car);
        await context.SaveChangesAsync();

        return Ok(car);
    }
}