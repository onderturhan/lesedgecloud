using AutoMapper;
using EdgeCloud.LES.ClassLibrary.Core.DTOs;
using EdgeCloud.LES.ClassLibrary.Core.Models;

namespace EdgeCloud.LES.ClassLibrary.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ApiRequestLogDto, ApiRequestLog>()
                .ReverseMap();
            CreateMap<UserAuthenticationLogDto, UserAuthenticationLog>()
                .ReverseMap();
            CreateMap<InteractionLogDto, InteractionLog>()
                .ReverseMap();
            CreateMap<NavigationLogDto, NavigationLog>()
                .ReverseMap();
            CreateMap<NetworkLogDto, NetworkLog>()
                .ReverseMap();
        }
    }
}
