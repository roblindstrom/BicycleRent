using BicycleRent.Core.Models;
using System.Threading.Tasks;

namespace BicycleRent.Core.Repositories
{
    public interface IBicycleRepository : IRepository<Bicycle>
    {


        Task<Bicycle> GetBicycleByIdAsync(double id);

    }
}
