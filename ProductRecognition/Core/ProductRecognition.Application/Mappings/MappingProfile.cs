using AutoMapper;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Application.Features.Images.Commands.SaveImage;
using ProductRecognition.Application.Features.Images.Commands.UpdateImage;
using ProductRecognition.Application.Features.Images.Commands.DeleteImage;
using ProductRecognition.Application.Features.Images.Queries.GetImageById;
using ProductRecognition.Application.Features.Accounts.Commands.CreateAccount;

namespace ProductRecognition.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Image, SaveImageCommand>()
                .ForMember(dest => dest.Account_ID, act => act.MapFrom(src => src.AccountID))
                .ForMember(dest => dest.Image_Base64, act => act.MapFrom(src => src.Image_Base64))
                .ReverseMap();

            CreateMap<Image, UpdateImageCommand>()
                .ForMember(dest => dest.Image_Base64, act => act.MapFrom(src => src.Image_Base64))
                .ForMember(dest => dest.Image_ID, act => act.MapFrom(src => src.Image_ID))
                .ForMember(dest => dest.Term_of_Receipt, act => act.MapFrom(src => src.Term_of_Receipt))
                .ReverseMap();

            CreateMap<Image, DeleteImageCommand>()
                .ForMember(dest => dest.Image_ID, act => act.MapFrom(src => src.Image_ID))
                .ReverseMap();

            CreateMap<Image, ImageVm>().ReverseMap();

            CreateMap<Account, CreateAccountCommand>()
                .ForMember(dest => dest.Account_ID, act => act.MapFrom(src => src.Account_ID))
                .ForMember(dest => dest.Username, act => act.MapFrom(src => src.Username))
                .ReverseMap();
        }
    }
}
