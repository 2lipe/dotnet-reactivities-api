using AutoMapper;
using Reactivities.Domain.Entities;

namespace Reactivities.Application.Mappers
{
    public class ActivityProfileMapper : Profile
    {
        public ActivityProfileMapper()
        {
            CreateMap<Activity, Activity>()
                .ForMember(activity => activity.Id, opt => opt.Ignore());
        }
    }
}