using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Domain.Entities;

namespace MotoMaintenance.Api.Database;

public sealed class MotoDbContext(DbContextOptions<MotoDbContext> options) : DbContext(options)
{
    public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
    public DbSet<Model> Models => Set<Model>();
    public DbSet<Motorcycle> Motorcycles => Set<Motorcycle>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MotoDbContext).Assembly);
    }
}