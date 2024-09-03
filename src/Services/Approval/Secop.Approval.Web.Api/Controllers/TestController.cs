using Microsoft.AspNetCore.Mvc;
using Secop.Core.ApiCommon.Controllers;
using Secop.Core.Application.Features.Approval.Test.Commands;

namespace Secop.Approval.Web.Api.Controllers
{
    public class TestController : BaseV1Controller
    {
        [HttpGet]
        public IActionResult Test()
        {
            Mediator.Send(new TestCommand());
            return Ok();
        }
    }
}
