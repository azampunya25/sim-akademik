﻿using Microsoft.AspNetCore.Mvc;

namespace SIMA.Universitas.Web.Views.Shared.Components.Footer
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}