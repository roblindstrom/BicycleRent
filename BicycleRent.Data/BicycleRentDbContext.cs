using BicycleRent.Core.Models;
using BicycleRent.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BicycleRent.Data
{
    public class BicycleRentDbContext : DbContext
    {
        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<CustomerInformation> CustomerInformations { get; set; }
        public DbSet<CustomerInformationAddress> CustomerInformationAddresses { get; set; }
        public DbSet<Address> Addresses { get; set; }




        public BicycleRentDbContext(DbContextOptions<BicycleRentDbContext> options) : base(options)
        {

        }

        public BicycleRentDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new BicycleConfiguration());



            modelBuilder
                .ApplyConfiguration(new BookingConfiguration());




            modelBuilder
                .ApplyConfiguration(new CustomerInformationConfiguration());
            modelBuilder
                .ApplyConfiguration(new CustomerInformationAddressConfiguration());
            modelBuilder
                .ApplyConfiguration(new AddressConfiguration());



        }
    }
}
