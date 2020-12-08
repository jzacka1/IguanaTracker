﻿// <auto-generated />
using System;
using IguanaTracker.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IguanaTracker.Data.Migrations
{
    [DbContext(typeof(FloridaIguanaTrackerDBContext))]
    partial class FloridaIguanaTrackerDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("IguanaTracker.Data.Data.Iguana", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("IpAddress")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("IP_Address");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(11,9)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(11,9)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Iguanas");
                });
#pragma warning restore 612, 618
        }
    }
}
