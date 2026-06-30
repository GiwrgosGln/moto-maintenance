using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoMaintenance.Api.Domain.Entities;

namespace MotoMaintenance.Api.Database.Configurations;

public sealed class MotorcycleConfiguration : IEntityTypeConfiguration<Motorcycle>
{
    public void Configure(EntityTypeBuilder<Motorcycle> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.ModelYear)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(m => m.Nickname)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(m => m.Color)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(m => m.Manufacturer)
            .WithMany()
            .HasForeignKey(m => m.ManufacturerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.Model)
            .WithMany()
            .HasForeignKey(m => m.ModelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(m => m.UserId);
    }
}
