using BulkyWebBook.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace BulkyWebBook.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action", DisplaeyCategoryOrder = 1 },
                new Category { CategoryId = 2, CategoryName = "Sc-fi", DisplaeyCategoryOrder = 2 },
                new Category { CategoryId = 3, CategoryName = "Drama", DisplaeyCategoryOrder = 13 }

                );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Title = "Fortune of Time",
                Author = "Mahesh Chavan",
                Description = "Present very Good",
                ListPrise = 200,
                Prise = 175,
                Prise50 = 150,
                Prise100 = 100
            },
            new Product
            {
                Id = 2,
                Title = "Fortune of Time",
                Author = "Mahesh Chavan",
                Description = "Present very Good",
                ListPrise = 200,
                Prise = 175,
                Prise50 = 150,
                Prise100 = 100
            }
            );
        }
    }
}
