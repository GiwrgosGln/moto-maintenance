using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoMaintenance.Api.Domain.Entities;

namespace MotoMaintenance.Api.Database.Configurations;

public sealed class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(m => m.Manufacturer)
            .WithMany()
            .HasForeignKey(m => m.ManufacturerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(m => new { m.ManufacturerId, m.Name }).IsUnique();
    }
}