using WebApplication3.Caregivers.Domain.Model.Aggregates;
using WebApplication3.Caregivers.Interfaces.REST.Resources;
using WebApplication3.Tutors.Domain.Model.Aggregates;
using WebApplication3.Tutors.Interfaces.REST.Resources;

namespace WebApplication3.Tutors.Interfaces.REST.Transform;


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
