using CompanyManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess.EFContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seeding employee's table
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 1, Name = "Frederick Hughes", Address = "Accra, Ghana" },
                new Employee() { Id = 2, Name = "John Doe", Address = "New York, USA" },
                new Employee() { Id = 3, Name = "Moses Roberts", Address = "London, UK" }
                );

            //seeding customer's table
            modelBuilder.Entity<Customer>().HasData(
                new Customer() { Id = 1, Name = "Joseph Darling", Location = "Kumasi, Ghana" },
                new Customer() { Id = 2, Name = "Hurbert Rockingston", Location = "Abuja, Nigeria" },
                new Customer() { Id = 3, Name = "Mabel Knight", Location = "Cape Coast, Ghana" }
                );
        }
    }
}
