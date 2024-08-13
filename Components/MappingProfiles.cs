using AutoMapper;
using DotNetWebAPI.Controllers;

namespace DotNetWebAPI.Components
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles() {
            CreateMap<UserRegistrationModel, UserRegistrationModel1>();
        }
    }
}
