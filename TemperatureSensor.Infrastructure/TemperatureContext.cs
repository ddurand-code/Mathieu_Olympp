namespace TemperatureSensor.Infrastructure;

public class TemperatureContext : DbContext
{
    public TemperatureContext(DbContextOptions<TemperatureContext> opt) : base(opt)
    {
        // Fix SQL Lite bug
        Database.EnsureCreated();
    }

    public DbSet<Temperature> Temperatures { get; set; }

    public DbSet<TemperatureRange> TemperatureRanges { get; set; }
}