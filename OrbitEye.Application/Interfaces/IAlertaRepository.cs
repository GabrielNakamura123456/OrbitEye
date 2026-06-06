using OrbitEye.Domain.Entities;

namespace OrbitEye.Application.Interfaces;

public interface IAlertaRepository
{
    Task<List<Alerta>> ListarAsync();
    Task<Alerta?> BuscarPorIdAsync(int id);
    Task<Alerta> CriarAsync(Alerta alerta);
    Task<Alerta?> AtualizarAsync(int id, Alerta alerta);
    Task<bool> DeletarAsync(int id);
}