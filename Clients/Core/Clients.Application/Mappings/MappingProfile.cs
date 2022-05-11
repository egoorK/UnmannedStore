using System;
using AutoMapper;
using Clients.Domain.Entities;
using Clients.Application.DTOForEvents;
using Clients.Application.Features.Accounts.Commands.CreateAccount;
using Clients.Application.Features.Accounts.Commands.UpdateAccount;
using Clients.Application.Features.Accounts.Commands.DeleteAccount;
using Clients.Application.Features.Accounts.Queries.GetAccounts;

namespace Clients.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, CreateAccountCommand>()
                .ForMember(dest => dest.Username, act => act.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.Date_of_Birth, act => act.MapFrom(src => src.Date_of_Birth))
                .ForMember(dest => dest.Phone_number, act => act.MapFrom(src => src.Phone_number))
                .ReverseMap(); // Конвертация происходит в обоих направлениях

            CreateMap<Account, UpdateAccountCommand>()
                .ForMember(dest => dest.Account_ID, act => act.MapFrom(src => src.Account_ID))
                .ForMember(dest => dest.Username, act => act.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.Date_of_Birth, act => act.MapFrom(src => src.Date_of_Birth))
                .ForMember(dest => dest.Phone_number, act => act.MapFrom(src => src.Phone_number))
                .ReverseMap();

            CreateMap<Account, DeleteAccountCommand>()
                .ForMember(dest => dest.Account_ID, act => act.MapFrom(src => src.Account_ID))
                .ReverseMap();

            CreateMap<Account, AccountsVm>()
                .ForMember(dest => dest.Account_ID, act => act.MapFrom(src => src.Account_ID))
                .ForMember(dest => dest.Username, act => act.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.Date_of_Birth, act => act.MapFrom(src => src.Date_of_Birth))
                .ForMember(dest => dest.Phone_number, act => act.MapFrom(src => src.Phone_number))
                .ReverseMap();

            CreateMap<CreateAccountCommand, AccountCreatedEvent>()
                .ForMember(dest => dest.Username, act => act.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.Date_of_Birth, act => act.MapFrom(src => src.Date_of_Birth))
                .ForMember(dest => dest.Phone_number, act => act.MapFrom(src => src.Phone_number))
                .ReverseMap();

        }
    }
}
