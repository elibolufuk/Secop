using AutoMapper;
using Secop.Core.Messaging.Events.V1;
using Secop.Core.Application.Features.Score.CreditScores.Commands.Create;

namespace Secop.Score.Web.Api.V1.Profiles
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
