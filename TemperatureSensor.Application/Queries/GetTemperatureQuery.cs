namespace TemperatureSensor.Application.Queries;

public sealed record GetTemperatureQuery() : IRequest<TemperatureDTO>;

public sealed class GetTemperatureQueryHandler : IRequestHandler<GetTemperatureQuery, TemperatureDTO>
{
    private readonly ITemperatureService _tempService;

    public GetTemperatureQueryHandler(ITemperatureService tempService)
    {
        _tempService = tempService;
    }

    public async Task<TemperatureDTO> Handle(GetTemperatureQuery request, CancellationToken cancellationToken)
    {
        var model = _tempService.GetCurrentTemperature();

        return model;
    }
}