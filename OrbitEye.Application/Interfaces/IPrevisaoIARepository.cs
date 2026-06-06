using OrbitEye.Domain.Entities;

namespace OrbitEye.Application.Interfaces;

public interface IPrevisaoIARepository
{
    Task<List<PrevisaoIA>> ListarAsync();
    Task<PrevisaoIA?> BuscarPorIdAsync(int id);
    Task<PrevisaoIA> CriarAsync(PrevisaoIA previsao);
    Task<PrevisaoIA?> AtualizarAsync(int id, PrevisaoIA previsao);
    Task<bool> DeletarAsync(int id);
}