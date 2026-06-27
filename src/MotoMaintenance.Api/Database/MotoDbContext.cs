using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Domain.Entities;

namespace MotoMaintenance.Api.Database;

public sealed class MotoDbContext(DbContextOptions<MotoDbContext> options) : DbContext(options)
{
    
}