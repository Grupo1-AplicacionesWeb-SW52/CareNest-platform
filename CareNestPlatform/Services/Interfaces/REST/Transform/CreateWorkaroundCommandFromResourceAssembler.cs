using WebApplication3.Services.Domain.Model.Aggregates;
using WebApplication3.Services.Interfaces.REST.Resources;

namespace WebApplication3.Services.Interfaces.REST.Transform;

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