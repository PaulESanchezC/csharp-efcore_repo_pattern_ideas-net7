namespace api.DataAccess.Repositories.DappersRepository;
public class DapperWeatherForecastRepository : DapperResultOption<WeatherForecastStruct, WeatherForecastDto>, IDapperRepository
{
    private readonly IDbConnection _db;
    private readonly ILogger<DapperWeatherForecastRepository> _logger;
    public DapperWeatherForecastRepository(IConfiguration configure, ILogger<DapperWeatherForecastRepository> logger)
    {
        var connectionString = configure.GetConnectionString("ApplicationDbContext");
        _db = new SqlConnection(connectionString);
        _logger = logger;
    }

    public virtual async Task<IDapperResultOption<WeatherForecastStruct, WeatherForecastDto>> CreateAsync(WeatherForecastStruct objectToCreate, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Repository T:WeatherForecastStruct | CreateAllAsync");
        try
        {
            var query = "INSERT INTO @table (PublicId, TemperatureC, TemperatureF, Summary, Date) VALUES(@PublicId, @TemperatureC, @TemperatureF, @Summary, @Date)";
            var request = await _db.QuerySingleAsync<int>(query, new
            {
                objectToCreate.PublicId,
                objectToCreate.TemperatureC,
                objectToCreate.TemperatureF,
                objectToCreate.Summary,
                objectToCreate.Date
            });
            if (request > 0)
                SetSuccessResult(objectToCreate);
            else
                throw new SqlNullValueException("Something went wrong somewhere");

            return this;
        }
        catch (Exception e)
        {
            _logger.LogError("Repository T:WeatherForecastStruct | CreateAllAsync | error: {@0}", e);
            SetErrorResult(new() { Code = "1", IsError = true, Message = "empty result" });
            return this;
        }
    }

    public async Task<IDapperResultOption<WeatherForecastStruct, WeatherForecastDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Repository T:WeatherForecastStruct | GetAllAsync");
        var query = @"SELECT * FROM WeatherForecasts";
        var request = await _db.QueryAsync<WeatherForecastStruct>(query);

        if (request.Count() < 1)
        {
            _logger.LogError("Repository T:WeatherForecastStruct | GetAllAsync | error: empty result");
            SetErrorResult(new() { Code = "1", IsError = true, Message = "empty result" });
            return this;
        }

        SetSuccessResult(request.ToList());
        return this;
    }
}