using AutoMapper;
using BicycleRent.Api.Resources;
using BicycleRent.Core.Models;
using BicycleRent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleRent.Api.Mapping.Resolvers
{
    public class BookingCustomerInformationResolver : IValueResolver<SaveBookingResource, Booking, CustomerInformation>
    {
        public BookingCustomerInformationResolver(BicycleRentDbContext bicycleRentDbContext)
        {
            _bicycleRentDbContext = bicycleRentDbContext;
        }
        private BicycleRentDbContext _bicycleRentDbContext;

        public CustomerInformation Resolve(SaveBookingResource source, Booking destination, CustomerInformation destMember, ResolutionContext context)
        {
            var returnbooking = _bicycleRentDbContext.CustomerInformations.FirstOrDefault(x => x.PersonalID == source.CustomerWithBooking);

            return returnbooking;
        }
    }
}
