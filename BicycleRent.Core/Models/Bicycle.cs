using BicycleRent.Shared;
using System.Collections.Generic;

namespace BicycleRent.Core.Models
{
    public class Bicycle
    {

        public Bicycle()
        {
            Bookings = new List<Booking>();
        }


        public double BicycleId { get; set; }

        public double PricePerDay { get; set; }



        //public int BookingID { get; set; }
        public BicycleBrand BicycleBrand { get; set; }

        public BicycleSize BicycleSize { get; set; }

        public ICollection<Booking> Bookings { get; set; }


    }
}
