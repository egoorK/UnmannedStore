using System;
using AutoMapper;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Application.Features.Images.Commands.SaveImage;
using ProductRecognition.Application.Features.Images.Queries.GetImageById;

namespace ProductRecognition.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Image, SaveImageCommand>()
                .ForMember(dest => dest.Image_Base64, act => act.MapFrom(src => src.Image_Base64))
                .ForMember(dest => dest.Account_ID, act => act.MapFrom(src => src.AccountID))
                .ReverseMap();

            CreateMap<Image, ImageVm>().ReverseMap();
        }
    }
}
