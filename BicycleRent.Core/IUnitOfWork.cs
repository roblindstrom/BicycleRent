using BicycleRent.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace BicycleRent.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBicycleRepository Bicycles { get; }

        IBookingRepository Bookings { get; }


        ICustomerInformationRepository CustomerInformations { get; }
        ICustomer_AddressRepository Customer_Addresses { get; }
        IAddressRepository Addresses { get; }



        Task<double> CommitAsync();
    }
}
