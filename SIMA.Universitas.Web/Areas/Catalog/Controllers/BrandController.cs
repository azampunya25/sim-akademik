﻿using SIMA.Universitas.Application.Features.Brands.Commands.Delete;
using SIMA.Universitas.Application.Features.Brands.Queries.GetAllCached;
using SIMA.Universitas.Application.Features.Brands.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using SIMA.Universitas.Application.Features.Brands.Commands.Create;
using SIMA.Universitas.Application.Features.Brands.Commands.Update;
using SIMA.Universitas.Web.Abstractions;
using SIMA.Universitas.Web.Areas.Catalog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIMA.Universitas.Web.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    public class BrandController : BaseController<BrandController>
    {
        public IActionResult Index()
        {
            var model = new BrandViewModel();
            return View(model);
        }

        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllBrandsCachedQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<BrandViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            var brandsResponse = await _mediator.Send(new GetAllBrandsCachedQuery());

            if (id == 0)
            {
                var brandViewModel = new BrandViewModel();
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", brandViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetBrandByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var brandViewModel = _mapper.Map<BrandViewModel>(response.Data);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", brandViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, BrandViewModel brand)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var createBrandCommand = _mapper.Map<CreateBrandCommand>(brand);
                    var result = await _mediator.Send(createBrandCommand);
                    if (result.Succeeded)
                    {
                        id = result.Data;
                        _notify.Success($"Brand with ID {result.Data} Created.");
                    }
                    else _notify.Error(result.Message);
                }
                else
                {
                    var updateBrandCommand = _mapper.Map<UpdateBrandCommand>(brand);
                    var result = await _mediator.Send(updateBrandCommand);
                    if (result.Succeeded) _notify.Information($"Brand with ID {result.Data} Updated.");
                }
                var response = await _mediator.Send(new GetAllBrandsCachedQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<BrandViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html });
                }
                else
                {
                    _notify.Error(response.Message);
                    return null;
                }
            }
            else
            {
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", brand);
                return new JsonResult(new { isValid = false, html });
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            var deleteCommand = await _mediator.Send(new DeleteBrandCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Brand with Id {id} Deleted.");
                var response = await _mediator.Send(new GetAllBrandsCachedQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<BrandViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html });
                }
                else
                {
                    _notify.Error(response.Message);
                    return null;
                }
            }
            else
            {
                _notify.Error(deleteCommand.Message);
                return null;
            }
        }
    }
}