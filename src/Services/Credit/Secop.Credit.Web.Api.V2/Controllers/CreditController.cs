using Microsoft.AspNetCore.Mvc;
using Secop.Core.ApiCommon.Controllers;

namespace Secop.Credit.Web.Api.V2.Controllers
{
    public class CreditController : BaseV2Controller
    {
        [HttpPost("[action]")]
        public IActionResult Application()
        {
            return Ok(new { test = "test" });
        }
    }
}
