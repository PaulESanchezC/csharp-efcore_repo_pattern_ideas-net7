namespace api.Models;
[Index(nameof(PublicId), IsUnique = true)]
public class WeatherForecast
{
    [Key]
    public long WeatherForecastId { get; set; }
    public Guid PublicId { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    [MaxLength(250)]
    public string Summary { get; set; }
    public DateTime Date { get; set; }

    public WeatherForecastDto MapToDto()
    {
        var dto = new WeatherForecastDto()
        {
            Date = DateOnly.FromDateTime(Date),
            Summary = Summary,
            PublicId = PublicId,
            TemperatureC = TemperatureC
        };
        return dto;
    }
}