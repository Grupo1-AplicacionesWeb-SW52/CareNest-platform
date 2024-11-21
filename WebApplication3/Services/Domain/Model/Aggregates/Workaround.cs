namespace WebApplication3.Services.Domain.Model.Aggregates;

public class Workaround
{
    public int Id { get; set; }
    public string Location { get; set; } = string.Empty; // Ejemplo: "San Miguel"
    public int ServiceId { get; set; } // FK a Service
    public Service Service { get; set; } = null!; // Relación con Service
}