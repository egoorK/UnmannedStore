using AutoMapper;
using BasketFormation.Domain.Entities;
using BasketFormation.Application.Features.Accounts.Commands.CreateAccount;
using BasketFormation.Application.Features.Accounts.Commands.UpdateAccount;
using BasketFormation.Application.Features.Accounts.Commands.DeleteAccount;
using BasketFormation.Application.Features.Products.Commands.CreateProduct;
using BasketFormation.Application.Features.Products.Commands.UpdateProduct;
using BasketFormation.Application.Features.Products.Commands.DeleteProduct;

namespace BasketFormation.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, CreateAccountCommand>().ReverseMap();
            CreateMap<Account, UpdateAccountCommand>().ReverseMap();
            CreateMap<Account, DeleteAccountCommand>()
                .ForMember(dest => dest.Account_ID, act => act.MapFrom(src => src.Account_ID))
                .ReverseMap();

            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, DeleteProductCommand>()
                .ForMember(dest => dest.Product_ID, act => act.MapFrom(src => src.Product_ID))
                .ReverseMap();
        }
    }
}
