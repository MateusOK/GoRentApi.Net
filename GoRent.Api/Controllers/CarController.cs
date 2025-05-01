using GoRent.Application.Dtos.Request;
using GoRent.Application.Dtos.Response;
using GoRent.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoRent.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{

    private readonly ICarService _carService;
    
    public CarController(ICarService carService)
    {
        _carService = carService;
    }
    
    [HttpGet("test")]
    public string teste()
    {
        return  "Teste";
    }


    [HttpPost]
    public async Task<ActionResult<CarResponse>> CreateCar([FromBody] CarRequest carRequest)
    {
        var createdCar = await _carService.CreateAsync(carRequest);
        return CreatedAtAction(nameof(GetCarById), new { id = createdCar.Id }, createdCar);
    }

    [HttpGet]
    public async Task<ActionResult<List<CarResponse>>> GetAllCars()
    {
        var cars = await _carService.GetAllAsync();
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CarResponse>> GetCarById(string id)
    {
        var car = await _carService.GetByIdAsync(id);
        return car == null ? NotFound("Car not found") : Ok(car);
    }
}