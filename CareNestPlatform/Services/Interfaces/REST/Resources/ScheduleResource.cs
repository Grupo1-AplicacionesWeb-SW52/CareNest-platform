namespace CarNest.Services.Interfaces.REST.Resources;

public class ScheduleResource
{
    public int Id { get; set; }
    public string Day { get; set; } = string.Empty;
    public WorkHoursResource WorkHours { get; set; } = new();
    public int ServiceId { get; set; }
}