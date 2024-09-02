using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Secop.Core.ApiCommon.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseV1Controller : ControllerBase
    {
        private IMediator? _mediator;

#pragma warning disable CS8603 // Possible null reference return.
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
#pragma warning restore CS8603 // Possible null reference return.
    }
}