using System.Collections.Generic;

namespace BicycleRent.Core.Models
{
    public class Address
    {
        public Address()
        {
            Customer_Addresses = new List<CustomerInformationAddress>();
        }

        public double AddressID { get; set; }

        public string AddressName { get; set; }

        public ICollection<CustomerInformationAddress> Customer_Addresses { get; set; }
    }
}
