namespace api.DataAccess.Repositories.WeatherForecasts;
public class WeatherForecastRepository : Repository<WeatherForecast, WeatherForecastDto>, IWeatherForecastRepository
{
    public WeatherForecastRepository(ApplicationDbContext db, ILogger<Repository<WeatherForecast, WeatherForecastDto>> logger) : base(db, logger)
    { }
}