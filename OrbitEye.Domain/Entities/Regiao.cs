namespace OrbitEye.Domain.Entities;

public class Regiao
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Estado { get; set; } = string.Empty;

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public string NivelRisco { get; set; } = string.Empty;

    public ICollection<Alerta> Alertas { get; set; } = new List<Alerta>();

    public ICollection<EventoClimatico> EventosClimaticos { get; set; } = new List<EventoClimatico>();

    public ICollection<PrevisaoIA> PrevisoesIA { get; set; } = new List<PrevisaoIA>();
}