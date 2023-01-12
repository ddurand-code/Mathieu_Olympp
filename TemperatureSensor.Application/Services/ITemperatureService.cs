namespace TemperatureSensor.Application.Services;

public interface ITemperatureService
{
    TemperatureDTO GetCurrentTemperature();
    List<TemperatureDTO> GetCurrentTemperatures();
    Unit UpdateTemperatureRangeAsync(ModifyTemperatureRangeCommand request);
}