using CarNest.Services.Domain.Model.Aggregates;

namespace CarNest.Caregivers.Domain.Model.Aggregates;

public class Caregiver
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Document { get; set; }
    public string Password { get; set; }
    public string ProfileImg { get; set; }
    public string Address { get; set; }
    public string District { get; set; }
    
    // Relación con Services
    public List<Service> Services { get; set; } = new(); // Relación con los servicios asociados
}