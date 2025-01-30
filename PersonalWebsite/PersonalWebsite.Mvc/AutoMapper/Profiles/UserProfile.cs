using AutoMapper;
using PersonalWebsite.Entities.Concrete;
using PersonalWebsite.Entities.Dtos;

namespace PersonalWebsite.Mvc.AutoMapper.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
        }
    }
}
