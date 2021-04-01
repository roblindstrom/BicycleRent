using BicycleRent.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BicycleRent.Data.Configurations
{
    public class CustomerInformationConfiguration : IEntityTypeConfiguration<CustomerInformation>
    {
        public void Configure(EntityTypeBuilder<CustomerInformation> modelBuilder)
        {

            modelBuilder
                .HasKey(ci => ci.Customer_AdressID);

            modelBuilder
                .HasMany(ci => ci.Bookings)
                .WithOne(bk => bk.CustomerInformation);


            modelBuilder
                .HasMany(ci => ci.Customer_Addresses)
                .WithOne(ca => ca.CustomerInformation)
                .HasForeignKey(ci => ci.Customer_AddressID);

            modelBuilder
                .HasMany(bo => bo.Bookings)
                .WithOne(ci => ci.CustomerInformation)
                .HasForeignKey(bo => bo.CustomerWithBooking);


            modelBuilder
                .ToTable("CustomerInformation");

        }
    }
}
