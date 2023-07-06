namespace api.DataAccess.Repositories.EfCoreRepository;
public class WeatherForecastEfCoreRepository : EfcoreRepository<WeatherForecast, WeatherForecastDto>, IWeatherForecastEfCoreRepository
{
    public WeatherForecastEfCoreRepository(ApplicationDbContext db, ILogger<EfcoreRepository<WeatherForecast, WeatherForecastDto>> logger) : base(db, logger)
    { }
}