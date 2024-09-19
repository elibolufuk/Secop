using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Secop.Core.ApiCommon.Controllers;
using Secop.Core.ApiCommon.Events;
using Secop.Core.ApiCommon.Responses;
using Secop.Core.Application.Features.Credit.CreditApplications.Commands.Create;
using Secop.Credit.Web.Api.Models;
using System.Net;

namespace Secop.Credit.Web.Api.Controllers
{
    public class CreditController(IMapper mapper, IPublishEndpoint publishEndpoint, ILogger<CreditController> logger)
        : BaseV1Controller
    {
        private readonly IMapper _mapper = mapper;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        private readonly ILogger<CreditController> _logger = logger;

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(BaseApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseApiResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Application([FromBody] CreditApplicationModels model)
        {
            _logger.LogInformation("Credit Application Request : {Request}", model);
            var createCreditApplicationCommand = _mapper.Map<CreateCreditApplicationCommand>(model);
            var response = await Mediator.Send(createCreditApplicationCommand);

            var creditApplicationCreatedEvent = _mapper.Map<CreditApplicationCreatedEvent>(model);
            if (!response.Succeeded)
            {
                _logger.LogError("Credit Application could not save : {Request}, Response : {Response}", model, response);
                return BadRequest(new BaseApiResponse { Succeeded = false });
            }

            creditApplicationCreatedEvent.CreditApplicationId = response.Data.Id;
            await _publishEndpoint.Publish(creditApplicationCreatedEvent);
            _logger.LogInformation($"{nameof(CreditApplicationCreatedEvent)} publish : {{CreditApplicationCreatedEvent}}", creditApplicationCreatedEvent);

            return Ok(new BaseApiResponse { Succeeded = true });
        }
    }
}