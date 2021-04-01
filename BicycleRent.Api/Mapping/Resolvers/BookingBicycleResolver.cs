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
    public class BookingBicycleResolver : IValueResolver<SaveBookingResource, Booking, Bicycle>
    {
        public BookingBicycleResolver(BicycleRentDbContext bicycleRentDbContext)
        {
            _bicycleRentDbContext = bicycleRentDbContext;
        }

        private BicycleRentDbContext _bicycleRentDbContext;
        public Bicycle Resolve(SaveBookingResource source, Booking destination, Bicycle destMember, ResolutionContext context)
        {
            return _bicycleRentDbContext.Bicycles.Find(source.BookedBicycle);
        }
    }
}
