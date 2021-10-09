using AutoMapper;
using KITAB.CRUD.Products.Domain.Models;
using KITAB.CRUD.Products.Web.ViewModels;

namespace KITAB.CRUD.Products.Web.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
