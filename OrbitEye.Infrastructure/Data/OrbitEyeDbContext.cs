using Microsoft.EntityFrameworkCore;
using OrbitEye.Domain.Entities;

namespace OrbitEye.Infrastructure.Data;

public class OrbitEyeDbContext : DbContext
{
    public OrbitEyeDbContext(DbContextOptions<OrbitEyeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<Regiao> Regioes { get; set; }

    public DbSet<Alerta> Alertas { get; set; }

    public DbSet<EventoClimatico> EventosClimaticos { get; set; }

    public DbSet<PrevisaoIA> PrevisoesIA { get; set; }
}