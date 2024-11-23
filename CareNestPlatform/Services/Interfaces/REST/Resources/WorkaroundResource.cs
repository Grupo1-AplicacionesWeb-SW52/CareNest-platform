namespace WebApplication3.Services.Interfaces.REST.Resources;

public class WorkaroundResource
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public string Location { get; set; } = string.Empty;
}