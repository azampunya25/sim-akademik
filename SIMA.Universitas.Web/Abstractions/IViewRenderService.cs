﻿using System.Threading.Tasks;

namespace SIMA.Universitas.Web.Abstractions
{
    public interface IViewRenderService
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}