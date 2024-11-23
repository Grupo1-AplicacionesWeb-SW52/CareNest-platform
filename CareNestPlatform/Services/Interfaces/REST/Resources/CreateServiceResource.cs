namespace CarNest.Services.Interfaces.REST.Resources;

public class CreateServiceResource
{
    public int CaregiverId { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<string> Workaround { get; set; } = new(); // Lista de ubicaciones
    public decimal FarePerHour { get; set; }
    public double Rating { get; set; }
}
