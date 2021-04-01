

using BicycleRent.Core.Models;
using BicycleRent.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRent.Data.Repositories
{
    public class CustomerInformationRepository : Repository<CustomerInformation>, ICustomerInformationRepository
    {
        public CustomerInformationRepository(BicycleRentDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<CustomerInformation>> GetAllCustomerInformationsWithBookingAsync()
        {
            return await BicycleRentDbContext.CustomerInformations
                .Include(ci => ci.Bookings)
                .ToListAsync();
        }



        public async Task<ListOfModels> GetAllCustomersAndAdressesWithList()
        {
            var customerAddressList = new ListOfModels
            {
                ListOfAddresses = await BicycleRentDbContext
            .Addresses
            .ToListAsync(),
                ListOfCustomerInformations = await BicycleRentDbContext
                .CustomerInformations
                .ToListAsync()
            };


            return customerAddressList;
        }

        public async Task<CustomerInformation> GetCustomerInformationbyPersonalID(double PersonalID)
        {
            return await BicycleRentDbContext.CustomerInformations
                .FirstOrDefaultAsync(e => e.PersonalID == PersonalID);
        }



        private BicycleRentDbContext BicycleRentDbContext
        {
            get { return Context as BicycleRentDbContext; }
        }
    }
}
