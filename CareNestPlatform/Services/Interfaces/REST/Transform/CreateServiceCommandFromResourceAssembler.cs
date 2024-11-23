using CarNest.Services.Domain.Model.Aggregates;
using CarNest.Services.Interfaces.REST.Resources;

namespace CarNest.Services.Interfaces.REST.Transform;

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