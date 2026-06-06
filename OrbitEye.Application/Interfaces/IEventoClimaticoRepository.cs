using OrbitEye.Domain.Entities;

namespace OrbitEye.Application.Interfaces;

public interface IEventoClimaticoRepository
{
    Task<List<EventoClimatico>> ListarAsync();
    Task<EventoClimatico?> BuscarPorIdAsync(int id);
    Task<EventoClimatico> CriarAsync(EventoClimatico evento);
    Task<EventoClimatico?> AtualizarAsync(int id, EventoClimatico evento);
    Task<bool> DeletarAsync(int id);
}