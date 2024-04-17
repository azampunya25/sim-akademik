using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SIMA.Universitas.Web.Areas.Admin.Models;

namespace SIMA.Universitas.Web.Areas.Admin.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
        }
    }
}