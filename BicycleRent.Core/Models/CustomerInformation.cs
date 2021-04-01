using System.Collections.Generic;

namespace BicycleRent.Core.Models
{
    public class CustomerInformation
    {
        public double PersonalID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public double Customer_AdressID { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public ICollection<CustomerInformationAddress> Customer_Addresses { get; set; }
    }
}
