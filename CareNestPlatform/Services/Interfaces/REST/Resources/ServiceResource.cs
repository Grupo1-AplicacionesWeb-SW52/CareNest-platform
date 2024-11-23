using CarNest.Caregivers.Interfaces.REST.Resources;
using CarNest.Services.Domain.Model.Aggregates;

namespace CarNest.Services.Interfaces.REST.Resources;

public class ServiceResource
{
    public int Id { get; set; }
    public int CaregiverId { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<Schedule> Schedules { get; set; } = new(); // Simplificado para representación básica
    public List<string> Workaround { get; set; } = new();
    public decimal FarePerHour { get; set; }
    public double Rating { get; set; }
    public CaregiverResource Caregiver { get; set; } = new();
}