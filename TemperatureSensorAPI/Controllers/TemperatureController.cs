namespace TemperatureSensorAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TemperatureController : ControllerBase
{
    private readonly ISender _sender;

    public TemperatureController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("GetTemperature")]
    public async Task<ActionResult<TemperatureDTO>> GetCurrentTemperature(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetTemperatureQuery(), cancellationToken);
        return Ok(result);
    }
    [HttpGet("GetTemperatures")]
    public async Task<ActionResult<IEnumerable<TemperatureDTO>>> GetHistoricalTemperature(CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new GetTemperaturesQuery(), cancellationToken));
    }
    [HttpPut("SetTemperatures")]
    public async Task<IActionResult> SetThreshold(ModifyTemperatureRangeCommand command, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(command, cancellationToken));
    }
}