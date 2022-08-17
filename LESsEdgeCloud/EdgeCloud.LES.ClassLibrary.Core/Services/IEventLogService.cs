using EdgeCloud.LES.ClassLibrary.Core.DTOs;
using EdgeCloud.LES.ClassLibrary.Core.Models;

namespace EdgeCloud.LES.ClassLibrary.Core.Services
{
    public interface IEventLogService : IService<EventLog>
    {
        Task<EventLogDto> AddAsync(EventLogDto entity);
    }
}
