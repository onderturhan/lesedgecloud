using EdgeCloud.LES.ClassLibrary.Core.DTOs;
using EdgeCloud.LES.ClassLibrary.Core.Models;

namespace EdgeCloud.LES.ClassLibrary.Core.Services
{
    public interface INetworkLogService : IService<NetworkLog>
    {
        Task<NetworkLogDto> AddAsync(NetworkLogDto entity);
    }
}
