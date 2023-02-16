﻿// <auto-generated />
using System;
using EmpTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmpTracker.Migrations
{
    [DbContext(typeof(EmpTrackerContext))]
    partial class EmpTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmpTracker.Models.Engineer", b =>
                {
                    b.Property<Guid>("EngineerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("WorkingLocationWorkLocationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EngineerId");

                    b.HasIndex("WorkingLocationWorkLocationId");

                    b.ToTable("Engineer");
                });

            modelBuilder.Entity("EmpTracker.Models.WorkLocation", b =>
                {
                    b.Property<Guid>("WorkLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkLocationId");

                    b.ToTable("WorkLocation");
                });

            modelBuilder.Entity("EmpTracker.Models.Engineer", b =>
                {
                    b.HasOne("EmpTracker.Models.WorkLocation", "WorkingLocation")
                        .WithMany("Engineers")
                        .HasForeignKey("WorkingLocationWorkLocationId");

                    b.Navigation("WorkingLocation");
                });

            modelBuilder.Entity("EmpTracker.Models.WorkLocation", b =>
                {
                    b.Navigation("Engineers");
                });
#pragma warning restore 612, 618
        }
    }
}