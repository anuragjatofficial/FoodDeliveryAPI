using FoodDeliveryAPI.DataAcces.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.DataAcces.Data
{
    public class FoodDeliveryAPIContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<DeliveryPerson> DeliveryPersons { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Admin> Admins { get; set; }
        host:
db.meerjawkcnimfpofsucv.supabase.co

port:
5432

database:
postgres

user:
postgres



        public FoodDeliveryAPIContext(DbContextOptions<FoodDeliveryAPIContext> options)
            :base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
        

    }

}
