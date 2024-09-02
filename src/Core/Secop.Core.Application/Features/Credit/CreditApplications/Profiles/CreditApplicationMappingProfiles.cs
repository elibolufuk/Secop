using AutoMapper;
using Secop.Core.Application.Features.Credit.CreditApplications.Commands.Create;
using Secop.Core.Domain.Entities.CreditEntities;

namespace Secop.Core.Application.Features.Credit.CreditApplications.Profiles
{
    public class CreditApplicationMappingProfiles : Profile
    {
        public CreditApplicationMappingProfiles()
        {
            CreateMap<CreateCreditApplicationCommand, CreditApplication>();
        }
    }
}
