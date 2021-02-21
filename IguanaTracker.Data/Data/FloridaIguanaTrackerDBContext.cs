using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=JAMESPC;Initial Catalog=FloridaIguanaTrackerDB;Integrated Security=True");
//            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Iguana>(entity =>
        //    {
        //        entity.Property(e => e.Id).HasColumnName("ID");

        //        entity.Property(e => e.City)
        //            .IsRequired()
        //            .HasMaxLength(50)
        //            .IsUnicode(false);

        //        entity.Property(e => e.DatePosted).HasColumnType("datetime");

        //        entity.Property(e => e.Description).IsUnicode(false);

        //        entity.Property(e => e.State)
        //            .IsRequired()
        //            .HasMaxLength(50)
        //            .IsUnicode(false);
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
