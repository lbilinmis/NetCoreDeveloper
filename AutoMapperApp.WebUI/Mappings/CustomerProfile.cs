﻿using AutoMapper;
using AutoMapperApp.WebUI.Dtos;
using AutoMapperApp.WebUI.Models;

namespace AutoMapperApp.WebUI.Mappings
{
    public class CustomerProfile : Profile
    {
        // automapper işlemi için miras aldık
        // hangi nesnesinin neye dönüşeceğini burda sağlarız

        public CustomerProfile()
        {
            //Ya bu şekilde ayrı ayrı yazılır
            //CreateMap<Customer,CustomerDto>();
            //CreateMap<CustomerDto,Customer>();

            //Ya da bu şekilde tek bir yerde yazılır
            //CreateMap<CustomerDto, Customer>().ReverseMap();

            ////Farklı propery ler olması durumunda tek tek eşleme yapılmalı
            //CreateMap<Customer, CustomerDiferentPropertyDto>()
            //    .ForMember(dest => dest.Ad, opt => opt.MapFrom(x => x.Name))
            //    .ForMember(dest => dest.Eposta, opt => opt.MapFrom(x => x.Email))
            //    .ForMember(dest => dest.Yas, opt => opt.MapFrom(x => x.Age))
            //    .ForMember(dest => dest.CustomerEmailAndAge, opt => opt.MapFrom(x => x.CustomerEmailAndAgeNotSameProperty()));

            //Farklı propery ler olması durumunda tek tek eşleme yapılmalı
            CreateMap<Customer, CustomerFlatenning>()
                .ForMember(dest => dest.Ad, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Eposta, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Yas, opt => opt.MapFrom(x => x.Age))
                .ForMember(dest => dest.CustomerEmailAndAge, opt => opt.MapFrom(x => x.CustomerEmailAndAgeNotSameProperty()))
                .ForMember(dest => dest.CreditCardNumber, opt => opt.MapFrom(x => x.CreditCard.Number))
                .ForMember(dest => dest.CreditCardValidTime, opt => opt.MapFrom(x => x.CreditCard.ValidTime));




        }
    }
}
