using BicycleRent.Core;
using BicycleRent.Core.Models;
using BicycleRent.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRent.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Booking> CreateBooking(Booking newBooking)
        {
            await _unitOfWork.Bookings
                .AddAsync(newBooking);
            await _unitOfWork
                .CommitAsync();

            return newBooking;
        }

        public async Task DeleteBooking(Booking booking)
        {
            _unitOfWork.Bookings.Remove(booking);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _unitOfWork.Bookings
                .GetAllAsync();
        }



        public async Task<Booking> GetBookingByIdAsync(double BookingID)
        {
            return await _unitOfWork.Bookings
                .GetByIdAsync(BookingID);
        }

        public async Task UpdateBooking(Booking bookingToBeUpdated, Booking booking)
        {

            bookingToBeUpdated.BookingStartDate = booking.BookingStartDate;
            bookingToBeUpdated.BookingEndDate = booking.BookingEndDate;
            bookingToBeUpdated.CustomerWithBooking = booking.CustomerWithBooking;
            bookingToBeUpdated.BookedBicycle = booking.BookedBicycle;

            await _unitOfWork.CommitAsync();
        }
    }
}