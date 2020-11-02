using AutoMapper;
using MakersOfDenmark.Api.Resources;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Models;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Badges;
using MakersOfDenmark.Core.Models.Makerspaces;

public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Resource to Domain mappings - used when modifying data
            CreateMap<UserSignUpResource, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
            CreateMap<RoleResource, Role>();
            CreateMap<UserResource, User>();
            CreateMap<MakerspaceResource, Makerspace>();
            CreateMap<SaveMakerspaceResource, Makerspace>();
            CreateMap<SaveBadgeResource, Badge>();
            
            //Domain to Resource mappings - used when getting data
            CreateMap<Makerspace, MakerspaceResource>();
            CreateMap<Makerspace, SaveMakerspaceResource>();
            CreateMap<User, UserResource>();
            CreateMap<Address, AddressResource>();
            CreateMap<Badge, BadgeResource>();
        }
    }