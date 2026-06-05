using OrbitEye.Domain.Entities;

namespace OrbitEye.Application.Interfaces;

public interface IRegiaoRepository
{
    Task<List<Regiao>> ListarAsync();
    Task<Regiao?> BuscarPorIdAsync(int id);
    Task<Regiao> CriarAsync(Regiao regiao);
    Task<Regiao?> AtualizarAsync(int id, Regiao regiao);
    Task<bool> DeletarAsync(int id);
}