namespace TemperatureSensor.Infrastructure;

internal class TemperatureContextFactory : IDesignTimeDbContextFactory<TemperatureContext>
{
    public TemperatureContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TemperatureContext>();
        optionsBuilder.UseSqlite("Data Source=TemperatureCaptor.db");

        return new TemperatureContext(optionsBuilder.Options);
    }
}