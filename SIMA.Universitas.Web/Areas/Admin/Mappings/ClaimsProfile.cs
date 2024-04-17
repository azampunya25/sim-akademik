﻿using AutoMapper;
using SIMA.Universitas.Web.Areas.Admin.Models;
using System.Security.Claims;

namespace SIMA.Universitas.Web.Areas.Admin.Mappings
{
    public class ClaimsProfile : Profile
    {
        public ClaimsProfile()
        {
            CreateMap<Claim, RoleClaimsViewModel>().ReverseMap();
        }
    }
}