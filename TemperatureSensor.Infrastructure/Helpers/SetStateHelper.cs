namespace TemperatureSensor.Infrastructure.Helpers;

internal static class SetStateHelper
{
    public static string Set(TemperatureContext context, Temperature temp)
    {
        if (context.TemperatureRanges.FirstOrDefault(x => x.LowerLimit < temp.TemperatureC && x.UpperLimit > temp.TemperatureC) != null)
            return "WARM";
        if (context.TemperatureRanges.FirstOrDefault(x => x.LowerLimit > temp.TemperatureC) != null)
            return "COLD";
        return "HOT";
    }
}