using BicycleRent.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BicycleRent.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> modelBuilder)
        {

            modelBuilder
                .HasKey(a => a.AddressID);

            //modelBuilder
            //    .Property(a => a.AddressID)
            //    .UseIdentityColumn(1, 1);



            modelBuilder
                .HasMany(a => a.Customer_Addresses)
                .WithOne(ca => ca.Address)
                .HasForeignKey(a => a.AddressID);





        }
    }
}
