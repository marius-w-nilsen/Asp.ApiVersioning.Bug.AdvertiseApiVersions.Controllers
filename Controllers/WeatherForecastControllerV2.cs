using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Asp.ApiVersioning.Bug.AdvertiseApiVersions.Controllers;

[ApiController]
[ApiVersion(2)]
[Route("api/v{version:apiVersion}/[controller]")]

public class WeatherForecastV2Controller : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastV2Controller> _logger;

    public WeatherForecastV2Controller(ILogger<WeatherForecastV2Controller> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecastV2")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
