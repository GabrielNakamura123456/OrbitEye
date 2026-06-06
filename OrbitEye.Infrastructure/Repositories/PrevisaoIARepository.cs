using Microsoft.EntityFrameworkCore;
using OrbitEye.Application.Interfaces;
using OrbitEye.Domain.Entities;
using OrbitEye.Infrastructure.Data;

namespace OrbitEye.Infrastructure.Repositories;

public class PrevisaoIARepository : IPrevisaoIARepository
{
    private readonly OrbitEyeDbContext _context;

    public PrevisaoIARepository(OrbitEyeDbContext context)
    {
        _context = context;
    }

    public async Task<List<PrevisaoIA>> ListarAsync()
    {
        return await _context.PrevisoesIA.ToListAsync();
    }

    public async Task<PrevisaoIA?> BuscarPorIdAsync(int id)
    {
        return await _context.PrevisoesIA.FindAsync(id);
    }

    public async Task<PrevisaoIA> CriarAsync(PrevisaoIA previsao)
    {
        _context.PrevisoesIA.Add(previsao);
        await _context.SaveChangesAsync();
        return previsao;
    }

    public async Task<PrevisaoIA?> AtualizarAsync(int id, PrevisaoIA previsao)
    {
        var existente = await _context.PrevisoesIA.FindAsync(id);

        if (existente == null)
            return null;

        existente.ProbabilidadeRisco = previsao.ProbabilidadeRisco;
        existente.NivelPrevisto = previsao.NivelPrevisto;
        existente.DataAnalise = previsao.DataAnalise;
        existente.RegiaoId = previsao.RegiaoId;

        await _context.SaveChangesAsync();

        return existente;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var previsao = await _context.PrevisoesIA.FindAsync(id);

        if (previsao == null)
            return false;

        _context.PrevisoesIA.Remove(previsao);
        await _context.SaveChangesAsync();

        return true;
    }
}