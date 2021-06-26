using AbashonWeb.Domain.Entities;
using AbashonWeb.Infrastructure.ViewModel;
using AutoMapper;

namespace AbashonWeb.Infrastructure.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel, Customer>()
                .ForMember(dest => dest.Id,
                        opt => opt.MapFrom(src => src.CustomerId))
                .ReverseMap();

            CreateMap<ClientModel, Client>()
                .ForMember(dest => dest.Id,
                            opt => opt.MapFrom(src => src.ClientId))
                .ReverseMap();
        }
    }
}
