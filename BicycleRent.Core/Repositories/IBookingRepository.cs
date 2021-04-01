using BicycleRent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRent.Core.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetAllbookingsAsync();

        Task<Booking> GetBookingByIdAsync(double id);


    }
}
