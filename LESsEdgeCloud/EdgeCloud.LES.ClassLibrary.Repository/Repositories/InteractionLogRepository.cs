using EdgeCloud.LES.ClassLibrary.Core.Models;
using EdgeCloud.LES.ClassLibrary.Core.Repositories;
using EdgeCloud.LES.ClassLibrary.Repository.DBContexts;

namespace EdgeCloud.LES.ClassLibrary.Repository.Repositories
{
    public class InteractionLogRepository : GenericRepository<InteractionLog>, IInteractionLogRepository
    {
        public InteractionLogRepository(AppDbContext context) : base(context)
        {
        }
    }
}
