using OrbitEye.Domain.Entities;

namespace OrbitEye.Tests.Domain;

public class RegiaoTests
{
    [Fact]
    public void DeveCriarRegiaoComDadosValidos()
    {
        // Arrange
        var regiao = new Regiao
        {
            Id = 1,
            Nome = "São Paulo",
            Estado = "SP",
            Latitude = -23.5505,
            Longitude = -46.6333,
            NivelRisco = "Médio"
        };

        // Act
        var nome = regiao.Nome;

        // Assert
        Assert.Equal("São Paulo", nome);
        Assert.Equal("SP", regiao.Estado);
        Assert.Equal("Médio", regiao.NivelRisco);
    }
}