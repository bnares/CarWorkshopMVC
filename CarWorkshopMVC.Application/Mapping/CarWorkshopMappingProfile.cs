using AutoMapper;
using CarWorkshopMVC.Application.CarWorkshop;
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
        public CarWorkshopMappingProfile()
        {
            CreateMap<CarWorkshopDTO, Domain.Entities.CarWorkshop>()
                .ForMember(x => x.ContactDetails, opt => opt.MapFrom(src => new CarWorkshopContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                })).ReverseMap();
        }
    }
}
