using AutoMapper;
using Secop.Core.Application.Features.Score.CreditScores.Commands.Create;
using Secop.Core.Domain.Entities.ScoreEntities;

namespace Secop.Core.Application.Features.Score.CreditScores.Profiles
{
    public class CreditScoreProfiles : Profile
    {
        public CreditScoreProfiles()
        {
            CreateMap<CreateCreditScoreCommand, CreditScore>();
            CreateMap<CreditScore, CreateCreditScoreCommandResponse>();
        }
    }
}
