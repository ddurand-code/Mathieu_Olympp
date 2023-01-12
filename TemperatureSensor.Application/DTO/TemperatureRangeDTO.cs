namespace TemperatureSensor.Application.DTO;

public class TemperatureRangeDTO
{
    public int UpperLimit { get; set; }
    public int LowerLimit { get; set; }
    public string Label { get; set; } = string.Empty;
}