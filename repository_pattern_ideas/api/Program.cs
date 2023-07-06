var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<ApplicationDbContext>(options =>
{
    var enableDetailedErrors = configuration.GetValue<bool>("EnableDetailedErrors");
    var connectionString = configuration.GetConnectionString("ApplicationDbContext");
    options.EnableDetailedErrors(enableDetailedErrors);
    options.UseSqlServer(connectionString);
});
services.AddScoped<IWeatherForecastEfCoreRepository, WeatherForecastEfCoreRepository>();
services.AddScoped<IDapperRepository, DapperWeatherForecastRepository>();

var app = builder.Build();

app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
