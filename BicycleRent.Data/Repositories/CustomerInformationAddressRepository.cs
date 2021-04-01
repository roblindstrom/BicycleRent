using BicycleRent.Core.Models;
using BicycleRent.Core.Repositories;

namespace BicycleRent.Data.Repositories
{
    public class CustomerInformationAddressRepository : Repository<CustomerInformationAddress>, ICustomer_AddressRepository
    {
        public CustomerInformationAddressRepository(BicycleRentDbContext context)
            : base(context)
        { }

        // Denna är tom då detta är en bridge entitet.
    }
}
