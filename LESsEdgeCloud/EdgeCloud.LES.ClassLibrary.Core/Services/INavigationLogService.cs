using EdgeCloud.LES.ClassLibrary.Core.DTOs;
using EdgeCloud.LES.ClassLibrary.Core.Models;

namespace EdgeCloud.LES.ClassLibrary.Core.Services
{
    public interface INavigationLogService : IService<NavigationLog>
    {
        Task<NavigationLogDto> AddAsync(NavigationLogDto entity);
    }
}
