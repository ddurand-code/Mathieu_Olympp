namespace TemperatureSensor.Infrastructure.Models;

public class Temperature
{
    public int Id { get; set; }
    public int TemperatureC { get; set; }
    public string State { get; set; }
    public DateTime Date { get; set; }
}