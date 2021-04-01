using BicycleRent.Core.Models;
using System.Collections.Generic;

namespace BicycleRent.Api.Resources
{
    public class ListOfResources
    {
        public List<Address> ListOfAddresses { get; set; }

        public List<Bicycle> ListOfBicyles { get; set; }

        public List<Booking> ListOfBookings { get; set; }
        public List<CustomerInformation> ListOfCustomerInformations { get; set; }
    }
}
