namespace OrbitEye.Domain.Entities;

public class Alerta
{
    public int Id { get; set; }

    public string Mensagem { get; set; } = string.Empty;

    public string Nivel { get; set; } = string.Empty;

    public DateTime DataEmissao { get; set; }

    public int RegiaoId { get; set; }

    public Regiao? Regiao { get; set; }
}