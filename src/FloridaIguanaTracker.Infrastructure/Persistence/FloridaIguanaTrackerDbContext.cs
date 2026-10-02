using FloridaIguanaTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FloridaIguanaTracker.Infrastructure.Persistence
{
    public class FloridaIguanaTrackerDbContext : DbContext
    {
        public FloridaIguanaTrackerDbContext(
            DbContextOptions<FloridaIguanaTrackerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sighting> Sightings => Set<Sighting>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(FloridaIguanaTrackerDbContext).Assembly);
        }
    }
}
