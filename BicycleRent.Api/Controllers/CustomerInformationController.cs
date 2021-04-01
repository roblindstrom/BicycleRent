using AutoMapper;
using BicycleRent.Api.Resources;
using BicycleRent.Api.Validators;
using BicycleRent.Core.Models;
using BicycleRent.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInformationController : ControllerBase
    {

        private readonly ICustomerInformationService _customerInformationService;
        private readonly IMapper _mapper;
        public CustomerInformationController(ICustomerInformationService customerInformationService, IMapper mapper)
        {
            this._mapper = mapper;
            this._customerInformationService = customerInformationService;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<CustomerInformationResource>>> GetAllCustomerInformation()
        {
            var customerInformations = await _customerInformationService.GetAllCustomerInformations();
            var customerInformationResources = _mapper.Map<IEnumerable<CustomerInformation>, IEnumerable<CustomerInformationResource>>(customerInformations);

            return Ok(customerInformationResources);
        }


        [HttpGet("GetAllCustomersAndAllAddresses")]
        public async Task<ActionResult<ListOfResources>> GetAllCustomersAndAdressesWithLists()
        {
            var listOfModels = await _customerInformationService.GetAllCustomersAndAdressesWithLists();

            var listOfResources = _mapper.Map<ListOfModels, ListOfResources>(listOfModels);

            return Ok(listOfResources);
        }
        [HttpPost("CreateCustomer")]
        public async Task<ActionResult<CustomerInformationResource>> CreateCustomerInformation([FromBody] SaveCustomerInformationResource saveCustomerInformationResource)
        {

            var validator = new SaveCustomerInformationResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCustomerInformationResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var customerInformationToCreate = _mapper.Map<SaveCustomerInformationResource, CustomerInformation>(saveCustomerInformationResource);

            var newCustomerInformation = await _customerInformationService.CreateCustomerInformation(customerInformationToCreate);

            var customerInformation = await _customerInformationService.GetCustomerInformationbyPersonalID(newCustomerInformation.PersonalID);

            var customerInformationResource = _mapper.Map<CustomerInformation, CustomerInformationResource>(customerInformation);

            return Ok(customerInformationResource);
        }

        [HttpPut("UpdateCustomerById{id}")]
        public async Task<ActionResult<CustomerInformationResource>> UpdateCustomerInformation(double PersonalID, [FromBody] SaveCustomerInformationResource saveCustomerInformationResource)
        {
            var validator = new SaveCustomerInformationResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCustomerInformationResource);

            var requestIsInvalid = PersonalID == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var customerInformationToBeUpdate = await _customerInformationService.GetCustomerInformationbyPersonalID(PersonalID);

            if (customerInformationToBeUpdate == null)
                return NotFound();

            var customerInformation = _mapper.Map<SaveCustomerInformationResource, CustomerInformation>(saveCustomerInformationResource);

            await _customerInformationService.UpdateCustomerInformation(customerInformationToBeUpdate, customerInformation);

            var updatedCustomerInformation = await _customerInformationService.GetCustomerInformationbyPersonalID(PersonalID);
            var updatedCustomerInformationResource = _mapper.Map<CustomerInformation, CustomerInformationResource>(updatedCustomerInformation);

            return Ok(updatedCustomerInformationResource);


        }

        [HttpDelete("DeleteCustomer{id}")]
        public async Task<IActionResult> DeleteCustomerInformation(double PersonalID)
        {
            if (PersonalID == 0)
                return BadRequest();

            var customerInformation = await _customerInformationService.GetCustomerInformationbyPersonalID(PersonalID);

            if (customerInformation == null)
                return NotFound();

            await _customerInformationService.DeleteCustomerInformation(customerInformation);

            return NoContent();
        }

    }
}
