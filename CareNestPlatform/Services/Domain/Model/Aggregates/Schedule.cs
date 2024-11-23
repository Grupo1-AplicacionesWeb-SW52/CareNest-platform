namespace CarNest.Services.Domain.Model.Aggregates;

public class Schedule
{
    public int Id { get; set; }
    public string Day { get; set; } = string.Empty; // Ejemplo: "mon"
    public WorkHours WorkHours { get; set; } = new(); // Relación con WorkHours
    public int? ServiceId { get; set; } // Opcional
    public Service? Service { get; set; } // Relación opcional con Service
}