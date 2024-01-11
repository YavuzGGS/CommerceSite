using Entities.Concrete;
using InternshipProject2.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class InternshipAppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //"Data Source=.;Initial Catalog=DB name;Integrated Security=True;MultipleActiveResultSets=True"
            
            //optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\MSSQLLocalDB;initial catalog=CommerceSite;integrated security=true");
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=.;Initial Catalog=CommerceSite;Integrated Security=True;MultipleActiveResultSets=True");

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
