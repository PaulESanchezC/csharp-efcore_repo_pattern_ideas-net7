namespace api.DataAccess.Repositories.DappersRepository;
public interface IDapperRepository
{
    Task<IDapperResultOption<WeatherForecastStruct, WeatherForecastDto>> CreateAsync(WeatherForecastStruct objectToCreate, CancellationToken cancellationToken = default);
    Task<IDapperResultOption<WeatherForecastStruct, WeatherForecastDto>> GetAllAsync(CancellationToken cancellationToken = default);
}