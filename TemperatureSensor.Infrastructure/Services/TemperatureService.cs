namespace TemperatureSensor.Infrastructure.Services;

public class TemperatureService : ITemperatureService
{
    private readonly TemperatureContext _context;

    // Injecte DBcontext
    public TemperatureService(TemperatureContext context)
    {
        this._context = context;
    }
    // Injecte iun service temperature generator
    // Get temp Génère la temp + va chercher les fourchettes en base + générère un modele
    // Get 15 temps
    public TemperatureDTO GetCurrentTemperature()
    {
        var temp = new Temperature
        {
            TemperatureC = new Random().Next(0, 40),
            Date = DateTime.Now,
        };
        var range = _context.TemperatureRanges;
        if (range == null || !range.Any())
        {
            Helpers.InitializeTemperatures.Init(_context);
        }
        temp.State = Helpers.SetStateHelper.Set(_context, temp);
        _context.Temperatures.Add(temp);
        _context.SaveChanges();

        var dto = new TemperatureDTO
        {
            TemperatureC = temp.TemperatureC,
            State = temp.State,
            Date = temp.Date
        };

        return dto;
    }

    public List<TemperatureDTO> GetCurrentTemperatures()
    {
        var list = _context.Temperatures.OrderByDescending(x => x.Date).Take(15);
        var dtos = new List<TemperatureDTO>(15);
        foreach (var item in list)
        {
            dtos.Add(new TemperatureDTO
            {
                TemperatureC = item.TemperatureC,
                State = item.State,
                Date = item.Date
            });
        }
        return dtos;
    }

    public Unit UpdateTemperatureRangeAsync(ModifyTemperatureRangeCommand request)
    {
        var th = _context.TemperatureRanges.FirstOrDefault(x => x.Label == "Threshold");
        if (th != null)
        {
            _context.Entry(th).State = EntityState.Modified;
            th.LowerLimit = request.ColdThreshold;
            th.UpperLimit = request.WarmThreshold;
        }
        else
        {
            _context.TemperatureRanges.Add(new TemperatureRange
            {
                Label = "Threshold",
                LowerLimit = request.ColdThreshold,
                UpperLimit = request.WarmThreshold
            });
        }
        _context.SaveChanges();
        return Unit.Value;
    }
}