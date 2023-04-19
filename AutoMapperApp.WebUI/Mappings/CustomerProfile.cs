using AutoMapper;
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
            CreateMap<CustomerDto, Customer>().ReverseMap();

        }
    }
}
