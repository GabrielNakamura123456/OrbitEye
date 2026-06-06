using OrbitEye.Domain.Entities;

namespace OrbitEye.Application.Interfaces;

public interface IUsuarioRepository
{
    Task<List<Usuario>> ListarAsync();
    Task<Usuario?> BuscarPorIdAsync(int id);
    Task<Usuario> CriarAsync(Usuario usuario);
    Task<Usuario?> AtualizarAsync(int id, Usuario usuario);
    Task<bool> DeletarAsync(int id);
}