using AutoMapper;

namespace AlwaysLowPrice.API.Infrastructure
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Model.User.User, DB.Entities.User>();
            CreateMap<DB.Entities.User, Model.User.User>();
        }
    }
}
