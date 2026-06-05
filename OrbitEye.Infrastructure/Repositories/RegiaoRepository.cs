using Microsoft.EntityFrameworkCore;
using OrbitEye.Application.Interfaces;
using OrbitEye.Domain.Entities;
using OrbitEye.Infrastructure.Data;

namespace OrbitEye.Infrastructure.Repositories;

public class RegiaoRepository : IRegiaoRepository
{
    private readonly OrbitEyeDbContext _context;

    public RegiaoRepository(OrbitEyeDbContext context)
    {
        _context = context;
    }

    public async Task<List<Regiao>> ListarAsync()
    {
        return await _context.Regioes.ToListAsync();
    }

    public async Task<Regiao?> BuscarPorIdAsync(int id)
    {
        return await _context.Regioes.FindAsync(id);
    }

    public async Task<Regiao> CriarAsync(Regiao regiao)
    {
        _context.Regioes.Add(regiao);
        await _context.SaveChangesAsync();
        return regiao;
    }

    public async Task<Regiao?> AtualizarAsync(int id, Regiao regiao)
    {
        var regiaoExistente = await _context.Regioes.FindAsync(id);

        if (regiaoExistente == null)
            return null;

        regiaoExistente.Nome = regiao.Nome;
        regiaoExistente.Estado = regiao.Estado;
        regiaoExistente.Latitude = regiao.Latitude;
        regiaoExistente.Longitude = regiao.Longitude;
        regiaoExistente.NivelRisco = regiao.NivelRisco;

        await _context.SaveChangesAsync();

        return regiaoExistente;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var regiao = await _context.Regioes.FindAsync(id);

        if (regiao == null)
            return false;

        _context.Regioes.Remove(regiao);
        await _context.SaveChangesAsync();

        return true;
    }
}