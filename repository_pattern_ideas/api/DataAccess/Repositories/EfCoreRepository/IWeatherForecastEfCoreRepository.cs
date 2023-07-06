namespace api.DataAccess.Repositories.EfCoreRepository;
public interface IWeatherForecastEfCoreRepository : IEfCoreResultOption<WeatherForecast, WeatherForecastDto>, IEfCoreRepository<WeatherForecast, WeatherForecastDto>
{ }