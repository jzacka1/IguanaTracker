using System;
//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IguanaTracker.Data.Data
{
    public partial class FloridaIguanaTrackerDBContext : DbContext
    {
        public FloridaIguanaTrackerDBContext()
        {
        }

        public FloridaIguanaTrackerDBContext(DbContextOptions<FloridaIguanaTrackerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Iguana> Iguanas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
