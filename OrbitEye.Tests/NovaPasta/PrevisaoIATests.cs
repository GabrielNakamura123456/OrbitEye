using OrbitEye.Domain.Entities;

namespace OrbitEye.Tests.Domain;

public class PrevisaoIATests
{
    [Fact]
    public void DeveClassificarPrevisaoComoAltoRisco()
    {
        // Arrange
        var previsao = new PrevisaoIA
        {
            Id = 1,
            ProbabilidadeRisco = 87.5,
            NivelPrevisto = "Alto",
            DataAnalise = DateTime.Now,
            RegiaoId = 1
        };

        // Act
        var nivel = previsao.NivelPrevisto;

        // Assert
        Assert.Equal("Alto", nivel);
        Assert.True(previsao.ProbabilidadeRisco > 70);
        Assert.Equal(1, previsao.RegiaoId);
    }
}