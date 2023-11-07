using AutoMapper;
using CarWorkshopMVC.Application.ApplicationUser;
using CarWorkshopMVC.Application.CarWorkshop;
using CarWorkshopMVC.Application.CarWorkshopService;
using CarWorkshopMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.Mapping
{
    public class CarWorkshopMappingProfile : Profile
    {
        
        public CarWorkshopMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<CarWorkshopDTO, Domain.Entities.CarWorkshop>()
                .ForMember(x => x.ContactDetails, opt => opt.MapFrom(src => new CarWorkshopContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                })).ReverseMap();

            CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDTO>()
                .ForMember(x => x.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(x=>x.City, opt => opt.MapFrom(src=>src.ContactDetails.City))
                .ForMember(x=>x.PostalCode, opt=>opt.MapFrom(src=>src.ContactDetails.PostalCode))
                .ForMember(x=>x.PhoneNumber, opt=>opt.MapFrom(src=>src.ContactDetails.PhoneNumber))
                .ForMember(dto=>dto.IsEditable, opt=>opt.MapFrom(src=>user != null && src.CreatedById==user.Id));

            CreateMap<CarWorkshopSericeDto, Domain.Entities.CarWorkshopService>().ReverseMap();
        }
    }
}
