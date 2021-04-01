using BicycleRent.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BicycleRent.Data.Configurations
{
    public class CustomerInformationAddressConfiguration : IEntityTypeConfiguration<CustomerInformationAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerInformationAddress> modelBuilder)
        {

            modelBuilder
                .HasKey(ca => new { ca.AddressID, ca.Customer_AddressID });

            modelBuilder
                .HasOne(ca => ca.Address)
                .WithMany(a => a.Customer_Addresses)
                .HasForeignKey(ca => ca.AddressID);

            modelBuilder
                .HasOne(ca => ca.CustomerInformation)
                .WithMany(ci => ci.Customer_Addresses)
                .HasForeignKey(ca => ca.Customer_AddressID);


        }

    }
}
