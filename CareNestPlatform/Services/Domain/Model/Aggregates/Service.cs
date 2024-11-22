using WebApplication3.Caregivers.Domain.Model.Aggregates;

namespace WebApplication3.Services.Domain.Model.Aggregates;

public class Service
{
    public int Id { get; set; }
    public int CaregiverId { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<Schedule> Schedules { get; set; } = new(); // Relación con Schedule
    public List<Workaround> Workarounds { get; set; } = new(); // Relación con Workaround
    public decimal FarePerHour { get; set; }
    public double Rating { get; set; }
    public Caregiver Caregiver { get; set; } = null!;
}
