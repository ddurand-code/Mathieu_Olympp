namespace TemperatureSensor.Application.Models;

public class TemperatureRange
{
    public int Id { get; set; }
    public int UpperLimit { get; set; }
    public int LowerLimit { get; set; }
    public string Label { get; set; } = string.Empty;
}