namespace OrbitEye.Domain.Entities;

public class EventoClimatico
{
    public int Id { get; set; }

    public string TipoEvento { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public DateTime DataEvento { get; set; }

    public int RegiaoId { get; set; }

    public Regiao Regiao { get; set; } = null!;
}