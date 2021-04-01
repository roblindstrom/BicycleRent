using BicycleRent.Core;
using BicycleRent.Core.Models;
using BicycleRent.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BicycleRent.Services
{
    public class CustomerInformationService : ICustomerInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerInformationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<CustomerInformation> CreateCustomerInformation(CustomerInformation newCustomerInformation)
        {
            await _unitOfWork.CustomerInformations
                .AddAsync(newCustomerInformation);
            await _unitOfWork.CommitAsync();

            return newCustomerInformation;
        }

        public async Task DeleteCustomerInformation(CustomerInformation customerInformation)
        {
            _unitOfWork.CustomerInformations.Remove(customerInformation);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CustomerInformation>> GetAllCustomerInformations()
        {
            return await _unitOfWork.CustomerInformations
                .GetAllAsync();

        }



        public async Task<ListOfModels> GetAllCustomersAndAdressesWithLists()
        {
            return await _unitOfWork.CustomerInformations
                .GetAllCustomersAndAdressesWithList();


        }

        public async Task<CustomerInformation> GetCustomerInformationbyPersonalID(double PersonalID)
        {
            return await _unitOfWork.CustomerInformations
                .GetCustomerInformationbyPersonalID(PersonalID);
        }

        public async Task UpdateCustomerInformation(CustomerInformation customerInformationToBeUpdated, CustomerInformation customerInformation)
        {

            customerInformationToBeUpdated.Firstname = customerInformation.Firstname;
            customerInformationToBeUpdated.Lastname = customerInformation.Lastname;

            await _unitOfWork.CommitAsync();
        }


    }
}
