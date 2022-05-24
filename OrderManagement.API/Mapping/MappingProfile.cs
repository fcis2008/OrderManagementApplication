using AutoMapper;
using OrderManagement.API.Resources;
using OrderManagement.Core.Models;

namespace OrderManagement.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Supplier, SupplierResource>();
            CreateMap<Supplier, SupplierResource>().ForMember(
                dest => dest.StateName,
                input => input.MapFrom(src => $"{src.State.Name}"));

            CreateMap<State, StateResource>();

            // Resource to Domain
            CreateMap<SupplierResource, Supplier>();

            //CreateMap<SupplierResource, Supplier>().ForMember(
              //  dest => dest.State.Name,
                //input => input.MapFrom(src => $"{src.StateName}"));

            CreateMap<StateResource, State>();
        }
    }
}