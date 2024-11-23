using CarNest.Caregivers.Domain.Model.Aggregates;
using CarNest.Caregivers.Interfaces.REST.Resources;
using CarNest.Tutors.Domain.Model.Aggregates;
using CarNest.Tutors.Interfaces.REST.Resources;

namespace CarNest.Tutors.Interfaces.REST.Transform;


public static class TutorResourceFromEntityAssembler
{
    public static TutorResource ToResource(Tutor tutor)
    {
        return new TutorResource
        {
            Id = tutor.Id,
            FullName = tutor.FullName,
            Email = tutor.Email,
            Phone = tutor.Phone,
            Address = tutor.Address,
            District = tutor.District
        };
    }
}
