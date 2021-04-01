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
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            this._mapper = mapper;
            this._bookingService = bookingService;
        }

        [HttpGet("GetAllBookings")]
        public async Task<ActionResult<IEnumerable<BookingResource>>> GetAllbookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            var bookingResources = _mapper.Map<IEnumerable<Booking>, IEnumerable<BookingResource>>(bookings);


            return Ok(bookingResources);
        }



        [HttpGet("GetBookingById")]
        public async Task<ActionResult<BookingResource>> GetBookingById(double id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            var bookingResource = _mapper.Map<Booking, BookingResource>(booking);

            return Ok(bookingResource);
        }

        [HttpPost("CreateBooking")]
        public async Task<ActionResult<BookingResource>> CreateBooking([FromBody] SaveBookingResource saveBookingResource)
        {
            var validator = new SaveBookingResourceValidator();
            var validationResult = await validator.ValidateAsync(saveBookingResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var bookingToCreate = _mapper.Map<SaveBookingResource, Booking>(saveBookingResource);

            var newBooking = await _bookingService.CreateBooking(bookingToCreate);

            var bookingResource = _mapper.Map<Booking, BookingResource>(newBooking);

            return Ok(bookingResource);
        }

        [HttpPut("UpdateBookingById")]
        public async Task<ActionResult<BookingResource>> UpdateBooking(double id, [FromBody] SaveBookingResource saveBookingResource)
        {
            var validator = new SaveBookingResourceValidator();
            var validationResult = await validator.ValidateAsync(saveBookingResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var bookingToBeUpdated = await _bookingService.GetBookingByIdAsync(id);

            if (bookingToBeUpdated == null)
                return NotFound();

            var booking = _mapper.Map<SaveBookingResource, Booking>(saveBookingResource);

            await _bookingService.UpdateBooking(bookingToBeUpdated, booking);

            var updatedBooking = await _bookingService.GetBookingByIdAsync(id);

            var updatedBookingResource = _mapper.Map<Booking, BookingResource>(updatedBooking);

            return Ok(updatedBookingResource);
        }

        [HttpDelete("DeteleBookingById{id}")]
        public async Task<IActionResult> DeleteBooking(double id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);

            await _bookingService.DeleteBooking(booking);

            return NoContent();
        }
    }
}
