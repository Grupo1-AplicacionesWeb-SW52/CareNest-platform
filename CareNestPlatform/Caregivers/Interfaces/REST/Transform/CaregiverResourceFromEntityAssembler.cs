using WebApplication3.Caregivers.Domain.Model.Aggregates;
using WebApplication3.Caregivers.Interfaces.REST.Resources;

namespace WebApplication3.Caregivers.Interfaces.REST.Transform;


public static class CaregiverResourceFromEntityAssembler
{
    public static CaregiverResource ToResource(Caregiver caregiver)
    {
        return new CaregiverResource
        {
            Id = caregiver.Id,
            FullName = caregiver.FullName,
            Email = caregiver.Email,
            Phone = caregiver.Phone,
            Address = caregiver.Address,
            District = caregiver.District
        };
    }
}
