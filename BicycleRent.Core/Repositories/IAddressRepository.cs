using BicycleRent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRent.Core.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<IEnumerable<Address>> GetAllAddresses();

        Task<Address> GetAddressByIdAsync(double id);



    }
}
