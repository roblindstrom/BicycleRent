using BicycleRent.Core.Models;
using BicycleRent.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BicycleRent.Data.Repositories
{
    public class BicycleRepository : Repository<Bicycle>, IBicycleRepository
    {
        public BicycleRepository(BicycleRentDbContext context)
            : base(context)
        { }


        // Kommenterar ut denna för jag vill spara kodlösningen och kolla på även om jag inte använder koden

        //public async Task<IEnumerable<Bicycle>> GetFreeBicycles(DateTime startingdate, DateTime endingdate)
        //{
        //    var bicycles = await BicycleRentDbContext
        //        .Bicycles.Where(x => x.Bookings
        //        .Any(y => y.BookingStartDate >= startingdate 
        //        && 
        //        y.BookingEndDate <= endingdate))
        //        .ToListAsync();

        //    return  bicycles;
        //}

        public async Task<Bicycle> GetBicycleByIdAsync(double id)
        {
            return await BicycleRentDbContext.Bicycles
                .SingleOrDefaultAsync(bc => bc.BicycleId == id);
        }



        private BicycleRentDbContext BicycleRentDbContext
        {
            get { return Context as BicycleRentDbContext; }
        }
    }
}
