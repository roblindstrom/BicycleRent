using BicycleRent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRent.Core.Repositories
{
    public interface ICustomerInformationRepository : IRepository<CustomerInformation>
    {
        Task<IEnumerable<CustomerInformation>> GetAllCustomerInformationsWithBookingAsync();

        Task<ListOfModels> GetAllCustomersAndAdressesWithList();

        Task<CustomerInformation> GetCustomerInformationbyPersonalID(double PersonalID);


    }
}
