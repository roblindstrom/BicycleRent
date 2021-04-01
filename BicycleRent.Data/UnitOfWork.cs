using BicycleRent.Core;
using BicycleRent.Core.Repositories;
using BicycleRent.Data.Repositories;
using System.Threading.Tasks;

namespace BicycleRent.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BicycleRentDbContext _bicycleRentDbContext;
        private BicycleRepository _bicycleRepository;
        private BookingRepository _bookingRepository;
        private CustomerInformationRepository _customerInformationRepository;
        private CustomerInformationAddressRepository _customer_AddressRepository;
        private AddressRepository _addressRepository;

        public UnitOfWork(BicycleRentDbContext bicycleRentDbContext)
        {
            this._bicycleRentDbContext = bicycleRentDbContext;
        }

        public IBicycleRepository Bicycles => _bicycleRepository ??= new BicycleRepository(_bicycleRentDbContext);

        public IBookingRepository Bookings => _bookingRepository ??= new BookingRepository(_bicycleRentDbContext);

        public ICustomerInformationRepository CustomerInformations => _customerInformationRepository ??= new CustomerInformationRepository(_bicycleRentDbContext);

        public ICustomer_AddressRepository Customer_Addresses => _customer_AddressRepository ??= new CustomerInformationAddressRepository(_bicycleRentDbContext);

        public IAddressRepository Addresses => _addressRepository ??= new AddressRepository(_bicycleRentDbContext);



        public async Task<double> CommitAsync()
        {
            return await _bicycleRentDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _bicycleRentDbContext.Dispose();
        }
    }
}
