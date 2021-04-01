using BicycleRent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRent.Core.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(double id);
        Task<Booking> CreateBooking(Booking newBooking);
        Task UpdateBooking(Booking bookingToBeUpdated, Booking booking);
        Task DeleteBooking(Booking booking);
    }
}
