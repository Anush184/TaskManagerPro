using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.CustomUser.Commands.CreateUser;
using TaskManagerPro.Application.Features.CustomUser.Commands.UpdateUser;
using TaskManagerPro.Application.Features.CustomUser.Queries.GetAllUsers;
using TaskManagerPro.Application.Features.CustomUser.Queries.GetUserDetails;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<User, UserDetailsDto>().ReverseMap();
        CreateMap<CreateUserCommand, User>();
        CreateMap<UpdateUserCommand, User>();
    }
}
