using EdgeCloud.LES.ClassLibrary.Core.DTOs;
using EdgeCloud.LES.ClassLibrary.Core.Models;

namespace EdgeCloud.LES.ClassLibrary.Core.Services
{
    public interface IUserAuthenticationLogService : IService<UserAuthenticationLog>
    {
        Task<UserAuthenticationLogDto> AddAsync(UserAuthenticationLogDto entity);
    }
}
