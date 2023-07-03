using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoPizza.Data
{
    /*
     * Each DbSet<> maps to a table that will be created in the database.
     */
    public class ContosoPizzaContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null!; 
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=localhost;database=ContosoPizza;trusted_connection=true;TrustServerCertificate=true");
        }
    }
}
