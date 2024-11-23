using System.Collections.Generic;
using System.Linq;
using WebApplication3.ServiceDetail.Domain.Model.ValueObjects;

namespace WebApplication3.ServiceDetail.Domain.Services
{
    public class ServiceDetailValidationService
    {
        public bool ValidateScheduleConflict(List<Schedule> existingSchedules, Schedule newSchedule)
        {
            return existingSchedules.Any(schedule =>
                schedule.Day == newSchedule.Day &&
                !(newSchedule.EndHour <= schedule.StartHour || newSchedule.StartHour >= schedule.EndHour));
        }
    }
}
