﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CheckingDocxDbContext))]
    partial class CheckingDocxDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Requirement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("GetSearch")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Requirements");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            GetSearch = "FontFamily",
                            Name = "Шрифт"
                        },
                        new
                        {
                            Id = 2L,
                            GetSearch = "Size",
                            Name = "Розмір шрифту"
                        },
                        new
                        {
                            Id = 3L,
                            GetSearch = "Size",
                            Name = "Вирівняти"
                        });
                });

            modelBuilder.Entity("Core.Entities.Value", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RequirementId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RequirementId");

                    b.ToTable("Values");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Times New Roman",
                            RequirementId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Arial",
                            RequirementId = 1L
                        },
                        new
                        {
                            Id = 3L,
                            Name = "MS Sans Serif",
                            RequirementId = 1L
                        },
                        new
                        {
                            Id = 4L,
                            Name = "10",
                            RequirementId = 2L
                        },
                        new
                        {
                            Id = 5L,
                            Name = "11",
                            RequirementId = 2L
                        },
                        new
                        {
                            Id = 6L,
                            Name = "12",
                            RequirementId = 2L
                        });
                });

            modelBuilder.Entity("Core.Entities.Value", b =>
                {
                    b.HasOne("Core.Entities.Requirement", "Requirement")
                        .WithMany("Values")
                        .HasForeignKey("RequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requirement");
                });

            modelBuilder.Entity("Core.Entities.Requirement", b =>
                {
                    b.Navigation("Values");
                });
#pragma warning restore 612, 618
        }
    }
}
