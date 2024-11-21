using WebApplication3.Services.Domain.Model.Aggregates;
using WebApplication3.Services.Interfaces.REST.Resources;

namespace WebApplication3.Services.Interfaces.REST.Transform;

public static class CreateServiceCommandFromResourceAssembler
{
    public static Service ToEntity(CreateServiceResource resource)
    {
        return new Service
        {
            CaregiverId = resource.CaregiverId,
            Description = resource.Description,
            FarePerHour = resource.FarePerHour,
            Rating = resource.Rating,
            Workarounds = resource.Workaround.Select(w => new Workaround { Location = w }).ToList()
        };
    }

}