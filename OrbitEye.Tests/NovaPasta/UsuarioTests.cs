using OrbitEye.Domain.Entities;

namespace OrbitEye.Tests.Domain;

public class UsuarioTests
{
    [Fact]
    public void DeveCriarUsuarioComPerfilAdmin()
    {
        // Arrange
        var usuario = new Usuario
        {
            Id = 1,
            Nome = "Gabriel Ogata",
            Email = "gabriel@orbiteye.com",
            Senha = "123456",
            Perfil = "Admin"
        };

        // Act
        var perfil = usuario.Perfil;

        // Assert
        Assert.Equal("Admin", perfil);
        Assert.Equal("gabriel@orbiteye.com", usuario.Email);
        Assert.NotEmpty(usuario.Senha);
    }
}