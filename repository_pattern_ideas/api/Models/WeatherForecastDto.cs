namespace api.Models;
public struct WeatherForecastDto
{
    public Guid PublicId { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string Summary { get; set; }
    public DateOnly Date { get; set; }
}