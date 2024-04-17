using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SIMA.Universitas.Application.DTOs.Logs;
using SIMA.Universitas.Application.Interfaces.Shared;
using SIMA.Universitas.Web.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMA.Universitas.Application.Features.Logs.Queries.GetCurrentUserLogs;

namespace SIMA.Universitas.Web.Areas.Identity.Pages.Account
{
    public class AuditLogModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _userService;
        public List<AuditLogResponse> AuditLogResponses;
        private IViewRenderService _viewRenderer;

        public AuditLogModel(IMediator mediator, IAuthenticatedUserService userService, IViewRenderService viewRenderer)
        {
            _mediator = mediator;
            _userService = userService;
            _viewRenderer = viewRenderer;
        }

        public async Task OnGet()
        {
            var response = await _mediator.Send(new GetAuditLogsQuery() { userId = _userService.UserId });
            AuditLogResponses = response.Data;
        }
    }
}