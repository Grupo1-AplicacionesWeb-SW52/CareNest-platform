namespace WebApplication3.Services.Interfaces.REST.Resources;

public class CreateScheduleResource
{
    public string Day { get; set; } = string.Empty;
    public WorkHoursResource WorkHours { get; set; } = new();
    public int ServiceId { get; set; }
}