using AutoMapper;
using MakersOfDenmark.Api.Resources;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Models.Auth;

public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserSignUpResource, User>()
            .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }