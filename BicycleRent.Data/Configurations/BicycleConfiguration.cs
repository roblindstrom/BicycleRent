using BicycleRent.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BicycleRent.Data.Configurations
{
    public class BicycleConfiguration : IEntityTypeConfiguration<Bicycle>
    {
        public void Configure(EntityTypeBuilder<Bicycle> modelBuilder)
        {
            modelBuilder
                .HasKey(bc => bc.BicycleId);

            modelBuilder
                .Property(bc => bc.BicycleId)
                .ValueGeneratedOnAdd();


            modelBuilder
                .HasMany(bc => bc.Bookings)
                .WithOne(bo => bo.Bicycle)
                .HasForeignKey(bo => bo.BookedBicycle);

            modelBuilder
                .Property(bc => bc.BicycleSize)
                .HasConversion<string>();

            modelBuilder
                .ToTable("Bicycles");


        }
    }
}
