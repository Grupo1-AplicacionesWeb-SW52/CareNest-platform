namespace WebApplication3.Caregivers.Interfaces.REST.Resources;

public class CreateCaregiverResource
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Document { get; set; }
    public string Password { get; set; }
    public string ProfileImg { get; set; }
    public string Address { get; set; }
    public string District { get; set; }
}