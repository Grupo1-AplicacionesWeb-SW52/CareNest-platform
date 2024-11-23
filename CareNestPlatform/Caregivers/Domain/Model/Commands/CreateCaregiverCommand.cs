namespace CarNest.Caregivers.Domain.Model.Commands;

public class CreateCaregiverCommand
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