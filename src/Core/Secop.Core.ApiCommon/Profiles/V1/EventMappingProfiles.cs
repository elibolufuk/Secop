using AutoMapper;
using Secop.Core.ApiCommon.Events.V1;

namespace Secop.Core.ApiCommon.Profiles.V1
{
    public class EventMappingProfiles : Profile
    {
        public EventMappingProfiles()
        {
            CreateMap<CreditApplicationCreatedEvent, CreditScoreCreatedEvent>();
        }
    }
}