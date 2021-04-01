using System;

namespace BicycleRent.Core.Models
{
    public class Booking
    {



        public double BookedBicycle { get; set; }

        public double CustomerWithBooking { get; set; }

        public DateTime BookingStartDate { get; set; }

        public DateTime BookingEndDate { get; set; }

        public Bicycle Bicycle { get; set; }

        public CustomerInformation CustomerInformation { get; set; }




    }
}
