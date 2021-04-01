namespace BicycleRent.Api.Resources
{
    public class AddressResource
    {
        public double AddressID { get; set; }

        public string AddressName { get; set; }

        public Customer_AddressResource Customer_Address { get; set; }
    }
}
