using AutoMapper;
using Secop.Core.Messaging.Events.V1;
using Secop.Core.Application.Features.Credit.CreditApplications.Commands.Create;
using Secop.Credit.Web.Api.V1.Models;

namespace Secop.Credit.Web.Api.V1.Profiles
{
    public class CreditProfiles : Profile
    {
        public CreditProfiles()
        {
            CreateMap<CreditApplicationModels, CreateCreditApplicationCommand>();
            CreateMap<CreditApplicationModels, CreditApplicationCreatedEvent>();
        }
    }
}
