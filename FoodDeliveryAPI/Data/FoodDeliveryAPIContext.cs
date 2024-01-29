using FoodDeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.Data
{
    public class FoodDeliveryAPIContext : DbContext
    {
        public FoodDeliveryAPIContext(DbContextOptions<FoodDeliveryAPIContext> options)
            :base(options) 
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<DeliveryPerson> DeliveryPersons { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Restaurant> Restaurants { get; set;}

        public DbSet<Admin> Admins { get; set; }

    }

}
