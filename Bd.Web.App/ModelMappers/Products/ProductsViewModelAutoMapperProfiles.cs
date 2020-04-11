using AutoMapper;
using Bd.Web.App.DtoModels;
using Bd.Web.App.Models;

namespace Bd.Web.App.ModelMappers.Products
{
    public class ProductsViewModelAutoMapperProfiles  : Profile
    {
        public ProductsViewModelAutoMapperProfiles()
        {
            CreateMap<ProductDto, ProductModel>().ReverseMap();
        }
    }
}
