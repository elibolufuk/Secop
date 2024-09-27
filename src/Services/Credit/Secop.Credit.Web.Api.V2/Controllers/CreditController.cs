using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Secop.Core.ApiCommon.Controllers;
using Secop.Core.ApiCommon.Responses;
using Secop.Core.Application.Features.Credit.CreditApplications.Commands.Create;
using Secop.Core.Messaging.Constants.V2;
using Secop.Core.Messaging.Events.V1;
using Secop.Core.Messaging.Events.V2;
using Secop.Core.Messaging.Interfaces;
using Secop.Credit.Web.Api.V1.Models;
using System.Net;

namespace Secop.Credit.Web.Api.V2.Controllers
{
    public class CreditController(IMapper mapper, ISendEndpointProvider sendEndpointProvider, ILogger<CreditController> logger)
        : BaseV2Controller
    {
        private readonly IMapper _mapper = mapper;
        private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;
        private readonly ILogger<CreditController> _logger = logger;

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(BaseApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseApiResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Application([FromBody] CreditApplicationModels model)
        {
            _logger.LogInformation("Credit Application Request : {Request}", model);
            var createCreditApplicationCommand = _mapper.Map<CreateCreditApplicationCommand>(model);
            var response = await Mediator.Send(createCreditApplicationCommand);

            var creditApplicationRequestEvent = _mapper.Map<CreditApplicationRequestEvent>(model);
            if (!response.Succeeded)
            {
                _logger.LogError("Credit Application could not save : {Request}, Response : {Response}", model, response);
                return BadRequest(new BaseApiResponse { Succeeded = false });
            }

            creditApplicationRequestEvent.CreditApplicationId = response.Data.Id;

            var sendEndProvider = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{QueueNameConstants.CreditApplicationSaga}"));
            await sendEndProvider.Send<ICreditApplicationRequestEvent>(creditApplicationRequestEvent);

            _logger.LogInformation($"{nameof(CreditApplicationCreatedEvent)} send : {{CreditApplicationCreatedEvent}}", creditApplicationRequestEvent);

            return Ok(new BaseApiResponse { Succeeded = true });
        }
    }
}
