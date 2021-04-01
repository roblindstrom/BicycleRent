using System;

namespace BicycleRent.Api.Resources
{
    public class SaveBookingResource
    {
        public double BookedBicycle { get; set; }

        public double CustomerWithBooking { get; set; }


        public DateTime BookingStartDate { get; set; }

        public DateTime BookingEndDate { get; set; }
    }
}
