namespace TemperatureSensor.Tests;

[TestClass]
public class TemperatureSensorTests
{
    private TemperatureService _tempService;
    [TestInitialize]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<TemperatureContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        _tempService = new TemperatureService(new TemperatureContext(options));
    }
    [TestMethod]
    public async Task Must_Have_One_Return()
    {
        // Arrange
        var query = new GetTemperatureQueryHandler(_tempService);

        // Act
        var temp = await query.Handle(new GetTemperatureQuery(), new CancellationToken());

        // Assert
        Assert.IsNotNull(temp);
        
    }
    [TestMethod]
    public async Task Must_Have_15_Items_Max()
    {
        // Arrange
        var queryArrange = new GetTemperatureQueryHandler(_tempService);
        for (int x = 0; x < 20; x++)
            _ = await queryArrange.Handle(new GetTemperatureQuery(), new CancellationToken());

        // Act
        var query = new GetTemperaturesQueryHandler(_tempService);
        var result = await query.Handle(new GetTemperaturesQuery(), new CancellationToken());

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Count() <= 15);
    }
    [TestMethod]
    public async Task Must_Check_Default_ThresholdValues()
    {
        var query = new GetTemperatureQueryHandler(_tempService);
        var temp = await query.Handle(new GetTemperatureQuery(), new CancellationToken());

        if (temp.TemperatureC > 19 && temp.TemperatureC < 30)
            Assert.AreEqual(temp.State, "WARM");
        else if (temp.TemperatureC < 19)
            Assert.AreEqual(temp.State, "COLD");
        else
            Assert.AreEqual(temp.State, "HOT");
    }
    [TestMethod]
    public async Task Must_Change_ThresholdValues()
    {
        // Arrange
        var command = new ModifyTemperatureRangeCommand(5, 15);
        var queryCommand = new ModifyTemperatureRangeCommandHandler(_tempService);
        _ = await queryCommand.Handle(command, new CancellationToken());

        var query = new GetTemperatureQueryHandler(_tempService);
        var temp = await query.Handle(new GetTemperatureQuery(), new CancellationToken());

        // Assert
        if (temp.TemperatureC > 5 && temp.TemperatureC < 15)
            Assert.AreEqual(temp.State, "WARM");
        else if (temp.TemperatureC < 5)
            Assert.AreEqual(temp.State, "COLD");
        else
            Assert.AreEqual(temp.State, "HOT");
    }
    [TestMethod]
    public async Task Must_Valid_Threshold()
    {
        // Arrange
        var command = new ModifyTemperatureRangeCommand(5, 15);
        var validator = new ModifyTemperatureRangeCommandValidator();

        // Act
        var v = validator.Validate(command);

        // Assert
        Assert.IsTrue(v.IsValid);
    }
    [TestMethod]
    public async Task Must_Invalid_Threshold()
    {
        // Arrange
        var command = new ModifyTemperatureRangeCommand(15, 5);
        var validator = new ModifyTemperatureRangeCommandValidator();

        // Act
        var v = validator.Validate(command);

        // Assert
        Assert.IsFalse(v.IsValid);
    }
}