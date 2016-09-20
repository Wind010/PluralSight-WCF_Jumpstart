using System;
using System.Data.Entity;

namespace Zza.Data
{
    using Entities;

    public class ZzaDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }


        public ZzaDbContext() : base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }



    }
}
