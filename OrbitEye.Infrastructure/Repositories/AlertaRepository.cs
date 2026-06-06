using Microsoft.EntityFrameworkCore;
using OrbitEye.Application.Interfaces;
using OrbitEye.Domain.Entities;
using OrbitEye.Infrastructure.Data;

namespace OrbitEye.Infrastructure.Repositories;

public class AlertaRepository : IAlertaRepository
{
    private readonly OrbitEyeDbContext _context;

    public AlertaRepository(OrbitEyeDbContext context)
    {
        _context = context;
    }

    public async Task<List<Alerta>> ListarAsync()
    {
        return await _context.Alertas.ToListAsync();
    }

    public async Task<Alerta?> BuscarPorIdAsync(int id)
    {
        return await _context.Alertas.FindAsync(id);
    }

    public async Task<Alerta> CriarAsync(Alerta alerta)
    {
        _context.Alertas.Add(alerta);
        await _context.SaveChangesAsync();
        return alerta;
    }

    public async Task<Alerta?> AtualizarAsync(int id, Alerta alerta)
    {
        var alertaExistente = await _context.Alertas.FindAsync(id);

        if (alertaExistente == null)
            return null;

        alertaExistente.Mensagem = alerta.Mensagem;
        alertaExistente.Nivel = alerta.Nivel;
        alertaExistente.DataEmissao = alerta.DataEmissao;
        alertaExistente.RegiaoId = alerta.RegiaoId;

        await _context.SaveChangesAsync();

        return alertaExistente;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var alerta = await _context.Alertas.FindAsync(id);

        if (alerta == null)
            return false;

        _context.Alertas.Remove(alerta);
        await _context.SaveChangesAsync();

        return true;
    }
}