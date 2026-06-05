namespace OrbitEye.Domain.Entities;

public class PrevisaoIA
{
    public int Id { get; set; }

    public double ProbabilidadeRisco { get; set; }

    public string NivelPrevisto { get; set; } = string.Empty;

    public DateTime DataAnalise { get; set; }

    public int RegiaoId { get; set; }

    public Regiao Regiao { get; set; } = null!;
}