using AnyCore.Core.Domain.ApplicationUser;
using AnyCore.Web.Models.ApplicationUsers;
using AutoMapper;

namespace AnyCore.Web.AutoMapperProfiles
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        : this("Profile")
        {
        }
        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<LoginViewModel, ApplicationUser>();
        }
    }
}
