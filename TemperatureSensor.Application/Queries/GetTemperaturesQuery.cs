namespace TemperatureSensor.Application.Queries;

public sealed record GetTemperaturesQuery() : IRequest<List<TemperatureDTO>>;

public sealed class GetTemperaturesQueryHandler : IRequestHandler<GetTemperaturesQuery, List<TemperatureDTO>>
{
    private readonly ITemperatureService _tempService;

    public GetTemperaturesQueryHandler(ITemperatureService tempService)
    {
        _tempService = tempService;
    }

    public async Task<List<TemperatureDTO>> Handle(GetTemperaturesQuery request, CancellationToken cancellationToken)
    {
        return _tempService.GetCurrentTemperatures();
    }
}