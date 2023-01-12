namespace TemperatureSensor.Application.Commands;

public sealed record ModifyTemperatureRangeCommand(int ColdThreshold, int WarmThreshold) : IRequest;

public sealed class ModifyTemperatureRangeCommandHandler : IRequestHandler<ModifyTemperatureRangeCommand, Unit>
{
    private readonly ITemperatureService _tempService;

    public ModifyTemperatureRangeCommandHandler(ITemperatureService tempService)
    {
        _tempService = tempService;
    }

    public async Task<Unit> Handle(ModifyTemperatureRangeCommand request, CancellationToken cancellationToken)
    {
        _tempService.UpdateTemperatureRangeAsync(request);
        return Unit.Value;
    }
}

public sealed class ModifyTemperatureRangeCommandValidator : AbstractValidator<ModifyTemperatureRangeCommand>
{
    public ModifyTemperatureRangeCommandValidator()
    {
        RuleFor(i => new { i.ColdThreshold, i.WarmThreshold })
            .Must(o => o.WarmThreshold > o.ColdThreshold);
    }
}