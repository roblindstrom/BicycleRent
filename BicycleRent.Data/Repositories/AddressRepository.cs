using BicycleRent.Core.Models;
using BicycleRent.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRent.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(BicycleRentDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Address>> GetAllAddresses()
        {
            return await BicycleRentDbContext.Addresses
                .ToListAsync();
        }



        public async Task<Address> GetAddressByIdAsync(double AddressID)
        {
            return await BicycleRentDbContext.Addresses
                .SingleOrDefaultAsync(bc => bc.AddressID == AddressID);
        }

        private BicycleRentDbContext BicycleRentDbContext
        {
            get { return Context as BicycleRentDbContext; }
        }
    }
}
