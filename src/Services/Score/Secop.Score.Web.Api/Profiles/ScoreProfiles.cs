using AutoMapper;
using Secop.Core.ApiCommon.Events;
using Secop.Core.Application.Features.Score.CreditScores.Commands.Create;

namespace Secop.Score.Web.Api.Profiles
{
    public class ScoreProfiles : Profile
    {
        public ScoreProfiles()
        {
            CreateMap<CreditApplicationCreatedEvent, CreateCreditScoreCommand>();
            CreateMap<CreateCreditScoreCommandResponse, CreditScoreCreatedEvent>();
        }
    }
}
