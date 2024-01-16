﻿// <auto-generated />
using BulkyWebBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BulkyWebBook.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240116083311_seedcategorytable")]
    partial class seedcategorytable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
#pragma warning restore 612, 618
        }
    }
}
