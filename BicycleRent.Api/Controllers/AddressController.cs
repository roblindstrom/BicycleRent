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
    public class AddressController : Controller
    {

        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        public AddressController(IAddressService addressService, IMapper mapper)
        {
            this._mapper = mapper;
            this._addressService = addressService;
        }

        [HttpGet("GetAllAddresses")]
        public async Task<ActionResult<IEnumerable<AddressResource>>> GetAllAddresses()
        {
            var addresses = await _addressService.GetAllAddresses();
            var addressResources = _mapper.Map<IEnumerable<Address>, IEnumerable<AddressResource>>(addresses);

            return Ok(addressResources);
        }

        [HttpPost("CreateAddress")]
        public async Task<ActionResult<AddressResource>> CreateAddress([FromBody] SaveAddressResource saveAddressResource)
        {
            var validator = new SaveAddressResourceValidator();
            var validationResult = await validator.ValidateAsync(saveAddressResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var addressToCreate = _mapper.Map<SaveAddressResource, Address>(saveAddressResource);

            var newAddress = await _addressService.CreateAddress(addressToCreate);

            var address = await _addressService.GetAddressById(newAddress.AddressID);

            var addressResource = _mapper.Map<Address, AddressResource>(address);

            return Ok(addressResource);
        }

        [HttpGet("GetAddresById")]
        public async Task<ActionResult<AddressResource>> UpdateAddress(double AddressID)
        {
            var address = await _addressService.GetAddressById(AddressID);
            var addressResource = _mapper.Map<Address, AddressResource>(address);

            return Ok(addressResource);
        }

        [HttpDelete("DeleteAddressById")]
        public async Task<IActionResult> DeleteAddress(double AddressID)
        {
            if (AddressID == 0)
                return BadRequest();

            var address = await _addressService.GetAddressById(AddressID);

            if (address == null)
                return NotFound();

            await _addressService.DeleteAddress(address);

            return Ok("Address was deleted");
        }

    }
}
