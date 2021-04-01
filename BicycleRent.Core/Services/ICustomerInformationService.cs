using BicycleRent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRent.Core.Services
{
    public interface ICustomerInformationService
    {
        Task<IEnumerable<CustomerInformation>> GetAllCustomerInformations();
        Task<CustomerInformation> GetCustomerInformationbyPersonalID(double PersonalID);

        Task<CustomerInformation> CreateCustomerInformation(CustomerInformation newCustomerInformation);

        Task UpdateCustomerInformation(CustomerInformation customerInformationToBeUpdate, CustomerInformation customerInformation);

        Task DeleteCustomerInformation(CustomerInformation customerInformation);

        Task<ListOfModels> GetAllCustomersAndAdressesWithLists();
    }
}
