using CarNest.Services.Domain.Model.Aggregates;
using CarNest.Services.Interfaces.REST.Resources;

namespace CarNest.Services.Interfaces.REST.Transform;

public static class CreateWorkaroundCommandFromResourceAssembler
{
    public static List<Workaround> ToEntities(CreateWorkaroundResource resource)
    {
        return resource.Locations.Select(location => new Workaround
        {
            ServiceId = resource.ServiceId,
            Location = location
        }).ToList();
    }
}