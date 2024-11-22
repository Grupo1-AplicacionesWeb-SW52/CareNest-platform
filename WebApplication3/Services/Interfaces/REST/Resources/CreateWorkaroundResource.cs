namespace WebApplication3.Services.Interfaces.REST.Resources;

public class CreateWorkaroundResource
{
    public int ServiceId { get; set; } // ID del servicio relacionado
    public List<string> Locations { get; set; } = new(); // Lista de ubicaciones
}