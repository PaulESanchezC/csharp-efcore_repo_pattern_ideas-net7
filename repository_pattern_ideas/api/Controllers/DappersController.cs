namespace api.Controllers;
[ApiController, Route("api/v1/[controller]")]
public class DappersController : ControllerBase
{
    private readonly IDapperRepository _weatherForecast;
    private readonly ILogger<DappersController> _logger;
    public DappersController(ILogger<DappersController> logger, IDapperRepository weatherForecast)
    {
        _logger = logger;
        _weatherForecast = weatherForecast;
    }

    [HttpGet]
    public async Task<IActionResult> GetWeatherForecast(CancellationToken cancellationToken)
    {
        var request = await _weatherForecast.GetAllAsync(cancellationToken);
        if (!request.IsSuccessful)
            return BadRequest();

        var dtos = request.DatabaseObjects.Select(x => x.MapToDto());
        var response = new Response<WeatherForecastDto>()
        {
            IsSuccessfull = true,
            StatusCode = 200,
            Message = "Ok",
            ResponseObject = dtos.ToList(),
            ResponseCount = dtos.Count(),
            TotalCount = dtos.Count()
        };
        return Ok(response);
    }

    [HttpPost("{amount:int}")]
    public async Task<IActionResult> CreateManyWeatherForeacast(int amount, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var fixture = new Fixture();
        for (var i = 0; i < amount; i++)
        {
            var weatherForecast = fixture.Create<WeatherForecastStruct>();
            weatherForecast.WeatherForecastId = 0;
            await _weatherForecast.CreateAsync(weatherForecast, cancellationToken);
        }

        return Ok();
    }
}