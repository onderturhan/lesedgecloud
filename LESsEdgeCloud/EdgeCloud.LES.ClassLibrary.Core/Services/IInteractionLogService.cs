using EdgeCloud.LES.ClassLibrary.Core.DTOs;
using EdgeCloud.LES.ClassLibrary.Core.Models;

namespace EdgeCloud.LES.ClassLibrary.Core.Services
{
    public interface IInteractionLogService : IService<InteractionLog>
    {
        Task<InteractionLogDto> AddAsync(InteractionLogDto entity);
    }
}
