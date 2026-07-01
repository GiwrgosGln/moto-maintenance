using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoMaintenance.Api.Domain.Entities;

namespace MotoMaintenance.Api.Database.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Auth0Id)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(u => u.IsProfilePublic)
            .IsRequired();

        builder.HasIndex(u => u.Auth0Id)
            .IsUnique();

        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}
