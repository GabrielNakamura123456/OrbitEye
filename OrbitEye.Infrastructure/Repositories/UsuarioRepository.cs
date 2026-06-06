using Microsoft.EntityFrameworkCore;
using OrbitEye.Application.Interfaces;
using OrbitEye.Domain.Entities;
using OrbitEye.Infrastructure.Data;

namespace OrbitEye.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly OrbitEyeDbContext _context;

    public UsuarioRepository(OrbitEyeDbContext context)
    {
        _context = context;
    }

    public async Task<List<Usuario>> ListarAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario?> BuscarPorIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario> CriarAsync(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario?> AtualizarAsync(int id, Usuario usuario)
    {
        var usuarioExistente = await _context.Usuarios.FindAsync(id);

        if (usuarioExistente == null)
            return null;

        usuarioExistente.Nome = usuario.Nome;
        usuarioExistente.Email = usuario.Email;
        usuarioExistente.Senha = usuario.Senha;
        usuarioExistente.Perfil = usuario.Perfil;

        await _context.SaveChangesAsync();

        return usuarioExistente;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null)
            return false;

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return true;
    }
}