using BicycleRent.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BicycleRent.Data.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> modelBuilder)
        {
            modelBuilder
                .HasKey(bk => new { bk.BookedBicycle, bk.CustomerWithBooking });


            modelBuilder
                .HasOne(bk => bk.CustomerInformation)
                .WithMany(ci => ci.Bookings)
                .HasForeignKey(bk => bk.CustomerWithBooking);



            modelBuilder
                .HasOne(bk => bk.Bicycle)
                .WithMany(bc => bc.Bookings)
                .HasForeignKey(b => b.BookedBicycle);


        }
    }
}
