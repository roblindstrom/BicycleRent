using BicycleRent.Core.Models;
using BicycleRent.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRent.Data.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(BicycleRentDbContext context)
            : base(context)
        { }

        public async Task<Booking> GetBookingByIdAsync(double id)
        {
            return await BicycleRentDbContext.Bookings
                .FindAsync(id);
        }

        public async Task<IEnumerable<Booking>> GetAllbookingsAsync()
        {
            return await BicycleRentDbContext.Bookings
                .ToListAsync();
        }

        private BicycleRentDbContext BicycleRentDbContext
        {
            get { return Context as BicycleRentDbContext; }
        }
    }
}
