using WebApplication3.Services.Domain.Model.Aggregates;
using WebApplication3.Services.Interfaces.REST.Resources;

namespace WebApplication3.Services.Interfaces.REST.Transform;

public static class CreateScheduleCommandFromResourceAssembler
{
    public static Schedule ToEntity(CreateScheduleResource resource)
    {
        return new Schedule
        {
            Day = resource.Day,
            WorkHours = new WorkHours
            {
                StartTime = resource.WorkHours.StartTime,
                EndTime = resource.WorkHours.EndTime
            },
            ServiceId = resource.ServiceId
        };
    }
}