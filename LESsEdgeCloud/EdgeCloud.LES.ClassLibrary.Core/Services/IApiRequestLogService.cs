using EdgeCloud.LES.ClassLibrary.Core.DTOs;
using EdgeCloud.LES.ClassLibrary.Core.Models;

namespace EdgeCloud.LES.ClassLibrary.Core.Services
{
    public interface IApiRequestLogService : IService<ApiRequestLog>
    {
        Task<ApiRequestLogDto> AddAsync(ApiRequestLogDto entity);
    }
}
