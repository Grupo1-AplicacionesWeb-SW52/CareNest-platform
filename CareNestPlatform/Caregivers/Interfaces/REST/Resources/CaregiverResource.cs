namespace CarNest.Caregivers.Interfaces.REST.Resources;

public class CaregiverResource
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string District { get; set; } = null!;
}