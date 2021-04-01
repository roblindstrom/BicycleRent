namespace BicycleRent.Api.Resources
{
    public class CustomerInformationResource
    {

        public double PersonalID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public double Customer_AdressID { get; set; }

        //public ICollection<Booking> Bookings { get; set; }
        //Kanske onödig testar utan
    }
}
