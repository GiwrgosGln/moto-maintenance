using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Domain.Entities;

namespace MotoMaintenance.Api.Database;

public sealed class MotoDbContext(DbContextOptions<MotoDbContext> options) : DbContext(options)
{
    public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MotoDbContext).Assembly);
    }
}