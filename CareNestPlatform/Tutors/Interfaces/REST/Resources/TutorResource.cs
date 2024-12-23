namespace WebApplication3.Tutors.Interfaces.REST.Resources;

public class TutorResource
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string District { get; set; } = null!;
}