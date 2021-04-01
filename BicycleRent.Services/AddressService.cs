using BicycleRent.Core;
using BicycleRent.Core.Models;
using BicycleRent.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRent.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Address> CreateAddress(Address newAddress)
        {
            await _unitOfWork.Addresses
                .AddAsync(newAddress);
            await _unitOfWork.CommitAsync();

            return newAddress;
        }

        public async Task DeleteAddress(Address address)
        {
            _unitOfWork.Addresses.Remove(address);

            await _unitOfWork.CommitAsync();
        }

        public async Task<Address> GetAddressById(double addressID)
        {
            return await _unitOfWork.Addresses
                .GetAddressByIdAsync(addressID);
        }

        public async Task<IEnumerable<Address>> GetAllAddresses()
        {
            return await _unitOfWork.Addresses.GetAllAsync();
        }



        public async Task UpdateAddress(Address addressToBeUpdated, Address address)
        {

            addressToBeUpdated.AddressName = address.AddressName;
            addressToBeUpdated.AddressID = address.AddressID;

            await _unitOfWork.CommitAsync();
        }
    }
}
