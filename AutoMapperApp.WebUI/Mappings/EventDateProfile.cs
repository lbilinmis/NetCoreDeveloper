using AutoMapper;
using AutoMapperApp.WebUI.Dtos;
using AutoMapperApp.WebUI.Models;

namespace AutoMapperApp.WebUI.Mappings
{
    public class EventDateProfile:Profile
    {
        public EventDateProfile()
        {
            CreateMap<EventDateDto, EventDate>().ForMember(x => x.Date, opt => opt.MapFrom(x => new DateTime(x.Year, x.Month, x.Day)));
            CreateMap<EventDate, EventDateDto>()
                .ForMember(x => x.Year, opt => opt.MapFrom(x => new DateTime(x.Date.Year)))
                .ForMember(x => x.Month, opt => opt.MapFrom(x => new DateTime(x.Date.Month)))
                .ForMember(x => x.Day, opt => opt.MapFrom(x => new DateTime(x.Date.Day)));


        }
    }
}
