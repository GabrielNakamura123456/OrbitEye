using Microsoft.EntityFrameworkCore;
using OrbitEye.Application.Interfaces;
using OrbitEye.Domain.Entities;
using OrbitEye.Infrastructure.Data;

namespace OrbitEye.Infrastructure.Repositories;

public class EventoClimaticoRepository : IEventoClimaticoRepository
{
    private readonly OrbitEyeDbContext _context;

    public EventoClimaticoRepository(OrbitEyeDbContext context)
    {
        _context = context;
    }

    public async Task<List<EventoClimatico>> ListarAsync()
    {
        return await _context.EventosClimaticos.ToListAsync();
    }

    public async Task<EventoClimatico?> BuscarPorIdAsync(int id)
    {
        return await _context.EventosClimaticos.FindAsync(id);
    }

    public async Task<EventoClimatico> CriarAsync(EventoClimatico evento)
    {
        _context.EventosClimaticos.Add(evento);
        await _context.SaveChangesAsync();
        return evento;
    }

    public async Task<EventoClimatico?> AtualizarAsync(int id, EventoClimatico evento)
    {
        var existente = await _context.EventosClimaticos.FindAsync(id);

        if (existente == null)
            return null;

        existente.TipoEvento = evento.TipoEvento;
        existente.Descricao = evento.Descricao;
        existente.DataEvento = evento.DataEvento;
        existente.RegiaoId = evento.RegiaoId;

        await _context.SaveChangesAsync();

        return existente;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var evento = await _context.EventosClimaticos.FindAsync(id);

        if (evento == null)
            return false;

        _context.EventosClimaticos.Remove(evento);
        await _context.SaveChangesAsync();

        return true;
    }
}