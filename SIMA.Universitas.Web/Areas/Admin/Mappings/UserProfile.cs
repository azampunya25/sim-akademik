using AutoMapper;
using SIMA.Universitas.Infrastructure.Identity.Models;
using SIMA.Universitas.Web.Areas.Admin.Models;

namespace SIMA.Universitas.Web.Areas.Admin.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }
    }
}