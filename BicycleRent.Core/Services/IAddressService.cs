using BicycleRent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRent.Core.Services
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAllAddresses();

        Task<Address> CreateAddress(Address newAddress);
        Task UpdateAddress(Address addressToBeUpdated, Address address);
        Task DeleteAddress(Address address);
        Task<Address> GetAddressById(double addressID);
    }
}
