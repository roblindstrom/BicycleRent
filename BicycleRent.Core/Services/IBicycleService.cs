using BicycleRent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRent.Core.Services
{
    public interface IBicycleService
    {
        Task<IEnumerable<Bicycle>> GetAllBicyclesAsync();
        Task<Bicycle> GetBicycleByIdAsync(double id);


        Task<Bicycle> CreateBicycleAsync(Bicycle newBicycle);
        Task UpdateBicycle(Bicycle bicycleToBeUpdated, Bicycle Bicycle);
        Task DeleteBicycleAsync(Bicycle bicycle);


    }
}
