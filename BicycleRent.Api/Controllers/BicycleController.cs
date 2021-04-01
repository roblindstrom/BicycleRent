
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
    public class BicycleController : ControllerBase
    {

        private readonly IBicycleService _bicycleService;
        private readonly IMapper _mapper;

        public BicycleController(IBicycleService bicycleService, IMapper mapper)
        {

            this._mapper = mapper;
            this._bicycleService = bicycleService;
        }

        [HttpGet("GetAllBicycles")]
        public async Task<ActionResult<IEnumerable<BicycleResource>>> GetAllBicycles()
        {
            var bicycles = await _bicycleService.GetAllBicyclesAsync();
            var bicycleResources = _mapper.Map<IEnumerable<Bicycle>, IEnumerable<BicycleResource>>(bicycles);

            return Ok(bicycleResources);
        }



        [HttpGet("GetBicycleById")]
        public async Task<ActionResult<BicycleResource>> GetBicycleById(double id)
        {
            var bicycle = await _bicycleService.GetBicycleByIdAsync(id);
            var bicycleResource = _mapper.Map<Bicycle, BicycleResource>(bicycle);

            return Ok(bicycleResource);
        }

        [HttpPost("CreateBicycle")]
        public async Task<ActionResult<BicycleResource>> CreateBicycle([FromBody] SaveBicycleResource saveBicycleResource)
        {
            var validator = new SaveBicycleResourceValidator();
            var validationResult = await validator.ValidateAsync(saveBicycleResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var bicycleToCreate = _mapper.Map<SaveBicycleResource, Bicycle>(saveBicycleResource);

            var newBicycle = await _bicycleService.CreateBicycleAsync(bicycleToCreate);

            var bicycle = await _bicycleService.GetBicycleByIdAsync(newBicycle.BicycleId);

            var bicycleResource = _mapper.Map<Bicycle, BicycleResource>(bicycle);

            return Ok(bicycleResource);


        }

        [HttpPut("UpdateBicycleById")]
        public async Task<ActionResult<BicycleResource>> UpdateBicycle(double id, [FromBody] SaveBicycleResource saveBicycleResource)
        {
            var validator = new SaveBicycleResourceValidator();
            var validationResult = await validator.ValidateAsync(saveBicycleResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var bicycleToBeUpdate = await _bicycleService.GetBicycleByIdAsync(id);

            if (bicycleToBeUpdate == null)
                return NotFound();

            var bicycle = _mapper.Map<SaveBicycleResource, Bicycle>(saveBicycleResource);

            await _bicycleService.UpdateBicycle(bicycleToBeUpdate, bicycle);

            var updatedBicycle = await _bicycleService.GetBicycleByIdAsync(id);
            var updatedBicycleResource = _mapper.Map<Bicycle, BicycleResource>(updatedBicycle);

            return Ok(updatedBicycleResource);
        }

        [HttpDelete("DeleteBicycleById")]
        public async Task<IActionResult> DeleteBicycle(double id)
        {
            if (id == 0)
                return BadRequest();

            var bicycle = await _bicycleService.GetBicycleByIdAsync(id);

            if (bicycle == null)
                return NotFound();

            await _bicycleService.DeleteBicycleAsync(bicycle);

            return NoContent();
        }


    }
}
