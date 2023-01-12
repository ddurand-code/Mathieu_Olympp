namespace TemperatureSensor.Infrastructure.Helpers;

internal static class InitializeTemperatures
{
   public static void Init(TemperatureContext context)
    {
        // Init
        context.TemperatureRanges.Add(new TemperatureRange
        {
            Label = "Threshold",
            LowerLimit = 19,
            UpperLimit = 30
        });
        context.SaveChanges();
    }
}