using CarNest.Services.Domain.Model.Aggregates;
using CarNest.Services.Interfaces.REST.Resources;

namespace CarNest.Services.Interfaces.REST.Transform;

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