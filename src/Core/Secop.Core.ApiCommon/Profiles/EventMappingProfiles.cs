using AutoMapper;
using Secop.Core.ApiCommon.Events;

namespace Secop.Core.ApiCommon.Profiles
{
    public class EventMappingProfiles : Profile
    {
        public EventMappingProfiles()
        {
            CreateMap<CreditApplicationCreatedEvent, CreditScoreCreatedEvent>();
        }
    }
}