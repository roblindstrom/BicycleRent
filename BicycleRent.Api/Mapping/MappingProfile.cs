using AutoMapper;
using BicycleRent.Api.Mapping.Resolvers;
using BicycleRent.Api.Resources;
using BicycleRent.Core.Models;

namespace BicycleRent.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Bicycle, BicycleResource>();
            CreateMap<Booking, BookingResource>();

            CreateMap<CustomerInformation, CustomerInformationResource>();
            CreateMap<CustomerInformationAddress, Customer_AddressResource>();
            CreateMap<Address, AddressResource>();

            CreateMap<ListOfModels, ListOfResources>();


            // Resource to Domain
            CreateMap<BicycleResource, Bicycle>();
            CreateMap<BookingResource, Booking>();

            CreateMap<CustomerInformationResource, CustomerInformation>();
            CreateMap<Customer_AddressResource, CustomerInformationAddress>();
            CreateMap<AddressResource, Address>();

            CreateMap<ListOfResources, ListOfModels>();

            //Save to Domain
            CreateMap<SaveBicycleResource, Bicycle>();
            CreateMap<SaveBookingResource, Booking>()
                .ForMember(b => b.Bicycle, cfg => cfg
                .MapFrom<BookingBicycleResolver>())
                .ForMember(b => b.CustomerInformation, cfg => cfg
                .MapFrom<BookingCustomerInformationResolver>()); 

            CreateMap<SaveCustomerInformationResource, CustomerInformation>();
            CreateMap<SaveCustomer_AddressResource, CustomerInformationAddress>();
            CreateMap<SaveAddressResource, Address>();

            //Får lägga till listResurce till savelistresource om det behövs





        }
    }


}
