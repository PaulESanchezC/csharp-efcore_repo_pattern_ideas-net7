namespace api.DataAccess.Repositories.WeatherForecasts;

public interface IWeatherForecastRepository : IResultOption<WeatherForecast, WeatherForecastDto>, IRepository<WeatherForecast, WeatherForecastDto>
{
}