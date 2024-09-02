using AutoMapper;
using Secop.Core.ApiCommon.Events;
using Secop.Core.Application.Features.Credit.CreditApplications.Commands.Create;
using Secop.Credit.Web.Api.Models;

namespace Secop.Credit.Web.Api.Profiles
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
