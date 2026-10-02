using FloridaIguanaTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FloridaIguanaTracker.Infrastructure.Persistence.Configuration
{
    public class SightingConfiguration : IEntityTypeConfiguration<Sighting>
    {
        public void Configure(EntityTypeBuilder<Sighting> builder)
        {
            builder.ToTable("Sightings");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.City)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.State)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(2000);

            builder.Property(x => x.ImageBlobName)
                .HasMaxLength(500);

            builder.HasIndex(x => x.ReportedAt);

            builder.HasIndex(x => new
            {
                x.Latitude,
                x.Longitude
            });
        }
    }
}
