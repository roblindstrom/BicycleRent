namespace BicycleRent.Core.Models
{
    public class CustomerInformationAddress
    {

        public double Customer_AddressID { get; set; }

        public double AddressID { get; set; }

        public Address Address { get; set; }

        public CustomerInformation CustomerInformation { get; set; }



    }
}
