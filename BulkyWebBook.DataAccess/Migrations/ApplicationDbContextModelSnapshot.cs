﻿// <auto-generated />
using BulkyWebBook.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BulkyWebBook.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BulkyWebBook.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("DisplaeyCategoryOrder")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Action",
                            DisplaeyCategoryOrder = 1
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Sc-fi",
                            DisplaeyCategoryOrder = 2
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Drama",
                            DisplaeyCategoryOrder = 13
                        });
                });

            modelBuilder.Entity("BulkyWebBook.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ListPrise")
                        .HasColumnType("int");

                    b.Property<int>("Prise100")
                        .HasColumnType("int");

                    b.Property<int>("Prise50")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "The Don",
                            CategoryId = 1,
                            Description = "At main man",
                            ImageUrl = "",
                            ListPrise = 10000,
                            Prise100 = 5000,
                            Prise50 = 8700,
                            Title = "Powerful"
                        },
                        new
                        {
                            Id = 3,
                            Author = "The Don",
                            CategoryId = 2,
                            Description = "At main man",
                            ImageUrl = "",
                            ListPrise = 10000,
                            Prise100 = 5000,
                            Prise50 = 8700,
                            Title = "Powerful"
                        });
                });

            modelBuilder.Entity("BulkyWebBook.Models.Product", b =>
                {
                    b.HasOne("BulkyWebBook.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
