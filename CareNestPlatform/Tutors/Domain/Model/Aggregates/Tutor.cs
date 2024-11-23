using CarNest.Services.Domain.Model.Aggregates;

namespace CarNest.Tutors.Domain.Model.Aggregates;

public class Tutor
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
    
}